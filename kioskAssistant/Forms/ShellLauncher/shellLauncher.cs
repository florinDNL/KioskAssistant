using allGlobals;
using xmlManip;
using System.Windows.Forms;
using System.Diagnostics;

namespace kioskAssistant.Forms
{
    public partial class shellLauncher : Form
    {
        public shellLauncher()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            genXmlBt.Enabled = false;
        }

        private void nameBt_Click(object sender, System.EventArgs e)
        {
            if (!string.IsNullOrEmpty(nameSidTb.Text))
            {
                string acc = "[n]" + nameSidTb.Text;
                accountsGv.Rows.Add(acc);
            }
        }

        private void sidBt_Click(object sender, System.EventArgs e)
        {
            if (!string.IsNullOrEmpty(nameSidTb.Text))
            {
                string acc = "[s]" + nameSidTb.Text;
                accountsGv.Rows.Add(acc);
            }
        }

        private void remBt_Click(object sender, System.EventArgs e)
        {
            foreach (DataGridViewRow row in accountsGv.SelectedRows)
            {
                accountsGv.Rows.Remove(row);
                if (row.Cells[0].Value.ToString() == "Autologon")
                {
                    autologonBt.Enabled = true;
                }
            }
        }

        private void cShellbt_Click(object sender, System.EventArgs e)
        {
            var customShellForm = new customShell();
            customShellForm.ShowDialog();
            if (customShellForm.DialogResult == DialogResult.OK)
            {
                appProfileLb.Items.Add(customShellForm.guidLabel.Text);
            }
        }

        private void assignBt_Click(object sender, System.EventArgs e)
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
                    row.Cells[1].Value = appProfileLb.SelectedItem.ToString();
                }
            }
        }

        private void remCsBt_Click(object sender, System.EventArgs e)
        {
            if (appProfileLb.Items.Count > 0)
            {
                foreach (string profile in perFormObjects.shellLauncherAccs.Keys)
                {
                    if (profile == appProfileLb.SelectedItem.ToString())
                    {
                        perFormObjects.shellLauncherAccs.Remove(profile);
                    }
                }

                foreach (DataGridViewRow row in accountsGv.Rows)
                {
                    if (row.Cells[1].Value != null & row.Cells[1].Value == appProfileLb.SelectedItem)
                    {
                        row.Cells[1].Value = null;
                    }
                }

                appProfileLb.Items.Remove(appProfileLb.SelectedItem);
            }
        }

        private void genXmlBt_Click(object sender, System.EventArgs e)
        {
            DialogResult res = saveXML.ShowDialog();
            if (res != DialogResult.Cancel)
            {
                foreach (DataGridViewRow row in accountsGv.Rows)
                {
                    string name = row.Cells[0].Value.ToString();
                    string prof = row.Cells[1].Value.ToString();
                    Globals.shellLauncherAccounts.Add(name, prof);
                }

                string savePath = saveXML.FileName;
                xmlCreator.writeShellLauncherXmlFile(savePath);
                Globals.accountsInit();
                MessageBox.Show("XML file saved to " + savePath, "Success");
            }
        }

        #region Event Listeners
        private void accountsGv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            accountsGv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            if (Globals.areAllAssigned(accountsGv.Rows.Count, accountsGv, 1))
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
            else if (Globals.areAllAssigned(accountsGv.Rows.Count, accountsGv, 1))
            {
                genXmlBt.Enabled = true;
            }
        }

        #endregion

        private void autologonBt_Click(object sender, System.EventArgs e)
        {            
            accountsGv.Rows.Add("Autologon");
            autologonBt.Enabled = false;
        }
    }
}
