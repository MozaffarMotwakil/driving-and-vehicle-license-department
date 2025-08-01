﻿using System;
using System.IO;
using System.Windows.Forms;
using DVLD.BusinessLogic;
using DVLD.WinForms.Global;
using DVLD.WinForms.Properties;

namespace DVLD.WinForms.People
{
    public partial class ctrPersonCardInfo : UserControl
    {
        public string PersonID
        {
            get { return lblPersonID.Text; }
        }
        public string FullName
        {
            get { return lblFullName.Text; }
        }
        public string NationalNo
        {
            get { return lblNationalNumber.Text; }
        }
        public string DateOfBirth
        {
            get { return lblDateOfBirth.Text; }
        }
        public string Phone
        {
            get { return lblPhone.Text; }
        }
        public string Email
        {
            get { return lblEmail.Text; }
        }
        public string CountryName
        {
            get { return lblCountry.Text; }
        }
        public string Address
        {
            get { return lblAddress.Text; }
        }
        public string Gender
        {
            get { return lblGender.Text; }
        }
        public bool IsInfoModified { get; private set; }

        public ctrPersonCardInfo()
        {
            InitializeComponent();
            IsInfoModified = false;
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
                        ImageLoadFailed();
                    }
                }
            }

            llEditPersonInformation.Visible = true;
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
        }

    }
}
