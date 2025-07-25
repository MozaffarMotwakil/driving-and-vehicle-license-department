using System;
using System.Windows.Forms;
using DVLD.BusinessLogic;
using DVLD.WinForms.Global;
using DVLD.WinForms.Utils;

namespace DVLD.WinForms.People
{
    public partial class frmAddUpdatePerson : Form
    {
        // تسخدم للتحقق هل يتم تحديث قائمة الأشخاص أم لا
        public bool IsSaveSuccess { get; private set; }

        private clsPerson _Person;
        private clsPerson.enMode _FormMode;

        public delegate void PersonBackEventHandler(clsPerson Person);
        public event PersonBackEventHandler PersonBack;

        public bool SuppressImageLoadWarning
        {
            get { return ctrAddEditPerson.SuppressImageLoadWarning; }
            set { ctrAddEditPerson.SuppressImageLoadWarning = value; }
        }

        public frmAddUpdatePerson()
        {
            InitializeComponent();
            IsSaveSuccess = false;
            _FormMode = clsPerson.enMode.AddNew;
            _Person = new clsPerson();
            ctrAddEditPerson.OnImageLoadFailed += CtrAddEditPerson_OnImageLoadFailed;
        }
       
        public frmAddUpdatePerson(int PersonID)
        {
            InitializeComponent();
            IsSaveSuccess = false;
            _FormMode = clsPerson.enMode.Update;
            _Person = clsPerson.Find(PersonID);
            ctrAddEditPerson.OnImageLoadFailed += CtrAddEditPerson_OnImageLoadFailed;
        }

        private void CtrAddEditPerson_OnImageLoadFailed()
        {
            clsMessages.ShowImageNotFoundWarning();
        }

        private void frmAddEditPerson_Load(object sender, EventArgs e)
        {
            lblHeader.Text = (_FormMode == clsPerson.enMode.AddNew ? "Add New Person" : "Update Person");
            lblPersonID.Text = (_Person.PersonID != -1 ? _Person.PersonID.ToString() : "N/A");
            ctrAddEditPerson.LoadPersonDataForEdit(_Person);

            // Set the national number to ignore in validation when editing an existing person
            // This prevents their own number from being flagged as a duplicate.
            ctrAddEditPerson.SetCurrentNationalNoToIgnore(_Person.NationalNo);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ctrAddEditPerson.IsDataValid())
            {
                Utils.clsMessages.ShowError("Cannot save because not all data is valid. Please enter correct data.", "Save Failed");
                return;
            }

            if (Utils.clsMessages.Confirm("Are you sure you want save?"))
            {
                _FillPersonObjectFromUI();

                if (!_HandlePersonImageSaving())
                {
                    return;
                }

                if (_Person.Save())
                {
                    if (_FormMode == clsPerson.enMode.AddNew)
                    {
                        clsMessages.ShowSuccess("The person has been added successfully.", "Add Successful");
                        _UpdateFormStateAfterSave();
                    }
                    else
                    {
                        clsMessages.ShowSuccess("The person has been updated successfully.", "Update Successful");
                    }

                    IsSaveSuccess = true;
                    PersonBack?.Invoke(_Person);

                    // Reset the OldImagePath property to ensure correct behavior
                    // in ctrAddEditPerson.SetOldImagePath. (See method for details)
                    ctrAddEditPerson.OldImagePath = string.Empty;
                }
                else
                {
                    clsMessages.ShowError("Failed to save the person.", "Save Failed");
                }
            }
        }

        private void _ReloadTheOldImage(string OldImagePath)
        {
            ctrAddEditPerson.LoadImage(OldImagePath);
            _Person.ImagePath = OldImagePath;
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
            // Check if the image was changed or a new image was set
            if (_Person.ImagePath != ctrAddEditPerson.ImagePath)
            {
                string oldImagePath = ctrAddEditPerson.OldImagePath;
                string selectedImagePath = ctrAddEditPerson.ImagePath;

                // Set the new image path in the DVLD-People-Images folder (local storage)
                string newImagePath = clsSettings.GetNewImagePathWithGUID();

                try
                {
                    // If there is a selected image, copy it to the new location
                    if (!string.IsNullOrEmpty(selectedImagePath))
                    {
                        clsFileManager.SavePersonImageToLocalFolder(selectedImagePath, newImagePath);
                        _Person.ImagePath = newImagePath;

                        /*
                         * Switch the selected image to the new path so that operations are performed
                         * on it (operations of selecting the old path for deletion) to avoid the problem
                         * of not deleting the image stored in the local folder and deleting the image in the
                         * original path from which it was selected.
                         */
                        ctrAddEditPerson.LoadImage(newImagePath);
                    }
                    else
                    {
                        // If the image is deleted.
                        _Person.ImagePath = string.Empty;
                    }

                    if (ctrAddEditPerson.IsImageChanged())
                    {
                        try
                        {
                            clsFileManager.DeletePersonImageFromLocalFolder(oldImagePath);
                        }
                        catch (Exception ex)
                        {
                            clsMessages.ShowFailedDeleteThePersonImage(ex);
                            _ReloadTheOldImage(oldImagePath);
                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    clsMessages.ShowError($"Failed to save the new person's image file.\n{ex.Message}");
                    _ReloadTheOldImage(oldImagePath);
                    return false;
                }
            }

            return true;
        }

        private void _UpdateFormStateAfterSave()
        {
            _FormMode = clsPerson.enMode.Update;
            lblHeader.Text = "Update Person";
            lblPersonID.Text = _Person.PersonID.ToString();
            ctrAddEditPerson.SetCurrentNationalNoToIgnore(_Person.NationalNo);
        }

        private void btnCloseScreen_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
