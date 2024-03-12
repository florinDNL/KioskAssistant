using allGlobals;
using kioskAssistant.Forms.MultiApp;
using powershellApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace kioskAssistant
{
    public partial class appProfile : Form
    {
        #region Form Initialization

        public appProfile()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            guidLabel.Text = Globals.GetGUID();

            foreach (string app in Globals.allUwpApps.Keys)
            {
                if (Globals.allUwpApps[app].ToLower().Contains("!app") | Globals.allUwpApps[app].ToLower().Contains("!microsoft") | Globals.allUwpApps[app].ToLower().Contains("msedge"))
                {
                    perFormObjects.uwpApps.Add(app);
                }
                else
                {
                    perFormObjects.addUwpApps.Add(app);
                }
            }

            //Populate Apps Checkbox List 
            foreach (string app in perFormObjects.uwpApps)
            {
                uwpAppClb.Items.Add(app);
            }
        }

        #endregion


        #region Button Click Events

        private void addWin32AppBt_Click(object sender, EventArgs e)
        {
            DialogResult result = addExeDialog.ShowDialog();
            string executable = addExeDialog.FileName;
            if (result == DialogResult.Cancel)
            {

            }
            else if (!(win32AppLb.FindStringExact(executable) == ListBox.NoMatches) | perFormObjects.linkedWin32Apps.ContainsKey(executable)) //Check if item exists in list box or group
            {
                string message = "This executable has alredy been added";
                string caption = "Duplicate Entry";
                MessageBox.Show(message, caption);
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
                string message = "No entry selected.";
                string caption = "Error";
                MessageBox.Show(message, caption);
            }
            else
            {
                var currItem = win32AppLb.SelectedItem;
                win32AppLb.Items.Remove(currItem);
                if (perFormObjects.linkedWin32Apps.ContainsKey(currItem.ToString()))
                {
                    lnkFileLb.Items.Remove(perFormObjects.linkedWin32Apps[currItem.ToString()]);
                    perFormObjects.linkedWin32Apps.Remove(currItem.ToString());
                }
            }
        }

        private void addAppGroupBt_Click(object sender, EventArgs e)
        {
            var slForm = new startGroup();

            foreach (var item in uwpAppClb.CheckedItems)
            {
                slForm.allAppsLb.Items.Add(item);
            }

            foreach (var item in lnkFileLb.Items)
            {
                slForm.allAppsLb.Items.Add(item);
            }

            DialogResult res = slForm.ShowDialog(this);

            if (!(res == DialogResult.Cancel))
            {
                groupsLv.Items.Add(slForm.nameTb.Text).SubItems.Add(string.Join(", ", slForm.group.Keys.ToArray()));
                groupsLv.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                perFormObjects.groups.Add(slForm.nameTb.Text, slForm.group);

                foreach (var item in slForm.addedAppsLb.Items)
                {
                    if (uwpAppClb.Items.Contains(item))
                    {
                        if (perFormObjects.addUwpApps.Contains(item.ToString()))
                        {
                            perFormObjects.addUwpApps.Remove(item.ToString());
                        }
                        uwpAppClb.Items.Remove(item);
                        perFormObjects.allowedApps.Add(item.ToString());
                    }
                    else if (lnkFileLb.Items.Contains(item))
                    {
                        string linkedExe = perFormObjects.lnkToExe(item.ToString());
                        win32AppLb.Items.Remove(linkedExe);
                        lnkFileLb.Items.Remove(item);
                        perFormObjects.allowedApps.Add(linkedExe);
                    }
                }
            }
        }

        private void addLnkBt_Click(object sender, EventArgs e)
        {

            if (win32AppLb.Items.Count == 0)
            {
                string message = "No executable added";
                string caption = "Error";
                MessageBox.Show(message, caption);
            }
            else if (win32AppLb.Items.Count == lnkFileLb.Items.Count)
            {
                string message = "No need to add more icons than executables";
                string caption = "Sufficient links provided";
                MessageBox.Show(message, caption);
            }
            else
            {
                DialogResult result = addLnkDialog.ShowDialog();
                string linkFile = addLnkDialog.FileName;
                if (!(result == DialogResult.Cancel))
                {
                    string linkedExe = Commands.GetPathFromLnk(linkFile);
                    if (!win32AppLb.Items.Contains(linkedExe))
                    {
                        string message = "This link file does not correspond to any of the added Win32 Applications.\n\nThe executable in this lnk is: " + linkedExe;
                        string caption = "Wrong link";
                        MessageBox.Show(message, caption);
                    }
                    else
                    {
                        lnkFileLb.Items.Add(linkFile);
                        perFormObjects.linkedWin32Apps.Add(linkedExe, linkFile);
                    }
                }
            }
        }

        private void remLnkBt_Click(object sender, EventArgs e)
        {
            if (lnkFileLb.SelectedIndex == -1)
            {
                string message = "No entry selected.";
                string caption = "Error";
                MessageBox.Show(message, caption);
            }
            else
            {
                var currItem = lnkFileLb.SelectedItem;
                string linkedExe = perFormObjects.lnkToExe(currItem.ToString());
                lnkFileLb.Items.Remove(currItem);
                perFormObjects.linkedWin32Apps.Remove(linkedExe);
            }
        }

        private void remGrpBt_Click(object sender, EventArgs e)
        {
            if (groupsLv.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a group to remove", "No group selected");
            }
            else
            {
                foreach (ListViewItem group in groupsLv.SelectedItems)
                {
                    foreach (string app in perFormObjects.groups[group.Text].Keys)
                    {
                        if (app.Contains(".lnk"))
                        {
                            string linkedExe = perFormObjects.lnkToExe(app);
                            System.Diagnostics.Debug.WriteLine(linkedExe);
                            win32AppLb.Items.Add(linkedExe);
                            lnkFileLb.Items.Add(app);
                            perFormObjects.allowedApps.Remove(linkedExe);
                        }
                        else if (Globals.allUwpApps[app].ToLower().Contains("!app") | Globals.allUwpApps[app].ToLower().Contains("!microsoft") | Globals.allUwpApps[app].ToLower().Contains("msedge"))
                        {
                            uwpAppClb.Items.Add(app);
                            perFormObjects.allowedApps.Remove(app);
                        }
                        else
                        {
                            perFormObjects.addUwpApps.Add(app);
                            showAllCb_CheckedChanged(sender, e);
                            perFormObjects.allowedApps.Remove(app);
                        }
                    }
                    perFormObjects.groups.Remove(group.Text);
                    groupsLv.Items.Remove(group);
                }
            }
        }

        private void cancelBt_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void saveProfBt_Click(object sender, EventArgs e)
        {
            if (win10_cb.Checked & groupsLv.Items.Count == 0)
            {
                string message = "For Windows 10, you need to add at least 1 application group to the start menu";
                string caption = "No application added";
                MessageBox.Show(message, caption);
            }
            else
            {
                string message = "Save Application Profile? You won't be able to modify it afterwards.";
                string caption = "Confirmation";
                MessageBoxButtons bt = MessageBoxButtons.OKCancel;
                DialogResult save = MessageBox.Show(message, caption, bt);

                if (save == DialogResult.OK)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void confAutoLaunchBt_Click(object sender, EventArgs e)
        {
            var alForm = new autoLaunch();
            foreach (var app in uwpAppClb.CheckedItems)
            {
                alForm.allAppsCb.Items.Add(app);
            }

            foreach (var app in win32AppLb.Items)
            {
                alForm.allAppsCb.Items.Add(app);
            }

            foreach (string app in perFormObjects.allowedApps)
            {
                alForm.allAppsCb.Items.Add(app);
            }

            if (!(perFormObjects.autoLaunch.Count == 0))
            {
                alForm.allAppsCb.SelectedItem = perFormObjects.autoLaunch[0];
                alForm.argumentsTb.Text = perFormObjects.autoLaunch[1];
            }

            alForm.ShowDialog();
        }

        private void manUwpBt_Click(object sender, EventArgs e)
        {
            var manUwpAdd = new addUwpMan();
            DialogResult res = manUwpAdd.ShowDialog();
            if (res == DialogResult.OK) { showAllCb.Checked = true; }
        }
        private void manExeBt_Click(object sender, EventArgs e)
        {
            var manExeAdd = new addExeMan();
            manExeAdd.ShowDialog();
        }


        #endregion


        #region Checkbox Events

        public void showAllCb_CheckedChanged(object sender, EventArgs e)
        {
            if (showAllCb.Checked)
            {
                foreach (string app in perFormObjects.addUwpApps)
                {
                    uwpAppClb.Items.Add(app);
                }
            }
            else
            {
                foreach (string app in perFormObjects.addUwpApps)
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

        private void win10_CheckedChanged(object sender, EventArgs e)
        {
            if (!win10_cb.Checked )
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
            if (!win10_cb.Checked & !win11_cb.Checked)
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
                    string message = "Are you sure you want to quit? Changes will not be saved";
                    string caption = "Confirm";
                    MessageBoxButtons bt = MessageBoxButtons.YesNo;
                    DialogResult res = MessageBox.Show(message, caption, bt);
                    if (res == DialogResult.No)
                    {
                        e.Cancel = true;
                    }
                }
            }
            else if (this.DialogResult == DialogResult.OK)
            {
                foreach (var item in uwpAppClb.CheckedItems)
                {
                    perFormObjects.allowedApps.Add(item.ToString());
                }
                foreach (var item in win32AppLb.Items)
                {
                    perFormObjects.allowedApps.Add(item.ToString());
                }

                string taskBar = "false";
                string dlPerm = "false";
                string rdPerm = "false";
                string noRestrict = "false";
                string isWin10 = "false";
                string isWin11 = "false";

                if (showTaskbarCb.Checked)
                {
                    taskBar = "true";
                }

                if (dlPermCb.Checked)
                {
                    dlPerm = "true";
                }

                if (rdPermCb.Checked)
                {
                    rdPerm = "true";
                }

                if (noRestrictCb.Checked)
                {
                    noRestrict = "true";
                }

                if (win10_cb.Checked)
                {
                    isWin10 = "true";
                }

                if (win11_cb.Checked)
                {
                    isWin11 = "true";
                }

                List<string> profileParam = new()
                {
                    guidLabel.Text,
                    taskBar,
                    dlPerm,
                    rdPerm,
                    noRestrict,
                    isWin10,
                    isWin11
                };

                Dictionary<List<string>, Dictionary<string, Dictionary<string, List<string>>>> appProfile = new()
                {
                    { perFormObjects.allowedApps, perFormObjects.groups }
                };
                Globals.appProfiles.Add(profileParam, appProfile);
                Globals.globalAutoLaunchApps.Add(guidLabel.Text, perFormObjects.autoLaunch);
            }
        }

        private void appProfile_FormClosed(object sender, FormClosedEventArgs e)
        {
            perFormObjects.flushAll();
        }

        #endregion
    }
}