using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DVLD.BusinessLogic;
using DVLD.WinForms.BaseForms;
using DVLD.WinForms.Licenses;
using DVLD.WinForms.People;
using DVLD.WinForms.Properties;
using DVLD.WinForms.Utils;

namespace DVLD.WinForms.Applications.InternationalLicense
{
    internal partial class frmManageInternationalLicenses : frmBaseManageWithFilter
    {
        public frmManageInternationalLicenses() : base(clsInternationalLicense.GetAllInternationalLicenses())
        {
            InitializeComponent();
        }

        private void frmManageInternationalLicenses_Load(object sender, EventArgs e)
        {
            _SetValuesToBaseFormControls();
        }

        private void _SetValuesToBaseFormControls()
        {
            base.FormTitle = "Manage International Licenses";
            base.FormLogo = Resources.Applications;
            base.RecordsList.ContextMenuStrip = recordsListContextMenuStrip;
            base.FilterColumns.AddRange(
                new object[] {
                    "International License ID",
                    "Local License ID",
                    "Full Name",
                    "IsActive"
                }
            );
        }

        protected override void UpdateFilterControlsVisibility()
        {
            SetFilterColumnValue();
            base.FilterTextControlVisible = cbActivity.Visible = false;

            switch (base.SelectedFilterColumn)
            {
                case "IsActive":
                    cbActivity.Location = new Point(cbActivity.Location.X, 178);
                    cbActivity.Visible = true;
                    cbActivity.SelectedItem = "All";
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
                base.RecordsList.Columns["InternationalLicenseID"].HeaderText = "International License ID";
                base.RecordsList.Columns["InternationalLicenseID"].Width = 130;

                base.RecordsList.Columns["IssuedUsingLocalLicenseID"].HeaderText = "Local License ID";
                base.RecordsList.Columns["IssuedUsingLocalLicenseID"].Width = 100;

                base.RecordsList.Columns["FullName"].HeaderText = "Full Name";
                base.RecordsList.Columns["FullName"].Width = 200;

                base.RecordsList.Columns["IssueDate"].HeaderText = "Issue Date";
                base.RecordsList.Columns["IssueDate"].Width = 135;

                base.RecordsList.Columns["ExpirationDate"].HeaderText = "Expiration Date";
                base.RecordsList.Columns["ExpirationDate"].Width = 135;

                base.RecordsList.Columns["IsActive"].HeaderText = "Is Active";
                base.RecordsList.Columns["IsActive"].Width = 75;
            }
        }

        protected override void SetFilterColumnValue()
        {
            base.SetFilterColumnValue();

            if (base.SelectedFilterColumn == "LocalLicenseID")
            {
                base.SelectedFilterColumn = "IssuedUsingLocalLicenseID";
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

        protected override DataTable GetDataSource()
        {
            return clsInternationalLicense.GetAllInternationalLicenses();
        }

        protected override void ShowRecordDetailsOperation()
        {
            frmShowInternationalLicenseInfo internationalLicenseInfo = new frmShowInternationalLicenseInfo(_GetSelectedInternationalLicense());
            internationalLicenseInfo.ShowDialog();
        }

        protected override void AddNewRecordOperation()
        {
            frmIsuueInternationalLicense isuueInternationalLicense = new frmIsuueInternationalLicense();
            isuueInternationalLicense.ShowDialog();
        }

        private void cbActivity_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbActivity.SelectedItem)
            {
                case "Yes":
                    base.FilterText = "1";
                    break;
                case "No":
                    base.FilterText = "0";
                    break;
                default:
                    base.FilterText = string.Empty;
                    break;
            }
        }

        private void frmManageInternationalLicenses_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            base.frmBaseManage_MouseDown(sender, e);
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowPersonInfo personInfo = new frmShowPersonInfo(_GetSelectedInternationalLicense().DriverInfo.PersonInfo);
            personInfo.ShowEditPersonInformationLinke = false;
            personInfo.ShowDialog();
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowRecordDetailsOperation();
        }

        private void showPersonLicensesHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPersonLicensesHistory licensesHistory = new frmPersonLicensesHistory(_GetSelectedInternationalLicense().DriverInfo.PersonInfo);
            licensesHistory.ShowDialog();
        }

        private void issueInternationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewRecordOperation();
        }

        private void recordsListContextMenuStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            clsFormHelper.PreventContextMenuOnHeaderOrEmptySpace(base.RecordsList, e);
        }

        private clsInternationalLicense _GetSelectedInternationalLicense()
        {
            return clsInternationalLicense.Find(Convert.ToInt32(clsFormHelper.GetSelectedRowID(base.RecordsList)));
        }

    }
}