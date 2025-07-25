using System;
using System.Windows.Forms;
using DVLD.BusinessLogic;
using DVLD.WinForms.Utils;

namespace DVLD.WinForms.People
{
    public partial class frmShowPersonInfo : Form
    {
        public bool IsInfoModified 
        {
            get { return ctrPersonInformation.IsInfoModified; }

        }

        private clsPerson _Person;

        public frmShowPersonInfo(int PersonID)
        {
            InitializeComponent();
            _Person = clsPerson.Find(PersonID);

            ctrPersonInformation.OnImageLoadFailed += CtrPersonInformation_OnImageLoadFailed;
        }

        private void CtrPersonInformation_OnImageLoadFailed()
        {
             clsMessages.ShowImageNotFoundWarning();
        }

        private void btnCloseScreen_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPersonDetails_Load(object sender, EventArgs e)
        {
            if (_Person == null)
            {
                clsMessages.ShowPersonNotFoundError();
                this.Close();
            }

            ctrPersonInformation.LoadPersonDataForDesplay(_Person);

            // Stop showing the warning again while this form is still open.
            // This avoids showing it twice when coming back from frmAddEditPerson.
            ctrPersonInformation.SuppressImageLoadWarning = true;
        }

    }
}
