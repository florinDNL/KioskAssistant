#nullable enable

using System;
using System.Collections.Generic;

namespace kioskAssistant.Model
{
    /// <summary>Apps, users and groups discovered on the local machine.</summary>
    public sealed class AppCatalog
    {
        public AppCatalog(IDictionary<string, string> uwpApps, IEnumerable<string> localUsers, IEnumerable<string> localGroups)
        {
            UwpApps = new Dictionary<string, string>(uwpApps);
            LocalUsers = new List<string>(localUsers);
            LocalGroups = new List<string>(localGroups);
        }

        /// <summary>UWP display name to AppUserModelId. Manually added apps are appended here.</summary>
        public Dictionary<string, string> UwpApps { get; }
        public IReadOnlyList<string> LocalUsers { get; }
        public IReadOnlyList<string> LocalGroups { get; }

        public bool IsUwp(string app) => UwpApps.ContainsKey(app);

        /// <summary>Returns the AUMID for a known display name; otherwise assumes the value already is an AUMID.</summary>
        public string ResolveAumid(string app) => UwpApps.TryGetValue(app, out var aumid) ? aumid : app;

        /// <summary>Apps shown by default; others are only listed when "show all" is checked.</summary>
        public bool IsPrimaryUwpApp(string app)
        {
            string aumid = ResolveAumid(app);
            return aumid.Contains("!app", StringComparison.OrdinalIgnoreCase)
                || aumid.Contains("!microsoft", StringComparison.OrdinalIgnoreCase)
                || aumid.Contains("msedge", StringComparison.OrdinalIgnoreCase);
        }
    }
}
