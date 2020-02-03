namespace Youtube_PLL
{
    partial class Start
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Start));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.emailTb = new System.Windows.Forms.TextBox();
            this.activateCodeTb = new System.Windows.Forms.TextBox();
            this.startBtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.errorEmailLb = new System.Windows.Forms.Label();
            this.errorCodeLb = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.forgetCodeLb = new System.Windows.Forms.LinkLabel();
            this.rememberCb = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(68, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(247, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Login to Your Account";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(43, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Your Email";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(43, 224);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Your License";
            // 
            // emailTb
            // 
            this.emailTb.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.emailTb.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.emailTb.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailTb.Location = new System.Drawing.Point(46, 171);
            this.emailTb.Name = "emailTb";
            this.emailTb.Size = new System.Drawing.Size(290, 29);
            this.emailTb.TabIndex = 3;
            this.emailTb.KeyUp += new System.Windows.Forms.KeyEventHandler(this.emailTb_KeyUp);
            // 
            // activateCodeTb
            // 
            this.activateCodeTb.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.activateCodeTb.Location = new System.Drawing.Point(46, 243);
            this.activateCodeTb.Name = "activateCodeTb";
            this.activateCodeTb.PasswordChar = '*';
            this.activateCodeTb.Size = new System.Drawing.Size(290, 29);
            this.activateCodeTb.TabIndex = 4;
            this.activateCodeTb.KeyUp += new System.Windows.Forms.KeyEventHandler(this.activateCodeTb_KeyUp);
            // 
            // startBtn
            // 
            this.startBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.startBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.startBtn.FlatAppearance.BorderSize = 0;
            this.startBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startBtn.ForeColor = System.Drawing.Color.AliceBlue;
            this.startBtn.Location = new System.Drawing.Point(138, 315);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(98, 42);
            this.startBtn.TabIndex = 5;
            this.startBtn.Text = "Start";
            this.startBtn.UseVisualStyleBackColor = false;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Youtube_PLL.Properties.Resources.pngguru_com_id_bylqy;
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(147, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(80, 80);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // errorEmailLb
            // 
            this.errorEmailLb.AutoSize = true;
            this.errorEmailLb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorEmailLb.ForeColor = System.Drawing.Color.Red;
            this.errorEmailLb.Location = new System.Drawing.Point(43, 203);
            this.errorEmailLb.Name = "errorEmailLb";
            this.errorEmailLb.Size = new System.Drawing.Size(0, 15);
            this.errorEmailLb.TabIndex = 7;
            // 
            // errorCodeLb
            // 
            this.errorCodeLb.AutoSize = true;
            this.errorCodeLb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorCodeLb.ForeColor = System.Drawing.Color.Red;
            this.errorCodeLb.Location = new System.Drawing.Point(43, 275);
            this.errorCodeLb.Name = "errorCodeLb";
            this.errorCodeLb.Size = new System.Drawing.Size(0, 15);
            this.errorCodeLb.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 386);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "girangopro@gmail.com";
            // 
            // forgetCodeLb
            // 
            this.forgetCodeLb.AutoSize = true;
            this.forgetCodeLb.Location = new System.Drawing.Point(256, 154);
            this.forgetCodeLb.Name = "forgetCodeLb";
            this.forgetCodeLb.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.forgetCodeLb.Size = new System.Drawing.Size(83, 13);
            this.forgetCodeLb.TabIndex = 10;
            this.forgetCodeLb.TabStop = true;
            this.forgetCodeLb.Text = "Get your license";
            this.forgetCodeLb.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.forgetCodeLb.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.forgetCodeLb_LinkClicked);
            // 
            // rememberCb
            // 
            this.rememberCb.AutoSize = true;
            this.rememberCb.Checked = true;
            this.rememberCb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.rememberCb.Location = new System.Drawing.Point(46, 279);
            this.rememberCb.Name = "rememberCb";
            this.rememberCb.Size = new System.Drawing.Size(117, 17);
            this.rememberCb.TabIndex = 11;
            this.rememberCb.Text = "Remember License";
            this.rememberCb.UseVisualStyleBackColor = true;
            // 
            // Start
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(384, 411);
            this.Controls.Add(this.rememberCb);
            this.Controls.Add(this.forgetCodeLb);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.errorCodeLb);
            this.Controls.Add(this.errorEmailLb);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.activateCodeTb);
            this.Controls.Add(this.emailTb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Start";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Start_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox emailTb;
        private System.Windows.Forms.TextBox activateCodeTb;
        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label errorEmailLb;
        private System.Windows.Forms.Label errorCodeLb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel forgetCodeLb;
        private System.Windows.Forms.CheckBox rememberCb;
    }
}