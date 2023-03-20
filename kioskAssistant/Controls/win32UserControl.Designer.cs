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
            this.exeLb = new System.Windows.Forms.Label();
            this.argLb = new System.Windows.Forms.Label();
            this.exeTb = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.browseBt = new System.Windows.Forms.Button();
            this.exeDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // exeLb
            // 
            this.exeLb.AutoSize = true;
            this.exeLb.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.exeLb.Location = new System.Drawing.Point(8, 27);
            this.exeLb.Name = "exeLb";
            this.exeLb.Size = new System.Drawing.Size(88, 20);
            this.exeLb.TabIndex = 1;
            this.exeLb.Text = "Executable: ";
            // 
            // argLb
            // 
            this.argLb.AutoSize = true;
            this.argLb.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.argLb.Location = new System.Drawing.Point(8, 60);
            this.argLb.Name = "argLb";
            this.argLb.Size = new System.Drawing.Size(84, 20);
            this.argLb.TabIndex = 2;
            this.argLb.Text = "Arguments:";
            // 
            // exeTb
            // 
            this.exeTb.Location = new System.Drawing.Point(102, 24);
            this.exeTb.Name = "exeTb";
            this.exeTb.Size = new System.Drawing.Size(405, 23);
            this.exeTb.TabIndex = 3;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(102, 57);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(405, 23);
            this.textBox2.TabIndex = 4;
            // 
            // browseBt
            // 
            this.browseBt.Location = new System.Drawing.Point(513, 24);
            this.browseBt.Name = "browseBt";
            this.browseBt.Size = new System.Drawing.Size(75, 23);
            this.browseBt.TabIndex = 5;
            this.browseBt.Text = "Browse";
            this.browseBt.UseVisualStyleBackColor = true;
            this.browseBt.Click += new System.EventHandler(this.browseBt_Click);
            // 
            // win32UserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.browseBt);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.exeTb);
            this.Controls.Add(this.argLb);
            this.Controls.Add(this.exeLb);
            this.Name = "win32UserControl";
            this.Size = new System.Drawing.Size(608, 180);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label exeLb;
        private System.Windows.Forms.Label argLb;
        private System.Windows.Forms.TextBox exeTb;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button browseBt;
        private System.Windows.Forms.OpenFileDialog exeDialog;
    }
}
