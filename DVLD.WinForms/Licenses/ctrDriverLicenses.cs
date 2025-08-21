using System;
using System.Windows.Forms;
using DVLD.BusinessLogic;
using DVLD.WinForms.Applications.InternationalLicense;
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
            if (tabControl.SelectedTab == tpLocal)
            {
                lblRecordsCount.Text = dgvLocalLicenses.RowCount.ToString();
            }
            else
            {
                lblRecordsCount.Text = dgvInternationalLicenses.RowCount.ToString();
            }
        }

        public void LoadPersonLicensesForDisplay(clsPerson Person)
        {
            dgvLocalLicenses.DataSource = clsLicense.GetAllLicensesForPerson(Person.PersonID);
            lblRecordsCount.Text = dgvLocalLicenses.RowCount.ToString();
            _ResetLocalLicensesListColumnsWidthAndName();
            dgvInternationalLicenses.DataSource = clsInternationalLicense.GetAllInternationalLicensesForPerson(Person.PersonID);
            _ResetInternatinoalLicensesListColumnsWidthAndName();
        }

        private void _ResetLocalLicensesListColumnsWidthAndName()
        {
            if (dgvLocalLicenses.RowCount > 0)
            {
                dgvLocalLicenses.Columns["LicenseID"].HeaderText = "License ID";
                dgvLocalLicenses.Columns["LicenseID"].Width = 55;

                dgvLocalLicenses.Columns["ApplicationID"].HeaderText = "Application ID";
                dgvLocalLicenses.Columns["ApplicationID"].Width = 65;

                dgvLocalLicenses.Columns["ClassName"].HeaderText = "Class Name";
                dgvLocalLicenses.Columns["ClassName"].Width = 140;

                dgvLocalLicenses.Columns["IssueDate"].HeaderText = "Issue Date";
                dgvLocalLicenses.Columns["IssueDate"].Width = 85;

                dgvLocalLicenses.Columns["ExpirationDate"].HeaderText = "Expiration Date";
                dgvLocalLicenses.Columns["ExpirationDate"].Width = 85;

                dgvLocalLicenses.Columns["IsActive"].HeaderText = "Is Active";
                dgvLocalLicenses.Columns["IsActive"].Width = 65;
            }
        }

        private void _ResetInternatinoalLicensesListColumnsWidthAndName()
        {
            if (dgvInternationalLicenses.RowCount > 0)
            {
                dgvInternationalLicenses.Columns["InternationalLicenseID"].HeaderText = "International License ID";
                dgvInternationalLicenses.Columns["InternationalLicenseID"].Width = 150;

                dgvInternationalLicenses.Columns["ApplicationID"].HeaderText = "Application ID";
                dgvInternationalLicenses.Columns["ApplicationID"].Width = 102;

                dgvInternationalLicenses.Columns["IssuedUsingLocalLicenseID"].HeaderText = "Local License ID";
                dgvInternationalLicenses.Columns["IssuedUsingLocalLicenseID"].Width = 120;

                dgvInternationalLicenses.Columns["IssueDate"].HeaderText = "Issue Date";
                dgvInternationalLicenses.Columns["IssueDate"].Width = 135;

                dgvInternationalLicenses.Columns["ExpirationDate"].HeaderText = "Expiration Date";
                dgvInternationalLicenses.Columns["ExpirationDate"].Width = 135;

                dgvInternationalLicenses.Columns["IsActive"].HeaderText = "Is Active";
                dgvInternationalLicenses.Columns["IsActive"].Width = 75;
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
                frmShowLicenseInfo localLicenseInfo = new frmShowLicenseInfo(clsLicense.FindByLicenseID(clsFormHelper.GetSelectedRowID(dgvLocalLicenses)));
                localLicenseInfo.ShowDialog();
            }
            else
            {
                frmShowInternationalLicenseInfo internationalLicenseInfo = new frmShowInternationalLicenseInfo(clsFormHelper.GetSelectedRowID(dgvInternationalLicenses));
                internationalLicenseInfo.ShowDialog();
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
                frmShowLicenseInfo localLicenseInfo = new frmShowLicenseInfo(clsLicense.FindByLicenseID(clsFormHelper.GetSelectedRowID(dgvLocalLicenses)));
                localLicenseInfo.ShowDialog();
            }
        }

        private void dgvInternationalLicenses_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            clsFormHelper.SelectEntireRow(dgvInternationalLicenses, e);

            if (clsFormHelper.GetHitTestInfo(dgvLocalLicenses).Type == DataGridViewHitTestType.Cell && e.Button == MouseButtons.Left)
            {
                frmShowInternationalLicenseInfo internationalLicenseInfo = new frmShowInternationalLicenseInfo(clsFormHelper.GetSelectedRowID(dgvInternationalLicenses));
                internationalLicenseInfo.ShowDialog();
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
