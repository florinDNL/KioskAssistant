using allGlobals;
using System.Windows.Forms;
using kioskAssistant.Controls;

namespace kioskAssistant
{
    public partial class kioskModeApp : Form
    {
        public kioskModeApp()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            guidLabel.Text = Globals.GetGUID();                      
        }

        private void appTypeCb_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            kModePanel.Controls.Clear();

            if (appTypeCb.SelectedIndex == 0)
            {
                EdgeUserControl EdgeControl = new();
                kModePanel.Controls.Add(EdgeControl);
            }
            else if (appTypeCb.SelectedIndex == 1)
            {
                UwpUserControl UwpControl = new();
                kModePanel.Controls.Add(UwpControl);
            }
            else if (appTypeCb.SelectedIndex == 2)
            {
                win32UserControl win32Control = new();
                kModePanel.Controls.Add(win32Control);
            }
        }
    }
}
