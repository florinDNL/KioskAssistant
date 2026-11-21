#nullable enable

using System;
using System.Collections.Generic;

namespace kioskAssistant.Model
{
    public enum TileSize
    {
        Small,   // 1x1
        Medium,  // 2x2
        Wide,    // 4x2
        Large,   // 4x4
    }

    public static class TileSizeExtensions
    {
        public static (int Width, int Height) Cells(this TileSize size) => size switch
        {
            TileSize.Small => (1, 1),
            TileSize.Medium => (2, 2),
            TileSize.Wide => (4, 2),
            TileSize.Large => (4, 4),
            _ => throw new ArgumentOutOfRangeException(nameof(size)),
        };

        public static string ToLayoutString(this TileSize size)
        {
            var (w, h) = size.Cells();
            return $"{w}x{h}";
        }

        public static TileSize ParseTileSize(string value) => value switch
        {
            "1x1" => TileSize.Small,
            "2x2" => TileSize.Medium,
            "4x2" => TileSize.Wide,
            "4x4" => TileSize.Large,
            _ => throw new ArgumentException($"Unknown tile size '{value}'.", nameof(value)),
        };
    }

    /// <param name="App">UWP display name / AUMID, or a .lnk path for desktop apps.</param>
    public sealed record Tile(string App, TileSize Size, int Column, int Row);

    public sealed class StartGroup
    {
        public StartGroup(string name, IEnumerable<Tile> tiles)
        {
            Name = name;
            Tiles = new List<Tile>(tiles);
        }

        public string Name { get; }
        public IReadOnlyList<Tile> Tiles { get; }
    }

    public sealed record AutoLaunchApp(string App, string Arguments);

    public sealed record KioskModeProfile(string Id, KioskApp App);

    public sealed class MultiAppProfile
    {
        public required string Id { get; init; }
        public bool ShowTaskbar { get; init; }
        public bool AllowDownloads { get; init; }
        public bool AllowRemovableDrives { get; init; }
        public bool NoFileExplorerRestriction { get; init; }
        public bool TargetsWindows10 { get; init; }
        public bool TargetsWindows11 { get; init; }
        public IReadOnlyList<string> AllowedApps { get; init; } = Array.Empty<string>();
        public IReadOnlyList<StartGroup> StartGroups { get; init; } = Array.Empty<StartGroup>();
        public AutoLaunchApp? AutoLaunch { get; init; }
    }

    // Declaration order is the order in which configs are written to the XML.
    public enum AccountType
    {
        GlobalProfile,
        AutoLogon,
        User,
        LocalGroup,
        DomainGroup,
        AzureGroup,
    }

    /// <param name="Name">Account or group name. For <see cref="AccountType.AutoLogon"/> this is the display name.</param>
    public sealed record AccountAssignment(AccountType Type, string Name, string ProfileId);

    public sealed class AssignedAccessConfiguration
    {
        public List<KioskModeProfile> KioskModeProfiles { get; } = new();
        public List<MultiAppProfile> MultiAppProfiles { get; } = new();
        public List<AccountAssignment> Accounts { get; } = new();
    }
}
