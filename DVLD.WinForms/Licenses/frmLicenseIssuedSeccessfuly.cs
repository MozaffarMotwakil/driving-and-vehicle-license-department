using System;
using System.Media;
using System.Windows.Forms;
using DVLD.BusinessLogic;
using DVLD.WinForms.Utils;

namespace DVLD.WinForms.Licenses
{
    public partial class frmLicenseIssuedSeccessfuly : Form
    {
        private clsLicense _License;

        public frmLicenseIssuedSeccessfuly(int LicenseID)
        {
            InitializeComponent();
            _License = clsLicense.FindByLicenseID(LicenseID);
        }

        public frmLicenseIssuedSeccessfuly(clsLicense License)
        {
            InitializeComponent();
            _License = License;
        }

        private void frmSuccessIssuedLicense_Load(object sender, EventArgs e)
        {
            if (_License == null)
            {
                clsFormMessages.ShowError("License not found.");
                this.Close();
                return;
            }

            lblMessage.Text = $"License issued seccessfuly with ID[{_License.LicenseID}].";
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
