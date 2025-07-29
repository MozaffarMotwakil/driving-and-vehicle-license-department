using System;
using System.Drawing;
using System.Windows.Forms;
using DVLD.WinForms.People;
using DVLD.WinForms.Properties;

namespace DVLD.WinForms.MainForms
{
    public partial class frmMainForm : Form
    {
        enum enFormTypes { ManagePeople , ManageUsers}

        private Form _ManagePeopleForm;
        private Form _ManageUsersForm;

        public frmMainForm()
        {
            InitializeComponent();
            _ManagePeopleForm = null;
            _ManageUsersForm = null;

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
            _OpenForm(ref _ManagePeopleForm, enFormTypes.ManagePeople);
        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _OpenForm(ref _ManageUsersForm, enFormTypes.ManageUsers);
        }

        private void _OpenForm(ref Form form, enFormTypes FormType)
        {
            if (form == null || form.IsDisposed)
            {
                form = _GetFormObject(FormType);
                form.MdiParent = this;
                form.Show();
            }
            else
            {
                if (form.WindowState == FormWindowState.Minimized)
                {
                    form.WindowState = FormWindowState.Normal;
                }

                form.Activate();
            }
        }

        private Form _GetFormObject(enFormTypes FormType)
        {
            switch (FormType)
            {
                case enFormTypes.ManagePeople:
                    return new frmManagePeople();
                case enFormTypes.ManageUsers:
                    return new frmManageUsers();
                default:
                    return new Form();
            }
        }

    }
}
