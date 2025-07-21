using System;
using System.IO;
using System.Windows.Forms;
using DVLD.BusinessLogic;

namespace DVLD.WinForms.People
{
    public partial class frmAddEditPerson : Form
    {
        clsPerson Person;

        public delegate void PersonBackEventHandler(clsPerson Person);
        public event PersonBackEventHandler PersonBack;

        public frmAddEditPerson(int PersonID)
        {
            InitializeComponent();

            Person = clsPerson.Find(PersonID);

            if (Person == null)
            {
                Person = new clsPerson();
            }
        }

        private void frmAddEditPerson_Load(object sender, EventArgs e)
        {
            if (Person.Mode == clsPerson.enMode.AddNew)
            {
                lblHeader.Text = "Add New Person";
                return;
            }

            lblHeader.Text = "Update Person";
            lblPersonID.Text = Person.PersonID.ToString();
            ctrAddEditPerson.NationalNo = Person.NationalNo;
            ctrAddEditPerson.FirstName = Person.FirstName;
            ctrAddEditPerson.SecondName = Person.SecondName;
            ctrAddEditPerson.ThirdName = Person.ThirdName;
            ctrAddEditPerson.LastName = Person.LastName;
            ctrAddEditPerson.Email = Person.Email;
            ctrAddEditPerson.Phone = Person.Phone;
            ctrAddEditPerson.Address = Person.Address;
            ctrAddEditPerson.DateOfBirth = Person.DateOfBirth;
            ctrAddEditPerson.NationalityCountryID = Person.NationalityCountryID;

            // Set the national number to ignore in validation when editing an existing person
            // This prevents their own number from being flagged as a duplicate.
            ctrAddEditPerson.SetCurrentNationalNoToIgnore(Person.NationalNo);

            if (Person.Gender == clsPerson.enGender.Male)
            {
                ctrAddEditPerson.IsMale = true;
            }
            else
            {
                ctrAddEditPerson.IsFemale = true;
            }

            if (File.Exists(Person.ImagePath))
            {
                ctrAddEditPerson.LoadImage(Person.ImagePath);
            }
            else
            {
                Person.ImagePath = string.Empty;
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ctrAddEditPerson.IsDataValid())
            {
                MessageBox.Show(
                    "Cannot save because not all data is valid, please enter correct data.",
                    "Failed Save",
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
                
                return;
            }

            Person.FirstName = ctrAddEditPerson.FirstName;
            Person.SecondName = ctrAddEditPerson.SecondName;
            Person.ThirdName = ctrAddEditPerson.ThirdName;
            Person.LastName = ctrAddEditPerson.LastName;
            Person.NationalNo = ctrAddEditPerson.NationalNo;
            Person.DateOfBirth = ctrAddEditPerson.DateOfBirth;
            Person.Gender = ctrAddEditPerson.IsMale ? clsPerson.enGender.Male : clsPerson.enGender.Female;
            Person.Phone = ctrAddEditPerson.Phone;
            Person.Email = ctrAddEditPerson.Email;
            Person.Address = ctrAddEditPerson.Address;
            Person.NationalityCountryID = ctrAddEditPerson.NationalityCountryID;

            if (!string.IsNullOrEmpty(ctrAddEditPerson.ImagePath))
            {
                // Check if the selected image file still exists
                if (File.Exists(ctrAddEditPerson.ImagePath))
                {
                    Person.ImagePath = _SavePersonImage(ctrAddEditPerson.ImagePath);
                }
                else
                {
                    MessageBox.Show(
                        "The selected image file no longer exists. Please select a new image.",
                        "Image Not Found",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    Person.ImagePath = string.Empty;
                    return;
                }
            }
            else
            {
                Person.ImagePath = string.Empty;
            }

            if (Person.Save())
            {
                if (Person.Mode == clsPerson.enMode.AddNew)
                {
                    MessageBox.Show(
                        "The person has been added successfully.",
                        "Successfully Adding",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    // Switch to update mode after saving a new person,
                    // and reload the person from the database to get the new ID.
                    // This avoids closing and reopening the form, allowing smooth data editing.
                    // Also, mark the current national number to be ignored during validation.
                    lblHeader.Text = "Update Person";
                    Person = clsPerson.Find(Person.NationalNo);
                    lblPersonID.Text = Person.PersonID.ToString();
                    ctrAddEditPerson.SetCurrentNationalNoToIgnore(Person.NationalNo);

                }
                else
                {
                    MessageBox.Show(
                        "The person has been updated successfully.",
                        "Successfully Updating", 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Information);

                    if (ctrAddEditPerson.IsImageChanged())
                    {
                        try
                        {
                        TODO:
                            File.Delete(ctrAddEditPerson.OldImagePath());
                        }
                        catch (IOException ex)
                        {
                            MessageBox.Show(
                                $"Failed to delete the image file.\n{ex.Message}",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                    }

                }
            }
            else
            {
                MessageBox.Show(
                    "Failed save the person.",
                    "Failed Save", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// Saves a person’s image to the local folder for person images.
        /// </summary>
        /// <param name="SourceFilePath">
        /// The full path of the image currently displayed in the PictureBox or selected by the user.
        /// </param>
        /// <returns>
        /// Returns the new path where the image was saved inside the local folder.
        /// If the given path already points to the local folder, 
        /// the method does not copy the image again and returns the same path.
        /// </returns>
        private string _SavePersonImage(string SourceFilePath)
        {
            string appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string dvldImagesFolder = Path.Combine(appDataFolder, "DVLD-People-Images");

            if (!Directory.Exists(dvldImagesFolder))
            {
                Directory.CreateDirectory(dvldImagesFolder);
            }

            // If the image is already stored in the folder, it means it hasn't changed, so just return the path as-is
            if (SourceFilePath.Contains(dvldImagesFolder))
            {
                return SourceFilePath;
            }
            else
            {
                string destinationFilePath = Path.Combine(dvldImagesFolder, $"{Guid.NewGuid()}.JPG");
                File.Copy(SourceFilePath, destinationFilePath);
                return destinationFilePath;
            }
        }

        private void btnCloseScreen_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddEditPerson_FormClosing(object sender, FormClosingEventArgs e)
        {
            PersonBack?.Invoke(Person);
        }

    }
}
