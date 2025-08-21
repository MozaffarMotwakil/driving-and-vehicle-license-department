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
            ctrDriverLicenseInfoWithFilter.FoundLicense += CtrDriverLicenseInfoWithFilter_FoundLicense;
            ctrDriverLicenseInfoWithFilter.NotFoundLicense += CtrDriverLicenseInfoWithFilter_NotFoundLicense;
        }

        private void frmIsuueInternationalLicense_Activated(object sender, EventArgs e)
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
            try
            {
                _InternationalLicense = new clsInternationalLicense(ctrDriverLicenseInfoWithFilter.License);
                _SetValuesAfterFoundValidLocalLicense();
            }
            catch (Exception ex)
            {
                _SetDefaultValuesToForm();

                if (clsInternationalLicense.IsPersonHasAnActiveInternationalLicense(
                    ctrDriverLicenseInfoWithFilter.License.DriverInfo.PersonInfo.PersonID))
                {
                    clsInternationalLicense activeInternationaLicense = clsInternationalLicense.GetActiveInternationalLicenseForPerson(
                    ctrDriverLicenseInfoWithFilter.License.DriverInfo.PersonInfo.PersonID);

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
            ClearValuesFromInternationalLicenseGroupBox();
            btnIssue.Enabled = gbInternationalLicenseAndApplicationInfo.Enabled = false;
            llShowLicenseHistory.Visible = llShowInternationalLicenseInfo.Visible = false;
        }

        private void _SetValuesAfterFoundValidLocalLicense()
        {
            SetValuesToInternationalLicenseGroupBox();
            btnIssue.Enabled = gbInternationalLicenseAndApplicationInfo.Enabled = true;
            llShowLicenseHistory.Visible = true;
        }

        public void SetValuesToInternationalLicenseGroupBox()
        {
            lblApplicationFees.Text = _InternationalLicense.ApplicationInfo.PaidFees.ToString();
            llLocalLicenseID.Text = _InternationalLicense.IssuedUsingLocalLicenseInfo.LicenseID.ToString();
            llCreatedByUsername.Text = _InternationalLicense.CreatedByUserInfo.Username;
            lblIssueDate.Text = _InternationalLicense.IssueDate.ToString("dd/MM/yyyy");
            lblExpirationDate.Text = _InternationalLicense.ExpirationDate.ToString("dd/MM/yyyy");
        }

        public void ClearValuesFromInternationalLicenseGroupBox()
        {
            _InternationalLicense = null;
            lblInternationalLicenseApplicationID.Text = lblApplicationFees.Text = llLocalLicenseID.Text =
                llCreatedByUsername.Text = lblInternationalLicenseID.Text = "???";
            lblIssueDate.Text = lblExpirationDate.Text = "DD/MM/YYYY";
        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_InternationalLicense == null)
            {
                return;
            }

            frmPersonLicensesHistory personLicensesHistory = new frmPersonLicensesHistory(_InternationalLicense.DriverInfo.PersonInfo);
            personLicensesHistory.ShowDialog();
        }

        private void llShowInternationalLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_InternationalLicense == null)
            {
                return;
            }

            frmShowInternationalLicenseInfo internationalLicenseInfo = new frmShowInternationalLicenseInfo(_InternationalLicense);
            internationalLicenseInfo.ShowDialog();
        }

        private void llLocalLicenseID_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_InternationalLicense == null)
            {
                return;
            }

            frmShowLicenseInfo licenseInfo = new frmShowLicenseInfo(_InternationalLicense.IssuedUsingLocalLicenseInfo);
            licenseInfo.ShowDialog();
        }

        private void llCreatedByUsername_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_InternationalLicense == null)
            {
                return;
            }

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

    }
}
