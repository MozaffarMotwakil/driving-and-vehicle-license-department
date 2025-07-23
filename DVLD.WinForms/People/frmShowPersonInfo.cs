using System;
using System.Windows.Forms;
using DVLD.BusinessLogic;
using DVLD.WinForms.Utils;

namespace DVLD.WinForms.People
{
    public partial class frmShowPersonInfo : Form
    {
        clsPerson Person;

        public frmShowPersonInfo(int PersonID)
        {
            InitializeComponent();
            Person = clsPerson.Find(PersonID);

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
            ctrPersonInformation.LoadPersonDataForDesplay(Person);

            // Stop showing the warning again while this form is still open.
            // This avoids showing it twice when coming back from frmAddEditPerson.
            ctrPersonInformation.SuppressImageLoadWarning = true;
        }

    }
}
