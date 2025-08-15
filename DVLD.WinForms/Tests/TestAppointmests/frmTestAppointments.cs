using System;
using System.Windows.Forms;
using DVLD.BusinessLogic;
using DVLD.WinForms.Applications.LocalLicense;
using DVLD.WinForms.Properties;
using DVLD.WinForms.Utils;

namespace DVLD.WinForms.Tests.TestAppointmests
{
    public partial class frmTestAppointments : Form
    {
        private clsLocalLicenseApplication _LocalLicenseApplication;
        private clsTestType.enTestType _TestType;

        public event Action PassedTest;
        protected virtual void OnPassedTest()
        {
            ctrLocalLicenseApplicationInfo.LoadLocalLicenseApplicationDataForDisplay(_LocalLicenseApplication);
            PassedTest?.Invoke();
        }

        public frmTestAppointments(int localLicenseApplocationID)
        {
            InitializeComponent();
            _LocalLicenseApplication = clsLocalLicenseApplication.Find(localLicenseApplocationID);
            _TestType = _LocalLicenseApplication.GetCurrentTestType();
        }

        private void frmVisionTestAppointments_Load(object sender, EventArgs e)
        {
            if (_LocalLicenseApplication == null)
            {
                clsFormMessages.ShowError("Sorry, local license application not found.");
                this.Close();
                return;
            }

            switch (_TestType)
            {
                case clsTestType.enTestType.Vision:
                    lblFormTitle.Text = this.Text = "Vision Test Appointments";
                    pbFormLogo.Image = Resources.Vision_512;
                    break;
                case clsTestType.enTestType.Written:
                    lblFormTitle.Text = this.Text = "Written Test Appointments";
                    pbFormLogo.Image = Resources.Written_Test_512;
                    break;
                case clsTestType.enTestType.Street:
                    lblFormTitle.Text = this.Text = "Driving Test Appointments";
                    pbFormLogo.Image = Resources.driving_test_512;
                    break;
            }

            ctrLocalLicenseApplicationInfo.LoadLocalLicenseApplicationDataForDisplay(_LocalLicenseApplication);
            _RefreshAppointmentsList();
            _ResetRecordsListColumnsWidthAndName();
        }

        private void btnAddNewAppointment_Click(object sender, EventArgs e)
        {
            if (dgvAppointmentsList.RowCount > 0)
            {
                if (!Convert.ToBoolean(dgvAppointmentsList.Rows[0].Cells["IsLocked"].Value))
                {
                    clsFormMessages.ShowError("This person already have an active appointment for this test, you cannot add a new appointment.");
                    return;
                }
                
                if (clsTest.Find(Convert.ToInt32(dgvAppointmentsList.Rows[0].Cells["TestAppointmentID"].Value)).TestResult)
                {
                    clsFormMessages.ShowError("This person already passed this test before, you cannot retake passed test.");
                    return;
                }
            }

            frmSchedualTest schedualTest = new frmSchedualTest(_LocalLicenseApplication);
            schedualTest.SaveSuccess += _RefreshAppointmentsList;
            schedualTest.ShowDialog();
        }

        private void _ResetRecordsListColumnsWidthAndName()
        {
            if (dgvAppointmentsList.RowCount > 0)
            {
                dgvAppointmentsList.Columns["TestAppointmentID"].HeaderText = "Test Appointment ID";
                dgvAppointmentsList.Columns["TestAppointmentID"].Width = 150;

                dgvAppointmentsList.Columns["AppointmentDate"].HeaderText = "Appointment Date";
                dgvAppointmentsList.Columns["AppointmentDate"].Width = 180;

                dgvAppointmentsList.Columns["PaidFees"].HeaderText = "Paid Fees";
                dgvAppointmentsList.Columns["PaidFees"].Width = 180;

                dgvAppointmentsList.Columns["IsLocked"].HeaderText = "Is Locked";
                dgvAppointmentsList.Columns["IsLocked"].Width = 150;
            }
        }

        private void _RefreshAppointmentsList()
        {
            lblRecordsCount.Text = clsFormHelper.RefreshDataGridView(dgvAppointmentsList,
                clsTestAppointment.GetAllTestAppointmentsForLocalLicenseApplication(
                    _LocalLicenseApplication.LocalLicenseApplicationID,
                    _TestType
                    )
                ).ToString();
        }

        private void dgvAppointmentsList_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            clsFormHelper.SelectEntireRow(dgvAppointmentsList, e);
        }

        private void dgvAppointmentsList_MouseDown(object sender, MouseEventArgs e)
        {
            clsFormHelper.DeselectCellsAndRows(dgvAppointmentsList, e);
        }

        private void appointmentsContextMenuStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (clsFormHelper.GetHitTestInfo(dgvAppointmentsList).Type != DataGridViewHitTestType.Cell)
            {
                e.Cancel = true;
                return;
            }

            editToolStripMenuItem.Visible = takeTestToolStripMenuItem.Visible = false;
            if (Convert.ToBoolean(dgvAppointmentsList.SelectedRows[0].Cells["IsLocked"].Value))
            {
                editToolStripMenuItem.Visible = true;
            }
            else
            {
                editToolStripMenuItem.Visible = takeTestToolStripMenuItem.Visible = true;
            }
        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTakeTest takeTest = new frmTakeTest(clsFormHelper.GetSelectedRowID(dgvAppointmentsList));
            takeTest.SaveSuccess += _RefreshAppointmentsList;
            takeTest.PassedTest += OnPassedTest;
            takeTest.ShowDialog();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSchedualTest schedualTest = new frmSchedualTest(clsFormHelper.GetSelectedRowID(dgvAppointmentsList));
            schedualTest.SaveSuccess += _RefreshAppointmentsList;
            schedualTest.ShowDialog();
        }

    }
}