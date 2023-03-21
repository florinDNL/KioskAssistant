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
            appTypeCb = new System.Windows.Forms.ComboBox();
            appTypeLb = new System.Windows.Forms.Label();
            profileLabel = new System.Windows.Forms.Label();
            guidLabel = new System.Windows.Forms.Label();
            logoBox = new System.Windows.Forms.PictureBox();
            kModePanel = new System.Windows.Forms.Panel();
            saveProfileBt = new System.Windows.Forms.Button();
            cancelbt = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)logoBox).BeginInit();
            SuspendLayout();
            // 
            // appTypeCb
            // 
            appTypeCb.FormattingEnabled = true;
            appTypeCb.Items.AddRange(new object[] { "Edge", "UWP", "Win32 (Unstable)" });
            appTypeCb.Location = new System.Drawing.Point(78, 57);
            appTypeCb.Name = "appTypeCb";
            appTypeCb.Size = new System.Drawing.Size(121, 23);
            appTypeCb.TabIndex = 0;
            appTypeCb.SelectedIndexChanged += appTypeCb_SelectedIndexChanged;
            // 
            // appTypeLb
            // 
            appTypeLb.AutoSize = true;
            appTypeLb.Location = new System.Drawing.Point(13, 60);
            appTypeLb.Name = "appTypeLb";
            appTypeLb.Size = new System.Drawing.Size(59, 15);
            appTypeLb.TabIndex = 1;
            appTypeLb.Text = "App Type:";
            // 
            // profileLabel
            // 
            profileLabel.AutoSize = true;
            profileLabel.Location = new System.Drawing.Point(12, 9);
            profileLabel.Name = "profileLabel";
            profileLabel.Size = new System.Drawing.Size(41, 15);
            profileLabel.TabIndex = 24;
            profileLabel.Text = "Profile";
            // 
            // guidLabel
            // 
            guidLabel.AutoSize = true;
            guidLabel.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            guidLabel.Location = new System.Drawing.Point(9, 19);
            guidLabel.Name = "guidLabel";
            guidLabel.Size = new System.Drawing.Size(54, 25);
            guidLabel.TabIndex = 23;
            guidLabel.Text = "GUID";
            // 
            // logoBox
            // 
            logoBox.Image = (System.Drawing.Image)resources.GetObject("logoBox.Image");
            logoBox.Location = new System.Drawing.Point(390, 19);
            logoBox.Name = "logoBox";
            logoBox.Size = new System.Drawing.Size(231, 51);
            logoBox.TabIndex = 25;
            logoBox.TabStop = false;
            // 
            // kModePanel
            // 
            kModePanel.Location = new System.Drawing.Point(13, 100);
            kModePanel.Name = "kModePanel";
            kModePanel.Size = new System.Drawing.Size(608, 180);
            kModePanel.TabIndex = 26;
            // 
            // saveProfileBt
            // 
            saveProfileBt.Location = new System.Drawing.Point(526, 306);
            saveProfileBt.Name = "saveProfileBt";
            saveProfileBt.Size = new System.Drawing.Size(95, 32);
            saveProfileBt.TabIndex = 27;
            saveProfileBt.Text = "Save Profile";
            saveProfileBt.UseVisualStyleBackColor = true;
            saveProfileBt.Click += saveProfileBt_Click;
            // 
            // cancelbt
            // 
            cancelbt.Location = new System.Drawing.Point(425, 306);
            cancelbt.Name = "cancelbt";
            cancelbt.Size = new System.Drawing.Size(95, 32);
            cancelbt.TabIndex = 28;
            cancelbt.Text = "Cancel";
            cancelbt.UseVisualStyleBackColor = true;
            cancelbt.Click += cancelbt_Click;
            // 
            // kioskModeApp
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(634, 356);
            Controls.Add(cancelbt);
            Controls.Add(saveProfileBt);
            Controls.Add(kModePanel);
            Controls.Add(logoBox);
            Controls.Add(profileLabel);
            Controls.Add(guidLabel);
            Controls.Add(appTypeLb);
            Controls.Add(appTypeCb);
            Name = "kioskModeApp";
            Text = "kioskModeApp";
            ((System.ComponentModel.ISupportInitialize)logoBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.kioskModeApp_FormClosing);
        }

        #endregion

        private System.Windows.Forms.ComboBox appTypeCb;
        private System.Windows.Forms.Label appTypeLb;
        private System.Windows.Forms.Label profileLabel;
        public System.Windows.Forms.Label guidLabel;
        private System.Windows.Forms.PictureBox logoBox;
        private System.Windows.Forms.Panel kModePanel;
        private System.Windows.Forms.Button saveProfileBt;
        private System.Windows.Forms.Button cancelbt;
    }
}