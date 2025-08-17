using System;
using System.Windows.Forms;
using DVLD.BusinessLogic;
using DVLD.WinForms.Utils;

namespace DVLD.WinForms.Licenses
{
    public partial class ctrDriverLicenses : UserControl
    {
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

    }
}
