using System;
using System.Windows.Forms;

namespace kioskAssistant.Controls
{
    public partial class slWin32UserControl : UserControl
    {
        public slWin32UserControl()
        {
            InitializeComponent();
        }

        private void browseBt_Click(object sender, EventArgs e)
        {
            DialogResult res = shellDialog.ShowDialog();
            if (res == DialogResult.OK)
            {
                shellTb.Text = shellDialog.FileName;
            }
        }
    }
}
