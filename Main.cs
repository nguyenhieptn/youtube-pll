using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Keys = OpenQA.Selenium.Keys;

namespace Youtube_PLL
{
    public partial class Main : Form
    {
        int pllCreated = 0;
        public Main()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            Thread thread = new Thread(new ThreadStart(new Action(() =>
            {
                Log("Start");
            })));
            thread.Start();
        }

        private void newProfileBtn_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(OpenProfile));
            thread.Start();
        }

        private void InitPlaylist()
        {
            Thread thread = new Thread(new ThreadStart(() =>
            {
                bool isMulti = multiCb.Checked;
                var path = profileLb.Text;
                if (!isMulti)
                {
                    var keyword = KeywordTb.Text;
                    CreatePlaylist(path, keyword);
                }
                else
                {
                    var paths = Directory.GetDirectories(path).ToList();
                    var stop = false;
                    while (!stop) {
                        var keyword = KeywordTb.Text;
                        if (string.IsNullOrEmpty(keyword)) break;
                        Log(paths.Count + " Profiles");
                        if (paths.Count() == 0) break;
                        var p = paths.First();
                        Log("Start Profile: "+p);
                        paths.RemoveAt(0);
                        if (runBackCb.Checked)
                        {
                            paths.Add(p);
                        }
                        if (path.Count() == 0) stop = true;
                        CreatePlaylist(p, keyword);
                        Thread.Sleep(5000);
                    }
                }
            }));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        private void CreatePlaylist(string path, string keyword)
        {
            try
            {
                Chrome chrome = new Chrome(path);
                chrome.GoToURL("https://www.youtube.com/");
                Console.WriteLine(chrome.CountElements("button#avatar-btn"));
                if (chrome.CountElements("button#avatar-btn") == 0)
                {
                    Log("Please login youtube");
                    MessageBox.Show("Please login youtube");
                    chrome.Close();
                    chrome.Quit();
                    return;
                }

                var videoId = videoTb.Text;
                var num = int.Parse(NumPllTb.Text);
                Log("Create " + num + " playlists.");
                for (var i = 0; i < num; i++)
                {
                    Log("Create playlist " + (i+1));
                    bool created = CreateOnePlaylist(chrome, keyword, videoId);
                    if (!created) break;
                }
                chrome.Close();
                chrome.Quit();
            }
            catch (Exception e)
            {
                Log(e.Message);
                MessageBox.Show(e.Message);
            }
        }

        private bool CreateOnePlaylist(Chrome chrome, string keyword, string videoId)
        {
        StartCreate:
            chrome.GoToURL("https://www.youtube.com/view_all_playlists", "view_all_playlists");
            bool waitCreate = chrome.Wait("#vm-playlist-div", 10);
            if (!waitCreate) goto StartCreate;
            int createdEntries = 5;
        CreatePlaylist:
            Log("Create new playlist");
            chrome.Click("#vm-playlist-div");
            chrome.Wait("#vm-create-playlist-dialog .create-playlist-section input[name=\"n\"]", 20);
            chrome.SendKeys("#vm-create-playlist-dialog .create-playlist-section input[name=\"n\"]", keyword,speed:50);
            Thread.Sleep(5000);
            if (chrome.Url.IndexOf("view_all_playlists") != -1)
            {
                if(createdEntries == 0)
                {
                    Log("Can't create new playlist!");
                    MessageBox.Show("Can't create new playlist!");
                    return false;
                }
                chrome.Navigate().Refresh();
                createdEntries--;
                goto CreatePlaylist;
            }
            pllListTb.AppendText(Environment.NewLine + chrome.Url);
            chrome.Wait("#owner-container #button", 20);
            chrome.Click("#owner-container #button");
            if (chrome.Url.IndexOf("disable_polymer") == -1)
            {
                var url = chrome.Url;
                chrome.GoToURL(url + "&disable_polymer=true");
            }

            Thread.Sleep(1500);
            chrome.Wait("#gh-playlist-add-video", 20);
            Log("Add videos to playlist");
        OpenIframe:
            chrome.Click("#gh-playlist-add-video");
            bool waitIframe1 = chrome.Wait("iframe.picker-frame", 10);
            if (!waitIframe1) goto OpenIframe;
            chrome.SwitchToFrame("iframe.picker-frame");
        SearchVideos:
            bool waitSearch = chrome.Wait("#doclist input", 0, "Displayed", 10);
            if (!waitSearch)
            {
                chrome.Click("[role=\"button\"][data-tooltip=\"Close\"]");
                chrome.SwitchToDefaultContent();
                goto OpenIframe;
            }
            Log("Search videos to add playlist");
        InsertKeyword:
            Clipboard.SetText(keyword);
            chrome.FindElement("#doclist input").SendKeys(Keys.Control + "v" + Keys.Enter);
            if(chrome.getText("#doclist input") != keyword)
            {
                chrome.FindElement("#doclist input").Clear();
                goto InsertKeyword;
            }
            Thread.Sleep(3000);
            var check = chrome.Wait("table[role=\"listbox\"] div[role=\"option\"]", 20);
            if (!check)
            {
                Log("No videos found! Search again!");
                goto SearchVideos;
            }
            //Log(chrome.CountElements("table[role=\"listbox\"] div[role=\"option\"]") + " videos found!");
            int numVideo = int.Parse(numVideoTb.Text);
            int count = 0;
            int ignore = 3;
            int i = 0;
            string description = "";
            string newTitle = "";
            var random = new Random();
            Log("Select videos to playlist");
            while (count < numVideo) {
                if (i>20 && ignore > 0)
                {
                    int rand = random.Next(i, 100);
                    if (rand % 9 > 3)
                    {
                        ignore--;
                        i++;
                        continue;
                    }
                }
                int nth = 3 - ignore;
                chrome.Click("table[role=\"listbox\"] div[role=\"option\"][aria-checked=\"false\"]", nth);
                var id = chrome.FindElements("table[role=\"listbox\"] div[role=\"option\"][aria-checked=\"false\"]")[nth].GetAttribute("aria-labelledby");
                if (count <= int.Parse(descriptionTb.Text))
                    description += chrome.getText("table[role=\"listbox\"] div[role=\"option\"] div[id=\"" + id + "\"]") + Environment.NewLine;
                if (i == 0)
                    newTitle = chrome.getText("table[role=\"listbox\"] div[role=\"option\"] div[id=\"" + id + "\"]");
                if (i == pllCreated)
                    newTitle = chrome.getText("table[role=\"listbox\"] div[role=\"option\"] div[id=\"" + id + "\"]");
                count++;
                if (i > 0 && i % 50 == 0) Thread.Sleep(4500);
                Thread.Sleep(500);
                i++;
            }
        AddVideo:
            bool waitAddVideos = chrome.Wait("#doclist [role=\"button\"][id=\"picker:ap:2\"]", 0, "Enabled", 20);
            if(!waitAddVideos)
            {
                Log("Can't add videos to playlist.");
                chrome.Click("[role=\"button\"][data-tooltip=\"Close\"]");
            }
            else
            {
                chrome.Click("#doclist [role=\"button\"][id=\"picker:ap:2\"]");
            }

            if(chrome.Wait("[role=\"button\"][data-tooltip=\"Close\"]", 2))
            {
                goto AddVideo;
            }

            Thread.Sleep(3000);
            chrome.SwitchToDefaultContent();
            Log("Change title playlist: " + newTitle);
            chrome.Click(".pl-header-title");
            chrome.Wait("input[name=\"playlist_title\"]", 0, "Displayed", 10);
            chrome.FindElement("input[name=\"playlist_title\"]").Clear();
            Clipboard.SetText(newTitle);
            chrome.FindElement("input[name=\"playlist_title\"]").SendKeys(Keys.Control + "v" + Keys.Tab);
            Thread.Sleep(3000);
            Log("Change description playlist");
            chrome.Click(".pl-header-add-description-button");
            chrome.Wait(".pl-header-description-editor-form textarea", 0, "Displayed", 10);
            Clipboard.SetText(description);
            chrome.FindElement(".pl-header-description-editor-form textarea").SendKeys(Keys.Control + "v" + Keys.Tab);
            Thread.Sleep(1000);
            chrome.Click("#playlist-settings-editor button");
            chrome.Wait("select.playlist-video-order-input[name=\"sort_order\"]", 0, "Displayed", 10);
            chrome.Click("select.playlist-video-order-input[name=\"sort_order\"]");
            Thread.Sleep(500);
            chrome.Click("select.playlist-video-order-input[name=\"sort_order\"] option[value=\"3\"]");
            chrome.Wait("button.save-button", 0, "Enabled", 10);
            chrome.Click("button.save-button");
            Thread.Sleep(3000);
            chrome.Click("#playlist-settings-editor button");
            chrome.Wait("select.playlist-video-order-input[name=\"sort_order\"]", 0, "Displayed", 10);
            chrome.Click("select.playlist-video-order-input[name=\"sort_order\"]");
            Thread.Sleep(500);
            chrome.Click("select.playlist-video-order-input[name=\"sort_order\"] option[value=\"0\"]");
            Thread.Sleep(1000);
            chrome.Click("input[name=\"add_to_top\"]");
            if (canAddVideoCb.Checked)
            {
                chrome.Click("[data-uix-tabs-target-id=\"collaboration-settings\"]");
                Thread.Sleep(500);
                chrome.Click("#open-to-contributions");
            }
            chrome.Wait("button.save-button", 0, "Enabled", 20);
            chrome.Click("button.save-button");
            Thread.Sleep(3000);
            if (!string.IsNullOrEmpty(videoId))
            {
                string videoUrl = "https://www.youtube.com/watch?v=" + videoId;
                Log("Add your video to playlist");
            AddYourVideo:
                chrome.Wait("#gh-playlist-add-video", 10);
                chrome.Click("#gh-playlist-add-video");
                bool waitIframe = chrome.Wait("iframe.picker-frame", 10);
                if (!waitIframe) goto AddYourVideo;

                chrome.SwitchToFrame("iframe.picker-frame");
            OpenTab:
                chrome.Click("#doclist [role=\"tab\"]", 1);
                bool waitInput = chrome.Wait("#doclist input", 1, "Displayed", 10);
                if(!waitInput) goto OpenTab;
                int searchEntries = 5;
            SearchVideo:
                Clipboard.SetText(videoUrl);
                chrome.FindElements("#doclist input")[1].SendKeys(Keys.Control + "v" + Keys.Enter);
                Thread.Sleep(3000);
                check = chrome.Wait("#doclist iframe",10);
                if (!check)
                {
                    if (searchEntries == 0)
                    {
                        Log("Can't search your video!");
                        MessageBox.Show("Can't search your video!");
                        chrome.Click("[role=\"button\"][data-tooltip=\"Close\"]");
                    }
                    else
                    {
                        searchEntries--;
                        chrome.FindElements("#doclist input")[1].Clear();
                        goto SearchVideo;
                    }
                }
                else
                {
                    chrome.Wait("#doclist [role=\"button\"][id=\"picker:ap:2\"]", 0, "Enabled", 10);
                    chrome.Click("#doclist [role=\"button\"][id=\"picker:ap:2\"]");
                }
                Thread.Sleep(3000);
                chrome.SwitchToDefaultContent();
                bool found = chrome.Wait("[data-video-id=\"" + videoId + "\"]", 10);
                if (found)
                {
                    Log("Move your video to your position in playlist");
                    chrome.DragAndDrop("[data-video-id=\"" + videoId + "\"] td.yt-uix-dragdrop-drag-handle", "#pl-video-table tr", (int.Parse(videoPosTb.Text) - 1));
                }
                Thread.Sleep(3000);
            }
            Log("Create Playlist Successfully!");
            pllCreated++;
            return true;
        }

        private void OpenProfile()
        {
            bool isMulti = multiProfileCb.Checked;
            var path = profileFolderTb.Text;
            if (isMulti)
            {
                var paths = Directory.GetDirectories(path);
                foreach(var p in paths) {
                    Thread thread = new Thread(new ThreadStart(() =>
                    {
                        try
                        {
                            Chrome chrome = new Chrome(p);
                            chrome.GoToURL("https://www.youtube.com/");
                        }
                        catch (Exception e)
                        {
                            Log(e.Message);
                            MessageBox.Show(e.Message);
                        }
                    }));
                    thread.Start();
                    Thread.Sleep(5000);
                }
            }
            else
            {
                Chrome chrome = new Chrome(path);
                chrome.GoToURL("https://www.youtube.com/");
            }

        }

        private void profileFolderTb_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                profileFolderTb.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void createPllBtn_Click(object sender, EventArgs e)
        {
            InitPlaylist();
        }

        private void Log(dynamic str)
        {
            str = str.ToString();
            try
            {
                logRtb.Invoke(new Action(() =>
                {

                    if (logRtb.Text.Length > 50000)
                    {
                        logRtb.Text = "";
                    }
                    str = DateTime.Now.ToString("dd/MM/yy HH:mm:ss tt") + "\t" + str + Environment.NewLine;
                    logRtb.Text = str + logRtb.Text;
                    File.AppendAllText(Environment.CurrentDirectory + @"\log.txt", str);
                }));
            }
            catch
            {
                Console.WriteLine("stop");
            }
        }

        private void profileBtn_Click(object sender, EventArgs e)
        {
            if(folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                profileLb.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Process[] bProcess = Process.GetProcessesByName("chromedriver");
            if (bProcess.Length > 0)
            {
                foreach (var proc in bProcess)
                {
                    try
                    {
                        proc.Kill();
                    }
                    catch { }
                }
                Thread.Sleep(1000);
            }
            Environment.Exit(Environment.ExitCode);
        }
    }
}
