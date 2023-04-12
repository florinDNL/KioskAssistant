
namespace kioskAssistant
{
    partial class multiApp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(multiApp));
            logoBox = new System.Windows.Forms.PictureBox();
            addUsrBt = new System.Windows.Forms.Button();
            addGrpBt = new System.Windows.Forms.Button();
            addAppProfileBt = new System.Windows.Forms.Button();
            addGlobProfBt = new System.Windows.Forms.Button();
            appProfileLb = new System.Windows.Forms.ListBox();
            addAutoLogonAccBt = new System.Windows.Forms.Button();
            delAppProfileBt = new System.Windows.Forms.Button();
            assignBt = new System.Windows.Forms.Button();
            removeGrBt = new System.Windows.Forms.Button();
            accountsGv = new System.Windows.Forms.DataGridView();
            genXmlBt = new System.Windows.Forms.Button();
            saveXML = new System.Windows.Forms.SaveFileDialog();
            kModeBt = new System.Windows.Forms.Button();
            acc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            appProfile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)logoBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)accountsGv).BeginInit();
            SuspendLayout();
            // 
            // logoBox
            // 
            logoBox.Image = (System.Drawing.Image)resources.GetObject("logoBox.Image");
            logoBox.Location = new System.Drawing.Point(12, 387);
            logoBox.Name = "logoBox";
            logoBox.Size = new System.Drawing.Size(231, 51);
            logoBox.TabIndex = 5;
            logoBox.TabStop = false;
            // 
            // addUsrBt
            // 
            addUsrBt.Location = new System.Drawing.Point(12, 12);
            addUsrBt.Name = "addUsrBt";
            addUsrBt.Size = new System.Drawing.Size(77, 51);
            addUsrBt.TabIndex = 6;
            addUsrBt.Text = "Add User";
            addUsrBt.UseVisualStyleBackColor = true;
            addUsrBt.Click += addUsrBt_Click;
            // 
            // addGrpBt
            // 
            addGrpBt.Location = new System.Drawing.Point(95, 11);
            addGrpBt.Name = "addGrpBt";
            addGrpBt.Size = new System.Drawing.Size(80, 51);
            addGrpBt.TabIndex = 7;
            addGrpBt.Text = "Add Group";
            addGrpBt.UseVisualStyleBackColor = true;
            addGrpBt.Click += addGrpBt_Click;
            // 
            // addAppProfileBt
            // 
            addAppProfileBt.Location = new System.Drawing.Point(505, 11);
            addAppProfileBt.Name = "addAppProfileBt";
            addAppProfileBt.Size = new System.Drawing.Size(170, 22);
            addAppProfileBt.TabIndex = 8;
            addAppProfileBt.Text = "Add Multi-App Kiosk";
            addAppProfileBt.UseVisualStyleBackColor = true;
            addAppProfileBt.Click += addAppProfileBt_Click;
            // 
            // addGlobProfBt
            // 
            addGlobProfBt.Location = new System.Drawing.Point(181, 11);
            addGlobProfBt.Name = "addGlobProfBt";
            addGlobProfBt.Size = new System.Drawing.Size(141, 22);
            addGlobProfBt.TabIndex = 9;
            addGlobProfBt.Text = "Global Profile";
            addGlobProfBt.UseVisualStyleBackColor = true;
            addGlobProfBt.Click += addGlobProfBt_Click;
            // 
            // appProfileLb
            // 
            appProfileLb.FormattingEnabled = true;
            appProfileLb.ItemHeight = 15;
            appProfileLb.Location = new System.Drawing.Point(505, 68);
            appProfileLb.Name = "appProfileLb";
            appProfileLb.Size = new System.Drawing.Size(283, 304);
            appProfileLb.TabIndex = 11;
            // 
            // addAutoLogonAccBt
            // 
            addAutoLogonAccBt.Location = new System.Drawing.Point(181, 39);
            addAutoLogonAccBt.Name = "addAutoLogonAccBt";
            addAutoLogonAccBt.Size = new System.Drawing.Size(141, 23);
            addAutoLogonAccBt.TabIndex = 12;
            addAutoLogonAccBt.Text = "AutoLogon Account";
            addAutoLogonAccBt.UseVisualStyleBackColor = true;
            addAutoLogonAccBt.Click += addAutoLogonAccBt_Click;
            // 
            // delAppProfileBt
            // 
            delAppProfileBt.Location = new System.Drawing.Point(681, 11);
            delAppProfileBt.Name = "delAppProfileBt";
            delAppProfileBt.Size = new System.Drawing.Size(107, 51);
            delAppProfileBt.TabIndex = 13;
            delAppProfileBt.Text = "Delete";
            delAppProfileBt.UseVisualStyleBackColor = true;
            delAppProfileBt.Click += delAppProfileBt_Click;
            // 
            // assignBt
            // 
            assignBt.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            assignBt.Location = new System.Drawing.Point(458, 116);
            assignBt.Name = "assignBt";
            assignBt.Size = new System.Drawing.Size(41, 216);
            assignBt.TabIndex = 15;
            assignBt.Text = "< >";
            assignBt.UseVisualStyleBackColor = true;
            assignBt.Click += assignBt_Click;
            // 
            // removeGrBt
            // 
            removeGrBt.Location = new System.Drawing.Point(364, 12);
            removeGrBt.Name = "removeGrBt";
            removeGrBt.Size = new System.Drawing.Size(88, 51);
            removeGrBt.TabIndex = 16;
            removeGrBt.Text = "Remove";
            removeGrBt.UseVisualStyleBackColor = true;
            removeGrBt.Click += removeGrBt_Click;
            // 
            // accountsGv
            // 
            accountsGv.AllowUserToAddRows = false;
            accountsGv.AllowUserToDeleteRows = false;
            accountsGv.BackgroundColor = System.Drawing.SystemColors.Window;
            accountsGv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            accountsGv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { acc, type, appProfile });
            accountsGv.Location = new System.Drawing.Point(12, 69);
            accountsGv.Name = "accountsGv";
            accountsGv.ReadOnly = true;
            accountsGv.RowHeadersVisible = false;
            accountsGv.RowHeadersWidth = 102;
            accountsGv.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            accountsGv.RowTemplate.Height = 25;
            accountsGv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            accountsGv.Size = new System.Drawing.Size(440, 304);
            accountsGv.TabIndex = 17;
            accountsGv.CellValueChanged += accountsGv_CellValueChanged;
            accountsGv.RowsAdded += accountsGv_RowsAdded;
            accountsGv.RowsRemoved += accountsGv_RowsRemoved;
            // 
            // genXmlBt
            // 
            genXmlBt.Location = new System.Drawing.Point(599, 387);
            genXmlBt.Name = "genXmlBt";
            genXmlBt.Size = new System.Drawing.Size(189, 50);
            genXmlBt.TabIndex = 18;
            genXmlBt.Text = "Generate XML";
            genXmlBt.UseVisualStyleBackColor = true;
            genXmlBt.Click += genXmlBt_Click;
            // 
            // saveXML
            // 
            saveXML.DefaultExt = "xml";
            saveXML.FileName = "multiAppKiosk";
            saveXML.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*\"";
            // 
            // kModeBt
            // 
            kModeBt.Location = new System.Drawing.Point(505, 39);
            kModeBt.Name = "kModeBt";
            kModeBt.Size = new System.Drawing.Size(170, 22);
            kModeBt.TabIndex = 19;
            kModeBt.Text = "Add Kiosk Mode App";
            kModeBt.UseVisualStyleBackColor = true;
            kModeBt.Click += kModeBt_Click;
            // 
            // acc
            // 
            acc.HeaderText = "Account";
            acc.MinimumWidth = 180;
            acc.Name = "acc";
            acc.ReadOnly = true;
            acc.Width = 180;
            // 
            // type
            // 
            type.HeaderText = "Type";
            type.MinimumWidth = 50;
            type.Name = "type";
            type.ReadOnly = true;
            type.Width = 56;
            // 
            // appProfile
            // 
            appProfile.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            appProfile.HeaderText = "Application Profile";
            appProfile.MinimumWidth = 210;
            appProfile.Name = "appProfile";
            appProfile.ReadOnly = true;
            // 
            // multiApp
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(kModeBt);
            Controls.Add(genXmlBt);
            Controls.Add(accountsGv);
            Controls.Add(removeGrBt);
            Controls.Add(assignBt);
            Controls.Add(delAppProfileBt);
            Controls.Add(addAutoLogonAccBt);
            Controls.Add(appProfileLb);
            Controls.Add(addGlobProfBt);
            Controls.Add(addAppProfileBt);
            Controls.Add(addGrpBt);
            Controls.Add(addUsrBt);
            Controls.Add(logoBox);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "multiApp";
            Text = "MultiApp / KioskMode App XML";
            ((System.ComponentModel.ISupportInitialize)logoBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)accountsGv).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.PictureBox logoBox;
        private System.Windows.Forms.Button addUsrBt;
        private System.Windows.Forms.Button addGrpBt;
        private System.Windows.Forms.Button addAppProfileBt;
        private System.Windows.Forms.Button addGlobProfBt;
        private System.Windows.Forms.ListBox appProfileLb;
        private System.Windows.Forms.Button addAutoLogonAccBt;
        private System.Windows.Forms.Button delAppProfileBt;
        private System.Windows.Forms.Button assignBt;
        private System.Windows.Forms.Button removeGrBt;
        private System.Windows.Forms.DataGridView accountsGv;
        private System.Windows.Forms.Button genXmlBt;
        private System.Windows.Forms.SaveFileDialog saveXML;
        private System.Windows.Forms.Button kModeBt;
        private System.Windows.Forms.DataGridViewTextBoxColumn acc;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewTextBoxColumn appProfile;
    }
}