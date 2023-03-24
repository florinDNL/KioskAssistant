using System;
using System.Windows.Forms;
using allGlobals;

namespace kioskAssistant.Forms.MultiApp
{
    public partial class addUwpMan : Form
    {
        public addUwpMan()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void addBt_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(nameTb.Text) & !string.IsNullOrEmpty(aumidTb.Text))
            {
                if (Globals.allUwpApps.ContainsKey(nameTb.Text)) { MessageBox.Show("This aplication is already added"); }
                else
                {
                    Globals.allUwpApps.Add(nameTb.Text, aumidTb.Text);
                    appProfile.uwpAppClb.Items.Add(nameTb.Text, true);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }                    
            }
        }
    }
}
