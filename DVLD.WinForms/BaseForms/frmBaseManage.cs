using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DVLD.WinForms.Global;

namespace DVLD.WinForms.BaseForms
{
    internal partial class frmBaseManage : Form
    {
        protected string FormTitle
        {
            set { lblFormTitle.Text = value; }
        }

        protected Image FormLogo
        {
            set { pbFormLogo.Image = value; }
        }

        protected int RecordsCount
        {
            get { return int.Parse(lblRecordsCount.Text); }
            set { lblRecordsCount.Text = value.ToString(); }
        }

        protected DataGridView RecordsList
        {
            get { return dgvRecordsList; }
        }

        private frmBaseManage()
        {
            InitializeComponent();
        }

        public frmBaseManage(DataView DataSource)
        {
            InitializeComponent();
            RecordsList.DataSource = DataSource;
            RefreshRecordsList();
        }

        private void frmBaseManage_Load(object sender, EventArgs e)
        {
            ResetRecordsListColumnsWidthAndName();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvRecordsList_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            clsFormHelper.SelectEntireRow(dgvRecordsList, e);
        }

        private void dgvRecordsList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            clsFormHelper.SelectEntireRow(dgvRecordsList, e);
        }
        
        private void dgvRecordsList_MouseDown(object sender, MouseEventArgs e)
        {
            clsFormHelper.DeselectCellsAndRows(dgvRecordsList, e);
        }

        protected virtual DataView GetDataSource()
        {
            return (DataView)RecordsList.DataSource;
        }

        protected void RefreshRecordsList()
        {
            RecordsList.DataSource = GetDataSource();
            RecordsCount = clsFormHelper.RefreshDataGridView(RecordsList, RecordsList.DataSource);
        }

        protected virtual void ResetRecordsListColumnsWidthAndName() { }

    }
}
