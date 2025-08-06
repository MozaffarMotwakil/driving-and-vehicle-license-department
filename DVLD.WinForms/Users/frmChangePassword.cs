using System;
using System.ComponentModel;
using System.Windows.Forms;
using DVLD.BusinessLogic;
using DVLD.WinForms.Utils;

namespace DVLD.WinForms.Users
{
    public partial class frmChangePassword : Form
    {
        private clsUser _User;

        public bool IsSaveSuccess { get; private set; }

        public frmChangePassword(int UserID)
        {
            InitializeComponent();
            _User = clsUser.Find(UserID);
            IsSaveSuccess = false;
        }

        public frmChangePassword(clsUser User)
        {
            InitializeComponent();
            _User = User;
            IsSaveSuccess = false;
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            if (_User == null)
            {
                clsFormMessages.ShowUserNotFoundError();
                this.Close();
                return;
            }

            ctrUserCardInfo.LoadUserDataForDesplay(_User);
            pcShowCurrentPassword.Tag = txtCurrentPassword;
            pcShowNewPassword.Tag = txtNewPassword;
            pcShowConfirmPassword.Tag = txtConfirmPassword;
        }

        private void txtCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            clsFormValidation.ValidatingRequiredField(txtCurrentPassword, "You must enter the current password.", errorProvider);

            if (!string.IsNullOrEmpty(txtCurrentPassword.Text))
            {
                if (!_User.VerifyPassword(txtCurrentPassword.Text))
                {
                    errorProvider.SetError(txtCurrentPassword, "Password is wrong.");
                }
                else
                {
                    errorProvider.SetError(txtCurrentPassword, "");
                }
            }
        }

        private void txtNewPassword_Validating(object sender, CancelEventArgs e)
        {
            clsFormValidation.ValidatingRequiredField(txtNewPassword, "Confirm password is required field.", errorProvider);
            clsFormValidation.ValidatingPassword(txtNewPassword, errorProvider);
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            clsFormValidation.ValidatingRequiredField(txtConfirmPassword, "Confirm password is required field.", errorProvider);
            clsFormValidation.ValidatingConfirmPassword(txtNewPassword, txtConfirmPassword, errorProvider);
        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            clsFormValidation.ValidatingConfirmPassword(txtNewPassword, txtConfirmPassword, errorProvider);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!clsFormValidation.IsDataValid(this, this.Controls, errorProvider))
            {
                clsFormMessages.ShowInvalidDataError();
                return;
            }

            if (clsFormMessages.ConfirmSava())
            {
                if (_User.ChangePassword(txtNewPassword.Text))
                {
                    clsFormMessages.ShowSuccess("Password has been successfully changed.");
                    IsSaveSuccess = true;

                    if (_User.UserID == clsAppSettings.CurrentUser.UserID && clsLoginManager.IsLoginInformationExist())
                    {
                        clsLoginManager.UpdatedLoginInformation(_User.Username, txtNewPassword.Text);
                    }

                    _ClearPasswords();
                }
                else
                {
                    clsFormMessages.ShowError("Failed Save.");
                }
            }

        }

        private void btnCloseScreen_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbShowPasswords_CheckedChanged(object sender, EventArgs e)
        {
            clsFormHelper.SetPasswordsVisibility(
                new TextBox[3] { txtCurrentPassword, txtNewPassword, txtConfirmPassword }, 
                cbShowPasswords.Checked
                );
        }

        private void pcShowCurrentPassword_MouseDown(object sender, MouseEventArgs e)
        {
            clsFormHelper.ShowPassword(sender, e);
        }

        private void pcShowCurrentPassword_MouseUp(object sender, MouseEventArgs e)
        {
            clsFormHelper.HidePassword(sender, e);
        }

        private void pcShowNewPassword_MouseDown(object sender, MouseEventArgs e)
        {
            clsFormHelper.ShowPassword(sender, e);
        }

        private void pcShowNewPassword_MouseUp(object sender, MouseEventArgs e)
        {
            clsFormHelper.HidePassword(sender, e);
        }

        private void pcShowConfirmPassword_MouseDown(object sender, MouseEventArgs e)
        {
            clsFormHelper.ShowPassword(sender, e);
        }

        private void pcShowConfirmPassword_MouseUp(object sender, MouseEventArgs e)
        {
            clsFormHelper.HidePassword(sender, e);
        }

        private void _ClearPasswords()
        {
            txtCurrentPassword.Text = txtConfirmPassword.Text = txtNewPassword.Text =  string.Empty;
        }

    }
}
