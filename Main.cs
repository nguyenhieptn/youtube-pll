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

namespace Youtube_PLL
{
    public partial class Main : Form
    {
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
                    var kws = KeywordsTb.Text;
                    var keywords = kws.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None).ToList<string>();
                    CreatePlaylist(path, keywords);
                }
                else
                {
                    var paths = Directory.GetDirectories(path).ToList();
                    var stop = false;
                    while (!stop) {
                        var kws = KeywordsTb.Text;
                        if (string.IsNullOrEmpty(kws)) break;
                        var keywords = kws.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None).ToList<string>();
                        if (paths.Count() == 0) break;
                        var p = paths.First();
                        paths.RemoveAt(0);
                        if (runBackCb.Checked)
                        {
                            paths.Add(p);
                        }
                        if (path.Count() == 0) stop = true;
                        var num = int.Parse(NumPllTb.Text);
                        var key = keywords.Skip(0).Take(num).ToList();
                        var newKeywords = keywords.Skip(num).Take(keywords.Count - num);
                        KeywordsTb.Invoke(new Action(() =>
                        {
                            KeywordsTb.Text = String.Join("\r\n", newKeywords);
                        }));
                        Keywords2Tb.Invoke(new Action(() =>
                        {
                            Keywords2Tb.Text = Keywords2Tb.Text + "\r\n" + String.Join("\r\n", key);
                        }));
                        CreatePlaylist(p, key);
                        Thread.Sleep(5000);
                    }
                }
        }));
            thread.Start();
        }

        private void CreatePlaylist(string path, List<string> keywords)
        {
            try
            {
                Chrome chrome = new Chrome(path);
                chrome.GoToURL("https://www.youtube.com/");
                Console.WriteLine(chrome.CountElements("button#avatar-btn"));
                if (chrome.CountElements("button#avatar-btn") == 0)
                {
                    chrome.Close();
                    chrome.Quit();
                    return;
                }

                var videosText = videosTb.Text;
                var videos = new List<string>();
                if (!string.IsNullOrEmpty(videosText))
                {
                    videos = videosText.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None).ToList<string>();
                }
                for (var i = 0; i < keywords.Count; i++)
                {
                    var keyword = keywords[i];
                    CreateOnePlaylist(chrome, keyword, videos);
                }
                chrome.Close();
                chrome.Quit();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void CreateOnePlaylist(Chrome chrome, string keyword, List<string> videos)
        {
            chrome.GoToURL("https://www.youtube.com/view_all_playlists");
            chrome.Click("#vm-playlist-div");
            chrome.SendKeys("#vm-create-playlist-dialog .create-playlist-section input[name=\"n\"]", keyword,speed:50);
            Thread.Sleep(5000);
            chrome.Click("#owner-container #button");
            var url = chrome.Url;
            chrome.GoToURL(url + "&disable_polymer=1");
            Uri theUri = new Uri(url);
            var query = theUri.Query;

            Thread.Sleep(1500);
            string description = "";
            if (videos.Count() == 0)
            {
                chrome.Click("#gh-playlist-add-video");
                chrome.Wait("iframe.picker-frame", 5);
                chrome.SwitchToFrame("iframe.picker-frame");
                chrome.SendKeys("#doclist input", keyword, speed:50);
                Thread.Sleep(3000);
                chrome.Wait("table[role=\"listbox\"]", 5000);
                int numVideo = int.Parse(numVideoTb.Text);
                int count = 0;
                int ignore = 3;
                int i = 0;
                while(count < numVideo) {
                    if (ignore >= 0)
                    {
                        int rand = new Random().Next(1, 100);
                        if (rand % 10 <= 3)
                        {
                            i++;
                            ignore--;
                            continue;
                        }
                    }
                    chrome.Click("table[role=\"listbox\"] div[role=\"option\"]", i);
                    var id = chrome.FindElements("table[role=\"listbox\"] div[role=\"option\"]")[i].GetAttribute("aria-labelledby");
                    description += chrome.getText("table[role=\"listbox\"] div[role=\"option\"] div[id=\"" + id + "\"]") + Environment.NewLine;
                    var str = chrome.getText("table[role=\"listbox\"] div[role=\"option\"] div[id=\"" + id + "\"]").Split(new string[] { "|", "-" }, StringSplitOptions.None)[0].Trim();
                    Log(str);
                    if (i % 10 == 0) chrome.Scroll();
                    Thread.Sleep(500);
                    i++;
                    count++;
                }
            }
            else
            {

            }
            chrome.Click("#doclist [role=\"button\"][id=\"picker:ap:2\"]");
            Thread.Sleep(3000);
            chrome.Click(".pl-header-add-description-button");
            chrome.SendKeys(".pl-header-description-editor-form textarea", description, isSubmit:false);
            chrome.Click("body");
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
            Console.WriteLine(str);
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
