using allGlobals;
using System.Windows.Forms;

namespace kioskAssistant.Controls
{
    public partial class slUwpUserControl : UserControl
    {
        public slUwpUserControl()
        {
            InitializeComponent();
            foreach (string app in Globals.allUwpApps.Keys)
            {
                appCb.Items.Add(app);
            }
        }
    }
}
