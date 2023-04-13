using allGlobals;
using System;
using System.Windows.Forms;

namespace kioskAssistant
{
    public partial class autoLaunch : Form
    {
        public autoLaunch()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void updateAutoLaunchApp()
        {
            if (perFormObjects.autoLaunch.Count == 0)
            {
                perFormObjects.autoLaunch.Add(allAppsCb.SelectedItem.ToString());
                perFormObjects.autoLaunch.Add(argumentsTb.Text);
            }
            else
            {
                perFormObjects.autoLaunch[0] = allAppsCb.SelectedItem.ToString();
                perFormObjects.autoLaunch[1] = argumentsTb.Text;
            }
        }

        private void okBt_Click(object sender, EventArgs e)
        {
            if (!(allAppsCb.SelectedIndex == -1))
            {
                DialogResult = DialogResult.OK;
                updateAutoLaunchApp();
                Close();
            }
            else
            {
                MessageBox.Show("No application selected");
            }

        }

        private void cancelBt_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void clearBt_Click(object sender, EventArgs e)
        {
            allAppsCb.SelectedIndex = -1;
            argumentsTb.Text = string.Empty;
            if (!(perFormObjects.autoLaunch.Count == 0))
            {
                perFormObjects.autoLaunch = new();
            }
        }
    }
}
