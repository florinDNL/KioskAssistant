using kioskAssistant.Forms;
using kioskAssistant.Model;
using kioskAssistant.Services;
using System;
using System.Threading;
using System.Windows.Forms;

namespace kioskAssistant
{
    static class Program
    {
        static Form splashScreen;
        static Form mainWindow;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            splashScreen = new splashScreen();

            //Load the splash screen in a separate thread
            Thread t = new(new ThreadStart(() => Application.Run(splashScreen)));
            t.SetApartmentState(ApartmentState.STA);
            t.Start();

            //Query apps, users and groups during the splash screen, before loading the main form
            AppCatalog catalog = PowerShellService.LoadCatalog();
            mainWindow = new startWindow(catalog);

            //Add the LoadCompleted event to mainWindow's Load Event Handler
            mainWindow.Load += mainWindow_LoadCompleted;
            Application.Run(mainWindow);
        }

        //Close splashScreen, bring mainWindow into focus
        private static void mainWindow_LoadCompleted(object sender, EventArgs e)
        {
            splashScreen.Invoke(new Action(splashScreen.Close));
            mainWindow.Activate();
            mainWindow.Focus();
        }
    }
}
