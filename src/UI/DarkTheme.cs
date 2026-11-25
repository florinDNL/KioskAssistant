using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace kioskAssistant.UI
{
    internal static class DarkTheme
    {
        private static readonly Color Background = Color.FromArgb(24, 24, 27);
        private static readonly Color Surface = Color.FromArgb(39, 39, 42);
        private static readonly Color AlternateSurface = Color.FromArgb(31, 31, 34);
        private static readonly Color ElevatedSurface = Color.FromArgb(52, 52, 56);
        private static readonly Color Border = Color.FromArgb(74, 74, 82);
        private static readonly Color Foreground = Color.FromArgb(245, 245, 245);
        private static readonly Color MutedForeground = Color.FromArgb(178, 178, 186);
        private static readonly Color Accent = Color.FromArgb(55, 125, 255);
        private static readonly ConditionalWeakTable<Form, object> AppliedForms = new();

        public static void Apply(Form form)
        {
            ArgumentNullException.ThrowIfNull(form);
            if (!AppliedForms.TryAdd(form, new object()))
            {
                return;
            }

            form.BackColor = Background;
            form.ForeColor = Foreground;
            form.HandleCreated += Form_HandleCreated;
            form.ControlAdded += Form_ControlAdded;
            ApplyControlTree(form);

            if (form.IsHandleCreated)
            {
                ApplyNativeDarkMode(form);
            }
        }

        public static void ApplyOpenForms()
        {
            foreach (Form form in Application.OpenForms)
            {
                Apply(form);
            }
        }

        private static void Form_HandleCreated(object sender, EventArgs e) => ApplyNativeDarkMode((Control)sender);

        private static void Form_ControlAdded(object sender, ControlEventArgs e) => ApplyControlTree(e.Control);

        private static void Control_ControlAdded(object sender, ControlEventArgs e) => ApplyControlTree(e.Control);

        private static void Control_HandleCreated(object sender, EventArgs e) => ApplyNativeDarkMode((Control)sender);

        private static void ApplyControlTree(Control control)
        {
            ApplyControl(control);
            control.ControlAdded += Control_ControlAdded;
            control.HandleCreated += Control_HandleCreated;

            if (control.IsHandleCreated)
            {
                ApplyNativeDarkMode(control);
            }

            foreach (Control child in control.Controls)
            {
                ApplyControlTree(child);
            }
        }

        private static void ApplyControl(Control control)
        {
            Color originalForeground = control.ForeColor;
            control.BackColor = control is Form or Panel or GroupBox or TabPage or UserControl or Label
                ? Background
                : Surface;
            control.ForeColor = originalForeground == Color.Red
                ? Color.FromArgb(255, 105, 105)
                : Foreground;

            if (control is Form { FormBorderStyle: FormBorderStyle.None } borderlessForm)
            {
                DarkenSplashBackground(borderlessForm);
            }

            switch (control)
            {
                case Button button:
                    button.UseVisualStyleBackColor = false;
                    button.BackColor = ElevatedSurface;
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderColor = Border;
                    button.FlatAppearance.BorderSize = 0;
                    button.FlatAppearance.MouseDownBackColor = Color.FromArgb(34, 96, 210);
                    button.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 64, 70);
                    button.Paint -= Button_Paint;
                    button.Paint += Button_Paint;
                    button.SizeChanged -= Button_SizeChanged;
                    button.SizeChanged += Button_SizeChanged;
                    SetRoundedButtonRegion(button);
                    break;
                case ProgressBar progressBar:
                    progressBar.BackColor = Surface;
                    progressBar.ForeColor = Accent;
                    break;
                case CheckBox checkBox:
                    checkBox.BackColor = Background;
                    checkBox.FlatStyle = FlatStyle.Standard;
                    break;
                case RadioButton radioButton:
                    radioButton.BackColor = Background;
                    radioButton.FlatStyle = FlatStyle.Standard;
                    break;
                case ComboBox comboBox:
                    comboBox.BackColor = Surface;
                    comboBox.FlatStyle = FlatStyle.Flat;
                    comboBox.DrawMode = DrawMode.OwnerDrawFixed;
                    comboBox.DrawItem -= ComboBox_DrawItem;
                    comboBox.DrawItem += ComboBox_DrawItem;
                    break;
                case CheckedListBox checkedList:
                    checkedList.BackColor = Surface;
                    checkedList.DrawMode = DrawMode.OwnerDrawFixed;
                    checkedList.DrawItem -= CheckedListBox_DrawItem;
                    checkedList.DrawItem += CheckedListBox_DrawItem;
                    break;
                case ListBox listBox:
                    listBox.BackColor = Surface;
                    listBox.DrawMode = DrawMode.OwnerDrawFixed;
                    listBox.DrawItem -= ListBox_DrawItem;
                    listBox.DrawItem += ListBox_DrawItem;
                    break;
                case DataGridView grid:
                    ApplyGrid(grid);
                    break;
                case ListView listView:
                    listView.BackColor = Surface;
                    listView.ForeColor = Foreground;
                    listView.OwnerDraw = listView.View == View.Details;
                    listView.DrawColumnHeader -= ListView_DrawColumnHeader;
                    listView.DrawItem -= ListView_DrawItem;
                    listView.DrawSubItem -= ListView_DrawSubItem;
                    listView.DrawColumnHeader += ListView_DrawColumnHeader;
                    listView.DrawItem += ListView_DrawItem;
                    listView.DrawSubItem += ListView_DrawSubItem;
                    foreach (ListViewItem item in listView.Items)
                    {
                        item.BackColor = Surface;
                        item.ForeColor = Foreground;
                    }
                    break;
                case TreeView treeView:
                    treeView.BackColor = Surface;
                    treeView.LineColor = Border;
                    break;
                case NumericUpDown numeric:
                    numeric.BackColor = Surface;
                    break;
                case TextBoxBase textBox:
                    textBox.BackColor = Surface;
                    textBox.ForeColor = Foreground;
                    break;
                case TabControl tab:
                    tab.BackColor = Background;
                    foreach (TabPage page in tab.TabPages)
                    {
                        page.BackColor = Background;
                        page.ForeColor = Foreground;
                    }
                    break;
                case LinkLabel link:
                    link.LinkColor = Color.FromArgb(86, 170, 255);
                    link.ActiveLinkColor = Color.FromArgb(135, 196, 255);
                    link.VisitedLinkColor = Color.FromArgb(196, 143, 255);
                    break;
                case ToolStrip toolStrip:
                    toolStrip.BackColor = Surface;
                    foreach (ToolStripItem item in toolStrip.Items)
                    {
                        item.BackColor = Surface;
                        item.ForeColor = Foreground;
                    }
                    break;
                case PictureBox:
                    control.BackColor = Background;
                    break;
            }

            if (HasVisibleBorder(control))
            {
                control.Paint -= Control_PaintBorder;
                control.Paint += Control_PaintBorder;
            }
        }

        private static void Button_SizeChanged(object sender, EventArgs e) => SetRoundedButtonRegion((Button)sender);

        private static void SetRoundedButtonRegion(Button button)
        {
            if (button.Width <= 2 || button.Height <= 2)
            {
                return;
            }

            int radius = Math.Min(7, Math.Max(3, button.Height / 4));
            using GraphicsPath path = RoundedRectangle(button.ClientRectangle, radius);
            Region previousRegion = button.Region;
            button.Region = new Region(path);
            previousRegion?.Dispose();
        }

        private static void Button_Paint(object sender, PaintEventArgs e)
        {
            var button = (Button)sender;
            bool hovered = button.ClientRectangle.Contains(button.PointToClient(Cursor.Position));
            bool pressed = hovered && (Control.MouseButtons & MouseButtons.Left) != 0;
            Color background = pressed
                ? button.FlatAppearance.MouseDownBackColor
                : hovered
                    ? button.FlatAppearance.MouseOverBackColor
                    : button.BackColor;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using var canvasBrush = new SolidBrush(button.Parent?.BackColor ?? Background);
            e.Graphics.FillRectangle(canvasBrush, button.ClientRectangle);
            Rectangle surface = Rectangle.Inflate(button.ClientRectangle, -1, -1);
            using GraphicsPath path = RoundedRectangle(surface, Math.Min(7, Math.Max(3, surface.Height / 4)));
            using var backgroundBrush = new SolidBrush(background);
            using var border = new Pen(Border);
            e.Graphics.FillPath(backgroundBrush, path);
            e.Graphics.DrawPath(border, path);

            Rectangle textBounds = Rectangle.Inflate(button.ClientRectangle, -5, -2);
            const TextFormatFlags flags = TextFormatFlags.HorizontalCenter |
                                          TextFormatFlags.VerticalCenter |
                                          TextFormatFlags.WordBreak |
                                          TextFormatFlags.NoPrefix |
                                          TextFormatFlags.EndEllipsis;
            Font textFont = button.Font;
            bool ownsFont = false;
            while (textFont.Size > 8f)
            {
                Size required = TextRenderer.MeasureText(button.Text, textFont, textBounds.Size, flags);
                if (required.Width <= textBounds.Width && required.Height <= textBounds.Height)
                {
                    break;
                }

                if (ownsFont)
                {
                    textFont.Dispose();
                }
                textFont = new Font(button.Font.FontFamily, textFont.Size - 0.5f, button.Font.Style, button.Font.Unit);
                ownsFont = true;
            }

            TextRenderer.DrawText(e.Graphics, button.Text, textFont, textBounds,
                button.Enabled ? Foreground : MutedForeground, flags);
            if (ownsFont)
            {
                textFont.Dispose();
            }
        }

        private static void DarkenSplashBackground(Form form)
        {
            if (form.BackgroundImage is not Image original)
            {
                return;
            }

            var darkened = new Bitmap(original.Width, original.Height);
            using (var source = new Bitmap(original))
            {
                for (int y = 0; y < source.Height; y++)
                {
                    for (int x = 0; x < source.Width; x++)
                    {
                        Color pixel = source.GetPixel(x, y);
                        Color replacement = Math.Min(pixel.R, Math.Min(pixel.G, pixel.B)) >= 220
                            ? Color.FromArgb(pixel.A, Background)
                            : pixel;
                        darkened.SetPixel(x, y, replacement);
                    }
                }
            }

            form.BackgroundImage = darkened;
        }

        private static bool HasVisibleBorder(Control control) => control switch
        {
            ListBox listBox => listBox.BorderStyle != BorderStyle.None,
            ListView listView => listView.BorderStyle != BorderStyle.None,
            TextBoxBase textBox => textBox.BorderStyle != BorderStyle.None,
            Panel panel => panel.BorderStyle != BorderStyle.None,
            _ => false,
        };

        private static void Control_PaintBorder(object sender, PaintEventArgs e)
        {
            var control = (Control)sender;
            if (control.Width < 2 || control.Height < 2)
            {
                return;
            }

            Rectangle border = new(1, 1, control.Width - 2, control.Height - 2);
            using var pen = new Pen(Border, 2);
            e.Graphics.DrawRectangle(pen, border);
        }

        private static void ListView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using var canvas = new SolidBrush(Surface);
            e.Graphics.FillRectangle(canvas, e.Bounds);
            Rectangle surface = Rectangle.Inflate(e.Bounds, -1, -1);
            using GraphicsPath path = RoundedRectangle(surface, 5);
            using var background = new SolidBrush(ElevatedSurface);
            using var separator = new Pen(Border);
            e.Graphics.FillPath(background, path);
            e.Graphics.DrawPath(separator, path);
            TextRenderer.DrawText(
                e.Graphics,
                e.Header.Text,
                e.Font,
                Rectangle.Inflate(e.Bounds, -5, 0),
                Foreground,
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
        }

        private static void ListView_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
        }

        private static void ListView_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            bool selected = e.Item.Selected;
            Color backColor = selected ? Accent : e.ItemIndex % 2 == 0 ? Surface : AlternateSurface;
            using var background = new SolidBrush(backColor);
            using var gridLine = new Pen(Border);
            e.Graphics.FillRectangle(background, e.Bounds);
            e.Graphics.DrawRectangle(gridLine, e.Bounds);
            TextRenderer.DrawText(
                e.Graphics,
                e.SubItem.Text,
                e.Item.Font,
                Rectangle.Inflate(e.Bounds, -5, 0),
                Foreground,
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
        }

        private static void ApplyGrid(DataGridView grid)
        {
            grid.EnableHeadersVisualStyles = false;
            grid.BackgroundColor = Background;
            grid.BorderStyle = BorderStyle.None;
            grid.GridColor = Border;
            grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            grid.ColumnHeadersDefaultCellStyle.BackColor = ElevatedSurface;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Foreground;
            grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = ElevatedSurface;
            grid.ColumnHeadersDefaultCellStyle.SelectionForeColor = Foreground;
            grid.RowHeadersDefaultCellStyle.BackColor = ElevatedSurface;
            grid.RowHeadersDefaultCellStyle.ForeColor = MutedForeground;
            ApplyCellStyle(grid.DefaultCellStyle, Background);
            ApplyCellStyle(grid.RowsDefaultCellStyle, Background);
            ApplyCellStyle(grid.AlternatingRowsDefaultCellStyle, AlternateSurface);

            foreach (DataGridViewColumn column in grid.Columns)
            {
                ApplyCellStyle(column.DefaultCellStyle, Background);
            }

            foreach (DataGridViewRow row in grid.Rows)
            {
                ApplyGridRow(row);
            }

            grid.RowsAdded -= Grid_RowsAdded;
            grid.RowsAdded += Grid_RowsAdded;
            grid.CellPainting -= Grid_CellPainting;
            grid.CellPainting += Grid_CellPainting;
        }

        private static void Grid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex != -1 || e.ColumnIndex < 0)
            {
                return;
            }

            DataGridView grid = (DataGridView)sender;
            using var background = new SolidBrush(ElevatedSurface);
            e.Graphics.FillRectangle(background, e.CellBounds);
            if (e.ColumnIndex < grid.ColumnCount - 1)
            {
                using var separator = new Pen(Border);
                e.Graphics.DrawLine(separator, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom);
            }

            TextRenderer.DrawText(
                e.Graphics,
                e.FormattedValue?.ToString(),
                e.CellStyle.Font,
                Rectangle.Inflate(e.CellBounds, -5, 0),
                Foreground,
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
            e.Handled = true;
        }

        private static GraphicsPath RoundedRectangle(Rectangle bounds, int radius)
        {
            int diameter = Math.Min(radius * 2, Math.Min(bounds.Width, bounds.Height));
            var path = new GraphicsPath();
            if (diameter <= 0)
            {
                path.AddRectangle(bounds);
                return path;
            }

            Rectangle arc = new(bounds.Left, bounds.Top, diameter, diameter);
            path.AddArc(arc, 180, 90);
            arc.X = bounds.Right - diameter;
            path.AddArc(arc, 270, 90);
            arc.Y = bounds.Bottom - diameter;
            path.AddArc(arc, 0, 90);
            arc.X = bounds.Left;
            path.AddArc(arc, 90, 90);
            path.CloseFigure();
            return path;
        }

        private static void ApplyCellStyle(DataGridViewCellStyle style, Color backColor)
        {
            style.BackColor = backColor;
            style.ForeColor = Foreground;
            style.SelectionBackColor = Accent;
            style.SelectionForeColor = Color.White;
        }

        private static void Grid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            var grid = (DataGridView)sender;
            for (int index = e.RowIndex; index < e.RowIndex + e.RowCount && index < grid.Rows.Count; index++)
            {
                ApplyGridRow(grid.Rows[index]);
            }
        }

        private static void ApplyGridRow(DataGridViewRow row)
        {
            Color backColor = row.Index % 2 == 0 ? Background : AlternateSurface;
            ApplyCellStyle(row.DefaultCellStyle, backColor);
            foreach (DataGridViewCell cell in row.Cells)
            {
                ApplyCellStyle(cell.Style, backColor);
            }
        }

        private static void ListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            var listBox = (ListBox)sender;
            DrawListItem(e, listBox.Items[e.Index], e.Index, null);
        }

        private static void CheckedListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            var listBox = (CheckedListBox)sender;
            DrawListItem(e, listBox.Items[e.Index], e.Index, listBox.GetItemChecked(e.Index));
        }

        private static void ComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
            {
                return;
            }

            var comboBox = (ComboBox)sender;
            DrawListItem(e, comboBox.Items[e.Index], e.Index, null);
        }

        private static void DrawListItem(DrawItemEventArgs e, object item, int index, bool? isChecked)
        {
            bool selected = (e.State & DrawItemState.Selected) != 0;
            Color backColor = selected ? Accent : index % 2 == 0 ? Surface : AlternateSurface;
            using var backgroundBrush = new SolidBrush(backColor);
            e.Graphics.FillRectangle(backgroundBrush, e.Bounds);

            int textOffset = 7;
            if (isChecked.HasValue)
            {
                int boxSize = Math.Min(14, Math.Max(10, e.Bounds.Height - 4));
                Rectangle box = new(e.Bounds.Left + 6, e.Bounds.Top + (e.Bounds.Height - boxSize) / 2, boxSize, boxSize);
                using var boxBrush = new SolidBrush(isChecked.Value ? Accent : ElevatedSurface);
                using var borderPen = new Pen(isChecked.Value ? Accent : MutedForeground);
                e.Graphics.FillRectangle(boxBrush, box);
                e.Graphics.DrawRectangle(borderPen, box);

                if (isChecked.Value)
                {
                    using var checkPen = new Pen(Color.White, 1.7f);
                    e.Graphics.DrawLines(checkPen, new[]
                    {
                        new Point(box.Left + boxSize / 4, box.Top + boxSize / 2),
                        new Point(box.Left + boxSize / 2 - 1, box.Bottom - boxSize / 4),
                        new Point(box.Right - boxSize / 4, box.Top + boxSize / 4),
                    });
                }

                textOffset = box.Right - e.Bounds.Left + 7;
            }

            Rectangle textBounds = new(
                e.Bounds.Left + textOffset,
                e.Bounds.Top,
                Math.Max(0, e.Bounds.Width - textOffset),
                e.Bounds.Height);
            TextRenderer.DrawText(
                e.Graphics,
                item?.ToString(),
                e.Font,
                textBounds,
                Foreground,
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
        }

        private static void ApplyNativeDarkMode(Control control)
        {
            if (!control.IsHandleCreated)
            {
                return;
            }

            _ = SetWindowTheme(control.Handle, "DarkMode_Explorer", null);
            if (control is Form form)
            {
                int enabled = 1;
                _ = DwmSetWindowAttribute(form.Handle, 20, ref enabled, sizeof(int));
                _ = DwmSetWindowAttribute(form.Handle, 19, ref enabled, sizeof(int));
            }
        }

        [DllImport("dwmapi.dll", PreserveSig = true)]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attribute, ref int value, int size);

        [DllImport("uxtheme.dll", CharSet = CharSet.Unicode, PreserveSig = true)]
        private static extern int SetWindowTheme(IntPtr hwnd, string themeName, string colorScheme);
    }
}
