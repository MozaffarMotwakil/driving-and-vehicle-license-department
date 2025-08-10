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
            this.components = new System.ComponentModel.Container();
            this.gbFiltter = new System.Windows.Forms.GroupBox();
            this.btnFindPerson = new System.Windows.Forms.Button();
            this.btnAddNewPerson = new System.Windows.Forms.Button();
            this.txtFilterText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbFilterColumn = new System.Windows.Forms.ComboBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.ctrPersonCardInfo = new DVLD.WinForms.People.ctrPersonCardInfo();
            this.gbFiltter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // gbFiltter
            // 
            this.gbFiltter.Controls.Add(this.btnFindPerson);
            this.gbFiltter.Controls.Add(this.btnAddNewPerson);
            this.gbFiltter.Controls.Add(this.txtFilterText);
            this.gbFiltter.Controls.Add(this.label3);
            this.gbFiltter.Controls.Add(this.cbFilterColumn);
            this.gbFiltter.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFiltter.Location = new System.Drawing.Point(3, -1);
            this.gbFiltter.Name = "gbFiltter";
            this.gbFiltter.Size = new System.Drawing.Size(772, 60);
            this.gbFiltter.TabIndex = 1;
            this.gbFiltter.TabStop = false;
            this.gbFiltter.Text = "Filtter";
            // 
            // btnFindPerson
            // 
            this.btnFindPerson.BackgroundImage = global::DVLD.WinForms.Properties.Resources.SearchPerson;
            this.btnFindPerson.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnFindPerson.Location = new System.Drawing.Point(457, 16);
            this.btnFindPerson.Name = "btnFindPerson";
            this.btnFindPerson.Size = new System.Drawing.Size(42, 38);
            this.btnFindPerson.TabIndex = 0;
            this.btnFindPerson.UseVisualStyleBackColor = true;
            this.btnFindPerson.Click += new System.EventHandler(this.btnFindPerson_Click);
            // 
            // btnAddNewPerson
            // 
            this.btnAddNewPerson.BackgroundImage = global::DVLD.WinForms.Properties.Resources.AddPerson_32;
            this.btnAddNewPerson.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAddNewPerson.Location = new System.Drawing.Point(504, 16);
            this.btnAddNewPerson.Name = "btnAddNewPerson";
            this.btnAddNewPerson.Size = new System.Drawing.Size(42, 38);
            this.btnAddNewPerson.TabIndex = 28;
            this.btnAddNewPerson.UseVisualStyleBackColor = true;
            this.btnAddNewPerson.Click += new System.EventHandler(this.btnAddNewPerson_Click);
            // 
            // txtFilterText
            // 
            this.txtFilterText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtFilterText.Location = new System.Drawing.Point(225, 29);
            this.txtFilterText.Name = "txtFilterText";
            this.txtFilterText.Size = new System.Drawing.Size(200, 23);
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
            this.label3.Location = new System.Drawing.Point(6, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 19);
            this.label3.TabIndex = 26;
            this.label3.Text = "Filtter By:";
            // 
            // cbFilterColumn
            // 
            this.cbFilterColumn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cbFilterColumn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterColumn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFilterColumn.FormattingEnabled = true;
            this.cbFilterColumn.Items.AddRange(new object[] {
            "Person ID",
            "National No"});
            this.cbFilterColumn.Location = new System.Drawing.Point(90, 28);
            this.cbFilterColumn.Name = "cbFilterColumn";
            this.cbFilterColumn.Size = new System.Drawing.Size(129, 24);
            this.cbFilterColumn.TabIndex = 25;
            this.cbFilterColumn.SelectedIndexChanged += new System.EventHandler(this.cbFiltterColumn_SelectedIndexChanged);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // ctrPersonCardInfo
            // 
            this.ctrPersonCardInfo.Location = new System.Drawing.Point(0, 57);
            this.ctrPersonCardInfo.Name = "ctrPersonCardInfo";
            this.ctrPersonCardInfo.Size = new System.Drawing.Size(780, 277);
            this.ctrPersonCardInfo.SuppressImageLoadWarning = false;
            this.ctrPersonCardInfo.TabIndex = 0;
            // 
            // ctrPersonCardInfoWithFiltter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbFiltter);
            this.Controls.Add(this.ctrPersonCardInfo);
            this.Name = "ctrPersonCardInfoWithFiltter";
            this.Size = new System.Drawing.Size(779, 342);
            this.Load += new System.EventHandler(this.ctrPersonCardInfoWithFiltter_Load);
            this.gbFiltter.ResumeLayout(false);
            this.gbFiltter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ctrPersonCardInfo ctrPersonCardInfo;
        private System.Windows.Forms.GroupBox gbFiltter;
        private System.Windows.Forms.TextBox txtFilterText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbFilterColumn;
        private System.Windows.Forms.Button btnAddNewPerson;
        private System.Windows.Forms.Button btnFindPerson;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}
