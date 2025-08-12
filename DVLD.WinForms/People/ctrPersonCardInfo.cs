using System;
using System.IO;
using System.Windows.Forms;
using DVLD.BusinessLogic;
using DVLD.WinForms.Utils;
using DVLD.WinForms.Properties;

namespace DVLD.WinForms.People
{
    public partial class ctrPersonCardInfo : UserControl
    {
        /// <summary>
        /// Gets the person if found successfully, otherwise returns null.
        /// </summary>
        public clsPerson Person { get; private set; }

        public bool ShowEditPersonInformationLinke { get; set; }

        public event Action InfoModified;
        protected virtual void OnInfoModified()
        {
            InfoModified?.Invoke();
        }

        public ctrPersonCardInfo()
        {
            InitializeComponent();
            ShowEditPersonInformationLinke = true;
            llEditPersonInformation.Visible = false;
        }

        public event Action ImageLoadFailed;
        protected virtual void OnImageLoadFailed()
        {
            if (ImageLoadFailed != null)
            {
                ImageLoadFailed();
            }
        }

        public bool SuppressImageLoadWarning { get; set; }

        private void llEditPersonInformation_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddUpdatePerson addEditPersonForm = new frmAddUpdatePerson(int.Parse(lblPersonID.Text));
            addEditPersonForm.PersonBack += LoadPersonDataForDisplay;
            addEditPersonForm.SaveSuccess += OnInfoModified;

            // To ensure a smoother user experience and avoid showing the image load warning again,
            // since it was already shown when opening the Person Details form.
            addEditPersonForm.SuppressImageLoadWarning = true;
            addEditPersonForm.ShowDialog();
        }

        public void LoadPersonDataForDisplay(clsPerson Person)
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
            pbPersonImage.Image = clsFormHelper.GetDefaultPersonImage(Person.Gender);

            if (!string.IsNullOrEmpty(Person.ImagePath))
            {
                if (File.Exists(Person.ImagePath))
                {
                    pbPersonImage.ImageLocation = Person.ImagePath;
                }
                else
                {
                    if (ImageLoadFailed != null && !SuppressImageLoadWarning)
                    {
                        OnImageLoadFailed();
                    }
                }
            }

            llEditPersonInformation.Visible = ShowEditPersonInformationLinke;
            this.Person = Person;
        }

        /// <summary>
        /// Clears all displayed person data, replacing it with default placeholder values (question marks).
        /// Resets the person image to the default male person image, and disable edit person link.
        /// </summary>
        public void Clear()
        {
            lblPersonID.Text = lblNationalNumber.Text = lblGender.Text = lblDateOfBirth.Text = lblFullName.Text =
                lblEmail.Text = lblAddress.Text = lblPhone.Text = lblCountry.Text = "???";

            pbPersonImage.Image = clsFormHelper.GetDefaultPersonImage(clsPerson.enGender.Male);
            llEditPersonInformation.Visible = false;
            this.Person = null;
        }

    }
}
