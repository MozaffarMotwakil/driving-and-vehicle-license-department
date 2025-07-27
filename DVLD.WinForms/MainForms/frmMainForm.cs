using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using DVLD.WinForms.People;

namespace DVLD.WinForms.MainForms
{
    public partial class frmMainForm : Form
    {
        frmManagePeople managePeopleForm;

        public frmMainForm()
        {
            InitializeComponent();

            foreach (Control control in this.Controls)
            {
                if (control is MdiClient)
                {
                    control.BackColor = Color.White;
                }
            }
        }
        
        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (managePeopleForm == null || managePeopleForm.IsDisposed)
            {
                managePeopleForm = new frmManagePeople();
                managePeopleForm.MdiParent = this;
                managePeopleForm.Show();
                managePeopleForm.BringToFront();
                
            }
            else
            {
                if (managePeopleForm.WindowState == FormWindowState.Minimized)
                {
                    managePeopleForm.WindowState = FormWindowState.Normal;
                }

                managePeopleForm.Activate();
            }
        }

    }
}
