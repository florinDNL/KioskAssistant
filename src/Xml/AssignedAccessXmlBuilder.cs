#nullable enable

using kioskAssistant.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Xml.Linq;
using static kioskAssistant.Xml.XmlNamespaces;

namespace kioskAssistant.Xml
{
    /// <summary>Builds an Assigned Access (multi-app / kiosk-mode) configuration document.</summary>
    public sealed class AssignedAccessXmlBuilder
    {
        private static readonly JsonSerializerOptions PinJsonOptions = new() { Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping };

        private readonly AppCatalog _catalog;
        private bool _v3Needed;
        private bool _v4Needed;
        private bool _win11Needed;

        private AssignedAccessXmlBuilder(AppCatalog catalog)
        {
            _catalog = catalog;
        }

        public static XDocument Build(AssignedAccessConfiguration config, AppCatalog catalog) =>
            new AssignedAccessXmlBuilder(catalog).BuildDocument(config);

        private XDocument BuildDocument(AssignedAccessConfiguration config)
        {
            var profiles = new XElement(AssignedAccess + "Profiles");
            foreach (var profile in config.KioskModeProfiles)
            {
                profiles.Add(BuildKioskModeProfile(profile));
            }
            foreach (var profile in config.MultiAppProfiles)
            {
                profiles.Add(BuildMultiAppProfile(profile));
            }

            var configs = new XElement(AssignedAccess + "Configs",
                config.Accounts.OrderBy(a => a.Type).Select(BuildConfig));

            var root = new XElement(AssignedAccess + "AssignedAccessConfiguration",
                new XAttribute(XNamespace.Xmlns + "v2", V2),
                profiles,
                configs);

            if (_v3Needed) root.Add(new XAttribute(XNamespace.Xmlns + "v3", V3));
            if (_v4Needed) root.Add(new XAttribute(XNamespace.Xmlns + "v4", V4));
            if (_win11Needed) root.Add(new XAttribute(XNamespace.Xmlns + "win11", Win11));

            return new XDocument(new XDeclaration("1.0", "UTF-8", null), root);
        }

        private XElement BuildKioskModeProfile(KioskModeProfile profile)
        {
            var app = new XElement(AssignedAccess + "KioskModeApp");

            switch (profile.App)
            {
                case EdgeKioskApp edge:
                    app.Add(
                        new XAttribute(V4 + "ClassicAppPath", EdgeKioskApp.ExecutablePath),
                        new XAttribute(V4 + "ClassicAppArguments", edge.BuildArguments()));
                    _v4Needed = true;
                    break;

                case UwpKioskApp uwp:
                    app.Add(new XAttribute("AppUserModelId", _catalog.ResolveAumid(uwp.App)));
                    break;

                case Win32KioskApp win32:
                    app.Add(new XAttribute(V4 + "ClassicAppPath", win32.Path));
                    if (!string.IsNullOrEmpty(win32.Arguments))
                    {
                        app.Add(new XAttribute(V4 + "ClassicAppArguments", win32.Arguments));
                    }
                    _v4Needed = true;
                    break;

                default:
                    throw new NotSupportedException($"Unsupported kiosk app type {profile.App.GetType().Name}.");
            }

            return new XElement(AssignedAccess + "Profile", new XAttribute("Id", profile.Id), app);
        }

        private XElement BuildMultiAppProfile(MultiAppProfile profile)
        {
            var element = new XElement(AssignedAccess + "Profile",
                new XAttribute("Id", profile.Id),
                new XElement(AssignedAccess + "AllAppsList",
                    new XElement(AssignedAccess + "AllowedApps",
                        profile.AllowedApps.Select(app => BuildAllowedApp(app, profile.AutoLaunch)))));

            if (profile.TargetsWindows10)
            {
                element.Add(new XElement(AssignedAccess + "StartLayout",
                    new XCData(BuildStartLayout(profile.StartGroups).ToString())));
            }

            if (profile.TargetsWindows11)
            {
                element.Add(new XElement(Win11 + "StartPins", new XCData(BuildStartPinsJson(profile.AllowedApps))));
                _win11Needed = true;
            }

            element.Add(new XElement(AssignedAccess + "Taskbar", new XAttribute("ShowTaskbar", profile.ShowTaskbar)));

            var restrictions = BuildFileExplorerRestrictions(profile);
            if (restrictions != null)
            {
                element.Add(restrictions);
            }

            return element;
        }

        private XElement BuildAllowedApp(string app, AutoLaunchApp? autoLaunch)
        {
            var element = _catalog.IsUwp(app)
                ? new XElement(AssignedAccess + "App", new XAttribute("AppUserModelId", _catalog.UwpApps[app]))
                : new XElement(AssignedAccess + "App", new XAttribute("DesktopAppPath", app));

            if (autoLaunch != null && autoLaunch.App == app)
            {
                element.Add(new XAttribute(V2 + "AutoLaunch", true));
                if (!string.IsNullOrEmpty(autoLaunch.Arguments))
                {
                    element.Add(new XAttribute(V2 + "AutoLaunchArguments", autoLaunch.Arguments));
                }
            }

            return element;
        }

        private XElement BuildStartLayout(IEnumerable<StartGroup> groups)
        {
            return new XElement(LayoutModification + "LayoutModificationTemplate",
                new XAttribute(XNamespace.Xmlns + "defaultlayout", FullDefaultLayout),
                new XAttribute("Version", 1),
                new XAttribute(XNamespace.Xmlns + "start", StartLayout),
                new XElement(LayoutModification + "LayoutOptions", new XAttribute("StartTileGroupCellWidth", 6)),
                new XElement(LayoutModification + "DefaultLayoutOverride",
                    new XElement(LayoutModification + "StartLayoutCollection",
                        new XElement(FullDefaultLayout + "StartLayout",
                            new XAttribute("GroupCellWidth", 6),
                            groups.Select(BuildStartGroup)))));
        }

        private XElement BuildStartGroup(StartGroup group)
        {
            return new XElement(StartLayout + "Group",
                new XAttribute("Name", group.Name),
                group.Tiles.Select(tile => _catalog.IsUwp(tile.App)
                    ? new XElement(StartLayout + "Tile",
                        new XAttribute("Size", tile.Size.ToLayoutString()),
                        new XAttribute("Column", tile.Column),
                        new XAttribute("Row", tile.Row),
                        new XAttribute("AppUserModelID", _catalog.UwpApps[tile.App]))
                    : new XElement(StartLayout + "DesktopApplicationTile",
                        new XAttribute("Size", tile.Size.ToLayoutString()),
                        new XAttribute("Column", tile.Column),
                        new XAttribute("Row", tile.Row),
                        new XAttribute("DesktopApplicationLinkPath", tile.App))));
        }

        private string BuildStartPinsJson(IEnumerable<string> apps)
        {
            var pins = apps.Select(app => _catalog.IsUwp(app)
                ? JsonSerializer.Serialize(new { packagedAppId = _catalog.UwpApps[app] }, PinJsonOptions)
                : JsonSerializer.Serialize(new { desktopAppLink = app }, PinJsonOptions));

            return "{ \"pinnedList\":[\n" + string.Join(",\n", pins) + "\n] }";
        }

        private XElement? BuildFileExplorerRestrictions(MultiAppProfile profile)
        {
            var restrictions = new XElement(V2 + "FileExplorerNamespaceRestrictions");

            if (profile.NoFileExplorerRestriction)
            {
                restrictions.Add(new XElement(V3 + "NoRestriction"));
                _v3Needed = true;
                return restrictions;
            }

            if (!profile.AllowDownloads && !profile.AllowRemovableDrives)
            {
                return null;
            }

            if (profile.AllowDownloads)
            {
                restrictions.Add(new XElement(V2 + "AllowedNamespace", new XAttribute("Name", "Downloads")));
            }
            if (profile.AllowRemovableDrives)
            {
                restrictions.Add(new XElement(V3 + "AllowRemovableDrives"));
                _v3Needed = true;
            }

            return restrictions;
        }

        private XElement BuildConfig(AccountAssignment account)
        {
            var defaultProfile = new XElement(AssignedAccess + "DefaultProfile", new XAttribute("Id", account.ProfileId));

            switch (account.Type)
            {
                case AccountType.GlobalProfile:
                    _v3Needed = true;
                    return new XElement(V3 + "GlobalProfile", new XAttribute("Id", account.ProfileId));

                case AccountType.AutoLogon:
                    var autoLogon = new XElement(AssignedAccess + "AutoLogonAccount");
                    if (!string.IsNullOrWhiteSpace(account.Name))
                    {
                        autoLogon.Add(new XAttribute(V2 + "DisplayName", account.Name));
                    }
                    return new XElement(AssignedAccess + "Config", autoLogon, defaultProfile);

                case AccountType.User:
                    return new XElement(AssignedAccess + "Config",
                        new XElement(AssignedAccess + "Account", account.Name),
                        defaultProfile);

                default:
                    string groupType = account.Type switch
                    {
                        AccountType.LocalGroup => "LocalGroup",
                        AccountType.DomainGroup => "ActiveDirectoryGroup",
                        AccountType.AzureGroup => "AzureActiveDirectoryGroup",
                        _ => throw new NotSupportedException($"Unsupported account type {account.Type}."),
                    };
                    return new XElement(AssignedAccess + "Config",
                        new XElement(AssignedAccess + "UserGroup",
                            new XAttribute("Type", groupType),
                            new XAttribute("Name", account.Name)),
                        defaultProfile);
            }
        }
    }
}
