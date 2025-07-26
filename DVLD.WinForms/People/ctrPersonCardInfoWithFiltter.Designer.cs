namespace DVLD.WinForms.People
{
    partial class ctrPersonCardInfoWithFiltter
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.txtTextForFilttering = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbFiltterColumn = new System.Windows.Forms.ComboBox();
            this.ctrPersonCardInfo1 = new DVLD.WinForms.People.ctrPersonCardInfo();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.pictureBox5);
            this.groupBox1.Controls.Add(this.txtTextForFilttering);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbFiltterColumn);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, -1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(778, 60);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtter";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD.WinForms.Properties.Resources.AddPerson_321;
            this.pictureBox1.Location = new System.Drawing.Point(479, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::DVLD.WinForms.Properties.Resources.SearchPerson;
            this.pictureBox5.Location = new System.Drawing.Point(443, 23);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(30, 30);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox5.TabIndex = 13;
            this.pictureBox5.TabStop = false;
            // 
            // txtTextForFilttering
            // 
            this.txtTextForFilttering.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTextForFilttering.Location = new System.Drawing.Point(225, 29);
            this.txtTextForFilttering.Name = "txtTextForFilttering";
            this.txtTextForFilttering.Size = new System.Drawing.Size(200, 23);
            this.txtTextForFilttering.TabIndex = 27;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 19);
            this.label3.TabIndex = 26;
            this.label3.Text = "Filtter By:";
            // 
            // cbFiltterColumn
            // 
            this.cbFiltterColumn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cbFiltterColumn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFiltterColumn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFiltterColumn.FormattingEnabled = true;
            this.cbFiltterColumn.Items.AddRange(new object[] {
            "Person ID",
            "National No"});
            this.cbFiltterColumn.Location = new System.Drawing.Point(90, 28);
            this.cbFiltterColumn.Name = "cbFiltterColumn";
            this.cbFiltterColumn.Size = new System.Drawing.Size(129, 24);
            this.cbFiltterColumn.TabIndex = 25;
            // 
            // ctrPersonCardInfo1
            // 
            this.ctrPersonCardInfo1.Location = new System.Drawing.Point(3, 57);
            this.ctrPersonCardInfo1.Name = "ctrPersonCardInfo1";
            this.ctrPersonCardInfo1.Size = new System.Drawing.Size(780, 277);
            this.ctrPersonCardInfo1.SuppressImageLoadWarning = false;
            this.ctrPersonCardInfo1.TabIndex = 0;
            // 
            // ctrPersonCardInfoWithFiltter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ctrPersonCardInfo1);
            this.Name = "ctrPersonCardInfoWithFiltter";
            this.Size = new System.Drawing.Size(784, 342);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ctrPersonCardInfo ctrPersonCardInfo1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtTextForFilttering;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbFiltterColumn;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
