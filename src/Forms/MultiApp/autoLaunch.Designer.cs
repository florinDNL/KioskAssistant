
namespace kioskAssistant
{
    partial class autoLaunch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(autoLaunch));
            this.okBt = new System.Windows.Forms.Button();
            this.cancelBt = new System.Windows.Forms.Button();
            this.allAppsCb = new System.Windows.Forms.ComboBox();
            this.argumentsTb = new System.Windows.Forms.TextBox();
            this.clearBt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // okBt
            // 
            this.okBt.Location = new System.Drawing.Point(363, 62);
            this.okBt.Name = "okBt";
            this.okBt.Size = new System.Drawing.Size(75, 23);
            this.okBt.TabIndex = 1;
            this.okBt.Text = "OK";
            this.okBt.UseVisualStyleBackColor = true;
            this.okBt.Click += new System.EventHandler(this.okBt_Click);
            // 
            // cancelBt
            // 
            this.cancelBt.Location = new System.Drawing.Point(282, 62);
            this.cancelBt.Name = "cancelBt";
            this.cancelBt.Size = new System.Drawing.Size(75, 23);
            this.cancelBt.TabIndex = 2;
            this.cancelBt.Text = "Cancel";
            this.cancelBt.UseVisualStyleBackColor = true;
            this.cancelBt.Click += new System.EventHandler(this.cancelBt_Click);
            // 
            // allAppsCb
            // 
            this.allAppsCb.FormattingEnabled = true;
            this.allAppsCb.Location = new System.Drawing.Point(12, 23);
            this.allAppsCb.Name = "allAppsCb";
            this.allAppsCb.Size = new System.Drawing.Size(326, 23);
            this.allAppsCb.TabIndex = 3;
            // 
            // argumentsTb
            // 
            this.argumentsTb.Location = new System.Drawing.Point(363, 22);
            this.argumentsTb.Name = "argumentsTb";
            this.argumentsTb.PlaceholderText = "Arguments";
            this.argumentsTb.Size = new System.Drawing.Size(371, 23);
            this.argumentsTb.TabIndex = 4;
            // 
            // clearBt
            // 
            this.clearBt.Location = new System.Drawing.Point(12, 62);
            this.clearBt.Name = "clearBt";
            this.clearBt.Size = new System.Drawing.Size(75, 23);
            this.clearBt.TabIndex = 5;
            this.clearBt.Text = "Clear";
            this.clearBt.UseVisualStyleBackColor = true;
            this.clearBt.Click += new System.EventHandler(this.clearBt_Click);
            // 
            // autoLaunch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 93);
            this.Controls.Add(this.clearBt);
            this.Controls.Add(this.argumentsTb);
            this.Controls.Add(this.allAppsCb);
            this.Controls.Add(this.cancelBt);
            this.Controls.Add(this.okBt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "autoLaunch";
            this.Text = "Add auto-launch application";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.ComboBox allAppsCb;
        public System.Windows.Forms.TextBox argumentsTb;

        private System.Windows.Forms.Button okBt;
        private System.Windows.Forms.Button cancelBt;
        private System.Windows.Forms.Button clearBt;
    }
}