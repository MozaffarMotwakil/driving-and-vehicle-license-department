using System;
using System.Windows.Forms;
using DVLD.BusinessLogic;
using DVLD.WinForms.Users;
using DVLD.WinForms.Utils;

namespace DVLD.WinForms.Applications.LocalLicense
{
    public partial class frmAddUpdateLocalLicenseApplication : Form
    {
        private clsLocalLicenseApplication _LocalLicenseApplication;
        private enMode _FormMode;

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

        public frmAddUpdateLocalLicenseApplication()
        {
            InitializeComponent();
            _LocalLicenseApplication = null;
            _FormMode = enMode.AddNew;
            ctrPersonCardInfoWithFiltter.PersonFound += CtrPersonCardInfoWithFiltter_PersonFound;
            ctrPersonCardInfoWithFiltter.PersonNotFound += CtrPersonCardInfoWithFiltter_PersonNotFound;
            ctrPersonCardInfoWithFiltter.AddNewPerson += CtrPersonCardInfoWithFiltter_AddNewPerson;
            ctrPersonCardInfoWithFiltter.InfoModifie += CtrPersonCardInfoWithFiltter_InfoModifie;
        }

        public frmAddUpdateLocalLicenseApplication(int LocalLicenseApplicationID)
        {
            InitializeComponent();
            _LocalLicenseApplication = clsLocalLicenseApplication.Find(LocalLicenseApplicationID);
            _FormMode = enMode.Update;
            ctrPersonCardInfoWithFiltter.InfoModifie += CtrPersonCardInfoWithFiltter_InfoModifie;
        }

        private void frmAddUpdateLocalLicenseApplication_Activated(object sender, EventArgs e)
        {
            ctrPersonCardInfoWithFiltter.FocusOnFilterText();
        }

        private void frmAddUpdateLocalLicenseApplication_Load(object sender, EventArgs e)
        {
            clsFormHelper.SetLicenseClassesToComboBox(cbLicenseClass);

            if (_FormMode == enMode.AddNew)
            {
                _SetDefaultValuesForAddNewModeToUI();
                return;
            }

            if (_LocalLicenseApplication == null)
            {
                clsFormMessages.ShowError("Application not found.");
                this.Close();
                return;
            }

            _SetDefaultValuesForUpdateModeToUI();
        }

        private void _SetDefaultValuesForAddNewModeToUI()
        {
            this.Text = lblHeader.Text = "Add New Local License Application";
            lblApplicationDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            btnNext.Enabled = btnSave.Enabled = false;
            cbLicenseClass.SelectedIndex = 0;
            lblApplicationFees.Text = clsApplicationType.Get(clsApplication.enApplicationType.NewLocalDrivingLicenseService).Fees.ToString();
            llCreatedByUsername.Text = clsAppSettings.CurrentUser.Username;
        }

        private void _SetDefaultValuesForUpdateModeToUI()
        {
            this.Text = lblHeader.Text = "Update Local License Application";
            _FillApplicationInfoToUI();
            tabControl.SelectedTab = tpApplicationInfo;
            btnNext.Enabled = btnSave.Enabled = true;
        }

        private void _FillApplicationInfoToUI()
        {
            ctrPersonCardInfoWithFiltter.LoadPersonDataForEdit(_LocalLicenseApplication.ApplicationInfo.PersonInfo);
            lblApplicationID.Text = _LocalLicenseApplication.LocalLicenseApplicationID.ToString();
            lblApplicationDate.Text = _LocalLicenseApplication.ApplicationInfo.CreatedDate.ToString("dd/MM/yyyy");
            cbLicenseClass.SelectedIndex = _LocalLicenseApplication.LicenseClassInfo.LicenseClassID - 1;
            lblApplicationFees.Text = _LocalLicenseApplication.ApplicationInfo.PaidFees.ToString();
            llCreatedByUsername.Text = _LocalLicenseApplication.ApplicationInfo.CreatedByUserInfo.Username;
        }

        private void CtrPersonCardInfoWithFiltter_InfoModifie()
        {
            OnPersonInfoModifie(); 
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
            btnSave.Enabled = (tabControl.SelectedTab == tpApplicationInfo) && ctrPersonCardInfoWithFiltter.Person != null;
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
                tabControl.SelectedTab = tpApplicationInfo;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tpApplicationInfo;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tpPersonalInfo;
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            clsLocalLicenseApplication activeApplication = clsLocalLicenseApplication.GetActiveLocalLicenseApplication(
                ctrPersonCardInfoWithFiltter.Person.PersonID, cbLicenseClass.SelectedIndex + 1
                );

            if (activeApplication != null)
            {
                frmErrorPersonHaveActiveApplication errorForm = new frmErrorPersonHaveActiveApplication(activeApplication);
                errorForm.ShowDialog();
                return;
            }

            if (clsLicense.IsPersonHasLicense(ctrPersonCardInfoWithFiltter.Person.PersonID, cbLicenseClass.SelectedIndex + 1))
            {
                clsFormMessages.ShowError("Person already have a license in this class, cannot issue a new license.");
                return;
            }

            if (clsFormMessages.ConfirmSava())
            {
                if (_FormMode == enMode.AddNew)
                {
                    _LocalLicenseApplication = new clsLocalLicenseApplication(
                    ctrPersonCardInfoWithFiltter.Person,
                    clsLicenseClass.Find(cbLicenseClass.SelectedIndex + 1)
                    );
                }
                else
                {
                    _LocalLicenseApplication.LicenseClassInfo = clsLicenseClass.Find(cbLicenseClass.SelectedIndex + 1);
                }

                if (_LocalLicenseApplication.Save())
                {
                    clsFormMessages.ShowSuccess("Saved Successfuly.");

                    if (_FormMode == enMode.AddNew)
                    {
                        _UpdateFormStateAfterSave();
                    }

                    OnSaveSuccess();
                }
                else
                {
                    clsFormMessages.ShowError("Failed Save.");
                }
            }
        }

        private void _UpdateFormStateAfterSave()
        {
            _FormMode = enMode.Update;
            this.Text = lblHeader.Text = "Update Local License Application";
            lblApplicationID.Text = _LocalLicenseApplication.LocalLicenseApplicationID.ToString();
            ctrPersonCardInfoWithFiltter.IsFilterEnabled = false;
        }

        private void llCreatedByUsername_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowUserInfo userInfo = new frmShowUserInfo(clsUser.Find(llCreatedByUsername.Text));
            userInfo.InfoModifie += OnPersonInfoModifie;
            userInfo.ShowDialog();
        }

    }
}
