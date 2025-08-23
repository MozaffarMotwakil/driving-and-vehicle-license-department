using System;
using System.Windows.Forms;
using DVLD.BusinessLogic;
using DVLD.WinForms.Licenses;
using DVLD.WinForms.Users;
using DVLD.WinForms.Utils;

namespace DVLD.WinForms.Applications.DetainAndReleaseLicenses
{
    public partial class frmDetainLicense : Form
    {
        private clsLicense _CurrentLicense;
        private int _DetainID;

        public event Action DetainSuccess;
        protected virtual void OnDetainSuccess()
        {
            DetainSuccess?.Invoke();
        }

        public frmDetainLicense()
        {
            InitializeComponent();
            _CurrentLicense = null;
            ctrDriverLicenseInfoWithFilter.FoundLicense += _CtrDriverLicenseInfoWithFilter_FoundLicense;
            ctrDriverLicenseInfoWithFilter.NotFoundLicense += _CtrDriverLicenseInfoWithFilter_NotFoundLicense;
        }

        private void frmDetainLicense_Activated(object sender, EventArgs e)
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

            if (license.IsLicenseDetained())
            {
                clsFormMessages.ShowError("The sellected license is already detained");
                return;
            }

            if (!license.IsActive)
            {
                clsFormMessages.ShowError("The sellected license is not active.");
                return;
            }

            _CurrentLicense = license;
            _SetValuesAfterFoundValidLocalLicense();
        }

        private void _SetDefaultValuesToForm()
        {
            _CurrentLicense = null;
            _SetDefaultValuesForDatainLicenseInfoGroupBox();
            llShowLicensesHistory.Visible = gbDetainLicenseInfo.Visible = btnDetain.Enabled =
                txtFineFees.Enabled = false;
        }

        private void _SetValuesAfterFoundValidLocalLicense()
        {
            _SetValuesForDetainLicenseInfoGroupBox();
            llShowLicensesHistory.Visible = gbDetainLicenseInfo.Visible = btnDetain.Enabled =
                txtFineFees.Enabled = true;
        }

        private void _SetValuesForDetainLicenseInfoGroupBox()
        {
            lblDetainDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            llLicenseID.Text = _CurrentLicense.LicenseID.ToString();
            llCreatedByUsername.Text = clsAppSettings.CurrentUser.Username;
        }

        private void _SetDefaultValuesForDatainLicenseInfoGroupBox()
        {
            txtFineFees.Text = string.Empty;
            lblDetainDate.Text = "DD/MM/YYYY";
            lblDetainID.Text = "N/A";
            llCreatedByUsername.Text = llLicenseID.Text = "???";
        }

        private void txtFineFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsFormValidation.HandleNumericKeyPress(e, txtFineFees, errorProvider);
        }

        private void llShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPersonLicensesHistory personLicensesHistory = new frmPersonLicensesHistory(_CurrentLicense.DriverInfo.PersonInfo);
            personLicensesHistory.ShowDialog();
        }

        private void llLicenseID_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo licenseInfo = new frmShowLicenseInfo(_CurrentLicense);
            licenseInfo.ShowDialog();
        }

        private void llCreatedByUsername_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowUserInfo userInfo = new frmShowUserInfo(clsAppSettings.CurrentUser);
            userInfo.ShowEditPersonInformationLinke = false;
            userInfo.ShowDialog();
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFineFees.Text))
            {
                clsFormMessages.ShowError("You must enter fine fees.");
                return;
            }

            if (clsFormMessages.ConfirmSava())
            {
               _DetainID = _CurrentLicense.DetainLicense(float.Parse(txtFineFees.Text));

                if (_DetainID != -1)
                {
                    OnDetainSuccess();
                    _UpdateFormAfterRenewedLicense();
                    clsFormMessages.ShowSuccess($"The License Detained Successfuly With Detain ID[{_DetainID}]");
                }
                else
                {
                    _SetDefaultValuesToForm();
                    clsFormMessages.ShowError("Failed To Detain The Local License");
                }
            }
        }

        private void _UpdateFormAfterRenewedLicense()
        {
            btnDetain.Enabled = false;
            lblDetainID.Text = _DetainID.ToString();
            txtFineFees.Enabled = false;
            ctrDriverLicenseInfoWithFilter.LoadData(_CurrentLicense); // update data after detain license
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}