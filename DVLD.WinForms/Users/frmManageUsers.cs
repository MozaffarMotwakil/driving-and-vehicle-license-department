using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DVLD.BusinessLogic;
using DVLD.WinForms.Global;
using DVLD.WinForms.Users;
using DVLD.WinForms.Utils;

namespace DVLD.WinForms.People
{
    public partial class frmManageUsers : Form
    {
        private string _FilterColumn;

        private DataView _DataSource;
        private int _RecordsCount
        {
            get { return int.Parse(lblRecordsCount.Text); }
            set { lblRecordsCount.Text = value.ToString(); }
        }

        public frmManageUsers()
        {
            InitializeComponent();
        }

        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            cbFiltterColumn.SelectedItem = "None";
            _FilterColumn = "None";
            _DataSource = clsUser.GetAllUsers().DefaultView;
            _RecordsCount = clsSettings.RefreshDataGridView(dgvUsersList, _DataSource);
            _ResetUsersListColumnsWidth();
            cbCountry.Items.AddRange(clsSettings.GetCountries());
        }

        private void _ResetUsersListColumnsWidth()
        {
            dgvUsersList.Columns["UserID"].HeaderText = "User ID";
            dgvUsersList.Columns["UserID"].Width = 70;

            dgvUsersList.Columns["PersonID"].HeaderText = "Person ID";
            dgvUsersList.Columns["PersonID"].Width = 70;

            dgvUsersList.Columns["Username"].Width = 100;

            dgvUsersList.Columns["FullName"].HeaderText = "Full Name";
            dgvUsersList.Columns["FullName"].Width = 200;

            dgvUsersList.Columns["Gender"].Width = 80;

            dgvUsersList.Columns["Nationality"].Width = 100;

            dgvUsersList.Columns["IsActive"].HeaderText = "Is Active";
            dgvUsersList.Columns["IsActive"].Width = 80;
        }

        private void cbFiltterColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTextForFilttering.Text = string.Empty;
            _FilterColumn = cbFiltterColumn.Text.Replace(" ", "");

            txtTextForFilttering.Visible = false;
            cbCountry.Visible = false;
            panelGender.Visible = false;
            cbActivity.Visible = false;

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

            if (_FilterColumn == "IsActive")
            {
                cbActivity.Location = new Point(cbCountry.Location.X, 185);
                cbActivity.Visible = true;
                cbActivity.SelectedItem = "All";
                return;
            }

            txtTextForFilttering.Visible = true;
            txtTextForFilttering.Enabled = !(_FilterColumn == "None");
            txtTextForFilttering.Focus();
        }

        private void txtTextForFilttering_TextChanged(object sender, EventArgs e)
        {
            _RecordsCount = clsSettings.RefreshDataGridViewWithFiltter(dgvUsersList, _DataSource, _FilterColumn, txtTextForFilttering.Text);
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
                txtTextForFilttering.Text = string.Empty;
            }
            else
            {
                txtTextForFilttering.Text = cbCountry.SelectedItem.ToString();
            }
        }

        private void cbActivity_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbActivity.SelectedItem)
            {
                case "All":
                    txtTextForFilttering.Text = string.Empty;
                    break;
                case "Yes":
                    txtTextForFilttering.Text = "1";
                    break;
                default:
                    txtTextForFilttering.Text = "0";
                    break;
            }
        }

        private void txtTextForFilttering_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_FilterColumn.EndsWith("ID"))
            {
                clsValidation.HandleNumericKeyPress(e, txtTextForFilttering, errorProvider);
            }
            else
            {
                errorProvider.SetError(txtTextForFilttering, "");
            }
        }

        private void btnCloseScreen_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser addUserForm = new frmAddUpdateUser();
            addUserForm.ShowDialog();

            if (addUserForm.IsSaveSuccess)
            {
                _DataSource = clsUser.GetAllUsers().DefaultView;
                clsSettings.RefreshDataGridView(dgvUsersList, _DataSource);
            }
        }

        private void dgvUsersList_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            clsSettings.SelecteEntireRow(dgvUsersList, e);
        }

        private void dgvUsersList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            clsSettings.SelecteEntireRow(dgvUsersList, e);
            showDetailsToolStripMenuItem.PerformClick();
        }

        private void dgvUsersList_MouseDown(object sender, MouseEventArgs e)
        {
            clsSettings.DeselectCellsAndRows(dgvUsersList, e);
            _AdjustUserListContextMenuVisibility(e);
        }

        // This function's logic is kept separate from the 'Persons' context menu logic
        // (_AdjustPersonListContextMenuVisibility in frmManagePeople) to accommodate
        // anticipated future divergence in display rules and permission-based requirements
        // specific to users, ensuring better maintainability and extensibility.
        private void _AdjustUserListContextMenuVisibility(MouseEventArgs e)
        {
            DataGridView.HitTestInfo hit = dgvUsersList.HitTest(e.X, e.Y);

            if (e.Button == MouseButtons.Right && hit.Type == DataGridViewHitTestType.None ||
                hit.Type == DataGridViewHitTestType.ColumnHeader)
            {
                foreach (ToolStripItem item in contextMenuStrip.Items)
                {
                    if (item.Text != "Add New User")
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

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowUserInfo userInfo = new frmShowUserInfo(clsSettings.GetSelectedRowID(dgvUsersList));
            userInfo.ShowDialog();

            if (userInfo.IsInfoModified)
            {
                _DataSource = clsUser.GetAllUsers().DefaultView;
                clsSettings.RefreshDataGridView(dgvUsersList, _DataSource);
            }
        }

        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAddNewUser.PerformClick();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser updateUser = new frmAddUpdateUser(clsSettings.GetSelectedRowID(dgvUsersList));
            updateUser.ShowDialog();

            if (updateUser.IsSaveSuccess)
            {
                _DataSource = clsUser.GetAllUsers().DefaultView;
                clsSettings.RefreshDataGridView(dgvUsersList, _DataSource);
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = clsSettings.GetSelectedRowID(dgvUsersList);

            if (clsUser.IsUserExist(UserID))
            {
                if (clsMessages.Confirm($"Are you sure do you want delete the user with ID = {UserID}?",
                    "Confirm Deletion", MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2))
                {
                    try
                    {
                        if (clsUser.Delete(UserID))
                        {
                            clsMessages.ShowSuccess("Deleted successfully.");
                            _DataSource = clsUser.GetAllUsers().DefaultView;
                            _RecordsCount = clsSettings.RefreshDataGridView(dgvUsersList, _DataSource);
                        }
                        else
                        {
                            clsMessages.ShowError("Failed Deleted.");
                        }
                    }
                    catch (Exception)
                    {
                        clsMessages.ShowError("User was not deleted because it has data linked to it.", "Failed Deleted");
                    }
                }
            }
            else
            {
                clsMessages.ShowPersonNotFoundError();
            }
        }

        private void ChangePasswordtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword changePassword = new frmChangePassword(clsSettings.GetSelectedRowID(dgvUsersList));
            changePassword.ShowDialog();

            if (changePassword.IsSaveSuccess)
            {
                _DataSource = clsUser.GetAllUsers().DefaultView;
                clsSettings.RefreshDataGridView(dgvUsersList, _DataSource);
            }
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsMessages.ShowNotImplementedFeatureWarning();
        }

        private void sToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsMessages.ShowNotImplementedFeatureWarning();
        }

    }
}
