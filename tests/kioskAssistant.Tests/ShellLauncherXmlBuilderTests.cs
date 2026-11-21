using kioskAssistant.Model;
using kioskAssistant.Xml;
using static kioskAssistant.Tests.AssignedAccessXmlBuilderTests;

namespace kioskAssistant.Tests;

public class ShellLauncherXmlBuilderTests
{
    private static ShellLauncherConfiguration Config()
    {
        var config = new ShellLauncherConfiguration();
        config.Profiles.AddRange(new[]
        {
            new ShellLauncherProfile("{S1}", new EdgeKioskApp("https://contoso.com", "10", EdgeKioskType.DigitalSignage), true, ShellExitAction.RestartShell),
            new ShellLauncherProfile("{S2}", new UwpKioskApp("Calculator"), false, ShellExitAction.RestartDevice),
            new ShellLauncherProfile("{S3}", new Win32KioskApp(@"C:\shell\myshell.exe", "-kiosk"), false, ShellExitAction.DoNothing),
        });
        config.Accounts.AddRange(new[]
        {
            new ShellLauncherAccount(ShellAccountType.Name, "user1", "{S1}"),
            new ShellLauncherAccount(ShellAccountType.Sid, "S-1-5-21-1", "{S2}"),
            new ShellLauncherAccount(ShellAccountType.AutoLogon, "", "{S3}"),
        });
        return config;
    }

    [Fact]
    public void Configuration_MatchesLegacyOutput() =>
        AssertMatchesGolden("ShellLauncher.xml", ShellLauncherXmlBuilder.Build(Config(), Catalog()));

    [Fact]
    public void ProfileSharedByTwoAccounts_IsWrittenOnce()
    {
        var config = Config();
        config.Accounts.Add(new ShellLauncherAccount(ShellAccountType.Name, "user2", "{S1}"));

        var doc = ShellLauncherXmlBuilder.Build(config, Catalog());

        Assert.Single(doc.Descendants().Where(e => e.Name.LocalName == "Profile" && (string?)e.Attribute("Id") == "{S1}" && e.Element(e.Name.Namespace + "Shell") != null));
        Assert.Equal(4, doc.Descendants().Count(e => e.Name.LocalName == "Config"));
    }

    [Fact]
    public void UnassignedProfiles_AreNotWritten()
    {
        var config = Config();
        config.Accounts.RemoveAll(a => a.ProfileId == "{S2}");

        var doc = ShellLauncherXmlBuilder.Build(config, Catalog());

        Assert.DoesNotContain(doc.Descendants(), e => (string?)e.Attribute("Id") == "{S2}");
    }

    [Theory]
    [InlineData(@"C:\Program Files\Shell\shell.exe", "", @"""C:\Program Files\Shell\shell.exe""")]
    [InlineData(@"C:\Program Files\Shell\shell.exe", "-a b", @"""C:\Program Files\Shell\shell.exe"" -a b")]
    [InlineData(@"C:\shell.exe", "", @"C:\shell.exe")]
    [InlineData(@"""C:\Program Files\x.exe""", "", @"""C:\Program Files\x.exe""")]
    public void Win32Shell_QuotesPathsWithSpaces(string path, string args, string expected)
    {
        var config = new ShellLauncherConfiguration();
        config.Profiles.Add(new ShellLauncherProfile("{S}", new Win32KioskApp(path, args), false, ShellExitAction.RestartShell));
        config.Accounts.Add(new ShellLauncherAccount(ShellAccountType.Name, "u", "{S}"));

        var doc = ShellLauncherXmlBuilder.Build(config, Catalog());
        var shell = doc.Descendants().Single(e => e.Name.LocalName == "Shell" && e.Parent!.Name.LocalName == "Profile");

        Assert.Equal(expected, (string?)shell.Attribute("Shell"));
    }
}
