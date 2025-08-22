namespace DVLD.WinForms.Applications.InternationalLicense
{
    partial class frmManageInternationalLicenses
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
            this.cbActivity = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.recordsListContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showPersonDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.showPersonLicensesHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLicenseDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.formContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.issueInternationalLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.recordsListContextMenuStrip.SuspendLayout();
            this.formContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbActivity
            // 
            this.cbActivity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cbActivity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbActivity.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbActivity.FormattingEnabled = true;
            this.cbActivity.Items.AddRange(new object[] {
            "All",
            "Yes",
            "No"});
            this.cbActivity.Location = new System.Drawing.Point(228, 150);
            this.cbActivity.Name = "cbActivity";
            this.cbActivity.Size = new System.Drawing.Size(128, 24);
            this.cbActivity.TabIndex = 33;
            this.cbActivity.Visible = false;
            this.cbActivity.SelectedIndexChanged += new System.EventHandler(this.cbActivity_SelectedIndexChanged);
            this.cbActivity.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmManageInternationalLicenses_MouseDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox1.Image = global::DVLD.WinForms.Properties.Resources.International_32;
            this.pictureBox1.Location = new System.Drawing.Point(637, 36);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(58, 47);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 34;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmManageInternationalLicenses_MouseDown);
            // 
            // recordsListContextMenuStrip
            // 
            this.recordsListContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showPersonDetailsToolStripMenuItem,
            this.toolStripSeparator1,
            this.showLicenseDetailsToolStripMenuItem,
            this.toolStripSeparator2,
            this.showPersonLicensesHistoryToolStripMenuItem});
            this.recordsListContextMenuStrip.Name = "contextMenuStrip1";
            this.recordsListContextMenuStrip.Size = new System.Drawing.Size(247, 130);
            this.recordsListContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.recordsListContextMenuStrip_Opening);
            // 
            // showPersonDetailsToolStripMenuItem
            // 
            this.showPersonDetailsToolStripMenuItem.Image = global::DVLD.WinForms.Properties.Resources.PersonDetails_32;
            this.showPersonDetailsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showPersonDetailsToolStripMenuItem.Name = "showPersonDetailsToolStripMenuItem";
            this.showPersonDetailsToolStripMenuItem.Size = new System.Drawing.Size(246, 38);
            this.showPersonDetailsToolStripMenuItem.Text = "Show Person Details";
            this.showPersonDetailsToolStripMenuItem.Click += new System.EventHandler(this.showPersonDetailsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(243, 6);
            // 
            // showPersonLicensesHistoryToolStripMenuItem
            // 
            this.showPersonLicensesHistoryToolStripMenuItem.Image = global::DVLD.WinForms.Properties.Resources.PersonLicenseHistory_32;
            this.showPersonLicensesHistoryToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showPersonLicensesHistoryToolStripMenuItem.Name = "showPersonLicensesHistoryToolStripMenuItem";
            this.showPersonLicensesHistoryToolStripMenuItem.Size = new System.Drawing.Size(246, 38);
            this.showPersonLicensesHistoryToolStripMenuItem.Text = "Show Person Licenses History";
            this.showPersonLicensesHistoryToolStripMenuItem.Click += new System.EventHandler(this.showPersonLicensesHistoryToolStripMenuItem_Click);
            // 
            // showLicenseDetailsToolStripMenuItem
            // 
            this.showLicenseDetailsToolStripMenuItem.Image = global::DVLD.WinForms.Properties.Resources.International_32;
            this.showLicenseDetailsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showLicenseDetailsToolStripMenuItem.Name = "showLicenseDetailsToolStripMenuItem";
            this.showLicenseDetailsToolStripMenuItem.Size = new System.Drawing.Size(246, 38);
            this.showLicenseDetailsToolStripMenuItem.Text = "Show License Details";
            this.showLicenseDetailsToolStripMenuItem.Click += new System.EventHandler(this.showLicenseDetailsToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(243, 6);
            // 
            // formContextMenuStrip
            // 
            this.formContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.issueInternationalLicenseToolStripMenuItem});
            this.formContextMenuStrip.Name = "formContextMenuStrip";
            this.formContextMenuStrip.Size = new System.Drawing.Size(229, 42);
            // 
            // issueInternationalLicenseToolStripMenuItem
            // 
            this.issueInternationalLicenseToolStripMenuItem.Image = global::DVLD.WinForms.Properties.Resources.New_Driving_License_32;
            this.issueInternationalLicenseToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.issueInternationalLicenseToolStripMenuItem.Name = "issueInternationalLicenseToolStripMenuItem";
            this.issueInternationalLicenseToolStripMenuItem.Size = new System.Drawing.Size(228, 38);
            this.issueInternationalLicenseToolStripMenuItem.Text = "Issue International License";
            this.issueInternationalLicenseToolStripMenuItem.Click += new System.EventHandler(this.issueInternationalLicenseToolStripMenuItem_Click);
            // 
            // frmManageInternationalLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 561);
            this.ContextMenuStrip = this.formContextMenuStrip;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cbActivity);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmManageInternationalLicenses";
            this.Text = "Manage International Licenses";
            this.Load += new System.EventHandler(this.frmManageInternationalLicenses_Load);
            this.Controls.SetChildIndex(this.cbActivity, 0);
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.recordsListContextMenuStrip.ResumeLayout(false);
            this.formContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbActivity;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ContextMenuStrip recordsListContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem showPersonDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem showPersonLicensesHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLicenseDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ContextMenuStrip formContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem issueInternationalLicenseToolStripMenuItem;
    }
}