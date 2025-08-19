namespace DVLD.WinForms.BaseForms
{
    partial class frmBaseManageWithFilter
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
            this.txtFilterText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbFilterColumn = new System.Windows.Forms.ComboBox();
            this.btnAddNewRecord = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFilterText
            // 
            this.txtFilterText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtFilterText.Location = new System.Drawing.Point(228, 180);
            this.txtFilterText.Name = "txtFilterText";
            this.txtFilterText.Size = new System.Drawing.Size(200, 20);
            this.txtFilterText.TabIndex = 27;
            this.txtFilterText.TextChanged += new System.EventHandler(this.txtFilterText_TextChanged);
            this.txtFilterText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterText_KeyPress);
            this.txtFilterText.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmBaseManageWithFilter_MouseDown);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 19);
            this.label3.TabIndex = 26;
            this.label3.Text = "Filtter By:";
            this.label3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmBaseManageWithFilter_MouseDown);
            // 
            // cbFilterColumn
            // 
            this.cbFilterColumn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cbFilterColumn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterColumn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFilterColumn.FormattingEnabled = true;
            this.cbFilterColumn.Location = new System.Drawing.Point(93, 178);
            this.cbFilterColumn.Name = "cbFilterColumn";
            this.cbFilterColumn.Size = new System.Drawing.Size(129, 24);
            this.cbFilterColumn.TabIndex = 25;
            this.cbFilterColumn.SelectedIndexChanged += new System.EventHandler(this.cbFilterColumn_SelectedIndexChanged);
            this.cbFilterColumn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmBaseManageWithFilter_MouseDown);
            // 
            // btnAddNewRecord
            // 
            this.btnAddNewRecord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddNewRecord.BackgroundImage = global::DVLD.WinForms.Properties.Resources.add_icon_48;
            this.btnAddNewRecord.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAddNewRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewRecord.Location = new System.Drawing.Point(1124, 152);
            this.btnAddNewRecord.Name = "btnAddNewRecord";
            this.btnAddNewRecord.Size = new System.Drawing.Size(50, 50);
            this.btnAddNewRecord.TabIndex = 28;
            this.btnAddNewRecord.UseVisualStyleBackColor = true;
            this.btnAddNewRecord.Click += new System.EventHandler(this.btnAddNewRecord_Click);
            this.btnAddNewRecord.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmBaseManageWithFilter_MouseDown);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // frmBaseManageWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 561);
            this.Controls.Add(this.btnAddNewRecord);
            this.Controls.Add(this.txtFilterText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbFilterColumn);
            this.Name = "frmBaseManageWithFilter";
            this.Text = "Base Manage With Filter";
            this.Load += new System.EventHandler(this.frmBaseManageWithFilter_Load);
            this.Controls.SetChildIndex(this.cbFilterColumn, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtFilterText, 0);
            this.Controls.SetChildIndex(this.btnAddNewRecord, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFilterText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbFilterColumn;
        private System.Windows.Forms.Button btnAddNewRecord;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}