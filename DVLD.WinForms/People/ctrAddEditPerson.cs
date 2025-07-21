using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using DVLD.BusinessLogic;
using DVLD.WinForms.Properties;

namespace DVLD.WinForms.People
{
    public partial class ctrAddEditPerson : UserControl
    {
        public string FirstName
        {
            get { return txtFirstName.Text; } 
            set { txtFirstName.Text = value; }
        }
        public string SecondName 
        {
            get { return txtSecondName.Text; } 
            set { txtSecondName.Text = value; }
        }
        public string ThirdName 
        { 
            get { return txtThirdName.Text; } 
            set { txtThirdName.Text = value; }
        }
        public string LastName 
        { 
            get { return txtLastName.Text; } 
            set { txtLastName.Text = value; }
        }
        public string NationalNo 
        {
            get { return txtNationalNo.Text; }
            set { txtNationalNo.Text = value; }
        }
        public DateTime DateOfBirth
        {
            get { return dtpDateOfBirth.Value; } 
            set { dtpDateOfBirth.Value = value; }
        }
        public string Phone
        {
            get { return txtPhone.Text; } 
            set { txtPhone.Text = value; }
        }
        public string Email 
        {
            get { return txtEmail.Text; } 
            set { txtEmail.Text = value; } 
        }
        public int NationalityCountryID
        {
            get { return cbCountry.SelectedIndex + 1; } 
            set { cbCountry.SelectedIndex = value - 1; }
        }
        public string Address 
        {
            get { return txtAddress.Text; } 
            set { txtAddress.Text = value; }
        }
        public string ImagePath
        { 
            get { return pbPersonImage.ImageLocation; } 
            // Set its value when load an image
        }
        public bool IsMale 
        { 
            get { return rbMale.Checked; }
            set { rbMale.Checked = value; } 
        }
        public bool IsFemale 
        { 
            get { return rbFemale.Checked; } 
            set { rbFemale.Checked = value; }
        }

        private string _OldImagePath = string.Empty;

        private bool _IsImageChanged = false;

        private string _CurrentNationalNo;

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

        public ctrAddEditPerson()
        {
            InitializeComponent();
            _CurrentNationalNo = string.Empty;
            _FillCountriesComboBox();
        }

        public void LoadImage(string ImagePath)
        {
            pbPersonImage.Load(ImagePath);
            pbPersonImage.ImageLocation = ImagePath;
            llRemoveImage.Visible = true;
        }

        public bool IsImageChanged()
        {
            return _IsImageChanged;
        }

        public string OldImagePath()
        {
            return _OldImagePath;
        }

        /// <summary>
        /// Validates all input fields by triggering their Validating events and checks for errors.
        /// </summary>
        /// <returns>
        /// True if all inputs are valid (no error messages); otherwise, false.
        /// </returns>
       public bool IsDataValid()
        {
            this.ValidateChildren();

            foreach (Control control in groupBox.Controls)
            {
                if (errorProvider.GetError(control) != "")
                    return false;
            }

            return true;
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
            string oldImagePath = pbPersonImage.ImageLocation;

            if (!string.IsNullOrEmpty(oldImagePath))
            {
                _IsImageChanged = true;
                _OldImagePath = oldImagePath;
            }

        }

        private void llSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog openImagePath = new OpenFileDialog();
            openImagePath.Title = "Set Image";
            openImagePath.InitialDirectory = @"C:\";
            openImagePath.Filter = "JPG files (*.JPG)|*JPG|png files (*.png)|*.png|All files (*.*)|*.*";
            openImagePath.DefaultExt = "JPG";
            openImagePath.FilterIndex = 1;

            if (openImagePath.ShowDialog() == DialogResult.OK)
            {
                _SetOldImageDetails();

                string newImagePath = openImagePath.FileName;
                pbPersonImage.ImageLocation = newImagePath;
                pbPersonImage.Load(newImagePath);
                llRemoveImage.Visible = true;
            }
        }

        private void llRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _SetOldImageDetails();

            pbPersonImage.Image = IsMale ? Resources.Male_512 : Resources.Female_512;
            pbPersonImage.ImageLocation = string.Empty;
            llRemoveImage.Visible = false;
        }

        private void _FillCountriesComboBox()
        {
            DataTable countries = clsCountry.GetAllCountries();

            foreach (DataRow country in countries.Rows)
            {
                cbCountry.Items.Add(country["CountryName"].ToString());
            }
        }

        private void _SetGenderImage(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(pbPersonImage.ImageLocation))
            {
                if (rbMale.Checked)
                {
                    pbPersonImage.Image = Resources.Male_512;
                }
                else
                {
                    pbPersonImage.Image = Resources.Female_512;
                }
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
            string nationalNo = txtNationalNo.Text;
            
            if (!string.IsNullOrEmpty(nationalNo))
            {
                if (!string.IsNullOrEmpty(_CurrentNationalNo) && _CurrentNationalNo == nationalNo)
                {
                    return;
                }

                if (clsPerson.IsPersonExist(nationalNo))
                {
                    errorProvider.SetError(txtNationalNo, "National number is used from another person");
                }
                else
                {
                    errorProvider.SetError(txtNationalNo, "");
                }
            }
        }

        private bool _CheckIsPhoneValid(string PhoneNumber)
        {
            for (int i = 0; i < PhoneNumber.Length; i++)
            {
                if (!char.IsDigit(PhoneNumber[i]))
                {
                    return false;
                }
            }

            return true;
        }

        private void txtPhone_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _ValidatingRequiredField(sender as Control, "Phone number is required field.");
            string phone = txtPhone.Text;

            if (!string.IsNullOrEmpty(phone))
            {
                if (!_CheckIsPhoneValid(phone) || phone.Length != 10)
                {
                    errorProvider.SetError(txtPhone, "Phone number must consist of 10 numbers only.");
                }
                else
                {
                    errorProvider.SetError(txtPhone, "");
                }
            }
        }

        private void txtEmail_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string email = txtEmail.Text;

            if (!string.IsNullOrEmpty(email) && !email.Contains("@gmail.com"))
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
