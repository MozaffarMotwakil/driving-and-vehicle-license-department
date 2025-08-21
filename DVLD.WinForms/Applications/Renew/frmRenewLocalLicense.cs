using System;
using System.Windows.Forms;
using DVLD.BusinessLogic;
using DVLD.WinForms.Licenses;
using DVLD.WinForms.Users;
using DVLD.WinForms.Utils;

namespace DVLD.WinForms.Applications.Renew
{
    public partial class frmRenewLocalLicense : Form
    {
        private clsLicense _OldLocalLicense;
        private clsLicense _NewLocalLicense;

        public frmRenewLocalLicense()
        {
            InitializeComponent();
            _OldLocalLicense = null;
            _NewLocalLicense = null;
            ctrDriverLicenseInfoWithFilter.FoundLicense += CtrDriverLicenseInfoWithFilter_FoundLicense;
            ctrDriverLicenseInfoWithFilter.NotFoundLicense += CtrDriverLicenseInfoWithFilter_NotFoundLicense;
        }

        private void frmRenewLocalLicense_Activated(object sender, EventArgs e)
        {
            ctrDriverLicenseInfoWithFilter.FocusOnFilterText();
        }

        private void CtrDriverLicenseInfoWithFilter_NotFoundLicense()
        {
            _SetDefaultValuesToForm();
            clsFormMessages.ShowError("Local license not found.");
        }

        private void CtrDriverLicenseInfoWithFilter_FoundLicense()
        {
            _SetDefaultValuesToForm();

            if (ctrDriverLicenseInfoWithFilter.License.ExpirationDate > DateTime.Now)
            {
                clsFormMessages.ShowError(
                    $"The license is not yet expiration, it will expire on: {ctrDriverLicenseInfoWithFilter.License.ExpirationDate.ToString("dd/MM/yyyy")}."
                    );
                return;
            }

            clsLicense activeLicense = clsLicense.GetActiveLicenseForPerosn(
                ctrDriverLicenseInfoWithFilter.License.DriverInfo.PersonInfo.PersonID,
                ctrDriverLicenseInfoWithFilter.License.LicenseClassInfo.LicenseClassID
                );

            if (activeLicense != null)
            {
                frmErrorPersonHaveAnActiveLicense error = new frmErrorPersonHaveAnActiveLicense(activeLicense);
                error.ShowDialog();
                return;
            }

            _OldLocalLicense = ctrDriverLicenseInfoWithFilter.License;
            _SetValuesAfterFoundValidLocalLicense();
        }

        private void _SetDefaultValuesToForm()
        {
            _OldLocalLicense = null;
            _NewLocalLicense = null;
            ClearValuesFromRenewLicenseApplicationGroupBox();
            llShowLicensesHistory.Visible = llShowRenewedLicenseInfo.Visible =
                gbRenewLicenseApplicationInfo.Visible = btnRenew.Enabled = false;
        }

        private void _SetValuesAfterFoundValidLocalLicense()
        {
            SetValuesToRenewLicenseApplicationGroupBox();
            llShowLicensesHistory.Visible = gbRenewLicenseApplicationInfo.Visible =
                btnRenew.Enabled = true;
        }

        public void SetValuesToRenewLicenseApplicationGroupBox()
        {
            llOldLocalLicenseID.Text = _OldLocalLicense.LicenseID.ToString();
            lblApplicationFees.Text = clsApplicationType.Get(clsApplication.enApplicationType.RenewDrivingLicenseService).Fees.ToString();
            lblLicenseFees.Text = _OldLocalLicense.LicenseClassInfo.ClassFees.ToString();
            lblTotalFees.Text = (float.Parse(lblApplicationFees.Text) + float.Parse(lblLicenseFees.Text)).ToString();
            llCreatedByUsername.Text = clsAppSettings.CurrentUser.Username;
            lblIssueDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lblExpirationDate.Text = DateTime.Now.AddYears(_OldLocalLicense.LicenseClassInfo.DefaultValidityLength).ToString("dd/MM/yyyy");
        }

        public void ClearValuesFromRenewLicenseApplicationGroupBox()
        {
            _OldLocalLicense = null;
            _NewLocalLicense = null;
            lblRenewedLicenseApplicationID.Text = lblRenewedLicenseID.Text = llCreatedByUsername.Text = 
                llOldLocalLicenseID.Text =  lblApplicationFees.Text  = lblLicenseFees.Text = lblTotalFees.Text = "???";
            txtNotes.Text = string.Empty;
            lblIssueDate.Text = lblExpirationDate.Text = "DD/MM/YYYY";
        }

        private void llShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_OldLocalLicense == null)
            {
                return;
            }

            frmPersonLicensesHistory personLicensesHistory = new frmPersonLicensesHistory(_OldLocalLicense.DriverInfo.PersonInfo);
            personLicensesHistory.ShowDialog();
        }

        private void llShowRenewedLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_NewLocalLicense == null)
            {
                return;
            }

            frmShowLicenseInfo licenseInfo = new frmShowLicenseInfo(_NewLocalLicense);
            licenseInfo.ShowDialog();
        }

        private void llOldLocalLicenseID_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_OldLocalLicense == null)
            {
                return;
            }

            frmShowLicenseInfo licenseInfo = new frmShowLicenseInfo(_OldLocalLicense);
            licenseInfo.ShowDialog();
        }

        private void llCreatedByUsername_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowUserInfo userInfo = new frmShowUserInfo(clsAppSettings.CurrentUser);
            userInfo.ShowEditPersonInformationLinke = false;
            userInfo.ShowDialog();
        }

        private void btnRenew_Click(object sender, EventArgs e)
        {
            if (clsFormMessages.ConfirmSava())
            {
                int newLicenseID = _OldLocalLicense.Renew(txtNotes.Text);

                if (newLicenseID != -1)
                {
                    _NewLocalLicense = clsLicense.FindByLicenseID(newLicenseID);
                    _UpdateFormAfterIssueAnInternationalLicense();
                    clsFormMessages.ShowSuccess($"The License Renewed Successfuly With ID[{newLicenseID}]");
                }
                else
                {
                    clsFormMessages.ShowError("Failed To Renewed The Local License");
                }
            }
        }

        private void _UpdateFormAfterIssueAnInternationalLicense()
        {
            btnRenew.Enabled = false;
            llShowRenewedLicenseInfo.Visible = true;
            lblRenewedLicenseApplicationID.Text = _NewLocalLicense.ApplicationInfo.ApplicationID.ToString();
            lblRenewedLicenseID.Text = _NewLocalLicense.LicenseID.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
