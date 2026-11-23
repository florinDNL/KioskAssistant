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

			DrawTile(size, column, row);

			var app = allAppsLb.SelectedItem;
			addedAppsLb.Items.Add(app);
			allAppsLb.Items.Remove(app);
			allAppsLb.SelectedIndex = allAppsLb.Items.Count != 0 ? 0 : -1;

			tiles.Add(new Tile(app.ToString(), size, column, row));
		}

		private void DrawTile(TileSize size, int column, int row)
		{
			var (width, height) = size.Cells();
			var bounds = new Rectangle(
				column * TileGrid.CellSizePx,
				row * TileGrid.CellSizePx,
				width * TileGrid.CellSizePx,
				height * TileGrid.CellSizePx);

			using Graphics g = previewPanel.CreateGraphics();
			using Pen pen = new(Color.Black, 2) { Alignment = PenAlignment.Center };
			using SolidBrush brush = new(TileColor);
			g.DrawRectangle(pen, bounds);
			g.FillRectangle(brush, bounds);
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
