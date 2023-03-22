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
            slWin32UserControl slControl = new slWin32UserControl();
            shellPanel.Controls.Add(slControl);
            guidLabel.Text = Globals.GetGUID();           
        }

        TextBox url;
        TextBox idleTimeout;
        TextBox win32shell;
        TextBox arguments;
        ComboBox browsingType;
        ComboBox uwpshell;
        CheckBox fullScreen;
        List<string> profileParam = new();

        private void appTypeCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            shellPanel.Controls.Clear();

            if (appTypeCb.SelectedIndex == 0)
            {
                EdgeUserControl edgeControl = new EdgeUserControl();
                shellPanel.Controls.Add(edgeControl);
                url = edgeControl.urlTb;
                idleTimeout = edgeControl.urlTb;
                browsingType = edgeControl.browsingCb;
            }
            else if (appTypeCb.SelectedIndex == 1)
            {
                slUwpUserControl uwpControl = new slUwpUserControl();
                shellPanel.Controls.Add(uwpControl);
                uwpshell = uwpControl.appCb;
            }
            else if (appTypeCb.SelectedIndex == 2)
            {
                slWin32UserControl slControl = new slWin32UserControl();
                shellPanel.Controls.Add(slControl);
                win32shell = slControl.shellTb;
                fullScreen = slControl.fullscreenCb;
                arguments  = slControl.argTb;
            }
        }

        private void saveCsBt_Click(object sender, EventArgs e)
        {
            string Message = "";
            if (appTypeCb.SelectedIndex == 0)
            {
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

            }
            else if (appTypeCb.SelectedIndex == 1)
            {
                if (uwpshell.SelectedIndex == -1)
                {
                    Message = "No App selected";
                }
                else
                {
                    string app = uwpshell.SelectedItem.ToString();
                    profileParam.Add("UWP");
                    profileParam.Add(app);
                }
            }
            else if (appTypeCb.SelectedIndex == 2)
            {
                string exe = win32shell.Text;
                string args = arguments.Text;
                string fsbool = fullScreen.Checked.ToString();

                if (string.IsNullOrEmpty(exe))
                {
                    Message = "No executable selected";
                }
                else
                {
                    profileParam.Add("win32");
                    profileParam.Add(exe);
                    profileParam.Add(args);
                    profileParam.Add(fsbool);
                }
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
                perFormObjects.shellLauncherAccs.Add(guidLabel.Text, profileParam);
            }
        }
    }
}
