using kioskAssistant.Model;
using kioskAssistant.UI;
using System;
using System.Windows.Forms;

namespace kioskAssistant.Forms
{
	public partial class customShell : Form
	{
		private readonly KioskAppEditor editor;

		/// <summary>The saved profile; set when the dialog closes with OK.</summary>
		public ShellLauncherProfile Profile { get; private set; }

		public customShell(AppCatalog catalog)
		{
			InitializeComponent();
			StartPosition = FormStartPosition.CenterScreen;
			guidLabel.Text = AccountGrid.NewProfileId();
			editor = new KioskAppEditor(shellPanel, catalog);
			actionCb.SelectedIndex = 0;
			appTypeCb.SelectedIndex = KioskAppEditor.Win32;
		}

		private void appTypeCb_SelectedIndexChanged(object sender, EventArgs e)
		{
			editor.Show(appTypeCb.SelectedIndex, win32ExeLabel: "Shell:");
		}

		private void saveCsBt_Click(object sender, EventArgs e)
		{
			KioskApp shell = editor.ReadOrShowError();
			if (shell == null)
			{
				return;
			}

			var exitAction = Enum.Parse<ShellExitAction>(actionCb.SelectedItem.ToString());
			Profile = new ShellLauncherProfile(guidLabel.Text, shell, fullscreenCb.Checked, exitAction);
			this.DialogResult = DialogResult.OK;
			this.Close();
		}
	}
}
