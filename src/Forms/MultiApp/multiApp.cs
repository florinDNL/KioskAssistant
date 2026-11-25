using kioskAssistant.Model;
using kioskAssistant.UI;
using kioskAssistant.Xml;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace kioskAssistant
{
	public partial class multiApp : Form
	{
		private const int NameColumn = 0;
		private const int TypeColumn = 1;
		private const int ProfileColumn = 2;

		private readonly AppCatalog catalog;
		private readonly List<KioskModeProfile> kioskModeProfiles = new();
		private readonly List<MultiAppProfile> multiAppProfiles = new();
		private string autoLogonDisplayName;

		#region Form Initialization

		public multiApp(AppCatalog catalog)
		{
			InitializeComponent();
			StartPosition = FormStartPosition.CenterScreen;
			genXmlBt.Enabled = false;
			this.catalog = catalog;
		}

		#endregion

		private static AccountType RowType(DataGridViewRow row) => AccountGrid.FromLabel(row.Cells[TypeColumn].Value.ToString());

		#region Button Click Events

		private void addAppProfileBt_Click(object sender, EventArgs e)
		{
			var profileForm = new appProfile(catalog);
			if (profileForm.ShowDialog() == DialogResult.OK)
			{
				multiAppProfiles.Add(profileForm.Profile);
				appProfileLb.Items.Add(profileForm.Profile.Id);
			}
		}

		private void kModeBt_Click(object sender, EventArgs e)
		{
			var kModeForm = new kioskModeApp(catalog);
			if (kModeForm.ShowDialog() == DialogResult.OK)
			{
				kioskModeProfiles.Add(kModeForm.Profile);
				appProfileLb.Items.Add(kModeForm.Profile.Id);
			}
		}

		private void delAppProfileBt_Click(object sender, EventArgs e)
		{
			if (appProfileLb.SelectedItem is not string profileId)
			{
				return;
			}

			multiAppProfiles.RemoveAll(p => p.Id == profileId);
			kioskModeProfiles.RemoveAll(p => p.Id == profileId);
			AccountGrid.Unassign(accountsGv, ProfileColumn, profileId);
			appProfileLb.Items.Remove(profileId);
		}

		private void addGlobProfBt_Click(object sender, EventArgs e)
		{
			addGlobProfBt.Enabled = false;
			accountsGv.Rows.Add("Global Profile", AccountGrid.ToLabel(AccountType.GlobalProfile));
		}

		private void addAutoLogonAccBt_Click(object sender, EventArgs e)
		{
			var dispNameBox = new dispName();
			if (dispNameBox.ShowDialog() == DialogResult.OK)
			{
				autoLogonDisplayName = dispNameBox.dispNameTb.Text;
				accountsGv.Rows.Add("Auto Login", AccountGrid.ToLabel(AccountType.AutoLogon));
				addAutoLogonAccBt.Enabled = false;
			}
		}

		private void addUsrBt_Click(object sender, EventArgs e)
		{
			var userSelect = new userSelection(catalog);
			if (userSelect.ShowDialog() == DialogResult.OK)
			{
				AddAccountRow(userSelect.selectedUsr, AccountType.User, "User already added.");
			}
		}

		private void addGrpBt_Click(object sender, EventArgs e)
		{
			var groupSelect = new groupSelection(catalog);
			if (groupSelect.ShowDialog() == DialogResult.OK)
			{
				AddAccountRow(groupSelect.selectedGrp, groupSelect.groupType, "Group already added.");
			}
		}

		private void AddAccountRow(string name, AccountType type, string duplicateMessage)
		{
			bool exists = accountsGv.Rows.Cast<DataGridViewRow>()
				.Any(row => row.Cells[NameColumn].Value.ToString() == name && RowType(row) == type);
			if (exists)
			{
				MessageBox.Show(duplicateMessage, "Error");
				return;
			}
			accountsGv.Rows.Add(name, AccountGrid.ToLabel(type));
		}

		private void assignBt_Click(object sender, EventArgs e)
		{
			if (accountsGv.SelectedRows.Count == 0)
			{
				MessageBox.Show("Please select at least one user or group", "Nothing selected");
				return;
			}
			if (appProfileLb.SelectedIndex == -1)
			{
				MessageBox.Show("Please select an application profile to add", "No application profile selected");
				return;
			}

			string profileId = appProfileLb.SelectedItem.ToString();
			bool isKioskMode = kioskModeProfiles.Any(p => p.Id == profileId);

			foreach (DataGridViewRow row in accountsGv.SelectedRows)
			{
				if (isKioskMode && AccountGrid.IsGroup(RowType(row)))
				{
					MessageBox.Show("Kiosk-Mode App does not support Group assignment");
				}
				else
				{
					row.Cells[ProfileColumn].Value = profileId;
				}
			}
		}

		private void removeGrBt_Click(object sender, EventArgs e)
		{
			foreach (DataGridViewRow row in accountsGv.SelectedRows.Cast<DataGridViewRow>().ToList())
			{
				switch (RowType(row))
				{
					case AccountType.GlobalProfile:
						addGlobProfBt.Enabled = true;
						break;
					case AccountType.AutoLogon:
						autoLogonDisplayName = null;
						addAutoLogonAccBt.Enabled = true;
						break;
				}

				accountsGv.Rows.Remove(row);
			}
		}

		private void genXmlBt_Click(object sender, EventArgs e)
		{
			if (saveXML.ShowDialog() == DialogResult.Cancel)
			{
				return;
			}

			var config = new AssignedAccessConfiguration();
			config.KioskModeProfiles.AddRange(kioskModeProfiles);
			config.MultiAppProfiles.AddRange(multiAppProfiles);

			foreach (DataGridViewRow row in accountsGv.Rows)
			{
				AccountType type = RowType(row);
				string name = type == AccountType.AutoLogon ? autoLogonDisplayName : row.Cells[NameColumn].Value.ToString();
				config.Accounts.Add(new AccountAssignment(type, name, row.Cells[ProfileColumn].Value.ToString()));
			}

			string savePath = saveXML.FileName;
			try
			{
				AssignedAccessXmlBuilder.Build(config, catalog).Save(savePath);
			}
			catch (Exception ex) when (ex is IOException or UnauthorizedAccessException)
			{
				MessageBox.Show("Could not save the XML file:\n" + ex.Message, "Error");
				return;
			}

			DialogResult openResult = MessageBox.Show(
				this,
				"XML file saved to " + savePath + "\n\nOpen the file now?",
				"Success",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Question);
			if (openResult == DialogResult.Yes)
			{
				try
				{
					Process.Start(new ProcessStartInfo(savePath) { UseShellExecute = true });
				}
				catch (Exception ex) when (ex is System.ComponentModel.Win32Exception or InvalidOperationException or FileNotFoundException)
				{
					MessageBox.Show(this, "The XML file was saved, but it could not be opened:\n" + ex.Message,
						"Open file", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		#endregion


		#region Event Listeners
		private void accountsGv_CellValueChanged(object sender, DataGridViewCellEventArgs e) =>
			AccountGrid.RefreshGenerateButton(accountsGv, ProfileColumn, genXmlBt);

		private void accountsGv_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e) =>
			AccountGrid.RefreshGenerateButton(accountsGv, ProfileColumn, genXmlBt);

		private void accountsGv_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e) =>
			AccountGrid.RefreshGenerateButton(accountsGv, ProfileColumn, genXmlBt);

		#endregion
	}
}
