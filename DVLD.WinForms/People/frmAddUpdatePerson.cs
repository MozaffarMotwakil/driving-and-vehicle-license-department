using System;
using System.Windows.Forms;
using DVLD.BusinessLogic;
using DVLD.WinForms.Utils;

namespace DVLD.WinForms.People
{
    public partial class frmAddUpdatePerson : Form
    {
        private clsPerson _Person;
        private enMode _FormMode;

        public delegate void PersonBackEventHandler(clsPerson Person);
        public event PersonBackEventHandler PersonBack;
        protected virtual void OnPersonBack()
        {
            PersonBack?.Invoke(_Person);
        }

        public event Action SaveSuccess;
        protected virtual void OnSaveSuccess()
        {
            if (SaveSuccess != null)
            {
                SaveSuccess();
            }
        }

        public bool SuppressImageLoadWarning
        {
            get { return ctrAddEditPerson.SuppressImageLoadWarning; }
            set { ctrAddEditPerson.SuppressImageLoadWarning = value; }
        }

        public frmAddUpdatePerson()
        {
            InitializeComponent();
            this.Text = lblHeader.Text = "Add New Person";
            _FormMode = enMode.AddNew;
            _Person = new clsPerson();
            lblPersonID.Text = "N/A";
        }
       
        public frmAddUpdatePerson(int PersonID)
        {
            InitializeComponent();
            this.Text = lblHeader.Text = "Update Person";
            _FormMode = enMode.Update;
            _Person = clsPerson.Find(PersonID);
            lblPersonID.Text = _Person.PersonID.ToString();
        }

        private void CtrAddEditPerson_OnImageLoadFailed()
        {
            clsFormMessages.ShowImageNotFoundWarning();
        }

        private void frmAddEditPerson_Load(object sender, EventArgs e)
        {
            if (_Person == null)
            {
                clsFormMessages.ShowPersonNotFoundError();
                this.Close();
                return;
            }

            ctrAddEditPerson.ImageLoadFailed += CtrAddEditPerson_OnImageLoadFailed;
            ctrAddEditPerson.LoadPersonDataForEdit(_Person);
            ctrAddEditPerson.SetCurrentNationalNoToIgnore(_Person.NationalNo);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ctrAddEditPerson.IsDataValid())
            {
                clsFormMessages.ShowInvalidDataError();
                return;
            }

            if (clsFormMessages.ConfirmSava())
            {
                _FillPersonObjectFromUI();

                if (!_HandlePersonImageSaving())
                {
                    return;
                }

                if (_Person.Save())
                {
                    clsFormMessages.ShowSuccess("Saved successfully.");

                    if (_FormMode == enMode.AddNew)
                    {
                        _UpdateFormStateAfterSave();
                    }

                    OnPersonBack();
                    OnSaveSuccess();
                    ctrAddEditPerson.OldImagePath = string.Empty;
                }
                else
                {
                    clsFormMessages.ShowError("Failed Save.");
                }
            }
        }

        private void _FillPersonObjectFromUI()
        {
            _Person.FirstName = ctrAddEditPerson.FirstName;
            _Person.SecondName = ctrAddEditPerson.SecondName;
            _Person.ThirdName = ctrAddEditPerson.ThirdName;
            _Person.LastName = ctrAddEditPerson.LastName;
            _Person.NationalNo = ctrAddEditPerson.NationalNo;
            _Person.DateOfBirth = ctrAddEditPerson.DateOfBirth;
            _Person.Gender = ctrAddEditPerson.IsMale ? clsPerson.enGender.Male : clsPerson.enGender.Female;
            _Person.Phone = ctrAddEditPerson.Phone;
            _Person.Email = ctrAddEditPerson.Email;
            _Person.Address = ctrAddEditPerson.Address;
            _Person.CountryInfo.CountryID = ctrAddEditPerson.CountryID;
            _Person.CountryInfo.CountryName = ctrAddEditPerson.CountryName;
        }

        private bool _HandlePersonImageSaving()
        {
            if (_Person.ImagePath != ctrAddEditPerson.ImagePath)
            {
                string oldImagePath = ctrAddEditPerson.OldImagePath;
                string selectedImagePath = ctrAddEditPerson.ImagePath;

                try
                {
                    if (!string.IsNullOrEmpty(selectedImagePath))
                    {
                        _Person.SaveImage(selectedImagePath);
                        ctrAddEditPerson.LoadImage(_Person.ImagePath);
                    }
                    else
                    {
                        _Person.DeleteImage();
                    }

                }
                catch (Exception ex)
                {
                    clsFormMessages.ShowError($"Failed to save the new person's image file.\n{ex.Message}");
                    
                    if (!string.IsNullOrEmpty(oldImagePath))
                    {
                        _ReloadTheOldImage(oldImagePath);
                    }

                    return false;
                }
            }

            return true;
        }

        private void _UpdateFormStateAfterSave()
        {
            _FormMode = enMode.Update;
            lblHeader.Text = "Update Person";
            lblPersonID.Text = _Person.PersonID.ToString();
            ctrAddEditPerson.SetCurrentNationalNoToIgnore(_Person.NationalNo);
        }

        private void _ReloadTheOldImage(string OldImagePath)
        {
            ctrAddEditPerson.LoadImage(OldImagePath);
            _Person.ImagePath = OldImagePath;
        }

        private void btnCloseScreen_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}