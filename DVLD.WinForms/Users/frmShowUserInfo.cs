using System;
using System.Windows.Forms;
using DVLD.BusinessLogic;

namespace DVLD.WinForms.Users
{
    public partial class frmShowUserInfo : Form
    {
        private clsUser _User;

        public bool IsInfoModified { get { return ctrUserCardInfo.IsInfoModified; } }

        public frmShowUserInfo(int UserID)
        {
            InitializeComponent();
            _User = clsUser.Find(UserID);
        }

        public frmShowUserInfo(clsUser User)
        {
            InitializeComponent();
            _User = User;
        }

        private void frmShowUserInfo_Load(object sender, EventArgs e)
        {
            ctrUserCardInfo.LoadUserDataForDesplay(_User);
        }

        private void btnCloseScreen_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
