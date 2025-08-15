using System;
using System.Windows.Forms;
using DVLD.BusinessLogic;
using DVLD.WinForms.Applications.LocalLicense;
using DVLD.WinForms.People;
using DVLD.WinForms.Properties;
using DVLD.WinForms.Utils;

namespace DVLD.WinForms.Tests.TestAppointmests
{
    public partial class frmTakeTest : Form
    {
        private clsTest _Test;

        public event Action SaveSuccess;
        protected virtual void OnSaveSuccess()
        {
            SaveSuccess?.Invoke();
        }
       
        public event Action PassedTest;
        protected virtual void OnPassedTest()
        {
            PassedTest?.Invoke();
        }

        public frmTakeTest(int TestAppointmentID)
        {
            InitializeComponent();
            _Test = new clsTest(clsTestAppointment.Find(TestAppointmentID));
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (clsFormMessages.ConfirmSava())
            {
                _Test.TestResult = rbPass.Checked;
                _Test.Notes = txtNotes.Text;

                if (_Test.Save())
                {
                    clsFormMessages.ShowSuccess("Seved Successfuly.");
                    OnSaveSuccess();

                    if (rbPass.Checked)
                    {
                        OnPassedTest();
                    }

                    this.Close();
                }
                else
                {
                    clsFormMessages.ShowError("Failed Saved.");
                }
            }
        }

        private void frmTakeTest_Load(object sender, EventArgs e)
        {
            switch (_Test.TestAppointmentInfo.LocalLicenseApplicationInfo.GetCurrentTestType())
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

            _FillDataFormTestAppointmentToUI();
        }

        private void _FillDataFormTestAppointmentToUI()
        {
            llLocalLicenseApplicationID.Text = _Test.TestAppointmentInfo.LocalLicenseApplicationInfo.LocalLicenseApplicationID.ToString();
            llFullName.Text = _Test.TestAppointmentInfo.LocalLicenseApplicationInfo.ApplicationInfo.PersonInfo.GetFullName();
            lblDrivingClass.Text = _Test.TestAppointmentInfo.LocalLicenseApplicationInfo.LicenseClassInfo.ClassName;
            lblTestFees.Text = _Test.TestAppointmentInfo.PaidFees.ToString();
            lblTotalOfAttempts.Text = _Test.TestAppointmentInfo.GetPreviousAttemptsCount().ToString();
            lblAppointmentDate.Text = _Test.TestAppointmentInfo.AppointmentDate.ToString("dd/MM/yyyy");
        }


        private void llFullName_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonInfo personInfo = new frmShowPersonInfo(_Test.TestAppointmentInfo.LocalLicenseApplicationInfo.ApplicationInfo.PersonInfo);
            personInfo.ShowEditPersonInformationLinke = false;
            personInfo.ShowDialog();
        }

        private void llLocalLicenseApplicationID_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLocalLicenseApplicationInfo localLicenseApplicationInfo = new frmShowLocalLicenseApplicationInfo(_Test.TestAppointmentInfo.LocalLicenseApplicationInfo);
            localLicenseApplicationInfo.ShowDialog();
        }

        private void TestResult_CheckedChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

    }
}