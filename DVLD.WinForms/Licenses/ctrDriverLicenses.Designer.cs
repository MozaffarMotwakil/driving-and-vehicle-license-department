namespace DVLD.WinForms.Licenses
{
    partial class ctrDriverLicenses
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tpLocal = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvLocalLicenses = new System.Windows.Forms.DataGridView();
            this.licensesListContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showLicenseDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tpInternational = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvInternationalLicenses = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tpLocal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalLicenses)).BeginInit();
            this.licensesListContextMenuStrip.SuspendLayout();
            this.tpInternational.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalLicenses)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblRecordsCount);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tabControl);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(780, 303);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Driver Licenses";
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRecordsCount.AutoSize = true;
            this.lblRecordsCount.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordsCount.Location = new System.Drawing.Point(100, 275);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(33, 19);
            this.lblRecordsCount.TabIndex = 18;
            this.lblRecordsCount.Text = "???";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 275);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 19);
            this.label1.TabIndex = 19;
            this.label1.Text = "# Records:";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tpLocal);
            this.tabControl.Controls.Add(this.tpInternational);
            this.tabControl.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl.Location = new System.Drawing.Point(6, 22);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(768, 250);
            this.tabControl.TabIndex = 0;
            this.tabControl.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl_Selecting);
            // 
            // tpLocal
            // 
            this.tpLocal.Controls.Add(this.label2);
            this.tpLocal.Controls.Add(this.dgvLocalLicenses);
            this.tpLocal.Location = new System.Drawing.Point(4, 22);
            this.tpLocal.Name = "tpLocal";
            this.tpLocal.Padding = new System.Windows.Forms.Padding(3);
            this.tpLocal.Size = new System.Drawing.Size(760, 224);
            this.tpLocal.TabIndex = 0;
            this.tpLocal.Text = "Local";
            this.tpLocal.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Local Driving Licenses:";
            // 
            // dgvLocalLicenses
            // 
            this.dgvLocalLicenses.AllowUserToAddRows = false;
            this.dgvLocalLicenses.AllowUserToDeleteRows = false;
            this.dgvLocalLicenses.AllowUserToOrderColumns = true;
            this.dgvLocalLicenses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLocalLicenses.BackgroundColor = System.Drawing.Color.White;
            this.dgvLocalLicenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocalLicenses.ContextMenuStrip = this.licensesListContextMenuStrip;
            this.dgvLocalLicenses.Location = new System.Drawing.Point(0, 28);
            this.dgvLocalLicenses.Name = "dgvLocalLicenses";
            this.dgvLocalLicenses.ReadOnly = true;
            this.dgvLocalLicenses.Size = new System.Drawing.Size(760, 193);
            this.dgvLocalLicenses.TabIndex = 0;
            this.dgvLocalLicenses.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvLocalLicenses_CellMouseDoubleClick);
            this.dgvLocalLicenses.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvLocalLicenses_CellMouseDown);
            this.dgvLocalLicenses.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvLocalLicenses_MouseDown);
            // 
            // licensesListContextMenuStrip
            // 
            this.licensesListContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showLicenseDetailsToolStripMenuItem});
            this.licensesListContextMenuStrip.Name = "licensesListContextMenuStrip";
            this.licensesListContextMenuStrip.Size = new System.Drawing.Size(200, 64);
            this.licensesListContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.licensesListContextMenuStrip_Opening);
            // 
            // showLicenseDetailsToolStripMenuItem
            // 
            this.showLicenseDetailsToolStripMenuItem.Image = global::DVLD.WinForms.Properties.Resources.LocalDriving_License;
            this.showLicenseDetailsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showLicenseDetailsToolStripMenuItem.Name = "showLicenseDetailsToolStripMenuItem";
            this.showLicenseDetailsToolStripMenuItem.Size = new System.Drawing.Size(199, 38);
            this.showLicenseDetailsToolStripMenuItem.Text = "Show License Details";
            this.showLicenseDetailsToolStripMenuItem.Click += new System.EventHandler(this.showLicenseDetailsToolStripMenuItem_Click);
            // 
            // tpInternational
            // 
            this.tpInternational.Controls.Add(this.label3);
            this.tpInternational.Controls.Add(this.dgvInternationalLicenses);
            this.tpInternational.Location = new System.Drawing.Point(4, 22);
            this.tpInternational.Name = "tpInternational";
            this.tpInternational.Padding = new System.Windows.Forms.Padding(3);
            this.tpInternational.Size = new System.Drawing.Size(760, 224);
            this.tpInternational.TabIndex = 1;
            this.tpInternational.Text = "International";
            this.tpInternational.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(205, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "International Driving Licenses:";
            // 
            // dgvInternationalLicenses
            // 
            this.dgvInternationalLicenses.AllowUserToAddRows = false;
            this.dgvInternationalLicenses.AllowUserToDeleteRows = false;
            this.dgvInternationalLicenses.AllowUserToOrderColumns = true;
            this.dgvInternationalLicenses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInternationalLicenses.BackgroundColor = System.Drawing.Color.White;
            this.dgvInternationalLicenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInternationalLicenses.ContextMenuStrip = this.licensesListContextMenuStrip;
            this.dgvInternationalLicenses.Location = new System.Drawing.Point(0, 28);
            this.dgvInternationalLicenses.Name = "dgvInternationalLicenses";
            this.dgvInternationalLicenses.ReadOnly = true;
            this.dgvInternationalLicenses.Size = new System.Drawing.Size(760, 193);
            this.dgvInternationalLicenses.TabIndex = 2;
            // 
            // ctrDriverLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "ctrDriverLicenses";
            this.Size = new System.Drawing.Size(785, 308);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tpLocal.ResumeLayout(false);
            this.tpLocal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalLicenses)).EndInit();
            this.licensesListContextMenuStrip.ResumeLayout(false);
            this.tpInternational.ResumeLayout(false);
            this.tpInternational.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalLicenses)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tpLocal;
        private System.Windows.Forms.TabPage tpInternational;
        private System.Windows.Forms.Label lblRecordsCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvLocalLicenses;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvInternationalLicenses;
        private System.Windows.Forms.ContextMenuStrip licensesListContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem showLicenseDetailsToolStripMenuItem;
    }
}
