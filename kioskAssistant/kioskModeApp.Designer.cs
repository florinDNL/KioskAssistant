namespace kioskAssistant
{
    partial class kioskModeApp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(kioskModeApp));
            this.appTypeCb = new System.Windows.Forms.ComboBox();
            this.appTypeLb = new System.Windows.Forms.Label();
            this.profileLabel = new System.Windows.Forms.Label();
            this.guidLabel = new System.Windows.Forms.Label();
            this.logoBox = new System.Windows.Forms.PictureBox();
            this.kModePanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.logoBox)).BeginInit();
            this.SuspendLayout();
            // 
            // appTypeCb
            // 
            this.appTypeCb.FormattingEnabled = true;
            this.appTypeCb.Items.AddRange(new object[] {
            "Edge",
            "UWP",
            "Win32"});
            this.appTypeCb.Location = new System.Drawing.Point(78, 57);
            this.appTypeCb.Name = "appTypeCb";
            this.appTypeCb.Size = new System.Drawing.Size(121, 23);
            this.appTypeCb.TabIndex = 0;
            this.appTypeCb.SelectedIndexChanged += new System.EventHandler(this.appTypeCb_SelectedIndexChanged);
            // 
            // appTypeLb
            // 
            this.appTypeLb.AutoSize = true;
            this.appTypeLb.Location = new System.Drawing.Point(13, 60);
            this.appTypeLb.Name = "appTypeLb";
            this.appTypeLb.Size = new System.Drawing.Size(59, 15);
            this.appTypeLb.TabIndex = 1;
            this.appTypeLb.Text = "App Type:";
            // 
            // profileLabel
            // 
            this.profileLabel.AutoSize = true;
            this.profileLabel.Location = new System.Drawing.Point(12, 9);
            this.profileLabel.Name = "profileLabel";
            this.profileLabel.Size = new System.Drawing.Size(41, 15);
            this.profileLabel.TabIndex = 24;
            this.profileLabel.Text = "Profile";
            // 
            // guidLabel
            // 
            this.guidLabel.AutoSize = true;
            this.guidLabel.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.guidLabel.Location = new System.Drawing.Point(9, 19);
            this.guidLabel.Name = "guidLabel";
            this.guidLabel.Size = new System.Drawing.Size(54, 25);
            this.guidLabel.TabIndex = 23;
            this.guidLabel.Text = "GUID";
            // 
            // logoBox
            // 
            this.logoBox.Image = ((System.Drawing.Image)(resources.GetObject("logoBox.Image")));
            this.logoBox.Location = new System.Drawing.Point(557, 12);
            this.logoBox.Name = "logoBox";
            this.logoBox.Size = new System.Drawing.Size(231, 51);
            this.logoBox.TabIndex = 25;
            this.logoBox.TabStop = false;
            // 
            // kModePanel
            // 
            this.kModePanel.Location = new System.Drawing.Point(13, 100);
            this.kModePanel.Name = "kModePanel";
            this.kModePanel.Size = new System.Drawing.Size(768, 319);
            this.kModePanel.TabIndex = 26;
            // 
            // kioskModeApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.kModePanel);
            this.Controls.Add(this.logoBox);
            this.Controls.Add(this.profileLabel);
            this.Controls.Add(this.guidLabel);
            this.Controls.Add(this.appTypeLb);
            this.Controls.Add(this.appTypeCb);
            this.Name = "kioskModeApp";
            this.Text = "kioskModeApp";
            ((System.ComponentModel.ISupportInitialize)(this.logoBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox appTypeCb;
        private System.Windows.Forms.Label appTypeLb;
        private System.Windows.Forms.Label profileLabel;
        public System.Windows.Forms.Label guidLabel;
        private System.Windows.Forms.PictureBox logoBox;
        private System.Windows.Forms.Panel kModePanel;
    }
}