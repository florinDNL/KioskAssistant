using kioskAssistant.Model;
using System;
using System.Windows.Forms;

namespace kioskAssistant.Forms
{
    public partial class startWindow : Form
    {
        private readonly AppCatalog catalog;
        private readonly AppSettings settings;

        internal startWindow(AppCatalog catalog, AppSettings settings)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            this.catalog = catalog;
            this.settings = settings;
        }

        private void multiAppBt_Click(object sender, EventArgs e)
        {
            var multiAppForm = new multiApp(catalog);
            this.Hide();
            multiAppForm.ShowDialog();
            this.Show();
        }

        private void sLauncherBt_Click(object sender, EventArgs e)
        {
            var sLauncherForm = new shellLauncher(catalog);
            this.Hide();
            sLauncherForm.ShowDialog();
            this.Show();
        }

        private void settingsMenuItem_Click(object sender, EventArgs e)
        {
            using var settingsForm = new settingsWindow(settings);
            settingsForm.ShowDialog(this);
        }

        private void aboutMenuItem_Click(object sender, EventArgs e)
        {
            using var aboutForm = new aboutWindow(Icon);
            aboutForm.ShowDialog(this);
        }
    }
}
