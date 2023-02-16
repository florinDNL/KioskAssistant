
namespace kioskAssistant
{
    partial class dispName
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dispName));
            this.msgLabel1 = new System.Windows.Forms.Label();
            this.msgLabel2 = new System.Windows.Forms.Label();
            this.dispNameTb = new System.Windows.Forms.TextBox();
            this.okBt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // msgLabel1
            // 
            this.msgLabel1.AutoSize = true;
            this.msgLabel1.Location = new System.Drawing.Point(22, 9);
            this.msgLabel1.Name = "msgLabel1";
            this.msgLabel1.Size = new System.Drawing.Size(266, 15);
            this.msgLabel1.TabIndex = 0;
            this.msgLabel1.Text = "Enter a display name for the Autologon account. ";
            // 
            // msgLabel2
            // 
            this.msgLabel2.AutoSize = true;
            this.msgLabel2.Location = new System.Drawing.Point(60, 24);
            this.msgLabel2.Name = "msgLabel2";
            this.msgLabel2.Size = new System.Drawing.Size(171, 15);
            this.msgLabel2.TabIndex = 1;
            this.msgLabel2.Text = "Leave blank to display nothing.";
            // 
            // dispNameTb
            // 
            this.dispNameTb.Location = new System.Drawing.Point(22, 42);
            this.dispNameTb.Name = "dispNameTb";
            this.dispNameTb.Size = new System.Drawing.Size(266, 23);
            this.dispNameTb.TabIndex = 2;
            this.dispNameTb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // okBt
            // 
            this.okBt.Location = new System.Drawing.Point(114, 71);
            this.okBt.Name = "okBt";
            this.okBt.Size = new System.Drawing.Size(75, 23);
            this.okBt.TabIndex = 3;
            this.okBt.Text = "OK";
            this.okBt.UseVisualStyleBackColor = true;
            this.okBt.Click += new System.EventHandler(this.okBt_Click);
            // 
            // dispName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 97);
            this.Controls.Add(this.okBt);
            this.Controls.Add(this.dispNameTb);
            this.Controls.Add(this.msgLabel2);
            this.Controls.Add(this.msgLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "dispName";
            this.Text = "Display Name";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.TextBox dispNameTb;

        private System.Windows.Forms.Label msgLabel1;
        private System.Windows.Forms.Label msgLabel2;        
        private System.Windows.Forms.Button okBt;
    }
}