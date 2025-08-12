using System;
using System.Windows.Forms;
using DVLD.BusinessLogic;
using DVLD.WinForms.People;
using DVLD.WinForms.Users;

namespace DVLD.WinForms.Applications.BaseApplication
{
    public partial class ctrBaseApplicationInfo : UserControl
    {
        public clsApplication Application { get; set; }
        
        public ctrBaseApplicationInfo()
        {
            InitializeComponent();
        }

        public void LoadBaseApplicationDataForDisplay(clsApplication Application)
        {
            this.Application = Application;
            lblApplicationID.Text = Application.ApplicationID.ToString();
            lblApplicationStatus.Text = Application.Status.ToString();
            lblApplicationFees.Text = Application.PaidFees.ToString();
            lblApplicationType.Text = Application.TypeInfo.Title;
            llApplicant.Text = Application.PersonInfo.GetFullName();
            lblApplicationDate.Text = Application.CreatedDate.ToString();
            lblApplicationStatusDate.Text = Application.LastStatusDate.ToString();
            llCreatedByUsername.Text = Application.CreatedByUserInfo.Username;
        }

        public void Clear()
        {
            this.Application = null;
            lblApplicationID.Text = lblApplicationStatus.Text = lblApplicationFees.Text =
                lblApplicationType.Text = llApplicant.Text = llCreatedByUsername.Text = "???";

            lblApplicationDate.Text = lblApplicationStatusDate.Text = "DD/M/YYYY";
        }

        private void llApplicant_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Application == null)
            {
                return;
            }

            frmShowPersonInfo personInfo = new frmShowPersonInfo(Application.PersonInfo);
            personInfo.ShowEditPersonInformationLinke = false;
            personInfo.ShowDialog();
        }

        private void llCreatedByUsername_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Application == null)
            {
                return;
            }

            frmShowUserInfo userInfo = new frmShowUserInfo(Application.CreatedByUserInfo);
            userInfo.ShowEditPersonInformationLinke = false;
            userInfo.ShowDialog();
        }

    }
}