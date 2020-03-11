using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Youtube_PLL
{
    public partial class Start : Form
    {
        string machineId = "";
        public Start(string machineId)
        {
            this.machineId = machineId;
            InitializeComponent();
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            string email = emailTb.Text.Trim();
            if (string.IsNullOrEmpty(email))
            {
                errorEmailLb.Text = "Your email is empty!";
                emailTb.Focus();
                return;
            }
            string code = activateCodeTb.Text.Trim();
            if (string.IsNullOrEmpty(code))
            {
                errorCodeLb.Text = "Your activate code is empty!";
                activateCodeTb.Focus();
                return;
            }
            if (login(email, code))
            {
                this.Hide();
                new Main(email, code, this.machineId).ShowDialog();
            }
            else
            {
                return;
            }
        }

        private void emailTb_KeyUp(object sender, KeyEventArgs e)
        {
            if (string.IsNullOrEmpty(emailTb.Text.Trim()))
            {
                errorEmailLb.Text = "Your email is empty!";
                return;
            }
            errorEmailLb.Text = "";
        }

        private void activateCodeTb_KeyUp(object sender, KeyEventArgs e)
        {
            if (string.IsNullOrEmpty(activateCodeTb.Text.Trim()))
            {
                errorCodeLb.Text = "Your activate code is empty!";
                return;
            }
            errorCodeLb.Text = "";
        }

        private bool login(string email, string code)
        {
            try
            {
                var data = new Dictionary<string, string>();
                data["email"] = email;
                data["activate_code"] = code;
                data["machine"] = machineId;
                var request = new Request("POST", "https://ytb.tokamedia.com/api/licenses/check", JSON.Encode(data));
                var response = JSON.Decode<Dictionary<string, string>>(request.ResponseText);
                if (response["type"] == "success")
                {
                    Properties.Settings.Default.Email = email;
                    if (rememberCb.Checked) Properties.Settings.Default.License = code;
                    Properties.Settings.Default.Save();
                    return true;
                }
                else
                {
                    MessageBox.Show(response["message"], "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }
        }

        private void forgetCodeLb_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(emailTb.Text.Trim()))
                {
                    errorEmailLb.Text = "Your email is empty!";
                    return;
                }
                var data = new Dictionary<string, string>();
                data["email"] = emailTb.Text;
                data["machine"] = machineId;
                var request = new Request("POST", "https://ytb.tokamedia.com/api/licenses", JSON.Encode(data));
                var response = JSON.Decode<Dictionary<string, string>>(request.ResponseText);
                if(response["type"] == "success")
                {
                    MessageBox.Show(response["message"],"Success!",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(response["message"], "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {

            }
        }

        private void Start_Load(object sender, EventArgs e)
        {
            Properties.Settings.Default.Running = true;
            if (Properties.Settings.Default.Email != string.Empty)
            {
                emailTb.Text = Properties.Settings.Default.Email;
            }
            if (Properties.Settings.Default.License != string.Empty)
            {
                activateCodeTb.Text = Properties.Settings.Default.License;
            }
        }
    }
}
