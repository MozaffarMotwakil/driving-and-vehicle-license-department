using System;
using System.Windows.Forms;
using DVLD.BusinessLogic;
using DVLD.WinForms.Utils;

namespace DVLD.WinForms.Applications.LocalLicense
{
    public partial class frmAddUpdateLocalLicenseApplication : Form
    {
        private clsLocalLicenseApplication _LocalLicenseApplication;
        private enMode _FormMode;

        public frmAddUpdateLocalLicenseApplication()
        {
            InitializeComponent();
            _LocalLicenseApplication = new clsLocalLicenseApplication();
            _FormMode = enMode.AddNew;
            btnNext.Enabled = btnSave.Enabled = false;
            ctrPersonCardInfoWithFiltter.PersonFound += CtrPersonCardInfoWithFiltter_PersonFound;
            ctrPersonCardInfoWithFiltter.PersonNotFound += CtrPersonCardInfoWithFiltter_PersonNotFound;
            ctrPersonCardInfoWithFiltter.AddNewPerson += CtrPersonCardInfoWithFiltter_AddNewPerson;
        }
        
        public frmAddUpdateLocalLicenseApplication(int LocalLicenseApplicationID)
        {
            InitializeComponent();
            _LocalLicenseApplication = clsLocalLicenseApplication.Find(LocalLicenseApplicationID);
            _FormMode = enMode.Update;
            btnNext.Enabled = btnSave.Enabled = true;
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

        private void frmAddUpdateLocalLicenseApplication_Load(object sender, EventArgs e)
        {
            clsFormHelper.SetLicenseClassesToComboBox(cbLicenseClass);

            if (_FormMode == enMode.AddNew)
            {
                this.Text = lblHeader.Text = "Add New Local License Application";
                lblApplicationDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                cbLicenseClass.SelectedIndex = 0;
                lblApplicationFees.Text = _LocalLicenseApplication.ApplicationInfo.TypeInfo.Fees.ToString();
                lblCreatedByUsername.Text = clsAppSettings.CurrentUser.Username;
                return;
            }

            if (_LocalLicenseApplication == null)
            {
                clsFormMessages.ShowError("Application not found.");
                this.Close();
                return;
            }

            this.Text = lblHeader.Text = "Update Local License Application";
            _FillApplicationInfoToUI();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            clsLocalLicenseApplication activeApplication = clsLocalLicenseApplication.GetActiveLocalLicenseApplication(
                ctrPersonCardInfoWithFiltter.Person.PersonID, cbLicenseClass.SelectedIndex + 1
                );

            if (activeApplication != null)
            {
                clsFormMessages.ShowError(
                    $"Please choose another license class, " +
                    $"the selected person already have an active application for the selected class." +
                    $"\n\nApplication Details:" +
                    $"\n- Application ID: {activeApplication.LocalLicenseApplicationID}" +
                    $"\n- Application Date: {activeApplication.ApplicationInfo.CreatedDate}"
                );

                return;
            }

            if (clsFormMessages.ConfirmSava())
            {
                if (!_FillApplicationInfoFromUI())
                {
                    clsFormMessages.ShowError("Create a new application failed, please try again.");
                    return;
                }

                if (_LocalLicenseApplication.Save())
                {
                    clsFormMessages.ShowSuccess("Saved Successfuly.");

                    if (_FormMode == enMode.AddNew)
                    {
                        _UpdateFormStateAfterSave();
                    }
                }
                else
                {
                    clsFormMessages.ShowError("Failed Save.");

                    if (!clsApplication.Delete(_LocalLicenseApplication.ApplicationInfo.ApplicationID))
                    {
                        clsFormMessages.ShowWarning("Failed to delete the base application, please delete it manual.");
                    }
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

        private bool _FillApplicationInfoFromUI()
        {
            int applicationID = clsApplication.CreateApplication(ctrPersonCardInfoWithFiltter.Person.PersonID, 
                clsApplication.enApplicationType.NewLocalDrivingLicenseService);

            if (applicationID == -1)
            {
                return false;
            }

            _LocalLicenseApplication.ApplicationInfo.ApplicationID = applicationID;
            _LocalLicenseApplication.LicenseClassInfo.LicenseClassID = cbLicenseClass.SelectedIndex + 1;
            return true;
        }

        private void _FillApplicationInfoToUI()
        {
            ctrPersonCardInfoWithFiltter.LoadPersonDataForEdit(_LocalLicenseApplication.ApplicationInfo.PersonInfo);
            lblApplicationID.Text = _LocalLicenseApplication.LocalLicenseApplicationID.ToString();
            lblApplicationDate.Text = _LocalLicenseApplication.ApplicationInfo.CreatedDate.ToString("dd/MM/yyyy");
            cbLicenseClass.SelectedIndex = _LocalLicenseApplication.LicenseClassInfo.LicenseClassID - 1;
            lblApplicationFees.Text = _LocalLicenseApplication.ApplicationInfo.PaidFees.ToString();
            lblCreatedByUsername.Text = _LocalLicenseApplication.ApplicationInfo.CreatedByUserInfo.Username;
        }

    }
}
