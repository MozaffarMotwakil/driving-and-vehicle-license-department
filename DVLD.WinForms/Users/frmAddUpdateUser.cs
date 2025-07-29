using System;
using System.ComponentModel;
using System.Windows.Forms;
using DVLD.BusinessLogic;
using DVLD.WinForms.Utils;

namespace DVLD.WinForms.Users
{
    public partial class frmAddUpdateUser : Form
    {
        private clsUser _User;
        private enMode _FormMode;

        public bool IsSaveSuccess { get; private set; }

        public delegate void UserBackEventHandler(clsUser User);
        public event UserBackEventHandler UserBack;

        public frmAddUpdateUser()
        {
            InitializeComponent();
            _User = new clsUser();
            this.Text = lblHeader.Text = "Add New User";
            _FormMode = enMode.AddNew;
        }
        
        public frmAddUpdateUser(int PersonID)
        {
            InitializeComponent();
            _User = clsUser.Find(PersonID);
            this.Text = lblHeader.Text = "Update User";
            _FormMode = enMode.Update;
        }

        private void txtUsername_Validating(object sender, CancelEventArgs e)
        {
            clsValidation.ValidatingRequiredField(sender as Control, "Username is required field.", errorProvider);

            if (!string.IsNullOrEmpty(txtUsername.Text))
            {
                if (clsUser.IsUserExist(txtUsername.Text))
                {
                    errorProvider.SetError(txtUsername, "Username is already used by another one.");
                }
                else
                {
                    errorProvider.SetError(txtUsername, "");
                }
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            clsValidation.ValidatingRequiredField(sender as Control, "Password is required field.", errorProvider);

            if (!string.IsNullOrEmpty(txtPassword.Text))
            {
                if (string.IsNullOrEmpty(txtPassword.Text) || !clsValidation.IsValidPassword(txtPassword.Text))
                {
                    errorProvider.SetError(txtPassword, "Password must be at least 8 characters long, contain at least 4 numbers, one uppercase letter, and one lowercase letter.");
                }
                else
                {
                    errorProvider.SetError(txtPassword, "");
                }
            }
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            clsValidation.ValidatingRequiredField(sender as Control, "Confirm password is required field.", errorProvider);
        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtConfirmPassword.Text))
            {
                if (txtConfirmPassword.Text != txtPassword.Text)
                {
                    errorProvider.SetError(txtConfirmPassword, "Passwords do not match.");
                }
                else
                {
                    errorProvider.SetError(txtConfirmPassword, "");
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!clsValidation.IsDataValid(this, tpLoginInfo.Controls, errorProvider))
            {
                clsMessages.ShowInvalidDataError();
                return;
            }

            _FillUserObjectFromUI();

            if (clsMessages.ConfirmSava())
            {
                if (_User.Save())
                {
                    clsMessages.ShowSuccess("Saved successfully.");

                    if (_FormMode == enMode.AddNew)
                    {
                        _UpdateFormStateAfterSave();
                    }

                    IsSaveSuccess = true;
                    UserBack?.Invoke(_User);
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

        private void btnNext_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tpLoginInfo;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tpPersonalInfo;
        }

        private void _UpdateFormStateAfterSave()
        {
            _FormMode = enMode.Update;
            this.Text = lblHeader.Text = "Update User";
            lblUserID.Text = _User.UserID.ToString();
        }

        private void _FillUserObjectFromUI()
        {
            _User.PersonInfo = ctrPersonCardInfoWithFiltter.Person;
            _User.Username = txtUsername.Text;
            _User.Password = txtPassword.Text;
            _User.IsActive = cbIsActive.Checked;
        }

    }
}
