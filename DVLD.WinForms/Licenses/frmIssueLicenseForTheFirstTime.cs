using System;
using System.Windows.Forms;
using DVLD.BusinessLogic;
using DVLD.WinForms.Utils;

namespace DVLD.WinForms.Licenses
{
    public partial class frmIssueLicenseForTheFirstTime : Form
    {
        private readonly clsLocalLicenseApplication _LocalLicenseApplication;
        private clsLicense _License;

        public event Action IssueSuccess;
        protected virtual void OnIssueSuccess()
        {
            IssueSuccess?.Invoke();
        }

        public frmIssueLicenseForTheFirstTime(int LocalLicenseApplicationID)
        {
            InitializeComponent();
            _LocalLicenseApplication = clsLocalLicenseApplication.Find(LocalLicenseApplicationID);

            if (_LocalLicenseApplication != null)
            {
                _License = new clsLicense(
                _LocalLicenseApplication.ApplicationInfo,
                _LocalLicenseApplication.LicenseClassInfo,
                clsLicense.enIssueReason.FirstTime
                );
            }
        }

        private void frmIssueLicenseForTheFirstTime_Load(object sender, EventArgs e)
        {
            if (_LocalLicenseApplication == null)
            {
                clsFormMessages.ShowError("Local license application not found.");
                this.Close();
                return;
            }

            ctrLocalLicenseApplicationInfo.LoadLocalLicenseApplicationDataForDisplay(_LocalLicenseApplication);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            if (clsFormMessages.ConfirmSava())
            {
                _License.Notes = txtNotes.Text;

                if (_License.Issue())
                {
                    OnIssueSuccess();
                    frmLicenseIssuedSeccessfuly issuedSeccessfuly = new frmLicenseIssuedSeccessfuly(_License);
                    issuedSeccessfuly.ShowDialog();
                }
                else
                {
                    clsFormMessages.ShowError("Failed license issue");
                }

                this.Close();
            }
        }

    }
}
