using kioskAssistant.Controls;
using kioskAssistant.Model;
using System;
using System.Windows.Forms;

namespace kioskAssistant.UI
{
    /// <summary>
    /// Hosts the Edge / UWP / Win32 editor controls inside a panel and reads the result back as a <see cref="KioskApp"/>.
    /// Shared by the kiosk-mode app and custom shell dialogs.
    /// </summary>
    internal sealed class KioskAppEditor
    {
        public const int Edge = 0;
        public const int Uwp = 1;
        public const int Win32 = 2;

        private readonly Panel host;
        private readonly AppCatalog catalog;
        private Func<(KioskApp App, string Error)> read = () => (null, "No application type selected");

        public KioskAppEditor(Panel host, AppCatalog catalog)
        {
            this.host = host;
            this.catalog = catalog;
        }

        public void Show(int appType, string win32ExeLabel = null)
        {
            host.Controls.Clear();

            switch (appType)
            {
                case Edge:
                    var edge = new EdgeUserControl();
                    host.Controls.Add(edge);
                    read = () => string.IsNullOrEmpty(edge.urlTb.Text)
                        ? (null, "No URL added")
                        : (new EdgeKioskApp(edge.urlTb.Text, edge.idleTb.Text, EdgeKioskApp.ParseKioskType(edge.browsingCb.SelectedItem?.ToString())), null);
                    break;

                case Uwp:
                    var uwp = new UwpUserControl(catalog);
                    host.Controls.Add(uwp);
                    read = () => string.IsNullOrEmpty(uwp.appCb.Text)
                        ? (null, "No App selected")
                        : (new UwpKioskApp(uwp.appCb.Text), null);
                    break;

                case Win32:
                    var win32 = new win32UserControl();
                    if (win32ExeLabel != null)
                    {
                        win32.exeLb.Text = win32ExeLabel;
                    }
                    host.Controls.Add(win32);
                    read = () => string.IsNullOrEmpty(win32.exeTb.Text)
                        ? (null, "No executable selected")
                        : (new Win32KioskApp(win32.exeTb.Text, win32.argTb.Text), null);
                    break;
            }
        }

        /// <summary>Returns the configured app, or null and shows the validation error.</summary>
        public KioskApp ReadOrShowError()
        {
            var (app, error) = read();
            if (app == null)
            {
                MessageBox.Show(error);
            }
            return app;
        }
    }
}
