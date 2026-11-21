using kioskAssistant.Model;
using kioskAssistant.Services;

namespace kioskAssistant.Tests;

public class TileGridTests
{
    [Fact]
    public void Placement_SucceedsOnFreeCells()
    {
        var grid = new TileGrid();
        Assert.Equal(TilePlacement.Placed, grid.TryPlace(TileSize.Large, 0, 0));
        Assert.Equal(TilePlacement.Placed, grid.TryPlace(TileSize.Medium, 4, 0));
        Assert.Equal(TilePlacement.Placed, grid.TryPlace(TileSize.Medium, 4, 2));
    }

    [Theory]
    [InlineData(TileSize.Wide, 3, 0)]
    [InlineData(TileSize.Large, 0, 1)]
    [InlineData(TileSize.Small, 6, 0)]
    [InlineData(TileSize.Small, 0, 4)]
    public void Placement_OutsideGrid_IsRejected(TileSize size, int column, int row) =>
        Assert.Equal(TilePlacement.OutOfBounds, new TileGrid().TryPlace(size, column, row));

    [Fact]
    public void FailedPlacement_DoesNotOccupyAnyCell()
    {
        var grid = new TileGrid();
        grid.TryPlace(TileSize.Small, 1, 1);

        // Overlaps (1,1) only in its last cell; none of its other cells may be claimed.
        Assert.Equal(TilePlacement.Occupied, grid.TryPlace(TileSize.Medium, 0, 0));
        Assert.Equal(TilePlacement.Placed, grid.TryPlace(TileSize.Small, 0, 0));
    }

    [Fact]
    public void Clear_FreesAllCells()
    {
        var grid = new TileGrid();
        grid.TryPlace(TileSize.Large, 0, 0);
        grid.Clear();
        Assert.Equal(TilePlacement.Placed, grid.TryPlace(TileSize.Large, 0, 0));
    }

    [Theory]
    [InlineData("1x1", TileSize.Small)]
    [InlineData("2x2", TileSize.Medium)]
    [InlineData("4x2", TileSize.Wide)]
    [InlineData("4x4", TileSize.Large)]
    public void TileSize_RoundTripsLayoutString(string text, TileSize size)
    {
        Assert.Equal(size, TileSizeExtensions.ParseTileSize(text));
        Assert.Equal(text, size.ToLayoutString());
    }
}

public class AppCatalogTests
{
    private static readonly AppCatalog Catalog = new(
        new Dictionary<string, string>
        {
            ["Calculator"] = "Microsoft.WindowsCalculator_8wekyb3d8bbwe!App",
            ["Settings"] = "windows.immersivecontrolpanel_cw5n1h2txyewy!microsoft.windows.immersivecontrolpanel",
            ["Helper"] = "Contoso.Helper_abc!Background",
        },
        Array.Empty<string>(),
        Array.Empty<string>());

    [Theory]
    [InlineData("Calculator", true)]
    [InlineData("Settings", true)]
    [InlineData("Helper", false)]
    public void IsPrimaryUwpApp_FiltersBackgroundEntries(string app, bool expected) =>
        Assert.Equal(expected, Catalog.IsPrimaryUwpApp(app));

    [Fact]
    public void ResolveAumid_FallsBackToRawValue()
    {
        Assert.Equal("Microsoft.WindowsCalculator_8wekyb3d8bbwe!App", Catalog.ResolveAumid("Calculator"));
        Assert.Equal("Some.Raw_Aumid!App", Catalog.ResolveAumid("Some.Raw_Aumid!App"));
    }
}
