using System;
using System.Diagnostics.Eventing.Reader;
using System.Windows.Forms;
using DVLD.BusinessLogic;
using DVLD.WinForms.Utils;

namespace DVLD.WinForms.People
{
    public partial class ctrPersonCardInfoWithFiltter : UserControl
    {
        /// <summary>
        /// Gets the person if found successfully, otherwise returns null.
        /// </summary>
        public clsPerson Person { get; private set; }

        public ctrPersonCardInfoWithFiltter()
        {
            InitializeComponent();
            Person = null;
            ctrPersonCardInfo.DisableEditPersonLink = true;
        }

        private void ctrPersonCardInfoWithFiltter_Load(object sender, EventArgs e)
        {
            cbFiltterColumn.SelectedIndex = 0; // Person ID
        }

        private void txtTextForFilttering_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFiltterColumn.SelectedIndex == 0)
            {
                clsValidation.HandleNumericKeyPress(e, txtTextForFilttering, errorProvider);
            }
            else
            {
                errorProvider.SetError(txtTextForFilttering, "");
            }
        }

        private void btnFindPerson_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTextForFilttering.Text))
            {
                return;
            }

            if (cbFiltterColumn.SelectedIndex == 0)
            {
                Person = clsPerson.Find(int.Parse(txtTextForFilttering.Text));
            }
            else 
            {
                Person = clsPerson.Find(txtTextForFilttering.Text);
            }
            
            if (Person != null)
            {
                ctrPersonCardInfo.DisableEditPersonLink = false;
                ctrPersonCardInfo.LoadPersonDataForDesplay(Person);
            }
            else
            {
                ctrPersonCardInfo.Clear();
                ctrPersonCardInfo.DisableEditPersonLink = true;
                clsMessages.ShowPersonNotFoundError();
            }

        }

        private void cbFiltterColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTextForFilttering.Text = string.Empty;
            txtTextForFilttering.Focus();
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson AddNewPersonForm = new frmAddUpdatePerson();
            AddNewPersonForm.PersonBack += _DisplayPersonInfo;
            AddNewPersonForm.ShowDialog();

            if (AddNewPersonForm.IsSaveSuccess)
            {
                ctrPersonCardInfo.DisableEditPersonLink = false;
            }
        }

        private void _DisplayPersonInfo(clsPerson Person)
        {
            ctrPersonCardInfo.LoadPersonDataForDesplay(Person);
            cbFiltterColumn.SelectedIndex = 0;
            txtTextForFilttering.Text = Person.PersonID.ToString();
        }

    }
}
