using kioskAssistant.Model;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace kioskAssistant.Forms
{
    internal sealed class settingsWindow : Form
    {
        private readonly AppSettings settings;
        private readonly CheckBox darkModeCheckBox;
        private readonly CheckBox rememberSizesCheckBox;
        private readonly Button clearSizesButton;
        private readonly Button saveButton;
        private readonly Button cancelButton;

        public settingsWindow(AppSettings settings)
        {
            this.settings = settings;
            Text = "Settings";
            FormBorderStyle = FormBorderStyle.Sizable;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterParent;
            ClientSize = new Size(390, 176);

            var titleLabel = new Label
            {
                AutoSize = true,
                Font = new Font(Font, FontStyle.Bold),
                Location = new Point(16, 16),
                Text = "Appearance and window behavior",
            };

            darkModeCheckBox = new CheckBox
            {
                AutoSize = true,
                Checked = settings.DarkMode,
                Location = new Point(18, 48),
                Text = "Use dark mode (applies next time the app opens)",
            };

            rememberSizesCheckBox = new CheckBox
            {
                AutoSize = true,
                Checked = settings.RememberWindowSizes,
                Location = new Point(18, 76),
                Text = "Remember window sizes for next time",
            };

            clearSizesButton = new Button
            {
                Location = new Point(18, 126),
                Size = new Size(160, 30),
                Text = "Clear saved sizes",
            };
            clearSizesButton.Click += clearSizesButton_Click;

            saveButton = new Button
            {
                DialogResult = DialogResult.OK,
                Location = new Point(200, 126),
                Size = new Size(78, 30),
                Text = "Save",
            };
            saveButton.Click += saveButton_Click;

            cancelButton = new Button
            {
                DialogResult = DialogResult.Cancel,
                Location = new Point(290, 126),
                Size = new Size(78, 30),
                Text = "Cancel",
            };

            AcceptButton = saveButton;
            CancelButton = cancelButton;
            Controls.AddRange(new Control[]
            {
                titleLabel, darkModeCheckBox, rememberSizesCheckBox, clearSizesButton, saveButton, cancelButton,
            });
        }

        private void clearSizesButton_Click(object sender, EventArgs e)
        {
            settings.WindowSizes.Clear();
            try
            {
                AppSettingsStore.Save(settings);
                MessageBox.Show(this, "Saved window sizes have been cleared.", "Settings",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) when (ex is IOException or UnauthorizedAccessException)
            {
                MessageBox.Show(this, $"The saved sizes could not be cleared: {ex.Message}", "Settings error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            settings.DarkMode = darkModeCheckBox.Checked;
            settings.RememberWindowSizes = rememberSizesCheckBox.Checked;
            if (!settings.RememberWindowSizes)
            {
                settings.WindowSizes.Clear();
            }

            try
            {
                AppSettingsStore.Save(settings);
            }
            catch (Exception ex) when (ex is IOException or UnauthorizedAccessException)
            {
                MessageBox.Show(this, $"The settings could not be saved: {ex.Message}", "Settings error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
            }
        }
    }
}
