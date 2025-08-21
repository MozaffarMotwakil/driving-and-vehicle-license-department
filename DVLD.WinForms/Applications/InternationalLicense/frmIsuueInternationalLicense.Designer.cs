namespace DVLD.WinForms.Applications.InternationalLicense
{
    partial class frmIsuueInternationalLicense
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
            this.label12 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnIssue = new System.Windows.Forms.Button();
            this.llShowLicensesHistory = new System.Windows.Forms.LinkLabel();
            this.llShowInternationalLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.gbInternationalLicenseApplicationInfo = new System.Windows.Forms.GroupBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lblExpirationDate = new System.Windows.Forms.Label();
            this.lblIssueDate = new System.Windows.Forms.Label();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblInternationalLicenseID = new System.Windows.Forms.Label();
            this.lblInternationalLicenseApplicationID = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblApplicationFees = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.llLocalLicenseID = new System.Windows.Forms.LinkLabel();
            this.llCreatedByUsername = new System.Windows.Forms.LinkLabel();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ctrDriverLicenseInfoWithFilter = new DVLD.WinForms.Licenses.ctrDriverLicenseInfoWithFilter();
            this.gbInternationalLicenseApplicationInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            this.SuspendLayout();
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(5, 573);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(835, 13);
            this.label12.TabIndex = 54;
            this.label12.Text = "_________________________________________________________________________________" +
    "_________________________________________________________";
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImage = global::DVLD.WinForms.Properties.Resources.Close_32;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(624, 595);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(102, 34);
            this.btnClose.TabIndex = 53;
            this.btnClose.Text = "     Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnIssue
            // 
            this.btnIssue.BackgroundImage = global::DVLD.WinForms.Properties.Resources.Save_32;
            this.btnIssue.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnIssue.Enabled = false;
            this.btnIssue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIssue.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIssue.Location = new System.Drawing.Point(732, 595);
            this.btnIssue.Name = "btnIssue";
            this.btnIssue.Size = new System.Drawing.Size(102, 34);
            this.btnIssue.TabIndex = 52;
            this.btnIssue.Text = "     Issue";
            this.btnIssue.UseVisualStyleBackColor = true;
            this.btnIssue.Click += new System.EventHandler(this.btnIssue_Click);
            // 
            // llShowLicensesHistory
            // 
            this.llShowLicensesHistory.AutoSize = true;
            this.llShowLicensesHistory.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llShowLicensesHistory.Location = new System.Drawing.Point(12, 603);
            this.llShowLicensesHistory.Name = "llShowLicensesHistory";
            this.llShowLicensesHistory.Size = new System.Drawing.Size(166, 19);
            this.llShowLicensesHistory.TabIndex = 55;
            this.llShowLicensesHistory.TabStop = true;
            this.llShowLicensesHistory.Text = "Show Licenses History";
            this.llShowLicensesHistory.Visible = false;
            this.llShowLicensesHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llShowLicensesHistory_LinkClicked);
            // 
            // llShowInternationalLicenseInfo
            // 
            this.llShowInternationalLicenseInfo.AutoSize = true;
            this.llShowInternationalLicenseInfo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llShowInternationalLicenseInfo.Location = new System.Drawing.Point(222, 603);
            this.llShowInternationalLicenseInfo.Name = "llShowInternationalLicenseInfo";
            this.llShowInternationalLicenseInfo.Size = new System.Drawing.Size(233, 19);
            this.llShowInternationalLicenseInfo.TabIndex = 55;
            this.llShowInternationalLicenseInfo.TabStop = true;
            this.llShowInternationalLicenseInfo.Text = "Show International License Info";
            this.llShowInternationalLicenseInfo.Visible = false;
            this.llShowInternationalLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llShowInternationalLicenseInfo_LinkClicked);
            // 
            // gbInternationalLicenseApplicationInfo
            // 
            this.gbInternationalLicenseApplicationInfo.Controls.Add(this.pictureBox5);
            this.gbInternationalLicenseApplicationInfo.Controls.Add(this.label8);
            this.gbInternationalLicenseApplicationInfo.Controls.Add(this.lblExpirationDate);
            this.gbInternationalLicenseApplicationInfo.Controls.Add(this.lblIssueDate);
            this.gbInternationalLicenseApplicationInfo.Controls.Add(this.pictureBox7);
            this.gbInternationalLicenseApplicationInfo.Controls.Add(this.pictureBox6);
            this.gbInternationalLicenseApplicationInfo.Controls.Add(this.label1);
            this.gbInternationalLicenseApplicationInfo.Controls.Add(this.label6);
            this.gbInternationalLicenseApplicationInfo.Controls.Add(this.lblInternationalLicenseID);
            this.gbInternationalLicenseApplicationInfo.Controls.Add(this.lblInternationalLicenseApplicationID);
            this.gbInternationalLicenseApplicationInfo.Controls.Add(this.pictureBox3);
            this.gbInternationalLicenseApplicationInfo.Controls.Add(this.label2);
            this.gbInternationalLicenseApplicationInfo.Controls.Add(this.pictureBox1);
            this.gbInternationalLicenseApplicationInfo.Controls.Add(this.label3);
            this.gbInternationalLicenseApplicationInfo.Controls.Add(this.lblApplicationFees);
            this.gbInternationalLicenseApplicationInfo.Controls.Add(this.pictureBox2);
            this.gbInternationalLicenseApplicationInfo.Controls.Add(this.label4);
            this.gbInternationalLicenseApplicationInfo.Controls.Add(this.llLocalLicenseID);
            this.gbInternationalLicenseApplicationInfo.Controls.Add(this.llCreatedByUsername);
            this.gbInternationalLicenseApplicationInfo.Controls.Add(this.pictureBox8);
            this.gbInternationalLicenseApplicationInfo.Controls.Add(this.label7);
            this.gbInternationalLicenseApplicationInfo.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbInternationalLicenseApplicationInfo.Location = new System.Drawing.Point(18, 412);
            this.gbInternationalLicenseApplicationInfo.Name = "gbInternationalLicenseApplicationInfo";
            this.gbInternationalLicenseApplicationInfo.Size = new System.Drawing.Size(817, 162);
            this.gbInternationalLicenseApplicationInfo.TabIndex = 56;
            this.gbInternationalLicenseApplicationInfo.TabStop = false;
            this.gbInternationalLicenseApplicationInfo.Text = "International License Application Info";
            this.gbInternationalLicenseApplicationInfo.Visible = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::DVLD.WinForms.Properties.Resources.LocalDriving_License;
            this.pictureBox5.Location = new System.Drawing.Point(6, 88);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(32, 32);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox5.TabIndex = 52;
            this.pictureBox5.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(44, 96);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 14);
            this.label8.TabIndex = 51;
            this.label8.Text = "Local License ID:";
            // 
            // lblExpirationDate
            // 
            this.lblExpirationDate.AutoSize = true;
            this.lblExpirationDate.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpirationDate.Location = new System.Drawing.Point(597, 96);
            this.lblExpirationDate.Name = "lblExpirationDate";
            this.lblExpirationDate.Size = new System.Drawing.Size(83, 14);
            this.lblExpirationDate.TabIndex = 49;
            this.lblExpirationDate.Text = "DD/MM/YYYY";
            // 
            // lblIssueDate
            // 
            this.lblIssueDate.AutoSize = true;
            this.lblIssueDate.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIssueDate.Location = new System.Drawing.Point(597, 63);
            this.lblIssueDate.Name = "lblIssueDate";
            this.lblIssueDate.Size = new System.Drawing.Size(83, 14);
            this.lblIssueDate.TabIndex = 50;
            this.lblIssueDate.Text = "DD/MM/YYYY";
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = global::DVLD.WinForms.Properties.Resources.Calendar_32;
            this.pictureBox7.Location = new System.Drawing.Point(447, 88);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(32, 32);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox7.TabIndex = 47;
            this.pictureBox7.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::DVLD.WinForms.Properties.Resources.Calendar_32;
            this.pictureBox6.Location = new System.Drawing.Point(447, 55);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(32, 32);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox6.TabIndex = 48;
            this.pictureBox6.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(485, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 14);
            this.label1.TabIndex = 45;
            this.label1.Text = "Expiration Date:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(485, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 14);
            this.label6.TabIndex = 46;
            this.label6.Text = "Issue Date:";
            // 
            // lblInternationalLicenseID
            // 
            this.lblInternationalLicenseID.AutoSize = true;
            this.lblInternationalLicenseID.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInternationalLicenseID.Location = new System.Drawing.Point(658, 30);
            this.lblInternationalLicenseID.Name = "lblInternationalLicenseID";
            this.lblInternationalLicenseID.Size = new System.Drawing.Size(25, 16);
            this.lblInternationalLicenseID.TabIndex = 37;
            this.lblInternationalLicenseID.Text = "???";
            // 
            // lblInternationalLicenseApplicationID
            // 
            this.lblInternationalLicenseApplicationID.AutoSize = true;
            this.lblInternationalLicenseApplicationID.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInternationalLicenseApplicationID.Location = new System.Drawing.Point(293, 30);
            this.lblInternationalLicenseApplicationID.Name = "lblInternationalLicenseApplicationID";
            this.lblInternationalLicenseApplicationID.Size = new System.Drawing.Size(25, 16);
            this.lblInternationalLicenseApplicationID.TabIndex = 37;
            this.lblInternationalLicenseApplicationID.Text = "???";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::DVLD.WinForms.Properties.Resources.International_32;
            this.pictureBox3.Location = new System.Drawing.Point(447, 22);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(32, 32);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 36;
            this.pictureBox3.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(485, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 16);
            this.label2.TabIndex = 35;
            this.label2.Text = "International License ID:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD.WinForms.Properties.Resources.Number_32;
            this.pictureBox1.Location = new System.Drawing.Point(6, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 36;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(44, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(243, 16);
            this.label3.TabIndex = 35;
            this.label3.Text = "International License Application ID:";
            // 
            // lblApplicationFees
            // 
            this.lblApplicationFees.AutoSize = true;
            this.lblApplicationFees.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationFees.Location = new System.Drawing.Point(167, 63);
            this.lblApplicationFees.Name = "lblApplicationFees";
            this.lblApplicationFees.Size = new System.Drawing.Size(25, 16);
            this.lblApplicationFees.TabIndex = 34;
            this.lblApplicationFees.Text = "???";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DVLD.WinForms.Properties.Resources.money_32;
            this.pictureBox2.Location = new System.Drawing.Point(6, 55);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 32);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 33;
            this.pictureBox2.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(44, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 16);
            this.label4.TabIndex = 32;
            this.label4.Text = "Application Fees:";
            // 
            // llLocalLicenseID
            // 
            this.llLocalLicenseID.AutoSize = true;
            this.llLocalLicenseID.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llLocalLicenseID.Location = new System.Drawing.Point(167, 96);
            this.llLocalLicenseID.Name = "llLocalLicenseID";
            this.llLocalLicenseID.Size = new System.Drawing.Size(25, 16);
            this.llLocalLicenseID.TabIndex = 31;
            this.llLocalLicenseID.TabStop = true;
            this.llLocalLicenseID.Text = "???";
            this.llLocalLicenseID.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llLocalLicenseID_LinkClicked);
            // 
            // llCreatedByUsername
            // 
            this.llCreatedByUsername.AutoSize = true;
            this.llCreatedByUsername.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llCreatedByUsername.Location = new System.Drawing.Point(167, 129);
            this.llCreatedByUsername.Name = "llCreatedByUsername";
            this.llCreatedByUsername.Size = new System.Drawing.Size(25, 16);
            this.llCreatedByUsername.TabIndex = 31;
            this.llCreatedByUsername.TabStop = true;
            this.llCreatedByUsername.Text = "???";
            this.llCreatedByUsername.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llCreatedByUsername_LinkClicked);
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = global::DVLD.WinForms.Properties.Resources.User_32__2;
            this.pictureBox8.Location = new System.Drawing.Point(6, 121);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(32, 32);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox8.TabIndex = 30;
            this.pictureBox8.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(44, 129);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 16);
            this.label7.TabIndex = 29;
            this.label7.Text = "Created By:";
            // 
            // ctrDriverLicenseInfoWithFilter
            // 
            this.ctrDriverLicenseInfoWithFilter.Location = new System.Drawing.Point(12, 12);
            this.ctrDriverLicenseInfoWithFilter.Name = "ctrDriverLicenseInfoWithFilter";
            this.ctrDriverLicenseInfoWithFilter.Size = new System.Drawing.Size(823, 400);
            this.ctrDriverLicenseInfoWithFilter.TabIndex = 1;
            // 
            // frmIsuueInternationalLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(844, 637);
            this.Controls.Add(this.gbInternationalLicenseApplicationInfo);
            this.Controls.Add(this.llShowInternationalLicenseInfo);
            this.Controls.Add(this.llShowLicensesHistory);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnIssue);
            this.Controls.Add(this.ctrDriverLicenseInfoWithFilter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmIsuueInternationalLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Isuue New International License";
            this.Activated += new System.EventHandler(this.frmIsuueInternationalLicense_Activated);
            this.gbInternationalLicenseApplicationInfo.ResumeLayout(false);
            this.gbInternationalLicenseApplicationInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Licenses.ctrDriverLicenseInfoWithFilter ctrDriverLicenseInfoWithFilter;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnIssue;
        private System.Windows.Forms.LinkLabel llShowLicensesHistory;
        private System.Windows.Forms.LinkLabel llShowInternationalLicenseInfo;
        private System.Windows.Forms.GroupBox gbInternationalLicenseApplicationInfo;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblExpirationDate;
        private System.Windows.Forms.Label lblIssueDate;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblInternationalLicenseID;
        private System.Windows.Forms.Label lblInternationalLicenseApplicationID;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblApplicationFees;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel llLocalLicenseID;
        private System.Windows.Forms.LinkLabel llCreatedByUsername;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.Label label7;
    }
}