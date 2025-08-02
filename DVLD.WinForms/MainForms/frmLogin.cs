using System;
using System.Windows.Forms;
using DVLD.BusinessLogic;
using DVLD.WinForms.Global;
using DVLD.WinForms.Utils;

namespace DVLD.WinForms.MainForms
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            if (clsLoginManager.IsLoginInformationExist())
            {
                txtUsername.Text = clsLoginManager.GetSavedUsername();
                txtPassword.Text = clsLoginManager.GetSavedPassword();
                cbRememberMe.Checked = true;
            }

            pcShowPassword.Tag = txtPassword;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!clsFormValidation.IsDataValid(this, this.Controls, errorProvider))
            {
                clsFormMessages.ShowInvalidDataError();
                return;
            }

            clsUser user = clsUser.Find(txtUsername.Text);
            
            if (user == null)
            {
                clsFormMessages.ShowError("Invalid Username.");
                return;
            }

            if (!user.VerifyPassword(txtPassword.Text))
            {
                clsFormMessages.ShowError("Password is incorrect.");
                return;
            }

            if (!user.IsActive)
            {
                clsFormMessages.ShowError("Your account is deactivated. Please contact your administrator.");
                return;
            }

            clsAppSettings.CurrentUser = user;
            frmMainForm mainForm = new frmMainForm();
            mainForm.Show();
            this.Hide();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtUsername_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            clsFormValidation.ValidatingRequiredField(txtUsername, "Username must be entered.", errorProvider);
        }

        private void txtPassword_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            clsFormValidation.ValidatingRequiredField(txtPassword, "Password must be entered.", errorProvider);
        }

        private void frmLogin_VisibleChanged(object sender, EventArgs e)
        {
            // Ensure the logic is not executed during the initial launch when no user is logged in yet
            if (clsAppSettings.CurrentUser == null)
            {
                return;
            }

            if (cbRememberMe.Checked)
            {
                clsLoginManager.SaveLoginInformation(txtUsername.Text, txtPassword.Text);
            }
            else
            {
                clsLoginManager.DeleteLoginInformation();
                txtUsername.Text = string.Empty;
                txtPassword.Text = string.Empty;
            }
        }

        private void pcShowPassword_MouseDown(object sender, MouseEventArgs e)
        {
            clsFormHelper.ShowPassword(sender, e);
        }

        private void pcShowPassword_MouseUp(object sender, MouseEventArgs e)
        {
            clsFormHelper.HidePassword(sender, e);
        }
    }
}
