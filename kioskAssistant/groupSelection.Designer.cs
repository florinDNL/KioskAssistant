
namespace kioskAssistant
{
    partial class groupSelection
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(groupSelection));
            this.typeCombo = new System.Windows.Forms.ComboBox();
            this.typeLabel = new System.Windows.Forms.Label();
            this.addGrpBt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // typeCombo
            // 
            this.typeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeCombo.FormattingEnabled = true;
            this.typeCombo.Items.AddRange(new object[] {
            "Local",
            "Domain",
            "Azure AD"});
            this.typeCombo.Location = new System.Drawing.Point(60, 25);
            this.typeCombo.Name = "typeCombo";
            this.typeCombo.Size = new System.Drawing.Size(142, 23);
            this.typeCombo.TabIndex = 0;
            this.typeCombo.SelectedIndexChanged += new System.EventHandler(this.typeCombo_SelectedIndexChanged);
            // 
            // typeLabel
            // 
            this.typeLabel.AutoSize = true;
            this.typeLabel.Location = new System.Drawing.Point(23, 33);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(31, 15);
            this.typeLabel.TabIndex = 1;
            this.typeLabel.Text = "Type";
            // 
            // addGrpBt
            // 
            this.addGrpBt.Location = new System.Drawing.Point(530, 24);
            this.addGrpBt.Name = "addGrpBt";
            this.addGrpBt.Size = new System.Drawing.Size(53, 23);
            this.addGrpBt.TabIndex = 2;
            this.addGrpBt.Text = "Add";
            this.addGrpBt.UseVisualStyleBackColor = true;
            this.addGrpBt.Click += new System.EventHandler(this.addGrpBt_Click);
            // 
            // groupSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 85);
            this.Controls.Add(this.addGrpBt);
            this.Controls.Add(this.typeLabel);
            this.Controls.Add(this.typeCombo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "groupSelection";
            this.Text = "Group Selection";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox typeCombo;
        private System.Windows.Forms.Label typeLabel;
        private System.Windows.Forms.Button addGrpBt;
    }
}