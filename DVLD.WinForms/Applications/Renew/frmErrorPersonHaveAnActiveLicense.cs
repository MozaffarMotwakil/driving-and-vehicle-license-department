using System;
using System.Media;
using System.Windows.Forms;
using DVLD.BusinessLogic;
using DVLD.WinForms.Licenses;

namespace DVLD.WinForms.Applications.Renew
{
    public partial class frmErrorPersonHaveAnActiveLicense : Form
    {
        private clsLicense _License;

        public frmErrorPersonHaveAnActiveLicense(clsLicense license)
        {
            InitializeComponent();
            _License = license;
        }

        private void frmErrorPersonHaveAnActiveLicense_Load(object sender, EventArgs e)
        {
            SystemSounds.Asterisk.Play();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void llLicenseDetails_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo licenseInfo = new frmShowLicenseInfo(_License);
            licenseInfo.ShowDialog();
        }

    }
}