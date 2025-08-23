using System;
using System.Windows.Forms;
using DVLD.BusinessLogic;
using DVLD.WinForms.Licenses;
using DVLD.WinForms.Users;
using DVLD.WinForms.Utils;

namespace DVLD.WinForms.Applications.DetainAndReleaseLicenses
{

    public partial class frmReleaseDetainedLicense : Form
    {
        private clsDetainedLicense _DetainedLicense;
        private int _ReleaseApplicationID;
        private int _SelectedLicenseID;

        public event Action ReleaseSuccess;
        protected virtual void OnReleaseSuccess()
        {
            ReleaseSuccess?.Invoke();
        }

        public frmReleaseDetainedLicense()
        {
            InitializeComponent();
            _DetainedLicense = null;
            ctrDriverLicenseInfoWithFilter.FoundLicense += _CtrDriverLicenseInfoWithFilter_FoundLicense;
            ctrDriverLicenseInfoWithFilter.NotFoundLicense += _CtrDriverLicenseInfoWithFilter_NotFoundLicense;
        }

        public frmReleaseDetainedLicense(int licenseID) : this()
        {
            ctrDriverLicenseInfoWithFilter.EnableSearch = false;
            _SelectedLicenseID = licenseID;
        }

        private void frmReleaseDetainedLicense_Load(object sender, EventArgs e)
        {
            if (!ctrDriverLicenseInfoWithFilter.EnableSearch)
            {
                ctrDriverLicenseInfoWithFilter.PerformSearch(_SelectedLicenseID);
            }
        }

        private void frmReleaseDetainedLicense_Activated(object sender, EventArgs e)
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

            if (!license.IsLicenseDetained())
            {
                clsFormMessages.ShowError("The selected license is not detained");
                return;
            }

            if (!license.IsActive)
            {
                clsFormMessages.ShowError("The selected license is not active.");
                return;
            }

            _DetainedLicense = clsDetainedLicense.Find(license.LicenseID);
            _SetValuesAfterFoundValidLocalLicense();
        }

        private void _SetDefaultValuesToForm()
        {
            _DetainedLicense = null;
            _SetDefaultValuesForDatainLicenseInfoGroupBox();
            llShowLicensesHistory.Visible = gbReleaseApplicationInfo.Visible = btnRelease.Enabled = false;
        }

        private void _SetValuesAfterFoundValidLocalLicense()
        {
            _SetValuesForReleaseApplicationInfoGroupBox();
            llShowLicensesHistory.Visible = gbReleaseApplicationInfo.Visible = btnRelease.Enabled = true;
        }

        private void _SetValuesForReleaseApplicationInfoGroupBox()
        {
            lblApplicationFees.Text = clsApplicationType.Get(
                clsApplication.enApplicationType.ReleaseDetainedDrivingLicence
                ).Fees.ToString();
            lblFineFees.Text = _DetainedLicense.FineFees.ToString();
            lblTotalFees.Text = (float.Parse(lblApplicationFees.Text) + float.Parse(lblFineFees.Text)).ToString();
            lblDetainID.Text = _DetainedLicense.DetainID.ToString();
            lblDetainDate.Text = _DetainedLicense.DetainDate.ToString("dd/MM/yyyy");
            llLicenseID.Text = _DetainedLicense.LicenseInfo.LicenseID.ToString();
            llCreatedByUsername.Text = _DetainedLicense.CreatedByUserInfo.Username;
        }

        private void _SetDefaultValuesForDatainLicenseInfoGroupBox()
        {
            lblDetainDate.Text = "DD/MM/YYYY";
            lblReleaseApplicationID.Text = lblDetainID.Text = "N/A";
            lblApplicationFees.Text = lblFineFees.Text = lblTotalFees.Text =
                llCreatedByUsername.Text = llLicenseID.Text = "???";
        }

        private void llShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPersonLicensesHistory personLicensesHistory = new frmPersonLicensesHistory(_DetainedLicense.LicenseInfo.DriverInfo.PersonInfo);
            personLicensesHistory.ShowDialog();
        }

        private void llLicenseID_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo licenseInfo = new frmShowLicenseInfo(_DetainedLicense.LicenseInfo);
            licenseInfo.ShowDialog();
        }

        private void llCreatedByUsername_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowUserInfo userInfo = new frmShowUserInfo(_DetainedLicense.CreatedByUserInfo);
            userInfo.ShowEditPersonInformationLinke = false;
            userInfo.ShowDialog();
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            if (clsFormMessages.ConfirmSava())
            {
                _ReleaseApplicationID = _DetainedLicense.LicenseInfo.ReleaseLicense();

                if (_ReleaseApplicationID != -1)
                {
                    OnReleaseSuccess();
                    _UpdateFormAfterRenewedLicense();
                    clsFormMessages.ShowSuccess($"The License Released Successfuly.");
                }
                else
                {
                    _SetDefaultValuesToForm();
                    clsFormMessages.ShowError("Failed To Released The Local License");
                }
            }
        }

        private void _UpdateFormAfterRenewedLicense()
        {
            btnRelease.Enabled = false;
            lblReleaseApplicationID.Text = _ReleaseApplicationID.ToString();
            ctrDriverLicenseInfoWithFilter.LoadData(_DetainedLicense.LicenseInfo); // update data after released license
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}