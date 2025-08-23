namespace DVLD.WinForms.Applications.DetainAndReleaseLicenses
{
    partial class frmDetainLicense
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
            this.label14 = new System.Windows.Forms.Label();
            this.txtFineFees = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblDetainDate = new System.Windows.Forms.Label();
            this.llShowLicensesHistory = new System.Windows.Forms.LinkLabel();
            this.ctrDriverLicenseInfoWithFilter = new DVLD.WinForms.Licenses.ctrDriverLicenseInfoWithFilter();
            this.label6 = new System.Windows.Forms.Label();
            this.lblDetainID = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.llLicenseID = new System.Windows.Forms.LinkLabel();
            this.llCreatedByUsername = new System.Windows.Forms.LinkLabel();
            this.label7 = new System.Windows.Forms.Label();
            this.gbDetainLicenseInfo = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pbFormLogo = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDetain = new System.Windows.Forms.Button();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbDetainLicenseInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFormLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(7, 662);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(835, 13);
            this.label14.TabIndex = 68;
            this.label14.Text = "_________________________________________________________________________________" +
    "_________________________________________________________";
            // 
            // txtFineFees
            // 
            this.txtFineFees.Location = new System.Drawing.Point(137, 86);
            this.txtFineFees.Name = "txtFineFees";
            this.txtFineFees.Size = new System.Drawing.Size(169, 23);
            this.txtFineFees.TabIndex = 59;
            this.txtFineFees.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFineFees_KeyPress);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(44, 93);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(70, 16);
            this.label12.TabIndex = 56;
            this.label12.Text = "Fine Fees:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(564, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 14);
            this.label8.TabIndex = 51;
            this.label8.Text = "License ID:";
            // 
            // lblDetainDate
            // 
            this.lblDetainDate.AutoSize = true;
            this.lblDetainDate.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetainDate.Location = new System.Drawing.Point(134, 58);
            this.lblDetainDate.Name = "lblDetainDate";
            this.lblDetainDate.Size = new System.Drawing.Size(83, 14);
            this.lblDetainDate.TabIndex = 50;
            this.lblDetainDate.Text = "DD/MM/YYYY";
            // 
            // llShowLicensesHistory
            // 
            this.llShowLicensesHistory.AutoSize = true;
            this.llShowLicensesHistory.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llShowLicensesHistory.Location = new System.Drawing.Point(16, 689);
            this.llShowLicensesHistory.Name = "llShowLicensesHistory";
            this.llShowLicensesHistory.Size = new System.Drawing.Size(166, 19);
            this.llShowLicensesHistory.TabIndex = 70;
            this.llShowLicensesHistory.TabStop = true;
            this.llShowLicensesHistory.Text = "Show Licenses History";
            this.llShowLicensesHistory.Visible = false;
            this.llShowLicensesHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llShowLicensesHistory_LinkClicked);
            // 
            // ctrDriverLicenseInfoWithFilter
            // 
            this.ctrDriverLicenseInfoWithFilter.Location = new System.Drawing.Point(12, 142);
            this.ctrDriverLicenseInfoWithFilter.Name = "ctrDriverLicenseInfoWithFilter";
            this.ctrDriverLicenseInfoWithFilter.Size = new System.Drawing.Size(823, 396);
            this.ctrDriverLicenseInfoWithFilter.TabIndex = 63;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(44, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 14);
            this.label6.TabIndex = 46;
            this.label6.Text = "Detain Date:";
            // 
            // lblDetainID
            // 
            this.lblDetainID.AutoSize = true;
            this.lblDetainID.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetainID.Location = new System.Drawing.Point(134, 25);
            this.lblDetainID.Name = "lblDetainID";
            this.lblDetainID.Size = new System.Drawing.Size(28, 16);
            this.lblDetainID.TabIndex = 37;
            this.lblDetainID.Text = "N/A";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(44, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 16);
            this.label4.TabIndex = 35;
            this.label4.Text = "Detain ID:";
            // 
            // llLicenseID
            // 
            this.llLicenseID.AutoSize = true;
            this.llLicenseID.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llLicenseID.Location = new System.Drawing.Point(654, 23);
            this.llLicenseID.Name = "llLicenseID";
            this.llLicenseID.Size = new System.Drawing.Size(25, 16);
            this.llLicenseID.TabIndex = 31;
            this.llLicenseID.TabStop = true;
            this.llLicenseID.Text = "???";
            this.llLicenseID.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llLicenseID_LinkClicked);
            // 
            // llCreatedByUsername
            // 
            this.llCreatedByUsername.AutoSize = true;
            this.llCreatedByUsername.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llCreatedByUsername.Location = new System.Drawing.Point(654, 58);
            this.llCreatedByUsername.Name = "llCreatedByUsername";
            this.llCreatedByUsername.Size = new System.Drawing.Size(25, 16);
            this.llCreatedByUsername.TabIndex = 31;
            this.llCreatedByUsername.TabStop = true;
            this.llCreatedByUsername.Text = "???";
            this.llCreatedByUsername.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llCreatedByUsername_LinkClicked);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(564, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 16);
            this.label7.TabIndex = 29;
            this.label7.Text = "Created By:";
            // 
            // gbDetainLicenseInfo
            // 
            this.gbDetainLicenseInfo.Controls.Add(this.txtFineFees);
            this.gbDetainLicenseInfo.Controls.Add(this.pictureBox9);
            this.gbDetainLicenseInfo.Controls.Add(this.label12);
            this.gbDetainLicenseInfo.Controls.Add(this.pictureBox5);
            this.gbDetainLicenseInfo.Controls.Add(this.label8);
            this.gbDetainLicenseInfo.Controls.Add(this.lblDetainDate);
            this.gbDetainLicenseInfo.Controls.Add(this.pictureBox6);
            this.gbDetainLicenseInfo.Controls.Add(this.label6);
            this.gbDetainLicenseInfo.Controls.Add(this.lblDetainID);
            this.gbDetainLicenseInfo.Controls.Add(this.pictureBox1);
            this.gbDetainLicenseInfo.Controls.Add(this.label4);
            this.gbDetainLicenseInfo.Controls.Add(this.llLicenseID);
            this.gbDetainLicenseInfo.Controls.Add(this.llCreatedByUsername);
            this.gbDetainLicenseInfo.Controls.Add(this.pictureBox8);
            this.gbDetainLicenseInfo.Controls.Add(this.label7);
            this.gbDetainLicenseInfo.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDetainLicenseInfo.Location = new System.Drawing.Point(14, 539);
            this.gbDetainLicenseInfo.Name = "gbDetainLicenseInfo";
            this.gbDetainLicenseInfo.Size = new System.Drawing.Size(817, 124);
            this.gbDetainLicenseInfo.TabIndex = 65;
            this.gbDetainLicenseInfo.TabStop = false;
            this.gbDetainLicenseInfo.Text = "Detain License Info";
            this.gbDetainLicenseInfo.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(312, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 39);
            this.label1.TabIndex = 64;
            this.label1.Text = "Detain License";
            // 
            // pbFormLogo
            // 
            this.pbFormLogo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pbFormLogo.Image = global::DVLD.WinForms.Properties.Resources.Detain_5121;
            this.pbFormLogo.Location = new System.Drawing.Point(296, 5);
            this.pbFormLogo.Name = "pbFormLogo";
            this.pbFormLogo.Size = new System.Drawing.Size(255, 92);
            this.pbFormLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbFormLogo.TabIndex = 71;
            this.pbFormLogo.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImage = global::DVLD.WinForms.Properties.Resources.Close_32;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(621, 681);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(102, 34);
            this.btnClose.TabIndex = 67;
            this.btnClose.Text = "     Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDetain
            // 
            this.btnDetain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDetain.Enabled = false;
            this.btnDetain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetain.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetain.Image = global::DVLD.WinForms.Properties.Resources.Detain_32;
            this.btnDetain.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDetain.Location = new System.Drawing.Point(729, 681);
            this.btnDetain.Name = "btnDetain";
            this.btnDetain.Size = new System.Drawing.Size(102, 34);
            this.btnDetain.TabIndex = 66;
            this.btnDetain.Text = "       Detain";
            this.btnDetain.UseVisualStyleBackColor = true;
            this.btnDetain.Click += new System.EventHandler(this.btnDetain_Click);
            // 
            // pictureBox9
            // 
            this.pictureBox9.Image = global::DVLD.WinForms.Properties.Resources.money_32;
            this.pictureBox9.Location = new System.Drawing.Point(6, 83);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(32, 32);
            this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox9.TabIndex = 57;
            this.pictureBox9.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::DVLD.WinForms.Properties.Resources.LocalDriving_License;
            this.pictureBox5.Location = new System.Drawing.Point(526, 17);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(32, 32);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox5.TabIndex = 52;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::DVLD.WinForms.Properties.Resources.Calendar_32;
            this.pictureBox6.Location = new System.Drawing.Point(6, 50);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(32, 32);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox6.TabIndex = 48;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD.WinForms.Properties.Resources.Number_32;
            this.pictureBox1.Location = new System.Drawing.Point(6, 17);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 36;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = global::DVLD.WinForms.Properties.Resources.User_32__2;
            this.pictureBox8.Location = new System.Drawing.Point(526, 50);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(32, 32);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox8.TabIndex = 30;
            this.pictureBox8.TabStop = false;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // frmDetainLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 722);
            this.Controls.Add(this.pbFormLogo);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.llShowLicensesHistory);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrDriverLicenseInfoWithFilter);
            this.Controls.Add(this.btnDetain);
            this.Controls.Add(this.gbDetainLicenseInfo);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDetainLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detain License";
            this.Activated += new System.EventHandler(this.frmDetainLicense_Activated);
            this.gbDetainLicenseInfo.ResumeLayout(false);
            this.gbDetainLicenseInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFormLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtFineFees;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblDetainDate;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.LinkLabel llShowLicensesHistory;
        private System.Windows.Forms.Button btnClose;
        private Licenses.ctrDriverLicenseInfoWithFilter ctrDriverLicenseInfoWithFilter;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblDetainID;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel llLicenseID;
        private System.Windows.Forms.LinkLabel llCreatedByUsername;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnDetain;
        private System.Windows.Forms.GroupBox gbDetainLicenseInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbFormLogo;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}