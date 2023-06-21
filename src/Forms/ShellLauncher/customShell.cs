using allGlobals;
using kioskAssistant.Controls;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace kioskAssistant.Forms
{
    public partial class customShell : Form
    {
        public customShell()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            actionCb.SelectedIndex = 0;
            appTypeCb.SelectedIndex = 2;
            win32UserControl slControl = new win32UserControl();
            shellPanel.Controls.Add(slControl);
            guidLabel.Text = Globals.GetGUID();
        }

        TextBox url;
        TextBox idleTimeout;
        TextBox win32shell;
        TextBox arguments;
        ComboBox browsingType;
        ComboBox uwpshell;
        List<string> profileParam = new();

        private void appTypeCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            shellPanel.Controls.Clear();

            switch(appTypeCb.SelectedIndex){
                case 0:
                    EdgeUserControl edgeControl = new EdgeUserControl();
                    shellPanel.Controls.Add(edgeControl);
                    url = edgeControl.urlTb;
                    idleTimeout = edgeControl.idleTb;
                    browsingType = edgeControl.browsingCb;
                    break;
                case 1:
                    UwpUserControl uwpControl = new UwpUserControl();
                    shellPanel.Controls.Add(uwpControl);
                    uwpshell = uwpControl.appCb;
                    break;
                case 2:
                    win32UserControl slControl = new win32UserControl();
                    slControl.exeLb.Text = "Shell:";
                    shellPanel.Controls.Add(slControl);
                    win32shell = slControl.exeTb;
                    arguments = slControl.argTb;
                    break;
            }
        }

        private void saveCsBt_Click(object sender, EventArgs e)
        {
            string Message = "";
            switch (appTypeCb.SelectedIndex)
            {
                case 0:
                    string link = url.Text;
                    string timeout = idleTimeout.Text;
                    string browsing = browsingType.SelectedItem.ToString();

                    if (string.IsNullOrEmpty(link))
                    {
                        Message = "No URL added";
                    }
                    else
                    {
                        profileParam.Add("Edge");
                        profileParam.Add(link);
                        profileParam.Add(timeout);
                        profileParam.Add(browsing);
                    }
                    break;
                case 1:
                    if (string.IsNullOrEmpty(uwpshell.Text))
                    {
                        Message = "No App selected";
                    }
                    else
                    {
                        string app = uwpshell.Text;
                        profileParam.Add("UWP");
                        profileParam.Add(app);
                    }
                    break;
                case 2:
                    string exe = win32shell.Text;
                    string args = arguments.Text;

                    if (string.IsNullOrEmpty(exe))
                    {
                        Message = "No executable selected";
                    }
                    else
                    {
                        profileParam.Add("win32");
                        profileParam.Add(exe);
                        profileParam.Add(args);
                    }
                    break;
            }

            if (string.IsNullOrEmpty(Message))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(Message);
            }
        }

        private void customShell_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                profileParam.Add(fullscreenCb.Checked.ToString().ToLower());
                profileParam.Add(actionCb.SelectedItem.ToString());
                perFormObjects.shellLauncherAccs.Add(guidLabel.Text, profileParam);
            }
        }
    }
}
