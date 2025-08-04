namespace DVLD.WinForms.Applications
{
    partial class frmManageApplicationTypes
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
            this.label2 = new System.Windows.Forms.Label();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvApplicatonsList = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnCloseScreen = new System.Windows.Forms.Button();
            this.contextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplicatonsList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(231, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(323, 33);
            this.label2.TabIndex = 15;
            this.label2.Text = "Manage Application Types";
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRecordsCount.AutoSize = true;
            this.lblRecordsCount.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordsCount.Location = new System.Drawing.Point(96, 515);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(33, 19);
            this.lblRecordsCount.TabIndex = 16;
            this.lblRecordsCount.Text = "???";
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip1";
            this.contextMenuStrip.Size = new System.Drawing.Size(111, 42);
            this.contextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_Opening);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = global::DVLD.WinForms.Properties.Resources.edit_32;
            this.editToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(110, 38);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 515);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 19);
            this.label1.TabIndex = 17;
            this.label1.Text = "# Records:";
            // 
            // dgvApplicatonsList
            // 
            this.dgvApplicatonsList.AllowUserToAddRows = false;
            this.dgvApplicatonsList.AllowUserToDeleteRows = false;
            this.dgvApplicatonsList.AllowUserToOrderColumns = true;
            this.dgvApplicatonsList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvApplicatonsList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvApplicatonsList.BackgroundColor = System.Drawing.Color.White;
            this.dgvApplicatonsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvApplicatonsList.ContextMenuStrip = this.contextMenuStrip;
            this.dgvApplicatonsList.Location = new System.Drawing.Point(12, 204);
            this.dgvApplicatonsList.Name = "dgvApplicatonsList";
            this.dgvApplicatonsList.ReadOnly = true;
            this.dgvApplicatonsList.Size = new System.Drawing.Size(760, 305);
            this.dgvApplicatonsList.TabIndex = 14;
            this.dgvApplicatonsList.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvApplicatonsList_CellMouseDown);
            this.dgvApplicatonsList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvApplicatonsList_MouseDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::DVLD.WinForms.Properties.Resources.Application_Types_512;
            this.pictureBox1.Location = new System.Drawing.Point(294, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(196, 119);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // btnCloseScreen
            // 
            this.btnCloseScreen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCloseScreen.BackgroundImage = global::DVLD.WinForms.Properties.Resources.Close_32;
            this.btnCloseScreen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCloseScreen.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCloseScreen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseScreen.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseScreen.Location = new System.Drawing.Point(670, 515);
            this.btnCloseScreen.Name = "btnCloseScreen";
            this.btnCloseScreen.Size = new System.Drawing.Size(102, 34);
            this.btnCloseScreen.TabIndex = 22;
            this.btnCloseScreen.Text = "     Close";
            this.btnCloseScreen.UseVisualStyleBackColor = true;
            this.btnCloseScreen.Click += new System.EventHandler(this.btnCloseScreen_Click);
            // 
            // frmManageApplicationTypes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCloseScreen;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnCloseScreen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblRecordsCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvApplicatonsList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmManageApplicationTypes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Application Types";
            this.Load += new System.EventHandler(this.frmManageApplicationTypes_Load);
            this.contextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplicatonsList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnCloseScreen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblRecordsCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvApplicatonsList;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
    }
}