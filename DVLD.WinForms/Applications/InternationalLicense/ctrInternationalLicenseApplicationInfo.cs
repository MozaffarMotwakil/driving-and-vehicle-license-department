using System.Windows.Forms;
using DVLD.BusinessLogic;
using DVLD.WinForms.Licenses;
using DVLD.WinForms.Users;

namespace DVLD.WinForms.Applications.InternationalLicense
{
    public partial class ctrInternationalLicenseApplicationInfo : UserControl
    {
        public clsInternationalLicense InternationalLicense { get; private set; }

        public ctrInternationalLicenseApplicationInfo()
        {
            InitializeComponent();
        }
    
    }
}
