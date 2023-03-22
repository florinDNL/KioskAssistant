namespace kioskAssistant.Controls
{
    partial class slUwpUserControl
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
            SuspendLayout();
            // 
            // appLb
            // 
            appLb.AutoSize = true;
            appLb.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            appLb.Location = new System.Drawing.Point(8, 16);
            appLb.Name = "appLb";
            appLb.Size = new System.Drawing.Size(40, 20);
            appLb.TabIndex = 11;
            appLb.Text = "App:";
            // 
            // appCb
            // 
            appCb.FormattingEnabled = true;
            appCb.Location = new System.Drawing.Point(73, 16);
            appCb.Name = "appCb";
            appCb.Size = new System.Drawing.Size(243, 23);
            appCb.TabIndex = 12;
            // 
            // slUwpUserControl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(appCb);
            Controls.Add(appLb);
            Name = "slUwpUserControl";
            Size = new System.Drawing.Size(616, 80);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label appLb;
        public System.Windows.Forms.ComboBox appCb;
    }
}
