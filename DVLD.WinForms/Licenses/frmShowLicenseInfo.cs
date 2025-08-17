using System;
using System.Windows.Forms;
using DVLD.BusinessLogic;
using DVLD.WinForms.Utils;

namespace DVLD.WinForms.Licenses
{
    public partial class frmShowLicenseInfo : Form
    {
        private clsLicense _License;

        public frmShowLicenseInfo(int ApplicaitonID)
        {
            InitializeComponent();
            _License = clsLicense.Find(ApplicaitonID);
        }

        public frmShowLicenseInfo(clsLicense License)
        {
            InitializeComponent();
            _License = License;
        }

        private void frmShowLicenseInfo_Load(object sender, EventArgs e)
        {
            if (_License == null)
            {
                clsFormMessages.ShowError("License not found.");
                this.Close();
                return;
            }

            ctrDriverLicenseInfo.LoadLicenseDataForDisplay(_License);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
