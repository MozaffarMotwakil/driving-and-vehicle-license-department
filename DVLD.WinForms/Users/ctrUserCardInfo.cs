using System.Windows.Forms;
using DVLD.BusinessLogic;

namespace DVLD.WinForms.Users
{
    public partial class ctrUserCardInfo : UserControl
    {
        public bool IsInfoModified { get { return ctrPersonCardInfo.IsInfoModified; } }

        public ctrUserCardInfo()
        {
            InitializeComponent();
        }

        public void LoadUserDataForDesplay(clsUser User)
        {
            ctrPersonCardInfo.LoadPersonDataForDesplay(User.PersonInfo);
            lblUserID.Text = User.UserID.ToString();
            lblUsername.Text = User.Username;
            lblIsActive.Text = (User.IsActive ? "Yes" : "No");
        }

    }
}
