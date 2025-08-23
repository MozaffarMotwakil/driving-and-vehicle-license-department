using System;
using System.Drawing;
using System.Windows.Forms;
using DVLD.BusinessLogic;
using DVLD.WinForms.Applications;
using DVLD.WinForms.Applications.DetainAndReleaseLicenses;
using DVLD.WinForms.Applications.InternationalLicense;
using DVLD.WinForms.Applications.LocalLicense;
using DVLD.WinForms.Applications.Renew;
using DVLD.WinForms.Applications.Replacement;
using DVLD.WinForms.Drivers;
using DVLD.WinForms.People;
using DVLD.WinForms.Tests;
using DVLD.WinForms.Users;

namespace DVLD.WinForms.MainForms
{
    public partial class frmMainForm : Form
    {
        enum enFormTypes
        { 
            ManagePeople,
            ManageUsers,
            ManageDrivers,
            ManageLocalLicenseApplications, 
            ManageInternationalLicenses,
            ManageDetainedLicenses
        }

        private bool _IsSignOut;
        private Form _ManagePeople;
        private Form _ManageUsers;
        private Form _ManageDrivers;
        private Form _ManageInternationalLicenses;
        private Form _ManageLocalLicenseApplications;
        private Form _ManageDetainedLicenses;

        public frmMainForm()
        {
            InitializeComponent();
            _IsSignOut = false;
            _ManagePeople = null;
            _ManageUsers = null;
            _ManageLocalLicenseApplications = null;
            _ManageDetainedLicenses = null;

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
            _OpenForm(ref _ManagePeople, enFormTypes.ManagePeople);
        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _OpenForm(ref _ManageUsers, enFormTypes.ManageUsers);
        }

        private void localDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _OpenForm(ref _ManageLocalLicenseApplications, enFormTypes.ManageLocalLicenseApplications);
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
                case enFormTypes.ManageLocalLicenseApplications:
                    return new frmManageLocalLicenseApplications();
                case enFormTypes.ManageDrivers:
                    return new frmManageDrivers();
                case enFormTypes.ManageInternationalLicenses:
                    return new frmManageInternationalLicenses();
                case enFormTypes.ManageDetainedLicenses:
                    return new frmManageDetainedLicenses();
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
            _IsSignOut = true;
            clsAppSettings.CurrentUser = null;
            Application.OpenForms["frmLogin"].Show();
            this.Close();
        }

        private void manageAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageApplicationTypes applicationTypes = new frmManageApplicationTypes();
            applicationTypes.ShowDialog();
        }

        private void manageTestsTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageTestTypes manageTestTypes = new frmManageTestTypes();
            manageTestTypes.ShowDialog();
        }

        private void frmMainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Because we used frmLogin.Hide(), the login form is still running but hidden.
            // If we don’t close it manually, it will keep running in the background even after the main form is closed.
            // This might cause problems, like not being able to open the app again because part of it is still running.
            if (!_IsSignOut)
            {
                Application.OpenForms["frmLogin"].Close();
            }
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateLocalLicenseApplication addLocalLicenseApplication = new frmAddUpdateLocalLicenseApplication();
            addLocalLicenseApplication.ShowDialog();
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _OpenForm(ref _ManageDrivers, enFormTypes.ManageDrivers);
        }

        private void retakeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _OpenForm(ref _ManageLocalLicenseApplications, enFormTypes.ManageLocalLicenseApplications);
        }

        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIsuueInternationalLicense isuueInternationalLicense = new frmIsuueInternationalLicense();
            isuueInternationalLicense.ShowDialog();
        }

        private void internationalDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _OpenForm(ref _ManageInternationalLicenses, enFormTypes.ManageInternationalLicenses);
        }

        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRenewLocalLicense renewLocalLicense = new frmRenewLocalLicense();
            renewLocalLicense.ShowDialog();
        }

        private void replacementForLostOrDamagedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReplacementForDamagedOrLost replacementForDamagedOrLost = new frmReplacementForDamagedOrLost();
            replacementForDamagedOrLost.ShowDialog();
        }

        private void manageDetainedLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _OpenForm(ref _ManageDetainedLicenses, enFormTypes.ManageDetainedLicenses);
        }

        private void detainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDetainLicense detainLicense = new frmDetainLicense();
            detainLicense.ShowDialog();
        }

        private void releaseDetainedDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicense releaseDetainedLicense = new frmReleaseDetainedLicense();
            releaseDetainedLicense.ShowDialog();
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicense releaseDetainedLicense = new frmReleaseDetainedLicense();
            releaseDetainedLicense.ShowDialog();
        }

    }
}