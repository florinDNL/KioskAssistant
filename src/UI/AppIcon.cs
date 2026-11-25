using System;
using System.Drawing;
using System.IO;
using System.Reflection;

namespace kioskAssistant.UI
{
    internal static class AppIcon
    {
        public static Icon Current { get; } = LoadIcon(new Size(32, 32));
        public static Icon CurrentLarge { get; } = LoadIcon(new Size(256, 256));

        private static Icon LoadIcon(Size size)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            using Stream stream = assembly.GetManifestResourceStream("kioskAssistant.kA2.ico")
                ?? throw new InvalidOperationException("The embedded application icon could not be loaded.");
            return new Icon(stream, size);
        }
    }
}
