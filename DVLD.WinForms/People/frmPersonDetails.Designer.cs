namespace DVLD.WinForms.People
{
    partial class frmPersonDetails
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnCloseScreen = new System.Windows.Forms.Button();
            this.ctrPersonInformation = new DVLD.WinForms.People.ctrPersonInformation();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(322, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 33);
            this.label1.TabIndex = 2;
            this.label1.Text = "Person Details";
            // 
            // btnCloseScreen
            // 
            this.btnCloseScreen.BackgroundImage = global::DVLD.WinForms.Properties.Resources.Close_32;
            this.btnCloseScreen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCloseScreen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseScreen.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseScreen.Location = new System.Drawing.Point(702, 342);
            this.btnCloseScreen.Name = "btnCloseScreen";
            this.btnCloseScreen.Size = new System.Drawing.Size(102, 34);
            this.btnCloseScreen.TabIndex = 6;
            this.btnCloseScreen.Text = "     Close";
            this.btnCloseScreen.UseVisualStyleBackColor = true;
            this.btnCloseScreen.Click += new System.EventHandler(this.btnCloseScreen_Click);
            // 
            // ctrPersonInformation
            // 
            this.ctrPersonInformation.Address = "???";
            this.ctrPersonInformation.Country = "???";
            this.ctrPersonInformation.DateOfBirth = "???";
            this.ctrPersonInformation.Email = "???";
            this.ctrPersonInformation.FullName = "???";
            this.ctrPersonInformation.Gender = "???";
            this.ctrPersonInformation.Location = new System.Drawing.Point(12, 56);
            this.ctrPersonInformation.Name = "ctrPersonInformation";
            this.ctrPersonInformation.NationalNo = "???";
            this.ctrPersonInformation.PersonID = "???";
            this.ctrPersonInformation.Phone = "???";
            this.ctrPersonInformation.Size = new System.Drawing.Size(792, 280);
            this.ctrPersonInformation.TabIndex = 7;
            // 
            // frmPersonDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 387);
            this.Controls.Add(this.ctrPersonInformation);
            this.Controls.Add(this.btnCloseScreen);
            this.Controls.Add(this.label1);
            this.Name = "frmPersonDetails";
            this.Text = "Person Details";
            this.Load += new System.EventHandler(this.frmPersonDetails_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ctrPersonInformation ctrPersonInformation1;
        private System.Windows.Forms.Button btnCloseScreen;
        private ctrPersonInformation ctrPersonInformation;
    }
}