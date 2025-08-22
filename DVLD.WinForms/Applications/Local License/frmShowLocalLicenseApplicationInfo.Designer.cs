namespace DVLD.WinForms.Applications.LocalLicense
{
    partial class frmShowLocalLicenseApplicationInfo
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
            this.btnCloseScreen = new System.Windows.Forms.Button();
            this.ctrLocalLicenseApplicationInfo = new DVLD.WinForms.Applications.LocalLicense.ctrLocalLicenseApplicationInfo();
            this.SuspendLayout();
            // 
            // btnCloseScreen
            // 
            this.btnCloseScreen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCloseScreen.BackgroundImage = global::DVLD.WinForms.Properties.Resources.Close_32;
            this.btnCloseScreen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCloseScreen.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCloseScreen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseScreen.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseScreen.Location = new System.Drawing.Point(585, 330);
            this.btnCloseScreen.Name = "btnCloseScreen";
            this.btnCloseScreen.Size = new System.Drawing.Size(102, 34);
            this.btnCloseScreen.TabIndex = 24;
            this.btnCloseScreen.Text = "     Close";
            this.btnCloseScreen.UseVisualStyleBackColor = true;
            this.btnCloseScreen.Click += new System.EventHandler(this.btnCloseScreen_Click);
            // 
            // ctrLocalLicenseApplicationInfo
            // 
            this.ctrLocalLicenseApplicationInfo.LocalLicenseApplication = null;
            this.ctrLocalLicenseApplicationInfo.Location = new System.Drawing.Point(2, 1);
            this.ctrLocalLicenseApplicationInfo.Name = "ctrLocalLicenseApplicationInfo";
            this.ctrLocalLicenseApplicationInfo.Size = new System.Drawing.Size(693, 317);
            this.ctrLocalLicenseApplicationInfo.TabIndex = 0;
            // 
            // frmShowLocalLicenseApplicationInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCloseScreen;
            this.ClientSize = new System.Drawing.Size(699, 376);
            this.Controls.Add(this.btnCloseScreen);
            this.Controls.Add(this.ctrLocalLicenseApplicationInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmShowLocalLicenseApplicationInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Show Local License Application Info";
            this.Load += new System.EventHandler(this.frmShowLocalLicenseApplicationInfo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrLocalLicenseApplicationInfo ctrLocalLicenseApplicationInfo;
        private System.Windows.Forms.Button btnCloseScreen;
    }
}