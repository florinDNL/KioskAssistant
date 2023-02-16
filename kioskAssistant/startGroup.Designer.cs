
namespace kioskAssistant
{
    partial class startGroup
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(startGroup));
            this.sizeCombo = new System.Windows.Forms.ComboBox();
            this.sizeLabel = new System.Windows.Forms.Label();
            this.colLabel = new System.Windows.Forms.Label();
            this.rowLabel = new System.Windows.Forms.Label();
            this.addBt = new System.Windows.Forms.Button();
            this.colNud = new System.Windows.Forms.NumericUpDown();
            this.rowNud = new System.Windows.Forms.NumericUpDown();
            this.previewPanel = new System.Windows.Forms.Panel();
            this.previewLabel = new System.Windows.Forms.Label();
            this.clearBt = new System.Windows.Forms.Button();
            this.allAppsLb = new System.Windows.Forms.ListBox();
            this.addedAppsLb = new System.Windows.Forms.ListBox();
            this.nameTb = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.finishBt = new System.Windows.Forms.Button();
            this.win11NoteLb = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.colNud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rowNud)).BeginInit();
            this.SuspendLayout();
            // 
            // sizeCombo
            // 
            this.sizeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sizeCombo.FormattingEnabled = true;
            this.sizeCombo.Items.AddRange(new object[] {
            "1x1",
            "2x2",
            "4x2",
            "4x4"});
            this.sizeCombo.Location = new System.Drawing.Point(36, 60);
            this.sizeCombo.Name = "sizeCombo";
            this.sizeCombo.Size = new System.Drawing.Size(56, 23);
            this.sizeCombo.TabIndex = 0;
            // 
            // sizeLabel
            // 
            this.sizeLabel.AutoSize = true;
            this.sizeLabel.Location = new System.Drawing.Point(8, 68);
            this.sizeLabel.Name = "sizeLabel";
            this.sizeLabel.Size = new System.Drawing.Size(27, 15);
            this.sizeLabel.TabIndex = 1;
            this.sizeLabel.Text = "Size";
            // 
            // colLabel
            // 
            this.colLabel.AutoSize = true;
            this.colLabel.Location = new System.Drawing.Point(98, 68);
            this.colLabel.Name = "colLabel";
            this.colLabel.Size = new System.Drawing.Size(50, 15);
            this.colLabel.TabIndex = 3;
            this.colLabel.Text = "Column";
            // 
            // rowLabel
            // 
            this.rowLabel.AutoSize = true;
            this.rowLabel.Location = new System.Drawing.Point(204, 68);
            this.rowLabel.Name = "rowLabel";
            this.rowLabel.Size = new System.Drawing.Size(30, 15);
            this.rowLabel.TabIndex = 5;
            this.rowLabel.Text = "Row";
            // 
            // addBt
            // 
            this.addBt.Location = new System.Drawing.Point(341, 60);
            this.addBt.Name = "addBt";
            this.addBt.Size = new System.Drawing.Size(46, 23);
            this.addBt.TabIndex = 7;
            this.addBt.Text = "Add";
            this.addBt.UseVisualStyleBackColor = true;
            this.addBt.Click += new System.EventHandler(this.addBt_Click);
            // 
            // colNud
            // 
            this.colNud.Location = new System.Drawing.Point(152, 60);
            this.colNud.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.colNud.Name = "colNud";
            this.colNud.Size = new System.Drawing.Size(44, 23);
            this.colNud.TabIndex = 0;
            // 
            // rowNud
            // 
            this.rowNud.Location = new System.Drawing.Point(240, 60);
            this.rowNud.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.rowNud.Name = "rowNud";
            this.rowNud.Size = new System.Drawing.Size(44, 23);
            this.rowNud.TabIndex = 8;
            // 
            // previewPanel
            // 
            this.previewPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.previewPanel.Location = new System.Drawing.Point(460, 89);
            this.previewPanel.Name = "previewPanel";
            this.previewPanel.Size = new System.Drawing.Size(300, 200);
            this.previewPanel.TabIndex = 9;
            // 
            // previewLabel
            // 
            this.previewLabel.AutoSize = true;
            this.previewLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.previewLabel.Location = new System.Drawing.Point(460, 71);
            this.previewLabel.Name = "previewLabel";
            this.previewLabel.Size = new System.Drawing.Size(53, 15);
            this.previewLabel.TabIndex = 10;
            this.previewLabel.Text = "Preview";
            // 
            // clearBt
            // 
            this.clearBt.Location = new System.Drawing.Point(393, 60);
            this.clearBt.Name = "clearBt";
            this.clearBt.Size = new System.Drawing.Size(46, 23);
            this.clearBt.TabIndex = 11;
            this.clearBt.Text = "Clear";
            this.clearBt.UseVisualStyleBackColor = true;
            this.clearBt.Click += new System.EventHandler(this.clearBt_Click);
            // 
            // allAppsLb
            // 
            this.allAppsLb.FormattingEnabled = true;
            this.allAppsLb.ItemHeight = 15;
            this.allAppsLb.Location = new System.Drawing.Point(12, 89);
            this.allAppsLb.Name = "allAppsLb";
            this.allAppsLb.Size = new System.Drawing.Size(427, 304);
            this.allAppsLb.TabIndex = 12;
            // 
            // addedAppsLb
            // 
            this.addedAppsLb.FormattingEnabled = true;
            this.addedAppsLb.ItemHeight = 15;
            this.addedAppsLb.Location = new System.Drawing.Point(459, 299);
            this.addedAppsLb.Name = "addedAppsLb";
            this.addedAppsLb.Size = new System.Drawing.Size(300, 94);
            this.addedAppsLb.TabIndex = 13;
            // 
            // nameTb
            // 
            this.nameTb.Location = new System.Drawing.Point(57, 15);
            this.nameTb.Name = "nameTb";
            this.nameTb.Size = new System.Drawing.Size(100, 23);
            this.nameTb.TabIndex = 14;
            this.nameTb.Text = "App Group";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(12, 18);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(39, 15);
            this.nameLabel.TabIndex = 15;
            this.nameLabel.Text = "Name";
            // 
            // finishBt
            // 
            this.finishBt.Location = new System.Drawing.Point(676, 396);
            this.finishBt.Name = "finishBt";
            this.finishBt.Size = new System.Drawing.Size(84, 23);
            this.finishBt.TabIndex = 16;
            this.finishBt.Text = "Finish";
            this.finishBt.UseVisualStyleBackColor = true;
            this.finishBt.Click += new System.EventHandler(this.finishBt_Click);
            // 
            // win11NoteLb
            // 
            this.win11NoteLb.AutoSize = true;
            this.win11NoteLb.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.win11NoteLb.ForeColor = System.Drawing.Color.Red;
            this.win11NoteLb.Location = new System.Drawing.Point(57, 41);
            this.win11NoteLb.Name = "win11NoteLb";
            this.win11NoteLb.Size = new System.Drawing.Size(699, 13);
            this.win11NoteLb.TabIndex = 17;
            this.win11NoteLb.Text = "Note: For Win11, apps will no longer be grouped. Instead, all apps you add to gro" +
    "ups will be displayed in the order they are added in.";
            // 
            // startGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 429);
            this.Controls.Add(this.win11NoteLb);
            this.Controls.Add(this.finishBt);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.nameTb);
            this.Controls.Add(this.addedAppsLb);
            this.Controls.Add(this.allAppsLb);
            this.Controls.Add(this.clearBt);
            this.Controls.Add(this.previewLabel);
            this.Controls.Add(this.previewPanel);
            this.Controls.Add(this.rowNud);
            this.Controls.Add(this.colNud);
            this.Controls.Add(this.addBt);
            this.Controls.Add(this.rowLabel);
            this.Controls.Add(this.colLabel);
            this.Controls.Add(this.sizeLabel);
            this.Controls.Add(this.sizeCombo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "startGroup";
            this.Text = "Customize Group";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.startGroup_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.colNud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rowNud)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.ListBox allAppsLb;
        public System.Windows.Forms.ListBox addedAppsLb;
        public System.Windows.Forms.TextBox nameTb;        

        private System.Windows.Forms.ComboBox sizeCombo;
        private System.Windows.Forms.Label sizeLabel;
        private System.Windows.Forms.Label colLabel;
        private System.Windows.Forms.Label rowLabel;
        private System.Windows.Forms.Button addBt;
        private System.Windows.Forms.NumericUpDown colNud;
        private System.Windows.Forms.NumericUpDown rowNud;
        private System.Windows.Forms.Panel previewPanel;
        private System.Windows.Forms.Label previewLabel;
        private System.Windows.Forms.Button clearBt;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Button finishBt;
        private System.Windows.Forms.Label win11NoteLb;
    }
}

