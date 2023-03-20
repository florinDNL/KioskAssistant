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
            this.appLb = new System.Windows.Forms.Label();
            this.appCb = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // appLb
            // 
            this.appLb.AutoSize = true;
            this.appLb.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.appLb.Location = new System.Drawing.Point(8, 27);
            this.appLb.Name = "appLb";
            this.appLb.Size = new System.Drawing.Size(40, 20);
            this.appLb.TabIndex = 6;
            this.appLb.Text = "App:";
            // 
            // appCb
            // 
            this.appCb.FormattingEnabled = true;
            this.appCb.Location = new System.Drawing.Point(54, 27);
            this.appCb.Name = "appCb";
            this.appCb.Size = new System.Drawing.Size(188, 23);
            this.appCb.TabIndex = 7;
            // 
            // UwpUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.appCb);
            this.Controls.Add(this.appLb);
            this.Name = "UwpUserControl";
            this.Size = new System.Drawing.Size(608, 180);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label appLb;
        private System.Windows.Forms.ComboBox appCb;
    }
}
