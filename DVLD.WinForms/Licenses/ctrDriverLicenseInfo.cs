using System.Windows.Forms;
using DVLD.BusinessLogic;
using DVLD.WinForms.People;
using DVLD.WinForms.Properties;

namespace DVLD.WinForms.Licenses
{
    public partial class ctrDriverLicenseInfo : UserControl
    {
        public clsLicense License { get; set; }

        public ctrDriverLicenseInfo()
        {
            InitializeComponent();
        }

        public void LoadLicenseDataForDisplay(clsLicense license)
        {
            License = license;
            pbGender.Image = license.DriverInfo.PersonInfo.Gender == clsPerson.enGender.Male ?
                Resources.Man_32 :
                Resources.Woman_32;
            lblLicenseID.Text = license.LicenseID.ToString();
            llFullName.Text = license.DriverInfo.PersonInfo.GetFullName();
            lblNationalNo.Text = license.DriverInfo.PersonInfo.NationalNo;
            lblBirthDay.Text = license.DriverInfo.PersonInfo.DateOfBirth.ToString("dd/MM/yyyy");
            lblGender.Text = license.DriverInfo.PersonInfo.Gender.ToString();
            lblPhone.Text = license.DriverInfo.PersonInfo.Phone;
            pbPersonImage.ImageLocation = license.DriverInfo.PersonInfo.ImagePath;
            lblLicenseClass.Text = license.LicenseClassInfo.ClassName;
            lblDriverID.Text = license.DriverInfo.DriverID.ToString();
            lblNotes.Text = string.IsNullOrEmpty(license.Notes) ? "No Notes" : license.Notes;
            lblIssueDate.Text = license.IssueDate.ToString("dd/MM/yyyy");
            lblExpirationDate.Text = license.ExpirationDate.ToString("dd/MM/yyyy");
            lblIssueReason.Text = license.GetIssueReasonAsText();
            lblIsActive.Text = license.IsActive ? "Yes" : "No";
            // implementation this part later on after add "DetainedLicense" classes.
            // lblIsDetained.Text = clsDetainedLicense ? "Yes" : "No";
        }

        public void Clear()
        {
            License = null;
            lblLicenseID.Text = llFullName.Text = lblNationalNo.Text = lblGender.Text = 
                lblPhone.Text = lblLicenseClass.Text = lblDriverID.Text = lblNotes.Text = 
                lblIssueReason.Text = lblIsActive.Text = lblIsDetained.Text = "???";

            lblIssueDate.Text = lblExpirationDate.Text = lblBirthDay.Text = "DD/MM/YYYY";
            pbPersonImage.ImageLocation = string.Empty;
        }

        private void llFullName_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonInfo personInfo = new frmShowPersonInfo(License.DriverInfo.PersonInfo);
            personInfo.ShowEditPersonInformationLinke = false;
            personInfo.ShowDialog();
        }
    }
}
