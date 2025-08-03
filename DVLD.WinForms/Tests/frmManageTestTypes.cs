using System.Drawing;
using System.Windows.Forms;
using DVLD.BusinessLogic;
using DVLD.WinForms.Global;

namespace DVLD.WinForms.Tests
{
    public partial class frmManageTestTypes : Form
    {
        public frmManageTestTypes()
        {
            InitializeComponent();
            _RefreshTestsList();
            lblRecordsCount.Text = dgvTestsList.RowCount.ToString();
        }

        private void frmManageTestTypes_Load(object sender, System.EventArgs e)
        {
            _ResetTestsListColumnsWidthAndName();
        }

        private void editToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            frmUpdateTestType updateTestType = new frmUpdateTestType(clsFormHelper.GetSelectedRowID(dgvTestsList));
            updateTestType.ShowDialog();

            if (updateTestType.IsSaveSuccess)
            {
                _RefreshTestsList();
            }
        }

        private void btnCloseScreen_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void dgvTestsList_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            clsFormHelper.SelectEntireRow(dgvTestsList, e);
        }

        private void dgvTestsList_MouseDown(object sender, MouseEventArgs e)
        {
            clsFormHelper.DeselectCellsAndRows(dgvTestsList, e);
        }

        private void contextMenuStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _AdjustContextMenuVisibility(e);
        }

        private void _ResetTestsListColumnsWidthAndName()
        {
            if (dgvTestsList.Rows.Count > 0)
            {
                dgvTestsList.Columns[0].HeaderText = "ID";
                dgvTestsList.Columns[0].Width = 50;

                dgvTestsList.Columns[1].HeaderText = "Title";
                dgvTestsList.Columns[1].Width = 150;

                dgvTestsList.Columns[2].HeaderText = "Description";
                dgvTestsList.Columns[2].Width = 450;
                
                dgvTestsList.Columns[3].HeaderText = "Fees";
                dgvTestsList.Columns[3].Width = 80;
            }
        }

        private void _AdjustContextMenuVisibility(System.ComponentModel.CancelEventArgs e)
        {
            Point point = dgvTestsList.PointToClient(Cursor.Position);
            DataGridView.HitTestInfo hit = dgvTestsList.HitTest(point.X, point.Y);

            if (hit.Type == DataGridViewHitTestType.None || hit.Type == DataGridViewHitTestType.ColumnHeader)
            {
                e.Cancel = true;
            }
        }

        private void _RefreshTestsList()
        {
            dgvTestsList.DataSource = clsTestType.GetAllTestTypes();
        }

    }
}
