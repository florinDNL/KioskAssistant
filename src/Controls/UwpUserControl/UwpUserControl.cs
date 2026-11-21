using kioskAssistant.Model;
using System.Windows.Forms;

namespace kioskAssistant.Controls
{
    public partial class UwpUserControl : UserControl
    {
        public UwpUserControl(AppCatalog catalog)
        {
            InitializeComponent();
            foreach (string app in catalog.UwpApps.Keys)
            {
                appCb.Items.Add(app);
            }

        }
    }
}
