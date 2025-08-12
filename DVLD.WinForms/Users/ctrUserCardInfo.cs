using System;
using System.Windows.Forms;
using DVLD.BusinessLogic;

namespace DVLD.WinForms.Users
{
    public partial class ctrUserCardInfo : UserControl
    {
        public event Action InfoModified;

        public bool ShowEditPersonInformationLinke
        {
            get { return ctrPersonCardInfo.ShowEditPersonInformationLinke; }
            set { ctrPersonCardInfo.ShowEditPersonInformationLinke = value; }
        }

        protected virtual void OnInfoModified()
        {
            InfoModified?.Invoke();
        }

        public ctrUserCardInfo()
        {
            InitializeComponent();
            ctrPersonCardInfo.InfoModified += CtrPersonCardInfo_InfoModified;
        }

        private void CtrPersonCardInfo_InfoModified()
        {
            OnInfoModified();
        }

        public void LoadUserDataForDesplay(clsUser User)
        {
            ctrPersonCardInfo.LoadPersonDataForDisplay(User.PersonInfo);
            lblUserID.Text = User.UserID.ToString();
            lblUsername.Text = User.Username;
            lblIsActive.Text = (User.IsActive ? "Yes" : "No");
        }

    }
}
