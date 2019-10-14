using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
                var num = int.Parse(NumPllTb.Text);
                Chrome chrome = new Chrome(path);
                chrome.GoToURL("https://www.youtube.com/");
                Console.WriteLine(chrome.CountElements("button#avatar-btn"));
                if (chrome.CountElements("button#avatar-btn") == 0)
                {
                    chrome.Close();
                    chrome.Quit();
                    return;
                }

                var videoId = videoTb.Text;
                for (var i = 0; i < num; i++)
                {
                    CreateOnePlaylist(chrome, keyword, videoId);
                }
                chrome.Close();
                chrome.Quit();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void CreateOnePlaylist(Chrome chrome, string keyword, string videoId)
        {
            chrome.GoToURL("https://www.youtube.com/view_all_playlists");
            chrome.Click("#vm-playlist-div");
            chrome.SendKeys("#vm-create-playlist-dialog .create-playlist-section input[name=\"n\"]", keyword,speed:50);
            Thread.Sleep(5000);
            pllListTb.AppendText(Environment.NewLine + chrome.Url);
            //Log(chrome.Url);
            chrome.Click("#owner-container #button");
            if (chrome.Url.IndexOf("disable_polymer") == -1)
            {
                var url = chrome.Url;
                chrome.GoToURL(url + "&disable_polymer=true");
            }

            Thread.Sleep(1500);
            chrome.Click("#gh-playlist-add-video");
            chrome.Wait("iframe.picker-frame", 20);
            chrome.SwitchToFrame("iframe.picker-frame");
            chrome.Wait("#doclist input", 0, "Displayed", 20 );
            chrome.SendKeys("#doclist input", keyword);
            Thread.Sleep(3000);
            var check = chrome.Wait("table[role=\"listbox\"]", 20);
            if (!check) MessageBox.Show("No videos found!");
            int numVideo = int.Parse(numVideoTb.Text);
            int count = 0;
            int ignore = 3;
            int i = 0;
            string description = "";
            string newTitle = "";
            var random = new Random();
            while(count < numVideo) {
                if (i>10 && ignore > 0)
                {
                    int rand = random.Next(i, 100);
                    if (rand % 9 > 3)
                    {
                        ignore--;
                        i++;
                        continue;
                    }
                }
                chrome.Click("table[role=\"listbox\"] div[role=\"option\"]", i);
                var id = chrome.FindElements("table[role=\"listbox\"] div[role=\"option\"]")[i].GetAttribute("aria-labelledby");
                if (count <= int.Parse(descriptionTb.Text))
                    description += chrome.getText("table[role=\"listbox\"] div[role=\"option\"] div[id=\"" + id + "\"]") + Environment.NewLine;
                if (i == pllCreated)
                    newTitle = chrome.getText("table[role=\"listbox\"] div[role=\"option\"] div[id=\"" + id + "\"]");
                count++;
                if (i % 10 == 0) chrome.Scroll();
                Thread.Sleep(500);
                i++;
                continue;
            }
            chrome.Click("#doclist [role=\"button\"][id=\"picker:ap:2\"]");
            Thread.Sleep(3000);
            chrome.SwitchToDefaultContent();
            chrome.Click(".pl-header-title");
            Clipboard.SetText(newTitle);
            chrome.FindElement("input[name=\"playlist_title\"]").Clear();
            chrome.FindElement("input[name=\"playlist_title\"]").SendKeys(Keys.Control + "v");
            chrome.FindElement("input[name=\"playlist_title\"]").SendKeys(Keys.Enter);
            //chrome.SendKeys("input[name=\"playlist_title\"]", newTitle);
            Thread.Sleep(3000);
            chrome.Click(".pl-header-add-description-button");
            Clipboard.SetText(description);
            chrome.FindElement(".pl-header-description-editor-form textarea").SendKeys(Keys.Control + "v");
            //chrome.SendKeys(".pl-header-description-editor-form textarea", description, isSubmit:false);
            Thread.Sleep(1000);
            chrome.Click("#playlist-settings-editor button");
            Thread.Sleep(1500);
            chrome.Click("select.playlist-video-order-input[name=\"sort_order\"]");
            chrome.Click("select.playlist-video-order-input[name=\"sort_order\"] option[value=\"3\"]");
            chrome.Click("button.save-button");
            Thread.Sleep(3000);
            chrome.Click("#playlist-settings-editor button");
            Thread.Sleep(1500);
            chrome.Click("select.playlist-video-order-input[name=\"sort_order\"]");
            chrome.Click("select.playlist-video-order-input[name=\"sort_order\"] option[value=\"0\"]");
            Thread.Sleep(1000);
            chrome.Click("input[name=\"add_to_top\"]");
            chrome.Click("button.save-button");
            Thread.Sleep(3000);
            if (!string.IsNullOrEmpty(videoId))
            {
                string videoUrl = "https://www.youtube.com/watch?v=" + videoId;
                chrome.Click("#gh-playlist-add-video");
                chrome.Wait("iframe.picker-frame", 10);
                chrome.SwitchToFrame("iframe.picker-frame");
                chrome.TryClick("#doclist [id=\":6\"]");
                chrome.Wait("#doclist input",1, "Displayed" ,10);
                Clipboard.SetText(videoUrl);
                chrome.FindElements("#doclist input")[1].SendKeys(Keys.Control + "v");
                Thread.Sleep(3000);
                chrome.Click("#doclist [role=\"button\"][id=\"picker:ap:2\"]");
                Thread.Sleep(3000);
                chrome.SwitchToDefaultContent();
                chrome.Wait("[data-video-id=\"" + videoId + "\"]", 10);
                Log(chrome.CountElements("[data-video-id=\"" + videoId + "\"] td.yt-uix-dragdrop-drag-handle"));
                Log(chrome.CountElements("#pl-video-table tr"));
                chrome.DragAndDrop("[data-video-id=\""+videoId+"\"] td.yt-uix-dragdrop-drag-handle", "#pl-video-table tr", (int.Parse(videoPosTb.Text) - 1));
                Thread.Sleep(3000);
            }

            pllCreated++;
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
    }
}
