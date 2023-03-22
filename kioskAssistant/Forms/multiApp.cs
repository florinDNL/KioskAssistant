using System;
using System.Windows.Forms;
using System.Collections.Generic;
using allGlobals;
using xmlManip;

namespace kioskAssistant
{
    public partial class multiApp : Form
    {
        #region Form Initialization

        public multiApp()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            genXmlBt.Enabled = false;
        }

        #endregion


        #region Button Click Events

        private void addAppProfileBt_Click(object sender, EventArgs e)
        {
            var profileForm = new appProfile();
            DialogResult appProf = profileForm.ShowDialog();
            if (appProf == DialogResult.OK)
            {
                appProfileLb.Items.Add(profileForm.guidLabel.Text);
            }
        }

        private void kModeBt_Click(object sender, EventArgs e)
        {
            var kModeForm = new kioskModeApp();
            DialogResult appProf = kModeForm.ShowDialog();
            if (appProf == DialogResult.OK)
            {
                appProfileLb.Items.Add(kModeForm.guidLabel.Text);
            }
        }

        private void delAppProfileBt_Click(object sender, EventArgs e)
        {
            foreach (List<string> profile in Globals.appProfiles.Keys)
            {
                if (profile.Contains(appProfileLb.SelectedItem.ToString()))
                {
                    Globals.appProfiles.Remove(profile);
                }
            }
            foreach (DataGridViewRow row in accountsGv.Rows)
            {
                if (row.Cells[2].Value != null & row.Cells[2].Value == appProfileLb.SelectedItem)
                {
                    row.Cells[2].Value = null;
                }
            }
            appProfileLb.Items.Remove(appProfileLb.SelectedItem);
        }

        private void addGlobProfBt_Click(object sender, EventArgs e)
        {
            addGlobProfBt.Enabled = false;
            accountsGv.Rows.Add("Global Profile", "Global");
        }

        private void addAutoLogonAccBt_Click(object sender, EventArgs e)
        {
            var dispNameBox = new dispName();
            DialogResult res = dispNameBox.ShowDialog();

            if (res == DialogResult.OK)
            {
                Globals.displayName = dispNameBox.dispNameTb.Text;
                accountsGv.Rows.Add("Auto Login", "Auto");
                addAutoLogonAccBt.Enabled = false;
            }
        }

        private void addUsrBt_Click(object sender, EventArgs e)
        {
            var userSelect = new userSelection();
            DialogResult usrSel = userSelect.ShowDialog();
            if (usrSel == DialogResult.OK)
            {
                foreach (DataGridViewRow row in accountsGv.Rows)
                {
                    if (row.Cells[0].Value.ToString() == userSelect.selectedUsr & row.Cells[1].Value.ToString() == "User")
                    {
                        MessageBox.Show("User already added.", "Error");
                        return;
                    }
                }
                accountsGv.Rows.Add(userSelect.selectedUsr, "User");
            }
        }

        private void addGrpBt_Click(object sender, EventArgs e)
        {
            var groupSelect = new groupSelection();
            DialogResult grpSel = groupSelect.ShowDialog();
            if (grpSel == DialogResult.OK)
            {
                foreach (DataGridViewRow row in accountsGv.Rows)
                {
                    if (row.Cells[0].Value.ToString() == groupSelect.selectedGrp & row.Cells[1].Value.ToString() == groupSelect.groupType)
                    {
                        MessageBox.Show("Group already added.", "Error");
                        return;
                    }
                }
                accountsGv.Rows.Add(groupSelect.selectedGrp, groupSelect.groupType);
            }
        }

        private void assignBt_Click(object sender, EventArgs e)
        {
            if (accountsGv.SelectedRows.Count == 0)
            {
                string message = "Please select at least one user or group";
                string caption = "Nothing selected";
                MessageBox.Show(message, caption);
            }
            else if (appProfileLb.SelectedIndex == -1)
            {
                string message = "Please select an application profile to add";
                string caption = "No application profile selected";
                MessageBox.Show(message, caption);
            }
            else
            {
                foreach (DataGridViewRow row in accountsGv.SelectedRows)
                {
                    row.Cells[2].Value = appProfileLb.SelectedItem.ToString();
                }
            }
        }

        private void removeGrBt_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in accountsGv.SelectedRows)
            {

                if (row.Cells[1].Value.ToString() == "Global")
                {
                    addGlobProfBt.Enabled = true;
                }
                else if (row.Cells[1].Value.ToString() == "Auto")
                {
                    Globals.displayName = null;
                    addAutoLogonAccBt.Enabled = true;
                }

                accountsGv.Rows.Remove(row);
            }
        }

        private void genXmlBt_Click(object sender, EventArgs e)
        {
            DialogResult res = saveXML.ShowDialog();
            if (res != DialogResult.Cancel)
            {
                foreach (DataGridViewRow row in accountsGv.Rows)
                {
                    string name = row.Cells[0].Value.ToString();
                    string type = row.Cells[1].Value.ToString();
                    string prof = row.Cells[2].Value.ToString();

                    if (type == "User")
                    {
                        Globals.addedUsers.Add(name, prof);
                    }
                    else if (type == "[L]Group")
                    {
                        Globals.addedLocalGroups.Add(name, prof);
                    }
                    else if (type == "[D]Group")
                    {
                        Globals.addedDomainGroups.Add(name, prof);
                    }
                    else if (type == "[A]Group")
                    {
                        Globals.addedAzureGroups.Add(name, prof);
                    }
                    else if (type == "Auto")
                    {
                        Globals.isAuto = true;
                        Globals.autoLogon.Add(Globals.displayName, prof);
                    }
                    else if (type == "Global")
                    {
                        Globals.isGlobal = true;
                        Globals.globalProfile = prof;
                    }
                }
                string savePath = saveXML.FileName;
                xmlCreator.writeXmlFile(savePath);
                Globals.accountsInit();
                MessageBox.Show("XML file saved to " + savePath, "Success");
            }
        }

        #endregion


        #region Event Listeners
        private void accountsGv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            accountsGv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            if (Globals.areAllAssigned(accountsGv.Rows.Count, accountsGv, 2))
            {
                genXmlBt.Enabled = true;
            }
            else
            {
                genXmlBt.Enabled = false;
            }
        }

        private void accountsGv_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            accountsGv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            genXmlBt.Enabled = false;
        }

        private void accountsGv_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            accountsGv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            if (accountsGv.RowCount == 0)
            {
                genXmlBt.Enabled = false;
            }
            else if (Globals.areAllAssigned(accountsGv.Rows.Count, accountsGv, 2))
            {
                genXmlBt.Enabled = true;
            }
        }

        #endregion
    }
}
