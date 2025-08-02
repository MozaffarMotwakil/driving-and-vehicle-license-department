using System;
using System.ComponentModel;
using System.Windows.Forms;
using DVLD.BusinessLogic;
using DVLD.WinForms.Global;
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
            btnNext.Enabled = btnSave.Enabled =false;
            ctrPersonCardInfoWithFiltter.PersonFound += CtrPersonCardInfoWithFiltter_PersonFound;
            ctrPersonCardInfoWithFiltter.PersonNotFound += CtrPersonCardInfoWithFiltter_PersonNotFound;
        }

        public frmAddUpdateUser(int PersonID)
        {
            InitializeComponent();
            _User = clsUser.Find(PersonID);
            this.Text = lblHeader.Text = "Update User";
            _FormMode = enMode.Update;
            ctrPersonCardInfoWithFiltter.LoadPersonDataForDesplay(_User.PersonInfo);
        }

        private void frmAddUpdateUser_Load(object sender, EventArgs e)
        {
            pcShowPassword.Tag = txtPassword;
            pbShowConfirmPassword.Tag = txtConfirmPassword;

            if (_FormMode == enMode.Update)
            {
                if (_User == null)
                {
                    clsFormMessages.ShowUserNotFoundError();
                    this.Close();
                    return;
                }

                _FillUserInfoToUI();
            }
            
        }

        private void CtrPersonCardInfoWithFiltter_PersonFound()
        {
            btnNext.Enabled = true;
        }

        private void CtrPersonCardInfoWithFiltter_PersonNotFound()
        {
            btnNext.Enabled = btnSave.Enabled = false;
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = (tabControl.SelectedTab == tpLoginInfo);
        }

        private void tabControl_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (ctrPersonCardInfoWithFiltter.Person == null)
            {
                e.Cancel = true;
                clsFormMessages.ShowError("You must first select a person before moving on to the next step.");
                return;
            }

            if (tabControl.SelectedIndex == 1)
            {
                btnNext.PerformClick();
            }
        }

        private void txtUsername_Validating(object sender, CancelEventArgs e)
        {
            clsFormValidation.ValidatingRequiredField(sender as Control, "Username is required field.", errorProvider);

            if (!string.IsNullOrEmpty(txtUsername.Text))
            {
                if (txtUsername.Text != _User.Username && clsUser.IsUserExist(txtUsername.Text))
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
            if (_FormMode == enMode.AddNew)
            {
                clsFormValidation.ValidatingRequiredField(txtPassword, "Password is required field.", errorProvider);
            }

            clsFormValidation.ValidatingPassword(txtPassword, errorProvider);
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (_FormMode == enMode.AddNew)
            {
                clsFormValidation.ValidatingRequiredField(txtConfirmPassword, "Confirm password is required field.", errorProvider);
            }

            clsFormValidation.ValidatingConfirmPassword(txtPassword, txtConfirmPassword, errorProvider);
        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            clsFormValidation.ValidatingConfirmPassword(txtPassword, txtConfirmPassword, errorProvider);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!clsFormValidation.IsDataValid(this, tpLoginInfo.Controls, errorProvider))
            {
                clsFormMessages.ShowInvalidDataError();
                return;
            }

            if (ctrPersonCardInfoWithFiltter.Person != null)
            {
                _FillUserObjectFromUI();
            }
            else
            {
                clsFormMessages.ShowPersonNotFoundError();
                ctrPersonCardInfoWithFiltter.ClearPersonInfo();
                return;
            }

            if (clsFormMessages.ConfirmSava())
            {
                if (_User.Save())
                {
                    clsFormMessages.ShowSuccess("Saved successfully.");

                    if (_FormMode == enMode.AddNew)
                    {
                        _UpdateFormStateAfterSave();
                    }

                    IsSaveSuccess = true;
                    UserBack?.Invoke(_User);
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

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (clsUser.IsPersonHasUser(ctrPersonCardInfoWithFiltter.Person.PersonID) && _FormMode == enMode.AddNew)
            {
                clsFormMessages.ShowError("Selected person already has a user, choose another one.");
                return;
            }

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

            if (!string.IsNullOrEmpty(txtPassword.Text))
            {
                _User.SetPassword(txtPassword.Text);
            }

            _User.IsActive = cbIsActive.Checked;
        }

        private void _FillUserInfoToUI()
        {
            lblUserID.Text = _User.UserID.ToString();
            txtUsername.Text = _User.Username;
            cbIsActive.Checked = _User.IsActive;
        }

        private void cbShowPasswords_CheckedChanged(object sender, EventArgs e)
        {
            clsFormHelper.SetPasswordsVisibility(
                new TextBox[2] {txtPassword, txtConfirmPassword},
                cbShowPasswords.Checked
                );
        }

        private void pcShowPassword_MouseDown(object sender, MouseEventArgs e)
        {
            clsFormHelper.ShowPassword(sender, e);
        }

        private void pcShowPassword_MouseUp(object sender, MouseEventArgs e)
        {
            clsFormHelper.HidePassword(sender, e);
        }

        private void pbShowConfirmPassword_MouseDown(object sender, MouseEventArgs e)
        {
            clsFormHelper.ShowPassword(sender, e);
        }

        private void pbShowConfirmPassword_MouseUp(object sender, MouseEventArgs e)
        {
            clsFormHelper.HidePassword(sender, e);
        }

    }
}
