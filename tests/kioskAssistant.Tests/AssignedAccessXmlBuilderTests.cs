using kioskAssistant.Model;
using kioskAssistant.Xml;
using System.Text;
using System.Text.Json;
using System.Xml.Linq;

namespace kioskAssistant.Tests;

public class AssignedAccessXmlBuilderTests
{
    internal static AppCatalog Catalog() => new(
        new Dictionary<string, string>
        {
            ["Calculator"] = "Microsoft.WindowsCalculator_8wekyb3d8bbwe!App",
            ["Photos"] = "Microsoft.Windows.Photos_8wekyb3d8bbwe!App",
        },
        Array.Empty<string>(),
        Array.Empty<string>());

    internal static string Serialize(XDocument doc)
    {
        var path = Path.GetTempFileName();
        try
        {
            doc.Save(path);
            return File.ReadAllText(path, Encoding.UTF8);
        }
        finally
        {
            File.Delete(path);
        }
    }

    internal static void AssertMatchesGolden(string goldenName, XDocument actual)
    {
        string expected = File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "Golden", goldenName), Encoding.UTF8);
        Assert.Equal(Normalize(expected), Normalize(Serialize(actual)));

        static string Normalize(string s) => s.Replace("\r\n", "\n").Trim();
    }

    private static MultiAppProfile MinimalProfile() => new()
    {
        Id = "{P3}",
        ShowTaskbar = true,
        TargetsWindows10 = true,
        AllowedApps = new[] { "Calculator" },
        StartGroups = new[] { new StartGroup("G", new[] { new Tile("Calculator", TileSize.Small, 0, 0) }) },
    };

    private static AssignedAccessConfiguration FullConfig()
    {
        var config = new AssignedAccessConfiguration();
        config.KioskModeProfiles.AddRange(new[]
        {
            new KioskModeProfile("{K1}", new EdgeKioskApp("https://contoso.com", "15", EdgeKioskType.PublicBrowsing)),
            new KioskModeProfile("{K2}", new UwpKioskApp("Calculator")),
            new KioskModeProfile("{K3}", new Win32KioskApp(@"C:\Apps\app.exe", "")),
            new KioskModeProfile("{K4}", new Win32KioskApp(@"C:\Apps\app2.exe", "-x")),
            new KioskModeProfile("{K5}", new EdgeKioskApp("https://fabrikam.com", "0", EdgeKioskType.DigitalSignage)),
        });

        config.MultiAppProfiles.Add(new MultiAppProfile
        {
            Id = "{P1}",
            ShowTaskbar = true,
            AllowDownloads = true,
            AllowRemovableDrives = true,
            TargetsWindows10 = true,
            TargetsWindows11 = true,
            AllowedApps = new[] { "Calculator", @"C:\Apps\tool.exe", "Photos" },
            StartGroups = new[]
            {
                new StartGroup("Main", new[]
                {
                    new Tile("Calculator", TileSize.Medium, 0, 0),
                    new Tile(@"C:\links\tool.lnk", TileSize.Wide, 2, 0),
                }),
                new StartGroup("Second", new[] { new Tile("Photos", TileSize.Small, 0, 0) }),
            },
            AutoLaunch = new AutoLaunchApp("Calculator", "--arg"),
        });
        config.MultiAppProfiles.Add(new MultiAppProfile
        {
            Id = "{P2}",
            NoFileExplorerRestriction = true,
            TargetsWindows11 = true,
            AllowedApps = new[] { "Photos", @"C:\Program Files\x.exe" },
            AutoLaunch = new AutoLaunchApp(@"C:\Program Files\x.exe", ""),
        });
        config.MultiAppProfiles.Add(MinimalProfile());

        // Deliberately out of order: configs are written grouped by account type.
        config.Accounts.AddRange(new[]
        {
            new AccountAssignment(AccountType.User, "user1", "{P1}"),
            new AccountAssignment(AccountType.AzureGroup, "aad-group-id", "{P1}"),
            new AccountAssignment(AccountType.AutoLogon, "Kiosk Display", "{K1}"),
            new AccountAssignment(AccountType.User, @"DOMAIN\u2", "{K2}"),
            new AccountAssignment(AccountType.LocalGroup, "Users", "{P2}"),
            new AccountAssignment(AccountType.GlobalProfile, "Global Profile", "{P1}"),
            new AccountAssignment(AccountType.DomainGroup, @"CONTOSO\kiosk", "{P3}"),
        });
        return config;
    }

    private static AssignedAccessConfiguration MinimalConfig()
    {
        var config = new AssignedAccessConfiguration();
        config.MultiAppProfiles.Add(MinimalProfile());
        config.Accounts.Add(new AccountAssignment(AccountType.User, "user1", "{P3}"));
        return config;
    }

    [Fact]
    public void FullConfiguration_MatchesLegacyOutput() =>
        AssertMatchesGolden("MultiApp.xml", AssignedAccessXmlBuilder.Build(FullConfig(), Catalog()));

    [Fact]
    public void MinimalConfiguration_MatchesLegacyOutput() =>
        AssertMatchesGolden("Minimal.xml", AssignedAccessXmlBuilder.Build(MinimalConfig(), Catalog()));

    [Fact]
    public void OptionalNamespaces_DoNotLeakIntoLaterDocuments()
    {
        AssignedAccessXmlBuilder.Build(FullConfig(), Catalog());

        AssertMatchesGolden("Minimal.xml", AssignedAccessXmlBuilder.Build(MinimalConfig(), Catalog()));
    }

    [Fact]
    public void StartPins_AreValidJsonForPathsWithQuotes()
    {
        var config = new AssignedAccessConfiguration();
        config.MultiAppProfiles.Add(new MultiAppProfile
        {
            Id = "{P}",
            TargetsWindows11 = true,
            AllowedApps = new[] { "Calculator", @"C:\My ""Apps""\a.lnk" },
        });

        var doc = AssignedAccessXmlBuilder.Build(config, Catalog());
        string json = doc.Descendants(XName.Get("StartPins", "http://schemas.microsoft.com/AssignedAccess/2022/config")).Single().Value;

        var pins = JsonDocument.Parse(json).RootElement.GetProperty("pinnedList");
        Assert.Equal("Microsoft.WindowsCalculator_8wekyb3d8bbwe!App", pins[0].GetProperty("packagedAppId").GetString());
        Assert.Equal(@"C:\My ""Apps""\a.lnk", pins[1].GetProperty("desktopAppLink").GetString());
    }

    [Fact]
    public void AutoLaunch_OnlyMarksTheSelectedApp()
    {
        var config = new AssignedAccessConfiguration();
        config.MultiAppProfiles.Add(new MultiAppProfile
        {
            Id = "{P}",
            TargetsWindows11 = true,
            AllowedApps = new[] { "Calculator", "Photos" },
            // Arguments equal to another app's name must not mark that app as auto-launched.
            AutoLaunch = new AutoLaunchApp("Calculator", "Photos"),
        });

        var doc = AssignedAccessXmlBuilder.Build(config, Catalog());
        XNamespace v2 = "http://schemas.microsoft.com/AssignedAccess/201810/config";
        var autoLaunched = doc.Descendants().Where(e => e.Attribute(v2 + "AutoLaunch") != null).ToList();

        Assert.Single(autoLaunched);
        Assert.Equal("Microsoft.WindowsCalculator_8wekyb3d8bbwe!App", (string?)autoLaunched[0].Attribute("AppUserModelId"));
    }

    [Fact]
    public void EdgeUrlWithSpaces_IsQuoted()
    {
        var config = new AssignedAccessConfiguration();
        config.KioskModeProfiles.Add(new KioskModeProfile("{K}", new EdgeKioskApp("file:///C:/My Site/index.html", "5", EdgeKioskType.DigitalSignage)));

        var doc = AssignedAccessXmlBuilder.Build(config, Catalog());
        XNamespace v4 = "http://schemas.microsoft.com/AssignedAccess/2021/config";
        string args = (string)doc.Descendants().Single(e => e.Name.LocalName == "KioskModeApp").Attribute(v4 + "ClassicAppArguments")!;

        Assert.Contains("--kiosk \"file:///C:/My Site/index.html\" ", args);
    }
}
