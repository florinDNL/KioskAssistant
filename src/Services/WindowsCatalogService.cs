#nullable enable

using kioskAssistant.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace kioskAssistant.Services
{
    public static class WindowsCatalogService
    {
        private const int ErrorMoreData = 234;
        private const int ErrorNoMoreItems = 259;
        private const int Success = 0;
        private const int MaxPreferredLength = -1;
        private const int AccountDisabled = 0x0002;

        public static AppCatalog LoadCatalog() => new(GetStartApps(), GetEnabledLocalUsers(), GetLocalGroups());

        public static Dictionary<string, string> GetStartApps()
        {
            var apps = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            Type shellType = Type.GetTypeFromProgID("Shell.Application")
                ?? throw new PlatformNotSupportedException("Windows Shell is unavailable.");
            object shell = Activator.CreateInstance(shellType)
                ?? throw new InvalidOperationException("Windows Shell could not be initialized.");

            try
            {
                dynamic appsFolder = ((dynamic)shell).NameSpace("shell:AppsFolder");
                foreach (dynamic item in appsFolder.Items())
                {
                    string? appId = item.ExtendedProperty("System.AppUserModel.ID")?.ToString();
                    if (string.IsNullOrWhiteSpace(appId)
                        || !appId.Contains('!')
                        || appId.Contains("!microsoftedge", StringComparison.OrdinalIgnoreCase)
                        || appId.Contains("msedge", StringComparison.OrdinalIgnoreCase))
                    {
                        continue;
                    }

                    string name = item.Name?.ToString() ?? appId;
                    if (apps.ContainsKey(name))
                    {
                        name += "_" + appId;
                    }
                    apps[name] = appId;
                }
            }
            finally
            {
                if (Marshal.IsComObject(shell))
                {
                    Marshal.ReleaseComObject(shell);
                }
            }

            return apps;
        }

        public static List<string> GetEnabledLocalUsers()
        {
            var users = new List<string>();
            IntPtr buffer = IntPtr.Zero;
            try
            {
                IntPtr resumeHandle = IntPtr.Zero;
                int status = NetUserEnum(
                    null, 0, FilterNormalAccount, out buffer, MaxPreferredLength,
                    out int entriesRead, out _, ref resumeHandle);
                ThrowIfUnexpected(status);

                int entrySize = Marshal.SizeOf<UserInfo0>();
                for (int index = 0; index < entriesRead; index++)
                {
                    UserInfo0 user = Marshal.PtrToStructure<UserInfo0>(IntPtr.Add(buffer, index * entrySize));
                    string? name = Marshal.PtrToStringUni(user.Name);
                    if (!string.IsNullOrEmpty(name) && IsEnabledLocalUser(name))
                    {
                        users.Add(name);
                    }
                }
            }
            finally
            {
                if (buffer != IntPtr.Zero)
                {
                    _ = NetApiBufferFree(buffer);
                }
            }

            users.Sort(StringComparer.OrdinalIgnoreCase);
            return users;
        }

        public static List<string> GetLocalGroups()
        {
            var groups = new List<string>();
            IntPtr buffer = IntPtr.Zero;
            try
            {
                IntPtr resumeHandle = IntPtr.Zero;
                int status = NetLocalGroupEnum(
                    null, 0, out buffer, MaxPreferredLength,
                    out int entriesRead, out _, ref resumeHandle);
                ThrowIfUnexpected(status);

                int entrySize = Marshal.SizeOf<LocalGroupInfo0>();
                for (int index = 0; index < entriesRead; index++)
                {
                    LocalGroupInfo0 group = Marshal.PtrToStructure<LocalGroupInfo0>(IntPtr.Add(buffer, index * entrySize));
                    string? name = Marshal.PtrToStringUni(group.Name);
                    if (!string.IsNullOrEmpty(name))
                    {
                        groups.Add(name);
                    }
                }
            }
            finally
            {
                if (buffer != IntPtr.Zero)
                {
                    _ = NetApiBufferFree(buffer);
                }
            }

            groups.Sort(StringComparer.OrdinalIgnoreCase);
            return groups;
        }

        public static string GetShortcutTarget(string lnkPath)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(lnkPath);
            var shellLink = (IShellLinkW)new ShellLink();
            try
            {
                ((IPersistFile)shellLink).Load(lnkPath, 0);
                var path = new StringBuilder(260);
                shellLink.GetPath(path, path.Capacity, IntPtr.Zero, 4);
                return path.ToString();
            }
            finally
            {
                if (Marshal.IsComObject(shellLink))
                {
                    Marshal.ReleaseComObject(shellLink);
                }
            }
        }

        private static bool IsEnabledLocalUser(string userName)
        {
            IntPtr buffer = IntPtr.Zero;
            try
            {
                int status = NetUserGetInfo(null, userName, 1, out buffer);
                ThrowIfUnexpected(status);
                return (Marshal.ReadInt32(buffer, 40) & AccountDisabled) == 0;
            }
            finally
            {
                if (buffer != IntPtr.Zero)
                {
                    _ = NetApiBufferFree(buffer);
                }
            }
        }

        private static void ThrowIfUnexpected(int status)
        {
            if (status != Success && status != ErrorMoreData && status != ErrorNoMoreItems)
            {
                throw new Win32Exception(status, "The local Windows catalog could not be queried.");
            }
        }

        [StructLayout(LayoutKind.Explicit, Size = 8)]
        private struct UserInfo0
        {
            [FieldOffset(0)] public IntPtr Name;
        }

        [StructLayout(LayoutKind.Explicit, Size = 8)]
        private struct LocalGroupInfo0
        {
            [FieldOffset(0)] public IntPtr Name;
        }

        [DllImport("netapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern int NetUserEnum(
            string? serverName, int level, int filter, out IntPtr buffer,
            int preferredMaximumLength, out int entriesRead, out int totalEntries, ref IntPtr resumeHandle);

        [DllImport("netapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern int NetUserGetInfo(
            string? serverName, string userName, int level, out IntPtr buffer);

        [DllImport("netapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern int NetLocalGroupEnum(
            string? serverName, int level, out IntPtr buffer, int preferredMaximumLength,
            out int entriesRead, out int totalEntries, ref IntPtr resumeHandle);

        [DllImport("netapi32.dll")]
        private static extern int NetApiBufferFree(IntPtr buffer);

        private const int FilterNormalAccount = 0x0002;

        [ComImport, Guid("00021401-0000-0000-C000-000000000046")]
        private class ShellLink
        {
        }

        [ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("000214F9-0000-0000-C000-000000000046")]
        private interface IShellLinkW
        {
            void GetPath([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder path, int maxPath, IntPtr findData, uint flags);
            void GetIDList(out IntPtr idList);
            void SetIDList(IntPtr idList);
            void GetDescription([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder name, int maxName);
            void SetDescription([MarshalAs(UnmanagedType.LPWStr)] string name);
            void GetWorkingDirectory([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder directory, int maxPath);
            void SetWorkingDirectory([MarshalAs(UnmanagedType.LPWStr)] string directory);
            void GetArguments([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder arguments, int maxPath);
            void SetArguments([MarshalAs(UnmanagedType.LPWStr)] string arguments);
            void GetHotKey(out short hotKey);
            void SetHotKey(short hotKey);
            void GetShowCmd(out int showCmd);
            void SetShowCmd(int showCmd);
            void GetIconLocation([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder iconPath, int iconPathLength, out int iconIndex);
            void SetIconLocation([MarshalAs(UnmanagedType.LPWStr)] string iconPath, int iconIndex);
            void SetRelativePath([MarshalAs(UnmanagedType.LPWStr)] string relativePath, uint reserved);
            void Resolve(IntPtr hwnd, uint flags);
            void SetPath([MarshalAs(UnmanagedType.LPWStr)] string file);
        }

        [ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("0000010b-0000-0000-C000-000000000046")]
        private interface IPersistFile
        {
            void GetClassID(out Guid classId);
            [PreserveSig]
            int IsDirty();
            void Load([MarshalAs(UnmanagedType.LPWStr)] string fileName, uint mode);
            void Save([MarshalAs(UnmanagedType.LPWStr)] string fileName, bool remember);
            void SaveCompleted([MarshalAs(UnmanagedType.LPWStr)] string fileName);
            void GetCurFile([MarshalAs(UnmanagedType.LPWStr)] out string fileName);
        }
    }
}
