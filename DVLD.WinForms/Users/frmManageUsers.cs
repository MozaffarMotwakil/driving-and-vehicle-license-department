using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DVLD.BusinessLogic;
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
            cbFiltterColumn.SelectedItem = "None";
            _FilterColumn = "None";
            _DataSource = clsUser.GetAllUsers().DefaultView;
            _RecordsCount = clsFormHelper.RefreshDataGridView(dgvUsersList, _DataSource);
        }

        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            _ResetUsersListColumnsWidthAndName();
            cbCountry.Items.AddRange(clsAppSettings.GetCountries());
        }

        private void cbFiltterColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            _UpdateFilterControlVisibility();
        }

        private void txtTextForFilttering_TextChanged(object sender, EventArgs e)
        {
            _RecordsCount = clsFormHelper.RefreshDataGridViewWithFilter(dgvUsersList, _DataSource, _FilterColumn, txtTextForFilttering.Text);
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
                clsFormValidation.HandleNumericKeyPress(e, txtTextForFilttering, errorProvider);
            }
            else
            {
                errorProvider.SetError(txtTextForFilttering, "");
            }
        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser addUserForm = new frmAddUpdateUser();
            addUserForm.ShowDialog();

            if (addUserForm.IsSaveSuccess)
            {
                _RefreshUserList();
            }
        }

        private void btnCloseScreen_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvUsersList_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            clsFormHelper.SelectEntireRow(dgvUsersList, e);
            contextMenuStrip.Items["addNewUserToolStripMenuItem"].Visible = false;
        }

        private void dgvUsersList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            clsFormHelper.SelectEntireRow(dgvUsersList, e);
            showDetailsToolStripMenuItem.PerformClick();
        }

        private void dgvUsersList_MouseDown(object sender, MouseEventArgs e)
        {
            clsFormHelper.DeselectCellsAndRows(dgvUsersList, e);
            _AdjustUserListContextMenuVisibility(e);
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowUserInfo userInfo = new frmShowUserInfo(clsFormHelper.GetSelectedRowID(dgvUsersList));
            userInfo.ShowDialog();

            if (userInfo.IsInfoModified)
            {
                _RefreshUserList();
                clsFormHelper.ReapplyAndHighlightFilterText(txtTextForFilttering);
            }
        }

        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAddNewUser.PerformClick();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser updateUser = new frmAddUpdateUser(clsFormHelper.GetSelectedRowID(dgvUsersList));
            updateUser.ShowDialog();

            if (updateUser.IsSaveSuccess)
            {
                _RefreshUserList();
                clsFormHelper.ReapplyAndHighlightFilterText(txtTextForFilttering);
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = clsFormHelper.GetSelectedRowID(dgvUsersList);

            if (clsFormMessages.Confirm($"Are you sure do you want delete the user with ID = {UserID}?",
                "Confirm Deletion", MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2))
            {
                try
                {
                    if (clsUser.Delete(UserID))
                    {
                        clsFormMessages.ShowSuccess("Deleted successfully.");
                        _RefreshUserList();
                    }
                    else
                    {
                        clsFormMessages.ShowUserNotFoundError();
                    }
                }
                catch (Exception)
                {
                    clsFormMessages.ShowError("User was not deleted because it has data linked to it.", "Failed Deleted");
                }
            }
        }

        private void ChangePasswordtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword changePassword = new frmChangePassword(clsFormHelper.GetSelectedRowID(dgvUsersList));
            changePassword.ShowDialog();

            if (changePassword.IsSaveSuccess)
            {
                _RefreshUserList();
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
                contextMenuStrip.Items["addNewUserToolStripMenuItem"].Visible = true;

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

        private void _UpdateFilterControlVisibility()
        {
            txtTextForFilttering.Text = string.Empty;
            _FilterColumn = cbFiltterColumn.Text.Replace(" ", "");

            txtTextForFilttering.Visible = cbCountry.Visible =
                panelGender.Visible = cbActivity.Visible = false;

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
                case "IsActive":
                    cbActivity.Location = new Point(cbCountry.Location.X, 185);
                    cbActivity.Visible = true;
                    cbActivity.SelectedItem = "All";
                    break;
                default:
                    txtTextForFilttering.Visible = true;
                    txtTextForFilttering.Enabled = !(_FilterColumn == "None");
                    txtTextForFilttering.Focus();
                    break;
            }
            
        }

        private void _ResetUsersListColumnsWidthAndName()
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

        private void _RefreshUserList()
        {
            _DataSource = clsUser.GetAllUsers().DefaultView;
            clsFormHelper.RefreshDataGridView(dgvUsersList, _DataSource);
        }

    }
}
