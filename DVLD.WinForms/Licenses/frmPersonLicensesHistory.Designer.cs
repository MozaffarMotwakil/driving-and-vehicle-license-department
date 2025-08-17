namespace DVLD.WinForms.Licenses
{
    partial class frmPersonLicensesHistory
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
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.pbFormLogo = new System.Windows.Forms.PictureBox();
            this.ctrDriverLicenses = new DVLD.WinForms.Licenses.ctrDriverLicenses();
            this.ctrPersonCardInfo = new DVLD.WinForms.People.ctrPersonCardInfo();
            ((System.ComponentModel.ISupportInitialize)(this.pbFormLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblFormTitle.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormTitle.ForeColor = System.Drawing.Color.Red;
            this.lblFormTitle.Location = new System.Drawing.Point(81, 84);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(638, 33);
            this.lblFormTitle.TabIndex = 21;
            this.lblFormTitle.Text = "Person Licenses History";
            this.lblFormTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbFormLogo
            // 
            this.pbFormLogo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pbFormLogo.Image = global::DVLD.WinForms.Properties.Resources.PersonLicenseHistory_512;
            this.pbFormLogo.Location = new System.Drawing.Point(288, 4);
            this.pbFormLogo.Name = "pbFormLogo";
            this.pbFormLogo.Size = new System.Drawing.Size(224, 85);
            this.pbFormLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbFormLogo.TabIndex = 22;
            this.pbFormLogo.TabStop = false;
            // 
            // ctrDriverLicenses
            // 
            this.ctrDriverLicenses.Location = new System.Drawing.Point(7, 390);
            this.ctrDriverLicenses.Name = "ctrDriverLicenses";
            this.ctrDriverLicenses.Size = new System.Drawing.Size(785, 308);
            this.ctrDriverLicenses.TabIndex = 24;
            // 
            // ctrPersonCardInfo
            // 
            this.ctrPersonCardInfo.Location = new System.Drawing.Point(12, 116);
            this.ctrPersonCardInfo.Name = "ctrPersonCardInfo";
            this.ctrPersonCardInfo.ShowEditPersonInformationLinke = true;
            this.ctrPersonCardInfo.Size = new System.Drawing.Size(780, 274);
            this.ctrPersonCardInfo.SuppressImageLoadWarning = false;
            this.ctrPersonCardInfo.TabIndex = 23;
            // 
            // frmPersonLicensesHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 702);
            this.Controls.Add(this.ctrDriverLicenses);
            this.Controls.Add(this.ctrPersonCardInfo);
            this.Controls.Add(this.pbFormLogo);
            this.Controls.Add(this.lblFormTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPersonLicensesHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Person Licenses History";
            this.Load += new System.EventHandler(this.frmPersonLicensesHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbFormLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbFormLogo;
        private System.Windows.Forms.Label lblFormTitle;
        private People.ctrPersonCardInfo ctrPersonCardInfo;
        private ctrDriverLicenses ctrDriverLicenses;
    }
}