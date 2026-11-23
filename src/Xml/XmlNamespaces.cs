#nullable enable

using System.Xml.Linq;

namespace kioskAssistant.Xml
{
    internal static class XmlNamespaces
    {
        public static readonly XNamespace AssignedAccess = "http://schemas.microsoft.com/AssignedAccess/2017/config";
        public static readonly XNamespace V2 = "http://schemas.microsoft.com/AssignedAccess/201810/config";
        public static readonly XNamespace V3 = "http://schemas.microsoft.com/AssignedAccess/2020/config";
        public static readonly XNamespace V4 = "http://schemas.microsoft.com/AssignedAccess/2021/config";
        public static readonly XNamespace Win11 = "http://schemas.microsoft.com/AssignedAccess/2022/config";

        public static readonly XNamespace LayoutModification = "http://schemas.microsoft.com/Start/2014/LayoutModification";
        public static readonly XNamespace FullDefaultLayout = "http://schemas.microsoft.com/Start/2014/FullDefaultLayout";
        public static readonly XNamespace StartLayout = "http://schemas.microsoft.com/Start/2014/StartLayout";

        public static readonly XNamespace ShellLauncher = "http://schemas.microsoft.com/ShellLauncher/2018/Configuration";
        public static readonly XNamespace ShellLauncherV2 = "http://schemas.microsoft.com/ShellLauncher/2019/Configuration";
    }
}
