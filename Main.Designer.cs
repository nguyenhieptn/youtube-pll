namespace Youtube_PLL
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.mainTab = new MetroFramework.Controls.MetroTabPage();
            this.stopBtn = new MetroFramework.Controls.MetroButton();
            this.canAddVideoCb = new MetroFramework.Controls.MetroCheckBox();
            this.descriptionTb = new MetroFramework.Controls.MetroTextBox();
            this.KeywordTb = new MetroFramework.Controls.MetroTextBox();
            this.videoTb = new MetroFramework.Controls.MetroTextBox();
            this.videoPosTb = new MetroFramework.Controls.MetroTextBox();
            this.pllListTb = new System.Windows.Forms.RichTextBox();
            this.NumPllTb = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.logRtb = new System.Windows.Forms.RichTextBox();
            this.numVideoTb = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.createPllBtn = new MetroFramework.Controls.MetroButton();
            this.profileLb = new MetroFramework.Controls.MetroLabel();
            this.multiCb = new MetroFramework.Controls.MetroCheckBox();
            this.profileBtn = new MetroFramework.Controls.MetroButton();
            this.metroTabPage1 = new MetroFramework.Controls.MetroTabPage();
            this.autoLoginCb = new MetroFramework.Controls.MetroCheckBox();
            this.multiProfileCb = new MetroFramework.Controls.MetroCheckBox();
            this.newProfileBtn = new MetroFramework.Controls.MetroButton();
            this.profileFolderTb = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroTabPage3 = new MetroFramework.Controls.MetroTabPage();
            this.saveSettingBtn = new MetroFramework.Controls.MetroButton();
            this.proxyPassword = new MetroFramework.Controls.MetroTextBox();
            this.proxyUsername = new MetroFramework.Controls.MetroTextBox();
            this.proxyPort = new MetroFramework.Controls.MetroTextBox();
            this.proxyHost = new MetroFramework.Controls.MetroTextBox();
            this.proxySchema = new MetroFramework.Controls.MetroComboBox();
            this.htmlLabel6 = new MetroFramework.Drawing.Html.HtmlLabel();
            this.htmlLabel5 = new MetroFramework.Drawing.Html.HtmlLabel();
            this.htmlLabel4 = new MetroFramework.Drawing.Html.HtmlLabel();
            this.htmlLabel3 = new MetroFramework.Drawing.Html.HtmlLabel();
            this.htmlLabel2 = new MetroFramework.Drawing.Html.HtmlLabel();
            this.htmlLabel1 = new MetroFramework.Drawing.Html.HtmlLabel();
            this.useProxyCb = new MetroFramework.Controls.MetroCheckBox();
            this.metroTabControl1.SuspendLayout();
            this.mainTab.SuspendLayout();
            this.metroTabPage1.SuspendLayout();
            this.metroTabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.Location = new System.Drawing.Point(13, 80);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(59, 19);
            this.metroLabel7.TabIndex = 23;
            this.metroLabel7.Text = "Keyword";
            this.metroLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.metroLabel7.WrapToLine = true;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(13, 159);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(59, 19);
            this.metroLabel4.TabIndex = 39;
            this.metroLabel4.Text = "Video ID";
            this.metroLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.metroLabel4.WrapToLine = true;
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(13, 260);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(48, 19);
            this.metroLabel5.TabIndex = 40;
            this.metroLabel5.Text = "Playlist";
            this.metroLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.metroLabel5.WrapToLine = true;
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(13, 109);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(74, 19);
            this.metroLabel6.TabIndex = 42;
            this.metroLabel6.Text = "Description";
            this.metroLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.metroLabel6.WrapToLine = true;
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Controls.Add(this.mainTab);
            this.metroTabControl1.Controls.Add(this.metroTabPage1);
            this.metroTabControl1.Controls.Add(this.metroTabPage3);
            this.metroTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTabControl1.Location = new System.Drawing.Point(0, 0);
            this.metroTabControl1.MinimumSize = new System.Drawing.Size(794, 508);
            this.metroTabControl1.Multiline = true;
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 0;
            this.metroTabControl1.Size = new System.Drawing.Size(794, 508);
            this.metroTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.metroTabControl1.TabIndex = 0;
            this.metroTabControl1.UseSelectable = true;
            // 
            // mainTab
            // 
            this.mainTab.Controls.Add(this.stopBtn);
            this.mainTab.Controls.Add(this.canAddVideoCb);
            this.mainTab.Controls.Add(this.descriptionTb);
            this.mainTab.Controls.Add(this.metroLabel6);
            this.mainTab.Controls.Add(this.KeywordTb);
            this.mainTab.Controls.Add(this.videoTb);
            this.mainTab.Controls.Add(this.videoPosTb);
            this.mainTab.Controls.Add(this.metroLabel5);
            this.mainTab.Controls.Add(this.metroLabel4);
            this.mainTab.Controls.Add(this.pllListTb);
            this.mainTab.Controls.Add(this.NumPllTb);
            this.mainTab.Controls.Add(this.metroLabel3);
            this.mainTab.Controls.Add(this.logRtb);
            this.mainTab.Controls.Add(this.numVideoTb);
            this.mainTab.Controls.Add(this.metroLabel1);
            this.mainTab.Controls.Add(this.createPllBtn);
            this.mainTab.Controls.Add(this.profileLb);
            this.mainTab.Controls.Add(this.metroLabel7);
            this.mainTab.Controls.Add(this.multiCb);
            this.mainTab.Controls.Add(this.profileBtn);
            this.mainTab.HorizontalScrollbarBarColor = true;
            this.mainTab.HorizontalScrollbarHighlightOnWheel = false;
            this.mainTab.HorizontalScrollbarSize = 10;
            this.mainTab.Location = new System.Drawing.Point(4, 38);
            this.mainTab.Name = "mainTab";
            this.mainTab.Size = new System.Drawing.Size(786, 466);
            this.mainTab.TabIndex = 1;
            this.mainTab.Text = "Create Playlist";
            this.mainTab.VerticalScrollbarBarColor = true;
            this.mainTab.VerticalScrollbarHighlightOnWheel = false;
            this.mainTab.VerticalScrollbarSize = 10;
            // 
            // stopBtn
            // 
            this.stopBtn.BackColor = System.Drawing.SystemColors.Control;
            this.stopBtn.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.stopBtn.Highlight = true;
            this.stopBtn.Location = new System.Drawing.Point(622, 29);
            this.stopBtn.Name = "stopBtn";
            this.stopBtn.Size = new System.Drawing.Size(151, 57);
            this.stopBtn.TabIndex = 44;
            this.stopBtn.Text = "Stop";
            this.stopBtn.UseSelectable = true;
            this.stopBtn.Click += new System.EventHandler(this.stopBtn_Click);
            // 
            // canAddVideoCb
            // 
            this.canAddVideoCb.AutoSize = true;
            this.canAddVideoCb.Location = new System.Drawing.Point(13, 138);
            this.canAddVideoCb.Name = "canAddVideoCb";
            this.canAddVideoCb.Size = new System.Drawing.Size(255, 15);
            this.canAddVideoCb.TabIndex = 43;
            this.canAddVideoCb.Text = "Collaborators can add videos to this playlist ";
            this.canAddVideoCb.UseSelectable = true;
            // 
            // descriptionTb
            // 
            // 
            // 
            // 
            this.descriptionTb.CustomButton.Image = null;
            this.descriptionTb.CustomButton.Location = new System.Drawing.Point(258, 1);
            this.descriptionTb.CustomButton.Name = "";
            this.descriptionTb.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.descriptionTb.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.descriptionTb.CustomButton.TabIndex = 1;
            this.descriptionTb.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.descriptionTb.CustomButton.UseSelectable = true;
            this.descriptionTb.CustomButton.Visible = false;
            this.descriptionTb.Lines = new string[] {
        "10"};
            this.descriptionTb.Location = new System.Drawing.Point(110, 109);
            this.descriptionTb.MaxLength = 32767;
            this.descriptionTb.Name = "descriptionTb";
            this.descriptionTb.PasswordChar = '\0';
            this.descriptionTb.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.descriptionTb.SelectedText = "";
            this.descriptionTb.SelectionLength = 0;
            this.descriptionTb.SelectionStart = 0;
            this.descriptionTb.ShortcutsEnabled = true;
            this.descriptionTb.Size = new System.Drawing.Size(280, 23);
            this.descriptionTb.TabIndex = 41;
            this.descriptionTb.Text = "10";
            this.descriptionTb.UseSelectable = true;
            this.descriptionTb.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.descriptionTb.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // KeywordTb
            // 
            // 
            // 
            // 
            this.KeywordTb.CustomButton.Image = null;
            this.KeywordTb.CustomButton.Location = new System.Drawing.Point(258, 1);
            this.KeywordTb.CustomButton.Name = "";
            this.KeywordTb.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.KeywordTb.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.KeywordTb.CustomButton.TabIndex = 1;
            this.KeywordTb.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.KeywordTb.CustomButton.UseSelectable = true;
            this.KeywordTb.CustomButton.Visible = false;
            this.KeywordTb.Lines = new string[0];
            this.KeywordTb.Location = new System.Drawing.Point(110, 80);
            this.KeywordTb.MaxLength = 32767;
            this.KeywordTb.Name = "KeywordTb";
            this.KeywordTb.PasswordChar = '\0';
            this.KeywordTb.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.KeywordTb.SelectedText = "";
            this.KeywordTb.SelectionLength = 0;
            this.KeywordTb.SelectionStart = 0;
            this.KeywordTb.ShortcutsEnabled = true;
            this.KeywordTb.Size = new System.Drawing.Size(280, 23);
            this.KeywordTb.TabIndex = 6;
            this.KeywordTb.UseSelectable = true;
            this.KeywordTb.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.KeywordTb.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // videoTb
            // 
            // 
            // 
            // 
            this.videoTb.CustomButton.Image = null;
            this.videoTb.CustomButton.Location = new System.Drawing.Point(138, 1);
            this.videoTb.CustomButton.Name = "";
            this.videoTb.CustomButton.Size = new System.Drawing.Size(93, 93);
            this.videoTb.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.videoTb.CustomButton.TabIndex = 1;
            this.videoTb.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.videoTb.CustomButton.UseSelectable = true;
            this.videoTb.CustomButton.Visible = false;
            this.videoTb.Lines = new string[0];
            this.videoTb.Location = new System.Drawing.Point(110, 159);
            this.videoTb.MaxLength = 32767;
            this.videoTb.Multiline = true;
            this.videoTb.Name = "videoTb";
            this.videoTb.PasswordChar = '\0';
            this.videoTb.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.videoTb.SelectedText = "";
            this.videoTb.SelectionLength = 0;
            this.videoTb.SelectionStart = 0;
            this.videoTb.ShortcutsEnabled = true;
            this.videoTb.Size = new System.Drawing.Size(232, 95);
            this.videoTb.TabIndex = 7;
            this.videoTb.UseSelectable = true;
            this.videoTb.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.videoTb.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // videoPosTb
            // 
            // 
            // 
            // 
            this.videoPosTb.CustomButton.Image = null;
            this.videoPosTb.CustomButton.Location = new System.Drawing.Point(20, 1);
            this.videoPosTb.CustomButton.Name = "";
            this.videoPosTb.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.videoPosTb.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.videoPosTb.CustomButton.TabIndex = 1;
            this.videoPosTb.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.videoPosTb.CustomButton.UseSelectable = true;
            this.videoPosTb.CustomButton.Visible = false;
            this.videoPosTb.Lines = new string[] {
        "2"};
            this.videoPosTb.Location = new System.Drawing.Point(348, 159);
            this.videoPosTb.MaxLength = 32767;
            this.videoPosTb.Name = "videoPosTb";
            this.videoPosTb.PasswordChar = '\0';
            this.videoPosTb.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.videoPosTb.SelectedText = "";
            this.videoPosTb.SelectionLength = 0;
            this.videoPosTb.SelectionStart = 0;
            this.videoPosTb.ShortcutsEnabled = true;
            this.videoPosTb.Size = new System.Drawing.Size(42, 23);
            this.videoPosTb.TabIndex = 8;
            this.videoPosTb.Text = "2";
            this.videoPosTb.UseSelectable = true;
            this.videoPosTb.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.videoPosTb.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // pllListTb
            // 
            this.pllListTb.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pllListTb.BackColor = System.Drawing.Color.GhostWhite;
            this.pllListTb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pllListTb.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pllListTb.Location = new System.Drawing.Point(110, 260);
            this.pllListTb.Name = "pllListTb";
            this.pllListTb.Size = new System.Drawing.Size(280, 198);
            this.pllListTb.TabIndex = 10;
            this.pllListTb.Text = "";
            this.pllListTb.WordWrap = false;
            // 
            // NumPllTb
            // 
            // 
            // 
            // 
            this.NumPllTb.CustomButton.Image = null;
            this.NumPllTb.CustomButton.Location = new System.Drawing.Point(18, 1);
            this.NumPllTb.CustomButton.Name = "";
            this.NumPllTb.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.NumPllTb.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.NumPllTb.CustomButton.TabIndex = 1;
            this.NumPllTb.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.NumPllTb.CustomButton.UseSelectable = true;
            this.NumPllTb.CustomButton.Visible = false;
            this.NumPllTb.Lines = new string[] {
        "10"};
            this.NumPllTb.Location = new System.Drawing.Point(193, 50);
            this.NumPllTb.MaxLength = 32767;
            this.NumPllTb.Name = "NumPllTb";
            this.NumPllTb.PasswordChar = '\0';
            this.NumPllTb.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.NumPllTb.SelectedText = "";
            this.NumPllTb.SelectionLength = 0;
            this.NumPllTb.SelectionStart = 0;
            this.NumPllTb.ShortcutsEnabled = true;
            this.NumPllTb.Size = new System.Drawing.Size(40, 23);
            this.NumPllTb.TabIndex = 3;
            this.NumPllTb.Text = "10";
            this.NumPllTb.UseSelectable = true;
            this.NumPllTb.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.NumPllTb.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(113, 50);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(74, 19);
            this.metroLabel3.TabIndex = 31;
            this.metroLabel3.Text = "Playlist/Acc";
            // 
            // logRtb
            // 
            this.logRtb.BackColor = System.Drawing.Color.WhiteSmoke;
            this.logRtb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.logRtb.Location = new System.Drawing.Point(396, 99);
            this.logRtb.Name = "logRtb";
            this.logRtb.Size = new System.Drawing.Size(377, 359);
            this.logRtb.TabIndex = 30;
            this.logRtb.Text = "";
            // 
            // numVideoTb
            // 
            // 
            // 
            // 
            this.numVideoTb.CustomButton.Image = null;
            this.numVideoTb.CustomButton.Location = new System.Drawing.Point(18, 1);
            this.numVideoTb.CustomButton.Name = "";
            this.numVideoTb.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.numVideoTb.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.numVideoTb.CustomButton.TabIndex = 1;
            this.numVideoTb.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.numVideoTb.CustomButton.UseSelectable = true;
            this.numVideoTb.CustomButton.Visible = false;
            this.numVideoTb.Lines = new string[] {
        "40"};
            this.numVideoTb.Location = new System.Drawing.Point(350, 51);
            this.numVideoTb.MaxLength = 32767;
            this.numVideoTb.Name = "numVideoTb";
            this.numVideoTb.PasswordChar = '\0';
            this.numVideoTb.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.numVideoTb.SelectedText = "";
            this.numVideoTb.SelectionLength = 0;
            this.numVideoTb.SelectionStart = 0;
            this.numVideoTb.ShortcutsEnabled = true;
            this.numVideoTb.Size = new System.Drawing.Size(40, 23);
            this.numVideoTb.TabIndex = 4;
            this.numVideoTb.Text = "40";
            this.numVideoTb.UseSelectable = true;
            this.numVideoTb.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.numVideoTb.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(252, 51);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(92, 19);
            this.metroLabel1.TabIndex = 28;
            this.metroLabel1.Text = "Videos/Playlist";
            // 
            // createPllBtn
            // 
            this.createPllBtn.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.createPllBtn.Highlight = true;
            this.createPllBtn.Location = new System.Drawing.Point(447, 29);
            this.createPllBtn.Name = "createPllBtn";
            this.createPllBtn.Size = new System.Drawing.Size(151, 57);
            this.createPllBtn.TabIndex = 9;
            this.createPllBtn.Text = "Start";
            this.createPllBtn.UseSelectable = true;
            this.createPllBtn.Click += new System.EventHandler(this.createPllBtn_Click);
            // 
            // profileLb
            // 
            this.profileLb.AutoSize = true;
            this.profileLb.Location = new System.Drawing.Point(99, 18);
            this.profileLb.Name = "profileLb";
            this.profileLb.Size = new System.Drawing.Size(125, 19);
            this.profileLb.TabIndex = 25;
            this.profileLb.Text = "You select no folder";
            // 
            // multiCb
            // 
            this.multiCb.AutoSize = true;
            this.multiCb.Location = new System.Drawing.Point(13, 52);
            this.multiCb.Name = "multiCb";
            this.multiCb.Size = new System.Drawing.Size(88, 15);
            this.multiCb.TabIndex = 2;
            this.multiCb.Text = "Multi Profile";
            this.multiCb.UseSelectable = true;
            // 
            // profileBtn
            // 
            this.profileBtn.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.profileBtn.Location = new System.Drawing.Point(11, 9);
            this.profileBtn.Name = "profileBtn";
            this.profileBtn.Size = new System.Drawing.Size(82, 37);
            this.profileBtn.TabIndex = 1;
            this.profileBtn.Text = "Select Profile";
            this.profileBtn.UseSelectable = true;
            this.profileBtn.Click += new System.EventHandler(this.profileBtn_Click);
            // 
            // metroTabPage1
            // 
            this.metroTabPage1.Controls.Add(this.autoLoginCb);
            this.metroTabPage1.Controls.Add(this.multiProfileCb);
            this.metroTabPage1.Controls.Add(this.newProfileBtn);
            this.metroTabPage1.Controls.Add(this.profileFolderTb);
            this.metroTabPage1.Controls.Add(this.metroLabel2);
            this.metroTabPage1.HorizontalScrollbarBarColor = true;
            this.metroTabPage1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.HorizontalScrollbarSize = 10;
            this.metroTabPage1.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage1.Name = "metroTabPage1";
            this.metroTabPage1.Size = new System.Drawing.Size(786, 466);
            this.metroTabPage1.TabIndex = 2;
            this.metroTabPage1.Text = "Open Profile";
            this.metroTabPage1.VerticalScrollbarBarColor = true;
            this.metroTabPage1.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.VerticalScrollbarSize = 10;
            // 
            // autoLoginCb
            // 
            this.autoLoginCb.AutoSize = true;
            this.autoLoginCb.Location = new System.Drawing.Point(10, 80);
            this.autoLoginCb.Name = "autoLoginCb";
            this.autoLoginCb.Size = new System.Drawing.Size(82, 15);
            this.autoLoginCb.TabIndex = 8;
            this.autoLoginCb.Text = "Auto Login";
            this.autoLoginCb.UseSelectable = true;
            // 
            // multiProfileCb
            // 
            this.multiProfileCb.AutoSize = true;
            this.multiProfileCb.Location = new System.Drawing.Point(401, 32);
            this.multiProfileCb.Name = "multiProfileCb";
            this.multiProfileCb.Size = new System.Drawing.Size(88, 15);
            this.multiProfileCb.TabIndex = 7;
            this.multiProfileCb.Text = "Multi Profile";
            this.multiProfileCb.UseSelectable = true;
            // 
            // newProfileBtn
            // 
            this.newProfileBtn.DisplayFocus = true;
            this.newProfileBtn.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.newProfileBtn.Location = new System.Drawing.Point(623, 15);
            this.newProfileBtn.Name = "newProfileBtn";
            this.newProfileBtn.Size = new System.Drawing.Size(107, 43);
            this.newProfileBtn.TabIndex = 6;
            this.newProfileBtn.Text = "Start";
            this.newProfileBtn.UseSelectable = true;
            this.newProfileBtn.Click += new System.EventHandler(this.newProfileBtn_Click);
            // 
            // profileFolderTb
            // 
            // 
            // 
            // 
            this.profileFolderTb.CustomButton.Image = null;
            this.profileFolderTb.CustomButton.Location = new System.Drawing.Point(269, 1);
            this.profileFolderTb.CustomButton.Name = "";
            this.profileFolderTb.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.profileFolderTb.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.profileFolderTb.CustomButton.TabIndex = 1;
            this.profileFolderTb.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.profileFolderTb.CustomButton.UseSelectable = true;
            this.profileFolderTb.CustomButton.Visible = false;
            this.profileFolderTb.Lines = new string[0];
            this.profileFolderTb.Location = new System.Drawing.Point(103, 25);
            this.profileFolderTb.MaxLength = 32767;
            this.profileFolderTb.Name = "profileFolderTb";
            this.profileFolderTb.PasswordChar = '\0';
            this.profileFolderTb.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.profileFolderTb.SelectedText = "";
            this.profileFolderTb.SelectionLength = 0;
            this.profileFolderTb.SelectionStart = 0;
            this.profileFolderTb.ShortcutsEnabled = true;
            this.profileFolderTb.Size = new System.Drawing.Size(291, 23);
            this.profileFolderTb.TabIndex = 5;
            this.profileFolderTb.UseSelectable = true;
            this.profileFolderTb.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.profileFolderTb.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.profileFolderTb.Click += new System.EventHandler(this.profileFolderTb_Click);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(9, 29);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(89, 19);
            this.metroLabel2.TabIndex = 3;
            this.metroLabel2.Text = "Profile Folder";
            // 
            // metroTabPage3
            // 
            this.metroTabPage3.Controls.Add(this.useProxyCb);
            this.metroTabPage3.Controls.Add(this.saveSettingBtn);
            this.metroTabPage3.Controls.Add(this.proxyPassword);
            this.metroTabPage3.Controls.Add(this.proxyUsername);
            this.metroTabPage3.Controls.Add(this.proxyPort);
            this.metroTabPage3.Controls.Add(this.proxyHost);
            this.metroTabPage3.Controls.Add(this.proxySchema);
            this.metroTabPage3.Controls.Add(this.htmlLabel6);
            this.metroTabPage3.Controls.Add(this.htmlLabel5);
            this.metroTabPage3.Controls.Add(this.htmlLabel4);
            this.metroTabPage3.Controls.Add(this.htmlLabel3);
            this.metroTabPage3.Controls.Add(this.htmlLabel2);
            this.metroTabPage3.Controls.Add(this.htmlLabel1);
            this.metroTabPage3.HorizontalScrollbarBarColor = true;
            this.metroTabPage3.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage3.HorizontalScrollbarSize = 10;
            this.metroTabPage3.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage3.Name = "metroTabPage3";
            this.metroTabPage3.Size = new System.Drawing.Size(786, 466);
            this.metroTabPage3.TabIndex = 3;
            this.metroTabPage3.Text = "Settings";
            this.metroTabPage3.VerticalScrollbarBarColor = true;
            this.metroTabPage3.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage3.VerticalScrollbarSize = 10;
            // 
            // saveSettingBtn
            // 
            this.saveSettingBtn.BackColor = System.Drawing.Color.Red;
            this.saveSettingBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.saveSettingBtn.Highlight = true;
            this.saveSettingBtn.Location = new System.Drawing.Point(701, 3);
            this.saveSettingBtn.Name = "saveSettingBtn";
            this.saveSettingBtn.Size = new System.Drawing.Size(77, 41);
            this.saveSettingBtn.TabIndex = 12;
            this.saveSettingBtn.Text = "Save";
            this.saveSettingBtn.UseSelectable = true;
            this.saveSettingBtn.Click += new System.EventHandler(this.saveSettingBtn_Click);
            // 
            // proxyPassword
            // 
            // 
            // 
            // 
            this.proxyPassword.CustomButton.Image = null;
            this.proxyPassword.CustomButton.Location = new System.Drawing.Point(182, 1);
            this.proxyPassword.CustomButton.Name = "";
            this.proxyPassword.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.proxyPassword.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.proxyPassword.CustomButton.TabIndex = 1;
            this.proxyPassword.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.proxyPassword.CustomButton.UseSelectable = true;
            this.proxyPassword.CustomButton.Visible = false;
            this.proxyPassword.Lines = new string[0];
            this.proxyPassword.Location = new System.Drawing.Point(88, 229);
            this.proxyPassword.MaxLength = 32767;
            this.proxyPassword.Name = "proxyPassword";
            this.proxyPassword.PasswordChar = '\0';
            this.proxyPassword.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.proxyPassword.SelectedText = "";
            this.proxyPassword.SelectionLength = 0;
            this.proxyPassword.SelectionStart = 0;
            this.proxyPassword.ShortcutsEnabled = true;
            this.proxyPassword.Size = new System.Drawing.Size(210, 29);
            this.proxyPassword.TabIndex = 11;
            this.proxyPassword.UseSelectable = true;
            this.proxyPassword.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.proxyPassword.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // proxyUsername
            // 
            // 
            // 
            // 
            this.proxyUsername.CustomButton.Image = null;
            this.proxyUsername.CustomButton.Location = new System.Drawing.Point(182, 1);
            this.proxyUsername.CustomButton.Name = "";
            this.proxyUsername.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.proxyUsername.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.proxyUsername.CustomButton.TabIndex = 1;
            this.proxyUsername.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.proxyUsername.CustomButton.UseSelectable = true;
            this.proxyUsername.CustomButton.Visible = false;
            this.proxyUsername.Lines = new string[0];
            this.proxyUsername.Location = new System.Drawing.Point(88, 194);
            this.proxyUsername.MaxLength = 32767;
            this.proxyUsername.Name = "proxyUsername";
            this.proxyUsername.PasswordChar = '\0';
            this.proxyUsername.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.proxyUsername.SelectedText = "";
            this.proxyUsername.SelectionLength = 0;
            this.proxyUsername.SelectionStart = 0;
            this.proxyUsername.ShortcutsEnabled = true;
            this.proxyUsername.Size = new System.Drawing.Size(210, 29);
            this.proxyUsername.TabIndex = 10;
            this.proxyUsername.UseSelectable = true;
            this.proxyUsername.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.proxyUsername.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // proxyPort
            // 
            // 
            // 
            // 
            this.proxyPort.CustomButton.Image = null;
            this.proxyPort.CustomButton.Location = new System.Drawing.Point(182, 1);
            this.proxyPort.CustomButton.Name = "";
            this.proxyPort.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.proxyPort.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.proxyPort.CustomButton.TabIndex = 1;
            this.proxyPort.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.proxyPort.CustomButton.UseSelectable = true;
            this.proxyPort.CustomButton.Visible = false;
            this.proxyPort.Lines = new string[0];
            this.proxyPort.Location = new System.Drawing.Point(88, 159);
            this.proxyPort.MaxLength = 32767;
            this.proxyPort.Name = "proxyPort";
            this.proxyPort.PasswordChar = '\0';
            this.proxyPort.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.proxyPort.SelectedText = "";
            this.proxyPort.SelectionLength = 0;
            this.proxyPort.SelectionStart = 0;
            this.proxyPort.ShortcutsEnabled = true;
            this.proxyPort.Size = new System.Drawing.Size(210, 29);
            this.proxyPort.TabIndex = 9;
            this.proxyPort.UseSelectable = true;
            this.proxyPort.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.proxyPort.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // proxyHost
            // 
            // 
            // 
            // 
            this.proxyHost.CustomButton.Image = null;
            this.proxyHost.CustomButton.Location = new System.Drawing.Point(182, 1);
            this.proxyHost.CustomButton.Name = "";
            this.proxyHost.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.proxyHost.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.proxyHost.CustomButton.TabIndex = 1;
            this.proxyHost.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.proxyHost.CustomButton.UseSelectable = true;
            this.proxyHost.CustomButton.Visible = false;
            this.proxyHost.Lines = new string[0];
            this.proxyHost.Location = new System.Drawing.Point(88, 124);
            this.proxyHost.MaxLength = 32767;
            this.proxyHost.Name = "proxyHost";
            this.proxyHost.PasswordChar = '\0';
            this.proxyHost.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.proxyHost.SelectedText = "";
            this.proxyHost.SelectionLength = 0;
            this.proxyHost.SelectionStart = 0;
            this.proxyHost.ShortcutsEnabled = true;
            this.proxyHost.Size = new System.Drawing.Size(210, 29);
            this.proxyHost.TabIndex = 8;
            this.proxyHost.UseSelectable = true;
            this.proxyHost.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.proxyHost.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // proxySchema
            // 
            this.proxySchema.FormattingEnabled = true;
            this.proxySchema.ItemHeight = 23;
            this.proxySchema.Items.AddRange(new object[] {
            "http",
            "https",
            "socks4",
            "socks5"});
            this.proxySchema.Location = new System.Drawing.Point(88, 89);
            this.proxySchema.Name = "proxySchema";
            this.proxySchema.Size = new System.Drawing.Size(210, 29);
            this.proxySchema.TabIndex = 7;
            this.proxySchema.UseSelectable = true;
            // 
            // htmlLabel6
            // 
            this.htmlLabel6.AutoScroll = true;
            this.htmlLabel6.AutoScrollMinSize = new System.Drawing.Size(59, 23);
            this.htmlLabel6.AutoSize = false;
            this.htmlLabel6.BackColor = System.Drawing.SystemColors.Window;
            this.htmlLabel6.Location = new System.Drawing.Point(8, 231);
            this.htmlLabel6.Name = "htmlLabel6";
            this.htmlLabel6.Size = new System.Drawing.Size(71, 29);
            this.htmlLabel6.TabIndex = 6;
            this.htmlLabel6.Text = "Password";
            // 
            // htmlLabel5
            // 
            this.htmlLabel5.AutoScroll = true;
            this.htmlLabel5.AutoScrollMinSize = new System.Drawing.Size(61, 23);
            this.htmlLabel5.AutoSize = false;
            this.htmlLabel5.BackColor = System.Drawing.SystemColors.Window;
            this.htmlLabel5.Location = new System.Drawing.Point(8, 196);
            this.htmlLabel5.Name = "htmlLabel5";
            this.htmlLabel5.Size = new System.Drawing.Size(71, 29);
            this.htmlLabel5.TabIndex = 5;
            this.htmlLabel5.Text = "Username";
            // 
            // htmlLabel4
            // 
            this.htmlLabel4.AutoScroll = true;
            this.htmlLabel4.AutoScrollMinSize = new System.Drawing.Size(30, 23);
            this.htmlLabel4.AutoSize = false;
            this.htmlLabel4.BackColor = System.Drawing.SystemColors.Window;
            this.htmlLabel4.Location = new System.Drawing.Point(8, 163);
            this.htmlLabel4.Name = "htmlLabel4";
            this.htmlLabel4.Size = new System.Drawing.Size(56, 29);
            this.htmlLabel4.TabIndex = 4;
            this.htmlLabel4.Text = "Port";
            // 
            // htmlLabel3
            // 
            this.htmlLabel3.AutoScroll = true;
            this.htmlLabel3.AutoScrollMinSize = new System.Drawing.Size(33, 23);
            this.htmlLabel3.AutoSize = false;
            this.htmlLabel3.BackColor = System.Drawing.SystemColors.Window;
            this.htmlLabel3.Location = new System.Drawing.Point(8, 128);
            this.htmlLabel3.Name = "htmlLabel3";
            this.htmlLabel3.Size = new System.Drawing.Size(56, 29);
            this.htmlLabel3.TabIndex = 4;
            this.htmlLabel3.Text = "Host";
            // 
            // htmlLabel2
            // 
            this.htmlLabel2.AutoScroll = true;
            this.htmlLabel2.AutoScrollMinSize = new System.Drawing.Size(50, 23);
            this.htmlLabel2.AutoSize = false;
            this.htmlLabel2.BackColor = System.Drawing.SystemColors.Window;
            this.htmlLabel2.Location = new System.Drawing.Point(8, 92);
            this.htmlLabel2.Name = "htmlLabel2";
            this.htmlLabel2.Size = new System.Drawing.Size(56, 29);
            this.htmlLabel2.TabIndex = 3;
            this.htmlLabel2.Text = "Schema";
            // 
            // htmlLabel1
            // 
            this.htmlLabel1.AutoScroll = true;
            this.htmlLabel1.AutoScrollMinSize = new System.Drawing.Size(96, 25);
            this.htmlLabel1.AutoSize = false;
            this.htmlLabel1.BackColor = System.Drawing.SystemColors.Window;
            this.htmlLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.htmlLabel1.Location = new System.Drawing.Point(8, 29);
            this.htmlLabel1.Name = "htmlLabel1";
            this.htmlLabel1.Size = new System.Drawing.Size(182, 31);
            this.htmlLabel1.TabIndex = 2;
            this.htmlLabel1.Text = "Proxy settings";
            // 
            // useProxyCb
            // 
            this.useProxyCb.AutoSize = true;
            this.useProxyCb.Location = new System.Drawing.Point(11, 59);
            this.useProxyCb.Name = "useProxyCb";
            this.useProxyCb.Size = new System.Drawing.Size(75, 15);
            this.useProxyCb.TabIndex = 13;
            this.useProxyCb.Text = "Use Proxy";
            this.useProxyCb.UseSelectable = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(794, 508);
            this.Controls.Add(this.metroTabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(810, 547);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Youtube Playlist";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.Load += new System.EventHandler(this.Main_Load);
            this.metroTabControl1.ResumeLayout(false);
            this.mainTab.ResumeLayout(false);
            this.mainTab.PerformLayout();
            this.metroTabPage1.ResumeLayout(false);
            this.metroTabPage1.PerformLayout();
            this.metroTabPage3.ResumeLayout(false);
            this.metroTabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private MetroFramework.Controls.MetroTabPage mainTab;
        private MetroFramework.Controls.MetroLabel profileLb;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroCheckBox multiCb;
        private MetroFramework.Controls.MetroButton profileBtn;
        private MetroFramework.Controls.MetroTabPage metroTabPage1;
        private MetroFramework.Controls.MetroTextBox profileFolderTb;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroButton newProfileBtn;
        private MetroFramework.Controls.MetroButton createPllBtn;
        private MetroFramework.Controls.MetroCheckBox multiProfileCb;
        private MetroFramework.Controls.MetroTextBox numVideoTb;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox NumPllTb;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroCheckBox autoLoginCb;
        public System.Windows.Forms.RichTextBox logRtb;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        public System.Windows.Forms.RichTextBox pllListTb;
        private MetroFramework.Controls.MetroTextBox KeywordTb;
        private MetroFramework.Controls.MetroTextBox videoTb;
        private MetroFramework.Controls.MetroTextBox videoPosTb;
        private MetroFramework.Controls.MetroTextBox descriptionTb;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroCheckBox canAddVideoCb;
        private MetroFramework.Controls.MetroButton stopBtn;
        private MetroFramework.Controls.MetroTabPage metroTabPage3;
        private MetroFramework.Controls.MetroTextBox proxyHost;
        private MetroFramework.Controls.MetroComboBox proxySchema;
        private MetroFramework.Drawing.Html.HtmlLabel htmlLabel6;
        private MetroFramework.Drawing.Html.HtmlLabel htmlLabel5;
        private MetroFramework.Drawing.Html.HtmlLabel htmlLabel4;
        private MetroFramework.Drawing.Html.HtmlLabel htmlLabel3;
        private MetroFramework.Drawing.Html.HtmlLabel htmlLabel2;
        private MetroFramework.Drawing.Html.HtmlLabel htmlLabel1;
        private MetroFramework.Controls.MetroTextBox proxyPassword;
        private MetroFramework.Controls.MetroTextBox proxyUsername;
        private MetroFramework.Controls.MetroTextBox proxyPort;
        private MetroFramework.Controls.MetroButton saveSettingBtn;
        private MetroFramework.Controls.MetroCheckBox useProxyCb;
    }
}

