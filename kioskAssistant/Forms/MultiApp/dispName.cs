using System;
using System.Windows.Forms;

namespace kioskAssistant
{
    public partial class dispName : Form
    {
        public dispName()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void okBt_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
