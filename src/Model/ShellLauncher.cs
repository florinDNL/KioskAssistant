#nullable enable

using System.Collections.Generic;

namespace kioskAssistant.Model
{
    public enum ShellExitAction
    {
        RestartShell,
        RestartDevice,
        ShutdownDevice,
        DoNothing,
    }

    public sealed record ShellLauncherProfile(string Id, KioskApp Shell, bool AllAppsFullScreen, ShellExitAction ExitAction);

    public enum ShellAccountType
    {
        AutoLogon,
        Name,
        Sid,
    }

    public sealed record ShellLauncherAccount(ShellAccountType Type, string Value, string ProfileId);

    public sealed class ShellLauncherConfiguration
    {
        public List<ShellLauncherProfile> Profiles { get; } = new();
        public List<ShellLauncherAccount> Accounts { get; } = new();
    }
}
