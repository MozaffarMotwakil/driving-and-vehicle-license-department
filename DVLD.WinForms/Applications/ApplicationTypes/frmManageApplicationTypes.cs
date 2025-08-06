using System.Data;
using DVLD.BusinessLogic;
using DVLD.WinForms.BaseForms;
using DVLD.WinForms.Global;
using DVLD.WinForms.Properties;

namespace DVLD.WinForms.Applications
{
    internal partial class frmManageApplicationTypes : frmBaseManage
    {
        public frmManageApplicationTypes() : base(clsApplicationType.GetAllApplicationTypes().DefaultView)
        {
            InitializeComponent();
        }

        private void frmManageApplicationTypes_Load(object sender, System.EventArgs e)
        {
            base.FormTitle = "Manage Application Types";
            base.FormLogo = Resources.Application_Types_512;
            base.RecordsList.ContextMenuStrip = contextMenuStrip;
        }

        private void editToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            frmUpdateApplicationType updateApplicationType = new frmUpdateApplicationType(clsFormHelper.GetSelectedRowID(base.RecordsList));
            updateApplicationType.ShowDialog();

            if (updateApplicationType.IsSaveSuccess)
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
            if (base.RecordsCount > 0)
            {
                base.RecordsList.Columns[0].HeaderText = "ID";
                base.RecordsList.Columns[0].Width = 60;

                base.RecordsList.Columns[1].HeaderText = "Title";
                base.RecordsList.Columns[1].Width = 250;

                base.RecordsList.Columns[2].HeaderText = "Fees";
                base.RecordsList.Columns[2].Width = 120;
            }
        }
        
        protected override DataView GetDataSource()
        {
            return clsApplicationType.GetAllApplicationTypes().DefaultView;
        }

    }
}
