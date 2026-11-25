using System;
using System.ComponentModel;
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

            var licenseButton = new Button
            {
                Location = new Point(236, 180),
                Size = new Size(78, 28),
                Text = "License",
            };
            licenseButton.Click += licenseButton_Click;

            var closeButton = new Button
            {
                DialogResult = DialogResult.OK,
                Location = new Point(326, 180),
                Size = new Size(78, 28),
                Text = "Close",
            };

            AcceptButton = closeButton;
            CancelButton = closeButton;
            Controls.AddRange(new Control[] { logo, description, repositoryLink, licenseButton, closeButton });
        }

        private void licenseButton_Click(object sender, EventArgs e)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            using Stream stream = assembly.GetManifestResourceStream("kioskAssistant.License");
            if (stream == null)
            {
                MessageBox.Show(this, "The license could not be loaded from the application.", "License",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using var reader = new StreamReader(stream);
            using var licenseWindow = new Form
            {
                Text = "License",
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                ShowInTaskbar = false,
                StartPosition = FormStartPosition.CenterParent,
                ClientSize = new Size(580, 420),
                Icon = Icon,
            };
            var textBox = new TextBox
            {
                Dock = DockStyle.Fill,
                Multiline = true,
                ReadOnly = true,
                ScrollBars = ScrollBars.Vertical,
                Text = reader.ReadToEnd(),
                TabStop = false,
            };
            licenseWindow.Controls.Add(textBox);
            licenseWindow.Shown += (_, _) => textBox.DeselectAll();
            licenseWindow.ShowDialog(this);
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
