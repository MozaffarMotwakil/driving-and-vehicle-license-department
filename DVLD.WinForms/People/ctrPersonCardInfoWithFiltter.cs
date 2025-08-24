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
            get { return gbFilter.Enabled; }
            set { gbFilter.Enabled = value; }
        }

        public event Action PersonFound;
        protected virtual void OnPersonFound()
        {
            PersonFound?.Invoke();
        }

        public event Action PersonNotFound;
        protected virtual void OnPersonNotFound()
        {
            PersonNotFound?.Invoke();
        }
        
        public event Action AddNewPerson;
        protected virtual void OnAddNewPerson()
        {
            AddNewPerson?.Invoke();
        }

        public event Action InfoModifie;
        protected virtual void OnInfoModifie()
        {
            InfoModifie?.Invoke();
        }

        public ctrPersonCardInfoWithFiltter()
        {
            InitializeComponent();
            Person = null;
            IsFilterEnabled = true;
            cbFilterColumn.SelectedIndex = 0;
            ctrPersonCardInfo.InfoModified += CtrPersonCardInfo_InfoModified;
        }

        private void CtrPersonCardInfo_InfoModified()
        {
            OnInfoModifie();
        }

        private void ctrPersonCardInfoWithFiltter_Load(object sender, EventArgs e)
        {
            ctrPersonCardInfo.Visible = DesignMode;
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
            if (string.IsNullOrWhiteSpace(txtFilterText.Text) ||
                (cbFilterColumn.SelectedIndex == 0 && Person != null && Person.PersonID == int.Parse(txtFilterText.Text)) ||
                (cbFilterColumn.SelectedIndex == 1 && Person != null && Person.NationalNo == txtFilterText.Text))
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
                ctrPersonCardInfo.LoadPersonDataForDisplay(Person);
                ctrPersonCardInfo.Visible = true;
            }
            else
            {
                OnPersonNotFound();
                ctrPersonCardInfo.Clear();
                ctrPersonCardInfo.Visible = false;
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
            addNewPersonForm.SaveSuccess += AddNewPersonForm_SaveSuccess;
            addNewPersonForm.ShowDialog();
        }

        private void AddNewPersonForm_SaveSuccess()
        {
            OnAddNewPerson();
        }

        private void _DisplayTheAddedPersonInfo(clsPerson Person)
        {
            this.Person = Person;
            cbFilterColumn.SelectedIndex = 0;
            txtFilterText.Text = Person.PersonID.ToString();
            ctrPersonCardInfo.LoadPersonDataForDisplay(Person);
            ctrPersonCardInfo.Visible = true;
        }

        public void LoadPersonDataForEdit(clsPerson Person)
        {
            this.Person = Person;
            IsFilterEnabled = false;
            cbFilterColumn.SelectedIndex = 0;
            txtFilterText.Text = Person.PersonID.ToString();
            ctrPersonCardInfo.LoadPersonDataForDisplay(Person);
            ctrPersonCardInfo.Visible = true;
        }

        public void ClearPersonInfo()
        {
            ctrPersonCardInfo.Clear();
        }

        public void FocusOnFilterText()
        {
            txtFilterText.Focus();
        }

    }
}