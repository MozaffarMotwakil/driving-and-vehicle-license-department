namespace DVLD.WinForms.Licenses
{
    partial class ctrDriverLicenseInfoWithFilter
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gbFilter = new System.Windows.Forms.GroupBox();
            this.btnFindLicense = new System.Windows.Forms.Button();
            this.txtFilterText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.ctrDriverLicenseInfo = new DVLD.WinForms.Licenses.ctrDriverLicenseInfo();
            this.gbFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // gbFilter
            // 
            this.gbFilter.Controls.Add(this.btnFindLicense);
            this.gbFilter.Controls.Add(this.txtFilterText);
            this.gbFilter.Controls.Add(this.label3);
            this.gbFilter.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFilter.Location = new System.Drawing.Point(3, 3);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Size = new System.Drawing.Size(400, 60);
            this.gbFilter.TabIndex = 2;
            this.gbFilter.TabStop = false;
            this.gbFilter.Text = "Filter";
            // 
            // btnFindLicense
            // 
            this.btnFindLicense.BackgroundImage = global::DVLD.WinForms.Properties.Resources.License_View_32;
            this.btnFindLicense.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnFindLicense.Location = new System.Drawing.Point(352, 16);
            this.btnFindLicense.Name = "btnFindLicense";
            this.btnFindLicense.Size = new System.Drawing.Size(42, 38);
            this.btnFindLicense.TabIndex = 0;
            this.btnFindLicense.UseVisualStyleBackColor = true;
            this.btnFindLicense.Click += new System.EventHandler(this.btnFindLicense_Click);
            // 
            // txtFilterText
            // 
            this.txtFilterText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtFilterText.Location = new System.Drawing.Point(100, 21);
            this.txtFilterText.Name = "txtFilterText";
            this.txtFilterText.Size = new System.Drawing.Size(226, 23);
            this.txtFilterText.TabIndex = 0;
            this.txtFilterText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFilterText_KeyDown);
            this.txtFilterText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterText_KeyPress);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 19);
            this.label3.TabIndex = 26;
            this.label3.Text = "License ID:";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // ctrDriverLicenseInfo
            // 
            this.ctrDriverLicenseInfo.License = null;
            this.ctrDriverLicenseInfo.Location = new System.Drawing.Point(1, 69);
            this.ctrDriverLicenseInfo.Name = "ctrDriverLicenseInfo";
            this.ctrDriverLicenseInfo.Size = new System.Drawing.Size(823, 368);
            this.ctrDriverLicenseInfo.TabIndex = 3;
            // 
            // ctrDriverLicenseInfoWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctrDriverLicenseInfo);
            this.Controls.Add(this.gbFilter);
            this.Name = "ctrDriverLicenseInfoWithFilter";
            this.Size = new System.Drawing.Size(823, 435);
            this.gbFilter.ResumeLayout(false);
            this.gbFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbFilter;
        private System.Windows.Forms.Button btnFindLicense;
        private System.Windows.Forms.TextBox txtFilterText;
        private System.Windows.Forms.Label label3;
        private ctrDriverLicenseInfo ctrDriverLicenseInfo;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}
