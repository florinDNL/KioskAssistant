#nullable enable

using kioskAssistant.Model;

namespace kioskAssistant.Services
{
    public enum TilePlacement
    {
        Placed,
        OutOfBounds,
        Occupied,
    }

    /// <summary>
    /// Occupancy map of a 6x4 Start menu group. Each cell is a 1x1 tile (50px in the preview).
    /// </summary>
    public sealed class TileGrid
    {
        public const int Columns = 6;
        public const int Rows = 4;
        public const int CellSizePx = 50;

        private readonly bool[,] _occupied = new bool[Columns, Rows];

        /// <summary>Marks the tile's cells as occupied if they are all inside the grid and free.</summary>
        public TilePlacement TryPlace(TileSize size, int column, int row)
        {
            var (width, height) = size.Cells();

            if (column < 0 || row < 0 || column + width > Columns || row + height > Rows)
            {
                return TilePlacement.OutOfBounds;
            }

            for (int x = column; x < column + width; x++)
            {
                for (int y = row; y < row + height; y++)
                {
                    if (_occupied[x, y])
                    {
                        return TilePlacement.Occupied;
                    }
                }
            }

            for (int x = column; x < column + width; x++)
            {
                for (int y = row; y < row + height; y++)
                {
                    _occupied[x, y] = true;
                }
            }

            return TilePlacement.Placed;
        }

        public void Clear() => System.Array.Clear(_occupied);
    }
}
