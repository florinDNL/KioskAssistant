using allGlobals;
using System.Windows.Forms;

namespace kioskAssistant.Controls
{
    public partial class UwpUserControl : UserControl
    {
        public UwpUserControl()
        {
            InitializeComponent();
            foreach (string app in Globals.allUwpApps.Keys)
            {
                appCb.Items.Add(app);
            }

        }
    }
}
