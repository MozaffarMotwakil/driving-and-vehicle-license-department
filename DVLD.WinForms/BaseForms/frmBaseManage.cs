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
            _SelectEntireRow(dgvRecordsList, e);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected virtual void dgvRecordsList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            _SelectEntireRow(dgvRecordsList, e);
        }

        protected virtual void dgvRecordsList_MouseDown(object sender, MouseEventArgs e)
        {
            _DeselectCellsAndRows(dgvRecordsList, e);
        }

        protected virtual DataTable GetDataSource()
        {
            return (DataTable)RecordsList.DataSource;
        }

        protected void RefreshRecordsList()
        {
            OriginalDataSourceOfRecords = GetDataSource();
            RecordsCount = RefreshDataGridView(RecordsList, OriginalDataSourceOfRecords);
        }

        protected virtual void ResetRecordsListColumnsWidthAndName() { }

        protected int RefreshDataGridView(DataGridView dataGridView, object DataSource)
        {
            dataGridView.DataSource = DataSource;
            return dataGridView.RowCount;
        }


        private void _SelectEntireRow(DataGridView dataGridView, DataGridViewCellMouseEventArgs e)
        {
            if ((e.Clicks == 2 || e.Button == MouseButtons.Right) && e.RowIndex >= 0)
            {
                dataGridView.ClearSelection();
                dataGridView.Rows[e.RowIndex].Selected = true;
                dataGridView.CurrentCell = dataGridView.SelectedRows[0].Cells[0];
            }
        }

        private void _DeselectCellsAndRows(DataGridView dataGridView, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hit = dataGridView.HitTest(e.X, e.Y);

            if (e.Button == MouseButtons.Right || e.Button == MouseButtons.Left && hit.Type == DataGridViewHitTestType.None)
            {
                foreach (DataGridViewCell cell in dataGridView.SelectedCells)
                {
                    cell.Selected = false;
                }

                foreach (DataGridViewRow row in dataGridView.SelectedRows)
                {
                    row.Selected = false;
                }
            }
        }

    }
}
