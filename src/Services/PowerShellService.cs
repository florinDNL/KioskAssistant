#nullable enable

using kioskAssistant.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace kioskAssistant.Services
{
    /// <summary>Queries the local machine through an in-process PowerShell runspace.</summary>
    public static class PowerShellService
    {
        public static AppCatalog LoadCatalog() => new(GetStartApps(), GetEnabledLocalUsers(), GetLocalGroups());

        public static Dictionary<string, string> GetStartApps()
        {
            var apps = new Dictionary<string, string>();

            using var ps = PowerShell.Create();
            // Execution policy is scoped to this runspace only; needed to auto-load the StartLayout module.
            ps.AddScript("Set-ExecutionPolicy -Scope Process -ExecutionPolicy Unrestricted");
            ps.AddStatement();
            ps.AddCommand("Get-StartApps");

            foreach (PSObject result in ps.Invoke())
            {
                string instance = result.ToString();
                string name = result.Members["Name"].Value.ToString()!;
                string appId = result.Members["AppID"].Value.ToString()!;

                bool isPackagedApp = instance.Contains('!')
                    && !instance.Contains("!microsoftedge", StringComparison.OrdinalIgnoreCase)
                    && !instance.Contains("msedge", StringComparison.OrdinalIgnoreCase);
                if (!isPackagedApp)
                {
                    continue;
                }

                if (apps.ContainsKey(name))
                {
                    name += "_" + appId;
                }
                apps.Add(name, appId);
            }

            return apps;
        }

        public static List<string> GetEnabledLocalUsers()
        {
            using var ps = PowerShell.Create();
            ps.AddCommand("Get-LocalUser");

            // Disabled built-ins (Administrator, DefaultAccount, Guest, ...) are filtered out.
            return ps.Invoke()
                .Where(r => r.Members["Enabled"].Value?.ToString() == "True")
                .Select(r => r.Members["Name"].Value.ToString()!)
                .ToList();
        }

        public static List<string> GetLocalGroups()
        {
            using var ps = PowerShell.Create();
            ps.AddCommand("Get-LocalGroup");
            return ps.Invoke().Select(r => r.Members["Name"].Value.ToString()!).ToList();
        }

        public static string GetShortcutTarget(string lnkPath)
        {
            using var ps = PowerShell.Create();
            // Pass the path as a parameter rather than splicing it into the script text.
            ps.AddScript("param($path) (New-Object -ComObject WScript.Shell).CreateShortcut($path).TargetPath")
              .AddParameter("path", lnkPath);
            return ps.Invoke().FirstOrDefault()?.ToString() ?? string.Empty;
        }
    }
}
