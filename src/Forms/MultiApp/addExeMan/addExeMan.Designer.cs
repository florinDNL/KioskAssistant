namespace kioskAssistant.Forms.MultiApp
{
    partial class addExeMan
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
            exeLb = new System.Windows.Forms.Label();
            lnkLb = new System.Windows.Forms.Label();
            exeTb = new System.Windows.Forms.TextBox();
            lnkTb = new System.Windows.Forms.TextBox();
            addBt = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // exeLb
            // 
            exeLb.AutoSize = true;
            exeLb.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            exeLb.Location = new System.Drawing.Point(5, 15);
            exeLb.Name = "exeLb";
            exeLb.Size = new System.Drawing.Size(62, 20);
            exeLb.TabIndex = 0;
            exeLb.Text = "Exe File:";
            // 
            // lnkLb
            // 
            lnkLb.AutoSize = true;
            lnkLb.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lnkLb.Location = new System.Drawing.Point(5, 52);
            lnkLb.Name = "lnkLb";
            lnkLb.Size = new System.Drawing.Size(58, 20);
            lnkLb.TabIndex = 1;
            lnkLb.Text = "Lnk File";
            // 
            // exeTb
            // 
            exeTb.Location = new System.Drawing.Point(79, 12);
            exeTb.Name = "exeTb";
            exeTb.PlaceholderText = "e.g.: C:\\Windows\\System32\\explorer.exe";
            exeTb.Size = new System.Drawing.Size(311, 23);
            exeTb.TabIndex = 2;
            // 
            // lnkTb
            // 
            lnkTb.Location = new System.Drawing.Point(79, 49);
            lnkTb.Name = "lnkTb";
            lnkTb.PlaceholderText = "(Optional) e.g. C:\\Temp\\explorer.lnk";
            lnkTb.Size = new System.Drawing.Size(311, 23);
            lnkTb.TabIndex = 3;
            // 
            // addBt
            // 
            addBt.Location = new System.Drawing.Point(396, 12);
            addBt.Name = "addBt";
            addBt.Size = new System.Drawing.Size(37, 60);
            addBt.TabIndex = 4;
            addBt.Text = "Add";
            addBt.UseVisualStyleBackColor = true;
            addBt.Click += addBt_Click;
            // 
            // addExeMan
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(439, 82);
            Controls.Add(addBt);
            Controls.Add(lnkTb);
            Controls.Add(exeTb);
            Controls.Add(lnkLb);
            Controls.Add(exeLb);
            MinimizeBox = false;
            Name = "addExeMan";
            ShowIcon = false;
            Text = "Manually Add UWP App";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label exeLb;
        private System.Windows.Forms.Label lnkLb;
        private System.Windows.Forms.TextBox exeTb;
        private System.Windows.Forms.TextBox lnkTb;
        private System.Windows.Forms.Button addBt;
    }
}