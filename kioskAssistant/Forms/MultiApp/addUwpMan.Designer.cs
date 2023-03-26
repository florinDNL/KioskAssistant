namespace kioskAssistant.Forms.MultiApp
{
    partial class addUwpMan
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
            nameLb = new System.Windows.Forms.Label();
            aumidLb = new System.Windows.Forms.Label();
            nameTb = new System.Windows.Forms.TextBox();
            aumidTb = new System.Windows.Forms.TextBox();
            addBt = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // nameLb
            // 
            nameLb.AutoSize = true;
            nameLb.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            nameLb.Location = new System.Drawing.Point(5, 15);
            nameLb.Name = "nameLb";
            nameLb.Size = new System.Drawing.Size(52, 20);
            nameLb.TabIndex = 0;
            nameLb.Text = "Name:";
            // 
            // aumidLb
            // 
            aumidLb.AutoSize = true;
            aumidLb.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            aumidLb.Location = new System.Drawing.Point(5, 52);
            aumidLb.Name = "aumidLb";
            aumidLb.Size = new System.Drawing.Size(60, 20);
            aumidLb.TabIndex = 1;
            aumidLb.Text = "AUMID:";
            // 
            // nameTb
            // 
            nameTb.Location = new System.Drawing.Point(79, 12);
            nameTb.Name = "nameTb";
            nameTb.PlaceholderText = "e.g.: Calculator";
            nameTb.Size = new System.Drawing.Size(311, 23);
            nameTb.TabIndex = 2;
            // 
            // aumidTb
            // 
            aumidTb.Location = new System.Drawing.Point(79, 49);
            aumidTb.Name = "aumidTb";
            aumidTb.PlaceholderText = "e.g.: Microsoft.WindowsCalculator_8wekyb3d8bbwe!App";
            aumidTb.Size = new System.Drawing.Size(311, 23);
            aumidTb.TabIndex = 3;
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
            // addUwpMan
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(439, 82);
            Controls.Add(addBt);
            Controls.Add(aumidTb);
            Controls.Add(nameTb);
            Controls.Add(aumidLb);
            Controls.Add(nameLb);
            MinimizeBox = false;
            Name = "addUwpMan";
            ShowIcon = false;
            Text = "Manually Add UWP App";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label nameLb;
        private System.Windows.Forms.Label aumidLb;
        private System.Windows.Forms.TextBox nameTb;
        private System.Windows.Forms.TextBox aumidTb;
        private System.Windows.Forms.Button addBt;
    }
}