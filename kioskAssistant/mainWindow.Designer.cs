
namespace kioskAssistant
{
    partial class mainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainWindow));
            this.logoBox = new System.Windows.Forms.PictureBox();
            this.addUsrBt = new System.Windows.Forms.Button();
            this.addGrpBt = new System.Windows.Forms.Button();
            this.addAppProfileBt = new System.Windows.Forms.Button();
            this.addGlobProfBt = new System.Windows.Forms.Button();
            this.appProfileLb = new System.Windows.Forms.ListBox();
            this.addAutoLogonAccBt = new System.Windows.Forms.Button();
            this.delAppProfileBt = new System.Windows.Forms.Button();
            this.assignBt = new System.Windows.Forms.Button();
            this.removeGrBt = new System.Windows.Forms.Button();
            this.accountsGv = new System.Windows.Forms.DataGridView();
            this.acc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.appProfile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.genXmlBt = new System.Windows.Forms.Button();
            this.saveXML = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.logoBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountsGv)).BeginInit();
            this.SuspendLayout();
            // 
            // logoBox
            // 
            this.logoBox.Image = ((System.Drawing.Image)(resources.GetObject("logoBox.Image")));
            this.logoBox.Location = new System.Drawing.Point(12, 387);
            this.logoBox.Name = "logoBox";
            this.logoBox.Size = new System.Drawing.Size(231, 51);
            this.logoBox.TabIndex = 5;
            this.logoBox.TabStop = false;
            // 
            // addUsrBt
            // 
            this.addUsrBt.Location = new System.Drawing.Point(12, 12);
            this.addUsrBt.Name = "addUsrBt";
            this.addUsrBt.Size = new System.Drawing.Size(77, 51);
            this.addUsrBt.TabIndex = 6;
            this.addUsrBt.Text = "Add User";
            this.addUsrBt.UseVisualStyleBackColor = true;
            this.addUsrBt.Click += new System.EventHandler(this.addUsrBt_Click);
            // 
            // addGrpBt
            // 
            this.addGrpBt.Location = new System.Drawing.Point(95, 11);
            this.addGrpBt.Name = "addGrpBt";
            this.addGrpBt.Size = new System.Drawing.Size(80, 51);
            this.addGrpBt.TabIndex = 7;
            this.addGrpBt.Text = "Add Group";
            this.addGrpBt.UseVisualStyleBackColor = true;
            this.addGrpBt.Click += new System.EventHandler(this.addGrpBt_Click);
            // 
            // addAppProfileBt
            // 
            this.addAppProfileBt.Location = new System.Drawing.Point(505, 11);
            this.addAppProfileBt.Name = "addAppProfileBt";
            this.addAppProfileBt.Size = new System.Drawing.Size(170, 51);
            this.addAppProfileBt.TabIndex = 8;
            this.addAppProfileBt.Text = "Add Application Profile";
            this.addAppProfileBt.UseVisualStyleBackColor = true;
            this.addAppProfileBt.Click += new System.EventHandler(this.addAppProfileBt_Click);
            // 
            // addGlobProfBt
            // 
            this.addGlobProfBt.Location = new System.Drawing.Point(181, 11);
            this.addGlobProfBt.Name = "addGlobProfBt";
            this.addGlobProfBt.Size = new System.Drawing.Size(141, 22);
            this.addGlobProfBt.TabIndex = 9;
            this.addGlobProfBt.Text = "Global Profile";
            this.addGlobProfBt.UseVisualStyleBackColor = true;
            this.addGlobProfBt.Click += new System.EventHandler(this.addGlobProfBt_Click);
            // 
            // appProfileLb
            // 
            this.appProfileLb.FormattingEnabled = true;
            this.appProfileLb.ItemHeight = 15;
            this.appProfileLb.Location = new System.Drawing.Point(505, 68);
            this.appProfileLb.Name = "appProfileLb";
            this.appProfileLb.Size = new System.Drawing.Size(283, 304);
            this.appProfileLb.TabIndex = 11;
            // 
            // addAutoLogonAccBt
            // 
            this.addAutoLogonAccBt.Location = new System.Drawing.Point(181, 39);
            this.addAutoLogonAccBt.Name = "addAutoLogonAccBt";
            this.addAutoLogonAccBt.Size = new System.Drawing.Size(141, 23);
            this.addAutoLogonAccBt.TabIndex = 12;
            this.addAutoLogonAccBt.Text = "AutoLogon Account";
            this.addAutoLogonAccBt.UseVisualStyleBackColor = true;
            this.addAutoLogonAccBt.Click += new System.EventHandler(this.addAutoLogonAccBt_Click);
            // 
            // delAppProfileBt
            // 
            this.delAppProfileBt.Location = new System.Drawing.Point(681, 11);
            this.delAppProfileBt.Name = "delAppProfileBt";
            this.delAppProfileBt.Size = new System.Drawing.Size(107, 51);
            this.delAppProfileBt.TabIndex = 13;
            this.delAppProfileBt.Text = "Delete";
            this.delAppProfileBt.UseVisualStyleBackColor = true;
            this.delAppProfileBt.Click += new System.EventHandler(this.delAppProfileBt_Click);
            // 
            // assignBt
            // 
            this.assignBt.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.assignBt.Location = new System.Drawing.Point(458, 116);
            this.assignBt.Name = "assignBt";
            this.assignBt.Size = new System.Drawing.Size(41, 216);
            this.assignBt.TabIndex = 15;
            this.assignBt.Text = "< >";
            this.assignBt.UseVisualStyleBackColor = true;
            this.assignBt.Click += new System.EventHandler(this.assignBt_Click);
            // 
            // removeGrBt
            // 
            this.removeGrBt.Location = new System.Drawing.Point(364, 12);
            this.removeGrBt.Name = "removeGrBt";
            this.removeGrBt.Size = new System.Drawing.Size(88, 51);
            this.removeGrBt.TabIndex = 16;
            this.removeGrBt.Text = "Remove";
            this.removeGrBt.UseVisualStyleBackColor = true;
            this.removeGrBt.Click += new System.EventHandler(this.removeGrBt_Click);
            // 
            // accountsGv
            // 
            this.accountsGv.AllowUserToAddRows = false;
            this.accountsGv.AllowUserToDeleteRows = false;
            this.accountsGv.BackgroundColor = System.Drawing.SystemColors.Window;
            this.accountsGv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.accountsGv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.acc,
            this.type,
            this.appProfile});
            this.accountsGv.Location = new System.Drawing.Point(12, 69);
            this.accountsGv.Name = "accountsGv";
            this.accountsGv.ReadOnly = true;
            this.accountsGv.RowHeadersVisible = false;
            this.accountsGv.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.accountsGv.RowTemplate.Height = 25;
            this.accountsGv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.accountsGv.Size = new System.Drawing.Size(440, 304);
            this.accountsGv.TabIndex = 17;
            this.accountsGv.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.accountsGv_CellValueChanged);
            this.accountsGv.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.accountsGv_RowsAdded);
            this.accountsGv.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.accountsGv_RowsRemoved);
            // 
            // acc
            // 
            this.acc.HeaderText = "Account";
            this.acc.MinimumWidth = 180;
            this.acc.Name = "acc";
            this.acc.ReadOnly = true;
            this.acc.Width = 180;
            // 
            // type
            // 
            this.type.HeaderText = "Type";
            this.type.Name = "type";
            this.type.ReadOnly = true;
            this.type.Width = 45;
            // 
            // appProfile
            // 
            this.appProfile.HeaderText = "Application Profile";
            this.appProfile.MinimumWidth = 210;
            this.appProfile.Name = "appProfile";
            this.appProfile.ReadOnly = true;
            this.appProfile.Width = 210;
            // 
            // genXmlBt
            // 
            this.genXmlBt.Location = new System.Drawing.Point(599, 387);
            this.genXmlBt.Name = "genXmlBt";
            this.genXmlBt.Size = new System.Drawing.Size(189, 50);
            this.genXmlBt.TabIndex = 18;
            this.genXmlBt.Text = "Generate XML";
            this.genXmlBt.UseVisualStyleBackColor = true;
            this.genXmlBt.Click += new System.EventHandler(this.genXmlBt_Click);
            // 
            // saveXML
            // 
            this.saveXML.DefaultExt = "xml";
            this.saveXML.FileName = "multiAppKiosk";
            this.saveXML.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*\"";
            // 
            // mainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.genXmlBt);
            this.Controls.Add(this.accountsGv);
            this.Controls.Add(this.removeGrBt);
            this.Controls.Add(this.assignBt);
            this.Controls.Add(this.delAppProfileBt);
            this.Controls.Add(this.addAutoLogonAccBt);
            this.Controls.Add(this.appProfileLb);
            this.Controls.Add(this.addGlobProfBt);
            this.Controls.Add(this.addAppProfileBt);
            this.Controls.Add(this.addGrpBt);
            this.Controls.Add(this.addUsrBt);
            this.Controls.Add(this.logoBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "mainWindow";
            this.Text = "Kiosk Assistant";
            ((System.ComponentModel.ISupportInitialize)(this.logoBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountsGv)).EndInit();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.DataGridViewTextBoxColumn acc;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewTextBoxColumn appProfile;
        private System.Windows.Forms.Button genXmlBt;
        private System.Windows.Forms.SaveFileDialog saveXML;
    }
}