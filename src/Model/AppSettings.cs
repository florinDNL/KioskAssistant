using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.Json;

namespace kioskAssistant.Model
{
    internal sealed class AppSettings
    {
        public bool DarkMode { get; set; }
        public bool DpiAwareness { get; set; } = true;
        public bool RememberWindowSizes { get; set; }
        public Dictionary<string, SavedWindowSize> WindowSizes { get; set; } = new(StringComparer.Ordinal);
    }

    internal sealed class SavedWindowSize
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public Size ToSize() => new(Width, Height);

        public static SavedWindowSize From(Size size) => new()
        {
            Width = size.Width,
            Height = size.Height,
        };
    }

    internal static class AppSettingsStore
    {
        private static readonly string DirectoryPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "KioskAssistant");

        private static readonly string FilePath = Path.Combine(DirectoryPath, "settings.json");
        private static readonly JsonSerializerOptions JsonOptions = new() { WriteIndented = true };

        public static string LoadError { get; private set; }

        public static AppSettings Load()
        {
            if (!File.Exists(FilePath))
            {
                return new AppSettings();
            }

            try
            {
                string json = File.ReadAllText(FilePath);
                var settings = JsonSerializer.Deserialize<AppSettings>(json, JsonOptions);
                if (settings == null)
                {
                    throw new JsonException("The settings file did not contain an object.");
                }

                settings.WindowSizes ??= new Dictionary<string, SavedWindowSize>(StringComparer.Ordinal);
                return settings;
            }
            catch (Exception ex) when (ex is IOException or UnauthorizedAccessException or JsonException)
            {
                LoadError = ex.Message;
                return new AppSettings();
            }
        }

        public static void Save(AppSettings settings)
        {
            ArgumentNullException.ThrowIfNull(settings);
            Directory.CreateDirectory(DirectoryPath);
            string temporaryPath = FilePath + ".tmp";
            File.WriteAllText(temporaryPath, JsonSerializer.Serialize(settings, JsonOptions));
            File.Move(temporaryPath, FilePath, overwrite: true);
        }
    }
}
