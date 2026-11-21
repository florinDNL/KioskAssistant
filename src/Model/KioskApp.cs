#nullable enable

namespace kioskAssistant.Model
{
    public enum EdgeKioskType
    {
        DigitalSignage,
        PublicBrowsing,
    }

    /// <summary>A single application that runs as a kiosk app or a custom shell.</summary>
    public abstract record KioskApp;

    public sealed record EdgeKioskApp(string Url, string IdleTimeoutMinutes, EdgeKioskType KioskType) : KioskApp
    {
        public const string ExecutablePath = @"%ProgramFiles(x86)%\Microsoft\Edge\Application\msedge.exe";

        public static EdgeKioskType ParseKioskType(string? displayName) =>
            displayName == "Public Browsing" ? EdgeKioskType.PublicBrowsing : EdgeKioskType.DigitalSignage;

        public string BuildArguments()
        {
            string kioskType = KioskType == EdgeKioskType.PublicBrowsing ? "public-browsing" : "fullscreen";
            return $"--no-first-run --kiosk {CommandLine.QuoteIfNeeded(Url)} --edge-kiosk-type={kioskType} --kiosk-idle-timeout-minutes={IdleTimeoutMinutes}";
        }
    }

    /// <param name="App">Display name from the app catalog, or a raw AUMID.</param>
    public sealed record UwpKioskApp(string App) : KioskApp;

    public sealed record Win32KioskApp(string Path, string Arguments) : KioskApp;

    public static class CommandLine
    {
        public static string QuoteIfNeeded(string value) =>
            value.Length > 0 && value.IndexOfAny(new[] { ' ', '\t' }) >= 0 && !(value.StartsWith('"') && value.EndsWith('"'))
                ? $"\"{value}\""
                : value;

        public static string Join(string executable, string? arguments) =>
            string.IsNullOrEmpty(arguments) ? QuoteIfNeeded(executable) : $"{QuoteIfNeeded(executable)} {arguments}";
    }
}
