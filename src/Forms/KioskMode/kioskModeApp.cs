using kioskAssistant.Model;
using kioskAssistant.UI;
using System;
using System.Windows.Forms;

namespace kioskAssistant
{
	public partial class kioskModeApp : Form
	{
		private readonly KioskAppEditor editor;

		/// <summary>The saved profile; set when the dialog closes with OK.</summary>
		public KioskModeProfile Profile { get; private set; }

		public kioskModeApp(AppCatalog catalog)
		{
			InitializeComponent();
			StartPosition = FormStartPosition.CenterScreen;
			guidLabel.Text = AccountGrid.NewProfileId();
			saveProfileBt.Enabled = false;
			editor = new KioskAppEditor(kModePanel, catalog);
		}

		#region Button Click Events

		private void saveProfileBt_Click(object sender, EventArgs e)
		{
			KioskApp app = editor.ReadOrShowError();
			if (app == null)
			{
				return;
			}

			Profile = new KioskModeProfile(guidLabel.Text, app);
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void cancelbt_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		#endregion

		private void appTypeCb_SelectedIndexChanged(object sender, EventArgs e)
		{
			editor.Show(appTypeCb.SelectedIndex);
			saveProfileBt.Enabled = true;
		}
	}
}
