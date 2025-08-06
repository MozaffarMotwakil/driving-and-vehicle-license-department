using System.Data;
using DVLD.BusinessLogic;
using DVLD.WinForms.BaseForms;
using DVLD.WinForms.Global;
using DVLD.WinForms.Properties;

namespace DVLD.WinForms.Tests
{
    internal partial class frmManageTestTypes : frmBaseManage
    {
        public frmManageTestTypes() : base(clsTestType.GetAllTestTypes().DefaultView)
        {
            InitializeComponent();
        }

        private void frmManageTestTypes_Load(object sender, System.EventArgs e)
        {
            base.FormTitle = "Manage Test Types";
            base.FormLogo = Resources.TestType_512;
            base.RecordsList.ContextMenuStrip = contextMenuStrip;
        }

        private void editToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            frmUpdateTestType updateTestType = new frmUpdateTestType(clsFormHelper.GetSelectedRowID(base.RecordsList));
            updateTestType.ShowDialog();

            if (updateTestType.IsSaveSuccess)
            {
                base.RefreshRecordsList();
            }

        }

        private void contextMenuStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            clsFormHelper.PreventContextMenuOnHeaderOrEmptySpace(base.RecordsList, e);
        }

        protected override void ResetRecordsListColumnsWidthAndName()
        {
            if (RecordsCount > 0)
            {
                base.RecordsList.Columns[0].HeaderText = "ID";
                base.RecordsList.Columns[0].Width = 50;

                base.RecordsList.Columns[1].HeaderText = "Title";
                base.RecordsList.Columns[1].Width = 150;

                base.RecordsList.Columns[2].HeaderText = "Description";
                base.RecordsList.Columns[2].Width = 450;

                base.RecordsList.Columns[3].HeaderText = "Fees";
                base.RecordsList.Columns[3].Width = 80;
            }
        }

        protected override DataView GetDataSource()
        {
            return clsTestType.GetAllTestTypes().DefaultView;
        }

    }
}
