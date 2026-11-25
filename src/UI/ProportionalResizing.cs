using kioskAssistant.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace kioskAssistant.UI
{
    internal static class ProportionalResizing
    {
        private static readonly ConditionalWeakTable<Form, FormLayout> Layouts = new();
        private static AppSettings settings;

        public static void Configure(AppSettings settingsToUse)
        {
            settings = settingsToUse ?? throw new ArgumentNullException(nameof(settingsToUse));
        }

        public static void Apply(Form form)
        {
            ArgumentNullException.ThrowIfNull(form);

            if (form.FormBorderStyle == FormBorderStyle.None || Layouts.TryGetValue(form, out _))
            {
                return;
            }

            if (form.FormBorderStyle is FormBorderStyle.Fixed3D or FormBorderStyle.FixedSingle)
            {
                form.FormBorderStyle = FormBorderStyle.Sizable;
                form.MaximizeBox = true;
            }
            else if (form.FormBorderStyle is FormBorderStyle.FixedDialog or FormBorderStyle.FixedToolWindow)
            {
                form.FormBorderStyle = FormBorderStyle.SizableToolWindow;
            }

            var layout = new FormLayout(form.ClientSize);
            Layouts.Add(form, layout);
            form.MinimumSize = form.Size;
            CaptureSubtree(form, layout);
            HookSubtree(form, layout);
            form.Resize += Form_Resize;
            form.FormClosing += Form_FormClosing;
            RestoreWindowSize(form, layout);
        }

        public static void ApplyOpenForms()
        {
            foreach (Form form in Application.OpenForms)
            {
                Apply(form);
            }
        }

        private static void Form_Resize(object sender, EventArgs e)
        {
            var form = (Form)sender;
            FormLayout layout = Layouts.GetValue(form, _ => new FormLayout(form.ClientSize));
            if (layout.Resizing || form.WindowState == FormWindowState.Minimized)
            {
                return;
            }

            layout.Resizing = true;
            form.SuspendLayout();
            try
            {
                ResizeSubtree(form, form.ClientSize, layout);
            }
            finally
            {
                form.ResumeLayout(performLayout: true);
                layout.Resizing = false;
            }
        }

        private static void RestoreWindowSize(Form form, FormLayout layout)
        {
            if (settings?.RememberWindowSizes != true ||
                !settings.WindowSizes.TryGetValue(form.GetType().FullName ?? form.Name, out SavedWindowSize savedSize))
            {
                return;
            }

            Size restoredSize = savedSize.ToSize();
            if (restoredSize.Width < form.MinimumSize.Width || restoredSize.Height < form.MinimumSize.Height)
            {
                restoredSize = new Size(
                    Math.Max(restoredSize.Width, form.MinimumSize.Width),
                    Math.Max(restoredSize.Height, form.MinimumSize.Height));
            }

            layout.Resizing = true;
            try
            {
                form.Size = restoredSize;
                ResizeSubtree(form, form.ClientSize, layout);
            }
            finally
            {
                layout.Resizing = false;
            }

            if (form.Visible && form.StartPosition == FormStartPosition.CenterScreen)
            {
                Rectangle screen = Screen.FromControl(form).WorkingArea;
                form.Location = new Point(
                    screen.Left + (screen.Width - form.Width) / 2,
                    screen.Top + (screen.Height - form.Height) / 2);
            }
        }

        private static void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (settings?.RememberWindowSizes != true)
            {
                return;
            }

            var form = (Form)sender;
            Size sizeToSave = form.WindowState == FormWindowState.Maximized ? form.RestoreBounds.Size : form.Size;
            settings.WindowSizes[form.GetType().FullName ?? form.Name] = SavedWindowSize.From(sizeToSave);

            try
            {
                AppSettingsStore.Save(settings);
            }
            catch (Exception ex) when (ex is IOException or UnauthorizedAccessException)
            {
                MessageBox.Show(form, $"The window size could not be saved: {ex.Message}", "Settings error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void Control_ControlAdded(object sender, ControlEventArgs e)
        {
            var control = (Control)sender;
            Form form = control.FindForm();
            if (form != null && Layouts.TryGetValue(form, out FormLayout layout) && !layout.Resizing)
            {
                CaptureSubtree(e.Control, layout);
                HookSubtree(e.Control, layout);
                ResizeSubtree(form, form.ClientSize, layout);
            }
        }

        private static void CaptureSubtree(Control control, FormLayout layout)
        {
            if (control is not Form)
            {
                layout.Capture(control);
            }

            foreach (Control child in control.Controls)
            {
                CaptureSubtree(child, layout);
            }
        }

        private static void HookSubtree(Control control, FormLayout layout)
        {
            if (layout.Hooked.Add(control))
            {
                control.ControlAdded += Control_ControlAdded;
            }

            foreach (Control child in control.Controls)
            {
                HookSubtree(child, layout);
            }
        }

        private static void ResizeSubtree(Control container, Size targetClientSize, FormLayout layout)
        {
            Size originalClientSize = container is Form
                ? layout.OriginalClientSize
                : layout.Controls.TryGetValue(container, out ControlLayout containerLayout)
                    ? containerLayout.ClientSize
                    : container.ClientSize;

            float scaleX = Scale(originalClientSize.Width, targetClientSize.Width);
            float scaleY = Scale(originalClientSize.Height, targetClientSize.Height);

            foreach (Control control in container.Controls)
            {
                if (!layout.Controls.TryGetValue(control, out ControlLayout controlLayout))
                {
                    continue;
                }

                control.Bounds = controlLayout.UsesCornerAnchor
                    ? ScaleAnchored(controlLayout, targetClientSize)
                    : Scale(controlLayout.Bounds, scaleX, scaleY);
                ScaleSpecializedControl(control, controlLayout, scaleY);

                ResizeSubtree(control, control.ClientSize, layout);
            }
        }

        private static float Scale(int original, int current) => original == 0 ? 1 : (float)current / original;

        private static Rectangle Scale(Rectangle bounds, float scaleX, float scaleY) => new(
            Math.Max(0, (int)Math.Round(bounds.X * scaleX)),
            Math.Max(0, (int)Math.Round(bounds.Y * scaleY)),
            Math.Max(1, (int)Math.Round(bounds.Width * scaleX)),
            Math.Max(1, (int)Math.Round(bounds.Height * scaleY)));

        private static Rectangle ScaleAnchored(ControlLayout layout, Size targetClientSize)
        {
            int x = layout.Anchor.HasFlag(AnchorStyles.Right)
                ? targetClientSize.Width - layout.RightMargin - layout.Bounds.Width
                : layout.Bounds.X;
            int y = layout.Anchor.HasFlag(AnchorStyles.Bottom)
                ? targetClientSize.Height - layout.BottomMargin - layout.Bounds.Height
                : layout.Bounds.Y;
            return new Rectangle(x, y, layout.Bounds.Width, layout.Bounds.Height);
        }

        private static void ScaleSpecializedControl(Control control, ControlLayout layout, float scaleY)
        {
            switch (control)
            {
                case ListBox listBox:
                    listBox.ItemHeight = Math.Max(14, (int)Math.Round(layout.ItemHeight * scaleY));
                    break;
                case ComboBox comboBox:
                    comboBox.ItemHeight = Math.Max(14, (int)Math.Round(layout.ItemHeight * scaleY));
                    break;
                case DataGridView grid:
                    grid.ColumnHeadersHeight = Math.Max(20, (int)Math.Round(layout.ColumnHeadersHeight * scaleY));
                    grid.RowTemplate.Height = Math.Max(20, (int)Math.Round(layout.RowTemplateHeight * scaleY));
                    foreach (DataGridViewRow row in grid.Rows)
                    {
                        row.Height = grid.RowTemplate.Height;
                    }
                    foreach (KeyValuePair<DataGridViewColumn, int> columnWidth in layout.ColumnWidths)
                    {
                        if (columnWidth.Key.AutoSizeMode is DataGridViewAutoSizeColumnMode.NotSet or DataGridViewAutoSizeColumnMode.None)
                        {
                            columnWidth.Key.Width = Math.Max(30, (int)Math.Round(columnWidth.Value * GetScaleX(grid, layout)));
                        }
                    }
                    break;
            }
        }

        private static float GetScaleX(Control control, ControlLayout layout) =>
            layout.Bounds.Width == 0 ? 1 : (float)control.Width / layout.Bounds.Width;

        private sealed class FormLayout
        {
            public FormLayout(Size originalClientSize)
            {
                OriginalClientSize = originalClientSize;
            }

            public Size OriginalClientSize { get; }
            public Dictionary<Control, ControlLayout> Controls { get; } = new();
            public HashSet<Control> Hooked { get; } = new();
            public bool Resizing { get; set; }

            public void Capture(Control control)
            {
                if (!Controls.ContainsKey(control))
                {
                    Controls.Add(control, new ControlLayout(control));
                }
            }
        }

        private sealed class ControlLayout
        {
            public ControlLayout(Control control)
            {
                Bounds = control.Bounds;
                ClientSize = control.ClientSize;
                Anchor = control.Anchor;
                RightMargin = (control.Parent?.ClientSize.Width ?? control.Bounds.Right) - control.Bounds.Right;
                BottomMargin = (control.Parent?.ClientSize.Height ?? control.Bounds.Bottom) - control.Bounds.Bottom;
                UsesCornerAnchor = Anchor.HasFlag(AnchorStyles.Right) || Anchor.HasFlag(AnchorStyles.Bottom);
                ItemHeight = control is ListBox listBox
                    ? listBox.ItemHeight
                    : control is ComboBox comboBox
                        ? comboBox.ItemHeight
                        : 0;

                if (control is DataGridView grid)
                {
                    ColumnHeadersHeight = grid.ColumnHeadersHeight;
                    RowTemplateHeight = grid.RowTemplate.Height;
                    foreach (DataGridViewColumn column in grid.Columns)
                    {
                        ColumnWidths.Add(column, column.Width);
                    }
                }
            }

            public Rectangle Bounds { get; }
            public Size ClientSize { get; }
            public AnchorStyles Anchor { get; }
            public int RightMargin { get; }
            public int BottomMargin { get; }
            public bool UsesCornerAnchor { get; }
            public int ItemHeight { get; }
            public int ColumnHeadersHeight { get; }
            public int RowTemplateHeight { get; }
            public Dictionary<DataGridViewColumn, int> ColumnWidths { get; } = new();
        }
    }
}
