namespace kioskAssistant.Controls
{
    partial class UwpUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            appLb = new System.Windows.Forms.Label();
            appCb = new System.Windows.Forms.ComboBox();
            tipLb = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // appLb
            // 
            appLb.AutoSize = true;
            appLb.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            appLb.Location = new System.Drawing.Point(8, 27);
            appLb.Name = "appLb";
            appLb.Size = new System.Drawing.Size(40, 20);
            appLb.TabIndex = 6;
            appLb.Text = "App:";
            // 
            // appCb
            // 
            appCb.FormattingEnabled = true;
            appCb.Location = new System.Drawing.Point(54, 27);
            appCb.Name = "appCb";
            appCb.Size = new System.Drawing.Size(290, 23);
            appCb.TabIndex = 7;
            // 
            // tipLb
            // 
            tipLb.AutoSize = true;
            tipLb.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            tipLb.Location = new System.Drawing.Point(8, 53);
            tipLb.Name = "tipLb";
            tipLb.Size = new System.Drawing.Size(590, 13);
            tipLb.TabIndex = 8;
            tipLb.Text = "Select from the list or manually paste AUMID in the box (e.g. Microsoft.WindowsCalculator_8wekyb3d8bbwe!App)";
            // 
            // UwpUserControl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(tipLb);
            Controls.Add(appCb);
            Controls.Add(appLb);
            Name = "UwpUserControl";
            Size = new System.Drawing.Size(616, 90);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label appLb;
        public System.Windows.Forms.ComboBox appCb;
        private System.Windows.Forms.Label tipLb;
    }
}
