using System;
using System.Windows.Forms;
using DVLD.BusinessLogic;
using DVLD.WinForms.Utils;

namespace DVLD.WinForms.Licenses
{
    public partial class frmPersonLicensesHistory : Form
    {
        private clsPerson _Person;

        public frmPersonLicensesHistory(int personID)
        {
            InitializeComponent();
            _Person = clsPerson.Find(personID);
        }

        public frmPersonLicensesHistory(clsPerson person)
        {
            InitializeComponent();
            _Person = person;
        }

        private void frmPersonLicensesHistory_Load(object sender, EventArgs e)
        {
            if (_Person == null)
            {
                clsFormMessages.ShowError("Person not found.");
                this.Close();
                return;
            }

            ctrPersonCardInfo.ShowEditPersonInformationLinke = false;
            ctrPersonCardInfo.LoadPersonDataForDisplay(_Person);
            ctrDriverLicenses.LoadPersonLicensesForDisplay(_Person);
        }

    }
}
