using System.Windows.Forms;

namespace kioskAssistant.Controls
{
    public partial class EdgeUserControl : UserControl
    {
        public EdgeUserControl()
        {
            InitializeComponent();
            browsingCb.SelectedIndex = 1;
            idleTb.Text = "0";
        }
    }
}
