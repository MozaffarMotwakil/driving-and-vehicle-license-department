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
        private DataView _DataSource;

        private int _RecordsCount
        {
            get { return int.Parse(lblRecordsCount.Text); }
            set { lblRecordsCount.Text = value.ToString(); }
        }

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
            _DataSource = clsPerson.GetAllPeople().DefaultView;
            _RecordsCount = clsAppSettings.RefreshDataGridView(dgvPeopleList, _DataSource);
            _ResetPeopleListColumnWidthAndName();
            cbCountry.Items.AddRange(clsAppSettings.GetCountries());
        }

        private void txtTextForFilttering_TextChanged(object sender, EventArgs e)
        {
            _RecordsCount = clsAppSettings.RefreshDataGridViewWithFilter(dgvPeopleList, _DataSource, _FilterColumn, txtTextForFilttering.Text);
        }

        private void cbFiltterColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTextForFilttering.Text = string.Empty;
            _FilterColumn = cbFiltterColumn.Text.Replace(" ", "");

            txtTextForFilttering.Visible = false;
            cbCountry.Visible = false;
            panelGender.Visible = false;

            if (_FilterColumn == "Gender")
            {
                panelGender.Location = new Point(panelGender.Location.X, 180);
                panelGender.Visible = true;
                rbMale.Checked = true;
                return;
            }

            if (_FilterColumn == "Nationality")
            {
                cbCountry.Location = new Point(cbCountry.Location.X, 185);
                cbCountry.Visible = true;
                cbCountry.SelectedItem = "None";
                return;
            }

            txtTextForFilttering.Visible = true;
            txtTextForFilttering.Enabled = !(_FilterColumn == "None");
            txtTextForFilttering.Focus();
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

        private void dgvPeopleList_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            clsAppSettings.SelectEntireRow(dgvPeopleList, e);
        }

        private void dgvPeopleList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            clsAppSettings.SelectEntireRow(dgvPeopleList, e);
            showDetailsToolStripMenuItem.PerformClick();
        }

        private void dgvPeopleList_MouseDown(object sender, MouseEventArgs e)
        {
            clsAppSettings.DeselectCellsAndRows(dgvPeopleList, e);
            _AdjustPersonListContextMenuVisibility(e);
        }

        private void _AdjustPersonListContextMenuVisibility(MouseEventArgs e)
        {
            DataGridView.HitTestInfo hit = dgvPeopleList.HitTest(e.X, e.Y);

            if (e.Button == MouseButtons.Right && hit.Type == DataGridViewHitTestType.None ||
                hit.Type == DataGridViewHitTestType.ColumnHeader)
            {
                foreach (ToolStripItem item in contextMenuStrip.Items)
                {
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

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = clsAppSettings.GetSelectedRowID(dgvPeopleList);

            if (clsPerson.IsPersonExist(PersonID))
            {
                if (clsMessages.Confirm($"Are you sure do you want delete the person with ID = {PersonID}?", 
                    "Confirm Deletion", MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2))
                {
                    try
                    {
                        string ImagePath = clsPerson.Find(PersonID).ImagePath;

                        if (clsPerson.Delete(PersonID))
                        {
                            clsMessages.ShowSuccess("Deleted successfully.");
                            _DeletePersonImage(ImagePath);
                            _DataSource = clsPerson.GetAllPeople().DefaultView;
                            _RecordsCount = clsAppSettings.RefreshDataGridView(dgvPeopleList, _DataSource);
                        }
                        else
                        {
                            clsMessages.ShowError("Failed Deleted.");
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
            addEditPersonForm.ShowDialog();
            
            if (addEditPersonForm.IsSaveSuccess)
            {
                _DataSource = clsPerson.GetAllPeople().DefaultView;
                _RecordsCount = clsAppSettings.RefreshDataGridView(dgvPeopleList, _DataSource);
            }
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAddNewPerson.PerformClick();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson addEditPersonForm = new frmAddUpdatePerson(clsAppSettings.GetSelectedRowID(dgvPeopleList));
            addEditPersonForm.ShowDialog();
            _RefreshPeopleListIfPersonModified(addEditPersonForm.IsSaveSuccess);
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowPersonInfo personDetailsForm = new frmShowPersonInfo(clsAppSettings.GetSelectedRowID(dgvPeopleList));
            personDetailsForm.ShowDialog();
            _RefreshPeopleListIfPersonModified(personDetailsForm.IsInfoModified);
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
                _RecordsCount = clsAppSettings.RefreshDataGridView(dgvPeopleList, _DataSource);
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

        /// <summary>
        /// Updates the people list only if the person's data has been modified (e.g., after editing or viewing details).
        /// This ensures the UI stays in sync with the database.
        /// Also, if a filter text is applied, the list is refreshed based on the same filter to maintain the user experience.
        /// </summary>
        /// <param name="isPersonModified">
        /// A flag indicating whether the person data has been modified.
        /// If true, the list will be refreshed accordingly.
        /// </param>
        private void _RefreshPeopleListIfPersonModified(bool isPersonModified)
        {
            if (isPersonModified)
            {
                // If the data has been successfully saved, then the database has been updated,
                // so we need to refresh the people list to reflect the latest changes.
                _DataSource = clsPerson.GetAllPeople().DefaultView;
                _RecordsCount = clsAppSettings.RefreshDataGridView(dgvPeopleList, _DataSource);

                // If there's a filter text entered, it means the list is currently filtered
                // (e.g., by gender, country, ID, etc.), so we reapply the filter after reloading the data.
                if (!string.IsNullOrEmpty(txtTextForFilttering.Text))
                {
                    // To reapply the filter, we clear the textbox then reassign the original text.
                    // This will trigger txtTextForFilttering_TextChanged event.
                    // Don't worry — this method is optimized not to fetch data from the database again
                    // when assigning an empty string. It simply re-filters the existing list in memory.
                    string temp = txtTextForFilttering.Text;
                    txtTextForFilttering.Text = string.Empty;
                    txtTextForFilttering.Text = temp;

                    //The purpose of highlighting text is to provide a seamless user experience
                    //so that when someone has finished querying, we highlight the text
                    //so that they can delete it by simply typing over it, such as deleting,
                    //or if they want to press the arrows to move and edit it.
                    txtTextForFilttering.SelectionStart = 0;
                    txtTextForFilttering.SelectionLength = txtTextForFilttering.TextLength;
                }
            }
        }

    }
}