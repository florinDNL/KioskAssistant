namespace kioskAssistant.Controls
{
    partial class slWin32UserControl
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
            browseBt = new System.Windows.Forms.Button();
            shellTb = new System.Windows.Forms.TextBox();
            shellLb = new System.Windows.Forms.Label();
            fullscreenCb = new System.Windows.Forms.CheckBox();
            shellDialog = new System.Windows.Forms.OpenFileDialog();
            argTb = new System.Windows.Forms.TextBox();
            argLb = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // browseBt
            // 
            browseBt.Location = new System.Drawing.Point(538, 15);
            browseBt.Name = "browseBt";
            browseBt.Size = new System.Drawing.Size(75, 23);
            browseBt.TabIndex = 12;
            browseBt.Text = "Browse";
            browseBt.UseVisualStyleBackColor = true;
            browseBt.Click += browseBt_Click;
            // 
            // shellTb
            // 
            shellTb.Location = new System.Drawing.Point(132, 13);
            shellTb.Name = "shellTb";
            shellTb.PlaceholderText = "C:\\Windows\\System32\\explorer.exe";
            shellTb.Size = new System.Drawing.Size(399, 23);
            shellTb.TabIndex = 11;
            // 
            // shellLb
            // 
            shellLb.AutoSize = true;
            shellLb.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            shellLb.Location = new System.Drawing.Point(8, 16);
            shellLb.Name = "shellLb";
            shellLb.Size = new System.Drawing.Size(48, 20);
            shellLb.TabIndex = 10;
            shellLb.Text = "Shell: ";
            // 
            // fullscreenCb
            // 
            fullscreenCb.AutoSize = true;
            fullscreenCb.Checked = true;
            fullscreenCb.CheckState = System.Windows.Forms.CheckState.Checked;
            fullscreenCb.Location = new System.Drawing.Point(8, 71);
            fullscreenCb.Name = "fullscreenCb";
            fullscreenCb.Size = new System.Drawing.Size(126, 19);
            fullscreenCb.TabIndex = 13;
            fullscreenCb.Text = "All Apps Fullscreen";
            fullscreenCb.UseVisualStyleBackColor = true;
            // 
            // shellDialog
            // 
            shellDialog.FileName = "*.exe";
            // 
            // argTb
            // 
            argTb.Location = new System.Drawing.Point(132, 42);
            argTb.Name = "argTb";
            argTb.Size = new System.Drawing.Size(399, 23);
            argTb.TabIndex = 14;
            // 
            // argLb
            // 
            argLb.AutoSize = true;
            argLb.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            argLb.Location = new System.Drawing.Point(8, 45);
            argLb.Name = "argLb";
            argLb.Size = new System.Drawing.Size(84, 20);
            argLb.TabIndex = 15;
            argLb.Text = "Arguments:";
            // 
            // slWin32UserControl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(argLb);
            Controls.Add(argTb);
            Controls.Add(fullscreenCb);
            Controls.Add(browseBt);
            Controls.Add(shellTb);
            Controls.Add(shellLb);
            Name = "slWin32UserControl";
            Size = new System.Drawing.Size(616, 90);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button browseBt;
        public System.Windows.Forms.TextBox shellTb;
        private System.Windows.Forms.Label shellLb;
        public System.Windows.Forms.CheckBox fullscreenCb;
        private System.Windows.Forms.OpenFileDialog shellDialog;
        public System.Windows.Forms.TextBox argTb;
        private System.Windows.Forms.Label argLb;
    }
}
