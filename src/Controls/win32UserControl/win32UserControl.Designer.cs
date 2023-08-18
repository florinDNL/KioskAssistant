namespace kioskAssistant.Controls
{
    partial class win32UserControl
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
            exeLb = new System.Windows.Forms.Label();
            argLb = new System.Windows.Forms.Label();
            exeTb = new System.Windows.Forms.TextBox();
            argTb = new System.Windows.Forms.TextBox();
            browseBt = new System.Windows.Forms.Button();
            exeDialog = new System.Windows.Forms.OpenFileDialog();
            SuspendLayout();
            // 
            // exeLb
            // 
            exeLb.AutoSize = true;
            exeLb.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            exeLb.Location = new System.Drawing.Point(14, 14);
            exeLb.Name = "exeLb";
            exeLb.Size = new System.Drawing.Size(88, 20);
            exeLb.TabIndex = 1;
            exeLb.Text = "Executable: ";
            // 
            // argLb
            // 
            argLb.AutoSize = true;
            argLb.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            argLb.Location = new System.Drawing.Point(14, 47);
            argLb.Name = "argLb";
            argLb.Size = new System.Drawing.Size(84, 20);
            argLb.TabIndex = 2;
            argLb.Text = "Arguments:";
            // 
            // exeTb
            // 
            exeTb.Location = new System.Drawing.Point(108, 11);
            exeTb.Name = "exeTb";
            exeTb.PlaceholderText = "Type the path to the .exe manually or browse to a local executable";
            exeTb.Size = new System.Drawing.Size(405, 23);
            exeTb.TabIndex = 3;
            // 
            // argTb
            // 
            argTb.Location = new System.Drawing.Point(108, 44);
            argTb.Name = "argTb";
            argTb.Size = new System.Drawing.Size(405, 23);
            argTb.TabIndex = 4;
            // 
            // browseBt
            // 
            browseBt.Location = new System.Drawing.Point(519, 11);
            browseBt.Name = "browseBt";
            browseBt.Size = new System.Drawing.Size(75, 23);
            browseBt.TabIndex = 5;
            browseBt.Text = "Browse";
            browseBt.UseVisualStyleBackColor = true;
            browseBt.Click += browseBt_Click;
            // 
            // win32UserControl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(browseBt);
            Controls.Add(argTb);
            Controls.Add(exeTb);
            Controls.Add(argLb);
            Controls.Add(exeLb);
            Name = "win32UserControl";
            Size = new System.Drawing.Size(616, 90);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public System.Windows.Forms.Label exeLb;
        private System.Windows.Forms.Label argLb;
        public System.Windows.Forms.TextBox exeTb;
        public System.Windows.Forms.TextBox argTb;
        private System.Windows.Forms.Button browseBt;
        private System.Windows.Forms.OpenFileDialog exeDialog;
    }
}
