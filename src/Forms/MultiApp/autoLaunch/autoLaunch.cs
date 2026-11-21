using kioskAssistant.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace kioskAssistant
{
    public partial class autoLaunch : Form
    {
        /// <summary>The configured auto-launch app, or null if none. Unchanged when the dialog is cancelled.</summary>
        public AutoLaunchApp Selection { get; private set; }

        public autoLaunch(IEnumerable<object> candidateApps, AutoLaunchApp current)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            Selection = current;

            foreach (var app in candidateApps)
            {
                allAppsCb.Items.Add(app);
            }

            if (current != null)
            {
                allAppsCb.SelectedItem = current.App;
                argumentsTb.Text = current.Arguments;
            }
        }

        private void okBt_Click(object sender, EventArgs e)
        {
            if (allAppsCb.SelectedIndex != -1)
            {
                Selection = new AutoLaunchApp(allAppsCb.SelectedItem.ToString(), argumentsTb.Text);
                DialogResult = DialogResult.OK;
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
            if (Selection != null)
            {
                Selection = null;
                Close();
            }
        }
    }
}
