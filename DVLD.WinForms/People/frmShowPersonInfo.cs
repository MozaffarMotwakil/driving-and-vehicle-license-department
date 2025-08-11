using System;
using System.Windows.Forms;
using DVLD.BusinessLogic;
using DVLD.WinForms.Utils;

namespace DVLD.WinForms.People
{
    public partial class frmShowPersonInfo : Form
    {
        private clsPerson _Person;

        public event Action InfoModified;
        protected virtual void OnInfoModified()
        {
            InfoModified?.Invoke();
        }

        public frmShowPersonInfo(int PersonID)
        {
            InitializeComponent();
            _Person = clsPerson.Find(PersonID);
            ctrPersonInformation.ImageLoadFailed += CtrPersonInformation_OnImageLoadFailed;
            ctrPersonInformation.InfoModified += CtrPersonInformation_InfoModified;
        }

        private void CtrPersonInformation_InfoModified()
        {
            OnInfoModified();
        }

        private void CtrPersonInformation_OnImageLoadFailed()
        {
             clsFormMessages.ShowImageNotFoundWarning();
        }

        private void frmPersonDetails_Load(object sender, EventArgs e)
        {
            if (_Person == null)
            {
                clsFormMessages.ShowPersonNotFoundError();
                this.Close();
                return;
            }

            // Stop showing the warning again while this form is still open.
            // This avoids showing it twice when coming back from frmAddEditPerson.
            ctrPersonInformation.SuppressImageLoadWarning = true;
            ctrPersonInformation.LoadPersonDataForDesplay(_Person);
        }

        private void btnCloseScreen_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
