﻿namespace Youtube_PLL
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
            this.components = new System.ComponentModel.Container();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.metroToolTip1 = new MetroFramework.Components.MetroToolTip();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.metroTabPage2 = new MetroFramework.Controls.MetroTabPage();
            this.pllListTb = new System.Windows.Forms.RichTextBox();
            this.Keywords2Tb = new System.Windows.Forms.RichTextBox();
            this.KeywordsTb = new System.Windows.Forms.RichTextBox();
            this.runBackCb = new MetroFramework.Controls.MetroCheckBox();
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
            this.metroContextMenu1 = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.metroToolTip2 = new MetroFramework.Components.MetroToolTip();
            this.videosTb = new System.Windows.Forms.RichTextBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroTabControl1.SuspendLayout();
            this.metroTabPage2.SuspendLayout();
            this.metroTabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroToolTip1
            // 
            this.metroToolTip1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroToolTip1.StyleManager = null;
            this.metroToolTip1.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.Location = new System.Drawing.Point(13, 102);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(64, 19);
            this.metroLabel7.TabIndex = 23;
            this.metroLabel7.Text = "Keywords";
            this.metroLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.metroToolTip1.SetToolTip(this.metroLabel7, "Each keyword per line is equivalent to a playlist. With many profiles, the tool d" +
        "oes not run the previous keyword again. When the keyword runs out, the tool will" +
        " stop");
            this.metroLabel7.WrapToLine = true;
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Controls.Add(this.metroTabPage2);
            this.metroTabControl1.Controls.Add(this.metroTabPage1);
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
            // metroTabPage2
            // 
            this.metroTabPage2.Controls.Add(this.metroLabel4);
            this.metroTabPage2.Controls.Add(this.videosTb);
            this.metroTabPage2.Controls.Add(this.pllListTb);
            this.metroTabPage2.Controls.Add(this.Keywords2Tb);
            this.metroTabPage2.Controls.Add(this.KeywordsTb);
            this.metroTabPage2.Controls.Add(this.runBackCb);
            this.metroTabPage2.Controls.Add(this.NumPllTb);
            this.metroTabPage2.Controls.Add(this.metroLabel3);
            this.metroTabPage2.Controls.Add(this.logRtb);
            this.metroTabPage2.Controls.Add(this.numVideoTb);
            this.metroTabPage2.Controls.Add(this.metroLabel1);
            this.metroTabPage2.Controls.Add(this.createPllBtn);
            this.metroTabPage2.Controls.Add(this.profileLb);
            this.metroTabPage2.Controls.Add(this.metroLabel7);
            this.metroTabPage2.Controls.Add(this.multiCb);
            this.metroTabPage2.Controls.Add(this.profileBtn);
            this.metroTabPage2.HorizontalScrollbarBarColor = true;
            this.metroTabPage2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.HorizontalScrollbarSize = 10;
            this.metroTabPage2.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage2.Name = "metroTabPage2";
            this.metroTabPage2.Size = new System.Drawing.Size(786, 466);
            this.metroTabPage2.TabIndex = 1;
            this.metroTabPage2.Text = "Create Playlist";
            this.metroTabPage2.VerticalScrollbarBarColor = true;
            this.metroTabPage2.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.VerticalScrollbarSize = 10;
            // 
            // pllListTb
            // 
            this.pllListTb.Location = new System.Drawing.Point(396, 188);
            this.pllListTb.Name = "pllListTb";
            this.pllListTb.Size = new System.Drawing.Size(377, 157);
            this.pllListTb.TabIndex = 37;
            this.pllListTb.Text = "";
            // 
            // Keywords2Tb
            // 
            this.Keywords2Tb.Location = new System.Drawing.Point(396, 99);
            this.Keywords2Tb.Name = "Keywords2Tb";
            this.Keywords2Tb.Size = new System.Drawing.Size(377, 79);
            this.Keywords2Tb.TabIndex = 36;
            this.Keywords2Tb.Text = "";
            // 
            // KeywordsTb
            // 
            this.KeywordsTb.Location = new System.Drawing.Point(110, 99);
            this.KeywordsTb.Name = "KeywordsTb";
            this.KeywordsTb.Size = new System.Drawing.Size(280, 157);
            this.KeywordsTb.TabIndex = 35;
            this.KeywordsTb.Text = "";
            // 
            // runBackCb
            // 
            this.runBackCb.AutoSize = true;
            this.runBackCb.Location = new System.Drawing.Point(454, 68);
            this.runBackCb.Name = "runBackCb";
            this.runBackCb.Size = new System.Drawing.Size(74, 15);
            this.runBackCb.TabIndex = 33;
            this.runBackCb.Text = "Run Loop";
            this.runBackCb.UseSelectable = true;
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
            this.NumPllTb.Location = new System.Drawing.Point(221, 61);
            this.NumPllTb.MaxLength = 32767;
            this.NumPllTb.Name = "NumPllTb";
            this.NumPllTb.PasswordChar = '\0';
            this.NumPllTb.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.NumPllTb.SelectedText = "";
            this.NumPllTb.SelectionLength = 0;
            this.NumPllTb.SelectionStart = 0;
            this.NumPllTb.ShortcutsEnabled = true;
            this.NumPllTb.Size = new System.Drawing.Size(40, 23);
            this.NumPllTb.TabIndex = 32;
            this.NumPllTb.Text = "10";
            this.NumPllTb.UseSelectable = true;
            this.NumPllTb.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.NumPllTb.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(113, 65);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(74, 19);
            this.metroLabel3.TabIndex = 31;
            this.metroLabel3.Text = "Playlist/Acc";
            // 
            // logRtb
            // 
            this.logRtb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.logRtb.Location = new System.Drawing.Point(396, 351);
            this.logRtb.Name = "logRtb";
            this.logRtb.Size = new System.Drawing.Size(377, 79);
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
            this.numVideoTb.Location = new System.Drawing.Point(396, 61);
            this.numVideoTb.MaxLength = 32767;
            this.numVideoTb.Name = "numVideoTb";
            this.numVideoTb.PasswordChar = '\0';
            this.numVideoTb.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.numVideoTb.SelectedText = "";
            this.numVideoTb.SelectionLength = 0;
            this.numVideoTb.SelectionStart = 0;
            this.numVideoTb.ShortcutsEnabled = true;
            this.numVideoTb.Size = new System.Drawing.Size(40, 23);
            this.numVideoTb.TabIndex = 29;
            this.numVideoTb.Text = "40";
            this.numVideoTb.UseSelectable = true;
            this.numVideoTb.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.numVideoTb.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(288, 65);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(92, 19);
            this.metroLabel1.TabIndex = 28;
            this.metroLabel1.Text = "Videos/Playlist";
            // 
            // createPllBtn
            // 
            this.createPllBtn.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.createPllBtn.Location = new System.Drawing.Point(622, 15);
            this.createPllBtn.Name = "createPllBtn";
            this.createPllBtn.Size = new System.Drawing.Size(151, 69);
            this.createPllBtn.TabIndex = 27;
            this.createPllBtn.Text = "Start";
            this.createPllBtn.UseSelectable = true;
            this.createPllBtn.Click += new System.EventHandler(this.createPllBtn_Click);
            // 
            // profileLb
            // 
            this.profileLb.AutoSize = true;
            this.profileLb.Location = new System.Drawing.Point(101, 25);
            this.profileLb.Name = "profileLb";
            this.profileLb.Size = new System.Drawing.Size(125, 19);
            this.profileLb.TabIndex = 25;
            this.profileLb.Text = "You select no folder";
            // 
            // multiCb
            // 
            this.multiCb.AutoSize = true;
            this.multiCb.Location = new System.Drawing.Point(13, 69);
            this.multiCb.Name = "multiCb";
            this.multiCb.Size = new System.Drawing.Size(88, 15);
            this.multiCb.TabIndex = 18;
            this.multiCb.Text = "Multi Profile";
            this.multiCb.UseSelectable = true;
            // 
            // profileBtn
            // 
            this.profileBtn.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.profileBtn.Location = new System.Drawing.Point(13, 16);
            this.profileBtn.Name = "profileBtn";
            this.profileBtn.Size = new System.Drawing.Size(82, 30);
            this.profileBtn.TabIndex = 17;
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
            // metroContextMenu1
            // 
            this.metroContextMenu1.Name = "metroContextMenu1";
            this.metroContextMenu1.Size = new System.Drawing.Size(61, 4);
            // 
            // metroToolTip2
            // 
            this.metroToolTip2.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroToolTip2.StyleManager = null;
            this.metroToolTip2.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // videosTb
            // 
            this.videosTb.Location = new System.Drawing.Point(110, 273);
            this.videosTb.Name = "videosTb";
            this.videosTb.Size = new System.Drawing.Size(280, 157);
            this.videosTb.TabIndex = 38;
            this.videosTb.Text = "";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(13, 273);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(64, 19);
            this.metroLabel4.TabIndex = 39;
            this.metroLabel4.Text = "Video Url";
            this.metroLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.metroToolTip1.SetToolTip(this.metroLabel4, "Each keyword per line is equivalent to a playlist. With many profiles, the tool d" +
        "oes not run the previous keyword again. When the keyword runs out, the tool will" +
        " stop");
            this.metroLabel4.WrapToLine = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(794, 508);
            this.Controls.Add(this.metroTabControl1);
            this.MinimumSize = new System.Drawing.Size(810, 547);
            this.Name = "Main";
            this.Text = "Form1";
            this.metroTabControl1.ResumeLayout(false);
            this.metroTabPage2.ResumeLayout(false);
            this.metroTabPage2.PerformLayout();
            this.metroTabPage1.ResumeLayout(false);
            this.metroTabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private MetroFramework.Components.MetroToolTip metroToolTip1;
        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private MetroFramework.Controls.MetroTabPage metroTabPage2;
        private MetroFramework.Controls.MetroContextMenu metroContextMenu1;
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
        private MetroFramework.Controls.MetroCheckBox runBackCb;
        private MetroFramework.Controls.MetroCheckBox autoLoginCb;
        private MetroFramework.Components.MetroToolTip metroToolTip2;
        public System.Windows.Forms.RichTextBox Keywords2Tb;
        public System.Windows.Forms.RichTextBox KeywordsTb;
        public System.Windows.Forms.RichTextBox logRtb;
        public System.Windows.Forms.RichTextBox pllListTb;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        public System.Windows.Forms.RichTextBox videosTb;
    }
}

