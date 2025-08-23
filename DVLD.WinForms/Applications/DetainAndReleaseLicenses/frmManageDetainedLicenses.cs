using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DVLD.BusinessLogic;
using DVLD.WinForms.BaseForms;
using DVLD.WinForms.Licenses;
using DVLD.WinForms.People;
using DVLD.WinForms.Properties;
using DVLD.WinForms.Utils;

namespace DVLD.WinForms.Applications.DetainAndReleaseLicenses
{
    internal partial class frmManageDetainedLicenses : frmBaseManageWithFilter
    {
        public frmManageDetainedLicenses() : base(clsDetainedLicense.GetAllDetainedLicenses())
        {
            InitializeComponent();
        }

        private void frmManageDetainedLicenses_Load(object sender, EventArgs e)
        {
            _SetValuesToBaseFormControls();
        }

        private void _SetValuesToBaseFormControls()
        {
            base.FormTitle = "Manage Detained Licenses";
            base.FormLogo = Resources.Detain_512;
            base.AddNewRecordButtonBackgroumd = Resources.Detain_64;
            base.AddNewRecordButtonBackgroumdLayout = ImageLayout.Zoom;
            base.RecordsList.ContextMenuStrip = recordsListContextMenuStrip;
            base.FilterColumns.AddRange(
                new object[] {
                    "Detain ID",
                    "License ID",
                    "National No",
                    "Full Name",
                    "Is Released"
                }
            );
        }

        protected override void UpdateFilterControlsVisibility()
        {
            SetFilterColumnValue();
            base.FilterTextControlVisible = cbIsReleased.Visible = false;

            switch (base.SelectedFilterColumn)
            {
                case "IsReleased":
                    cbIsReleased.Location = new Point(cbIsReleased.Location.X, 178);
                    cbIsReleased.Visible = true;
                    cbIsReleased.SelectedItem = "All";
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
                base.RecordsList.Columns["DetainID"].HeaderText = "Detain ID";
                base.RecordsList.Columns["DetainID"].Width = 70;

                base.RecordsList.Columns["LicenseID"].HeaderText = "License ID";
                base.RecordsList.Columns["LicenseID"].Width = 70;

                base.RecordsList.Columns["NationalNo"].HeaderText = "National No";
                base.RecordsList.Columns["NationalNo"].Width = 120;

                base.RecordsList.Columns["FullName"].HeaderText = "Full Name";
                base.RecordsList.Columns["FullName"].Width = 200;

                base.RecordsList.Columns["DetainDate"].HeaderText = "Detain Date";
                base.RecordsList.Columns["DetainDate"].Width = 100;

                base.RecordsList.Columns["FineFees"].HeaderText = "Fine Fees";
                base.RecordsList.Columns["FineFees"].Width = 80;

                base.RecordsList.Columns["ReleaseApplicationID"].HeaderText = "Release Application ID";
                base.RecordsList.Columns["ReleaseApplicationID"].Width = 120;

                base.RecordsList.Columns["ReleaseDate"].HeaderText = "Release Date";
                base.RecordsList.Columns["ReleaseDate"].Width = 100;

                base.RecordsList.Columns["IsReleased"].HeaderText = "Is Released";
                base.RecordsList.Columns["IsReleased"].Width = 80;
            }
        }

        protected override DataTable GetDataSource()
        {
            return clsDetainedLicense.GetAllDetainedLicenses();
        }

        private void cbIsReleased_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbIsReleased.SelectedItem)
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

        protected override void ShowRecordDetailsOperation()
        {
            frmShowLicenseInfo licenseInfo = new frmShowLicenseInfo(_GetSelectedLicense());
            licenseInfo.ShowDialog();
        }

        protected override void AddNewRecordOperation()
        {
            frmDetainLicense detainLicense = new frmDetainLicense();
            detainLicense.DetainSuccess += base.RefreshAndReapplyCurrentFilter;
            detainLicense.ShowDialog();
        }

        protected override void dgvRecordsList_MouseDown(object sender, MouseEventArgs e)
        {
            base.dgvRecordsList_MouseDown(sender, e);

            if (e.Button == MouseButtons.Right)
            {
                clsFormHelper.ShowAnotherContextMenuOnEmptySpaceInDGV(base.RecordsList, formContextMenuStrip);
            }
        }

        private void frmManageDetainedLicenses_MouseDown(object sender, MouseEventArgs e)
        {
            base.frmBaseManage_MouseDown(sender, e);
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowPersonInfo personInfo = new frmShowPersonInfo(_GetSelectedLicense().DriverInfo.PersonInfo.PersonID);
            personInfo.ShowEditPersonInformationLinke = false;
            personInfo.ShowDialog();
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowRecordDetailsOperation();
        }

        private void showPersonLicensesHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPersonLicensesHistory licensesHistory = new frmPersonLicensesHistory(_GetSelectedLicense().DriverInfo.PersonInfo.PersonID);
            licensesHistory.ShowDialog();
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicense releaseDetainedLicense = new frmReleaseDetainedLicense();
            releaseDetainedLicense.ReleaseSuccess += base.RefreshAndReapplyCurrentFilter;
            releaseDetainedLicense.ShowDialog();
        }

        private void releaseSelectedDetainedLicensetoolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicense releaseDetainedLicense = new frmReleaseDetainedLicense(_GetSelectedLicenseID());
            releaseDetainedLicense.ReleaseSuccess += base.RefreshAndReapplyCurrentFilter;
            releaseDetainedLicense.ShowDialog();
        }

        private void btnReleaseLicense_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicense releaseDetainedLicense = new frmReleaseDetainedLicense();
            releaseDetainedLicense.ReleaseSuccess += base.RefreshAndReapplyCurrentFilter;
            releaseDetainedLicense.ShowDialog();
        }

        private void detainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewRecordOperation();
        }

        private void recordsListContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            if (clsFormHelper.GetHitTestInfo(base.RecordsList).Type != DataGridViewHitTestType.Cell)
            {
                e.Cancel = true;
                return;
            }

            releaseSelectedDetainedLicensetoolStripMenuItem.Visible = !IsSelectedLicenseReleased();
        }

        private bool IsSelectedLicenseReleased()
        {
            return Convert.ToBoolean(base.RecordsList.SelectedRows[0].Cells["IsReleased"].Value);
        }

        private int _GetSelectedLicenseID()
        {
            return Convert.ToInt32(base.RecordsList.SelectedRows[0].Cells["LicenseID"].Value);
        }

        private clsLicense _GetSelectedLicense()
        {
            return clsLicense.FindByLicenseID(_GetSelectedLicenseID());
        }

    }
}