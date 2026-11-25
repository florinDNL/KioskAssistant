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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            AppSettings settings = AppSettingsStore.Load();
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
            AppCatalog catalog = PowerShellService.LoadCatalog();
            mainWindow = new startWindow(catalog, settings);
            ProportionalResizing.Apply(mainWindow);
            if (darkModeEnabledAtStartup)
            {
                DarkTheme.Apply(mainWindow);
            }

            //Add the LoadCompleted event to mainWindow's Load Event Handler
            mainWindow.Load += mainWindow_LoadCompleted;
            Application.Run(mainWindow);
        }

        //Close splashScreen, bring mainWindow into focus
        private static void mainWindow_LoadCompleted(object sender, EventArgs e)
        {
            splashScreen.Invoke(new Action(splashScreen.Close));
            if (!string.IsNullOrEmpty(AppSettingsStore.LoadError))
            {
                MessageBox.Show(mainWindow, $"The settings file could not be read. Defaults are being used.\n\n{AppSettingsStore.LoadError}",
                    "Settings warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            mainWindow.Activate();
            mainWindow.Focus();
        }
    }
}
