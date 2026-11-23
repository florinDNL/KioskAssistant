using kioskAssistant.Model;
using kioskAssistant.UI;
using kioskAssistant.Xml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace kioskAssistant.Forms
{
	public partial class shellLauncher : Form
	{
		private const int AccountColumn = 0;
		private const int ProfileColumn = 1;

		// Account cells are displayed with a prefix that encodes the identifier type.
		private const string NamePrefix = "[n]";
		private const string SidPrefix = "[s]";
		private const string AutoLogonLabel = "Autologon";

		private readonly AppCatalog catalog;
		private readonly List<ShellLauncherProfile> profiles = new();

		public shellLauncher(AppCatalog catalog)
		{
			InitializeComponent();
			StartPosition = FormStartPosition.CenterScreen;
			genXmlBt.Enabled = false;
			this.catalog = catalog;
		}

		private static ShellLauncherAccount ParseAccount(string cell, string profileId)
		{
			if (cell == AutoLogonLabel) return new ShellLauncherAccount(ShellAccountType.AutoLogon, string.Empty, profileId);
			if (cell.StartsWith(SidPrefix)) return new ShellLauncherAccount(ShellAccountType.Sid, cell[SidPrefix.Length..], profileId);
			if (cell.StartsWith(NamePrefix)) return new ShellLauncherAccount(ShellAccountType.Name, cell[NamePrefix.Length..], profileId);
			throw new ArgumentException($"Unrecognised account '{cell}'.", nameof(cell));
		}

		private void nameBt_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(nameSidTb.Text))
			{
				accountsGv.Rows.Add(NamePrefix + nameSidTb.Text);
			}
		}

		private void sidBt_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(nameSidTb.Text))
			{
				accountsGv.Rows.Add(SidPrefix + nameSidTb.Text);
			}
		}

		private void remBt_Click(object sender, EventArgs e)
		{
			foreach (DataGridViewRow row in accountsGv.SelectedRows.Cast<DataGridViewRow>().ToList())
			{
				accountsGv.Rows.Remove(row);
				if (row.Cells[AccountColumn].Value.ToString() == AutoLogonLabel)
				{
					autologonBt.Enabled = true;
				}
			}
		}

		private void cShellbt_Click(object sender, EventArgs e)
		{
			var customShellForm = new customShell(catalog);
			if (customShellForm.ShowDialog() == DialogResult.OK)
			{
				profiles.Add(customShellForm.Profile);
				appProfileLb.Items.Add(customShellForm.Profile.Id);
			}
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

			foreach (DataGridViewRow row in accountsGv.SelectedRows)
			{
				row.Cells[ProfileColumn].Value = appProfileLb.SelectedItem.ToString();
			}
		}

		private void remCsBt_Click(object sender, EventArgs e)
		{
			if (appProfileLb.SelectedItem is not string profileId)
			{
				return;
			}

			profiles.RemoveAll(p => p.Id == profileId);
			AccountGrid.Unassign(accountsGv, ProfileColumn, profileId);
			appProfileLb.Items.Remove(profileId);
		}

		private void genXmlBt_Click(object sender, EventArgs e)
		{
			if (saveXML.ShowDialog() == DialogResult.Cancel)
			{
				return;
			}

			var config = new ShellLauncherConfiguration();
			config.Profiles.AddRange(profiles);

			// The same account listed twice keeps its first position and its last assignment.
			var assignments = new Dictionary<string, string>();
			foreach (DataGridViewRow row in accountsGv.Rows)
			{
				assignments[row.Cells[AccountColumn].Value.ToString()] = row.Cells[ProfileColumn].Value.ToString();
			}
			config.Accounts.AddRange(assignments.Select(a => ParseAccount(a.Key, a.Value)));

			string savePath = saveXML.FileName;
			try
			{
				ShellLauncherXmlBuilder.Build(config, catalog).Save(savePath);
			}
			catch (Exception ex) when (ex is IOException or UnauthorizedAccessException)
			{
				MessageBox.Show("Could not save the XML file:\n" + ex.Message, "Error");
				return;
			}
			MessageBox.Show("XML file saved to " + savePath, "Success");
		}

		private void autologonBt_Click(object sender, EventArgs e)
		{
			accountsGv.Rows.Add(AutoLogonLabel);
			autologonBt.Enabled = false;
		}

		#region Event Listeners
		private void accountsGv_CellValueChanged(object sender, DataGridViewCellEventArgs e) =>
			AccountGrid.RefreshGenerateButton(accountsGv, ProfileColumn, genXmlBt);

		private void accountsGv_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e) =>
			AccountGrid.RefreshGenerateButton(accountsGv, ProfileColumn, genXmlBt);

		private void accountsGv_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e) =>
			AccountGrid.RefreshGenerateButton(accountsGv, ProfileColumn, genXmlBt);

		#endregion

		private void toolTipLabel_MouseHover(object sender, EventArgs e)
		{
			string info = "- Name can be a local user or domain user. \n   (For Domain Users, the format is: domain\\userName)\n- SID Can be Local Group SID, Local User SID, or AD Group SID\n- Autologon will automatically create a local account (kioskuser0) and add it to the autologon registry\n- AAD is not supported for either name or SID";
			nameSidToolTip.Show(info, toolTipLabel);
		}
	}
}
