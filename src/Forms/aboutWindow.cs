using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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
            ClientSize = new Size(591, 509);
            Icon = appIcon;

            var appIconPicture = new PictureBox
            {
                Image = kioskAssistant.UI.AppIcon.CurrentLarge.ToBitmap(),
                Location = new Point(247, 16),
                Size = new Size(96, 96),
                SizeMode = PictureBoxSizeMode.Zoom,
            };

            string version = Assembly.GetExecutingAssembly().GetName().Version?.ToString(3) ?? "Unknown";
            var description = new Label
            {
                Location = new Point(16, 124),
                Size = new Size(559, 40),
                TextAlign = ContentAlignment.MiddleCenter,
                Text = $"Kiosk Assistant\nVersion {version}",
            };

            var repositoryLink = new LinkLabel
            {
                Location = new Point(16, 177),
                Size = new Size(559, 20),
                TextAlign = ContentAlignment.MiddleCenter,
                Text = RepositoryUrl,
            };
            repositoryLink.Click += repositoryLink_Click;

            var licenseTextBox = new TextBox
            {
                Location = new Point(16, 210),
                Size = new Size(559, 249),
                Multiline = true,
                ReadOnly = true,
                ScrollBars = ScrollBars.Vertical,
                TabStop = false,
                Text = LoadLicense(),
            };

            var closeButton = new Button
            {
                DialogResult = DialogResult.OK,
                Location = new Point(497, 471),
                Size = new Size(78, 28),
                Text = "Close",
            };

            AcceptButton = closeButton;
            CancelButton = closeButton;
            Controls.AddRange(new Control[] { appIconPicture, description, repositoryLink, licenseTextBox, closeButton });
            Shown += (_, _) => licenseTextBox.DeselectAll();
        }

        private static string LoadLicense()
        {
            using Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("kioskAssistant.License");
            if (stream == null)
            {
                return "The license could not be loaded from the application.";
            }

            using var reader = new StreamReader(stream);
            return reader.ReadToEnd();
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
