#nullable enable

using kioskAssistant.Model;
using System;
using System.Linq;
using System.Xml.Linq;
using static kioskAssistant.Xml.XmlNamespaces;

namespace kioskAssistant.Xml
{
    /// <summary>Builds a Shell Launcher configuration document.</summary>
    public sealed class ShellLauncherXmlBuilder
    {
        private readonly AppCatalog _catalog;

        private ShellLauncherXmlBuilder(AppCatalog catalog)
        {
            _catalog = catalog;
        }

        public static XDocument Build(ShellLauncherConfiguration config, AppCatalog catalog) =>
            new ShellLauncherXmlBuilder(catalog).BuildDocument(config);

        private XDocument BuildDocument(ShellLauncherConfiguration config)
        {
            var profilesById = config.Profiles.ToDictionary(p => p.Id);

            // Each profile is written once, even when it is assigned to several accounts.
            var assignedProfiles = config.Accounts
                .Select(a => a.ProfileId)
                .Distinct()
                .Select(id => profilesById.TryGetValue(id, out var profile)
                    ? profile
                    : throw new InvalidOperationException($"Account is assigned to unknown profile {id}."));

            var profiles = new XElement(ShellLauncher + "Profiles",
                new XElement(ShellLauncher + "DefaultProfile",
                    new XElement(ShellLauncher + "Shell",
                        new XAttribute("Shell", @"%systemroot%\explorer.exe"),
                        new XElement(ShellLauncher + "DefaultAction", new XAttribute("Action", "RestartShell")))),
                assignedProfiles.Select(BuildProfile));

            var configs = new XElement(ShellLauncher + "Configs", config.Accounts.Select(BuildConfig));

            return new XDocument(
                new XDeclaration("1.0", "UTF-8", null),
                new XElement(ShellLauncher + "ShellLauncherConfiguration",
                    new XAttribute(XNamespace.Xmlns + "v2", ShellLauncherV2),
                    profiles,
                    configs));
        }

        private XElement BuildProfile(ShellLauncherProfile profile)
        {
            var shell = new XElement(ShellLauncher + "Shell");

            switch (profile.Shell)
            {
                case EdgeKioskApp edge:
                    // %ProgramFiles(x86)% expands to a path with spaces, so always quote it.
                    shell.Add(new XAttribute("Shell", $"\"{EdgeKioskApp.ExecutablePath}\" {edge.BuildArguments()}"));
                    break;

                case UwpKioskApp uwp:
                    shell.Add(
                        new XAttribute("Shell", _catalog.ResolveAumid(uwp.App)),
                        new XAttribute(ShellLauncherV2 + "AppType", "UWP"));
                    break;

                case Win32KioskApp win32:
                    shell.Add(new XAttribute("Shell", CommandLine.Join(win32.Path, win32.Arguments)));
                    break;

                default:
                    throw new NotSupportedException($"Unsupported shell type {profile.Shell.GetType().Name}.");
            }

            shell.Add(
                new XAttribute(ShellLauncherV2 + "AllAppsFullScreen", profile.AllAppsFullScreen),
                new XElement(ShellLauncher + "DefaultAction", new XAttribute("Action", profile.ExitAction.ToString())));

            return new XElement(ShellLauncher + "Profile", new XAttribute("Id", profile.Id), shell);
        }

        private static XElement BuildConfig(ShellLauncherAccount account)
        {
            XElement accountElement = account.Type switch
            {
                ShellAccountType.AutoLogon => new XElement(ShellLauncher + "AutoLogonAccount"),
                ShellAccountType.Name => new XElement(ShellLauncher + "Account", new XAttribute("Name", account.Value)),
                ShellAccountType.Sid => new XElement(ShellLauncher + "Account", new XAttribute("Sid", account.Value)),
                _ => throw new NotSupportedException($"Unsupported account type {account.Type}."),
            };

            return new XElement(ShellLauncher + "Config",
                accountElement,
                new XElement(ShellLauncher + "Profile", new XAttribute("Id", account.ProfileId)));
        }
    }
}
