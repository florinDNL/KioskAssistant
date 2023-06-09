﻿namespace kioskAssistant.Forms
{
    partial class customShell
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(customShell));
            actionCb = new System.Windows.Forms.ComboBox();
            label1 = new System.Windows.Forms.Label();
            appTypeLb = new System.Windows.Forms.Label();
            appTypeCb = new System.Windows.Forms.ComboBox();
            shellPanel = new System.Windows.Forms.Panel();
            guidLabel = new System.Windows.Forms.Label();
            saveCsBt = new System.Windows.Forms.Button();
            fullscreenCb = new System.Windows.Forms.CheckBox();
            SuspendLayout();
            // 
            // actionCb
            // 
            actionCb.FormattingEnabled = true;
            actionCb.Items.AddRange(new object[] { "RestartShell", "RestartDevice", "ShutdownDevice", "DoNothing" });
            actionCb.Location = new System.Drawing.Point(138, 70);
            actionCb.Name = "actionCb";
            actionCb.Size = new System.Drawing.Size(203, 23);
            actionCb.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(29, 70);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(88, 20);
            label1.TabIndex = 4;
            label1.Text = "Error Action";
            // 
            // appTypeLb
            // 
            appTypeLb.AutoSize = true;
            appTypeLb.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            appTypeLb.Location = new System.Drawing.Point(29, 42);
            appTypeLb.Name = "appTypeLb";
            appTypeLb.Size = new System.Drawing.Size(75, 20);
            appTypeLb.TabIndex = 5;
            appTypeLb.Text = "App Type:";
            // 
            // appTypeCb
            // 
            appTypeCb.FormattingEnabled = true;
            appTypeCb.Items.AddRange(new object[] { "Edge", "UWP", "Win32" });
            appTypeCb.Location = new System.Drawing.Point(138, 42);
            appTypeCb.Name = "appTypeCb";
            appTypeCb.Size = new System.Drawing.Size(203, 23);
            appTypeCb.TabIndex = 6;
            appTypeCb.SelectedIndexChanged += appTypeCb_SelectedIndexChanged;
            // 
            // shellPanel
            // 
            shellPanel.Location = new System.Drawing.Point(32, 124);
            shellPanel.Name = "shellPanel";
            shellPanel.Size = new System.Drawing.Size(619, 137);
            shellPanel.TabIndex = 7;
            // 
            // guidLabel
            // 
            guidLabel.AutoSize = true;
            guidLabel.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            guidLabel.Location = new System.Drawing.Point(12, 9);
            guidLabel.Name = "guidLabel";
            guidLabel.Size = new System.Drawing.Size(54, 25);
            guidLabel.TabIndex = 30;
            guidLabel.Text = "GUID";
            // 
            // saveCsBt
            // 
            saveCsBt.Location = new System.Drawing.Point(508, 61);
            saveCsBt.Name = "saveCsBt";
            saveCsBt.Size = new System.Drawing.Size(136, 39);
            saveCsBt.TabIndex = 31;
            saveCsBt.Text = "Save Custom Shell";
            saveCsBt.UseVisualStyleBackColor = true;
            saveCsBt.Click += saveCsBt_Click;
            // 
            // fullscreenCb
            // 
            fullscreenCb.AutoSize = true;
            fullscreenCb.Checked = true;
            fullscreenCb.CheckState = System.Windows.Forms.CheckState.Checked;
            fullscreenCb.Location = new System.Drawing.Point(32, 99);
            fullscreenCb.Name = "fullscreenCb";
            fullscreenCb.Size = new System.Drawing.Size(126, 19);
            fullscreenCb.TabIndex = 32;
            fullscreenCb.Text = "All Apps Fullscreen";
            fullscreenCb.UseVisualStyleBackColor = true;
            // 
            // customShell
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(672, 275);
            Controls.Add(fullscreenCb);
            Controls.Add(saveCsBt);
            Controls.Add(guidLabel);
            Controls.Add(shellPanel);
            Controls.Add(appTypeCb);
            Controls.Add(appTypeLb);
            Controls.Add(label1);
            Controls.Add(actionCb);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "customShell";
            Text = "Custom Shell";
            FormClosing += customShell_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.ComboBox actionCb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label appTypeLb;
        private System.Windows.Forms.ComboBox appTypeCb;
        private System.Windows.Forms.Panel shellPanel;
        public System.Windows.Forms.Label guidLabel;
        private System.Windows.Forms.Button saveCsBt;
        public System.Windows.Forms.CheckBox fullscreenCb;
    }
}