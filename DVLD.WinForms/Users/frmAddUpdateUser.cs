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

        public delegate void UserBackEventHandler(clsUser User);
        public event UserBackEventHandler UserBack;
        protected virtual void OnUserBack()
        {
            UserBack?.Invoke(_User);
        }

        public event Action SaveSuccess;
        protected virtual void OnSaveSuccess()
        {
            SaveSuccess?.Invoke();
        }

        public event Action PersonInfoModifie;
        protected virtual void OnPersonInfoModifie()
        {
            PersonInfoModifie?.Invoke();
        }

        public frmAddUpdateUser()
        {
            InitializeComponent();
            _User = new clsUser();
            this.Text = lblHeader.Text = "Add New User";
            _FormMode = enMode.AddNew;
            btnNext.Enabled = btnSave.Enabled =false;
            ctrPersonCardInfoWithFiltter.PersonFound += CtrPersonCardInfoWithFiltter_PersonFound;
            ctrPersonCardInfoWithFiltter.PersonNotFound += CtrPersonCardInfoWithFiltter_PersonNotFound;
            ctrPersonCardInfoWithFiltter.AddNewPerson += CtrPersonCardInfoWithFiltter_AddNewPerson;
            ctrPersonCardInfoWithFiltter.InfoModifie += CtrPersonCardInfoWithFiltter_InfoModifie;
        }

        private void CtrPersonCardInfoWithFiltter_InfoModifie()
        {
            OnPersonInfoModifie();
        }

        public frmAddUpdateUser(int PersonID)
        {
            InitializeComponent();
            _User = clsUser.Find(PersonID);
            this.Text = lblHeader.Text = "Update User";
            _FormMode = enMode.Update;
            ctrPersonCardInfoWithFiltter.LoadPersonDataForEdit(_User.PersonInfo);
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

        private void CtrPersonCardInfoWithFiltter_AddNewPerson()
        {
            btnNext.Enabled = true;
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = (tabControl.SelectedTab == tpLoginInfo) && ctrPersonCardInfoWithFiltter.Person != null;
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
                if (!_HandlePersonSelection())
                {
                    e.Cancel = true;
                }
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
                    clsFormMessages.ShowSuccess("Saved Successfully.");

                    if (_FormMode == enMode.AddNew)
                    {
                        _UpdateFormStateAfterSave();
                    }

                    if (_User.UserID == clsAppSettings.CurrentUser.UserID && clsLoginManager.IsLoginInformationExist())
                    {
                        clsLoginManager.UpdatedLoginInformation(_User.Username, txtPassword.Text);
                    }

                    OnUserBack();
                    OnSaveSuccess();
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
            if (_HandlePersonSelection())
            {
                tabControl.SelectedTab = tpLoginInfo;
            }
        }

        private bool _HandlePersonSelection()
        {
            if (_FormMode == enMode.AddNew)
            {
                if (clsUser.IsPersonHasUser(ctrPersonCardInfoWithFiltter.Person.PersonID))
                {
                    clsFormMessages.ShowError("Selected person already has a user, choose another one.");
                    return false;
                }
            }

            return true;
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
            ctrPersonCardInfoWithFiltter.IsFilterEnabled = false;
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
