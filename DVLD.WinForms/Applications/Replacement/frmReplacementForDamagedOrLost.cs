using System;
using System.Windows.Forms;
using DVLD.BusinessLogic;
using DVLD.WinForms.Licenses;
using DVLD.WinForms.Users;
using DVLD.WinForms.Utils;

namespace DVLD.WinForms.Applications.Replacement
{
    public partial class frmReplacementForDamagedOrLost : Form
    {
        private clsLicense _OldLocalLicense;
        private clsLicense _NewLocalLicense;

        public frmReplacementForDamagedOrLost()
        {
            InitializeComponent();
            _OldLocalLicense = null;
            _NewLocalLicense = null;
            ctrDriverLicenseInfoWithFilter.FoundLicense += _CtrDriverLicenseInfoWithFilter_FoundLicense;
            ctrDriverLicenseInfoWithFilter.NotFoundLicense += _CtrDriverLicenseInfoWithFilter_NotFoundLicense;
        }

        private void frmReplacementForDamagedOrLost_Load(object sender, EventArgs e)
        {
            rbDamaged.Checked = true;
        }

        private void rbDamaged_CheckedChanged(object sender, EventArgs e)
        {
            this.Text = lblFormTitle.Text = "Replacement License For Damaged";
            lblApplicationFees.Text = clsApplicationType.Get(clsApplication.enApplicationType.ReplacementForDamagedDrivingLicense).Fees.ToString();
        }

        private void rbLost_CheckedChanged(object sender, EventArgs e)
        {
            this.Text = lblFormTitle.Text = "Replacement License For Lost";
            lblApplicationFees.Text = clsApplicationType.Get(clsApplication.enApplicationType.ReplacementForLostDrivingLicense).Fees.ToString();
        }

        private void frmReplacementForDamagedOrLost_Activated(object sender, EventArgs e)
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

            if (!license.IsActive)
            {
                clsFormMessages.ShowError("Selected license is not active.");
                return;
            }
            else if (license.IsLicenseExpired())
            {
                clsFormMessages.ShowError("Selected license is not valid, please renew this license.");
                return;
            }

            _OldLocalLicense = license;
            _SetValuesAfterFoundValidLocalLicense();
        }

        private void _SetDefaultValuesToForm()
        {
            _OldLocalLicense = null;
            _NewLocalLicense = null;
            rbDamaged.Checked = true;
            gbReplacementFor.Enabled = true;
            _ClearValuesFromRenewLicenseApplicationGroupBox();
            llShowLicensesHistory.Visible = llShowReplacementLicenseInfo.Visible =
                gbReplacementLicenseApplicationInfo.Visible = btnReplacement.Enabled = false;
        }

        private void _SetValuesAfterFoundValidLocalLicense()
        {
            _SetValuesToRenewLicenseApplicationGroupBox();
            llShowLicensesHistory.Visible = gbReplacementLicenseApplicationInfo.Visible =
                btnReplacement.Enabled = true;
        }

        private void _SetValuesToRenewLicenseApplicationGroupBox()
        {
            lblApplicationDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtNotes.Text = _OldLocalLicense.Notes;
            llOldLocalLicenseID.Text = _OldLocalLicense.LicenseID.ToString();
            llCreatedByUsername.Text = clsAppSettings.CurrentUser.Username;
            lblApplicationFees.Text = clsApplicationType.Get(GetSellectedApplicationType()).Fees.ToString();
        }

        private void _ClearValuesFromRenewLicenseApplicationGroupBox()
        {
            _OldLocalLicense = null;
            _NewLocalLicense = null;
            txtNotes.Text = string.Empty;
            lblApplicationDate.Text = "DD/MM/YYYY";
            lblReplacementLicenseApplicationID.Text = lblReplacementLicenseID.Text = "N/A";
            llCreatedByUsername.Text = llOldLocalLicenseID.Text = lblApplicationFees.Text = "???";
        }

        private void llShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPersonLicensesHistory personLicensesHistory = new frmPersonLicensesHistory(_OldLocalLicense.DriverInfo.PersonInfo);
            personLicensesHistory.ShowDialog();
        }

        private void llShowReplacementLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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

        private void btnReplacement_Click(object sender, EventArgs e)
        {
            if (clsFormMessages.ConfirmSava())
            {
                _NewLocalLicense = _OldLocalLicense.Replacement(_GetSellectedIssueReason(), txtNotes.Text);

                if (_NewLocalLicense != null)
                {
                    _UpdateFormAfterReplacementLicense();
                    clsFormMessages.ShowSuccess($"The License Replacement Successfuly With ID[{_NewLocalLicense.LicenseID}]");
                }
                else
                {
                    _SetDefaultValuesToForm();
                    clsFormMessages.ShowError("Failed To Replacement The Local License");
                }
            }
        }

        private void _UpdateFormAfterReplacementLicense()
        {
            btnReplacement.Enabled = gbReplacementFor.Enabled = false;
            llShowReplacementLicenseInfo.Visible = true;
            lblReplacementLicenseApplicationID.Text = _NewLocalLicense.ApplicationInfo.ApplicationID.ToString();
            lblReplacementLicenseID.Text = _NewLocalLicense.LicenseID.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private clsLicense.enIssueReason _GetSellectedIssueReason()
        {
            return rbDamaged.Checked ?
                clsLicense.enIssueReason.ReplacementForDamaged : 
                clsLicense.enIssueReason.ReplacementForLost;
        }

        private clsApplication.enApplicationType GetSellectedApplicationType()
        {
            return rbDamaged.Checked ?
                clsApplication.enApplicationType.ReplacementForDamagedDrivingLicense :
                clsApplication.enApplicationType.ReplacementForLostDrivingLicense;
        }

    }
}
