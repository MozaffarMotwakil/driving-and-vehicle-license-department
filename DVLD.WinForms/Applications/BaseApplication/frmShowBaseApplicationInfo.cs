using System;
using System.Windows.Forms;
using DVLD.BusinessLogic;
using DVLD.WinForms.Utils;

namespace DVLD.WinForms.Applications.BaseApplication
{
    public partial class frmShowBaseApplicationInfo : Form
    {
        private clsApplication _Application;

        public frmShowBaseApplicationInfo(clsApplication baseApplication)
        {
            InitializeComponent();
            _Application = baseApplication;
        }

        private void frmShowBaseApplicationInfo_Load(object sender, EventArgs e)
        {
            if (_Application == null)
            {
                clsFormMessages.ShowError("Application not found.");
                this.Close();
                return;
            }

            ctrBaseApplicationInfo.LoadBaseApplicationDataForDisplay(_Application);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}