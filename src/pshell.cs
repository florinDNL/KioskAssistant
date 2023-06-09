﻿using System.Collections.Generic;
using System.Management.Automation;

namespace powershellApp
{
    public class Commands
    {
        public static Dictionary<string, string> GetApps()
        {
            Dictionary<string, string> allUwpApps = new();


            PowerShell ps = PowerShell.Create();
            string script = "Set-ExecutionPolicy -Scope Process -ExecutionPolicy Unrestricted"; //Set execution policy only for the instance of powershell spawned by the process 
            ps.AddScript(script);
            ps.AddStatement();
            ps.AddCommand("Get-StartApps");
            foreach (PSObject result in ps.Invoke())
            {
                string appInstance = result.ToString().ToLower();
                string name = result.Members["Name"].Value.ToString();
                string appId = result.Members["AppID"].Value.ToString();
                if (appInstance.Contains("!") & !appInstance.Contains("!microsoftedge") & !appInstance.Contains("msedge"))
                {
                    if (allUwpApps.ContainsKey(name))
                    {
                        name += "_" + appId;
                    }

                    allUwpApps.Add(name, appId);
                }
            }
            return allUwpApps;
        }

        public static List<string> GetUsers()
        {
            List<string> usersList = new();
            PowerShell ps = PowerShell.Create();
            ps.AddCommand("Get-LocalUser");
            foreach (PSObject result in ps.Invoke())
            {
                if (result.Members["Enabled"].Value.ToString() == "True") //Filter out Administrator, Default User, etc...
                {
                    usersList.Add(result.Members["Name"].Value.ToString());
                }
            }
            return usersList;
        }

        public static List<string> GetGroups()
        {
            List<string> groupsList = new();
            PowerShell ps = PowerShell.Create();
            ps.AddCommand("Get-LocalGroup");
            foreach (PSObject result in ps.Invoke())
            {
                groupsList.Add(result.Members["Name"].Value.ToString());
            }
            return groupsList;
        }

        public static string GetPathFromLnk(string lnkPath)
        {
            PowerShell ps = PowerShell.Create();
            string script = "(New-Object -ComObject WScript.Shell).CreateShortcut('" + lnkPath + "').TargetPath";
            ps.AddScript(script);
            string exeFile = ps.Invoke()[0].ToString();

            return (exeFile);
        }
    }
}