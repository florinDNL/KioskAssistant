using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using allGlobals;


namespace kioskAssistant
{
    public partial class userSelection : Form
    {
        public string selectedUsr;

        public userSelection()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            addUsrBt.Enabled = false;
        }

        public void localUsrSelect()
        {
            ComboBox users = new();
            users.FormattingEnabled = true;
            users.Location = new Point(220, 25);
            users.Name = "localUsrBox";
            users.Size = new Size(140, 25);
            users.TabIndex = 2;
            foreach (string user in Globals.localUsers)
            {
                users.Items.Add(user);
            }
            Controls.Add(users);
        }

        public void domainUsrSelect()
        {
            TextBox domain = new();
            domain.Location = new Point(220, 25);
            domain.Name = "domainTb";
            domain.Size = new Size(140, 23);
            domain.PlaceholderText = "Domain";
            Controls.Add(domain);

            TextBox user = new();
            user.Location = new Point(380, 25);
            user.Name = "userTb";
            user.Size = new Size(140, 23);
            user.TabIndex = 3;
            user.PlaceholderText = "Username";
            Controls.Add(user);

            Label slash = new();
            slash.AutoSize = true;
            slash.Location = new Point(365, 28);
            slash.Name = "slashLb";
            slash.Size = new Size(12, 15);
            slash.Text = "\\";
            Controls.Add(slash);
        }

        public void azureUsrSelect()
        {
            TextBox mail = new();
            mail.Location = new Point(282, 25);
            mail.Name = "mailTb";
            mail.Size = new Size(140, 23);
            mail.PlaceholderText = "Azure Mail";
            Controls.Add(mail);

            Label azureAd = new();
            azureAd.AutoSize = true;
            azureAd.Location = new Point(220, 28);
            azureAd.Name = "azureLb";
            azureAd.Text = "AzureAD \\";
            Controls.Add(azureAd);
        }

        private void typeCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            addUsrBt.Enabled = true;
            foreach (Control item in Controls.OfType<Control>().ToList())
            {
                if (item.Name != "typeCombo" & item.Name != "typeLabel" & item.Name != "addUsrBt")
                {
                    Controls.Remove(item);
                }                    
            }

            if      (typeCombo.SelectedIndex == 0)
            {
                localUsrSelect();
            }
            else if (typeCombo.SelectedIndex == 1)
            {
                domainUsrSelect();        
            }
            else if (typeCombo.SelectedIndex == 2)
            {
                azureUsrSelect();
            }
        }

        private void addUsrBt_Click(object sender, EventArgs e)
        { 
            if      (typeCombo.SelectedIndex == 0)
            {
                if (!string.IsNullOrEmpty(Controls["localUsrBox"].Text))
                {
                    selectedUsr = Controls["localUsrBox"].Text;
                }
                else
                {
                    MessageBox.Show("Please select or type a username");
                    return;
                }                
            }
            else if (typeCombo.SelectedIndex == 1)
            {
                if (!string.IsNullOrEmpty(Controls["userTb"].Text) & !string.IsNullOrEmpty(Controls["domainTb"].Text))
                {
                    selectedUsr = Controls["domainTb"].Text + "\\" + Controls["userTb"].Text;
                }
                else
                {
                    MessageBox.Show("Fields cannot be blank");
                    return;
                }                
            }
            else if (typeCombo.SelectedIndex == 2)
            {
                if (!string.IsNullOrEmpty(Controls["mailTb"].Text))
                {
                    selectedUsr = "AzureAD\\" + Controls["mailTb"].Text;
                }
                else
                {
                    MessageBox.Show("Mail cannot be blank");
                    return;
                }
            }
            

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
