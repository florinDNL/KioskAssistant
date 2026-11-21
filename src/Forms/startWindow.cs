using kioskAssistant.Model;
using System;
using System.Windows.Forms;

namespace kioskAssistant.Forms
{
    public partial class startWindow : Form
    {
        private readonly AppCatalog catalog;

        public startWindow(AppCatalog catalog)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            this.catalog = catalog;
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
    }
}
