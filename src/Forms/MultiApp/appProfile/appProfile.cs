using kioskAssistant.Forms.MultiApp;
using kioskAssistant.Model;
using kioskAssistant.Services;
using kioskAssistant.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace kioskAssistant
{
	public partial class appProfile : Form
	{
		private readonly AppCatalog catalog;

		// UWP apps hidden unless "show all" is checked.
		private readonly List<string> extraUwpApps = new();
		// Executable path -> .lnk path.
		private readonly Dictionary<string, string> linkedWin32Apps = new();
		private readonly List<StartGroup> groups = new();
		// Apps moved out of the pickers into a Start group; still allowed in the profile.
		private readonly List<string> groupedApps = new();
		private AutoLaunchApp autoLaunchApp;

		/// <summary>The saved profile; set when the dialog closes with OK.</summary>
		public MultiAppProfile Profile { get; private set; }

		#region Form Initialization

		public appProfile(AppCatalog catalog)
		{
			InitializeComponent();
			StartPosition = FormStartPosition.CenterScreen;
			this.catalog = catalog;
			guidLabel.Text = AccountGrid.NewProfileId();

			foreach (string app in catalog.UwpApps.Keys)
			{
				if (catalog.IsPrimaryUwpApp(app))
				{
					uwpAppClb.Items.Add(app);
				}
				else
				{
					extraUwpApps.Add(app);
				}
			}
		}

		#endregion

		private string LnkToExe(string lnk) => linkedWin32Apps.FirstOrDefault(x => x.Value == lnk).Key;

		#region Button Click Events

		private void addWin32AppBt_Click(object sender, EventArgs e)
		{
			DialogResult result = addExeDialog.ShowDialog();
			string executable = addExeDialog.FileName;
			if (result == DialogResult.Cancel)
			{
				return;
			}

			if (win32AppLb.FindStringExact(executable) != ListBox.NoMatches || linkedWin32Apps.ContainsKey(executable))
			{
				MessageBox.Show("This executable has alredy been added", "Duplicate Entry");
			}
			else
			{
				win32AppLb.Items.Add(executable);
			}
		}

		private void remWin32AppBt_Click(object sender, EventArgs e)
		{
			if (win32AppLb.SelectedIndex == -1)
			{
				MessageBox.Show("No entry selected.", "Error");
				return;
			}

			string exe = win32AppLb.SelectedItem.ToString();
			win32AppLb.Items.Remove(exe);
			if (linkedWin32Apps.TryGetValue(exe, out string lnk))
			{
				lnkFileLb.Items.Remove(lnk);
				linkedWin32Apps.Remove(exe);
			}
		}

		private void addAppGroupBt_Click(object sender, EventArgs e)
		{
			var available = uwpAppClb.CheckedItems.Cast<object>().Concat(lnkFileLb.Items.Cast<object>()).ToList();
			var slForm = new startGroup(available, groups.Select(g => g.Name).ToList());

			if (slForm.ShowDialog(this) == DialogResult.Cancel)
			{
				return;
			}

			StartGroup group = slForm.Group;
			groupsLv.Items.Add(group.Name).SubItems.Add(string.Join(", ", group.Tiles.Select(t => t.App)));
			groupsLv.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
			groups.Add(group);

			foreach (var item in slForm.AddedApps)
			{
				if (uwpAppClb.Items.Contains(item))
				{
					extraUwpApps.Remove(item.ToString());
					uwpAppClb.Items.Remove(item);
					groupedApps.Add(item.ToString());
				}
				else if (lnkFileLb.Items.Contains(item))
				{
					string linkedExe = LnkToExe(item.ToString());
					win32AppLb.Items.Remove(linkedExe);
					lnkFileLb.Items.Remove(item);
					groupedApps.Add(linkedExe);
				}
			}
		}

		private void addLnkBt_Click(object sender, EventArgs e)
		{
			if (win32AppLb.Items.Count == 0)
			{
				MessageBox.Show("No executable added", "Error");
				return;
			}
			if (win32AppLb.Items.Count == lnkFileLb.Items.Count)
			{
				MessageBox.Show("No need to add more icons than executables", "Sufficient links provided");
				return;
			}

			if (addLnkDialog.ShowDialog() == DialogResult.Cancel)
			{
				return;
			}

			string linkFile = addLnkDialog.FileName;
			string linkedExe = WindowsCatalogService.GetShortcutTarget(linkFile);
			if (!win32AppLb.Items.Contains(linkedExe))
			{
				string message = "This link file does not correspond to any of the added Win32 Applications.\n\nThe executable in this lnk is: " + linkedExe;
				MessageBox.Show(message, "Wrong link");
			}
			else
			{
				lnkFileLb.Items.Add(linkFile);
				linkedWin32Apps.Add(linkedExe, linkFile);
			}
		}

		private void remLnkBt_Click(object sender, EventArgs e)
		{
			if (lnkFileLb.SelectedIndex == -1)
			{
				MessageBox.Show("No entry selected.", "Error");
				return;
			}

			string lnk = lnkFileLb.SelectedItem.ToString();
			string linkedExe = LnkToExe(lnk);
			lnkFileLb.Items.Remove(lnk);
			linkedWin32Apps.Remove(linkedExe);
		}

		private void remGrpBt_Click(object sender, EventArgs e)
		{
			if (groupsLv.SelectedItems.Count == 0)
			{
				MessageBox.Show("Please select a group to remove", "No group selected");
				return;
			}

			foreach (ListViewItem item in groupsLv.SelectedItems.Cast<ListViewItem>().ToList())
			{
				StartGroup group = groups.First(g => g.Name == item.Text);

				// Return each app to the picker it originally came from.
				foreach (string app in group.Tiles.Select(t => t.App))
				{
					if (app.Contains(".lnk"))
					{
						string linkedExe = LnkToExe(app);
						win32AppLb.Items.Add(linkedExe);
						lnkFileLb.Items.Add(app);
						groupedApps.Remove(linkedExe);
					}
					else if (catalog.IsPrimaryUwpApp(app))
					{
						uwpAppClb.Items.Add(app);
						groupedApps.Remove(app);
					}
					else
					{
						extraUwpApps.Add(app);
						if (showAllCb.Checked)
						{
							uwpAppClb.Items.Add(app);
						}
						groupedApps.Remove(app);
					}
				}

				groups.Remove(group);
				groupsLv.Items.Remove(item);
			}
		}

		private void cancelBt_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void saveProfBt_Click(object sender, EventArgs e)
		{
			if (win10_cb.Checked && groupsLv.Items.Count == 0)
			{
				MessageBox.Show("For Windows 10, you need to add at least 1 application group to the start menu", "No application added");
				return;
			}

			DialogResult save = MessageBox.Show("Save Application Profile? You won't be able to modify it afterwards.", "Confirmation", MessageBoxButtons.OKCancel);
			if (save == DialogResult.OK)
			{
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
		}

		private void confAutoLaunchBt_Click(object sender, EventArgs e)
		{
			var candidates = uwpAppClb.CheckedItems.Cast<object>()
				.Concat(win32AppLb.Items.Cast<object>())
				.Concat(groupedApps);

			var alForm = new autoLaunch(candidates, autoLaunchApp);
			alForm.ShowDialog();
			autoLaunchApp = alForm.Selection;
		}

		private void manUwpBt_Click(object sender, EventArgs e)
		{
			var manUwpAdd = new addUwpMan(catalog);
			if (manUwpAdd.ShowDialog() == DialogResult.OK)
			{
				uwpAppClb.Items.Add(manUwpAdd.AddedApp, true);
				showAllCb.Checked = true;
			}
		}

		private void manExeBt_Click(object sender, EventArgs e)
		{
			var manExeAdd = new addExeMan(exe => win32AppLb.Items.Contains(exe));
			if (manExeAdd.ShowDialog() != DialogResult.OK)
			{
				return;
			}

			win32AppLb.Items.Add(manExeAdd.ExePath);
			if (!string.IsNullOrEmpty(manExeAdd.LnkPath) && !lnkFileLb.Items.Contains(manExeAdd.LnkPath))
			{
				lnkFileLb.Items.Add(manExeAdd.LnkPath);
				linkedWin32Apps.Add(manExeAdd.ExePath, manExeAdd.LnkPath);
			}
		}

		#endregion


		#region Checkbox Events

		private void showAllCb_CheckedChanged(object sender, EventArgs e)
		{
			foreach (string app in extraUwpApps)
			{
				if (showAllCb.Checked)
				{
					uwpAppClb.Items.Add(app);
				}
				else
				{
					uwpAppClb.Items.Remove(app);
				}
			}
		}

		private void noRestrictCb_CheckedChanged(object sender, EventArgs e)
		{
			if (noRestrictCb.Checked)
			{
				dlPermCb.Checked = false;
				dlPermCb.Enabled = false;
				rdPermCb.Checked = false;
				rdPermCb.Enabled = false;
			}
			else
			{
				dlPermCb.Enabled = true;
				rdPermCb.Enabled = true;
			}
		}

		// At least one Windows version must stay selected; Start groups only apply to Windows 10.
		private void win10_CheckedChanged(object sender, EventArgs e)
		{
			if (!win10_cb.Checked)
			{
				if (!win11_cb.Checked)
				{
					win10_cb.Checked = true;
				}
				else
				{
					addAppGroupBt.Enabled = false;
				}
			}
			else
			{
				addAppGroupBt.Enabled = true;
			}
		}

		private void win11_CheckedChanged(object sender, EventArgs e)
		{
			if (!win10_cb.Checked && !win11_cb.Checked)
			{
				win11_cb.Checked = true;
			}
		}

		#endregion


		#region Form Closure Events

		private void appProfile_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (this.DialogResult == DialogResult.Cancel)
			{
				if (groupsLv.Items.Count > 0)
				{
					DialogResult res = MessageBox.Show("Are you sure you want to quit? Changes will not be saved", "Confirm", MessageBoxButtons.YesNo);
					if (res == DialogResult.No)
					{
						e.Cancel = true;
					}
				}
			}
			else if (this.DialogResult == DialogResult.OK)
			{
				var allowedApps = groupedApps
					.Concat(uwpAppClb.CheckedItems.Cast<object>().Select(i => i.ToString()))
					.Concat(win32AppLb.Items.Cast<object>().Select(i => i.ToString()))
					.ToList();

				Profile = new MultiAppProfile
				{
					Id = guidLabel.Text,
					ShowTaskbar = showTaskbarCb.Checked,
					AllowDownloads = dlPermCb.Checked,
					AllowRemovableDrives = rdPermCb.Checked,
					NoFileExplorerRestriction = noRestrictCb.Checked,
					TargetsWindows10 = win10_cb.Checked,
					TargetsWindows11 = win11_cb.Checked,
					AllowedApps = allowedApps,
					StartGroups = groups.ToList(),
					AutoLaunch = autoLaunchApp,
				};
			}
		}

		#endregion
	}
}
