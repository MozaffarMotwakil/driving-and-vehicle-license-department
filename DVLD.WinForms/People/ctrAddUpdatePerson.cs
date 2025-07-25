using System;
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
            cbCountry.Items.AddRange(clsSettings.GetCountries());
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

        /// <summary>
        /// Validates all input fields within this UserControl.
        /// </summary>
        /// <remarks>
        /// This method runs validation for all child controls using <c>ValidateChildren</c>,
        /// then manually checks for any validation errors using a <c>foreach</c> loop.
        ///
        /// Unlike the standard validation flow that relies on <c>e.Cancel</c> to stop focus change
        /// when a control is invalid, this method intentionally avoids that behavior.
        ///
        /// The goal behind using a <c>foreach</c> loop is to allow users to freely navigate
        /// between fields even if some contain invalid data. Error messages will still appear
        /// via the <c>ErrorProvider</c>, but users won't be blocked from moving around.
        ///
        /// This design provides a smoother user experience by postponing strict validation enforcement
        /// until the point of saving, rather than interrupting the user's input flow.
        ///
        /// </remarks>
        /// <returns>
        /// <c>true</c> if all fields are valid (no validation errors); otherwise, <c>false</c>.
        /// </returns>
        public bool IsDataValid()
        {
            this.ValidateChildren();

            foreach (Control control in this.Controls)
            {
                if (errorProvider.GetError(control) != "")
                {
                    return false;
                }
            }

            return true;
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

        private void _SetGenderImage(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(pbPersonImage.ImageLocation))
            {
                pbPersonImage.Image = IsMale ? Resources.Male_512 : Resources.Female_512;
            }
        }

        private void _ValidatingRequiredField(Control control, string ErrorMessage)
        {
            if (string.IsNullOrWhiteSpace(control.Text))
            {
                errorProvider.SetError(control, ErrorMessage);
            }
            else
            {
                errorProvider.SetError(control, "");
            }
        }

        private void txtFirstName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _ValidatingRequiredField(sender as Control, "First name is required field.");
        }

        private void txtSecondName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _ValidatingRequiredField(sender as Control, "Second name is required field.");
        }

        private void txtLastName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _ValidatingRequiredField(sender as Control, "Last name is required field.");
        }

        private void txtNationalNo_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _ValidatingRequiredField(sender as Control, "National number is required field.");
            
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
            _ValidatingRequiredField(sender as Control, "Phone number is required field.");

            if (!string.IsNullOrEmpty(Phone))
            {
                if (!clsValidation.IsValidPhone(Phone) || Phone.Length != 10)
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
            clsValidation.HandleNumericKeyPress(e, txtPhone, errorProvider);
        }

        private void txtEmail_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(Email) && !clsValidation.IsValidEmail(Email))
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
            _ValidatingRequiredField(sender as Control, "Address is required field.");
        }

    }
}
