using System;
using System.Windows.Forms;
using DVLD.BusinessLogic;
using DVLD.WinForms.Properties;

namespace DVLD.WinForms.People
{
    public partial class frmPersonDetails : Form
    {
        clsPerson Person;

        public frmPersonDetails(int PersonID)
        {
            InitializeComponent();
            Person = clsPerson.Find(PersonID);
        }

        private void btnCloseScreen_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPersonDetails_Load(object sender, EventArgs e)
        {
            ctrPersonInformation.PersonID = Person.PersonID.ToString();
            ctrPersonInformation.FullName = Person.GetFullName();
            ctrPersonInformation.NationalNo = Person.NationalNo.ToString();
            ctrPersonInformation.Gender = (Person.Gender == clsPerson.enGender.Male ? "Male" : "Female");
            ctrPersonInformation.Email = Person.Email.ToString();
            ctrPersonInformation.Address = Person.Address.ToString();
            ctrPersonInformation.DateOfBirth = Person.DateOfBirth.Date.ToShortDateString();
            ctrPersonInformation.Phone = Person.Phone.ToString();
            ctrPersonInformation.Country = clsCountry.FindCountryByID(Person.NationalityCountryID);

            if (!string.IsNullOrEmpty(Person.ImagePath))
            {
                ctrPersonInformation.LoadImage(Person.ImagePath);
            }
            else
            {
                if (Person.Gender == clsPerson.enGender.Male)
                {
                    ctrPersonInformation.SetImage(Resources.Male_512);
                }
                else
                {
                    ctrPersonInformation.SetImage(Resources.Female_512);
                }
            }
        }
    }
}
