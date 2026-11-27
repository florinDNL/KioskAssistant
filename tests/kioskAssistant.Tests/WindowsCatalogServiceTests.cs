using kioskAssistant.Services;

namespace kioskAssistant.Tests;

/// <summary>Exercises native Windows catalog APIs on the local machine.</summary>
[Trait("Category", "Integration")]
public class WindowsCatalogServiceTests
{
    [Fact]
    public void LoadCatalog_ReturnsLocalGroupsAndApps()
    {
        var catalog = WindowsCatalogService.LoadCatalog();

        Assert.NotEmpty(catalog.LocalGroups);
        Assert.NotEmpty(catalog.UwpApps);
        Assert.All(catalog.UwpApps.Values, aumid => Assert.Contains("!", aumid));
    }

    [Fact]
    public void GetShortcutTarget_HandlesQuotesInPath()
    {
        string dir = Path.Combine(Path.GetTempPath(), "kA test's dir");
        Directory.CreateDirectory(dir);
        string lnk = Path.Combine(dir, "it's a link.lnk");
        string target = Path.Combine(Environment.SystemDirectory, "notepad.exe");

        try
        {
            dynamic shell = Activator.CreateInstance(Type.GetTypeFromProgID("WScript.Shell")!)!;
            dynamic shortcut = shell.CreateShortcut(lnk);
            shortcut.TargetPath = target;
            shortcut.Save();

            Assert.Equal(target, WindowsCatalogService.GetShortcutTarget(lnk), ignoreCase: true);
        }
        finally
        {
            Directory.Delete(dir, recursive: true);
        }
    }
}
