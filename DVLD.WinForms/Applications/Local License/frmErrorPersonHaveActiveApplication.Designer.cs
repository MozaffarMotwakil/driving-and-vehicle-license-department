namespace DVLD.WinForms.Applications.LocalLicense
{
    partial class frmErrorPersonHaveActiveApplication
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
            this.llApplicationDetails = new System.Windows.Forms.LinkLabel();
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
            this.btnOK.TabIndex = 6;
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
            this.lblMessage.TabIndex = 5;
            this.lblMessage.Text = "Please choose another license class, the selected person already have an active a" +
    "pplication for the selected class.";
            // 
            // llApplicationDetails
            // 
            this.llApplicationDetails.AutoSize = true;
            this.llApplicationDetails.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llApplicationDetails.Location = new System.Drawing.Point(63, 46);
            this.llApplicationDetails.Name = "llApplicationDetails";
            this.llApplicationDetails.Size = new System.Drawing.Size(111, 16);
            this.llApplicationDetails.TabIndex = 4;
            this.llApplicationDetails.TabStop = true;
            this.llApplicationDetails.Text = "Application Details";
            this.llApplicationDetails.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llApplicationDetails_LinkClicked);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD.WinForms.Properties.Resources.Error_64;
            this.pictureBox1.Location = new System.Drawing.Point(0, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 58);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // frmPersonHaveActiveApplication
            // 
            this.AcceptButton = this.llApplicationDetails;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnOK;
            this.ClientSize = new System.Drawing.Size(430, 97);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.llApplicationDetails);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPersonHaveActiveApplication";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Error";
            this.Load += new System.EventHandler(this.frmPersonHaveActiveApplication_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.LinkLabel llApplicationDetails;
    }
}