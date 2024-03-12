namespace kioskAssistant.Controls
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
            urlLb = new System.Windows.Forms.Label();
            urlTb = new System.Windows.Forms.TextBox();
            browsingLb = new System.Windows.Forms.Label();
            browsingCb = new System.Windows.Forms.ComboBox();
            label1 = new System.Windows.Forms.Label();
            idleTb = new System.Windows.Forms.TextBox();
            SuspendLayout();
            // 
            // urlLb
            // 
            urlLb.AutoSize = true;
            urlLb.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            urlLb.Location = new System.Drawing.Point(8, 27);
            urlLb.Name = "urlLb";
            urlLb.Size = new System.Drawing.Size(38, 20);
            urlLb.TabIndex = 0;
            urlLb.Text = "URL:";
            // 
            // urlTb
            // 
            urlTb.Location = new System.Drawing.Point(147, 24);
            urlTb.Name = "urlTb";
            urlTb.PlaceholderText = "https://www.bing.com/";
            urlTb.Size = new System.Drawing.Size(445, 23);
            urlTb.TabIndex = 1;
            // 
            // browsingLb
            // 
            browsingLb.AutoSize = true;
            browsingLb.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            browsingLb.Location = new System.Drawing.Point(8, 61);
            browsingLb.Name = "browsingLb";
            browsingLb.Size = new System.Drawing.Size(108, 20);
            browsingLb.TabIndex = 2;
            browsingLb.Text = "Browsing Type:";
            // 
            // browsingCb
            // 
            browsingCb.FormattingEnabled = true;
            browsingCb.Items.AddRange(new object[] { "Digital Signage", "Public Browsing" });
            browsingCb.Location = new System.Drawing.Point(147, 58);
            browsingCb.Name = "browsingCb";
            browsingCb.Size = new System.Drawing.Size(200, 23);
            browsingCb.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(8, 97);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(96, 20);
            label1.TabIndex = 4;
            label1.Text = "Idle Timeout:";
            // 
            // idleTb
            // 
            idleTb.Location = new System.Drawing.Point(147, 94);
            idleTb.Name = "idleTb";
            idleTb.PlaceholderText = "0";
            idleTb.Size = new System.Drawing.Size(70, 23);
            idleTb.TabIndex = 5;
            // 
            // EdgeUserControl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(idleTb);
            Controls.Add(label1);
            Controls.Add(browsingCb);
            Controls.Add(browsingLb);
            Controls.Add(urlTb);
            Controls.Add(urlLb);
            Name = "EdgeUserControl";
            Size = new System.Drawing.Size(619, 137);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label urlLb;
        public System.Windows.Forms.TextBox urlTb;
        private System.Windows.Forms.Label browsingLb;
        public System.Windows.Forms.ComboBox browsingCb;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox idleTb;
    }
}
