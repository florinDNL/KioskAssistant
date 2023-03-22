namespace kioskAssistant.Forms
{
    partial class shellLauncher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(shellLauncher));
            accountsGv = new System.Windows.Forms.DataGridView();
            acc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            appProfile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            assignBt = new System.Windows.Forms.Button();
            appProfileLb = new System.Windows.Forms.ListBox();
            logoBox = new System.Windows.Forms.PictureBox();
            genXmlBt = new System.Windows.Forms.Button();
            nameBt = new System.Windows.Forms.Button();
            sidBt = new System.Windows.Forms.Button();
            cShellbt = new System.Windows.Forms.Button();
            nameSidTb = new System.Windows.Forms.TextBox();
            remBt = new System.Windows.Forms.Button();
            sidLb = new System.Windows.Forms.Label();
            remCsBt = new System.Windows.Forms.Button();
            saveXML = new System.Windows.Forms.SaveFileDialog();
            autologonBt = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)accountsGv).BeginInit();
            ((System.ComponentModel.ISupportInitialize)logoBox).BeginInit();
            SuspendLayout();
            // 
            // accountsGv
            // 
            accountsGv.AllowUserToAddRows = false;
            accountsGv.AllowUserToDeleteRows = false;
            accountsGv.BackgroundColor = System.Drawing.SystemColors.Window;
            accountsGv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            accountsGv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { acc, appProfile });
            accountsGv.Location = new System.Drawing.Point(12, 74);
            accountsGv.Name = "accountsGv";
            accountsGv.ReadOnly = true;
            accountsGv.RowHeadersVisible = false;
            accountsGv.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            accountsGv.RowTemplate.Height = 25;
            accountsGv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            accountsGv.Size = new System.Drawing.Size(440, 304);
            accountsGv.TabIndex = 20;
            accountsGv.CellValueChanged += accountsGv_CellValueChanged;
            accountsGv.RowsAdded += accountsGv_RowsAdded;
            accountsGv.RowsRemoved += accountsGv_RowsRemoved;
            // 
            // acc
            // 
            acc.HeaderText = "Account";
            acc.MinimumWidth = 218;
            acc.Name = "acc";
            acc.ReadOnly = true;
            acc.Width = 218;
            // 
            // appProfile
            // 
            appProfile.HeaderText = "Application Profile";
            appProfile.MinimumWidth = 218;
            appProfile.Name = "appProfile";
            appProfile.ReadOnly = true;
            appProfile.Width = 218;
            // 
            // assignBt
            // 
            assignBt.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            assignBt.Location = new System.Drawing.Point(458, 121);
            assignBt.Name = "assignBt";
            assignBt.Size = new System.Drawing.Size(41, 216);
            assignBt.TabIndex = 19;
            assignBt.Text = "< >";
            assignBt.UseVisualStyleBackColor = true;
            assignBt.Click += assignBt_Click;
            // 
            // appProfileLb
            // 
            appProfileLb.FormattingEnabled = true;
            appProfileLb.ItemHeight = 15;
            appProfileLb.Location = new System.Drawing.Point(505, 73);
            appProfileLb.Name = "appProfileLb";
            appProfileLb.Size = new System.Drawing.Size(283, 304);
            appProfileLb.TabIndex = 18;
            // 
            // logoBox
            // 
            logoBox.Image = (System.Drawing.Image)resources.GetObject("logoBox.Image");
            logoBox.Location = new System.Drawing.Point(12, 387);
            logoBox.Name = "logoBox";
            logoBox.Size = new System.Drawing.Size(231, 51);
            logoBox.TabIndex = 21;
            logoBox.TabStop = false;
            // 
            // genXmlBt
            // 
            genXmlBt.Location = new System.Drawing.Point(599, 388);
            genXmlBt.Name = "genXmlBt";
            genXmlBt.Size = new System.Drawing.Size(189, 50);
            genXmlBt.TabIndex = 22;
            genXmlBt.Text = "Generate XML";
            genXmlBt.UseVisualStyleBackColor = true;
            genXmlBt.Click += genXmlBt_Click;
            // 
            // nameBt
            // 
            nameBt.Location = new System.Drawing.Point(262, 15);
            nameBt.Name = "nameBt";
            nameBt.Size = new System.Drawing.Size(92, 23);
            nameBt.TabIndex = 23;
            nameBt.Text = "Add Name";
            nameBt.UseVisualStyleBackColor = true;
            nameBt.Click += nameBt_Click;
            // 
            // sidBt
            // 
            sidBt.Location = new System.Drawing.Point(360, 15);
            sidBt.Name = "sidBt";
            sidBt.Size = new System.Drawing.Size(92, 23);
            sidBt.TabIndex = 24;
            sidBt.Text = "Add SID";
            sidBt.UseVisualStyleBackColor = true;
            sidBt.Click += sidBt_Click;
            // 
            // cShellbt
            // 
            cShellbt.Location = new System.Drawing.Point(505, 15);
            cShellbt.Name = "cShellbt";
            cShellbt.Size = new System.Drawing.Size(282, 23);
            cShellbt.TabIndex = 25;
            cShellbt.Text = "Add Custom Shell";
            cShellbt.UseVisualStyleBackColor = true;
            cShellbt.Click += cShellbt_Click;
            // 
            // nameSidTb
            // 
            nameSidTb.Location = new System.Drawing.Point(12, 15);
            nameSidTb.Name = "nameSidTb";
            nameSidTb.PlaceholderText = "Name or Sid";
            nameSidTb.Size = new System.Drawing.Size(244, 23);
            nameSidTb.TabIndex = 26;
            // 
            // remBt
            // 
            remBt.Location = new System.Drawing.Point(360, 384);
            remBt.Name = "remBt";
            remBt.Size = new System.Drawing.Size(92, 23);
            remBt.TabIndex = 27;
            remBt.Text = "Remove";
            remBt.UseVisualStyleBackColor = true;
            remBt.Click += remBt_Click;
            // 
            // sidLb
            // 
            sidLb.AutoSize = true;
            sidLb.ForeColor = System.Drawing.Color.Red;
            sidLb.Location = new System.Drawing.Point(12, 52);
            sidLb.Name = "sidLb";
            sidLb.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            sidLb.Size = new System.Drawing.Size(286, 15);
            sidLb.TabIndex = 28;
            sidLb.Text = "Sid can be user sid, local group sid, and AD group sid";
            // 
            // remCsBt
            // 
            remCsBt.Location = new System.Drawing.Point(505, 44);
            remCsBt.Name = "remCsBt";
            remCsBt.Size = new System.Drawing.Size(282, 23);
            remCsBt.TabIndex = 29;
            remCsBt.Text = "Remove Custom Shell";
            remCsBt.UseVisualStyleBackColor = true;
            remCsBt.Click += remCsBt_Click;
            // 
            // saveXML
            // 
            saveXML.FileName = "shellLauncher";
            saveXML.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*\"";
            // 
            // autologonBt
            // 
            autologonBt.Location = new System.Drawing.Point(312, 43);
            autologonBt.Name = "autologonBt";
            autologonBt.Size = new System.Drawing.Size(140, 24);
            autologonBt.TabIndex = 30;
            autologonBt.Text = "Add Autologon";
            autologonBt.UseVisualStyleBackColor = true;
            autologonBt.Click += autologonBt_Click;
            // 
            // shellLauncher
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(autologonBt);
            Controls.Add(remCsBt);
            Controls.Add(sidLb);
            Controls.Add(remBt);
            Controls.Add(nameSidTb);
            Controls.Add(cShellbt);
            Controls.Add(sidBt);
            Controls.Add(nameBt);
            Controls.Add(genXmlBt);
            Controls.Add(logoBox);
            Controls.Add(accountsGv);
            Controls.Add(assignBt);
            Controls.Add(appProfileLb);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "shellLauncher";
            Text = "Shell Launcher XML";
            ((System.ComponentModel.ISupportInitialize)accountsGv).EndInit();
            ((System.ComponentModel.ISupportInitialize)logoBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView accountsGv;
        private System.Windows.Forms.Button assignBt;
        private System.Windows.Forms.ListBox appProfileLb;
        private System.Windows.Forms.PictureBox logoBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn acc;
        private System.Windows.Forms.DataGridViewTextBoxColumn appProfile;
        private System.Windows.Forms.Button genXmlBt;
        private System.Windows.Forms.Button nameBt;
        private System.Windows.Forms.Button sidBt;
        private System.Windows.Forms.Button cShellbt;
        private System.Windows.Forms.TextBox nameSidTb;
        private System.Windows.Forms.Button remBt;
        private System.Windows.Forms.Label sidLb;
        private System.Windows.Forms.Button remCsBt;
        private System.Windows.Forms.SaveFileDialog saveXML;
        private System.Windows.Forms.Button autologonBt;
    }
}