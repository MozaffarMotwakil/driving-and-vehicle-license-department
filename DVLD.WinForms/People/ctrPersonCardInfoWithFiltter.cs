using System;
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

        public bool IsFilterEnabled
        {
            get { return gbFiltter.Enabled; }
            set { gbFiltter.Enabled = value; }
        }

        public event Action PersonFound;

        protected virtual void OnPersonFound()
        {
            if (PersonFound != null)
            {
                PersonFound();
            }
        }

        public event Action PersonNotFound;

        protected virtual void OnPersonNotFound()
        {
            if (PersonNotFound != null)
            {
                PersonNotFound();
            }
        }
        
        public event Action AddNewPerson;

        protected virtual void OnAddNewPerson()
        {
            if (AddNewPerson != null)
            {
                AddNewPerson();
            }
        }

        public ctrPersonCardInfoWithFiltter()
        {
            InitializeComponent();
            Person = null;
            IsFilterEnabled = true;
        }

        private void ctrPersonCardInfoWithFiltter_Load(object sender, EventArgs e)
        {
            cbFilterColumn.SelectedIndex = 0; // Person ID
        }

        private void txtFilterText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterColumn.SelectedIndex == 0)
            {
                clsFormValidation.HandleNumericKeyPress(e, txtFilterText, errorProvider);
            }
            else
            {
                errorProvider.SetError(txtFilterText, "");
            }
        }

        private void txtFilterText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnFindPerson.PerformClick();
                e.Handled = true;
            }
        }

        private void btnFindPerson_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFilterText.Text))
            {
                return;
            }

            if (cbFilterColumn.SelectedIndex == 0)
            {
                Person = clsPerson.Find(int.Parse(txtFilterText.Text));
            }
            else 
            {
                Person = clsPerson.Find(txtFilterText.Text);
            }
            
            if (Person != null)
            {
                OnPersonFound();
                ctrPersonCardInfo.LoadPersonDataForDesplay(Person);
            }
            else
            {
                OnPersonNotFound();
                ctrPersonCardInfo.Clear();
                clsFormMessages.ShowPersonNotFoundError();
            }

        }

        private void cbFiltterColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterText.Text = string.Empty;
            txtFilterText.Focus();
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson addNewPersonForm = new frmAddUpdatePerson();
            addNewPersonForm.PersonBack += _DisplayTheAddedPersonInfo;
            addNewPersonForm.ShowDialog();

            if (addNewPersonForm.IsSaveSuccess)
            {
                OnAddNewPerson();
            }
        }

        private void _DisplayTheAddedPersonInfo(clsPerson Person)
        {
            this.Person = Person;
            ctrPersonCardInfo.LoadPersonDataForDesplay(Person);
            cbFilterColumn.SelectedIndex = 0;
            txtFilterText.Text = Person.PersonID.ToString();
        }

        public void LoadPersonDataForEdit(clsPerson Person)
        {
            this.Person = Person;
            cbFilterColumn.SelectedIndex = 0;
            txtFilterText.Text = Person.PersonID.ToString();
            IsFilterEnabled = false;
            ctrPersonCardInfo.LoadPersonDataForDesplay(Person);
        }

        public void ClearPersonInfo()
        {
            ctrPersonCardInfo.Clear();
        }

    }
}
