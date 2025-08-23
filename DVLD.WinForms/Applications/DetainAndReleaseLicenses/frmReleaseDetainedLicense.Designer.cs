namespace DVLD.WinForms.Applications.DetainAndReleaseLicenses
{
    partial class frmReleaseDetainedLicense
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
            this.label8 = new System.Windows.Forms.Label();
            this.lblDetainDate = new System.Windows.Forms.Label();
            this.pbFormLogo = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.lblDetainID = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.llLicenseID = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.llCreatedByUsername = new System.Windows.Forms.LinkLabel();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.llShowLicensesHistory = new System.Windows.Forms.LinkLabel();
            this.btnRelease = new System.Windows.Forms.Button();
            this.gbReleaseApplicationInfo = new System.Windows.Forms.GroupBox();
            this.lblApplicationFees = new System.Windows.Forms.Label();
            this.lblTotalFees = new System.Windows.Forms.Label();
            this.lblFineFees = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblReleaseApplicationID = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.ctrDriverLicenseInfoWithFilter = new DVLD.WinForms.Licenses.ctrDriverLicenseInfoWithFilter();
            ((System.ComponentModel.ISupportInitialize)(this.pbFormLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            this.gbReleaseApplicationInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(44, 91);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(70, 16);
            this.label12.TabIndex = 56;
            this.label12.Text = "Fine Fees:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(534, 91);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 14);
            this.label8.TabIndex = 51;
            this.label8.Text = "License ID:";
            // 
            // lblDetainDate
            // 
            this.lblDetainDate.AutoSize = true;
            this.lblDetainDate.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetainDate.Location = new System.Drawing.Point(624, 56);
            this.lblDetainDate.Name = "lblDetainDate";
            this.lblDetainDate.Size = new System.Drawing.Size(83, 14);
            this.lblDetainDate.TabIndex = 50;
            this.lblDetainDate.Text = "DD/MM/YYYY";
            // 
            // pbFormLogo
            // 
            this.pbFormLogo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pbFormLogo.Image = global::DVLD.WinForms.Properties.Resources.Release_Detained_License_512;
            this.pbFormLogo.Location = new System.Drawing.Point(295, 1);
            this.pbFormLogo.Name = "pbFormLogo";
            this.pbFormLogo.Size = new System.Drawing.Size(255, 81);
            this.pbFormLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbFormLogo.TabIndex = 79;
            this.pbFormLogo.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImage = global::DVLD.WinForms.Properties.Resources.Close_32;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(611, 686);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(102, 34);
            this.btnClose.TabIndex = 76;
            this.btnClose.Text = "     Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(534, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 14);
            this.label6.TabIndex = 46;
            this.label6.Text = "Detain Date:";
            // 
            // lblDetainID
            // 
            this.lblDetainID.AutoSize = true;
            this.lblDetainID.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetainID.Location = new System.Drawing.Point(624, 23);
            this.lblDetainID.Name = "lblDetainID";
            this.lblDetainID.Size = new System.Drawing.Size(28, 16);
            this.lblDetainID.TabIndex = 37;
            this.lblDetainID.Text = "N/A";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(534, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 16);
            this.label4.TabIndex = 35;
            this.label4.Text = "Detain ID:";
            // 
            // llLicenseID
            // 
            this.llLicenseID.AutoSize = true;
            this.llLicenseID.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llLicenseID.Location = new System.Drawing.Point(624, 89);
            this.llLicenseID.Name = "llLicenseID";
            this.llLicenseID.Size = new System.Drawing.Size(25, 16);
            this.llLicenseID.TabIndex = 31;
            this.llLicenseID.TabStop = true;
            this.llLicenseID.Text = "???";
            this.llLicenseID.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llLicenseID_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(242, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(377, 39);
            this.label1.TabIndex = 73;
            this.label1.Text = "Release Detained License";
            // 
            // pictureBox9
            // 
            this.pictureBox9.Image = global::DVLD.WinForms.Properties.Resources.money_32;
            this.pictureBox9.Location = new System.Drawing.Point(6, 81);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(32, 32);
            this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox9.TabIndex = 57;
            this.pictureBox9.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::DVLD.WinForms.Properties.Resources.LocalDriving_License;
            this.pictureBox5.Location = new System.Drawing.Point(496, 83);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(32, 32);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox5.TabIndex = 52;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::DVLD.WinForms.Properties.Resources.Calendar_32;
            this.pictureBox6.Location = new System.Drawing.Point(496, 48);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(32, 32);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox6.TabIndex = 48;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD.WinForms.Properties.Resources.Number_32;
            this.pictureBox1.Location = new System.Drawing.Point(496, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 36;
            this.pictureBox1.TabStop = false;
            // 
            // llCreatedByUsername
            // 
            this.llCreatedByUsername.AutoSize = true;
            this.llCreatedByUsername.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llCreatedByUsername.Location = new System.Drawing.Point(624, 124);
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
            this.pictureBox8.Location = new System.Drawing.Point(496, 116);
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
            this.label7.Location = new System.Drawing.Point(534, 124);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 16);
            this.label7.TabIndex = 29;
            this.label7.Text = "Created By:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(7, 667);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(835, 13);
            this.label14.TabIndex = 77;
            this.label14.Text = "_________________________________________________________________________________" +
    "_________________________________________________________";
            // 
            // llShowLicensesHistory
            // 
            this.llShowLicensesHistory.AutoSize = true;
            this.llShowLicensesHistory.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llShowLicensesHistory.Location = new System.Drawing.Point(15, 694);
            this.llShowLicensesHistory.Name = "llShowLicensesHistory";
            this.llShowLicensesHistory.Size = new System.Drawing.Size(166, 19);
            this.llShowLicensesHistory.TabIndex = 78;
            this.llShowLicensesHistory.TabStop = true;
            this.llShowLicensesHistory.Text = "Show Licenses History";
            this.llShowLicensesHistory.Visible = false;
            this.llShowLicensesHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llShowLicensesHistory_LinkClicked);
            // 
            // btnRelease
            // 
            this.btnRelease.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnRelease.Enabled = false;
            this.btnRelease.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRelease.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRelease.Image = global::DVLD.WinForms.Properties.Resources.Release_Detained_License_32;
            this.btnRelease.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRelease.Location = new System.Drawing.Point(719, 686);
            this.btnRelease.Name = "btnRelease";
            this.btnRelease.Size = new System.Drawing.Size(111, 34);
            this.btnRelease.TabIndex = 75;
            this.btnRelease.Text = "       Release";
            this.btnRelease.UseVisualStyleBackColor = true;
            this.btnRelease.Click += new System.EventHandler(this.btnDetain_Click);
            // 
            // gbReleaseApplicationInfo
            // 
            this.gbReleaseApplicationInfo.Controls.Add(this.lblApplicationFees);
            this.gbReleaseApplicationInfo.Controls.Add(this.lblTotalFees);
            this.gbReleaseApplicationInfo.Controls.Add(this.lblFineFees);
            this.gbReleaseApplicationInfo.Controls.Add(this.pictureBox2);
            this.gbReleaseApplicationInfo.Controls.Add(this.label2);
            this.gbReleaseApplicationInfo.Controls.Add(this.pictureBox3);
            this.gbReleaseApplicationInfo.Controls.Add(this.label5);
            this.gbReleaseApplicationInfo.Controls.Add(this.pictureBox9);
            this.gbReleaseApplicationInfo.Controls.Add(this.label12);
            this.gbReleaseApplicationInfo.Controls.Add(this.pictureBox5);
            this.gbReleaseApplicationInfo.Controls.Add(this.label8);
            this.gbReleaseApplicationInfo.Controls.Add(this.lblDetainDate);
            this.gbReleaseApplicationInfo.Controls.Add(this.pictureBox6);
            this.gbReleaseApplicationInfo.Controls.Add(this.label6);
            this.gbReleaseApplicationInfo.Controls.Add(this.lblReleaseApplicationID);
            this.gbReleaseApplicationInfo.Controls.Add(this.lblDetainID);
            this.gbReleaseApplicationInfo.Controls.Add(this.pictureBox4);
            this.gbReleaseApplicationInfo.Controls.Add(this.label9);
            this.gbReleaseApplicationInfo.Controls.Add(this.pictureBox1);
            this.gbReleaseApplicationInfo.Controls.Add(this.label4);
            this.gbReleaseApplicationInfo.Controls.Add(this.llLicenseID);
            this.gbReleaseApplicationInfo.Controls.Add(this.llCreatedByUsername);
            this.gbReleaseApplicationInfo.Controls.Add(this.pictureBox8);
            this.gbReleaseApplicationInfo.Controls.Add(this.label7);
            this.gbReleaseApplicationInfo.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbReleaseApplicationInfo.Location = new System.Drawing.Point(13, 515);
            this.gbReleaseApplicationInfo.Name = "gbReleaseApplicationInfo";
            this.gbReleaseApplicationInfo.Size = new System.Drawing.Size(817, 150);
            this.gbReleaseApplicationInfo.TabIndex = 74;
            this.gbReleaseApplicationInfo.TabStop = false;
            this.gbReleaseApplicationInfo.Text = "Release Detained License Application Info";
            this.gbReleaseApplicationInfo.Visible = false;
            // 
            // lblApplicationFees
            // 
            this.lblApplicationFees.AutoSize = true;
            this.lblApplicationFees.Location = new System.Drawing.Point(167, 58);
            this.lblApplicationFees.Name = "lblApplicationFees";
            this.lblApplicationFees.Size = new System.Drawing.Size(25, 16);
            this.lblApplicationFees.TabIndex = 58;
            this.lblApplicationFees.Text = "???";
            // 
            // lblTotalFees
            // 
            this.lblTotalFees.AutoSize = true;
            this.lblTotalFees.ForeColor = System.Drawing.Color.Red;
            this.lblTotalFees.Location = new System.Drawing.Point(127, 124);
            this.lblTotalFees.Name = "lblTotalFees";
            this.lblTotalFees.Size = new System.Drawing.Size(25, 16);
            this.lblTotalFees.TabIndex = 58;
            this.lblTotalFees.Text = "???";
            // 
            // lblFineFees
            // 
            this.lblFineFees.AutoSize = true;
            this.lblFineFees.Location = new System.Drawing.Point(127, 91);
            this.lblFineFees.Name = "lblFineFees";
            this.lblFineFees.Size = new System.Drawing.Size(25, 16);
            this.lblFineFees.TabIndex = 58;
            this.lblFineFees.Text = "???";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DVLD.WinForms.Properties.Resources.money_32;
            this.pictureBox2.Location = new System.Drawing.Point(6, 48);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 32);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 57;
            this.pictureBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(44, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 16);
            this.label2.TabIndex = 56;
            this.label2.Text = "Application Fees:";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::DVLD.WinForms.Properties.Resources.money_32;
            this.pictureBox3.Location = new System.Drawing.Point(6, 114);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(32, 32);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 57;
            this.pictureBox3.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(44, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 16);
            this.label5.TabIndex = 56;
            this.label5.Text = "Total Fees:";
            // 
            // lblReleaseApplicationID
            // 
            this.lblReleaseApplicationID.AutoSize = true;
            this.lblReleaseApplicationID.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReleaseApplicationID.Location = new System.Drawing.Point(321, 23);
            this.lblReleaseApplicationID.Name = "lblReleaseApplicationID";
            this.lblReleaseApplicationID.Size = new System.Drawing.Size(28, 16);
            this.lblReleaseApplicationID.TabIndex = 37;
            this.lblReleaseApplicationID.Text = "N/A";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::DVLD.WinForms.Properties.Resources.Number_32;
            this.pictureBox4.Location = new System.Drawing.Point(6, 15);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(32, 32);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox4.TabIndex = 36;
            this.pictureBox4.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(44, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(271, 16);
            this.label9.TabIndex = 35;
            this.label9.Text = "Release Detained License Application ID:";
            // 
            // ctrDriverLicenseInfoWithFilter
            // 
            this.ctrDriverLicenseInfoWithFilter.EnableSearch = true;
            this.ctrDriverLicenseInfoWithFilter.Location = new System.Drawing.Point(11, 122);
            this.ctrDriverLicenseInfoWithFilter.Name = "ctrDriverLicenseInfoWithFilter";
            this.ctrDriverLicenseInfoWithFilter.Size = new System.Drawing.Size(823, 396);
            this.ctrDriverLicenseInfoWithFilter.TabIndex = 72;
            // 
            // frmReleaseDetainedLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 725);
            this.Controls.Add(this.pbFormLogo);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.llShowLicensesHistory);
            this.Controls.Add(this.ctrDriverLicenseInfoWithFilter);
            this.Controls.Add(this.btnRelease);
            this.Controls.Add(this.gbReleaseApplicationInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReleaseDetainedLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Release Detained License";
            this.Activated += new System.EventHandler(this.frmReleaseDetainedLicense_Activated);
            this.Load += new System.EventHandler(this.frmReleaseDetainedLicense_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbFormLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            this.gbReleaseApplicationInfo.ResumeLayout(false);
            this.gbReleaseApplicationInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblDetainDate;
        private System.Windows.Forms.PictureBox pbFormLogo;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblDetainID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel llLicenseID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel llCreatedByUsername;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.LinkLabel llShowLicensesHistory;
        private Licenses.ctrDriverLicenseInfoWithFilter ctrDriverLicenseInfoWithFilter;
        private System.Windows.Forms.Button btnRelease;
        private System.Windows.Forms.GroupBox gbReleaseApplicationInfo;
        private System.Windows.Forms.Label lblFineFees;
        private System.Windows.Forms.Label lblApplicationFees;
        private System.Windows.Forms.Label lblTotalFees;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblReleaseApplicationID;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label9;
    }
}