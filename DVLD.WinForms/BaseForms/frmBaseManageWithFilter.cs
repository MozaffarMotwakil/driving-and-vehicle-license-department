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

        protected string SelectedFilterColumn { get; set; }

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

        protected Image AddNewRecordButtonBackgroumd
        {
            set { btnAddNewRecord.BackgroundImage = value; }
        }
        
        protected ImageLayout AddNewRecordButtonBackgroumdLayout
        {
            set { btnAddNewRecord.BackgroundImageLayout = value; }
        }

        protected frmBaseManageWithFilter() : base(1200, 600)
        {
            base.FormTitle = "Base Manage With Filter";
            InitializeComponent();
        }

        public frmBaseManageWithFilter(DataTable DataSource) : base(DataSource, 1200, 600) 
        {
            base.FormTitle = "Base Manage With Filter";
            InitializeComponent();
        }

        private void frmBaseManageWithFilter_Load(object sender, EventArgs e)
        {
            cbFilterColumn.Items.Add("None");
            ResetFilterColumnToDefault();
        }

        private void btnAddNewRecord_Click(object sender, EventArgs e)
        {
            AddNewRecordOperation();
        }

        protected override void dgvRecordsList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            base.dgvRecordsList_CellMouseDoubleClick(sender, e);

            if (clsFormHelper.GetHitTestInfo(base.RecordsList).Type == DataGridViewHitTestType.Cell)
            {
                ShowRecordDetailsOperation();
            }
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
            base.RecordsCount = _ApplyFilterToRecordsList(SelectedFilterColumn, FilterText);
        }

        protected virtual void UpdateFilterControlsVisibility()
        {
            SetFilterColumnValue();
            DefaultFilterControlsVisibility();
        }

        protected virtual void SetFilterColumnValue()
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

            ResetFilterColumnToDefault();
        }

        protected virtual bool DeleteRecord(int recordID)
        {
            throw new NotImplementedException();
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
            if (!string.IsNullOrEmpty(txtFilterText.Text))
            {
                string temp = txtFilterText.Text;
                txtFilterText.Text = string.Empty;
                txtFilterText.Text = temp;

                txtFilterText.SelectionStart = 0;
                txtFilterText.SelectionLength = txtFilterText.TextLength;
            }
        }

        protected void SetFilterTextFromComboBox(ComboBox comboBox)
        {
            if (comboBox.SelectedIndex == 0)
            {
                this.FilterText = string.Empty;
            }
            else
            {
                this.FilterText = comboBox.SelectedItem.ToString();
            }
        }

        protected void SetFilterTextFromDate(DateTime Date)
        {
            FilterText = Date.ToString("yyyy/MM/dd");
        }

        protected void RefreshAndResetFilterColumnToDefault()
        {
            base.RefreshRecordsList();
            ResetFilterColumnToDefault();
        }

        protected void RefreshAndReapplyCurrentFilter()
        {
            base.RefreshRecordsList();
            ReapplyAndHighlightFilterText();
        }

        private int _ApplyFilterToRecordsList(string FilterColumn, string FilterText)
        {
            DataView recordsListForFiltering;

            if (base.RecordsList.DataSource is DataTable)
            {
                recordsListForFiltering = ((DataTable)base.RecordsList.DataSource).DefaultView;
            }
            else
            {
                recordsListForFiltering = (DataView)base.RecordsList.DataSource;
            }

            if (FilterColumn == "None")
            {
                recordsListForFiltering.RowFilter = string.Empty;
                return clsFormHelper.RefreshDataGridView(base.RecordsList, base.OriginalDataSourceOfRecords);
            }

            Type columnType = base.OriginalDataSourceOfRecords.Columns[FilterColumn].DataType;

            if (columnType == typeof(Int32) || columnType == typeof(Boolean))
            {
                if (!string.IsNullOrWhiteSpace(FilterText))
                {
                    recordsListForFiltering.RowFilter = $"{FilterColumn} = {FilterText}";
                }
                else
                {
                    recordsListForFiltering.RowFilter = string.Empty;
                }
            }
            else if (columnType == typeof(DateTime))
            {
                if (DateTime.TryParse(FilterText, out DateTime applicationDate))
                {
                    recordsListForFiltering.RowFilter = $@"{FilterColumn} >= #{applicationDate.ToString("yyyy/MM/dd")}# AND
                        {FilterColumn} <= #{applicationDate.AddDays(1).ToString("yyyy/MM/dd")}#";
                }
                else
                {
                    recordsListForFiltering.RowFilter = string.Empty;
                }
            }
            else
            {
                recordsListForFiltering.RowFilter = $"{FilterColumn} LIKE '{FilterText}%'";
            }

            return clsFormHelper.RefreshDataGridView(base.RecordsList, recordsListForFiltering);
        }

    }
}
