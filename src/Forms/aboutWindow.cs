using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace kioskAssistant.Forms
{
    internal sealed class aboutWindow : Form
    {
        private const string RepositoryUrl = "https://github.com/florinDNL/KioskAssistant";

        public aboutWindow(Icon appIcon)
        {
            ArgumentNullException.ThrowIfNull(appIcon);

            Text = "About Kiosk Assistant";
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            ClientSize = new Size(420, 220);
            Icon = appIcon;

            var resources = new ComponentResourceManager(typeof(multiApp));
            var logo = new PictureBox
            {
                Image = (Image)resources.GetObject("logoBox.Image"),
                Location = new Point(16, 16),
                Size = new Size(388, 64),
                SizeMode = PictureBoxSizeMode.Zoom,
            };

            string version = Assembly.GetExecutingAssembly().GetName().Version?.ToString(3) ?? "Unknown";
            var description = new Label
            {
                AutoSize = true,
                Location = new Point(16, 92),
                Text = $"Kiosk Assistant\nVersion {version}",
            };

            var repositoryLink = new LinkLabel
            {
                AutoSize = true,
                Location = new Point(16, 145),
                Text = RepositoryUrl,
            };
            repositoryLink.Click += repositoryLink_Click;

            var closeButton = new Button
            {
                DialogResult = DialogResult.OK,
                Location = new Point(326, 180),
                Size = new Size(78, 28),
                Text = "Close",
            };

            AcceptButton = closeButton;
            CancelButton = closeButton;
            Controls.AddRange(new Control[] { logo, description, repositoryLink, closeButton });
        }

        private static void repositoryLink_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = RepositoryUrl,
                UseShellExecute = true,
            });
        }
    }
}
