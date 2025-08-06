using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DVLD.BusinessLogic;
using DVLD.WinForms.Utils;

namespace DVLD.WinForms.People
{
    public partial class frmManagePeople : Form
    {
        private string _FilterColumn;
        private DataView _DataSource;

        private int _RecordsCount
        {
            get { return int.Parse(lblRecordsCount.Text); }
            set { lblRecordsCount.Text = value.ToString(); }
        }

        public frmManagePeople()
        {
            InitializeComponent();
            cbFiltterColumn.SelectedItem = "None";
            _FilterColumn = "None";
            _DataSource = clsPerson.GetAllPeople().DefaultView;
            _RecordsCount = clsFormHelper.RefreshDataGridView(dgvPeopleList, _DataSource);
        }

        private void frmManagePeople_Load(object sender, EventArgs e)
        {
            _ResetPeopleListColumnsWidthAndName();
            cbCountry.Items.AddRange(clsAppSettings.GetCountries());
        }

        private void txtTextForFilttering_TextChanged(object sender, EventArgs e)
        {
            _RecordsCount = clsFormHelper.RefreshDataGridViewWithFilter(dgvPeopleList, _DataSource, _FilterColumn, txtTextForFilttering.Text);
        }

        private void cbFiltterColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            _UpdateFilterControlVisibility();
        }

        private void txtTextForFilttering_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_FilterColumn == "PersonID")
            {
                clsFormValidation.HandleNumericKeyPress(e, txtTextForFilttering, errorProvider);
            }
            else
            {
                errorProvider.SetError(txtTextForFilttering, "");
            }
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            txtTextForFilttering.Text = "M";
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            txtTextForFilttering.Text = "F";
        }

        private void cbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCountry.SelectedItem.ToString() == "None")
            {
                _RecordsCount = clsFormHelper.RefreshDataGridView(dgvPeopleList, _DataSource);
            }
            else
            {
                txtTextForFilttering.Text = cbCountry.SelectedItem.ToString();
            }
        }

        private void dgvPeopleList_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            clsFormHelper.SelectEntireRow(dgvPeopleList, e);
            contextMenuStrip.Items["addNewPersonToolStripMenuItem"].Visible = false;
        }

        private void dgvPeopleList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            clsFormHelper.SelectEntireRow(dgvPeopleList, e);
            showDetailsToolStripMenuItem.PerformClick();
        }

        private void dgvPeopleList_MouseDown(object sender, MouseEventArgs e)
        {
            clsFormHelper.DeselectCellsAndRows(dgvPeopleList, e);
            _AdjustPersonListContextMenuVisibility(e);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = clsFormHelper.GetSelectedRowID(dgvPeopleList);

            if (clsFormMessages.Confirm($"Are you sure do you want delete the person with ID = {PersonID}?", 
                "Confirm Deletion", MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2))
            {
                try
                {
                    if (clsPerson.Delete(PersonID))
                    {
                        clsFormMessages.ShowSuccess("Deleted successfully.");
                        _RefreshPeopleList();
                    }
                    else
                    {
                        clsFormMessages.ShowPersonNotFoundError();
                    }
                } 
                catch
                {
                        clsFormMessages.ShowError("Person was not deleted because it has data linked to it.", "Failed Deleted");
                }
            }
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson addEditPersonForm = new frmAddUpdatePerson();
            addEditPersonForm.ShowDialog();
            
            if (addEditPersonForm.IsSaveSuccess)
            {
                _RefreshPeopleList();
            }
        }

        private void btnCloseScreen_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAddNewPerson.PerformClick();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson EditPersonForm = new frmAddUpdatePerson(clsFormHelper.GetSelectedRowID(dgvPeopleList));
            EditPersonForm.ShowDialog();

            if (EditPersonForm.IsSaveSuccess)
            {
                _RefreshPeopleList();
                clsFormHelper.ReapplyAndHighlightFilterText(txtTextForFilttering);
            }
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowPersonInfo personDetailsForm = new frmShowPersonInfo(clsFormHelper.GetSelectedRowID(dgvPeopleList));
            personDetailsForm.ShowDialog();

            if (personDetailsForm.IsInfoModified)
            {
                _RefreshPeopleList();
                clsFormHelper.ReapplyAndHighlightFilterText(txtTextForFilttering);
            }
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsFormMessages.ShowNotImplementedFeatureWarning();
        }

        private void sToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsFormMessages.ShowNotImplementedFeatureWarning();
        }

        private void _AdjustPersonListContextMenuVisibility(MouseEventArgs e)
        {
            DataGridView.HitTestInfo hit = dgvPeopleList.HitTest(e.X, e.Y);

            if (e.Button == MouseButtons.Right && hit.Type == DataGridViewHitTestType.None ||
                hit.Type == DataGridViewHitTestType.ColumnHeader)
            {
                foreach (ToolStripItem item in contextMenuStrip.Items)
                {
                    contextMenuStrip.Items["addNewPersonToolStripMenuItem"].Visible = true;

                    if (item.Text != "Add New Person")
                    {
                        item.Visible = false;
                    }
                }
            }
            else
            {
                foreach (ToolStripItem item in contextMenuStrip.Items)
                {
                    item.Visible = true;
                }
            }
        }

        private void _UpdateFilterControlVisibility()
        {
            txtTextForFilttering.Text = string.Empty;
            _FilterColumn = cbFiltterColumn.Text.Replace(" ", "");

            txtTextForFilttering.Visible = cbCountry.Visible =
                panelGender.Visible = false;

            switch (_FilterColumn)
            {
                case "Gender":
                    panelGender.Location = new Point(panelGender.Location.X, 180);
                    panelGender.Visible = true;
                    rbMale.Checked = true;
                    break;
                case "Nationality":
                    cbCountry.Location = new Point(cbCountry.Location.X, 185);
                    cbCountry.Visible = true;
                    cbCountry.SelectedItem = "None";
                    break;
                default:
                    txtTextForFilttering.Visible = true;
                    txtTextForFilttering.Enabled = !(_FilterColumn == "None");
                    txtTextForFilttering.Focus();
                    break;
            }
        }

        private void _ResetPeopleListColumnsWidthAndName()
        {
            if (dgvPeopleList.Rows.Count > 0)
            {

                dgvPeopleList.Columns[0].HeaderText = "Person ID";
                dgvPeopleList.Columns[0].Width = 80;

                dgvPeopleList.Columns[1].HeaderText = "National No.";
                dgvPeopleList.Columns[1].Width = 100;

                dgvPeopleList.Columns[2].HeaderText = "First Name";
                dgvPeopleList.Columns[2].Width = 110;

                dgvPeopleList.Columns[3].HeaderText = "Second Name";
                dgvPeopleList.Columns[3].Width = 110;


                dgvPeopleList.Columns[4].HeaderText = "Third Name";
                dgvPeopleList.Columns[4].Width = 110;

                dgvPeopleList.Columns[5].HeaderText = "Last Name";
                dgvPeopleList.Columns[5].Width = 110;

                dgvPeopleList.Columns[6].HeaderText = "Gender";
                dgvPeopleList.Columns[6].Width = 60;

                dgvPeopleList.Columns[7].HeaderText = "Date Of Birth";
                dgvPeopleList.Columns[7].Width = 100;

                dgvPeopleList.Columns[8].HeaderText = "Nationality";
                dgvPeopleList.Columns[8].Width = 90;


                dgvPeopleList.Columns[9].HeaderText = "Phone";
                dgvPeopleList.Columns[9].Width = 80;


                dgvPeopleList.Columns[10].HeaderText = "Email";
            }

        }

        private void _RefreshPeopleList()
        {
            _DataSource = clsPerson.GetAllPeople().DefaultView;
            _RecordsCount = clsFormHelper.RefreshDataGridView(dgvPeopleList, _DataSource);
        }

    }
}