using System;
using System.Windows.Forms;
using DVLD.BusinessLogic;
using DVLD.WinForms.Utils;

namespace DVLD.WinForms.Licenses
{
    public partial class frmIssueLicenseForTheFirstTime : Form
    {
        private readonly clsLocalLicenseApplication _LocalLicenseApplication;

        public event Action IssueSuccess;
        protected virtual void OnIssueSuccess()
        {
            IssueSuccess?.Invoke();
        }

        public frmIssueLicenseForTheFirstTime(int LocalLicenseApplicationID)
        {
            InitializeComponent();
            _LocalLicenseApplication = clsLocalLicenseApplication.Find(LocalLicenseApplicationID);
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
            if (!_LocalLicenseApplication.IsPersonPassedAllTests())
            {
                clsFormMessages.ShowError("The applicant has not passed all tests yet.");
                return;
            }

            if (!_LocalLicenseApplication.IsPersonAgeAllowedToHaveThisLicense())
            {
                clsFormMessages.ShowError(
                    $"The person's current age ({_LocalLicenseApplication.ApplicationInfo.PersonInfo.GetAge()} Years) " +
                    $"does not allow him to obtain a license in this class, minimum age allowed is {_LocalLicenseApplication.LicenseClassInfo.MinimumAllowedAge}."
                    );

                return;
            }

            if (clsFormMessages.ConfirmSava())
            {
                int newLicenseID = _LocalLicenseApplication.IssueLicenseForFirstTime(txtNotes.Text);

                if (newLicenseID != -1)
                {
                    OnIssueSuccess();
                    frmLicenseIssuedSeccessfuly issuedSeccessfuly = new frmLicenseIssuedSeccessfuly(newLicenseID);
                    issuedSeccessfuly.ShowDialog();
                }
                else
                {
                    clsFormMessages.ShowError("Failed to issue driving license");
                }

                this.Close();
            }
        }

    }
}
