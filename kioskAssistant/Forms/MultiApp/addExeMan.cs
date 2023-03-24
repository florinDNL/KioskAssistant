using System;
using System.Windows.Forms;
using allGlobals;

namespace kioskAssistant.Forms.MultiApp
{
    public partial class addExeMan : Form
    {
        public addExeMan()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void addBt_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(exeTb.Text))
            {
                if (appProfile.win32AppLb.Items.Contains(exeTb.Text)) { MessageBox.Show("This aplication is already added"); }
                else
                {                    
                    appProfile.win32AppLb.Items.Add(exeTb.Text);
                    if (!string.IsNullOrEmpty(lnkTb.Text) & !appProfile.lnkFileLb.Items.Contains(lnkTb.Text))
                    { 
                        appProfile.lnkFileLb.Items.Add(lnkTb.Text);
                        perFormObjects.linkedWin32Apps.Add(exeTb.Text, lnkTb.Text);
                    }
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }
    }
}
