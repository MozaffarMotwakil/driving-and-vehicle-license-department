using System;
using System.Data;
using System.Windows.Forms;
using DVLD.BusinessLogic;
using DVLD.WinForms.Utils;

namespace DVLD.WinForms.People
{
    public partial class frmManagePeople : Form
    {
        public frmManagePeople()
        {
            InitializeComponent();
        }
        
        private void frmManagePeople_Load(object sender, EventArgs e)
        {
            cbFiltteringColumn.SelectedItem = "None";
            _RefreshPeopleList();
        }

        private void _RefreshPeopleList()
        {
            dgvPeopleList.DataSource = clsPerson.GetAllPeople().DefaultView;
            lblTotalRecordsCount.Text = dgvPeopleList.RowCount.ToString();
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson addEditPersonForm = new frmAddUpdatePerson();
            addEditPersonForm.MaximizeBox = false;
            addEditPersonForm.ShowDialog();
            _RefreshPeopleList();
        }

        private void btnCloseScreen_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtTextForFilttering_TextChanged(object sender, EventArgs e)
        {
            DataView peopleList = (DataView)dgvPeopleList.DataSource;
            string columnName = cbFiltteringColumn.Text.Replace(" ", "");
            string text = txtTextForFilttering.Text;

            if (cbFiltteringColumn.SelectedItem != "Person ID")
            {
                peopleList.RowFilter = $"{columnName} LIKE '{text}%'";
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(text))
                {
                    peopleList.RowFilter = $"{columnName} = {text}";
                }
                else
                {
                    _RefreshPeopleList();
                    return;
                }
            }

            dgvPeopleList.DataSource = peopleList;
        }

        private void txtTextForFilttering_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFiltteringColumn.SelectedItem == "Person ID" && !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Unaccept the input and turn on the warning bell
                e.Handled = true;
                System.Media.SystemSounds.Asterisk.Play();
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
                        if (clsPerson.Delete(PersonID))
                        {
                             clsMessages.ShowSuccess($"The person with ID = {PersonID} has been deleted successfully.", "Successfully Deleted");
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

        private void _NotImplementedFeatureMessage()
        {
             clsMessages.ShowWarning("This feature is not implemented yet.", "Not Implemented Feature");
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _NotImplementedFeatureMessage();
        }

        private void sToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _NotImplementedFeatureMessage();
        }

        private void cbFiltteringColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFiltteringColumn.SelectedItem == "None")
            {
                txtTextForFilttering.Enabled = false;
            }
            else
            {
                txtTextForFilttering.Enabled = true;
            }
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowPersonInfo personDetailsForm = new frmShowPersonInfo(Convert.ToInt32(dgvPeopleList.CurrentCell.Value));
            personDetailsForm.ShowDialog();
            _RefreshPeopleList();
        }
    }
}