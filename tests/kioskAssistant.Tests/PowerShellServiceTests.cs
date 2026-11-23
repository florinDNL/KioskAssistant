using kioskAssistant.Services;

namespace kioskAssistant.Tests;

/// <summary>Exercises the real PowerShell runspace on the local machine.</summary>
[Trait("Category", "Integration")]
public class PowerShellServiceTests
{
    [Fact]
    public void LoadCatalog_ReturnsLocalGroupsAndApps()
    {
        var catalog = PowerShellService.LoadCatalog();

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

            Assert.Equal(target, PowerShellService.GetShortcutTarget(lnk), ignoreCase: true);
        }
        finally
        {
            Directory.Delete(dir, recursive: true);
        }
    }
}
