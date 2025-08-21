using System;
using System.Media;
using System.Windows.Forms;
using DVLD.BusinessLogic;

namespace DVLD.WinForms.Applications.InternationalLicense
{
    public partial class frmErrorPerosnHaveAnActiveInternationalLicense : Form
    {
        private clsInternationalLicense _InternationalLicense;

        public frmErrorPerosnHaveAnActiveInternationalLicense(clsInternationalLicense internationalLicense)
        {
            InitializeComponent();
            _InternationalLicense = internationalLicense;
        }

        private void frmErrorPerosnHaveAnActiveInternationalLicense_Load(object sender, EventArgs e)
        {
            SystemSounds.Asterisk.Play();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void llInternationalLicenseDetails_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowInternationalLicenseInfo internationalLicenseInfo = new frmShowInternationalLicenseInfo(_InternationalLicense);
            internationalLicenseInfo.ShowDialog();
        }

    }
}