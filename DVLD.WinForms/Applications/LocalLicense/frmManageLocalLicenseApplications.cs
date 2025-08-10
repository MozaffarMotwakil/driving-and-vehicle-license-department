using System;
using System.Data;
using System.Drawing;
using DVLD.BusinessLogic;
using DVLD.WinForms.BaseForms;
using DVLD.WinForms.Properties;
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

                    dtpApplicationDate.Value = dtpApplicationDate.MaxDate > DateTime.Now.Date ? DateTime.Now.Date : dtpApplicationDate.MaxDate;
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

    }
}
