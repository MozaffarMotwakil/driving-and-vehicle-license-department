using System;
using System.IO;
using System.Windows.Forms;
using DVLD.BusinessLogic;
using DVLD.WinForms.Properties;

namespace DVLD.WinForms.People
{
    public partial class ctrPersonCardInfo : UserControl
    {
        public bool IsInfoModified { get; private set; }

        public ctrPersonCardInfo()
        {
            InitializeComponent();
            IsInfoModified = false;
        }

        public event Action OnImageLoadFailed;

        protected virtual void ImageLoadFailed()
        {
            if (OnImageLoadFailed != null)
            {
                OnImageLoadFailed();
            }
        }

        public bool SuppressImageLoadWarning { get; set; }

        private void llEditPersonInformation_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddUpdatePerson addEditPersonForm = new frmAddUpdatePerson(int.Parse(lblPersonID.Text));
            addEditPersonForm.PersonBack += LoadPersonDataForDesplay;

            // To ensure a smoother user experience and avoid showing the image load warning again,
            // since it was already shown when opening the Person Details form.
            addEditPersonForm.SuppressImageLoadWarning = true;
            addEditPersonForm.ShowDialog();
            IsInfoModified = addEditPersonForm.IsSaveSuccess;
        }

        public void LoadPersonDataForDesplay(clsPerson Person)
        {
            lblPersonID.Text = Person.PersonID.ToString();
            lblNationalNumber.Text = Person.NationalNo.ToString();
            lblFullName.Text = Person.GetFullName();

            if (Person.Gender == clsPerson.enGender.Male)
            {
                lblGender.Text = "Male";
                pbGender.Image = Resources.Man_32;
            }
            else
            {
                lblGender.Text = "Female";
                pbGender.Image = Resources.Woman_32;
            }

            lblEmail.Text = Person.Email.ToString();
            lblAddress.Text = Person.Address.ToString();
            lblDateOfBirth.Text = Person.DateOfBirth.Date.ToShortDateString();
            lblPhone.Text = Person.Phone.ToString();
            lblCountry.Text = Person.CountryInfo.CountryName;
            pbPersonImage.Image = (Person.Gender == clsPerson.enGender.Male ? Resources.Male_512 : Resources.Female_512);

            if (!string.IsNullOrEmpty(Person.ImagePath))
            {
                if (File.Exists(Person.ImagePath))
                {
                    pbPersonImage.ImageLocation = Person.ImagePath;
                }
                else
                {
                    if (OnImageLoadFailed != null && !SuppressImageLoadWarning)
                    {
                        OnImageLoadFailed();
                    }
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
