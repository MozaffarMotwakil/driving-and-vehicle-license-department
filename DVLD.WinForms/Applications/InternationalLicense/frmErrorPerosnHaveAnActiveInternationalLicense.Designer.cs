namespace DVLD.WinForms.Applications.InternationalLicense
{
    partial class frmErrorPerosnHaveAnActiveInternationalLicense
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
            this.btnOK = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.llInternationalLicenseDetails = new System.Windows.Forms.LinkLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOK.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(345, 69);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(63, 9);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(364, 35);
            this.lblMessage.TabIndex = 9;
            this.lblMessage.Text = "Cannot issue a new international license, The person already has an active intern" +
    "ational license.";
            // 
            // llInternationalLicenseDetails
            // 
            this.llInternationalLicenseDetails.AutoSize = true;
            this.llInternationalLicenseDetails.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llInternationalLicenseDetails.Location = new System.Drawing.Point(63, 46);
            this.llInternationalLicenseDetails.Name = "llInternationalLicenseDetails";
            this.llInternationalLicenseDetails.Size = new System.Drawing.Size(167, 16);
            this.llInternationalLicenseDetails.TabIndex = 8;
            this.llInternationalLicenseDetails.TabStop = true;
            this.llInternationalLicenseDetails.Text = "International License Details";
            this.llInternationalLicenseDetails.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llInternationalLicenseDetails_LinkClicked);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD.WinForms.Properties.Resources.Error_64;
            this.pictureBox1.Location = new System.Drawing.Point(0, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 58);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // frmErrorPerosnHaveAnActiveInternationalLicense
            // 
            this.AcceptButton = this.llInternationalLicenseDetails;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnOK;
            this.ClientSize = new System.Drawing.Size(430, 97);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.llInternationalLicenseDetails);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmErrorPerosnHaveAnActiveInternationalLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Error";
            this.Load += new System.EventHandler(this.frmErrorPerosnHaveAnActiveInternationalLicense_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.LinkLabel llInternationalLicenseDetails;
    }
}