using System;
using System.Windows.Forms;
using DVLD.BusinessLogic;
using DVLD.WinForms.Utils;

namespace DVLD.WinForms.Licenses
{
    public partial class ctrDriverLicenses : UserControl
    {
        public DataGridView LocalLicenses { get { return dgvLocalLicenses; } }
        public DataGridView InternationalLicenses { get { return dgvInternationalLicenses; } }

        public ctrDriverLicenses()
        {
            InitializeComponent();
        }

        private void tabControl_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (tabControl.SelectedIndex == 1)
            {
                clsFormMessages.ShowNotImplementedFeatureWarning();
                e.Cancel = true;
                return;
            }
        }

        public void LoadPersonLicensesForDisplay(clsPerson Person)
        {
            dgvLocalLicenses.DataSource = clsLicense.GetAllLicensesForPerson(Person.PersonID);
            lblRecordsCount.Text = dgvLocalLicenses.RowCount.ToString();
            _ResetLicensesListColumnsWidthAndName(dgvLocalLicenses);
            
            /// International licenses class not completed yet.
            /// 
            ///
            _ResetLicensesListColumnsWidthAndName(dgvInternationalLicenses);
        }

        private void _ResetLicensesListColumnsWidthAndName(DataGridView dataGridView)
        {
            if (dataGridView.RowCount > 0)
            {
                dataGridView.Columns["LicenseID"].HeaderText = "License ID";
                dataGridView.Columns["LicenseID"].Width = 55;

                dataGridView.Columns["ApplicationID"].HeaderText = "Application ID";
                dataGridView.Columns["ApplicationID"].Width = 65;

                dataGridView.Columns["ClassName"].HeaderText = "Class Name";
                dataGridView.Columns["ClassName"].Width = 140;

                dataGridView.Columns["IssueDate"].HeaderText = "Issue Date";
                dataGridView.Columns["IssueDate"].Width = 85;

                dataGridView.Columns["ExpirationDate"].HeaderText = "Expiration Date";
                dataGridView.Columns["ExpirationDate"].Width = 85;

                dataGridView.Columns["IsActive"].HeaderText = "Is Active";
                dataGridView.Columns["IsActive"].Width = 65;
            }
        }

        private void dgvLocalLicenses_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            clsFormHelper.SelectEntireRow(dgvLocalLicenses, e);
        }

        private void dgvInternationalLicenses_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            clsFormHelper.SelectEntireRow(dgvInternationalLicenses, e);
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab == tpLocal)
            {
                frmShowLicenseInfo licenseInfo = new frmShowLicenseInfo(clsLicense.FindByLicenseID(clsFormHelper.GetSelectedRowID(dgvLocalLicenses)));
                licenseInfo.ShowDialog();
            }
            else
            {
                frmShowLicenseInfo licenseInfo = new frmShowLicenseInfo(clsLicense.FindByLicenseID(clsFormHelper.GetSelectedRowID(dgvInternationalLicenses)));
                licenseInfo.ShowDialog();
            }
        }

        private void licensesListContextMenuStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (tabControl.SelectedTab == tpLocal)
            {
                clsFormHelper.PreventContextMenuOnHeaderOrEmptySpace(dgvLocalLicenses, e);
            }
            else
            {
                clsFormHelper.PreventContextMenuOnHeaderOrEmptySpace(dgvInternationalLicenses, e);
            }
        }

        private void dgvLocalLicenses_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            clsFormHelper.SelectEntireRow(dgvLocalLicenses, e);

            if (clsFormHelper.GetHitTestInfo(dgvLocalLicenses).Type == DataGridViewHitTestType.Cell && e.Button == MouseButtons.Left)
            {
                frmShowLicenseInfo licenseInfo = new frmShowLicenseInfo(clsLicense.FindByLicenseID(clsFormHelper.GetSelectedRowID(dgvLocalLicenses)));
                licenseInfo.ShowDialog();
            }
        }

        private void dgvInternationalLicenses_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            clsFormHelper.SelectEntireRow(dgvLocalLicenses, e);

            if (clsFormHelper.GetHitTestInfo(dgvLocalLicenses).Type == DataGridViewHitTestType.Cell && e.Button == MouseButtons.Left)
            {
                frmShowLicenseInfo licenseInfo = new frmShowLicenseInfo(clsLicense.FindByLicenseID(clsFormHelper.GetSelectedRowID(dgvInternationalLicenses)));
                licenseInfo.ShowDialog();
            }
        }

        private void dgvLocalLicenses_MouseDown(object sender, MouseEventArgs e)
        {
            clsFormHelper.ClearSelectionOnEmptyClick(dgvLocalLicenses, e);
        }

        private void dgvInternationalLicenses_MouseDown(object sender, MouseEventArgs e)
        {
            clsFormHelper.ClearSelectionOnEmptyClick(dgvInternationalLicenses, e);
        }

        private void dgvLocalLicenses_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvLocalLicenses.ClearSelection();
        }

        private void dgvInternationalLicenses_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvInternationalLicenses.ClearSelection();
        }

    }
}
