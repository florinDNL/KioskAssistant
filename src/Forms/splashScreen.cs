using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace kioskAssistant
{
    public partial class splashScreen : Form
    {
        public splashScreen()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            Paint += splashScreen_Paint;
        }

        private void splashScreen_Paint(object sender, PaintEventArgs e)
        {
            const int iconSize = 96;
            int x = (ClientSize.Width - iconSize) / 2;
            int y = 20;
            using Bitmap bitmap = kioskAssistant.UI.AppIcon.CurrentLarge.ToBitmap();
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.DrawImage(bitmap, new Rectangle(x, y, iconSize, iconSize));
        }
    }
}
