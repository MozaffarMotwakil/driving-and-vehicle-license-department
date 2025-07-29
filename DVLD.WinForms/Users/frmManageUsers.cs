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
                clsSettings.RefreshDataGridView(dgvUsersList, _DataSource);
            }
        }

    }
}
