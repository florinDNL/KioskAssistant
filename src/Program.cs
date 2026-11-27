using kioskAssistant.Forms;
using kioskAssistant.Model;
using kioskAssistant.Services;
using kioskAssistant.UI;
using System;
using System.Threading;
using System.Windows.Forms;

namespace kioskAssistant
{
    static class Program
    {
        static Form splashScreen;
        static Form mainWindow;
        static bool darkModeEnabledAtStartup;

        [STAThread]
        static void Main()
        {
            AppSettings settings = AppSettingsStore.Load();
            Application.SetHighDpiMode(settings.DpiAwareness
                ? HighDpiMode.PerMonitorV2
                : HighDpiMode.DpiUnaware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            darkModeEnabledAtStartup = settings.DarkMode;
            ProportionalResizing.Configure(settings);
            Application.Idle += (_, _) =>
            {
                ProportionalResizing.ApplyOpenForms();
                if (darkModeEnabledAtStartup)
                {
                    DarkTheme.ApplyOpenForms();
                }
            };

            splashScreen = new splashScreen();
            if (darkModeEnabledAtStartup)
            {
                DarkTheme.Apply(splashScreen);
            }

            //Load the splash screen in a separate thread
            Thread t = new(new ThreadStart(() => Application.Run(splashScreen)));
            t.SetApartmentState(ApartmentState.STA);
            t.Start();

            //Query apps, users and groups during the splash screen, before loading the main form
            AppCatalog catalog = WindowsCatalogService.LoadCatalog();
            mainWindow = new startWindow(catalog, settings);
            ProportionalResizing.Apply(mainWindow);
            if (darkModeEnabledAtStartup)
            {
                DarkTheme.Apply(mainWindow);
            }

            // Bring the visible main window forward after the splash screen has closed.
            mainWindow.Shown += mainWindow_Shown;
            Application.Run(mainWindow);
        }

        // Close the splash screen and bring the visible main window into focus.
        private static void mainWindow_Shown(object sender, EventArgs e)
        {
            splashScreen.Invoke(new Action(splashScreen.Close));
            if (!string.IsNullOrEmpty(AppSettingsStore.LoadError))
            {
                MessageBox.Show(mainWindow, $"The settings file could not be read. Defaults are being used.\n\n{AppSettingsStore.LoadError}",
                    "Settings warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            mainWindow.TopMost = true;
            mainWindow.WindowState = FormWindowState.Normal;
            mainWindow.BringToFront();
            mainWindow.Activate();
            mainWindow.Focus();
            mainWindow.BeginInvoke(() => mainWindow.TopMost = false);
        }
    }
}
