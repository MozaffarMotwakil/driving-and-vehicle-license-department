using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DVLD.BusinessLogic;
using DVLD.WinForms.BaseForms;
using DVLD.WinForms.Properties;
using DVLD.WinForms.Users;
using DVLD.WinForms.Utils;

namespace DVLD.WinForms.People
{
    internal partial class frmManageUsers : frmBaseManageWithFilter
    {
        public frmManageUsers() : base(clsUser.GetAllUsers())
        {
            InitializeComponent();
        }

        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            _SetValuesToBaseFormControls();
            clsFormHelper.SetDefaultValuesToCountriesComboBox(cbCountry);
        }

        private void _SetValuesToBaseFormControls()
        {
            base.FormTitle = "Manage Users";
            base.FormLogo = Resources.Users_2_400;
            base.RecordsList.ContextMenuStrip = recordsListContextMenuStrip;
            base.AddNewRecordButtonBackgroumd = Resources.Add_New_User_32;
            base.FilterColumns.AddRange(
                new object[] {
                    "User ID",
                    "Person ID",
                    "Username",
                    "Full Name",
                    "Gender",
                    "Nationality",
                    "Is Active"
                }
            );
        }

        private void cbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            base.SetFilterTextFromComboBox(cbCountry);
        }

        private void cbActivity_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbActivity.SelectedItem)
            {
                case "Yes":
                    base.FilterText = "1";
                    break;
                case "No":
                    base.FilterText = "0";
                    break;
                default:
                    base.FilterText = string.Empty;
                    break;
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

        private void frmManageUsers_MouseDown(object sender, MouseEventArgs e)
        {
            base.frmBaseManage_MouseDown(sender, e);
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
            return clsUser.GetAllUsers();
        }

        protected override void ResetRecordsListColumnsWidthAndName()
        {
            if (base.RecordsCount > 0)
            {
                base.RecordsList.Columns["UserID"].HeaderText = "User ID";
                base.RecordsList.Columns["UserID"].Width = 70;

                base.RecordsList.Columns["PersonID"].HeaderText = "Person ID";
                base.RecordsList.Columns["PersonID"].Width = 70;

                base.RecordsList.Columns["Username"].Width = 100;

                base.RecordsList.Columns["FullName"].HeaderText = "Full Name";
                base.RecordsList.Columns["FullName"].Width = 200;

                base.RecordsList.Columns["Gender"].Width = 80;

                base.RecordsList.Columns["Nationality"].Width = 100;

                base.RecordsList.Columns["IsActive"].HeaderText = "Is Active";
                base.RecordsList.Columns["IsActive"].Width = 80;
            }
        }

        protected override void UpdateFilterControlsVisibility()
        {
            base.SetFilterColumnValue();

            base.FilterTextControlVisible = cbCountry.Visible =
                panelGender.Visible = cbActivity.Visible = false;

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
                case "IsActive":
                    cbActivity.Location = new Point(cbCountry.Location.X, 178);
                    cbActivity.Visible = true;
                    cbActivity.SelectedItem = "All";
                    break;
                default:
                    base.DefaultFilterControlsVisibility();
                    break;
            }
        }

        protected override bool DeleteRecord(int recordID)
        {
            return clsUser.Delete(recordID);
        }

        protected override void AddNewRecordOperation()
        {
            frmAddUpdateUser addUserForm = new frmAddUpdateUser();
            addUserForm.SaveSuccess += base.RefreshAndResetFilterColumnToDefault;
            addUserForm.PersonInfoModifie += base.RefreshAndResetFilterColumnToDefault;
            addUserForm.ShowDialog();
        }

        protected override void ShowRecordDetailsOperation()
        {
            frmShowUserInfo userInfoForm = new frmShowUserInfo(clsFormHelper.GetSelectedRowID(base.RecordsList));
            userInfoForm.InfoModifie += base.RefreshAndReapplyCurrentFilter;
            userInfoForm.ShowDialog();
        }
        
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser updateUserForm = new frmAddUpdateUser(clsFormHelper.GetSelectedRowID(base.RecordsList));
            updateUserForm.SaveSuccess += base.RefreshAndReapplyCurrentFilter;
            updateUserForm.PersonInfoModifie += base.RefreshAndReapplyCurrentFilter;
            updateUserForm.ShowDialog();
        }
        
        private void ChangePasswordtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword changePasswordForm = new frmChangePassword(clsFormHelper.GetSelectedRowID(base.RecordsList));
            changePasswordForm.SaveSuccess += base.RefreshAndReapplyCurrentFilter;
            changePasswordForm.ShowDialog();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowRecordDetailsOperation();
        }

        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewRecordOperation();
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
