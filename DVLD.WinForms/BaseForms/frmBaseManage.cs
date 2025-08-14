using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DVLD.WinForms.Utils;

namespace DVLD.WinForms.BaseForms
{
    internal partial class frmBaseManage : Form
    {
        protected DataTable OriginalDataSourceOfRecords { get; set; }
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

        protected frmBaseManage()
        {
            InitializeComponent();
        }

        protected frmBaseManage(int Width = 800, int Height = 600) : this()
        {
            this.Width = Width;
            this.Height = Height;
        }

        public frmBaseManage(DataTable DataSource, int Width = 800, int Height = 600) : this(Width, Height)
        {
            OriginalDataSourceOfRecords = DataSource;
            RefreshRecordsList();
        }

        private void frmBaseManage_Load(object sender, EventArgs e)
        {
            ResetRecordsListColumnsWidthAndName();
        }

        private void dgvRecordsList_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            clsFormHelper.SelectEntireRow(dgvRecordsList, e);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected virtual void dgvRecordsList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            clsFormHelper.SelectEntireRow(dgvRecordsList, e);
        }

        protected virtual void dgvRecordsList_MouseDown(object sender, MouseEventArgs e)
        {
            clsFormHelper.DeselectCellsAndRows(dgvRecordsList, e);
        }

        protected virtual DataTable GetDataSource()
        {
            return (DataTable)RecordsList.DataSource;
        }

        protected void RefreshRecordsList()
        {
            OriginalDataSourceOfRecords = GetDataSource();
            RecordsCount = clsFormHelper.RefreshDataGridView(RecordsList, OriginalDataSourceOfRecords);
        }

        protected virtual void ResetRecordsListColumnsWidthAndName() { }

    }
}
