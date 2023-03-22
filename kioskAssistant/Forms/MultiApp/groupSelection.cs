using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using allGlobals;


namespace kioskAssistant
{
    public partial class groupSelection : Form
    {
        public string selectedGrp;
        public string groupType;

        public groupSelection()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            addGrpBt.Enabled = false;
        }

        public void localGrpSelect()
        {
            ComboBox groups = new();
            groups.FormattingEnabled = true;
            groups.Location = new Point(220, 25);
            groups.Name = "localGrpBox";
            groups.Size = new Size(140, 25);
            groups.TabIndex = 2;
            foreach (string group in Globals.localGroups)
            {
                groups.Items.Add(group);
            }
            Controls.Add(groups);
        }

        public void domainGrpSelect()
        {
            TextBox domain = new();
            domain.Location = new Point(220, 25);
            domain.Name = "domainTb";
            domain.Size = new Size(140, 23);
            domain.PlaceholderText = "Domain";
            Controls.Add(domain);

            TextBox group = new();
            group.Location = new Point(380, 25);
            group.Name = "groupTb";
            group.Size = new Size(140, 23);
            group.TabIndex = 3;
            group.PlaceholderText = "Groupname";
            Controls.Add(group);

            Label slash = new();
            slash.AutoSize = true;
            slash.Location = new Point(365, 28);
            slash.Name = "slashLb";
            slash.Size = new Size(12, 15);
            slash.Text = "\\";
            Controls.Add(slash);
        }

        public void azureGrpSelect()
        {
            TextBox group = new();
            group.Location = new Point(220, 25);
            group.Name = "azName";
            group.Size = new Size(140, 23);
            group.PlaceholderText = "Group name or object ID";
            Controls.Add(group);
        }

        private void typeCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            addGrpBt.Enabled = true;
            foreach (Control item in Controls.OfType<Control>().ToList())
            {
                if (item.Name != "typeCombo" & item.Name != "typeLabel" & item.Name != "addGrpBt")
                {
                    Controls.Remove(item);
                }                    
            }

            if      (typeCombo.SelectedIndex == 0)
            {
                localGrpSelect();
            }
            else if (typeCombo.SelectedIndex == 1)
            {
                domainGrpSelect();        
            }
            else if (typeCombo.SelectedIndex == 2)
            {
                azureGrpSelect();
            }
        }

        private void addGrpBt_Click(object sender, EventArgs e)
        {
            if (typeCombo.SelectedIndex == 0)
            {
                if (!string.IsNullOrEmpty(Controls["localGrpBox"].Text))
                {
                    selectedGrp = Controls["localGrpBox"].Text;
                    groupType = "[L]Group";
                }
                else
                {
                    MessageBox.Show("Please select or type a group name");
                    return;
                }
            }
            else if (typeCombo.SelectedIndex == 1)
            {
                if (!string.IsNullOrEmpty(Controls["groupTb"].Text) & !string.IsNullOrEmpty(Controls["domainTb"].Text))
                {
                    selectedGrp = Controls["domainTb"].Text + "\\" + Controls["groupTb"].Text;
                    groupType = "[D]Group";
                }
                else
                {
                    MessageBox.Show("Fields cannot be blank");
                    return;
                }
            }
            else if (typeCombo.SelectedIndex == 2)
            {
                if (!string.IsNullOrEmpty(Controls["azName"].Text))
                {
                    selectedGrp = Controls["azName"].Text;
                    groupType = "[A]Group";
                }
                else
                {
                    MessageBox.Show("Azure group cannot be blank");
                    return;
                }
            }
            

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}