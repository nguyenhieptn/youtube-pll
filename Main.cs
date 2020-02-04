using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Keys = OpenQA.Selenium.Keys;
using System.Collections.Generic;

namespace Youtube_PLL
{
    public partial class Main : Form
    {
        int pllCreated = 0;
        int totalPlaylists = 0;
        Thread t0, t1, t2, t3;
        MyChrome chrome;
        Setting setting = null;
        string settingsPath = Environment.CurrentDirectory + @"\settings.json";
        string playlistsPath = Environment.CurrentDirectory + @"\playlists.csv";
        string profile = "";
        string mainKeyword = "";
        List<string> sencondKeywords = new List<string>();
        bool multiKeywords = false;
        string email;
        string code;
        string machineId;
        bool licenseInvalid = true;
        bool run = true;
        public Main(string email, string code, string machineId)
        {
            this.email = email;
            this.code = code;
            this.machineId = machineId;
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void newProfileBtn_Click(object sender, EventArgs e)
        {
            t1 = new Thread(new ThreadStart(OpenProfile));
            t1.Start();
        }

        private void InitPlaylist()
        {
            ThreadStart ts = new ThreadStart(() =>
            {
                if (!run) return;
               bool isMulti = multiCb.Checked;
               var path = profileLb.Text;
               mainKeyword = KeywordTb.Text;
               if (!string.IsNullOrEmpty(secondKeywordsTb.Text))
                   sencondKeywords = secondKeywordsTb.Text.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None).ToList();
               if (sencondKeywords.Count > 0) multiKeywords = true;
               sencondKeywords.Insert(0, mainKeyword);
               if (!isMulti)
               {
                   if (!licenseInvalid) return;
                   totalPlaylists = int.Parse(NumPllTb.Text);
                   CreatePlaylist(path);
               }
               else
               {
                   var paths = Directory.GetDirectories(path).ToList();
                   var stop = false;
                    //string keyword;
                    while (!stop)
                   {
                       if (!licenseInvalid) return;
                       if (sencondKeywords.Count == 0) break;
                       if (string.IsNullOrEmpty(mainKeyword)) break;
                       Log(paths.Count + " Profiles");
                       totalPlaylists = paths.Count * int.Parse(NumPllTb.Text);
                       Log(totalPlaylists + " Playlists");
                       if (paths.Count() == 0) break;
                       var p = paths.First();
                       Log("Start Profile: " + p);
                       paths.RemoveAt(0);
                       if (path.Count() == 0) stop = true;
                       CreatePlaylist(p);
                       Thread.Sleep(5000);
                   }
               }
            });
            t2 = new Thread(ts);
            t2.SetApartmentState(ApartmentState.STA);
            t2.Start();
        }

        private void CreatePlaylist(string path)
        {
            profile = path;
            try
            {
                if (File.Exists(settingsPath))
                {
                    setting = JSON.Decode<Setting>(File.ReadAllText(settingsPath));
                }
                MyProxy proxy = null;
                if(setting != null && setting.useProxy == true)
                {
                    proxy = setting.proxy;
                }
                chrome = new MyChrome(path, proxy:proxy);
                chrome.GoToURL("https://www.youtube.com/");
                if (chrome.CountElements("button#avatar-btn") == 0)
                {
                    Log("Please login youtube");
                    //MessageBox.Show("Please login youtube");
                    chrome.Close();
                    chrome.Quit();
                    return;
                }

                var videoIds = videoIdsTb.Text;
                var num = int.Parse(NumPllTb.Text);
                Log("Create " + num + " playlists.");
                string keyword;
                for (var i = 0; i < num; i++)
                {
                    if (!licenseInvalid) return;
                    if (multiKeywords)
                    {
                        if (sencondKeywords.Count == 0)
                        {
                            return;
                        }
                        keyword = sencondKeywords.First();
                        sencondKeywords.RemoveAt(0);
                    }
                    else
                    {
                        keyword = mainKeyword;
                    }
                    Log("Start create playlist " + (i+1));
                    bool created = CreateOnePlaylist(chrome, keyword, videoIds);
                    if (!created) break;
                }
                chrome.Close();
                chrome.Quit();
            }
            catch(Exception e)
            {
                Log(e.Message);
                MessageBox.Show(e.Message);
            }
        }

        private bool CreateOnePlaylist(MyChrome chrome, string keyword, string videoIds)
        {
            try
            {
            StartCreate:
                chrome.GoToURL("https://www.youtube.com/view_all_playlists", "view_all_playlists");
                Thread.Sleep(3000);
                if(chrome.Url.IndexOf("account_warnings") != -1)
                {
                    chrome.Wait("button#view-content", 5);
                    chrome.Click("button#view-content");
                    Thread.Sleep(3000);
                    chrome.Wait("ytcp-icon-button[icon=\"icons:close\"]",5);
                    chrome.Click("ytcp-icon-button[icon=\"icons:close\"]");
                    Thread.Sleep(3000);
                    goto StartCreate;
                }
                bool waitCreate = chrome.Wait("#vm-playlist-div", 10);
                if (!waitCreate) goto StartCreate;
                int createdEntries = 5;
            CreatePlaylist:
                Log("Create new playlist");
                chrome.Click("#vm-playlist-div");
                string newTitle = "";
                string titleCreate = keyword;
                if (multiKeywords) titleCreate = newTitle = (mainKeyword.Equals(keyword)) ? mainKeyword : mainKeyword + " || " + keyword;
                chrome.Wait("#vm-create-playlist-dialog .create-playlist-section input[name=\"n\"]", 20);
                chrome.FindElement("#vm-create-playlist-dialog .create-playlist-section input[name=\"n\"]").SendKeys(titleCreate);
                chrome.FindElement("#vm-create-playlist-dialog .create-playlist-section input[name=\"n\"]").SendKeys(Keys.Enter);
                Thread.Sleep(5000);
                if (chrome.Url.IndexOf("view_all_playlists") != -1)
                {
                    if (createdEntries == 0)
                    {
                        Log("Can't create new playlist!");
                        MessageBox.Show("Can't create new playlist!");
                        return false;
                    }
                    chrome.Navigate().Refresh();
                    createdEntries--;
                    goto CreatePlaylist;
                }
            EditPlaylist:
                chrome.Wait("#owner-container #button", 20);
                chrome.Click("#owner-container #button");
                var url = chrome.Url;
                if (chrome.Url.IndexOf("disable_polymer") == -1)
                {
                    chrome.GoToURL(url + "&disable_polymer=true");
                }


                Thread.Sleep(1500);
            OpenIframe:
                var waitAddVideo = chrome.Wait("#gh-playlist-add-video", 5);
                if (!waitAddVideo)
                {
                    chrome.GoToURL(url);
                    goto EditPlaylist;
                }
                string playlistId = chrome.FindElement("[name=\"playlist_id\"]").GetAttribute("value");
                string channelId = chrome.FindElement("ul.guide-user-links li a[href*=\"channel\"]").GetAttribute("data-external-id");
                Log("Add videos to playlist");
                chrome.Click("#gh-playlist-add-video");
                bool waitIframe1 = chrome.Wait("iframe.picker-frame", 10);
                if (!waitIframe1)
                {
                    Log("Popup not show!");
                    chrome.Navigate().Refresh();
                    goto OpenIframe;
                }
                chrome.SwitchToFrame("iframe.picker-frame");
            SearchVideos:
                chrome.Click("#doclist [role=\"tab\"]");
                bool waitSearch = chrome.Wait("#doclist input", 0, "Displayed", 10);
                if (!waitSearch)
                {
                    Log("Search input not show");
                    chrome.Click("[role=\"button\"][data-tooltip=\"Close\"]");
                    chrome.SwitchToDefaultContent();
                    goto OpenIframe;
                }
                Log("Search keyword: " + keyword);
            SendText:
                //Clipboard.SetText(keyword, TextDataFormat.UnicodeText);
                chrome.FindElement("#doclist input").SendKeys(keyword);
                if (chrome.FindElement("#doclist input").GetAttribute("value") != keyword)
                {
                    chrome.FindElement("#doclist input").Clear();
                    goto SendText;
                }
                Thread.Sleep(1000);
                chrome.FindElement("#doclist input").SendKeys(Keys.Enter);
                Thread.Sleep(3000);
                var check = chrome.Wait("#doclist table[role=\"listbox\"] div[role=\"option\"]", 10);
                if (!check)
                {
                    Log("No videos found! Search again!");
                    goto SearchVideos;
                }
                int numVideo = int.Parse(numVideoTb.Text);
                int count = 0;
                int i = 0;
                string description = "";
                Log("Select videos to playlist");
                decimal startIgnore = (numVideo / 2);
                if (startIgnore > 20) startIgnore = 20;
                int ignore = 0;
                while (count < numVideo || count < totalPlaylists)
                {
                    try
                    {
                        string id;
                        if (i > startIgnore && new Random().Next(totalPlaylists + pllCreated) < (totalPlaylists + pllCreated) / 5)
                        {
                            ignore++;
                            goto GetTitle;
                        }
                        if (count < numVideo)
                        {
                            chrome.Wait("table[role=\"listbox\"] div[role=\"option\"][aria-checked=\"false\"]", ignore, "Count", 10);
                            id = chrome.FindElements("table[role=\"listbox\"] div[role=\"option\"][aria-checked=\"false\"]")[ignore].GetAttribute("aria-labelledby");
                            chrome.FindElements("table[role=\"listbox\"] div[role=\"option\"][aria-checked=\"false\"]")[ignore].Click();
                            if (count <= int.Parse(descriptionTb.Text))
                                description += chrome.getText("table[role=\"listbox\"] div[role=\"option\"] div[id=\"" + id + "\"]") + Environment.NewLine;
                            count++;
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(newTitle)) break;
                        }
                    GetTitle:
                        if (string.IsNullOrEmpty(newTitle))
                        {
                            if (i == pllCreated)
                            {
                                id = chrome.FindElements("table[role=\"listbox\"] div[role=\"option\"]")[i].GetAttribute("aria-labelledby");
                                newTitle = chrome.getText("table[role=\"listbox\"] div[role=\"option\"] div[id=\"" + id + "\"]");
                            }
                        }
                        i++;
                        Thread.Sleep(1000);
                    }
                    catch (Exception e)
                    {
                        Log(e.Message);
                    }
                }
            AddVideo:
                bool waitAddVideos = chrome.Wait("#doclist [role=\"button\"][id*=\"picker:ap\"][class*=\"enabled\"]", 0, "Enabled", 10);
                if (!waitAddVideos)
                {
                    Log("Can't add videos to playlist.");
                    chrome.Click("[role=\"button\"][data-tooltip=\"Close\"]");
                }
                else
                {
                    Log("Add videos to playlists");
                    chrome.Click("#doclist [role=\"button\"][id*=\"picker:ap\"][class*=\"enabled\"]");
                    Thread.Sleep(3000);
                }

                if (chrome.CountElements("#doclist [role=\"button\"][id*=\"picker:ap\"][class*=\"enabled\"]") > 0 && chrome.Wait("#doclist [role=\"button\"][id*=\"picker:ap\"][class*=\"enabled\"]", 0, "Enabled", 2))
                {
                    goto AddVideo;
                }

                Thread.Sleep(3000);
                chrome.SwitchToDefaultContent();
                Log("Change playlist title: " + newTitle);
                int retriesChangeTitle = 5;
                int retriesChangeDescription = 5;
            ChangeTitle:
                if (!multiKeywords)
                {
                    bool waitTitle = chrome.Wait("h1.pl-header-title", 0, "Enabled", 5);
                    if (!waitTitle)
                    {
                        if (retriesChangeTitle > 0)
                        {
                            Log("Change Title Again.");
                            goto ChangeTitle;
                        }
                        else
                        {
                            Log("Change title fail!");
                            goto ChangeDescription;
                        }
                    }
                    else { retriesChangeTitle = 5; }
                    Log("Click title");
                    try
                    {
                        chrome.FindElement("h1.pl-header-title").Click();
                    }
                    catch
                    {
                        goto ChangeTitle;
                    }
                    waitTitle = chrome.Wait("input[name=\"playlist_title\"]", 0, "Enabled", 5);
                    if (!waitTitle)
                    {
                        if (retriesChangeTitle > 0)
                        {
                            Log("Change Title Again. Input not show");
                            goto ChangeTitle;
                        }
                        else
                        {
                            Log("Change title fail!");
                            goto ChangeDescription;
                        }
                    }
                    waitTitle = chrome.Wait("input[name=\"playlist_title\"]", 0, "Enabled", 5);
                    //chrome.FindElement("input[name=\"playlist_title\"]").Click();
                    Log("Type title");
                    try
                    {
                        chrome.FindElement("input[name=\"playlist_title\"]").Clear();
                        chrome.FindElement("input[name=\"playlist_title\"]").SendKeys(newTitle);
                    }
                    catch
                    {
                        try
                        {
                            chrome.FindElement("input[name=\"playlist_title\"]").Clear();
                            Clipboard.SetText(newTitle);
                            chrome.FindElement("input[name=\"playlist_title\"]").SendKeys(Keys.Control + "v");
                        }
                        catch
                        {
                            Log("Change Title Again. Input not show");
                            goto ChangeTitle;
                        }
                    }
                    Thread.Sleep(1000);
                    if (chrome.FindElement("input[name=\"playlist_title\"]").GetAttribute("value").Trim() != newTitle.Trim())
                    {
                        Log("Change title again.");
                        if (retriesChangeTitle > 0)
                        {
                            goto ChangeTitle;
                        }
                        else
                        {
                            Log("Change title fail!");
                        }
                    }
                    chrome.FindElement("input[name=\"playlist_title\"]").SendKeys(Keys.Tab);
                    Thread.Sleep(3000);
                }
                Log("Change playlist description");
            ChangeDescription:
                chrome.Click(".pl-header-add-description-button");
                bool waitTextarea = chrome.Wait(".pl-header-description-editor-form textarea", 0, "Enabled", 5);
                try
                {
                    chrome.FindElement(".pl-header-description-editor-form textarea").SendKeys(description);
                }catch{
                    Clipboard.SetText(description);
                    chrome.FindElement(".pl-header-description-editor-form textarea").SendKeys(Keys.Control+"v");
                }
                if (chrome.FindElement(".pl-header-description-editor-form textarea").GetAttribute("value").Trim() != description.Trim())
                {
                    Log("Change description again.");
                    if (retriesChangeDescription > 0)
                    {
                        goto ChangeDescription;
                    }
                    else
                    {
                        Log("Change description fail!");
                    }
                }
                chrome.FindElement(".pl-header-description-editor-form textarea").SendKeys(Keys.Tab);
                Thread.Sleep(1000);
                bool waitSaveSetting;
                if (sortPopularCb.Checked)
                {
                    Log("Sort Playlist to popular.");
                    chrome.Wait("#playlist-settings-editor button", 0 , "Enabled", 5);
                    chrome.Click("#playlist-settings-editor button");
                    //chrome.Wait("select.playlist-video-order-input[name=\"sort_order\"]", 0, "Displayed", 5);
                    chrome.Wait("select.playlist-video-order-input[name=\"sort_order\"]", 0, "Enabled", 5);
                    chrome.Click("select.playlist-video-order-input[name=\"sort_order\"]");
                    Thread.Sleep(500);
                    chrome.Click("select.playlist-video-order-input[name=\"sort_order\"] option[value=\"3\"]");
                    waitSaveSetting = chrome.Wait("button.save-button", 0, "Enabled", 5);
                    if (!waitSaveSetting)
                    {
                        chrome.Click("button.yt-dialog-cancel");
                    }
                    else
                    {
                        chrome.Click("button.save-button");
                        Thread.Sleep(3000);
                    }
                }
                Log("Sort Playlist to manual.");
                chrome.Click("#playlist-settings-editor button");
                chrome.Wait("select.playlist-video-order-input[name=\"sort_order\"]", 0, "Enabled", 10);
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
            PlaylistSetting:
                waitSaveSetting = chrome.Wait("button.save-button", 0, "Enabled", 5);
                if (!waitSaveSetting)
                {
                    chrome.Click("button.yt-dialog-cancel");
                }
                else
                {
                    chrome.Click("button.save-button");
                    Thread.Sleep(3000);
                }
                if (chrome.CountElements("#playlist-settings-editor .messages .yt-alert-content") > 0 && !string.IsNullOrEmpty(chrome.FindElement("#playlist-settings-editor .messages .yt-alert-content").Text))
                {
                    Log("Save playlist settings again."); ;
                    goto PlaylistSetting;
                }
                if (!string.IsNullOrEmpty(videoIds))
                {
                    var video_ids = videoIds.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None).ToList<string>();
                    Log("Add " + video_ids.Count + " videos.");
                    int startPos = int.Parse(videoPosTb.Text);
                    foreach (string videoId in video_ids)
                    {
                        string video_id = videoId.Trim(' ');
                        if (string.IsNullOrEmpty(video_id)) continue;
                        string videoUrl = "https://www.youtube.com/watch?v=" + video_id;
                        Log("Add video " + videoId + " to playlist");
                    AddYourVideo:
                        chrome.Wait("#gh-playlist-add-video", 5);
                        chrome.Click("#gh-playlist-add-video");
                        bool waitIframe = chrome.Wait("iframe.picker-frame", 0, "Enabled", 10);
                        if (!waitIframe) {
                            Log("Popup not show");
                            goto AddYourVideo;
                        }

                        chrome.SwitchToFrame("iframe.picker-frame");
                    OpenTab:
                        chrome.Wait("#doclist [role=\"tab\"]", 1, "Displayed", 5);
                        chrome.Wait("#doclist [role=\"tab\"]", 1, "Enabled", 2);
                        chrome.Click("#doclist [role=\"tab\"]", 1);
                        bool waitInput = chrome.Wait("#doclist input", 1, "Enabled", 5);
                        if (!waitInput) goto OpenTab;
                        int searchEntries = 5;
                    SearchVideo:
                        Log("Search video: " + videoUrl);
                        chrome.FindElements("#doclist input")[1].SendKeys(videoUrl);
                        if (chrome.FindElements("#doclist input")[1].GetAttribute("value") != videoUrl)
                        {
                            chrome.FindElements("#doclist input")[1].Clear();
                            goto SearchVideo;
                        }
                        Thread.Sleep(3000);
                        check = chrome.Wait("#doclist iframe", 10);
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
                            chrome.Wait("#doclist [role=\"button\"][id*=\"picker:ap\"][class*=\"enabled\"]", 0, "Enabled", 10);
                            chrome.Click("#doclist [role=\"button\"][id*=\"picker:ap\"][class*=\"enabled\"]");
                        }
                        Thread.Sleep(3000);
                        chrome.SwitchToDefaultContent();
                        bool found = chrome.Wait("[data-video-id=\"" + videoId + "\"]", 10);
                        if (found)
                        {
                            Log("Move your video to your position in playlist");
                            chrome.DragAndDrop("[data-video-id=\"" + videoId + "\"] td.yt-uix-dragdrop-drag-handle", "#pl-video-table tr", (startPos - 1));
                            startPos++;
                        }
                        Thread.Sleep(3000);
                        chrome.Scroll(0);
                    }
                    Thread.Sleep(3000);
                }
                Log("Create Playlist Successfully!");
                pllCreated++;
                try
                {
                    File.AppendAllText(playlistsPath, Environment.NewLine + keyword + "," + channelId + "," + playlistId + "," + profile + "," + DateTime.Now.ToString());
                    Playlist playlist = new Playlist(keyword, channelId, playlistId, profile);
                    playlistBindingSource.Add(playlist);
                }
                catch { }
                return true;
            }catch(Exception e)
            {
                Log(e.Message);
                //MessageBox.Show(e.Source);
                return false;
            }
        }

        private void OpenProfile()
        {
            if (!licenseInvalid) return;
            bool isMulti = multiProfileCb.Checked;
            var path = profileFolderTb.Text;
            if (File.Exists(settingsPath))
            {
                setting = JSON.Decode<Setting>(File.ReadAllText(settingsPath));
            }
            MyProxy proxy = null;
            if (setting != null && setting.useProxy == true)
            {
                proxy = setting.proxy;
            }
            if (isMulti)
            {
                var paths = Directory.GetDirectories(path);
                foreach(var p in paths) {
                    Thread thread = new Thread(new ThreadStart(() =>
                    {
                        try
                        {
                            string useragent = "NokiaC3-00/5.0 (08.63) Profile/MIDP-2.1 Configuration/CLDC-1.1 Mozilla/5.0 AppleWebKit/420+ (KHTML, like Gecko) Safari/420+";
                            MyChrome chrome = new MyChrome(p, proxy:proxy, useragent: useragent);
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
                string useragent = "NokiaC3-00/5.0 (08.63) Profile/MIDP-2.1 Configuration/CLDC-1.1 Mozilla/5.0 AppleWebKit/420+ (KHTML, like Gecko) Safari/420+";
                MyChrome chrome = new MyChrome(path, proxy:proxy, useragent: useragent);
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

        public void Log(dynamic str)
        {
            str = JSON.Encode(str);
            //Console.WriteLine(str);
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
            catch(Exception e)
            {
                File.AppendAllText(Environment.CurrentDirectory + @"\log.txt", DateTime.Now.ToString("dd/MM/yy HH:mm:ss tt") + "\t" + e.Message + Environment.NewLine);
                //Console.WriteLine(e.Message);
                //Console.WriteLine("stop");
            }
        }

        private void profileBtn_Click(object sender, EventArgs e)
        {
            if(folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                profileLb.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            //mainTab.Show();
            t0 = new Thread(new ThreadStart(new Action(() =>
            {
                t3 = new Thread(new ThreadStart(checkLicense));
                t3.Start();
                Log("Start");
                if (File.Exists(settingsPath))
                {
                    var setting = JSON.Decode<Setting>(File.ReadAllText(settingsPath));
                    if(setting.useProxy == true)
                    {
                        useProxyCb.Checked = true;
                    }
                    proxySchema.Text = setting.proxy.schema;
                    proxyHost.Text = setting.proxy.host;
                    proxyPort.Text = setting.proxy.port.ToString();
                    proxyUsername.Text = setting.proxy.username;
                    proxyPassword.Text = setting.proxy.password;
                }
                if (File.Exists(playlistsPath))
                {
                    try
                    {
                        List<Playlist> playlists = new List<Playlist>();
                        String textLine = string.Empty;
                        String[] splitLine;
                        var reader = new StreamReader(playlistsPath);
                        do
                        {
                            textLine = reader.ReadLine();
                            if (textLine != "")
                            {
                                splitLine = textLine.Split(',');
                                if (splitLine.Count() < 5) continue;
                                Playlist playlist = new Playlist(splitLine[0], splitLine[1], splitLine[2], splitLine[3], DateTime.Parse(splitLine[4]));
                                playlistBindingSource.Add(playlist);
                            }
                        } while (reader.Peek() != -1);
                        reader.Dispose();
                    }
                    catch { }

                }
            })));
            t0.Start();
        }

        private void saveSettingBtn_Click(object sender, EventArgs e)
        {
            var myProxy = new MyProxy();
            myProxy.schema = proxySchema.Text.Trim();
            myProxy.host = proxyHost.Text.Trim();
            myProxy.port = int.Parse(proxyPort.Text.Trim());
            myProxy.username = proxyUsername.Text.Trim();
            myProxy.password = proxyPassword.Text.Trim();
            var setting = new Setting();
            setting.proxy = myProxy;
            setting.useProxy = useProxyCb.Checked;
            File.WriteAllText(settingsPath, JSON.Encode(setting));
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

        private void stopBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Yes or No", "Stop your tool?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                try
                {

                    if (t2 != null && t2.IsAlive)
                    {
                        try
                        {
                            t2.Abort();
                        }
                        catch { }
                    }

                    if (chrome != null)
                    {
                        try
                        {
                            chrome.Close();
                            chrome.Quit();
                        }
                        catch { }
                    }

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
                }
                catch { }
            }
        }

        public void checkLicense()
        {
            while (true)
            {
                try
                {
                    var data = new Dictionary<string, string>();
                    data["email"] = this.email;
                    data["activate_code"] = this.code;
                    data["machine"] = this.machineId;
                    var request = new Request("POST", "https://ytb.tokamedia.com/api/licenses/check", JSON.Encode(data));
                    var response = JSON.Decode<Dictionary<string, string>>(request.ResponseText);
                    licenseMessageLb.Invoke(new Action(() =>
                    {
                        licenseMessageLb.Text = response["message"];
                    }));
                    if (response["type"] == "success")
                    {
                        licenseInvalid = true;
                    }
                    else
                    {
                        licenseInvalid = false;
                    }
                }
                catch
                {
                    licenseInvalid = true;
                }
                Thread.Sleep(30 * 6000);
            }
        }
    }
}
