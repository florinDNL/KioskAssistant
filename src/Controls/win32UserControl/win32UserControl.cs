using System;
using System.Windows.Forms;

namespace kioskAssistant.Controls
{
    public partial class win32UserControl : UserControl
    {
        public win32UserControl()
        {
            InitializeComponent();
        }

        private void browseBt_Click(object sender, EventArgs e)
        {
            DialogResult res = exeDialog.ShowDialog();
            if (res == DialogResult.OK)
            {
                exeTb.Text = exeDialog.FileName;
            }
        }
    }
}
