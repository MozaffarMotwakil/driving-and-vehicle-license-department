using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DVLD.BusinessLogic;
using DVLD.WinForms.BaseForms;
using DVLD.WinForms.Properties;
using DVLD.WinForms.Utils;

namespace DVLD.WinForms.People
{
    internal partial class frmManagePeople : frmBaseManageWithFilter
    {
        public frmManagePeople() : base(clsPerson.GetAllPeople())
        {
            InitializeComponent();
        }

        private void frmManagePeople_Load(object sender, EventArgs e)
        {
            _SetValuesToBaseFormControls();
            clsFormHelper.SetDefaultValuesToCountriesComboBox(cbCountry);
        }

        private void _SetValuesToBaseFormControls()
        {
            base.FormTitle = "Manage People";
            base.FormLogo = Resources.People_400;
            base.RecordsList.ContextMenuStrip = recordsListContextMenuStrip;
            base.AddRecordButtonBackgroumd = Resources.Add_Person_40;
            base.FilterColumns.AddRange(
                new object[] {
                    "Person ID",
                    "National No",
                    "First Name",
                    "Second Name",
                    "Third Name",
                    "Last Name",
                    "Gender",
                    "Phone",
                    "Email",
                    "Nationality"
                }
            );
        }

        private void cbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCountry.SelectedIndex == 0)
            {
                base.RecordsCount = clsFormHelper.RefreshDataGridView(base.RecordsList, GetDataSource());
            }
            else
            {
                base.FilterText = cbCountry.SelectedItem.ToString();
            }
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            base.FilterText = "M";
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            base.FilterText = "F";
        }

        private void rocordsListContextMenuStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            clsFormHelper.PreventContextMenuOnHeaderOrEmptySpace(base.RecordsList, e);
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
            return clsPerson.GetAllPeople();
        }

        protected override void ResetRecordsListColumnsWidthAndName()
        {
            if (RecordsCount > 0)
            {
                base.RecordsList.Columns[0].HeaderText = "Person ID";
                base.RecordsList.Columns[0].Width = 80;

                base.RecordsList.Columns[1].HeaderText = "National No.";
                base.RecordsList.Columns[1].Width = 100;

                base.RecordsList.Columns[2].HeaderText = "First Name";
                base.RecordsList.Columns[2].Width = 110;

                base.RecordsList.Columns[3].HeaderText = "Second Name";
                base.RecordsList.Columns[3].Width = 110;

                base.RecordsList.Columns[4].HeaderText = "Third Name";
                base.RecordsList.Columns[4].Width = 110;

                base.RecordsList.Columns[5].HeaderText = "Last Name";
                base.RecordsList.Columns[5].Width = 110;

                base.RecordsList.Columns[6].HeaderText = "Gender";
                base.RecordsList.Columns[6].Width = 60;

                base.RecordsList.Columns[7].HeaderText = "Date Of Birth";
                base.RecordsList.Columns[7].Width = 100;

                base.RecordsList.Columns[8].HeaderText = "Nationality";
                base.RecordsList.Columns[8].Width = 90;

                base.RecordsList.Columns[9].HeaderText = "Phone";
                base.RecordsList.Columns[9].Width = 80;

                base.RecordsList.Columns[10].HeaderText = "Email";
            }
        }

        protected override void UpdateFilterControlsVisibility()
        {
            base.SetFilterColumnValue();

            base.FilterTextControlVisible = cbCountry.Visible =
                panelGender.Visible = false;

            switch (base.SelectedFilterColumn)
            {
                case "Gender":
                    panelGender.Location = new Point(panelGender.Location.X, 173);
                    panelGender.Visible = true;
                    rbMale.Checked = rbFemale.Checked = true;
                    break;
                case "Nationality":
                    cbCountry.Location = new Point(cbCountry.Location.X, 178);
                    cbCountry.Visible = true;
                    cbCountry.SelectedItem = "None";
                    break;
                default:
                    base.DefaultFilterControlsVisibility();
                    break;
            }
        }

        protected override bool DeleteRecord(int recordID)
        {
            return clsPerson.Delete(recordID);
        }

        protected override void AddNewRecordOperation()
        {
            frmAddUpdatePerson addEditPersonForm = new frmAddUpdatePerson();
            addEditPersonForm.ShowDialog();

            if (addEditPersonForm.IsSaveSuccess)
            {
                base.RefreshRecordsList();
                base.ResetFilterColumnToDefault();
            }
        }

        protected override void ShowRecordDetailsOperation()
        {
            frmShowPersonInfo personDetailsForm = new frmShowPersonInfo(clsFormHelper.GetSelectedRowID(base.RecordsList));
            personDetailsForm.ShowDialog();

            if (personDetailsForm.IsInfoModified)
            {
                base.RefreshRecordsList();
                base.ReapplyAndHighlightFilterText();
            }
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowRecordDetailsOperation();
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewRecordOperation();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson EditPersonForm = new frmAddUpdatePerson(clsFormHelper.GetSelectedRowID(base.RecordsList));
            EditPersonForm.ShowDialog();

            if (EditPersonForm.IsSaveSuccess)
            {
                base.RefreshRecordsList();
                base.ReapplyAndHighlightFilterText();
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            base.DeleteRecordOperation();
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsFormMessages.ShowNotImplementedFeatureWarning();
        }

        private void PhoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsFormMessages.ShowNotImplementedFeatureWarning();
        }

    }
}