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

namespace DVLD.WinForms.Applications.LocalLicense
{
    public partial class frmShowLocalLicenseApplicationInfo : Form
    {
        private clsLocalLicenseApplication _LocalLicenseApplication;
        public frmShowLocalLicenseApplicationInfo(int LocalLicenseApplicationID)
        {
            InitializeComponent();
            this._LocalLicenseApplication = clsLocalLicenseApplication.Find(LocalLicenseApplicationID);
        }

        public frmShowLocalLicenseApplicationInfo(clsLocalLicenseApplication LocalLicenseApplication)
        {
            InitializeComponent();
            this._LocalLicenseApplication = LocalLicenseApplication;
        }

        private void btnCloseScreen_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmShowLocalLicenseApplicationInfo_Load(object sender, EventArgs e)
        {
            if (_LocalLicenseApplication == null)
            {
                clsFormMessages.ShowError("Sorry, local license application not fount.");
                this.Close();
                return;
            }

            ctrLocalLicenseApplicationInfo.LoadLocalLicenseApplicationDataForDisplay(_LocalLicenseApplication);
        }

    }
}
