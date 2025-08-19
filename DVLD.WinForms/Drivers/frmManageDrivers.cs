using System;
using System.Data;
using System.Drawing;
using DVLD.BusinessLogic;
using DVLD.WinForms.BaseForms;
using DVLD.WinForms.Licenses;
using DVLD.WinForms.People;
using DVLD.WinForms.Properties;
using DVLD.WinForms.Utils;

namespace DVLD.WinForms.Drivers
{
    internal partial class frmManageDrivers : frmBaseManageWithFilter
    {
        public frmManageDrivers() : base(clsDriver.GetAllDrivers())
        {
            InitializeComponent();
        }

        private void frmManageDrivers_Load(object sender, EventArgs e)
        {
            _SetValuesToBaseFormControls();
        }

        private void _SetValuesToBaseFormControls()
        {
            base.FormTitle = "Manage Drivers";
            base.FormLogo = Resources.Driver_Main;
            base.RecordsList.ContextMenuStrip = recordsListContextMenuStrip;
            base.ShowAddNewRecordButton = false;
            base.FilterColumns.AddRange(
                new object[] {
                    "Driver ID",
                    "Person ID",
                    "National No",
                    "Full Name",
                    "Active Licenses"
                }
            );
        }

        protected override void UpdateFilterControlsVisibility()
        {
            SetFilterColumnValue();
            base.FilterTextControlVisible = nudActiveLicenses.Visible = false;

            switch (base.SelectedFilterColumn)
            {
                case "ActiveLicenses":
                    nudActiveLicenses.Location = new Point(nudActiveLicenses.Location.X, 179); ;
                    nudActiveLicenses.Visible = true;

                    if (nudActiveLicenses.Value == 0)
                    {
                        base.FilterText = nudActiveLicenses.Value.ToString();
                    }

                    nudActiveLicenses.Value = 0;
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
                base.RecordsList.Columns["DriverID"].HeaderText = "Driver ID";
                base.RecordsList.Columns["DriverID"].Width = 55;

                base.RecordsList.Columns["PersonID"].HeaderText = "Person ID";
                base.RecordsList.Columns["PersonID"].Width = 55;

                base.RecordsList.Columns["NationalNo"].HeaderText = "National No";
                base.RecordsList.Columns["NationalNo"].Width = 80;

                base.RecordsList.Columns["FullName"].HeaderText = "Full Name";
                base.RecordsList.Columns["FullName"].Width = 200;

                base.RecordsList.Columns["CreatedDate"].HeaderText = "Created Date";
                base.RecordsList.Columns["CreatedDate"].Width = 100;

                base.RecordsList.Columns["ActiveLicenses"].HeaderText = "Active Licenses";
                base.RecordsList.Columns["ActiveLicenses"].Width = 110;
            }
        }

        protected override DataTable GetDataSource()
        {
            return clsDriver.GetAllDrivers();
        }

        private void nudActiveLicenses_ValueChanged(object sender, EventArgs e)
        {
            base.FilterText = nudActiveLicenses.Value.ToString();
        }

        protected override void ShowRecordDetailsOperation()
        {
            frmShowPersonInfo personInfo = new frmShowPersonInfo(_GetFromSelectedRowPersonID());
            personInfo.ShowEditPersonInformationLinke = false;
            personInfo.ShowDialog();
        }

        private void frmManageDrivers_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            base.frmBaseManage_MouseDown(sender, e);
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowRecordDetailsOperation();
        }

        private void issueInternationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsFormMessages.ShowNotImplementedFeatureWarning();
        }

        private void showPersonLicensesHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPersonLicensesHistory licensesHistory = new frmPersonLicensesHistory(_GetFromSelectedRowPersonID());
            licensesHistory.ShowDialog();
        }

        private int _GetFromSelectedRowPersonID()
        {
            return Convert.ToInt32(base.RecordsList.SelectedRows[0].Cells["PersonID"].Value);
        }

        private void recordsListContextMenuStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            clsFormHelper.PreventContextMenuOnHeaderOrEmptySpace(base.RecordsList, e);
        }

    }
}
