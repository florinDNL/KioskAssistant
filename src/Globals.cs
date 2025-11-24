using gridUI;
using powershellApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace allGlobals
{
    public class Globals
    {
        public static Dictionary<List<string>,
                                 Dictionary<List<string>,
                                            Dictionary<string,
                                                       Dictionary<string,
                                                                  List<string>
                                                                 >
                                                      >
                                            >
                                > appProfiles = new();
        public static Dictionary<string, List<string>> globalAutoLaunchApps = new();

        public static Dictionary<string, string> allUwpApps;
        public static Dictionary<string, string> addedUsers;
        public static Dictionary<string, string> addedLocalGroups;
        public static Dictionary<string, string> addedDomainGroups;
        public static Dictionary<string, string> addedAzureGroups;
        public static Dictionary<string, string> autoLogon;
        public static Dictionary<string, string> shellLauncherAccounts;

        public static List<string> localUsers;
        public static List<string> localGroups;

        public static bool isGlobal = false;
        public static bool isAuto = false;

        public static string globalProfile;
        public static string displayName;


        public static string GetGUID()
        {
            return "{" + Guid.NewGuid().ToString().ToUpper() + "}";
        }

        public static void psInit()
        {
            allUwpApps = Commands.GetApps();
            localUsers = Commands.GetUsers();
            localGroups = Commands.GetGroups();
        }

        public static void accountsInit()
        {
            addedUsers = new();
            addedLocalGroups = new();
            addedDomainGroups = new();
            addedAzureGroups = new();
            autoLogon = new();
            shellLauncherAccounts = new();
        }


        public static bool areAllAssigned(int userNum, DataGridView dataGrid, int index)
        {
            int assignedNum = 0;

            foreach (DataGridViewRow row in dataGrid.Rows)
            {
                if (row.Cells[index].Value != null)
                {
                    assignedNum++;
                }
            }

            return userNum == assignedNum ? true : false;
        }
    }

    public class perFormObjects
    {
        public static List<string> uwpApps = new();
        public static List<string> addUwpApps = new();

        public static Dictionary<string, string> linkedWin32Apps = new();
        public static Dictionary<string, Dictionary<string, List<string>>> groups = new();
        public static Dictionary<string, List<string>> kioskModeApps = new();
        public static Dictionary<string, List<string>> shellLauncherAccs = new();

        public static List<List<bool>> tileGrid = Grid.gridInit();
        public static List<string> allowedApps = new();
        public static List<string> autoLaunch = new();

        public static string lnkToExe(string lnk)
        {
            return linkedWin32Apps.FirstOrDefault(x => x.Value == lnk).Key;
        }

        public static void flushAll()
        {
            groups = new();
            linkedWin32Apps = new();
            allowedApps = new();
            uwpApps = new();
            addUwpApps = new();
            autoLaunch = new();
            kioskModeApps = new();
            tileGrid = Grid.gridInit();
        }
    }
}
