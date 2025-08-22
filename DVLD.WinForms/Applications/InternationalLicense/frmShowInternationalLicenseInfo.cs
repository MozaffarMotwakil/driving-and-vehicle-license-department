using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD.BusinessLogic;
using DVLD.WinForms.Utils;

namespace DVLD.WinForms.Applications.InternationalLicense
{
    public partial class frmShowInternationalLicenseInfo : Form
    {
        private clsInternationalLicense _InternationalLicense;

        public frmShowInternationalLicenseInfo(int internationalLicenseID)
        {
            InitializeComponent();
            _InternationalLicense = clsInternationalLicense.Find(internationalLicenseID);
        }

        public frmShowInternationalLicenseInfo(clsInternationalLicense internationalLicense)
        {
            InitializeComponent();
            _InternationalLicense = internationalLicense;
        }

        private void frmShowInternationalLicenseInfo_Load(object sender, EventArgs e)
        {
            if (_InternationalLicense == null)
            {
                clsFormMessages.ShowError("International license not found.");
                this.Close();
                return;
            }

            ctrInternationalLicenseInfo.LoadData(_InternationalLicense);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
