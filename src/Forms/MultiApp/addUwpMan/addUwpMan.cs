using kioskAssistant.Model;
using System;
using System.Windows.Forms;

namespace kioskAssistant.Forms.MultiApp
{
    public partial class addUwpMan : Form
    {
        private readonly AppCatalog catalog;

        public string AddedApp { get; private set; }

        public addUwpMan(AppCatalog catalog)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            this.catalog = catalog;
        }

        private void addBt_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(nameTb.Text) && !string.IsNullOrEmpty(aumidTb.Text))
            {
                if (catalog.UwpApps.ContainsKey(nameTb.Text)) { MessageBox.Show("This aplication is already added"); }
                else
                {
                    catalog.UwpApps.Add(nameTb.Text, aumidTb.Text);
                    AddedApp = nameTb.Text;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }
    }
}
