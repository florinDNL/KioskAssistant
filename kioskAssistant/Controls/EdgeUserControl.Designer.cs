namespace kioskAssistant
{
    partial class EdgeUserControl
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
            this.urlLb = new System.Windows.Forms.Label();
            this.urlTb = new System.Windows.Forms.TextBox();
            this.browsingLb = new System.Windows.Forms.Label();
            this.browsingCb = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.idleTb = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // urlLb
            // 
            this.urlLb.AutoSize = true;
            this.urlLb.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.urlLb.Location = new System.Drawing.Point(8, 27);
            this.urlLb.Name = "urlLb";
            this.urlLb.Size = new System.Drawing.Size(38, 20);
            this.urlLb.TabIndex = 0;
            this.urlLb.Text = "URL:";
            // 
            // urlTb
            // 
            this.urlTb.Location = new System.Drawing.Point(147, 24);
            this.urlTb.Name = "urlTb";
            this.urlTb.PlaceholderText = "https://www.bing.com/";
            this.urlTb.Size = new System.Drawing.Size(445, 23);
            this.urlTb.TabIndex = 1;
            // 
            // browsingLb
            // 
            this.browsingLb.AutoSize = true;
            this.browsingLb.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.browsingLb.Location = new System.Drawing.Point(8, 61);
            this.browsingLb.Name = "browsingLb";
            this.browsingLb.Size = new System.Drawing.Size(108, 20);
            this.browsingLb.TabIndex = 2;
            this.browsingLb.Text = "Browsing Type:";
            // 
            // browsingCb
            // 
            this.browsingCb.FormattingEnabled = true;
            this.browsingCb.Items.AddRange(new object[] {
            "Digital Signage",
            "Public Browsing"});
            this.browsingCb.Location = new System.Drawing.Point(147, 58);
            this.browsingCb.Name = "browsingCb";
            this.browsingCb.Size = new System.Drawing.Size(200, 23);
            this.browsingCb.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(8, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Idle Timeout:";
            // 
            // idleTb
            // 
            this.idleTb.Location = new System.Drawing.Point(147, 94);
            this.idleTb.Name = "idleTb";
            this.idleTb.PlaceholderText = "0";
            this.idleTb.Size = new System.Drawing.Size(70, 23);
            this.idleTb.TabIndex = 5;
            // 
            // EdgeUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.idleTb);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.browsingCb);
            this.Controls.Add(this.browsingLb);
            this.Controls.Add(this.urlTb);
            this.Controls.Add(this.urlLb);
            this.Name = "EdgeUserControl";
            this.Size = new System.Drawing.Size(608, 316);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label urlLb;
        private System.Windows.Forms.TextBox urlTb;
        private System.Windows.Forms.Label browsingLb;
        private System.Windows.Forms.ComboBox browsingCb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox idleTb;
    }
}
