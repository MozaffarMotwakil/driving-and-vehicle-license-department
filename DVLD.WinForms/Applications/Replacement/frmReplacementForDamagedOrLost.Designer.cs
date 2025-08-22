namespace DVLD.WinForms.Applications.Replacement
{
    partial class frmReplacementForDamagedOrLost
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
            this.gbReplacementFor = new System.Windows.Forms.GroupBox();
            this.rbLost = new System.Windows.Forms.RadioButton();
            this.rbDamaged = new System.Windows.Forms.RadioButton();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.gbReplacementLicenseApplicationInfo = new System.Windows.Forms.GroupBox();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.label13 = new System.Windows.Forms.Label();
            this.lblApplicationDate = new System.Windows.Forms.Label();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lblReplacementLicenseID = new System.Windows.Forms.Label();
            this.lblReplacementLicenseApplicationID = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblApplicationFees = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.llOldLocalLicenseID = new System.Windows.Forms.LinkLabel();
            this.llCreatedByUsername = new System.Windows.Forms.LinkLabel();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.llShowReplacementLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.llShowLicensesHistory = new System.Windows.Forms.LinkLabel();
            this.label14 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnReplacement = new System.Windows.Forms.Button();
            this.ctrDriverLicenseInfoWithFilter = new DVLD.WinForms.Licenses.ctrDriverLicenseInfoWithFilter();
            this.gbReplacementFor.SuspendLayout();
            this.gbReplacementLicenseApplicationInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            this.SuspendLayout();
            // 
            // gbReplacementFor
            // 
            this.gbReplacementFor.Controls.Add(this.rbLost);
            this.gbReplacementFor.Controls.Add(this.rbDamaged);
            this.gbReplacementFor.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbReplacementFor.Location = new System.Drawing.Point(509, 76);
            this.gbReplacementFor.Name = "gbReplacementFor";
            this.gbReplacementFor.Size = new System.Drawing.Size(164, 44);
            this.gbReplacementFor.TabIndex = 1;
            this.gbReplacementFor.TabStop = false;
            this.gbReplacementFor.Text = "Replacement For:";
            // 
            // rbLost
            // 
            this.rbLost.AutoSize = true;
            this.rbLost.Location = new System.Drawing.Point(111, 20);
            this.rbLost.Name = "rbLost";
            this.rbLost.Size = new System.Drawing.Size(48, 20);
            this.rbLost.TabIndex = 0;
            this.rbLost.Text = "Lost";
            this.rbLost.UseVisualStyleBackColor = true;
            this.rbLost.CheckedChanged += new System.EventHandler(this.rbLost_CheckedChanged);
            // 
            // rbDamaged
            // 
            this.rbDamaged.AutoSize = true;
            this.rbDamaged.Location = new System.Drawing.Point(7, 20);
            this.rbDamaged.Name = "rbDamaged";
            this.rbDamaged.Size = new System.Drawing.Size(79, 20);
            this.rbDamaged.TabIndex = 0;
            this.rbDamaged.Text = "Damaged";
            this.rbDamaged.UseVisualStyleBackColor = true;
            this.rbDamaged.CheckedChanged += new System.EventHandler(this.rbDamaged_CheckedChanged);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormTitle.ForeColor = System.Drawing.Color.Red;
            this.lblFormTitle.Location = new System.Drawing.Point(110, 9);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(629, 39);
            this.lblFormTitle.TabIndex = 2;
            this.lblFormTitle.Text = "Replacement License For Damaged or Lost";
            this.lblFormTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbReplacementLicenseApplicationInfo
            // 
            this.gbReplacementLicenseApplicationInfo.Controls.Add(this.txtNotes);
            this.gbReplacementLicenseApplicationInfo.Controls.Add(this.pictureBox10);
            this.gbReplacementLicenseApplicationInfo.Controls.Add(this.label13);
            this.gbReplacementLicenseApplicationInfo.Controls.Add(this.lblApplicationDate);
            this.gbReplacementLicenseApplicationInfo.Controls.Add(this.pictureBox7);
            this.gbReplacementLicenseApplicationInfo.Controls.Add(this.label2);
            this.gbReplacementLicenseApplicationInfo.Controls.Add(this.pictureBox5);
            this.gbReplacementLicenseApplicationInfo.Controls.Add(this.label8);
            this.gbReplacementLicenseApplicationInfo.Controls.Add(this.lblReplacementLicenseID);
            this.gbReplacementLicenseApplicationInfo.Controls.Add(this.lblReplacementLicenseApplicationID);
            this.gbReplacementLicenseApplicationInfo.Controls.Add(this.pictureBox3);
            this.gbReplacementLicenseApplicationInfo.Controls.Add(this.label3);
            this.gbReplacementLicenseApplicationInfo.Controls.Add(this.pictureBox1);
            this.gbReplacementLicenseApplicationInfo.Controls.Add(this.label4);
            this.gbReplacementLicenseApplicationInfo.Controls.Add(this.lblApplicationFees);
            this.gbReplacementLicenseApplicationInfo.Controls.Add(this.pictureBox2);
            this.gbReplacementLicenseApplicationInfo.Controls.Add(this.label5);
            this.gbReplacementLicenseApplicationInfo.Controls.Add(this.llOldLocalLicenseID);
            this.gbReplacementLicenseApplicationInfo.Controls.Add(this.llCreatedByUsername);
            this.gbReplacementLicenseApplicationInfo.Controls.Add(this.pictureBox8);
            this.gbReplacementLicenseApplicationInfo.Controls.Add(this.label7);
            this.gbReplacementLicenseApplicationInfo.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbReplacementLicenseApplicationInfo.Location = new System.Drawing.Point(13, 458);
            this.gbReplacementLicenseApplicationInfo.Name = "gbReplacementLicenseApplicationInfo";
            this.gbReplacementLicenseApplicationInfo.Size = new System.Drawing.Size(817, 158);
            this.gbReplacementLicenseApplicationInfo.TabIndex = 57;
            this.gbReplacementLicenseApplicationInfo.TabStop = false;
            this.gbReplacementLicenseApplicationInfo.Text = "Replacement License Application Info";
            this.gbReplacementLicenseApplicationInfo.Visible = false;
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(103, 128);
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(609, 23);
            this.txtNotes.TabIndex = 62;
            // 
            // pictureBox10
            // 
            this.pictureBox10.Image = global::DVLD.WinForms.Properties.Resources.Notes_32;
            this.pictureBox10.Location = new System.Drawing.Point(6, 121);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(32, 32);
            this.pictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox10.TabIndex = 64;
            this.pictureBox10.TabStop = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(44, 129);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(49, 16);
            this.label13.TabIndex = 63;
            this.label13.Text = "Notes:";
            // 
            // lblApplicationDate
            // 
            this.lblApplicationDate.AutoSize = true;
            this.lblApplicationDate.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationDate.Location = new System.Drawing.Point(163, 63);
            this.lblApplicationDate.Name = "lblApplicationDate";
            this.lblApplicationDate.Size = new System.Drawing.Size(83, 14);
            this.lblApplicationDate.TabIndex = 55;
            this.lblApplicationDate.Text = "DD/MM/YYYY";
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = global::DVLD.WinForms.Properties.Resources.Calendar_32;
            this.pictureBox7.Location = new System.Drawing.Point(6, 55);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(32, 32);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox7.TabIndex = 54;
            this.pictureBox7.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(44, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 14);
            this.label2.TabIndex = 53;
            this.label2.Text = "Application Date:";
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::DVLD.WinForms.Properties.Resources.LocalDriving_License;
            this.pictureBox5.Location = new System.Drawing.Point(464, 55);
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
            this.label8.Location = new System.Drawing.Point(502, 63);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 14);
            this.label8.TabIndex = 51;
            this.label8.Text = "Old License ID:";
            // 
            // lblReplacementLicenseID
            // 
            this.lblReplacementLicenseID.AutoSize = true;
            this.lblReplacementLicenseID.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReplacementLicenseID.Location = new System.Drawing.Point(675, 30);
            this.lblReplacementLicenseID.Name = "lblReplacementLicenseID";
            this.lblReplacementLicenseID.Size = new System.Drawing.Size(28, 16);
            this.lblReplacementLicenseID.TabIndex = 37;
            this.lblReplacementLicenseID.Text = "N/A";
            // 
            // lblReplacementLicenseApplicationID
            // 
            this.lblReplacementLicenseApplicationID.AutoSize = true;
            this.lblReplacementLicenseApplicationID.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReplacementLicenseApplicationID.Location = new System.Drawing.Point(293, 30);
            this.lblReplacementLicenseApplicationID.Name = "lblReplacementLicenseApplicationID";
            this.lblReplacementLicenseApplicationID.Size = new System.Drawing.Size(28, 16);
            this.lblReplacementLicenseApplicationID.TabIndex = 37;
            this.lblReplacementLicenseApplicationID.Text = "N/A";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::DVLD.WinForms.Properties.Resources.Renew_Driving_License_32;
            this.pictureBox3.Location = new System.Drawing.Point(464, 22);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(32, 32);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 36;
            this.pictureBox3.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(502, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(166, 16);
            this.label3.TabIndex = 35;
            this.label3.Text = "Replacement License ID:";
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(44, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(242, 16);
            this.label4.TabIndex = 35;
            this.label4.Text = "Replacement License Application ID:";
            // 
            // lblApplicationFees
            // 
            this.lblApplicationFees.AutoSize = true;
            this.lblApplicationFees.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationFees.Location = new System.Drawing.Point(167, 96);
            this.lblApplicationFees.Name = "lblApplicationFees";
            this.lblApplicationFees.Size = new System.Drawing.Size(25, 16);
            this.lblApplicationFees.TabIndex = 34;
            this.lblApplicationFees.Text = "???";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DVLD.WinForms.Properties.Resources.money_32;
            this.pictureBox2.Location = new System.Drawing.Point(6, 88);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 32);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 33;
            this.pictureBox2.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(44, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 16);
            this.label5.TabIndex = 32;
            this.label5.Text = "Application Fees:";
            // 
            // llOldLocalLicenseID
            // 
            this.llOldLocalLicenseID.AutoSize = true;
            this.llOldLocalLicenseID.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llOldLocalLicenseID.Location = new System.Drawing.Point(603, 62);
            this.llOldLocalLicenseID.Name = "llOldLocalLicenseID";
            this.llOldLocalLicenseID.Size = new System.Drawing.Size(25, 16);
            this.llOldLocalLicenseID.TabIndex = 31;
            this.llOldLocalLicenseID.TabStop = true;
            this.llOldLocalLicenseID.Text = "???";
            this.llOldLocalLicenseID.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llOldLocalLicenseID_LinkClicked);
            // 
            // llCreatedByUsername
            // 
            this.llCreatedByUsername.AutoSize = true;
            this.llCreatedByUsername.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llCreatedByUsername.Location = new System.Drawing.Point(603, 96);
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
            this.pictureBox8.Location = new System.Drawing.Point(464, 88);
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
            this.label7.Location = new System.Drawing.Point(502, 96);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 16);
            this.label7.TabIndex = 29;
            this.label7.Text = "Created By:";
            // 
            // llShowReplacementLicenseInfo
            // 
            this.llShowReplacementLicenseInfo.AutoSize = true;
            this.llShowReplacementLicenseInfo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llShowReplacementLicenseInfo.Location = new System.Drawing.Point(212, 642);
            this.llShowReplacementLicenseInfo.Name = "llShowReplacementLicenseInfo";
            this.llShowReplacementLicenseInfo.Size = new System.Drawing.Size(233, 19);
            this.llShowReplacementLicenseInfo.TabIndex = 66;
            this.llShowReplacementLicenseInfo.TabStop = true;
            this.llShowReplacementLicenseInfo.Text = "Show Replacement License Info";
            this.llShowReplacementLicenseInfo.Visible = false;
            this.llShowReplacementLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llShowReplacementLicenseInfo_LinkClicked);
            // 
            // llShowLicensesHistory
            // 
            this.llShowLicensesHistory.AutoSize = true;
            this.llShowLicensesHistory.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llShowLicensesHistory.Location = new System.Drawing.Point(15, 642);
            this.llShowLicensesHistory.Name = "llShowLicensesHistory";
            this.llShowLicensesHistory.Size = new System.Drawing.Size(166, 19);
            this.llShowLicensesHistory.TabIndex = 67;
            this.llShowLicensesHistory.TabStop = true;
            this.llShowLicensesHistory.Text = "Show Licenses History";
            this.llShowLicensesHistory.Visible = false;
            this.llShowLicensesHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llShowLicensesHistory_LinkClicked);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(7, 613);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(835, 13);
            this.label14.TabIndex = 65;
            this.label14.Text = "_________________________________________________________________________________" +
    "_________________________________________________________";
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImage = global::DVLD.WinForms.Properties.Resources.Close_32;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(571, 634);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(102, 34);
            this.btnClose.TabIndex = 64;
            this.btnClose.Text = "     Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnReplacement
            // 
            this.btnReplacement.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnReplacement.Enabled = false;
            this.btnReplacement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReplacement.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReplacement.Image = global::DVLD.WinForms.Properties.Resources.Renew_Driving_License_32;
            this.btnReplacement.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReplacement.Location = new System.Drawing.Point(679, 634);
            this.btnReplacement.Name = "btnReplacement";
            this.btnReplacement.Size = new System.Drawing.Size(150, 34);
            this.btnReplacement.TabIndex = 63;
            this.btnReplacement.Text = "        Replacement";
            this.btnReplacement.UseVisualStyleBackColor = true;
            this.btnReplacement.Click += new System.EventHandler(this.btnReplacement_Click);
            // 
            // ctrDriverLicenseInfoWithFilter
            // 
            this.ctrDriverLicenseInfoWithFilter.Location = new System.Drawing.Point(13, 62);
            this.ctrDriverLicenseInfoWithFilter.Name = "ctrDriverLicenseInfoWithFilter";
            this.ctrDriverLicenseInfoWithFilter.Size = new System.Drawing.Size(823, 392);
            this.ctrDriverLicenseInfoWithFilter.TabIndex = 0;
            // 
            // frmReplacementForDamagedOrLost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 683);
            this.Controls.Add(this.llShowReplacementLicenseInfo);
            this.Controls.Add(this.llShowLicensesHistory);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnReplacement);
            this.Controls.Add(this.gbReplacementLicenseApplicationInfo);
            this.Controls.Add(this.lblFormTitle);
            this.Controls.Add(this.gbReplacementFor);
            this.Controls.Add(this.ctrDriverLicenseInfoWithFilter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReplacementForDamagedOrLost";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Replacement For Damaged or Lost";
            this.Activated += new System.EventHandler(this.frmReplacementForDamagedOrLost_Activated);
            this.Load += new System.EventHandler(this.frmReplacementForDamagedOrLost_Load);
            this.gbReplacementFor.ResumeLayout(false);
            this.gbReplacementFor.PerformLayout();
            this.gbReplacementLicenseApplicationInfo.ResumeLayout(false);
            this.gbReplacementLicenseApplicationInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Licenses.ctrDriverLicenseInfoWithFilter ctrDriverLicenseInfoWithFilter;
        private System.Windows.Forms.GroupBox gbReplacementFor;
        private System.Windows.Forms.RadioButton rbLost;
        private System.Windows.Forms.RadioButton rbDamaged;
        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.GroupBox gbReplacementLicenseApplicationInfo;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblReplacementLicenseID;
        private System.Windows.Forms.Label lblReplacementLicenseApplicationID;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblApplicationFees;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.LinkLabel llOldLocalLicenseID;
        private System.Windows.Forms.LinkLabel llCreatedByUsername;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblApplicationDate;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel llShowReplacementLicenseInfo;
        private System.Windows.Forms.LinkLabel llShowLicensesHistory;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnReplacement;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.Label label13;
    }
}