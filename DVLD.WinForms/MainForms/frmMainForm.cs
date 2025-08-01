﻿using System;
using System.Drawing;
using System.Windows.Forms;
using DVLD.WinForms.Global;
using DVLD.WinForms.People;
using DVLD.WinForms.Users;

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

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowUserInfo userInfo = new frmShowUserInfo(clsAppSettings.CurrentUser);
            userInfo.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword changePassword = new frmChangePassword(clsAppSettings.CurrentUser);
            changePassword.ShowDialog();
        }

        private void sginOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Application.OpenForms["frmLogin"].Show();
        }

        private void frmMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Because we used frmLogin.Hide(), the login form is still running but hidden.
            // If we don’t close it manually, it will keep running in the background even after the main form is closed.
            // This might cause problems, like not being able to open the app again because part of it is still running.
            Application.OpenForms["frmLogin"].Close();
        }

    }
}
