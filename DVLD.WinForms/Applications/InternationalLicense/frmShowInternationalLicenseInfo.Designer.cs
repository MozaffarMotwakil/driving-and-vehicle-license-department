namespace DVLD.WinForms.Applications.InternationalLicense
{
    partial class frmShowInternationalLicenseInfo
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
            this.pbFormLogo = new System.Windows.Forms.PictureBox();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.ctrInternationalLicenseInfo = new DVLD.WinForms.Applications.InternationalLicense.ctrInternationalLicenseInfo();
            this.btnClose = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbFormLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pbFormLogo
            // 
            this.pbFormLogo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pbFormLogo.Image = global::DVLD.WinForms.Properties.Resources.LicenseView_400;
            this.pbFormLogo.Location = new System.Drawing.Point(339, 12);
            this.pbFormLogo.Name = "pbFormLogo";
            this.pbFormLogo.Size = new System.Drawing.Size(224, 85);
            this.pbFormLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbFormLogo.TabIndex = 24;
            this.pbFormLogo.TabStop = false;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblFormTitle.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormTitle.ForeColor = System.Drawing.Color.Red;
            this.lblFormTitle.Location = new System.Drawing.Point(132, 101);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(638, 33);
            this.lblFormTitle.TabIndex = 23;
            this.lblFormTitle.Text = "Driver International License Info";
            this.lblFormTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ctrInternationalLicenseInfo
            // 
            this.ctrInternationalLicenseInfo.Location = new System.Drawing.Point(10, 149);
            this.ctrInternationalLicenseInfo.Name = "ctrInternationalLicenseInfo";
            this.ctrInternationalLicenseInfo.Size = new System.Drawing.Size(882, 219);
            this.ctrInternationalLicenseInfo.TabIndex = 25;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackgroundImage = global::DVLD.WinForms.Properties.Resources.Close_32;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(789, 386);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(102, 34);
            this.btnClose.TabIndex = 31;
            this.btnClose.Text = "     Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 366);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(901, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "_________________________________________________________________________________" +
    "____________________________________________________________________";
            // 
            // frmShowInternationalLicenseInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 428);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ctrInternationalLicenseInfo);
            this.Controls.Add(this.pbFormLogo);
            this.Controls.Add(this.lblFormTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmShowInternationalLicenseInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "International License Info";
            this.Load += new System.EventHandler(this.frmShowInternationalLicenseInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbFormLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbFormLogo;
        private System.Windows.Forms.Label lblFormTitle;
        private ctrInternationalLicenseInfo ctrInternationalLicenseInfo;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label2;
    }
}