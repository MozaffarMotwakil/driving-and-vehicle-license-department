﻿using System;
using System.IO;
using System.Windows.Forms;
using DVLD.BusinessLogic;
using DVLD.WinForms.Global;
using DVLD.WinForms.Properties;
using DVLD.WinForms.Utils;

namespace DVLD.WinForms.People
{
    public partial class ctrAddUpdatePerson : UserControl
    {
        public event Action OnImageLoadFailed;

        protected virtual void ImageLoadFailed()
        {
            if (OnImageLoadFailed != null)
            {
                OnImageLoadFailed();
            }
        }

        public string FirstName
        {
            get { return txtFirstName.Text; } 
            private set { txtFirstName.Text = value; }
        }
        public string SecondName 
        {
            get { return txtSecondName.Text; }
            private set { txtSecondName.Text = value; }
        }
        public string ThirdName 
        { 
            get { return txtThirdName.Text; }
            private set { txtThirdName.Text = value; }
        }
        public string LastName 
        { 
            get { return txtLastName.Text; }
            private set { txtLastName.Text = value; }
        }
        public string NationalNo 
        {
            get { return txtNationalNo.Text; }
            private set { txtNationalNo.Text = value; }
        }
        public DateTime DateOfBirth
        {
            get { return dtpDateOfBirth.Value; }
            private set { dtpDateOfBirth.Value = value; }
        }
        public string Phone
        {
            get { return txtPhone.Text; }
            private set { txtPhone.Text = value; }
        }
        public string Email 
        {
            get { return txtEmail.Text; }
            private set { txtEmail.Text = value; } 
        }
        public int CountryID
        {
            get { return cbCountry.SelectedIndex + 1; }
            private set { cbCountry.SelectedIndex = value - 1; }
        } 
        public string CountryName
        {
            get { return cbCountry.SelectedItem.ToString(); }
            private set { cbCountry.SelectedItem = value; }
        }
        public string Address 
        {
            get { return txtAddress.Text; }
            private set { txtAddress.Text = value; }
        }
        public string ImagePath
        { 
            get { return pbPersonImage.ImageLocation; } 
            // Set its value From LoadImage method.
        }
        public bool IsMale 
        { 
            get { return rbMale.Checked; }
            private set { rbMale.Checked = value; } 
        }
        public bool IsFemale 
        { 
            get { return rbFemale.Checked; }
            private set { rbFemale.Checked = value; }
        }
        public bool SuppressImageLoadWarning { get; set; }
        public string OldImagePath { get; set; }

        private string _CurrentNationalNo;

        private bool _IsImageChanged;

        /// <summary>
        /// Sets the current national number to be ignored during validation.
        /// This is useful when editing an existing person’s information,
        /// so their own national number does not trigger the duplicate check.
        /// </summary>
        /// <param name="NationalNo">
        /// The national number to ignore in the validation process.
        /// </param>
        public void SetCurrentNationalNoToIgnore(string NationalNo)
        {
            _CurrentNationalNo = NationalNo;
        }

        public ctrAddUpdatePerson()
        {
            InitializeComponent();
            cbCountry.Items.AddRange(clsAppSettings.GetCountries());
            OldImagePath = string.Empty;
            _CurrentNationalNo = string.Empty;
            _IsImageChanged = false;
        }

        public void LoadImage(string ImagePath)
        {
            pbPersonImage.ImageLocation = ImagePath;
            llRemoveImage.Visible = true;
        }

        public bool IsImageChanged()
        {
            return _IsImageChanged;
        }

        public bool IsDataValid()
        {
            return clsFormValidation.IsDataValid(this, errorProvider);
        }

        public void LoadPersonDataForEdit(clsPerson Person)
        {
            NationalNo = Person.NationalNo;
            FirstName = Person.FirstName;
            SecondName = Person.SecondName;
            ThirdName = Person.ThirdName;
            LastName = Person.LastName;
            Email = Person.Email;
            Phone = Person.Phone;
            Address = Person.Address;
            DateOfBirth = Person.DateOfBirth;
            CountryID = Person.CountryInfo.CountryID;
            IsMale = (Person.Gender == clsPerson.enGender.Male);
            IsFemale = (Person.Gender == clsPerson.enGender.Female);

            if (!string.IsNullOrEmpty(Person.ImagePath))
            {
                if (File.Exists(Person.ImagePath))
                {
                    LoadImage(Person.ImagePath);
                }
                else
                {
                    if (OnImageLoadFailed != null && !SuppressImageLoadWarning)
                    {
                        ImageLoadFailed();
                    }
                }
            }

        }

        private void ctrAddEditPerson_Load(object sender, EventArgs e)
        {
            rbMale.Checked = true;
            cbCountry.SelectedIndex = 164;
            dtpDateOfBirth.MaxDate = DateTime.Now.Date.AddYears(-18);
            llRemoveImage.Visible = false;
        }

        private void llSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog openSetNewImage = new OpenFileDialog();
            openSetNewImage.Title = "Set Image";
            openSetNewImage.InitialDirectory = @"C:\";
            openSetNewImage.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp|.jpg|*.jpg|.png|*.png";
            openSetNewImage.DefaultExt = "JPG";
            openSetNewImage.FilterIndex = 1;

            if (openSetNewImage.ShowDialog() == DialogResult.OK)
            {
                _SetOldImageDetails();
                pbPersonImage.ImageLocation = openSetNewImage.FileName;
                llRemoveImage.Visible = true;
            }
        }

        private void llRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _SetOldImageDetails();
            pbPersonImage.Image = IsMale ? Resources.Male_512 : Resources.Female_512;
            llRemoveImage.Visible = false;
        }

        private void txtFirstName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            clsFormValidation.ValidatingRequiredField(sender as Control, "First name is required field.", errorProvider);
        }

        private void txtSecondName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            clsFormValidation.ValidatingRequiredField(sender as Control, "Second name is required field.", errorProvider);
        }

        private void txtLastName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            clsFormValidation.ValidatingRequiredField(sender as Control, "Last name is required field.", errorProvider);
        }

        private void txtNationalNo_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            clsFormValidation.ValidatingRequiredField(sender as Control, "National number is required field.", errorProvider);
            
            if (!string.IsNullOrEmpty(NationalNo))
            {
                if (!string.IsNullOrEmpty(_CurrentNationalNo) && _CurrentNationalNo.ToUpper() == NationalNo.ToUpper())
                {
                    return;
                }

                if (clsPerson.IsPersonExist(NationalNo))
                {
                    errorProvider.SetError(txtNationalNo, "National number is used from another person");
                }
                else
                {
                    errorProvider.SetError(txtNationalNo, "");
                }
            }
        }

        private void txtPhone_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            clsFormValidation.ValidatingRequiredField(sender as Control, "Phone number is required field.", errorProvider);

            if (!string.IsNullOrEmpty(Phone))
            {
                if (!clsValidationHelper.IsValidPhone(Phone) || Phone.Length != 10)
                {
                    errorProvider.SetError(txtPhone, "Phone number must consist of 10 numbers only.");
                }
                else
                {
                    errorProvider.SetError(txtPhone, "");
                }
            }
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsFormValidation.HandleNumericKeyPress(e, txtPhone, errorProvider);
        }

        private void txtEmail_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(Email) && !clsValidationHelper.IsValidEmail(Email))
            {
                errorProvider.SetError(txtEmail, "Email must end with @gmail.com");
            }
            else
            {
                errorProvider.SetError(txtEmail, "");
            }
        }

        private void txtAddress_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            clsFormValidation.ValidatingRequiredField(sender as Control, "Address is required field.", errorProvider);
        }

        private void _SetGenderImage(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(pbPersonImage.ImageLocation))
            {
                pbPersonImage.Image = clsFormHelper.GetDefaultPersonImage((IsMale ? clsPerson.enGender.Male : clsPerson.enGender.Female));
            }
        }

        private void _SetOldImageDetails()
        {
            // Mark the current image path as the old one only if OldImagePath is still empty.
            // This ensures we keep the original path of the first image changed in the session,
            // preventing overwriting it if the user sets multiple images before saving.
            // This helps track and delete the old image later if it is no longer used.
            if (!string.IsNullOrEmpty(ImagePath) && string.IsNullOrEmpty(OldImagePath))
            {
                _IsImageChanged = true;
                OldImagePath = ImagePath;
            }

            pbPersonImage.Image = null;
            pbPersonImage.ImageLocation = string.Empty;
        }

    }
}
