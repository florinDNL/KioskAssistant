namespace kioskAssistant.Forms
{
    partial class startWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(startWindow));
            multiAppBt = new System.Windows.Forms.Button();
            sLauncherBt = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // multiAppBt
            // 
            multiAppBt.Location = new System.Drawing.Point(12, 23);
            multiAppBt.Name = "multiAppBt";
            multiAppBt.Size = new System.Drawing.Size(152, 58);
            multiAppBt.TabIndex = 0;
            multiAppBt.Text = "Create Multi App / KioskMode App XML";
            multiAppBt.UseVisualStyleBackColor = true;
            multiAppBt.Click += multiAppBt_Click;
            // 
            // sLauncherBt
            // 
            sLauncherBt.Location = new System.Drawing.Point(177, 23);
            sLauncherBt.Name = "sLauncherBt";
            sLauncherBt.Size = new System.Drawing.Size(152, 58);
            sLauncherBt.TabIndex = 1;
            sLauncherBt.Text = "Create Shell Launcher XML";
            sLauncherBt.UseVisualStyleBackColor = true;
            sLauncherBt.Click += sLauncherBt_Click;
            // 
            // startWindow
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(341, 108);
            Controls.Add(sLauncherBt);
            Controls.Add(multiAppBt);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "startWindow";
            Text = "Kiosk Assistant";
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button multiAppBt;
        private System.Windows.Forms.Button sLauncherBt;
    }
}