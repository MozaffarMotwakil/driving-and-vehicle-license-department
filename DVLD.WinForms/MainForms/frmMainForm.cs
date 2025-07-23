using System;
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
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (managePeopleForm == null || managePeopleForm.IsDisposed)
            {
                managePeopleForm = new frmManagePeople();
                managePeopleForm.MdiParent = this;
                managePeopleForm.Show();
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
