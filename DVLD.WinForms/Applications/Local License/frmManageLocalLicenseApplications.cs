using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DVLD.BusinessLogic;
using DVLD.WinForms.BaseForms;
using DVLD.WinForms.Licenses;
using DVLD.WinForms.Properties;
using DVLD.WinForms.Tests.TestAppointmests;
using DVLD.WinForms.Utils;

namespace DVLD.WinForms.Applications.LocalLicense
{
    internal partial class frmManageLocalLicenseApplications : frmBaseManageWithFilter
    {
        public frmManageLocalLicenseApplications() : base(clsLocalLicenseApplication.GetAllLocalLicenseApplications())
        {
            InitializeComponent();
        }

        private void frmManageLocalLicenseApplications_Load(object sender, EventArgs e)
        {
            _SetValuesToBaseFormControls();
            _SetDefaultValuesToLicenseClasses_ComboBox();
            _SetDefaultValuesToApplicationDate_DateTimePicker();
        }

        private void _SetDefaultValuesToApplicationDate_DateTimePicker()
        {
            dtpApplicationDate.MinDate = clsLocalLicenseApplication.GetMinimumApplicationDate();
            dtpApplicationDate.MaxDate = clsLocalLicenseApplication.GetMaximumApplicationDate();
            base.FilterText = string.Empty;
        }

        private void _SetDefaultValuesToLicenseClasses_ComboBox()
        {
            cbDrivingClass.Items.Add("All");
            clsFormHelper.SetLicenseClassesToComboBox(cbDrivingClass);
            cbDrivingClass.SelectedIndex = 0;
        }

        private void _SetValuesToBaseFormControls()
        {
            base.FormTitle = "Manage Local Driving License Applications";
            base.FormLogo = Resources.Applications;
            base.RecordsList.ContextMenuStrip = recordsListContextMenuStrip;
            base.AddNewRecordButtonBackgroumd = Resources.New_Application_64;
            base.AddNewRecordButtonBackgroumdLayout = System.Windows.Forms.ImageLayout.Zoom;
            base.FilterColumns.AddRange(
                new object[] {
                    "L.D.L.App ID",
                    "Driving Class",
                    "National No",
                    "Full Name",
                    "Application Date",
                    "Passed Tests",
                    "Status"
                }
            );
        }

        protected override DataTable GetDataSource()
        {
            return clsLocalLicenseApplication.GetAllLocalLicenseApplications();
        }

        protected override void UpdateFilterControlsVisibility()
        {
            SetFilterColumnValue();

            base.FilterTextControlVisible = cbDrivingClass.Visible = dtpApplicationDate.Visible =
                nudPassedTests.Visible = cbApplicationStatus.Visible = false;

            switch (base.SelectedFilterColumn)
            {
                case "ClassName":
                    cbDrivingClass.Location = new Point(cbDrivingClass.Location.X, 178);
                    cbDrivingClass.Visible = true;
                    cbDrivingClass.SelectedIndex = 0;
                    break;
                case "ApplicationDate":
                    dtpApplicationDate.Location = new Point(dtpApplicationDate.Location.X, 179);
                    dtpApplicationDate.Visible = true;

                    if (dtpApplicationDate.Value == DateTime.Now.Date || dtpApplicationDate.Value == dtpApplicationDate.MaxDate)
                    {
                        base.FilterText = dtpApplicationDate.Value.ToString("yyyy/MM/dd");
                    }

                    dtpApplicationDate.Value = dtpApplicationDate.MaxDate > DateTime.Now.Date ?
                        DateTime.Now.Date :
                        dtpApplicationDate.MaxDate;
                    break;
                case "PassedTests":
                    nudPassedTests.Location = new Point(nudPassedTests.Location.X, 179); ;
                    nudPassedTests.Visible = true;

                    if (nudPassedTests.Value == 0)
                    {
                        base.FilterText = nudPassedTests.Value.ToString();
                    }
                    
                    nudPassedTests.Value = 0;
                    break;
                case "ApplicationStatusName":
                    cbApplicationStatus.Location = new Point(cbApplicationStatus.Location.X, 178);
                    cbApplicationStatus.Visible = true;
                    cbApplicationStatus.SelectedIndex = 0;
                    break;
                default:
                    base.DefaultFilterControlsVisibility();
                    break;
            }
        }

        protected override void ResetRecordsListColumnsWidthAndName()
        {
            if (base.RecordsCount > 0)
            {
                base.RecordsList.Columns["LocalDrivingLicenseApplicationID"].HeaderText = "L.D.L.App ID";
                base.RecordsList.Columns["LocalDrivingLicenseApplicationID"].Width = 80;

                base.RecordsList.Columns["ClassName"].HeaderText = "Driving Class";
                base.RecordsList.Columns["ClassName"].Width = 150;

                base.RecordsList.Columns["NationalNo"].HeaderText = "National No";
                base.RecordsList.Columns["NationalNo"].Width = 100;

                base.RecordsList.Columns["FullName"].HeaderText = "Full Name";
                base.RecordsList.Columns["FullName"].Width = 200;

                base.RecordsList.Columns["ApplicationDate"].HeaderText = "Application Date";
                base.RecordsList.Columns["ApplicationDate"].Width = 80;

                base.RecordsList.Columns["PassedTests"].HeaderText = "Passed Tests";
                base.RecordsList.Columns["PassedTests"].Width = 75;

                base.RecordsList.Columns["ApplicationStatusName"].HeaderText = "Status";
                base.RecordsList.Columns["ApplicationStatusName"].Width = 100;
            }
        }

        protected override void SetFilterColumnValue()
        {
            base.SetFilterColumnValue();

            switch (base.SelectedFilterColumn)
            {
                case "L.D.L.AppID":
                    base.SelectedFilterColumn = "LocalDrivingLicenseApplicationID";
                    break;
                case "DrivingClass":
                    base.SelectedFilterColumn = "ClassName";
                    break;
                case "Status":
                    base.SelectedFilterColumn = "ApplicationStatusName";
                    break;
            }
        }

        protected override void dgvRecordsList_MouseDown(object sender, MouseEventArgs e)
        {
            base.dgvRecordsList_MouseDown(sender, e);

            if (e.Button == MouseButtons.Right)
            {
                clsFormHelper.ShowAnotherContextMenuOnEmptySpaceInDGV(base.RecordsList, formContextMenuStrip);
            }
        }

        private void frmManageLocalLicenseApplications_MouseDown(object sender, MouseEventArgs e)
        {
            base.frmBaseManage_MouseDown(sender, e);
        }

        private void cbDrivingClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            base.SetFilterTextFromComboBox(cbDrivingClass);
        }

        private void cbApplicationStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            base.SetFilterTextFromComboBox(cbApplicationStatus);
        }

        private void dtpApplicationDate_ValueChanged(object sender, EventArgs e)
        {
            base.SetFilterTextFromDate(dtpApplicationDate.Value);
        }

        private void nudPassedTests_ValueChanged(object sender, EventArgs e)
        {
            base.FilterText = nudPassedTests.Value.ToString();
        }

        private void dtpApplicationDate_VisibleChanged(object sender, EventArgs e)
        {
            DateTime lastMaximumApplicationDate = clsLocalLicenseApplication.GetMaximumApplicationDate();

            if (dtpApplicationDate.MaxDate != lastMaximumApplicationDate)
            {
                dtpApplicationDate.MaxDate = lastMaximumApplicationDate;
            }
        }

        protected override bool DeleteRecord(int recordID)
        {
            return clsLocalLicenseApplication.Delete(recordID);
        }

        protected override void ShowRecordDetailsOperation()
        {
            frmShowLocalLicenseApplicationInfo showLocalLicenseApplicationInfo = new frmShowLocalLicenseApplicationInfo(clsFormHelper.GetSelectedRowID(base.RecordsList));
            showLocalLicenseApplicationInfo.ShowDialog();
        }

        protected override void AddNewRecordOperation()
        {
            frmAddUpdateLocalLicenseApplication addLocalLicenseApplicationForm = new frmAddUpdateLocalLicenseApplication();
            addLocalLicenseApplicationForm.SaveSuccess += base.RefreshAndResetFilterColumnToDefault;
            addLocalLicenseApplicationForm.PersonInfoModifie += base.RefreshAndResetFilterColumnToDefault;
            addLocalLicenseApplicationForm.ShowDialog();
        }

        private void addNewApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewRecordOperation();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowRecordDetailsOperation();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateLocalLicenseApplication updateLocalLicenseApplicationForm = new frmAddUpdateLocalLicenseApplication(clsFormHelper.GetSelectedRowID(base.RecordsList));
            updateLocalLicenseApplicationForm.SaveSuccess += base.RefreshAndReapplyCurrentFilter;
            updateLocalLicenseApplicationForm.PersonInfoModifie += base.RefreshAndReapplyCurrentFilter;
            updateLocalLicenseApplicationForm.ShowDialog();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            base.DeleteRecordOperation();
        }

        private void cancleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsLocalLicenseApplication localLicenseApplication = clsLocalLicenseApplication.Find(clsFormHelper.GetSelectedRowID(base.RecordsList));

            if (localLicenseApplication == null)
            {
                clsFormMessages.ShowError("Sorry, the local driving license application not found.");
                return;
            }

            if (clsFormMessages.Confirm($"This action cannot be undone. Are you sure you want to cancel local driving license application number [{localLicenseApplication.LocalLicenseApplicationID}] ?", 
                messageBoxIcon: MessageBoxIcon.Warning, messageBoxDefaultButton: MessageBoxDefaultButton.Button2))
            {
                if (localLicenseApplication.ApplicationInfo.SetCanclled())
                {
                    base.RefreshAndResetFilterColumnToDefault();
                }
                else
                {
                    clsFormMessages.ShowError("Failed to change status.");
                }
            }
        }

        private void recordsListContextMenuStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (clsFormHelper.GetHitTestInfo(base.RecordsList).Type != DataGridViewHitTestType.Cell)
            {
                e.Cancel = true;
                return;
            }

            _ConfigureAllMenuItems();
            switch (base.RecordsList.SelectedRows[0].Cells["ApplicationStatusName"].Value.ToString())
            {
                case "New":
                    _ConfigureMenuItemsForNewStatus();
                    _HandleTestMenuItemsVisibility();
                    break;
                case "Completed":
                    _ConfigureMenuItemsForCompletedStatus();
                    break;
            }
        }

        private void _ConfigureAllMenuItems()
        {
            editToolStripMenuItem.Visible = deleteToolStripMenuItem.Visible = cancleToolStripMenuItem.Visible =
                    scheduleTestsToolStripMenuItem.Visible = issueDrivingLicenseToolStripMenuItem.Visible =
                    showLicenseToolStripMenuItem.Visible = showPersonLicensesHistoryToolStripMenuItem.Visible = false;

            toolStripSeparator1.Visible = toolStripSeparator2.Visible = toolStripSeparator3.Visible =
                toolStripSeparator4.Visible = toolStripSeparator5.Visible = false;

            schedualVisionTestToolStripMenuItem.Enabled = schedualWrittenTestToolStripMenuItem.Enabled =
                schedualStreetTestToolStripMenuItem.Enabled = false;
        }

        private void _ConfigureMenuItemsForNewStatus()
        {
            toolStripSeparator1.Visible = toolStripSeparator2.Visible = true;

            editToolStripMenuItem.Visible = deleteToolStripMenuItem.Visible =
                cancleToolStripMenuItem.Visible = scheduleTestsToolStripMenuItem.Visible = true;
        }

        private void _ConfigureMenuItemsForCompletedStatus()
        {
            toolStripSeparator4.Visible = toolStripSeparator5.Visible = true;
            showLicenseToolStripMenuItem.Visible = showPersonLicensesHistoryToolStripMenuItem.Visible = true;
        }

        private void _HandleTestMenuItemsVisibility()
        {
            switch (Convert.ToByte(base.RecordsList.SelectedRows[0].Cells["PassedTests"].Value))
            {
                case 0:
                    schedualVisionTestToolStripMenuItem.Enabled = true;
                    break;
                case 1:
                    schedualWrittenTestToolStripMenuItem.Enabled = true;
                    break;
                case 2:
                    schedualStreetTestToolStripMenuItem.Enabled = true;
                    break;
                default:
                    scheduleTestsToolStripMenuItem.Visible = false;
                    issueDrivingLicenseToolStripMenuItem.Visible = true;
                    break;
            }
        }

        private void schedualTestType_Click(object sender, EventArgs e)
        {
            frmTestAppointments visionTestAppointments = new frmTestAppointments(clsFormHelper.GetSelectedRowID(base.RecordsList));
            visionTestAppointments.PassedTest += base.RefreshAndReapplyCurrentFilter;
            visionTestAppointments.ShowDialog();
        }

        private void issueDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIssueLicenseForTheFirstTime licenseForTheFirstTime = new frmIssueLicenseForTheFirstTime(clsFormHelper.GetSelectedRowID(this.RecordsList));
            licenseForTheFirstTime.IssueSuccess += base.RefreshAndReapplyCurrentFilter;
            licenseForTheFirstTime.ShowDialog();
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowLicenseInfo licenseInfo = new frmShowLicenseInfo(clsLocalLicenseApplication.Find(clsFormHelper.GetSelectedRowID(base.RecordsList)).ApplicationInfo.ApplicationID);
            licenseInfo.ShowDialog();
        }

        private void showPersonLicensesHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPersonLicensesHistory licensesHistory = new frmPersonLicensesHistory(clsLocalLicenseApplication.Find(clsFormHelper.GetSelectedRowID(base.RecordsList)).ApplicationInfo.PersonInfo);
            licensesHistory.ShowDialog();
        }

    }
}
