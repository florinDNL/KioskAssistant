using allGlobals;
using System.Windows.Forms;
using kioskAssistant.Controls;
using System;
using System.Collections.Generic;

namespace kioskAssistant
{
    public partial class kioskModeApp : Form
    {
        TextBox url;
        TextBox idleTimeout;
        TextBox executable;
        TextBox arguments;
        ComboBox browsingType;
        ComboBox uwpApp;
        List<string> profileParam = new();

        public kioskModeApp()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            guidLabel.Text = Globals.GetGUID();
            saveProfileBt.Enabled = false;
        }

        #region Button Click Events


        private void saveProfileBt_Click(object sender, EventArgs e)
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
                if (uwpApp.SelectedIndex == -1)
                {
                    Message = "No App selected";
                }
                else
                {
                    string app = uwpApp.SelectedItem.ToString();
                    profileParam.Add("UWP");
                    profileParam.Add(app);
                }
            }
            else if (appTypeCb.SelectedIndex == 2)
            {
                string exe = executable.Text;
                string arg = arguments.Text;

                if (string.IsNullOrEmpty(exe))
                {
                    Message = "No executable selected";
                }
                else
                {
                    profileParam.Add("win32");
                    profileParam.Add(exe);
                    profileParam.Add(arg);
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

        private void cancelbt_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        #endregion

        private void appTypeCb_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            kModePanel.Controls.Clear();

            if (appTypeCb.SelectedIndex == 0)
            {
                EdgeUserControl EdgeControl = new();
                kModePanel.Controls.Add(EdgeControl);
                url = EdgeControl.urlTb;
                idleTimeout = EdgeControl.idleTb;
                browsingType = EdgeControl.browsingCb;
            }
            else if (appTypeCb.SelectedIndex == 1)
            {
                UwpUserControl UwpControl = new();
                kModePanel.Controls.Add(UwpControl);
                uwpApp = UwpControl.appCb;
            }
            else if (appTypeCb.SelectedIndex == 2)
            {
                win32UserControl win32Control = new();
                kModePanel.Controls.Add(win32Control);
                executable = win32Control.exeTb;
                arguments = win32Control.argTb;
            }

            saveProfileBt.Enabled = true;
        }

        private void kioskModeApp_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                perFormObjects.kioskModeApps.Add(guidLabel.Text, profileParam);
            }
        }
    }
}
