using System;
using System.Media;
using System.Windows.Forms;
using DVLD.BusinessLogic;

namespace DVLD.WinForms.Applications.LocalLicense
{
    public partial class frmErrorPersonHaveActiveApplication : Form
    {
        private clsLocalLicenseApplication _ActiveLocalLicenseApplicarion;

        public frmErrorPersonHaveActiveApplication(clsLocalLicenseApplication ActiveLocalLicenseApplication)
        {
            InitializeComponent();
            _ActiveLocalLicenseApplicarion = ActiveLocalLicenseApplication;
        }

        private void frmPersonHaveActiveApplication_Load(object sender, EventArgs e)
        {
            SystemSounds.Asterisk.Play();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void llApplicationDetails_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLocalLicenseApplicationInfo licenseApplicationInfo = new frmShowLocalLicenseApplicationInfo(_ActiveLocalLicenseApplicarion);
            licenseApplicationInfo.ShowDialog();
        }

    }
}