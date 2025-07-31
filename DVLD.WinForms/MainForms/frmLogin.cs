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
            if (clsAppSettings.IsLoginInformationExist())
            {
                txtUsername.Text = clsAppSettings.GetSavedUsername();
                txtPassword.Text = clsAppSettings.GetSavedPassword();
                cbRememberMe.Checked = true;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!clsValidation.IsDataValid(this, this.Controls, errorProvider))
            {
                clsMessages.ShowInvalidDataError();
                return;
            }

            clsUser user = clsUser.Find(txtUsername.Text);
            
            if (user == null)
            {
                clsMessages.ShowError("Invalid Username.");
                return;
            }

            if (txtPassword.Text != user.Password)
            {
                clsMessages.ShowError("Password is incorrect.");
                return;
            }

            if (!user.IsActive)
            {
                clsMessages.ShowError("Your account is deactivated. Please contact your administrator.");
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
            clsValidation.ValidatingRequiredField(txtUsername, "Username must be entered.", errorProvider);
        }

        private void txtPassword_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            clsValidation.ValidatingRequiredField(txtPassword, "Password must be entered.", errorProvider);
        }

        private void cbShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !cbShowPassword.Checked;
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
                clsAppSettings.SaveLoginInformation(clsAppSettings.CurrentUser.Username, clsAppSettings.CurrentUser.Password);
            }
            else
            {
                clsAppSettings.DeleteLoginInformation();
                txtUsername.Text = string.Empty;
                txtPassword.Text = string.Empty;
            }
        }
    }
}
