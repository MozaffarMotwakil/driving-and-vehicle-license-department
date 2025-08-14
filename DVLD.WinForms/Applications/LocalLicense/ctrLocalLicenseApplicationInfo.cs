using System.Windows.Forms;
using DVLD.BusinessLogic;

namespace DVLD.WinForms.Applications.LocalLicense
{
    public partial class ctrLocalLicenseApplicationInfo : UserControl
    {
        public clsLocalLicenseApplication LocalLicenseApplication { get; set; }

        public ctrLocalLicenseApplicationInfo()
        {
            InitializeComponent();
        }

        public void LoadLocalLicenseApplicationDataForDisplay(clsLocalLicenseApplication LocalLicenseApplication)
        {
            this.LocalLicenseApplication = LocalLicenseApplication;
            ctrBaseApplicationInfo.LoadBaseApplicationDataForDisplay(LocalLicenseApplication.ApplicationInfo);
            lblLocalLicenseApplicationID.Text = LocalLicenseApplication.LocalLicenseApplicationID.ToString();
            lblLicenseClass.Text = LocalLicenseApplication.LicenseClassInfo.ClassName;
            lblPassedTests.Text = clsTest.GetPassedTestsCountForLocalLicenseApplication(LocalLicenseApplication.LocalLicenseApplicationID).ToString() + "/3";
            llShowLicenseInfo.Visible = LocalLicenseApplication.ApplicationInfo.Status == clsApplication.enApplicationStatus.Completed;
        }

        public void Clear()
        {
            this.LocalLicenseApplication = null;
            ctrBaseApplicationInfo.Clear();
            lblLocalLicenseApplicationID.Text = lblLicenseClass.Text = lblPassedTests.Text = "???";
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

    }
}
