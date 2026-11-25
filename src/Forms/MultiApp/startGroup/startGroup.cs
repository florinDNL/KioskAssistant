using kioskAssistant.Model;
using kioskAssistant.Services;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;


namespace kioskAssistant
{
	public partial class startGroup : Form
	{
		private static readonly Color TileColor = Color.FromArgb(0, 191, 255);

		private readonly ICollection<string> existingGroupNames;
		private readonly TileGrid grid = new();
		private readonly List<Tile> tiles = new();

		/// <summary>The configured group; valid once the dialog returns OK.</summary>
		public StartGroup Group => new(nameTb.Text, tiles);

		public startGroup(IEnumerable<object> availableApps, ICollection<string> existingGroupNames)
		{
			InitializeComponent();
			StartPosition = FormStartPosition.CenterScreen;
			previewPanel.Paint += previewPanel_Paint;
			sizeCombo.SelectedIndex = 1;
			this.existingGroupNames = existingGroupNames;

			foreach (var app in availableApps)
			{
				allAppsLb.Items.Add(app);
			}
		}

		private void addBt_Click(object sender, System.EventArgs e)
		{
			if (allAppsLb.SelectedIndex == -1)
			{
				MessageBox.Show("Please select an application to add");
				return;
			}

			int column = decimal.ToInt32(colNud.Value);
			int row = decimal.ToInt32(rowNud.Value);
			TileSize size = TileSizeExtensions.ParseTileSize(sizeCombo.SelectedItem.ToString());

			switch (grid.TryPlace(size, column, row))
			{
				case TilePlacement.OutOfBounds:
					MessageBox.Show("Out of bounds.");
					return;
				case TilePlacement.Occupied:
					MessageBox.Show("Space is occupied by another tile.");
					return;
			}

			var app = allAppsLb.SelectedItem;
			addedAppsLb.Items.Add(app);
			allAppsLb.Items.Remove(app);
			allAppsLb.SelectedIndex = allAppsLb.Items.Count != 0 ? 0 : -1;

			tiles.Add(new Tile(app.ToString(), size, column, row));
			previewPanel.Invalidate();
		}

		private void previewPanel_Paint(object sender, PaintEventArgs e)
		{
			float scaleX = (float)previewPanel.ClientSize.Width / (TileGrid.Columns * TileGrid.CellSizePx);
			float scaleY = (float)previewPanel.ClientSize.Height / (TileGrid.Rows * TileGrid.CellSizePx);
			using Pen pen = new(Color.Black, 2) { Alignment = PenAlignment.Center };
			using SolidBrush brush = new(TileColor);

			foreach (Tile tile in tiles)
			{
				var (width, height) = tile.Size.Cells();
				var bounds = Rectangle.Round(new RectangleF(
					tile.Column * TileGrid.CellSizePx * scaleX,
					tile.Row * TileGrid.CellSizePx * scaleY,
					width * TileGrid.CellSizePx * scaleX,
					height * TileGrid.CellSizePx * scaleY));
				e.Graphics.FillRectangle(brush, bounds);
				e.Graphics.DrawRectangle(pen, bounds);
			}
		}

		private void clearBt_Click(object sender, System.EventArgs e)
		{
			foreach (var item in addedAppsLb.Items)
			{
				allAppsLb.Items.Add(item);
			}
			addedAppsLb.Items.Clear();
			tiles.Clear();
			grid.Clear();
			previewPanel.Invalidate();
		}

		private void finishBt_Click(object sender, System.EventArgs e)
		{
			if (addedAppsLb.Items.Count > 0)
			{
				if (existingGroupNames.Contains(nameTb.Text))
				{
					MessageBox.Show("This Group Name already exists.", "Duplicate Group");
				}
				else
				{
					this.DialogResult = DialogResult.OK;
					this.Close();
				}
			}
			else
			{
				MessageBox.Show("No modifications made");
			}
		}

		public IEnumerable<object> AddedApps => addedAppsLb.Items.Cast<object>();
	}
}
