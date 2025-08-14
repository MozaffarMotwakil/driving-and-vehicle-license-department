namespace DVLD.WinForms.Applications.LocalLicense
{
    partial class frmManageLocalLicenseApplications
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
            this.components = new System.ComponentModel.Container();
            this.recordsListContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.scheduleTestsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.schedualVisionTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.schedualWrittenTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.schedualStreetTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.issueDrivingLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.showLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.showPersonLicensesHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addNewUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cbApplicationStatus = new System.Windows.Forms.ComboBox();
            this.cbDrivingClass = new System.Windows.Forms.ComboBox();
            this.nudPassedTests = new System.Windows.Forms.NumericUpDown();
            this.dtpApplicationDate = new System.Windows.Forms.DateTimePicker();
            this.recordsListContextMenuStrip.SuspendLayout();
            this.formContextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPassedTests)).BeginInit();
            this.SuspendLayout();
            // 
            // recordsListContextMenuStrip
            // 
            this.recordsListContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showDetailsToolStripMenuItem,
            this.toolStripSeparator1,
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.cancleToolStripMenuItem,
            this.toolStripSeparator2,
            this.scheduleTestsToolStripMenuItem,
            this.toolStripSeparator3,
            this.issueDrivingLicenseToolStripMenuItem,
            this.toolStripSeparator4,
            this.showLicenseToolStripMenuItem,
            this.toolStripSeparator5,
            this.showPersonLicensesHistoryToolStripMenuItem});
            this.recordsListContextMenuStrip.Name = "contextMenuStrip1";
            this.recordsListContextMenuStrip.Size = new System.Drawing.Size(262, 360);
            this.recordsListContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.recordsListContextMenuStrip_Opening);
            // 
            // showDetailsToolStripMenuItem
            // 
            this.showDetailsToolStripMenuItem.Image = global::DVLD.WinForms.Properties.Resources.PersonDetails_32;
            this.showDetailsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showDetailsToolStripMenuItem.Name = "showDetailsToolStripMenuItem";
            this.showDetailsToolStripMenuItem.Size = new System.Drawing.Size(261, 38);
            this.showDetailsToolStripMenuItem.Text = "Show Details";
            this.showDetailsToolStripMenuItem.Click += new System.EventHandler(this.showDetailsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(258, 6);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = global::DVLD.WinForms.Properties.Resources.edit_32;
            this.editToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(261, 38);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::DVLD.WinForms.Properties.Resources.Delete_32_2;
            this.deleteToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(261, 38);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // cancleToolStripMenuItem
            // 
            this.cancleToolStripMenuItem.Image = global::DVLD.WinForms.Properties.Resources.Delete_32;
            this.cancleToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cancleToolStripMenuItem.Name = "cancleToolStripMenuItem";
            this.cancleToolStripMenuItem.Size = new System.Drawing.Size(261, 38);
            this.cancleToolStripMenuItem.Text = "Cancel";
            this.cancleToolStripMenuItem.Click += new System.EventHandler(this.cancleToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(258, 6);
            // 
            // scheduleTestsToolStripMenuItem
            // 
            this.scheduleTestsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.schedualVisionTestToolStripMenuItem,
            this.schedualWrittenTestToolStripMenuItem,
            this.schedualStreetTestToolStripMenuItem});
            this.scheduleTestsToolStripMenuItem.Image = global::DVLD.WinForms.Properties.Resources.Schedule_Test_32;
            this.scheduleTestsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.scheduleTestsToolStripMenuItem.Name = "scheduleTestsToolStripMenuItem";
            this.scheduleTestsToolStripMenuItem.Size = new System.Drawing.Size(261, 38);
            this.scheduleTestsToolStripMenuItem.Text = "Schedule Tests";
            // 
            // schedualVisionTestToolStripMenuItem
            // 
            this.schedualVisionTestToolStripMenuItem.Image = global::DVLD.WinForms.Properties.Resources.Vision_Test_32;
            this.schedualVisionTestToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.schedualVisionTestToolStripMenuItem.Name = "schedualVisionTestToolStripMenuItem";
            this.schedualVisionTestToolStripMenuItem.Size = new System.Drawing.Size(203, 38);
            this.schedualVisionTestToolStripMenuItem.Text = "Schedual Vision Test";
            this.schedualVisionTestToolStripMenuItem.Click += new System.EventHandler(this.schedualVisionTestToolStripMenuItem_Click);
            // 
            // schedualWrittenTestToolStripMenuItem
            // 
            this.schedualWrittenTestToolStripMenuItem.Image = global::DVLD.WinForms.Properties.Resources.Written_Test_32;
            this.schedualWrittenTestToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.schedualWrittenTestToolStripMenuItem.Name = "schedualWrittenTestToolStripMenuItem";
            this.schedualWrittenTestToolStripMenuItem.Size = new System.Drawing.Size(203, 38);
            this.schedualWrittenTestToolStripMenuItem.Text = "Schedual Written Test";
            // 
            // schedualStreetTestToolStripMenuItem
            // 
            this.schedualStreetTestToolStripMenuItem.Image = global::DVLD.WinForms.Properties.Resources.Street_Test_32;
            this.schedualStreetTestToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.schedualStreetTestToolStripMenuItem.Name = "schedualStreetTestToolStripMenuItem";
            this.schedualStreetTestToolStripMenuItem.Size = new System.Drawing.Size(203, 38);
            this.schedualStreetTestToolStripMenuItem.Text = "Schedual Street Test";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(258, 6);
            // 
            // issueDrivingLicenseToolStripMenuItem
            // 
            this.issueDrivingLicenseToolStripMenuItem.Image = global::DVLD.WinForms.Properties.Resources.IssueDrivingLicense_32;
            this.issueDrivingLicenseToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.issueDrivingLicenseToolStripMenuItem.Name = "issueDrivingLicenseToolStripMenuItem";
            this.issueDrivingLicenseToolStripMenuItem.Size = new System.Drawing.Size(261, 38);
            this.issueDrivingLicenseToolStripMenuItem.Text = "Issue Driving License (First Time)";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(258, 6);
            // 
            // showLicenseToolStripMenuItem
            // 
            this.showLicenseToolStripMenuItem.Image = global::DVLD.WinForms.Properties.Resources.License_View_32;
            this.showLicenseToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showLicenseToolStripMenuItem.Name = "showLicenseToolStripMenuItem";
            this.showLicenseToolStripMenuItem.Size = new System.Drawing.Size(261, 38);
            this.showLicenseToolStripMenuItem.Text = "Show License";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(258, 6);
            // 
            // showPersonLicensesHistoryToolStripMenuItem
            // 
            this.showPersonLicensesHistoryToolStripMenuItem.Image = global::DVLD.WinForms.Properties.Resources.PersonLicenseHistory_32;
            this.showPersonLicensesHistoryToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showPersonLicensesHistoryToolStripMenuItem.Name = "showPersonLicensesHistoryToolStripMenuItem";
            this.showPersonLicensesHistoryToolStripMenuItem.Size = new System.Drawing.Size(261, 38);
            this.showPersonLicensesHistoryToolStripMenuItem.Text = "Show Person Licenses History";
            // 
            // formContextMenuStrip
            // 
            this.formContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewUserToolStripMenuItem});
            this.formContextMenuStrip.Name = "formContextMenuStrip";
            this.formContextMenuStrip.Size = new System.Drawing.Size(204, 42);
            // 
            // addNewUserToolStripMenuItem
            // 
            this.addNewUserToolStripMenuItem.Image = global::DVLD.WinForms.Properties.Resources.New_Application_32;
            this.addNewUserToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.addNewUserToolStripMenuItem.Name = "addNewUserToolStripMenuItem";
            this.addNewUserToolStripMenuItem.Size = new System.Drawing.Size(203, 38);
            this.addNewUserToolStripMenuItem.Text = "Add New Application";
            this.addNewUserToolStripMenuItem.Click += new System.EventHandler(this.addNewUserToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox1.Image = global::DVLD.WinForms.Properties.Resources.Local_32;
            this.pictureBox1.Location = new System.Drawing.Point(637, 36);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(58, 47);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 31;
            this.pictureBox1.TabStop = false;
            // 
            // cbApplicationStatus
            // 
            this.cbApplicationStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cbApplicationStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbApplicationStatus.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbApplicationStatus.FormattingEnabled = true;
            this.cbApplicationStatus.Items.AddRange(new object[] {
            "All",
            "New",
            "Completed",
            "Cancelled"});
            this.cbApplicationStatus.Location = new System.Drawing.Point(228, 62);
            this.cbApplicationStatus.Name = "cbApplicationStatus";
            this.cbApplicationStatus.Size = new System.Drawing.Size(128, 24);
            this.cbApplicationStatus.TabIndex = 34;
            this.cbApplicationStatus.Visible = false;
            this.cbApplicationStatus.SelectedIndexChanged += new System.EventHandler(this.cbApplicationStatus_SelectedIndexChanged);
            // 
            // cbDrivingClass
            // 
            this.cbDrivingClass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cbDrivingClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDrivingClass.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDrivingClass.FormattingEnabled = true;
            this.cbDrivingClass.Location = new System.Drawing.Point(228, 150);
            this.cbDrivingClass.Name = "cbDrivingClass";
            this.cbDrivingClass.Size = new System.Drawing.Size(221, 24);
            this.cbDrivingClass.TabIndex = 33;
            this.cbDrivingClass.Visible = false;
            this.cbDrivingClass.SelectedIndexChanged += new System.EventHandler(this.cbDrivingClass_SelectedIndexChanged);
            // 
            // nudPassedTests
            // 
            this.nudPassedTests.Cursor = System.Windows.Forms.Cursors.Default;
            this.nudPassedTests.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudPassedTests.InterceptArrowKeys = false;
            this.nudPassedTests.Location = new System.Drawing.Point(228, 92);
            this.nudPassedTests.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nudPassedTests.Name = "nudPassedTests";
            this.nudPassedTests.ReadOnly = true;
            this.nudPassedTests.Size = new System.Drawing.Size(128, 23);
            this.nudPassedTests.TabIndex = 36;
            this.nudPassedTests.Visible = false;
            this.nudPassedTests.ValueChanged += new System.EventHandler(this.nudPassedTests_ValueChanged);
            // 
            // dtpApplicationDate
            // 
            this.dtpApplicationDate.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpApplicationDate.Location = new System.Drawing.Point(228, 121);
            this.dtpApplicationDate.Name = "dtpApplicationDate";
            this.dtpApplicationDate.Size = new System.Drawing.Size(221, 23);
            this.dtpApplicationDate.TabIndex = 37;
            this.dtpApplicationDate.Visible = false;
            this.dtpApplicationDate.ValueChanged += new System.EventHandler(this.dtpApplicationDate_ValueChanged);
            this.dtpApplicationDate.VisibleChanged += new System.EventHandler(this.dtpApplicationDate_VisibleChanged);
            // 
            // frmManageLocalLicenseApplications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 561);
            this.ContextMenuStrip = this.formContextMenuStrip;
            this.Controls.Add(this.dtpApplicationDate);
            this.Controls.Add(this.cbDrivingClass);
            this.Controls.Add(this.nudPassedTests);
            this.Controls.Add(this.cbApplicationStatus);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmManageLocalLicenseApplications";
            this.Text = "Manage Local License Applications";
            this.Load += new System.EventHandler(this.frmManageLocalLicenseApplications_Load);
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.Controls.SetChildIndex(this.cbApplicationStatus, 0);
            this.Controls.SetChildIndex(this.nudPassedTests, 0);
            this.Controls.SetChildIndex(this.cbDrivingClass, 0);
            this.Controls.SetChildIndex(this.dtpApplicationDate, 0);
            this.recordsListContextMenuStrip.ResumeLayout(false);
            this.formContextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPassedTests)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip recordsListContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem showDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancleToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem scheduleTestsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem issueDrivingLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem showLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem showPersonLicensesHistoryToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip formContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem addNewUserToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cbApplicationStatus;
        private System.Windows.Forms.ComboBox cbDrivingClass;
        private System.Windows.Forms.NumericUpDown nudPassedTests;
        private System.Windows.Forms.DateTimePicker dtpApplicationDate;
        private System.Windows.Forms.ToolStripMenuItem schedualVisionTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem schedualWrittenTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem schedualStreetTestToolStripMenuItem;
    }
}