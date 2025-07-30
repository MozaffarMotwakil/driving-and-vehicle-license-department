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
            ctrUserCardInfo.LoadUserDataForDesplay(_User);
        }

        private void txtCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            clsValidation.ValidatingRequiredField(txtCurrentPassword, "You must enter the current password.", errorProvider);

            if (!string.IsNullOrEmpty(txtCurrentPassword.Text))
            {
                if (txtCurrentPassword.Text != _User.Password)
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
            clsValidation.ValidatingPassword(txtNewPassword, errorProvider);
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            clsValidation.ValidatingConfirmPassword(txtNewPassword, txtConfirmPassword, errorProvider);
        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            clsValidation.ValidatingConfirmPassword(txtNewPassword, txtConfirmPassword, errorProvider);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!clsValidation.IsDataValid(this, this.Controls, errorProvider))
            {
                clsMessages.ShowInvalidDataError();
                return;
            }

            _User.Password = txtNewPassword.Text;

            if (clsMessages.ConfirmSava())
            {
                if (_User.Save())
                {
                    clsMessages.ShowSuccess("Password has been successfully changed.");
                    IsSaveSuccess = true;
                }
                else
                {
                    clsMessages.ShowError("Failed Save.");
                }
            }
        }

        private void btnCloseScreen_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
