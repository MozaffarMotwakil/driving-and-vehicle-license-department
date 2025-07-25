using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DVLD.BusinessLogic;
using DVLD.WinForms.Global;
using DVLD.WinForms.Utils;

namespace DVLD.WinForms.People
{
    public partial class frmManagePeople : Form
    {
        private string _FilterColumn;

        public frmManagePeople()
        {
            InitializeComponent();
        }
        
        private void _ResetPeopleListColumnWidthAndName()
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

        private void frmManagePeople_Load(object sender, EventArgs e)
        {
            cbFiltterColumn.SelectedItem = "None";
            _FilterColumn = "None";
            _RefreshPeopleList();
            _ResetPeopleListColumnWidthAndName();
            cbCountry.Items.AddRange(clsSettings.GetCountries());
        }

        private void _RefreshPeopleList(object DataSource = null)
        {
            if (DataSource == null)
            {
                DataSource = clsPerson.GetAllPeople().DefaultView;
            }
            
            dgvPeopleList.DataSource = DataSource;
            lblRecordsCount.Text = dgvPeopleList.RowCount.ToString();
        }

        private void txtTextForFilttering_TextChanged(object sender, EventArgs e)
        {
            DataView peopleList = (DataView)dgvPeopleList.DataSource;
            string text = txtTextForFilttering.Text;

            // Apply different filter logic based on the selected column.
            // 'LIKE' is used for text columns, '=' for exact ID match.
            if (_FilterColumn != "PersonID")
            {
                peopleList.RowFilter = $"{_FilterColumn} LIKE '{text}%'";
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(text))
                {
                    peopleList.RowFilter = $"{_FilterColumn} = {text}";
                }
                else
                {
                    // If ID filter is empty, show all people again.
                    // Why: To avoid an empty list when the ID filter is cleared.
                    _RefreshPeopleList();
                    return;
                }
            }

            // The DataSource is updated with the filtered DataView.
            // Why: Filtering on the DataView directly is efficient as it works on the
            // already loaded data, avoiding re-querying the database just for filtering.
            _RefreshPeopleList(peopleList);
        }

        private void cbFiltterColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider.SetError(txtTextForFilttering, "");
            txtTextForFilttering.Text = string.Empty;
            _FilterColumn = cbFiltterColumn.Text.Replace(" ", "");

            if (_FilterColumn == "Gender")
            {
                txtTextForFilttering.Visible = false;
                panelGender.Location = new Point(panelGender.Location.X, 180);
                panelGender.Visible = true;
                rbMale.Checked = true;
                return;
            }
            else 
            {
                panelGender.Visible = false;
                txtTextForFilttering.Visible = true;
            }

            if (_FilterColumn == "Nationality")
            {
                txtTextForFilttering.Visible = false;
                cbCountry.Location = new Point(cbCountry.Location.X, 185);
                cbCountry.Visible = true;
                cbCountry.SelectedItem = "None";
                return;
            }
            else
            {
                cbCountry.Visible = false;
                txtTextForFilttering.Visible = true;
            }

            if (_FilterColumn == "None")
            {
                txtTextForFilttering.Enabled = false;
            }
            else
            {
                txtTextForFilttering.Enabled = true;
            }
        }

        private void txtTextForFilttering_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_FilterColumn == "PersonID")
            {
                clsValidation.HandleNumericKeyPress(e, txtTextForFilttering, errorProvider);
            }
            else
            {
                errorProvider.SetError(txtTextForFilttering, "");
            }
        }

        // Select the entire row where the right mouse button was pressed, and check the selected is not column.
        // rather than selecting a single cell because the context menu is on the person, not the cell.
        private void dgvPeopleList_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dgvPeopleList.ClearSelection();
                dgvPeopleList.Rows[e.RowIndex].Selected = true;
                dgvPeopleList.CurrentCell = dgvPeopleList.SelectedRows[0].Cells[0];
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = Convert.ToInt32(dgvPeopleList.CurrentCell.Value);

            if (clsPerson.IsPersonExist(PersonID))
            {
                if (clsMessages.Confirm($"Are you sure do you want delete the person with ID = {PersonID}?", "Confirm Deletion",
                    MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2))
                {
                    try
                    {
                        string ImagePath = clsPerson.Find(PersonID).ImagePath;

                        if (clsPerson.Delete(PersonID))
                        {
                            clsMessages.ShowSuccess($"The person with ID = {PersonID} has been deleted successfully.", "Successfully Deleted");
                            _DeletePersonImage(ImagePath);
                            _RefreshPeopleList();
                        }
                        else
                        {
                             clsMessages.ShowError($"Delete person with ID = {PersonID} failed.", "Failed Deleted");
                        }
                    } 
                    catch
                    {
                         clsMessages.ShowError("Person was not deleted because it has data linked to it.", "Failed Deleted");
                    }
                }
            }
            else
            {
                clsMessages.ShowPersonNotFoundError();
            }
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson addEditPersonForm = new frmAddUpdatePerson();
            addEditPersonForm.MaximizeBox = false;
            addEditPersonForm.ShowDialog();
            _RefreshPeopleList();
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAddNewPerson.PerformClick();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson addEditPersonForm = new frmAddUpdatePerson(Convert.ToInt32(dgvPeopleList.CurrentCell.Value));
            addEditPersonForm.ShowDialog();
            _RefreshPeopleList();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowPersonInfo personDetailsForm = new frmShowPersonInfo(Convert.ToInt32(dgvPeopleList.CurrentCell.Value));
            personDetailsForm.ShowDialog();
            _RefreshPeopleList();
        }
        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsMessages.ShowNotImplementedFeatureWarning();
        }

        private void sToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsMessages.ShowNotImplementedFeatureWarning();
        }

        private void btnCloseScreen_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            txtTextForFilttering.Text = "Male";
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            txtTextForFilttering.Text = "Female";
        }

        private void cbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCountry.SelectedItem.ToString() == "None")
            {
                _RefreshPeopleList();
            }
            else
            {
                txtTextForFilttering.Text = cbCountry.SelectedItem.ToString();
            }
        }

        private void _DeletePersonImage(string ImagePath)
        {
            if (!string.IsNullOrEmpty(ImagePath))
            {
                try
                {
                    clsFileManager.DeletePersonImageFromLocalFolder(ImagePath);
                }
                catch (Exception ex)
                {
                    clsMessages.ShowFailedDeleteThePersonImage(ex);
                }
            }
        }

    }
}