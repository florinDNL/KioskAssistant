
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
            uwpAppClb = new System.Windows.Forms.CheckedListBox();
            addUwpAppLabel = new System.Windows.Forms.Label();
            logoBox = new System.Windows.Forms.PictureBox();
            addExeDialog = new System.Windows.Forms.OpenFileDialog();
            addWin32AppLabel = new System.Windows.Forms.Label();
            addWin32AppBt = new System.Windows.Forms.Button();
            win32AppLb = new System.Windows.Forms.ListBox();
            remWin32AppBt = new System.Windows.Forms.Button();
            showAllCb = new System.Windows.Forms.CheckBox();
            addAppGroupBt = new System.Windows.Forms.Button();
            lnkFileLb = new System.Windows.Forms.ListBox();
            lnkFileLabel = new System.Windows.Forms.Label();
            addLnkBt = new System.Windows.Forms.Button();
            remLnkBt = new System.Windows.Forms.Button();
            groupsLabel = new System.Windows.Forms.Label();
            addLnkDialog = new System.Windows.Forms.OpenFileDialog();
            groupsLv = new System.Windows.Forms.ListView();
            name = new System.Windows.Forms.ColumnHeader();
            apps = new System.Windows.Forms.ColumnHeader();
            remGrpBt = new System.Windows.Forms.Button();
            guidLabel = new System.Windows.Forms.Label();
            profileLabel = new System.Windows.Forms.Label();
            saveProfBt = new System.Windows.Forms.Button();
            cancelBt = new System.Windows.Forms.Button();
            showTaskbarCb = new System.Windows.Forms.CheckBox();
            dlPermCb = new System.Windows.Forms.CheckBox();
            rdPermCb = new System.Windows.Forms.CheckBox();
            confAutoLaunchBt = new System.Windows.Forms.Button();
            noRestrictCb = new System.Windows.Forms.CheckBox();
            win11_cb = new System.Windows.Forms.CheckBox();
            win10_cb = new System.Windows.Forms.CheckBox();
            manUwpBt = new System.Windows.Forms.Button();
            manExeBt = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)logoBox).BeginInit();
            SuspendLayout();
            // 
            // uwpAppClb
            // 
            uwpAppClb.CheckOnClick = true;
            uwpAppClb.FormattingEnabled = true;
            uwpAppClb.Location = new System.Drawing.Point(12, 94);
            uwpAppClb.Name = "uwpAppClb";
            uwpAppClb.Size = new System.Drawing.Size(295, 292);
            uwpAppClb.Sorted = true;
            uwpAppClb.TabIndex = 0;
            // 
            // addUwpAppLabel
            // 
            addUwpAppLabel.AutoSize = true;
            addUwpAppLabel.Location = new System.Drawing.Point(11, 77);
            addUwpAppLabel.Name = "addUwpAppLabel";
            addUwpAppLabel.Size = new System.Drawing.Size(127, 15);
            addUwpAppLabel.TabIndex = 1;
            addUwpAppLabel.Text = "Add UWP Applications";
            // 
            // logoBox
            // 
            logoBox.Image = (System.Drawing.Image)resources.GetObject("logoBox.Image");
            logoBox.Location = new System.Drawing.Point(565, 12);
            logoBox.Name = "logoBox";
            logoBox.Size = new System.Drawing.Size(231, 51);
            logoBox.TabIndex = 4;
            logoBox.TabStop = false;
            // 
            // addExeDialog
            // 
            addExeDialog.DefaultExt = "exe";
            addExeDialog.Filter = "exe files (*.exe)|*.exe|All files (*.*)|*.*\"";
            addExeDialog.InitialDirectory = "C:\\\\";
            addExeDialog.Title = "Select Executable";
            // 
            // addWin32AppLabel
            // 
            addWin32AppLabel.AutoSize = true;
            addWin32AppLabel.Location = new System.Drawing.Point(323, 85);
            addWin32AppLabel.Name = "addWin32AppLabel";
            addWin32AppLabel.Size = new System.Drawing.Size(166, 15);
            addWin32AppLabel.TabIndex = 5;
            addWin32AppLabel.Text = "Add Win32 (.exe) Applications";
            // 
            // addWin32AppBt
            // 
            addWin32AppBt.Location = new System.Drawing.Point(636, 77);
            addWin32AppBt.Name = "addWin32AppBt";
            addWin32AppBt.Size = new System.Drawing.Size(79, 23);
            addWin32AppBt.TabIndex = 6;
            addWin32AppBt.Text = "Browse .exe";
            addWin32AppBt.UseVisualStyleBackColor = true;
            addWin32AppBt.Click += addWin32AppBt_Click;
            // 
            // win32AppLb
            // 
            win32AppLb.FormattingEnabled = true;
            win32AppLb.ItemHeight = 15;
            win32AppLb.Location = new System.Drawing.Point(323, 103);
            win32AppLb.Name = "win32AppLb";
            win32AppLb.Size = new System.Drawing.Size(473, 124);
            win32AppLb.Sorted = true;
            win32AppLb.TabIndex = 7;
            // 
            // remWin32AppBt
            // 
            remWin32AppBt.Location = new System.Drawing.Point(721, 77);
            remWin32AppBt.Name = "remWin32AppBt";
            remWin32AppBt.Size = new System.Drawing.Size(75, 23);
            remWin32AppBt.TabIndex = 9;
            remWin32AppBt.Text = "Remove";
            remWin32AppBt.UseVisualStyleBackColor = true;
            remWin32AppBt.Click += remWin32AppBt_Click;
            // 
            // showAllCb
            // 
            showAllCb.AutoSize = true;
            showAllCb.Location = new System.Drawing.Point(198, 49);
            showAllCb.Name = "showAllCb";
            showAllCb.Size = new System.Drawing.Size(129, 19);
            showAllCb.TabIndex = 11;
            showAllCb.Text = "Show all UWP Apps";
            showAllCb.UseVisualStyleBackColor = true;
            showAllCb.CheckedChanged += showAllCb_CheckedChanged;
            // 
            // addAppGroupBt
            // 
            addAppGroupBt.Location = new System.Drawing.Point(588, 407);
            addAppGroupBt.Name = "addAppGroupBt";
            addAppGroupBt.Size = new System.Drawing.Size(208, 23);
            addAppGroupBt.TabIndex = 12;
            addAppGroupBt.Text = "Add and Configure App Group";
            addAppGroupBt.UseVisualStyleBackColor = true;
            addAppGroupBt.Click += addAppGroupBt_Click;
            // 
            // lnkFileLb
            // 
            lnkFileLb.FormattingEnabled = true;
            lnkFileLb.ItemHeight = 15;
            lnkFileLb.Location = new System.Drawing.Point(323, 262);
            lnkFileLb.Name = "lnkFileLb";
            lnkFileLb.Size = new System.Drawing.Size(473, 124);
            lnkFileLb.Sorted = true;
            lnkFileLb.TabIndex = 13;
            // 
            // lnkFileLabel
            // 
            lnkFileLabel.AutoSize = true;
            lnkFileLabel.Location = new System.Drawing.Point(323, 246);
            lnkFileLabel.Name = "lnkFileLabel";
            lnkFileLabel.Size = new System.Drawing.Size(174, 15);
            lnkFileLabel.TabIndex = 14;
            lnkFileLabel.Text = "Add icons (.lnk) for Win32 Apps";
            // 
            // addLnkBt
            // 
            addLnkBt.Location = new System.Drawing.Point(636, 238);
            addLnkBt.Name = "addLnkBt";
            addLnkBt.Size = new System.Drawing.Size(79, 23);
            addLnkBt.TabIndex = 15;
            addLnkBt.Text = "Browse .lnk";
            addLnkBt.UseVisualStyleBackColor = true;
            addLnkBt.Click += addLnkBt_Click;
            // 
            // remLnkBt
            // 
            remLnkBt.Location = new System.Drawing.Point(721, 238);
            remLnkBt.Name = "remLnkBt";
            remLnkBt.Size = new System.Drawing.Size(75, 23);
            remLnkBt.TabIndex = 16;
            remLnkBt.Text = "Remove";
            remLnkBt.UseVisualStyleBackColor = true;
            remLnkBt.Click += remLnkBt_Click;
            // 
            // groupsLabel
            // 
            groupsLabel.AutoSize = true;
            groupsLabel.Location = new System.Drawing.Point(11, 389);
            groupsLabel.Name = "groupsLabel";
            groupsLabel.Size = new System.Drawing.Size(45, 15);
            groupsLabel.TabIndex = 18;
            groupsLabel.Text = "Groups";
            // 
            // addLnkDialog
            // 
            addLnkDialog.DefaultExt = "lnk";
            addLnkDialog.FileName = "openFileDialog2";
            addLnkDialog.Filter = "lnk files (*.lnk)|*.lnk|All files (*.*)|*.*\"";
            addLnkDialog.InitialDirectory = "C:\\ProgramData\\Microsoft\\Windows\\Start Menu\\Programs";
            // 
            // groupsLv
            // 
            groupsLv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { name, apps });
            groupsLv.GridLines = true;
            groupsLv.Location = new System.Drawing.Point(12, 407);
            groupsLv.Name = "groupsLv";
            groupsLv.Size = new System.Drawing.Size(561, 118);
            groupsLv.TabIndex = 19;
            groupsLv.UseCompatibleStateImageBehavior = false;
            groupsLv.View = System.Windows.Forms.View.Details;
            // 
            // name
            // 
            name.Text = "Name";
            name.Width = 100;
            // 
            // apps
            // 
            apps.Text = "Applications";
            apps.Width = 457;
            // 
            // remGrpBt
            // 
            remGrpBt.Location = new System.Drawing.Point(588, 465);
            remGrpBt.Name = "remGrpBt";
            remGrpBt.Size = new System.Drawing.Size(208, 23);
            remGrpBt.TabIndex = 20;
            remGrpBt.Text = "Remove Group";
            remGrpBt.UseVisualStyleBackColor = true;
            remGrpBt.Click += remGrpBt_Click;
            // 
            // guidLabel
            // 
            guidLabel.AutoSize = true;
            guidLabel.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            guidLabel.Location = new System.Drawing.Point(9, 22);
            guidLabel.Name = "guidLabel";
            guidLabel.Size = new System.Drawing.Size(54, 25);
            guidLabel.TabIndex = 21;
            guidLabel.Text = "GUID";
            // 
            // profileLabel
            // 
            profileLabel.AutoSize = true;
            profileLabel.Location = new System.Drawing.Point(12, 12);
            profileLabel.Name = "profileLabel";
            profileLabel.Size = new System.Drawing.Size(41, 15);
            profileLabel.TabIndex = 22;
            profileLabel.Text = "Profile";
            // 
            // saveProfBt
            // 
            saveProfBt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            saveProfBt.Location = new System.Drawing.Point(676, 494);
            saveProfBt.Name = "saveProfBt";
            saveProfBt.Size = new System.Drawing.Size(120, 31);
            saveProfBt.TabIndex = 23;
            saveProfBt.Text = "Save Profile";
            saveProfBt.UseVisualStyleBackColor = true;
            saveProfBt.Click += saveProfBt_Click;
            // 
            // cancelBt
            // 
            cancelBt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            cancelBt.Location = new System.Drawing.Point(588, 494);
            cancelBt.Name = "cancelBt";
            cancelBt.Size = new System.Drawing.Size(75, 31);
            cancelBt.TabIndex = 24;
            cancelBt.Text = "Cancel";
            cancelBt.UseVisualStyleBackColor = true;
            cancelBt.Click += cancelBt_Click;
            // 
            // showTaskbarCb
            // 
            showTaskbarCb.AutoSize = true;
            showTaskbarCb.Location = new System.Drawing.Point(397, 8);
            showTaskbarCb.Name = "showTaskbarCb";
            showTaskbarCb.Size = new System.Drawing.Size(97, 19);
            showTaskbarCb.TabIndex = 25;
            showTaskbarCb.Text = "Show Taskbar";
            showTaskbarCb.UseVisualStyleBackColor = true;
            // 
            // dlPermCb
            // 
            dlPermCb.AutoSize = true;
            dlPermCb.Location = new System.Drawing.Point(397, 24);
            dlPermCb.Name = "dlPermCb";
            dlPermCb.Size = new System.Drawing.Size(160, 19);
            dlPermCb.TabIndex = 26;
            dlPermCb.Text = "Downloads Folder Access";
            dlPermCb.UseVisualStyleBackColor = true;
            // 
            // rdPermCb
            // 
            rdPermCb.AutoSize = true;
            rdPermCb.Location = new System.Drawing.Point(397, 40);
            rdPermCb.Name = "rdPermCb";
            rdPermCb.Size = new System.Drawing.Size(162, 19);
            rdPermCb.TabIndex = 27;
            rdPermCb.Text = "Removable Device Access";
            rdPermCb.UseVisualStyleBackColor = true;
            // 
            // confAutoLaunchBt
            // 
            confAutoLaunchBt.Location = new System.Drawing.Point(588, 436);
            confAutoLaunchBt.Name = "confAutoLaunchBt";
            confAutoLaunchBt.Size = new System.Drawing.Size(208, 23);
            confAutoLaunchBt.TabIndex = 28;
            confAutoLaunchBt.Text = "Configure auto-launch App";
            confAutoLaunchBt.UseVisualStyleBackColor = true;
            confAutoLaunchBt.Click += confAutoLaunchBt_Click;
            // 
            // noRestrictCb
            // 
            noRestrictCb.AutoSize = true;
            noRestrictCb.Location = new System.Drawing.Point(397, 56);
            noRestrictCb.Name = "noRestrictCb";
            noRestrictCb.Size = new System.Drawing.Size(106, 19);
            noRestrictCb.TabIndex = 29;
            noRestrictCb.Text = "No Restrictions";
            noRestrictCb.UseVisualStyleBackColor = true;
            noRestrictCb.CheckedChanged += noRestrictCb_CheckedChanged;
            // 
            // win11_cb
            // 
            win11_cb.AutoSize = true;
            win11_cb.Checked = true;
            win11_cb.CheckState = System.Windows.Forms.CheckState.Checked;
            win11_cb.Location = new System.Drawing.Point(105, 49);
            win11_cb.Name = "win11_cb";
            win11_cb.Size = new System.Drawing.Size(87, 19);
            win11_cb.TabIndex = 31;
            win11_cb.Text = "Windows11";
            win11_cb.UseVisualStyleBackColor = true;
            win11_cb.CheckedChanged += win11_CheckedChanged;
            // 
            // win10_cb
            // 
            win10_cb.AutoSize = true;
            win10_cb.Location = new System.Drawing.Point(12, 49);
            win10_cb.Name = "win10_cb";
            win10_cb.Size = new System.Drawing.Size(87, 19);
            win10_cb.TabIndex = 30;
            win10_cb.Text = "Windows10";
            win10_cb.UseVisualStyleBackColor = true;
            win10_cb.CheckedChanged += win10_CheckedChanged;
            // 
            // manUwpBt
            // 
            manUwpBt.Location = new System.Drawing.Point(175, 69);
            manUwpBt.Name = "manUwpBt";
            manUwpBt.Size = new System.Drawing.Size(132, 23);
            manUwpBt.TabIndex = 32;
            manUwpBt.Text = "Manually Add AUMID";
            manUwpBt.UseVisualStyleBackColor = true;
            manUwpBt.Click += manUwpBt_Click;
            // 
            // manExeBt
            // 
            manExeBt.Location = new System.Drawing.Point(498, 77);
            manExeBt.Name = "manExeBt";
            manExeBt.Size = new System.Drawing.Size(132, 23);
            manExeBt.TabIndex = 33;
            manExeBt.Text = "Manually Add .exe";
            manExeBt.UseVisualStyleBackColor = true;
            manExeBt.Click += manExeBt_Click;
            // 
            // appProfile
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(808, 534);
            Controls.Add(manExeBt);
            Controls.Add(manUwpBt);
            Controls.Add(win11_cb);
            Controls.Add(win10_cb);
            Controls.Add(noRestrictCb);
            Controls.Add(confAutoLaunchBt);
            Controls.Add(rdPermCb);
            Controls.Add(dlPermCb);
            Controls.Add(showTaskbarCb);
            Controls.Add(cancelBt);
            Controls.Add(saveProfBt);
            Controls.Add(profileLabel);
            Controls.Add(guidLabel);
            Controls.Add(remGrpBt);
            Controls.Add(groupsLv);
            Controls.Add(groupsLabel);
            Controls.Add(remLnkBt);
            Controls.Add(addLnkBt);
            Controls.Add(lnkFileLabel);
            Controls.Add(lnkFileLb);
            Controls.Add(addAppGroupBt);
            Controls.Add(showAllCb);
            Controls.Add(remWin32AppBt);
            Controls.Add(win32AppLb);
            Controls.Add(addWin32AppBt);
            Controls.Add(addWin32AppLabel);
            Controls.Add(logoBox);
            Controls.Add(addUwpAppLabel);
            Controls.Add(uwpAppClb);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "appProfile";
            Text = "Add Profile";
            FormClosing += appProfile_FormClosing;
            FormClosed += appProfile_FormClosed;
            ((System.ComponentModel.ISupportInitialize)logoBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        public System.Windows.Forms.Label guidLabel;
        public System.Windows.Forms.CheckBox win11_cb;

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
        private System.Windows.Forms.CheckBox win10_cb;
        private System.Windows.Forms.Button manUwpBt;
        private System.Windows.Forms.Button manExeBt;
        public static System.Windows.Forms.ListBox win32AppLb;
        public static System.Windows.Forms.ListBox lnkFileLb;
        public static System.Windows.Forms.CheckedListBox uwpAppClb;
    }
}

