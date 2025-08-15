using System;
using System.Windows.Forms;
using DVLD.BusinessLogic;
using DVLD.WinForms.Applications.LocalLicense;
using DVLD.WinForms.People;
using DVLD.WinForms.Properties;
using DVLD.WinForms.Utils;

namespace DVLD.WinForms.Tests.TestAppointmests
{
    public partial class frmSchedualTest : Form
    {
        private clsTestAppointment _TestAppointment;
        private enMode _FormMode;

        public event Action SaveSuccess;
        protected virtual void OnSaveSeccess()
        {
            SaveSuccess?.Invoke();
        }

        public frmSchedualTest(clsLocalLicenseApplication LocalLicenseApplciation)
        {
            InitializeComponent();
            _TestAppointment = new clsTestAppointment(LocalLicenseApplciation, LocalLicenseApplciation.GetCurrentTestType());
            _FormMode = enMode.AddNew;
        }

        public frmSchedualTest(int testAppointmentID)
        {
            InitializeComponent();
            _TestAppointment = clsTestAppointment.Find(testAppointmentID);
            _FormMode = enMode.Update;
        }

        private void frmSchedualTest_Load(object sender, EventArgs e)
        {
            switch (_TestAppointment.LocalLicenseApplicationInfo.GetCurrentTestType())
            {
                case clsTestType.enTestType.Vision:
                    gbTestAppointmentInfo.Text = "Vision Test";
                    pbFormLogo.Image = Resources.Vision_512;
                    break;
                case clsTestType.enTestType.Written:
                    gbTestAppointmentInfo.Text = "Written Test";
                    pbFormLogo.Image = Resources.Written_Test_512;
                    break;
                case clsTestType.enTestType.Street:
                    gbTestAppointmentInfo.Text = "Driving Test";
                    pbFormLogo.Image = Resources.driving_test_512;
                    break;
            }

            if (_TestAppointment.IsHasRetakeTestApplication())
            {
                lblFormTitle.Text = "Schedual Retake Test";
                gbRetakeTestInfo.Visible = true;
            }

            if (_FormMode == enMode.Update)
            {
                if (_TestAppointment.IsLocked)
                {
                    lblAppointmentLockedMessage.Visible = true;
                    dtpAppointmentDate.Enabled = false;
                    btnSave.Enabled = false;
                }
            }

            _FillDataFormTestAppointmentToUI();
        }

        private void _FillDataFormTestAppointmentToUI()
        {
            dtpAppointmentDate.MinDate = DateTime.Now;
            dtpAppointmentDate.Value = _TestAppointment.AppointmentDate;
            llLocalLicenseApplicationID.Text = _TestAppointment.LocalLicenseApplicationInfo.LocalLicenseApplicationID.ToString();
            llFullName.Text = _TestAppointment.LocalLicenseApplicationInfo.ApplicationInfo.PersonInfo.GetFullName();
            lblDrivingClass.Text = _TestAppointment.LocalLicenseApplicationInfo.LicenseClassInfo.ClassName;
            lblTotalOfAttempts.Text = _TestAppointment.GetPreviousAttemptsCount().ToString();
            lblTestFees.Text = _TestAppointment.PaidFees.ToString();
            lblRetakeTestFees.Text = _TestAppointment.IsHasRetakeTestApplication() ?
                _TestAppointment.RetakeTestApplicationInfo.PaidFees.ToString() :
                "0";
            lblTotalFess.Text = _TestAppointment.CalculateTotalFees().ToString();
        }

        private void llFullName_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonInfo personInfo = new frmShowPersonInfo(_TestAppointment.LocalLicenseApplicationInfo.ApplicationInfo.PersonInfo);
            personInfo.ShowEditPersonInformationLinke = false;
            personInfo.ShowDialog();
        }

        private void llLocalLicenseApplicationID_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLocalLicenseApplicationInfo localLicenseApplicationInfo = new frmShowLocalLicenseApplicationInfo(_TestAppointment.LocalLicenseApplicationInfo);
            localLicenseApplicationInfo.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (clsFormMessages.ConfirmSava())
            {
                _TestAppointment.AppointmentDate = dtpAppointmentDate.Value.Date;

                if (_TestAppointment.Save())
                {
                    clsFormMessages.ShowSuccess("Saved Successfuly.");
                    OnSaveSeccess();
                    this.Close();
                }
                else
                {
                    clsFormMessages.ShowError("Failed Saved");
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}