namespace DVLD.WinForms.Applications.BaseApplication
{
    partial class frmShowBaseApplicationInfo
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
            this.ctrBaseApplicationInfo = new DVLD.WinForms.Applications.BaseApplication.ctrBaseApplicationInfo();
            this.label12 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ctrBaseApplicationInfo
            // 
            this.ctrBaseApplicationInfo.Application = null;
            this.ctrBaseApplicationInfo.Location = new System.Drawing.Point(12, 69);
            this.ctrBaseApplicationInfo.Name = "ctrBaseApplicationInfo";
            this.ctrBaseApplicationInfo.Size = new System.Drawing.Size(688, 211);
            this.ctrBaseApplicationInfo.TabIndex = 0;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(11, 278);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(691, 13);
            this.label12.TabIndex = 53;
            this.label12.Text = "_________________________________________________________________________________" +
    "_________________________________";
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImage = global::DVLD.WinForms.Properties.Resources.Close_32;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(594, 299);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(102, 34);
            this.btnClose.TabIndex = 52;
            this.btnClose.Text = "     Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(199, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(315, 39);
            this.label1.TabIndex = 54;
            this.label1.Text = "Base Application Info";
            // 
            // frmShowBaseApplicationInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(711, 344);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrBaseApplicationInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmShowBaseApplicationInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Base Application Info";
            this.Load += new System.EventHandler(this.frmShowBaseApplicationInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrBaseApplicationInfo ctrBaseApplicationInfo;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
    }
}