using System;
using System.Drawing;
using System.Windows.Forms;
using DVLD.BusinessLogic;
using DVLD.WinForms.Properties;

namespace DVLD.WinForms.People
{
    public partial class ctrPersonInformation : UserControl
    {
        public string PersonID
        {
            get { return lblPersonID.Text; }
            set { lblPersonID.Text = value; }
        }
        public string FullName
        {
            get { return lblFullName.Text; }
            set { lblFullName.Text = value; }
        }
        public string NationalNo
        {
            get { return lblNationalNumber.Text; }
            set { lblNationalNumber.Text = value; }
        }
        public string DateOfBirth
        {
            get { return lblDateOfBirth.Text; }
            set { lblDateOfBirth.Text = value; }
        }
        public string Phone
        {
            get { return lblPhone.Text; }
            set { lblPhone.Text = value; }
        }
        public string Email
        {
            get { return lblEmail.Text; }
            set { lblEmail.Text = value; }
        }
        public string Country
        {
            get { return lblCountry.Text; }
            set { lblCountry.Text = value; }
        }
        public string Address
        {
            get { return lblAddress.Text; }
            set { lblAddress.Text = value; }
        }
        public string Gender
        {
            get { return lblGender.Text; }
            set { lblGender.Text = value; }
        }

        public ctrPersonInformation()
        {
            InitializeComponent();
        }

        public void LoadImage(string ImagePath)
        {
            pbPersonImage.Load(ImagePath);
        }

        public void SetImage(Image Image)
        {
            pbPersonImage.Image = Image;
        }

        private void llEditPersonInformation_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddEditPerson addEditPersonForm = new frmAddEditPerson(int.Parse(PersonID));
            addEditPersonForm.PersonBack += _UpdatePersonInfo;
            addEditPersonForm.ShowDialog();
        }

        private void _UpdatePersonInfo(clsPerson Person)
        {
            PersonID = Person.PersonID.ToString();
            NationalNo = Person.NationalNo.ToString();
            FullName = Person.GetFullName();
            Gender = (Person.Gender == clsPerson.enGender.Male ? "Male" : "Female");
            Email = Person.Email.ToString();
            Address = Person.Address.ToString();
            DateOfBirth = Person.DateOfBirth.Date.ToShortDateString();
            Phone = Person.Phone.ToString();
            Country = clsCountry.FindCountryByID(Person.NationalityCountryID);

            if (!string.IsNullOrEmpty(Person.ImagePath))
            {
                LoadImage(Person.ImagePath);
            }
            else
            {
                if (Person.Gender == clsPerson.enGender.Male)
                {
                    SetImage(Resources.Male_512);
                }
                else
                {
                    SetImage(Resources.Female_512);
                }
            }

        }

    }
}
