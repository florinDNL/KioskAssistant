
namespace kioskAssistant
{
    partial class appProfile
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(appProfile));
            this.uwpAppClb = new System.Windows.Forms.CheckedListBox();
            this.addUwpAppLabel = new System.Windows.Forms.Label();
            this.logoBox = new System.Windows.Forms.PictureBox();
            this.addExeDialog = new System.Windows.Forms.OpenFileDialog();
            this.addWin32AppLabel = new System.Windows.Forms.Label();
            this.addWin32AppBt = new System.Windows.Forms.Button();
            this.win32AppLb = new System.Windows.Forms.ListBox();
            this.remWin32AppBt = new System.Windows.Forms.Button();
            this.showAllCb = new System.Windows.Forms.CheckBox();
            this.addAppGroupBt = new System.Windows.Forms.Button();
            this.lnkFileLb = new System.Windows.Forms.ListBox();
            this.lnkFileLabel = new System.Windows.Forms.Label();
            this.addLnkBt = new System.Windows.Forms.Button();
            this.remLnkBt = new System.Windows.Forms.Button();
            this.groupsLabel = new System.Windows.Forms.Label();
            this.addLnkDialog = new System.Windows.Forms.OpenFileDialog();
            this.groupsLv = new System.Windows.Forms.ListView();
            this.name = new System.Windows.Forms.ColumnHeader();
            this.apps = new System.Windows.Forms.ColumnHeader();
            this.remGrpBt = new System.Windows.Forms.Button();
            this.guidLabel = new System.Windows.Forms.Label();
            this.profileLabel = new System.Windows.Forms.Label();
            this.saveProfBt = new System.Windows.Forms.Button();
            this.cancelBt = new System.Windows.Forms.Button();
            this.showTaskbarCb = new System.Windows.Forms.CheckBox();
            this.dlPermCb = new System.Windows.Forms.CheckBox();
            this.rdPermCb = new System.Windows.Forms.CheckBox();
            this.confAutoLaunchBt = new System.Windows.Forms.Button();
            this.noRestrictCb = new System.Windows.Forms.CheckBox();
            this.win11_cb = new System.Windows.Forms.CheckBox();
            this.win10_cb = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.logoBox)).BeginInit();
            this.SuspendLayout();
            // 
            // uwpAppClb
            // 
            this.uwpAppClb.CheckOnClick = true;
            this.uwpAppClb.FormattingEnabled = true;
            this.uwpAppClb.Location = new System.Drawing.Point(12, 94);
            this.uwpAppClb.Name = "uwpAppClb";
            this.uwpAppClb.Size = new System.Drawing.Size(295, 292);
            this.uwpAppClb.Sorted = true;
            this.uwpAppClb.TabIndex = 0;
            // 
            // addUwpAppLabel
            // 
            this.addUwpAppLabel.AutoSize = true;
            this.addUwpAppLabel.Location = new System.Drawing.Point(11, 71);
            this.addUwpAppLabel.Name = "addUwpAppLabel";
            this.addUwpAppLabel.Size = new System.Drawing.Size(127, 15);
            this.addUwpAppLabel.TabIndex = 1;
            this.addUwpAppLabel.Text = "Add UWP Applications";
            // 
            // logoBox
            // 
            this.logoBox.Image = ((System.Drawing.Image)(resources.GetObject("logoBox.Image")));
            this.logoBox.Location = new System.Drawing.Point(565, 12);
            this.logoBox.Name = "logoBox";
            this.logoBox.Size = new System.Drawing.Size(231, 51);
            this.logoBox.TabIndex = 4;
            this.logoBox.TabStop = false;
            // 
            // addExeDialog
            // 
            this.addExeDialog.DefaultExt = "exe";
            this.addExeDialog.Filter = "exe files (*.exe)|*.exe|All files (*.*)|*.*\"";
            this.addExeDialog.InitialDirectory = "C:\\\\";
            this.addExeDialog.Title = "Select Executable";
            // 
            // addWin32AppLabel
            // 
            this.addWin32AppLabel.AutoSize = true;
            this.addWin32AppLabel.Location = new System.Drawing.Point(323, 85);
            this.addWin32AppLabel.Name = "addWin32AppLabel";
            this.addWin32AppLabel.Size = new System.Drawing.Size(169, 15);
            this.addWin32AppLabel.TabIndex = 5;
            this.addWin32AppLabel.Text = "Add Win32 (.exe) Applications:";
            // 
            // addWin32AppBt
            // 
            this.addWin32AppBt.Location = new System.Drawing.Point(676, 77);
            this.addWin32AppBt.Name = "addWin32AppBt";
            this.addWin32AppBt.Size = new System.Drawing.Size(39, 23);
            this.addWin32AppBt.TabIndex = 6;
            this.addWin32AppBt.Text = "Add";
            this.addWin32AppBt.UseVisualStyleBackColor = true;
            this.addWin32AppBt.Click += new System.EventHandler(this.addWin32AppBt_Click);
            // 
            // win32AppLb
            // 
            this.win32AppLb.FormattingEnabled = true;
            this.win32AppLb.ItemHeight = 15;
            this.win32AppLb.Location = new System.Drawing.Point(323, 103);
            this.win32AppLb.Name = "win32AppLb";
            this.win32AppLb.Size = new System.Drawing.Size(473, 124);
            this.win32AppLb.Sorted = true;
            this.win32AppLb.TabIndex = 7;
            // 
            // remWin32AppBt
            // 
            this.remWin32AppBt.Location = new System.Drawing.Point(721, 77);
            this.remWin32AppBt.Name = "remWin32AppBt";
            this.remWin32AppBt.Size = new System.Drawing.Size(75, 23);
            this.remWin32AppBt.TabIndex = 9;
            this.remWin32AppBt.Text = "Remove";
            this.remWin32AppBt.UseVisualStyleBackColor = true;
            this.remWin32AppBt.Click += new System.EventHandler(this.remWin32AppBt_Click);
            // 
            // showAllCb
            // 
            this.showAllCb.AutoSize = true;
            this.showAllCb.Location = new System.Drawing.Point(178, 70);
            this.showAllCb.Name = "showAllCb";
            this.showAllCb.Size = new System.Drawing.Size(129, 19);
            this.showAllCb.TabIndex = 11;
            this.showAllCb.Text = "Show all UWP Apps";
            this.showAllCb.UseVisualStyleBackColor = true;
            this.showAllCb.CheckedChanged += new System.EventHandler(this.showAllCb_CheckedChanged);
            // 
            // addAppGroupBt
            // 
            this.addAppGroupBt.Location = new System.Drawing.Point(588, 407);
            this.addAppGroupBt.Name = "addAppGroupBt";
            this.addAppGroupBt.Size = new System.Drawing.Size(208, 23);
            this.addAppGroupBt.TabIndex = 12;
            this.addAppGroupBt.Text = "Add and Configure App Group";
            this.addAppGroupBt.UseVisualStyleBackColor = true;
            this.addAppGroupBt.Click += new System.EventHandler(this.addAppGroupBt_Click);
            // 
            // lnkFileLb
            // 
            this.lnkFileLb.FormattingEnabled = true;
            this.lnkFileLb.ItemHeight = 15;
            this.lnkFileLb.Location = new System.Drawing.Point(323, 262);
            this.lnkFileLb.Name = "lnkFileLb";
            this.lnkFileLb.Size = new System.Drawing.Size(473, 124);
            this.lnkFileLb.Sorted = true;
            this.lnkFileLb.TabIndex = 13;
            // 
            // lnkFileLabel
            // 
            this.lnkFileLabel.AutoSize = true;
            this.lnkFileLabel.Location = new System.Drawing.Point(323, 246);
            this.lnkFileLabel.Name = "lnkFileLabel";
            this.lnkFileLabel.Size = new System.Drawing.Size(174, 15);
            this.lnkFileLabel.TabIndex = 14;
            this.lnkFileLabel.Text = "Add icons (.lnk) for Win32 Apps";
            // 
            // addLnkBt
            // 
            this.addLnkBt.Location = new System.Drawing.Point(676, 238);
            this.addLnkBt.Name = "addLnkBt";
            this.addLnkBt.Size = new System.Drawing.Size(39, 23);
            this.addLnkBt.TabIndex = 15;
            this.addLnkBt.Text = "Add";
            this.addLnkBt.UseVisualStyleBackColor = true;
            this.addLnkBt.Click += new System.EventHandler(this.addLnkBt_Click);
            // 
            // remLnkBt
            // 
            this.remLnkBt.Location = new System.Drawing.Point(721, 238);
            this.remLnkBt.Name = "remLnkBt";
            this.remLnkBt.Size = new System.Drawing.Size(75, 23);
            this.remLnkBt.TabIndex = 16;
            this.remLnkBt.Text = "Remove";
            this.remLnkBt.UseVisualStyleBackColor = true;
            this.remLnkBt.Click += new System.EventHandler(this.remLnkBt_Click);
            // 
            // groupsLabel
            // 
            this.groupsLabel.AutoSize = true;
            this.groupsLabel.Location = new System.Drawing.Point(11, 389);
            this.groupsLabel.Name = "groupsLabel";
            this.groupsLabel.Size = new System.Drawing.Size(45, 15);
            this.groupsLabel.TabIndex = 18;
            this.groupsLabel.Text = "Groups";
            // 
            // addLnkDialog
            // 
            this.addLnkDialog.DefaultExt = "lnk";
            this.addLnkDialog.FileName = "openFileDialog2";
            this.addLnkDialog.Filter = "lnk files (*.lnk)|*.lnk|All files (*.*)|*.*\"";
            this.addLnkDialog.InitialDirectory = "C:\\ProgramData\\Microsoft\\Windows\\Start Menu\\Programs";
            // 
            // groupsLv
            // 
            this.groupsLv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.name,
            this.apps});
            this.groupsLv.GridLines = true;
            this.groupsLv.HideSelection = false;
            this.groupsLv.Location = new System.Drawing.Point(12, 407);
            this.groupsLv.Name = "groupsLv";
            this.groupsLv.Size = new System.Drawing.Size(561, 118);
            this.groupsLv.TabIndex = 19;
            this.groupsLv.UseCompatibleStateImageBehavior = false;
            this.groupsLv.View = System.Windows.Forms.View.Details;
            // 
            // name
            // 
            this.name.Text = "Name";
            this.name.Width = 100;
            // 
            // apps
            // 
            this.apps.Text = "Applications";
            this.apps.Width = 457;
            // 
            // remGrpBt
            // 
            this.remGrpBt.Location = new System.Drawing.Point(588, 465);
            this.remGrpBt.Name = "remGrpBt";
            this.remGrpBt.Size = new System.Drawing.Size(208, 23);
            this.remGrpBt.TabIndex = 20;
            this.remGrpBt.Text = "Remove Group";
            this.remGrpBt.UseVisualStyleBackColor = true;
            this.remGrpBt.Click += new System.EventHandler(this.remGrpBt_Click);
            // 
            // guidLabel
            // 
            this.guidLabel.AutoSize = true;
            this.guidLabel.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.guidLabel.Location = new System.Drawing.Point(9, 22);
            this.guidLabel.Name = "guidLabel";
            this.guidLabel.Size = new System.Drawing.Size(54, 25);
            this.guidLabel.TabIndex = 21;
            this.guidLabel.Text = "GUID";
            // 
            // profileLabel
            // 
            this.profileLabel.AutoSize = true;
            this.profileLabel.Location = new System.Drawing.Point(12, 12);
            this.profileLabel.Name = "profileLabel";
            this.profileLabel.Size = new System.Drawing.Size(41, 15);
            this.profileLabel.TabIndex = 22;
            this.profileLabel.Text = "Profile";
            // 
            // saveProfBt
            // 
            this.saveProfBt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.saveProfBt.Location = new System.Drawing.Point(676, 494);
            this.saveProfBt.Name = "saveProfBt";
            this.saveProfBt.Size = new System.Drawing.Size(120, 31);
            this.saveProfBt.TabIndex = 23;
            this.saveProfBt.Text = "Save Profile";
            this.saveProfBt.UseVisualStyleBackColor = true;
            this.saveProfBt.Click += new System.EventHandler(this.saveProfBt_Click);
            // 
            // cancelBt
            // 
            this.cancelBt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cancelBt.Location = new System.Drawing.Point(588, 494);
            this.cancelBt.Name = "cancelBt";
            this.cancelBt.Size = new System.Drawing.Size(75, 31);
            this.cancelBt.TabIndex = 24;
            this.cancelBt.Text = "Cancel";
            this.cancelBt.UseVisualStyleBackColor = true;
            this.cancelBt.Click += new System.EventHandler(this.cancelBt_Click);
            // 
            // showTaskbarCb
            // 
            this.showTaskbarCb.AutoSize = true;
            this.showTaskbarCb.Location = new System.Drawing.Point(397, 8);
            this.showTaskbarCb.Name = "showTaskbarCb";
            this.showTaskbarCb.Size = new System.Drawing.Size(97, 19);
            this.showTaskbarCb.TabIndex = 25;
            this.showTaskbarCb.Text = "Show Taskbar";
            this.showTaskbarCb.UseVisualStyleBackColor = true;
            // 
            // dlPermCb
            // 
            this.dlPermCb.AutoSize = true;
            this.dlPermCb.Location = new System.Drawing.Point(397, 24);
            this.dlPermCb.Name = "dlPermCb";
            this.dlPermCb.Size = new System.Drawing.Size(160, 19);
            this.dlPermCb.TabIndex = 26;
            this.dlPermCb.Text = "Downloads Folder Access";
            this.dlPermCb.UseVisualStyleBackColor = true;
            // 
            // rdPermCb
            // 
            this.rdPermCb.AutoSize = true;
            this.rdPermCb.Location = new System.Drawing.Point(397, 40);
            this.rdPermCb.Name = "rdPermCb";
            this.rdPermCb.Size = new System.Drawing.Size(162, 19);
            this.rdPermCb.TabIndex = 27;
            this.rdPermCb.Text = "Removable Device Access";
            this.rdPermCb.UseVisualStyleBackColor = true;
            // 
            // confAutoLaunchBt
            // 
            this.confAutoLaunchBt.Location = new System.Drawing.Point(588, 436);
            this.confAutoLaunchBt.Name = "confAutoLaunchBt";
            this.confAutoLaunchBt.Size = new System.Drawing.Size(208, 23);
            this.confAutoLaunchBt.TabIndex = 28;
            this.confAutoLaunchBt.Text = "Configure auto-launch App";
            this.confAutoLaunchBt.UseVisualStyleBackColor = true;
            this.confAutoLaunchBt.Click += new System.EventHandler(this.confAutoLaunchBt_Click);
            // 
            // noRestrictCb
            // 
            this.noRestrictCb.AutoSize = true;
            this.noRestrictCb.Location = new System.Drawing.Point(397, 56);
            this.noRestrictCb.Name = "noRestrictCb";
            this.noRestrictCb.Size = new System.Drawing.Size(106, 19);
            this.noRestrictCb.TabIndex = 29;
            this.noRestrictCb.Text = "No Restrictions";
            this.noRestrictCb.UseVisualStyleBackColor = true;
            this.noRestrictCb.CheckedChanged += new System.EventHandler(this.noRestrictCb_CheckedChanged);
            // 
            // win11_cb
            // 
            this.win11_cb.AutoSize = true;
            this.win11_cb.Location = new System.Drawing.Point(105, 49);
            this.win11_cb.Name = "win11_cb";
            this.win11_cb.Size = new System.Drawing.Size(87, 19);
            this.win11_cb.TabIndex = 31;
            this.win11_cb.Text = "Windows11";
            this.win11_cb.UseVisualStyleBackColor = true;
            this.win11_cb.CheckedChanged += new System.EventHandler(this.win11_CheckedChanged);
            // 
            // win10_cb
            // 
            this.win10_cb.AutoSize = true;
            this.win10_cb.Checked = true;
            this.win10_cb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.win10_cb.Location = new System.Drawing.Point(12, 49);
            this.win10_cb.Name = "win10_cb";
            this.win10_cb.Size = new System.Drawing.Size(87, 19);
            this.win10_cb.TabIndex = 30;
            this.win10_cb.Text = "Windows10";
            this.win10_cb.UseVisualStyleBackColor = true;
            this.win10_cb.CheckedChanged += new System.EventHandler(this.win10_CheckedChanged);
            // 
            // appProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 534);
            this.Controls.Add(this.win11_cb);
            this.Controls.Add(this.win10_cb);
            this.Controls.Add(this.noRestrictCb);
            this.Controls.Add(this.confAutoLaunchBt);
            this.Controls.Add(this.rdPermCb);
            this.Controls.Add(this.dlPermCb);
            this.Controls.Add(this.showTaskbarCb);
            this.Controls.Add(this.cancelBt);
            this.Controls.Add(this.saveProfBt);
            this.Controls.Add(this.profileLabel);
            this.Controls.Add(this.guidLabel);
            this.Controls.Add(this.remGrpBt);
            this.Controls.Add(this.groupsLv);
            this.Controls.Add(this.groupsLabel);
            this.Controls.Add(this.remLnkBt);
            this.Controls.Add(this.addLnkBt);
            this.Controls.Add(this.lnkFileLabel);
            this.Controls.Add(this.lnkFileLb);
            this.Controls.Add(this.addAppGroupBt);
            this.Controls.Add(this.showAllCb);
            this.Controls.Add(this.remWin32AppBt);
            this.Controls.Add(this.win32AppLb);
            this.Controls.Add(this.addWin32AppBt);
            this.Controls.Add(this.addWin32AppLabel);
            this.Controls.Add(this.logoBox);
            this.Controls.Add(this.addUwpAppLabel);
            this.Controls.Add(this.uwpAppClb);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "appProfile";
            this.Text = "Add Profile";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.appProfile_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.appProfile_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.logoBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.CheckedListBox uwpAppClb;
        public System.Windows.Forms.ComboBox comboBox1;
        public System.Windows.Forms.ListBox win32AppLb;
        public System.Windows.Forms.ListBox lnkFileLb;
        public System.Windows.Forms.Label guidLabel;

        private System.Windows.Forms.Label addUwpAppLabel;   
        private System.Windows.Forms.PictureBox logoBox;
        private System.Windows.Forms.OpenFileDialog addExeDialog;
        private System.Windows.Forms.Label addWin32AppLabel;
        private System.Windows.Forms.Button addWin32AppBt;        
        private System.Windows.Forms.Button remWin32AppBt;
        private System.Windows.Forms.CheckBox showAllCb;
        private System.Windows.Forms.Button addAppGroupBt;        
        private System.Windows.Forms.Label lnkFileLabel;
        private System.Windows.Forms.Button addLnkBt;
        private System.Windows.Forms.Button remLnkBt;
        private System.Windows.Forms.Label groupsLabel;
        private System.Windows.Forms.OpenFileDialog addLnkDialog;
        private System.Windows.Forms.ListView groupsLv;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader apps;
        private System.Windows.Forms.Button remGrpBt;
        private System.Windows.Forms.Label profileLabel;
        private System.Windows.Forms.Button saveProfBt;
        private System.Windows.Forms.Button cancelBt;
        private System.Windows.Forms.CheckBox showTaskbarCb;
        private System.Windows.Forms.CheckBox dlPermCb;
        private System.Windows.Forms.CheckBox rdPermCb;
        private System.Windows.Forms.Button confAutoLaunchBt;
        private System.Windows.Forms.CheckBox noRestrictCb;
        public System.Windows.Forms.CheckBox win11_cb;
        private System.Windows.Forms.CheckBox win10_cb;
    }
}

