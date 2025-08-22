using System.Windows.Forms;
using DVLD.BusinessLogic;
using DVLD.WinForms.Applications.BaseApplication;
using DVLD.WinForms.People;
using DVLD.WinForms.Properties;

namespace DVLD.WinForms.Applications.InternationalLicense
{
    public partial class ctrInternationalLicenseInfo : UserControl
    {
        public clsInternationalLicense InternationalLicense { get; private set; }

        public ctrInternationalLicenseInfo()
        {
            InitializeComponent();
            InternationalLicense = null;
        }

        public void LoadData(clsInternationalLicense internationalLicense)
        {
            InternationalLicense = internationalLicense;
            _SetPersonImage();
            lblInternationalLicenseID.Text = internationalLicense.InternationalLicenseID.ToString();
            llFullName.Text = internationalLicense.DriverInfo.PersonInfo.GetFullName();
            lblNationalNo.Text = internationalLicense.DriverInfo.PersonInfo.NationalNo;
            lblBirthDay.Text = internationalLicense.DriverInfo.PersonInfo.DateOfBirth.ToString("dd/MM/yyyy");
            lblGender.Text = internationalLicense.DriverInfo.PersonInfo.Gender.ToString();
            llInternationalLicenseApplicationID.Text = internationalLicense.ApplicationInfo.ApplicationID.ToString();
            lblIssueDate.Text = internationalLicense.IssueDate.ToString("dd/MM/yyyy");
            lblExpirationDate.Text = internationalLicense.ExpirationDate.ToString("dd/MM/yyyy");
            lblDriverID.Text = internationalLicense.DriverInfo.DriverID.ToString();
            lblIsActive.Text = internationalLicense.IsActive ? "Yes" : "No";
        }

        private void _SetPersonImage()
        {
            pbGender.Image = InternationalLicense.DriverInfo.PersonInfo.Gender == clsPerson.enGender.Male ?
                Resources.Man_32 :
                Resources.Woman_32;
            pbPersonImage.Image = InternationalLicense.DriverInfo.PersonInfo.Gender == clsPerson.enGender.Male ?
                Resources.Male_512 :
                Resources.Female_512;
            pbPersonImage.ImageLocation = InternationalLicense.DriverInfo.PersonInfo.ImagePath;
        }

        public void Clear()
        {
            InternationalLicense = null;
            pbGender.Image = Resources.Man_32;
            pbPersonImage.Image = Resources.Male_512;

            lblInternationalLicenseID.Text = llFullName.Text = lblNationalNo.Text = lblGender.Text =
                llInternationalLicenseApplicationID.Text = lblDriverID.Text = lblIsActive.Text = "???";

            lblIssueDate.Text = lblExpirationDate.Text = lblBirthDay.Text = "DD/MM/YYYY";
            pbPersonImage.ImageLocation = string.Empty;
        }

        private void llFullName_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (InternationalLicense == null)
            {
                return;
            }

            frmShowPersonInfo personInfo = new frmShowPersonInfo(InternationalLicense.DriverInfo.PersonInfo);
            personInfo.ShowEditPersonInformationLinke = false;
            personInfo.ShowDialog();
        }

        private void llInternationalLicenseApplicationID_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (InternationalLicense == null)
            {
                return;
            }

            frmShowBaseApplicationInfo baseApplicationInfo = new frmShowBaseApplicationInfo(InternationalLicense.ApplicationInfo);
            baseApplicationInfo.ShowDialog();
        }

    }
}