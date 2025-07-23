namespace DVLD.WinForms.MainForms
{
    partial class frmMainForm
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
            this.msMainScreen = new System.Windows.Forms.MenuStrip();
            this.appToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.peopleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.driversToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.msMainScreen.SuspendLayout();
            this.SuspendLayout();
            // 
            // msMainScreen
            // 
            this.msMainScreen.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.msMainScreen.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.appToolStripMenuItem,
            this.peopleToolStripMenuItem,
            this.driversToolStripMenuItem,
            this.userToolStripMenuItem,
            this.accoToolStripMenuItem});
            this.msMainScreen.Location = new System.Drawing.Point(0, 0);
            this.msMainScreen.Name = "msMainScreen";
            this.msMainScreen.Size = new System.Drawing.Size(1370, 72);
            this.msMainScreen.TabIndex = 0;
            this.msMainScreen.Text = "msMainScreen";
            // 
            // appToolStripMenuItem
            // 
            this.appToolStripMenuItem.Image = global::DVLD.WinForms.Properties.Resources.Applications_64;
            this.appToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.appToolStripMenuItem.Name = "appToolStripMenuItem";
            this.appToolStripMenuItem.Size = new System.Drawing.Size(192, 68);
            this.appToolStripMenuItem.Text = "Applications";
            // 
            // peopleToolStripMenuItem
            // 
            this.peopleToolStripMenuItem.Image = global::DVLD.WinForms.Properties.Resources.People_64;
            this.peopleToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.peopleToolStripMenuItem.Name = "peopleToolStripMenuItem";
            this.peopleToolStripMenuItem.Size = new System.Drawing.Size(145, 68);
            this.peopleToolStripMenuItem.Text = "People";
            this.peopleToolStripMenuItem.Click += new System.EventHandler(this.peopleToolStripMenuItem_Click);
            // 
            // driversToolStripMenuItem
            // 
            this.driversToolStripMenuItem.Image = global::DVLD.WinForms.Properties.Resources.Drivers_64;
            this.driversToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.driversToolStripMenuItem.Name = "driversToolStripMenuItem";
            this.driversToolStripMenuItem.Size = new System.Drawing.Size(147, 68);
            this.driversToolStripMenuItem.Text = "Drivers";
            // 
            // userToolStripMenuItem
            // 
            this.userToolStripMenuItem.Image = global::DVLD.WinForms.Properties.Resources.Users_2_64;
            this.userToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.userToolStripMenuItem.Name = "userToolStripMenuItem";
            this.userToolStripMenuItem.Size = new System.Drawing.Size(134, 68);
            this.userToolStripMenuItem.Text = "Users";
            // 
            // accoToolStripMenuItem
            // 
            this.accoToolStripMenuItem.Image = global::DVLD.WinForms.Properties.Resources.account_settings_64;
            this.accoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.accoToolStripMenuItem.Name = "accoToolStripMenuItem";
            this.accoToolStripMenuItem.Size = new System.Drawing.Size(229, 68);
            this.accoToolStripMenuItem.Text = "Account Settings";
            // 
            // frmMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.msMainScreen);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.msMainScreen;
            this.MaximizeBox = false;
            this.Name = "frmMainForm";
            this.Text = "Main";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.msMainScreen.ResumeLayout(false);
            this.msMainScreen.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msMainScreen;
        private System.Windows.Forms.ToolStripMenuItem appToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem peopleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem driversToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accoToolStripMenuItem;
    }
}

