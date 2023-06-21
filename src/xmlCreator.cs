using allGlobals;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;


namespace xmlManip
{
    class xmlCreator
    {

        public static void writeXmlFile(string savePath)
        {
            XDocument doc = buildXmlBody();
            buildProfiles(doc);
            buildConfigs(doc);
            doc.Save(savePath);
        }

        public static void writeShellLauncherXmlFile(string savePath)
        {
            XDocument doc = buildShellLauncherXmlBody();
            buildShellLauncherProfiles(doc);
            buildShellLauncherConfigs(doc);
            doc.Save(savePath);
        }

        #region XML Namespaces

        static XNamespace ns = "http://schemas.microsoft.com/AssignedAccess/2017/config";
        static XNamespace v2 = "http://schemas.microsoft.com/AssignedAccess/201810/config";
        static XNamespace v3 = "http://schemas.microsoft.com/AssignedAccess/2020/config";
        static XNamespace v4 = "http://schemas.microsoft.com/AssignedAccess/2021/config";
        static XNamespace win11 = "http://schemas.microsoft.com/AssignedAccess/2022/config";

        static XNamespace nssl = "http://schemas.microsoft.com/Start/2014/LayoutModification";
        static XNamespace defL = "http://schemas.microsoft.com/Start/2014/FullDefaultLayout";
        static XNamespace start = "http://schemas.microsoft.com/Start/2014/StartLayout";

        static XNamespace sL = "http://schemas.microsoft.com/ShellLauncher/2018/Configuration";
        static XNamespace slv2 = "http://schemas.microsoft.com/ShellLauncher/2019/Configuration";


        #endregion


        #region XML Builders

        public static XDocument buildXmlBody()
        {
            XDocument doc = new XDocument(
                 new XDeclaration("1.0", "UTF-8", null),
                 new XElement(ns + "AssignedAccessConfiguration",
                     new XAttribute(XNamespace.Xmlns + "v2", v2),
                     new XAttribute(XNamespace.Xmlns + "v3", v3),
                     new XAttribute(XNamespace.Xmlns + "v4", v4),
                     new XAttribute(XNamespace.Xmlns + "win11", win11),
                     new XElement(ns + "Profiles"),
                     new XElement(ns + "Configs")
                     )
                 );

            return doc;
        }

        public static XDocument buildShellLauncherXmlBody()
        {
            XDocument doc = new XDocument(
                 new XDeclaration("1.0", "UTF-8", null),
                 new XElement(sL + "ShellLauncherConfiguration",
                    new XAttribute(XNamespace.Xmlns + "v2", slv2),
                    new XElement(sL + "Profiles",
                        new XElement(sL + "DefaultProfile",
                            new XElement(sL + "Shell",
                                new XAttribute("Shell", "%systemroot%\\explorer.exe"),
                                new XElement(sL + "DefaultAction",
                                    new XAttribute("Action", "RestartShell")
                                    )
                                )
                            )
                        ),
                    new XElement(sL + "Configs")
                    )
                );

            return doc;
        }

        public static XDocument buildCoreStartLayout()
        {
            XDocument startLayout = new XDocument(
                new XDeclaration(null, null, null),
                new XElement(nssl + "LayoutModificationTemplate",
                    new XAttribute(XNamespace.Xmlns + "defaultlayout", defL),
                    new XAttribute("Version", 1),
                    new XAttribute(XNamespace.Xmlns + "start", start),
                    new XElement(nssl + "LayoutOptions",
                        new XAttribute("StartTileGroupCellWidth", 6)),
                    new XElement(nssl + "DefaultLayoutOverride",
                        new XElement(nssl + "StartLayoutCollection",
                            new XElement(defL + "StartLayout",
                                new XAttribute("GroupCellWidth", 6))
                            )
                        )
                    )
                );

            return startLayout;
        }

        public static void buildProfiles(XDocument doc)
        {
            XElement profiles = doc.Root.Element(ns + "Profiles");

            foreach (string item in perFormObjects.kioskModeApps.Keys)
            {
                string pGuid = item;
                List<string> profileParam = perFormObjects.kioskModeApps[item];
                profiles.Add(
                        new XElement(ns + "Profile",
                            new XAttribute("Id", pGuid),
                            new XElement(ns + "KioskModeApp")
                            )
                        );
                XElement profile = profiles.Elements(ns + "Profile").First(c => (string)c.Attribute("Id") == pGuid).Element(ns + "KioskModeApp");


                if (profileParam[0] == "Edge")
                {
                    string url = profileParam[1];
                    string timeout = profileParam[2];
                    string browsing;

                    if (profileParam[3] == "Public Browsing")
                    {
                        browsing = "public-browsing";
                    }
                    else
                    {
                        browsing = "fullscreen";
                    }

                    string commandline = "%ProgramFiles(x86)%\\Microsoft\\Edge\\Application\\msedge.exe";
                    string arguments = "--no-first-run --kiosk " + url + " --edge-kiosk-type=" + browsing + " --kiosk-idle-timeout-minutes=" + timeout;

                    profile.Add(
                            new XAttribute(v4 + "ClassicAppPath", commandline),
                            new XAttribute(v4 + "ClassicAppArguments", arguments)
                        );

                }
                else if (profileParam[0] == "UWP")
                {
                    string app = profileParam[1];
                    if (Globals.allUwpApps.ContainsKey(app))
                    {
                        profile.Add(
                            new XAttribute("AppUserModelId", Globals.allUwpApps[app])
                        );
                    }
                    else
                    {
                        profile.Add(
                            new XAttribute("AppUserModelId", app)
                        );
                    }
                }
                else if (profileParam[0] == "win32")
                {
                    string commandline = profileParam[1];
                    string arguments = profileParam[2];

                    profile.Add(
                        new XAttribute(v4 + "ClassicAppPath", commandline),
                        new XAttribute(v4 + "ClassicAppArguments", arguments)
                    );
                }
            }

            foreach (List<string> appParam in Globals.appProfiles.Keys)
            {
                string pGuid = appParam[0];
                string taskbar = appParam[1];
                string dlPerm = appParam[2];
                string rdPerm = appParam[3];
                string noRestrict = appParam[4];
                string isWin10 = appParam[5];
                string isWin11 = appParam[6];

                List<string> allApps = Globals.appProfiles[appParam].Keys.FirstOrDefault();


                profiles.Add(
                    new XElement(ns + "Profile",
                        new XAttribute("Id", pGuid),
                        new XElement(ns + "AllAppsList",
                            new XElement(ns + "AllowedApps"))
                        )
                    );

                XElement profile = profiles.Elements(ns + "Profile").First(c => (string)c.Attribute("Id") == pGuid);
                XElement allowedApps = profile.Element(ns + "AllAppsList").Element(ns + "AllowedApps");

                foreach (string app in allApps)
                {
                    addAppConfig(allowedApps, app, pGuid);
                }

                if (isWin10 == "true")
                {

                    XDocument sLayout = buildCoreStartLayout();
                    XElement startLayout = sLayout.Root.Element(nssl + "DefaultLayoutOverride").Element(nssl + "StartLayoutCollection").Element(defL + "StartLayout");

                    foreach (string groupName in Globals.appProfiles[appParam][allApps].Keys)
                    {
                        addAppGroupConfig(startLayout, groupName, Globals.appProfiles[appParam][allApps][groupName]);
                    }

                    string cDataBlock = sLayout.ToString();
                    profile.Add(new XElement(ns + "StartLayout"));
                    profile.Element(ns + "StartLayout").Add(new XCData(cDataBlock));
                }

                if (isWin11 == "true")
                {
                    string pinnedList = "";
                    int count = 0;
                    foreach (string app in allApps)
                    {
                        pinnedList += win11AddPins(app, count);
                        count++;
                    }

                    string json = "{ \"pinnedList\":[\n" + pinnedList + "\n] }";
                    profile.Add(new XElement(win11 + "StartPins"));
                    profile.Element(win11 + "StartPins").Add(new XCData(json));
                }

                profile.Add(
                    new XElement(ns + "Taskbar",
                        new XAttribute("ShowTaskbar", taskbar))
                    );

                profile.Add(new XElement(v2 + "FileExplorerNamespaceRestrictions"));

                XElement nsRestrict = profile.Element(v2 + "FileExplorerNamespaceRestrictions");
                addNamespaceConfig(nsRestrict, dlPerm, rdPerm, noRestrict);
            }
        }

        public static void buildShellLauncherProfiles(XDocument doc)
        {
            XElement profiles = doc.Root.Element(sL + "Profiles");

            foreach (string item in perFormObjects.shellLauncherAccs.Keys)
            {
                string pGuid = item;
                string shell;
                List<string> profileParam = perFormObjects.shellLauncherAccs[item];
                string errorAction = profileParam[profileParam.Count - 1];
                string fullScreen = profileParam[profileParam.Count - 2];

                profiles.Add(
                        new XElement(sL + "Profile",
                            new XAttribute("Id", pGuid),
                                new XElement(sL + "Shell",
                                    new XElement(sL + "DefaultAction",
                                        new XAttribute("Action", errorAction)
                                    )
                                )
                            )
                        );

                XElement shellNode = profiles.Elements(sL + "Profile").First(c => (string)c.Attribute("Id") == pGuid).Element(sL + "Shell");

                switch (profileParam[0])
                {
                    case "Edge":
                        string url = profileParam[1];
                        string timeout = profileParam[2];
                        string browsingType = profileParam[3] == "Public Browsing" ? "public-browsing" : "fullscreen";

                        shell = "%ProgramFiles(x86)%\\Microsoft\\Edge\\Application\\msedge.exe --no-first-run --kiosk " + url + " --edge-kiosk-type=" + browsingType + " --kiosk-idle-timeout-minutes=" + timeout;

                        shellNode.Add(
                            new XAttribute("Shell", shell),
                            new XAttribute(slv2 + "AllAppsFullScreen", fullScreen)
                        );
                        break;
                    case "UWP":
                        string uwpApp = profileParam[1];
                        if (Globals.allUwpApps.ContainsKey(uwpApp))
                        {
                            shell = Globals.allUwpApps[uwpApp];
                        }
                        else
                        {
                            shell = uwpApp;
                        }

                        shellNode.Add(
                            new XAttribute("Shell", shell),
                            new XAttribute(slv2 + "AppType", "UWP"),
                            new XAttribute(slv2 + "AllAppsFullScreen", fullScreen)
                        );
                        break;
                    case "win32":
                        string exe = profileParam[1];
                        string args = profileParam[2];

                        shell = exe + " " + args;
                        shellNode.Add(
                            new XAttribute("Shell", shell),
                            new XAttribute(slv2 + "AllAppsFullScreen", fullScreen)
                        );
                        break;
                }                
            }
        }

        public static void buildConfigs(XDocument doc)
        {
            XElement configs = doc.Root.Element(ns + "Configs");

            if (Globals.isGlobal)
            {
                configs.Add(
                    new XElement(v3 + "GlobalProfile",
                        new XAttribute("Id", Globals.globalProfile)
                        )
                    );
            }

            if (Globals.isAuto)
            {
                string dName = Globals.autoLogon.Keys.FirstOrDefault();
                string profileId = Globals.autoLogon[dName];

                configs.Add(
                    new XElement(ns + "Config",
                        new XElement(ns + "AutoLogonAccount"),
                        new XElement(ns + "DefaultProfile",
                            new XAttribute("Id", profileId)
                            )
                        )
                    );

                if (!string.IsNullOrWhiteSpace(Globals.displayName))
                {
                    configs.Element(ns + "Config").Element(ns + "AutoLogonAccount").Add(new XAttribute(v2 + "DisplayName", dName));
                }
            }

            foreach (string user in Globals.addedUsers.Keys)
            {
                string profileId = Globals.addedUsers[user];
                addUserConfig(configs, user, profileId);
            }

            foreach (string localGroup in Globals.addedLocalGroups.Keys)
            {
                string profileId = Globals.addedLocalGroups[localGroup];
                addGroupConfig(configs, localGroup, profileId, "LocalGroup");
            }

            foreach (string domainGroup in Globals.addedDomainGroups.Keys)
            {
                string profileId = Globals.addedDomainGroups[domainGroup];
                addGroupConfig(configs, domainGroup, profileId, "ActiveDirectoryGroup");
            }

            foreach (string azureGroup in Globals.addedAzureGroups.Keys)
            {
                string profileId = Globals.addedAzureGroups[azureGroup];
                addGroupConfig(configs, azureGroup, profileId, "AzureActiveDirectoryGroup");
            }
        }

        public static void buildShellLauncherConfigs(XDocument doc)
        {
            XElement configs = doc.Root.Element(sL + "Configs");
            foreach (string item in Globals.shellLauncherAccounts.Keys)
            {
                string profileId = Globals.shellLauncherAccounts[item];
                string identifier = "Name";
                string acc;

                if (item == "Autologon")
                {
                    configs.Add(
                        new XElement(sL + "Config",
                            new XElement(sL + "AutoLogonAccount"
                            ),
                            new XElement(sL + "Profile",
                                new XAttribute("Id", profileId)
                            )
                        )
                    );
                }
                else
                {
                    acc = item.Remove(0, 3);

                    if (item.Contains("[s]")) { identifier = "Sid"; }

                    configs.Add(
                        new XElement(sL + "Config",
                            new XElement(sL + "Account",
                                new XAttribute(identifier, acc)
                            ),
                            new XElement(sL + "Profile",
                                new XAttribute("Id", profileId)
                            )
                        )
                    );
                }
            }
        }

        #endregion


        #region XML Node Injectors

        private static void addAppConfig(XElement allowedApps, string app, string pGuid)
        {
            List<string> autoLaunchApp = Globals.globalAutoLaunchApps[pGuid];
            if (Globals.allUwpApps.ContainsKey(app))
            {
                allowedApps.Add(
                    new XElement(ns + "App",
                        new XAttribute("AppUserModelId", Globals.allUwpApps[app])
                        )
                    );

                if (autoLaunchApp.Contains(app))
                {
                    XElement addedEntry = allowedApps.Elements(ns + "App").Last(c => (string)c.Attribute("AppUserModelId") == Globals.allUwpApps[app]);
                    addedEntry.Add(new XAttribute(v2 + "AutoLaunch", true));

                    if (!string.IsNullOrEmpty(autoLaunchApp[1]))
                    {
                        addedEntry.Add(new XAttribute(v2 + "AutoLaunchArguments", autoLaunchApp[1]));
                    }
                }
            }
            else
            {
                allowedApps.Add(
                    new XElement(ns + "App",
                        new XAttribute("DesktopAppPath", app)
                        )
                    );

                if (autoLaunchApp.Contains(app))
                {
                    XElement addedEntry = allowedApps.Elements(ns + "App").Last(c => (string)c.Attribute("DesktopAppPath") == app);
                    addedEntry.Add(new XAttribute(v2 + "AutoLaunch", true));

                    if (!string.IsNullOrEmpty(autoLaunchApp[1]))
                    {
                        addedEntry.Add(new XAttribute(v2 + "AutoLaunchArguments", autoLaunchApp[1]));
                    }
                }
            }
        }

        private static void addNamespaceConfig(XElement nsRestrict, string dlPerm, string rdPerm, string noRestrict)
        {
            if (noRestrict == "true")
            {
                nsRestrict.Add(
                    new XElement(v3 + "NoRestriction")
                    );
            }
            else if (!(dlPerm == "true" | rdPerm == "true"))
            {
                nsRestrict.Remove();
            }
            else
            {
                if (dlPerm == "true")
                {
                    nsRestrict.Add(
                        new XElement(v2 + "AllowedNamespace",
                            new XAttribute("Name", "Downloads")
                            )
                        );
                }
                if (rdPerm == "true")
                {
                    nsRestrict.Add(new XElement(v3 + "AllowRemovableDrives"));
                }
            }
        }

        private static void addAppGroupConfig(XElement startLayout, string groupName, Dictionary<string, List<string>> groupApps)
        {
            startLayout.Add(new XElement(start + "Group", new XAttribute("Name", groupName)));
            XElement group = startLayout.Elements(start + "Group").First(c => (string)c.Attribute("Name") == groupName);

            foreach (string app in groupApps.Keys)
            {
                string tileSize = groupApps[app][0];
                string column = groupApps[app][1];
                string row = groupApps[app][2];

                if (Globals.allUwpApps.ContainsKey(app))
                {
                    group.Add(
                    new XElement
                    (
                        start + "Tile",
                        new XAttribute("Size", tileSize),
                        new XAttribute("Column", column),
                        new XAttribute("Row", row),
                        new XAttribute("AppUserModelID", Globals.allUwpApps[app]))
                    );
                }
                else
                {
                    group.Add(
                    new XElement
                    (
                        start + "DesktopApplicationTile",
                        new XAttribute("Size", tileSize),
                        new XAttribute("Column", column),
                        new XAttribute("Row", row),
                        new XAttribute("DesktopApplicationLinkPath", app))
                    );
                }
            }
        }

        private static string win11AddPins(string app, int count)
        {
            string appIDorPath;

            if (Globals.allUwpApps.ContainsKey(app))
            {
                appIDorPath = "packagedAppId\":\"" + Globals.allUwpApps[app] + "\"}";
            }
            else
            {
                appIDorPath = "desktopAppLink\":\"" + app.Replace(@"\", @"\\") + "\"}";
            }

            if (count > 0)
            {
                appIDorPath = ",\n" + appIDorPath;
            }

            return appIDorPath;
        }

        private static void addUserConfig(XElement configs, string name, string profileId)
        {
            configs.Add(
                new XElement(ns + "Config",
                    new XElement(ns + "Account", name),
                    new XElement(ns + "DefaultProfile",
                        new XAttribute("Id", profileId)
                        )
                    )
                );
        }

        private static void addGroupConfig(XElement configs, string name, string profileId, string type)
        {
            configs.Add(
                new XElement(ns + "Config",
                    new XElement(ns + "UserGroup",
                        new XAttribute("Type", type),
                        new XAttribute("Name", name)),
                    new XElement(ns + "DefaultProfile",
                        new XAttribute("Id", profileId)
                        )
                    )
                );
        }
        #endregion
    }
}