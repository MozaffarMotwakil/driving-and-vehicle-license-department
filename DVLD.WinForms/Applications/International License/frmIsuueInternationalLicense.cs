using System;
using System.Windows.Forms;
using DVLD.BusinessLogic;
using DVLD.WinForms.Licenses;
using DVLD.WinForms.Users;
using DVLD.WinForms.Utils;

namespace DVLD.WinForms.Applications.InternationalLicense
{
    public partial class frmIsuueInternationalLicense : Form
    {
        private clsInternationalLicense _InternationalLicense { get; set; }

        public frmIsuueInternationalLicense()
        {
            InitializeComponent();
            _InternationalLicense = null;
            ctrDriverLicenseInfoWithFilter.FoundLicense += _CtrDriverLicenseInfoWithFilter_FoundLicense;
            ctrDriverLicenseInfoWithFilter.NotFoundLicense += _CtrDriverLicenseInfoWithFilter_NotFoundLicense;
        }

        private void frmIsuueInternationalLicense_Activated(object sender, EventArgs e)
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

            try
            {
                _InternationalLicense = new clsInternationalLicense(license);
                _SetValuesAfterFoundValidLocalLicense();
            }
            catch (Exception ex)
            {
                if (clsInternationalLicense.IsPersonHasAnActiveInternationalLicense(license.DriverInfo.PersonInfo.PersonID))
                {
                    clsInternationalLicense activeInternationaLicense = 
                        clsInternationalLicense.GetActiveInternationalLicenseForPerson(license.DriverInfo.PersonInfo.PersonID);

                    frmErrorPerosnHaveAnActiveInternationalLicense error = new frmErrorPerosnHaveAnActiveInternationalLicense(activeInternationaLicense);
                    error.ShowDialog();
                }
                else
                {
                    clsFormMessages.ShowError(ex.Message);
                }
            }
        }

        private void _SetDefaultValuesToForm()
        {
            _InternationalLicense = null;
            _ClearValuesFromInternationalLicenseGroupBox();
            llShowLicensesHistory.Visible = llShowInternationalLicenseInfo.Visible =
                gbInternationalLicenseApplicationInfo.Visible = btnIssue.Enabled = false;
        }

        private void _SetValuesAfterFoundValidLocalLicense()
        {
            _SetValuesToInternationalLicenseGroupBox();
            llShowLicensesHistory.Visible = gbInternationalLicenseApplicationInfo.Visible = 
                btnIssue.Enabled = true;
        }

        private void _SetValuesToInternationalLicenseGroupBox()
        {
            lblApplicationFees.Text = _InternationalLicense.ApplicationInfo.PaidFees.ToString();
            llLocalLicenseID.Text = _InternationalLicense.IssuedUsingLocalLicenseInfo.LicenseID.ToString();
            llCreatedByUsername.Text = _InternationalLicense.CreatedByUserInfo.Username;
            lblIssueDate.Text = _InternationalLicense.IssueDate.ToString("dd/MM/yyyy");
            lblExpirationDate.Text = _InternationalLicense.ExpirationDate.ToString("dd/MM/yyyy");
        }

        private void _ClearValuesFromInternationalLicenseGroupBox()
        {
            _InternationalLicense = null;
            lblInternationalLicenseApplicationID.Text = lblInternationalLicenseID.Text = "N/A";
            lblApplicationFees.Text = llLocalLicenseID.Text = llCreatedByUsername.Text = "???";
            lblIssueDate.Text = lblExpirationDate.Text = "DD/MM/YYYY";
        }

        private void llShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPersonLicensesHistory personLicensesHistory = new frmPersonLicensesHistory(_InternationalLicense.DriverInfo.PersonInfo);
            personLicensesHistory.ShowDialog();
        }

        private void llShowInternationalLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowInternationalLicenseInfo internationalLicenseInfo = new frmShowInternationalLicenseInfo(_InternationalLicense);
            internationalLicenseInfo.ShowDialog();
        }

        private void llLocalLicenseID_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo licenseInfo = new frmShowLicenseInfo(_InternationalLicense.IssuedUsingLocalLicenseInfo);
            licenseInfo.ShowDialog();
        }

        private void llCreatedByUsername_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowUserInfo userInfo = new frmShowUserInfo(_InternationalLicense.CreatedByUserInfo);
            userInfo.ShowEditPersonInformationLinke = false;
            userInfo.ShowDialog();
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            if (clsFormMessages.ConfirmSava())
            {
                if (_InternationalLicense.Save())
                {
                    _UpdateFormAfterIssueAnInternationalLicense();
                    clsFormMessages.ShowSuccess($"International License Issued Successfuly With ID[{_InternationalLicense.InternationalLicenseID}]");
                }
                else
                {
                    _SetDefaultValuesToForm();
                    clsFormMessages.ShowError("Failed To Issued International License");
                }
            }
        }

        private void _UpdateFormAfterIssueAnInternationalLicense()
        {
            btnIssue.Enabled = false;
            llShowInternationalLicenseInfo.Visible = true;
            lblInternationalLicenseApplicationID.Text = _InternationalLicense.ApplicationInfo.ApplicationID.ToString();
            lblInternationalLicenseID.Text = _InternationalLicense.InternationalLicenseID.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
