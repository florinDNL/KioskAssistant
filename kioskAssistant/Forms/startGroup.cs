using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using allGlobals;
using gridUI;


namespace kioskAssistant
{
    public partial class startGroup : Form
    {
        public Dictionary<string, List<string>> group = new();
        public startGroup()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            sizeCombo.SelectedIndex = 1;            
        }

        private void addBt_Click(object sender, System.EventArgs e)
        {
            Graphics g = previewPanel.CreateGraphics();
            int x = 0 + 50 * decimal.ToInt32(colNud.Value);
            int y = 0 + 50 * decimal.ToInt32(rowNud.Value);
            string size = sizeCombo.SelectedItem.ToString();

            if (allAppsLb.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an application to add");
            }
            else
            {
                if (grid.drawTile(g, size, x, y))
                {
                    var app = allAppsLb.SelectedItem;
                    List<string> appParam = new();  
                    appParam.Add(size);
                    appParam.Add(colNud.Value.ToString());
                    appParam.Add(rowNud.Value.ToString());
                    addedAppsLb.Items.Add(app);
                    allAppsLb.Items.Remove(app);
                    allAppsLb.SelectedIndex = allAppsLb.Items.Count != 0 ? 0 : -1;
                    
                    group.Add(app.ToString(), appParam);            
                }
                else
                {
                    MessageBox.Show("Cannot place tile here.");
                }    
            }            
        }

        private void clearBt_Click(object sender, System.EventArgs e)
        {            
            foreach (var item in addedAppsLb.Items)
            {
                allAppsLb.Items.Add(item);                
            }
            addedAppsLb.Items.Clear();
            group = new();
            perFormObjects.tileGrid = grid.gridInit();
            previewPanel.Invalidate();
        }

        private void finishBt_Click(object sender, System.EventArgs e)
        {
            if (addedAppsLb.Items.Count > 0)
            {
                if (perFormObjects.groups.ContainsKey(nameTb.Text))
                {
                    MessageBox.Show("This Group Name already exists.", "Duplicate Group");
                }
                else
                {
                    this.DialogResult = DialogResult.OK;                    
                    this.Close();
                }                
            }
            else
            {
                MessageBox.Show("No modifications made");
            }
        }

        private void startGroup_FormClosed(object sender, FormClosedEventArgs e)
        {
          perFormObjects.tileGrid = grid.gridInit();          
        }
    }
}
