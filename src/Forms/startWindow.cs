using System;
using System.Windows.Forms;

namespace kioskAssistant.Forms
{
    public partial class startWindow : Form
    {
        public startWindow()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void multiAppBt_Click(object sender, EventArgs e)
        {
            var multiAppForm = new multiApp();
            this.Hide();
            multiAppForm.ShowDialog();
            this.Show();
        }

        private void sLauncherBt_Click(object sender, EventArgs e)
        {
            var sLauncherForm = new shellLauncher();
            this.Hide();
            sLauncherForm.ShowDialog();
            this.Show();
        }
    }
}
