using System;
using System.Windows.Forms;

namespace kioskAssistant.Forms.MultiApp
{
    public partial class addExeMan : Form
    {
        private readonly Predicate<string> isAlreadyAdded;

        public string ExePath => exeTb.Text;
        public string LnkPath => lnkTb.Text;

        public addExeMan(Predicate<string> isAlreadyAdded)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            this.isAlreadyAdded = isAlreadyAdded;
        }

        private void addBt_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(exeTb.Text))
            {
                if (isAlreadyAdded(exeTb.Text)) { MessageBox.Show("This aplication is already added"); }
                else
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }
    }
}
