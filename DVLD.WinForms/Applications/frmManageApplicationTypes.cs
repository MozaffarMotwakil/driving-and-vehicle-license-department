using System.Drawing;
using System.Windows.Forms;
using DVLD.BusinessLogic;
using DVLD.WinForms.Global;

namespace DVLD.WinForms.Applications
{
    public partial class frmManageApplicationTypes : Form
    {

        public frmManageApplicationTypes()
        {
            InitializeComponent();
            _RefreshApplicationsList();
            lblRecordsCount.Text = dgvApplicatonsList.RowCount.ToString();
        }

        private void frmManageApplicationTypes_Load(object sender, System.EventArgs e)
        {
            _ResetApplicationsListColumnsWidthAndName();
        }

        private void editToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            frmUpdateApplicationType updateApplicationType = new frmUpdateApplicationType(clsFormHelper.GetSelectedRowID(dgvApplicatonsList));
            updateApplicationType.ShowDialog();

            if (updateApplicationType.IsSaveSuccess)
            {
                _RefreshApplicationsList();
            }
        }

        private void btnCloseScreen_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void dgvApplicatonsList_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            clsFormHelper.SelectEntireRow(dgvApplicatonsList, e);
        }

        private void dgvApplicatonsList_MouseDown(object sender, MouseEventArgs e)
        {
            clsFormHelper.DeselectCellsAndRows(dgvApplicatonsList, e);
        }

        private void contextMenuStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _AdjustContextMenuVisibility(e);
        }

        private void _ResetApplicationsListColumnsWidthAndName()
        {
            if (dgvApplicatonsList.Rows.Count > 0)
            {
                dgvApplicatonsList.Columns[0].HeaderText = "ID";
                dgvApplicatonsList.Columns[0].Width = 60;

                dgvApplicatonsList.Columns[1].HeaderText = "Title";
                dgvApplicatonsList.Columns[1].Width = 250;

                dgvApplicatonsList.Columns[2].HeaderText = "Fees";
                dgvApplicatonsList.Columns[2].Width = 120;
            }
        }

        private void _AdjustContextMenuVisibility(System.ComponentModel.CancelEventArgs e)
        {
            Point point = dgvApplicatonsList.PointToClient(Cursor.Position);
            DataGridView.HitTestInfo hit = dgvApplicatonsList.HitTest(point.X, point.Y);

            if (hit.Type == DataGridViewHitTestType.None || hit.Type == DataGridViewHitTestType.ColumnHeader)
            {
                e.Cancel = true;
            }
        }

        private void _RefreshApplicationsList()
        {
            dgvApplicatonsList.DataSource = clsApplicationType.GetAllApplicationTypes();
        }

    }
}
