using System;
using System.Data;
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
        
        private void frmManagePeople_Load(object sender, EventArgs e)
        {
            cbFiltteringColumn.SelectedItem = "None";
            _FilterColumn = "None";
            _RefreshPeopleList();
        }

        private void _RefreshPeopleList()
        {
            dgvPeopleList.DataSource = clsPerson.GetAllPeople().DefaultView;
            lblTotalRecordsCount.Text = dgvPeopleList.RowCount.ToString();
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
            dgvPeopleList.DataSource = peopleList;
        }

        private void cbFiltteringColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTextForFilttering.Text = string.Empty;
            _FilterColumn = cbFiltteringColumn.Text.Replace(" ", "");

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
            if (_FilterColumn == "PersonID" && !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Unaccept the input and turn on the warning bell
                e.Handled = true;
                System.Media.SystemSounds.Asterisk.Play();
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
                        clsPerson person = clsPerson.Find(PersonID);


                        if (clsPerson.Delete(PersonID))
                        {
                             clsMessages.ShowSuccess($"The person with ID = {PersonID} has been deleted successfully.", "Successfully Deleted");

                            if (!string.IsNullOrEmpty(person.ImagePath))
                            {
                                try
                                {
                                    clsSettings.DeletePersonImageFromLocalFolder(person.ImagePath);
                                }
                                catch (Exception ex)
                                {
                                    clsMessages.ShowFailedDeleteOldPersonImage(ex);
                                }
                            }

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

    }
}