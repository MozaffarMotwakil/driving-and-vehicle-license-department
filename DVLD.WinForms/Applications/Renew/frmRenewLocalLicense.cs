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
            ctrDriverLicenseInfoWithFilter.FoundLicense += _CtrDriverLicenseInfoWithFilter_FoundLicense;
            ctrDriverLicenseInfoWithFilter.NotFoundLicense += _CtrDriverLicenseInfoWithFilter_NotFoundLicense;
        }

        private void frmRenewLocalLicense_Activated(object sender, EventArgs e)
        {
            ctrDriverLicenseInfoWithFilter.FocusOnFilterText();
        }

        private void _CtrDriverLicenseInfoWithFilter_NotFoundLicense()
        {
            _SetDefaultValuesToForm();
            clsFormMessages.ShowError("Local license not found.");
        }

        private void _CtrDriverLicenseInfoWithFilter_FoundLicense(clsLicense license)
        {
            _SetDefaultValuesToForm();

            if (!license.IsLicenseExpired())
            {
                clsFormMessages.ShowError(
                    $"The license is not yet expiration, it will expire on: {license.ExpirationDate:dd/MM/yyyy}."
                    );
                return;
            }

            if (clsLicense.IsPersonHasAnActiveLicense(license.DriverInfo.PersonInfo.PersonID, license.LicenseClassInfo.LicenseClassID))
            {
                clsLicense activeLicense = clsLicense.GetActiveLicenseForPerosn(
                    license.DriverInfo.PersonInfo.PersonID, license.LicenseClassInfo.LicenseClassID
                    );

                frmErrorPersonHaveAnActiveLicense error = new frmErrorPersonHaveAnActiveLicense(activeLicense);
                error.ShowDialog();
                return;
            }

            _OldLocalLicense = license;
            _SetValuesAfterFoundValidLocalLicense();
        }

        private void _SetDefaultValuesToForm()
        {
            _OldLocalLicense = null;
            _NewLocalLicense = null;
            _ClearValuesFromRenewLicenseApplicationGroupBox();
            llShowLicensesHistory.Visible = llShowRenewedLicenseInfo.Visible =
                gbRenewLicenseApplicationInfo.Visible = btnRenew.Enabled = false;
        }

        private void _SetValuesAfterFoundValidLocalLicense()
        {
            _SetValuesToRenewLicenseApplicationGroupBox();
            llShowLicensesHistory.Visible = gbRenewLicenseApplicationInfo.Visible =
                btnRenew.Enabled = true;
        }

        private void _SetValuesToRenewLicenseApplicationGroupBox()
        {
            llOldLocalLicenseID.Text = _OldLocalLicense.LicenseID.ToString();
            lblApplicationFees.Text = clsApplicationType.Get(clsApplication.enApplicationType.RenewDrivingLicenseService).Fees.ToString();
            lblLicenseFees.Text = _OldLocalLicense.LicenseClassInfo.ClassFees.ToString();
            lblTotalFees.Text = (float.Parse(lblApplicationFees.Text) + float.Parse(lblLicenseFees.Text)).ToString();
            llCreatedByUsername.Text = clsAppSettings.CurrentUser.Username;
            lblIssueDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lblExpirationDate.Text = DateTime.Now.AddYears(_OldLocalLicense.LicenseClassInfo.DefaultValidityLength).ToString("dd/MM/yyyy");
            txtNotes.Text = _OldLocalLicense.Notes;
        }

        private void _ClearValuesFromRenewLicenseApplicationGroupBox()
        {
            _OldLocalLicense = null;
            _NewLocalLicense = null;
            txtNotes.Text = string.Empty;
            lblIssueDate.Text = lblExpirationDate.Text = "DD/MM/YYYY";
            lblRenewedLicenseApplicationID.Text = lblRenewedLicenseID.Text = "N/A";
            llCreatedByUsername.Text = llOldLocalLicenseID.Text =  lblApplicationFees.Text = 
                lblLicenseFees.Text = lblTotalFees.Text = "???";
        }

        private void llShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPersonLicensesHistory personLicensesHistory = new frmPersonLicensesHistory(_OldLocalLicense.DriverInfo.PersonInfo);
            personLicensesHistory.ShowDialog();
        }

        private void llShowRenewedLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo licenseInfo = new frmShowLicenseInfo(_NewLocalLicense);
            licenseInfo.ShowDialog();
        }

        private void llOldLocalLicenseID_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
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
                _NewLocalLicense = _OldLocalLicense.Renew(txtNotes.Text);

                if (_NewLocalLicense != null)
                {
                    _UpdateFormAfterRenewedLicense();
                    clsFormMessages.ShowSuccess($"The License Renewed Successfuly With ID[{_NewLocalLicense.LicenseID}]");
                }
                else
                {
                    _SetDefaultValuesToForm();
                    clsFormMessages.ShowError("Failed To Renewed The Local License");
                }
            }
        }

        private void _UpdateFormAfterRenewedLicense()
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