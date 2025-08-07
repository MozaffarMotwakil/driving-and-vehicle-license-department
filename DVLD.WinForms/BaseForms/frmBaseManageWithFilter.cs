using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DVLD.WinForms.Utils;

namespace DVLD.WinForms.BaseForms
{
    internal partial class frmBaseManageWithFilter : frmBaseManage
    {
        protected ComboBox.ObjectCollection FilterColumns
        {
            get { return cbFilterColumn.Items; }
        }

        protected string SelectedFilterColumn { get; private set; }

        protected int SelectedFilterColumnIndex
        {
            get { return cbFilterColumn.SelectedIndex; }
            set { cbFilterColumn.SelectedIndex = value; }
        }

        protected string FilterText
        {
            get { return txtFilterText.Text; }
            set { txtFilterText.Text = value; }
        }

        protected bool FilterTextControlVisible
        {
            get { return txtFilterText.Visible; }
            set { txtFilterText.Visible = value; }
        }

        protected Image AddRecordButtonBackgroumd
        {
            set { btnAddNewRecord.BackgroundImage = value; }
        }

        protected frmBaseManageWithFilter() : base(1200, 600)
        {
            base.FormTitle = "Base Manage With Filter";
            InitializeComponent();
        }

        public frmBaseManageWithFilter(DataView DataSource) : base(DataSource, 1200, 600) 
        {
            base.FormTitle = "Base Manage With Filter";
            InitializeComponent();
        }

        private void frmBaseManageWithFilter_Load(object sender, EventArgs e)
        {
            cbFilterColumn.Items.Add("None");
            ResetFilterColumnToDefault();
        }

        protected override void dgvRecordsList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            base.dgvRecordsList_CellMouseDoubleClick(sender, e);
            ShowRecordDetailsOperation();
        }

        private void cbFilterColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateFilterControlsVisibility();
        }

        private void txtFilterText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (SelectedFilterColumn.EndsWith("ID"))
            {
                clsFormValidation.HandleNumericKeyPress(e, txtFilterText, errorProvider);
            }
            else
            {
                errorProvider.SetError(txtFilterText, "");
            }
        }

        private void txtFilterText_TextChanged(object sender, EventArgs e)
        {
            base.RecordsCount = clsFormHelper.RefreshDataGridViewWithFilter(base.RecordsList, base.RecordsList.DataSource as DataView, SelectedFilterColumn, FilterText);
        }

        protected virtual void UpdateFilterControlsVisibility()
        {
            SetFilterColumnValue();
            DefaultFilterControlsVisibility();
        }

        protected void SetFilterColumnValue()
        {
            FilterText = string.Empty;
            SelectedFilterColumn = cbFilterColumn.Text.Replace(" ", "");
        }

        protected void DefaultFilterControlsVisibility()
        {
            txtFilterText.Visible = true;
            txtFilterText.Enabled = !(SelectedFilterColumn == "None");
            txtFilterText.Focus();
        }

        protected virtual void ShowRecordDetailsOperation() 
        {
            throw new NotImplementedException();
        }

        protected void DeleteRecordOperation()
        {
            int recordID = clsFormHelper.GetSelectedRowID(base.RecordsList);

            if (clsFormMessages.Confirm($"Are you sure do you want delete the record with ID = {recordID}?",
                "Confirm Deletion", MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2))
            {
                try
                {
                    if (DeleteRecord(recordID))
                    {
                        clsFormMessages.ShowSuccess("Record deleted successfully.");
                        base.RefreshRecordsList();
                    }
                    else
                    {
                        clsFormMessages.ShowError("Could not delete record.");
                    }
                }
                catch
                {
                    clsFormMessages.ShowError("Record was not deleted because it has data linked to it.", "Failed Deleted");
                }
            }
        }

        protected virtual bool DeleteRecord(int recordID)
        {
            throw new NotImplementedException();
        }

        private void btnAddNewRecord_Click(object sender, EventArgs e)
        {
            AddNewRecordOperation();
            ResetFilterColumnToDefault();
        }

        protected virtual void AddNewRecordOperation()
        {
            throw new NotImplementedException();
        }

        protected void ResetFilterColumnToDefault()
        {
            SelectedFilterColumnIndex = 0;
        }

        protected void ReapplyAndHighlightFilterText()
        {
            clsFormHelper.ReapplyAndHighlightFilterText(txtFilterText);
        }

    }
}
