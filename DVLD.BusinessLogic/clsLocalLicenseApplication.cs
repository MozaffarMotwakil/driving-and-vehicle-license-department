using System;
using DVLD.DataAccess;
using System.Data;
using DVLD.Entities;

namespace DVLD.BusinessLogic
{
    public class clsLocalLicenseApplication
    {
        public int LocalLicenseApplicationID { get; private set; }
        public clsApplication ApplicationInfo { get; }
        public clsLicenseClass LicenseClassInfo { get; set; }
        private enMode Mode { get; set; }

        public clsLocalLicenseApplication(clsPerson person, clsLicenseClass licenseClass) 
        {
            if (person == null)
            {
                throw new ArgumentNullException(nameof(person), "Person cannot be null.");
            }

            if (licenseClass == null)
            {
                throw new ArgumentNullException(nameof(licenseClass), "License class cannot be null.");
            }

            if (IsThereActiveLocalLicenseApplication(person.PersonID, licenseClass.LicenseClassID))
            {
                throw new InvalidOperationException("Person already have an active application for the selected class.");
            }

            if (clsLicense.IsPersonHasLicense(person.PersonID, licenseClass.LicenseClassID))
            {
                throw new InvalidOperationException("Person already have a license in this class, cannot issue a new license.");
            }

            LocalLicenseApplicationID = -1;
            this.ApplicationInfo = new clsApplication(person, clsApplication.enApplicationType.NewLocalDrivingLicenseService);
            this.LicenseClassInfo = licenseClass;
            this.Mode = enMode.AddNew;
        }

        private clsLocalLicenseApplication(clsLocalLicenseApplicationEntity localLicenseApplicationEntity)
        {
            this.LocalLicenseApplicationID = localLicenseApplicationEntity.LocalLicenseApplicationID;
            this.ApplicationInfo = clsApplication.FindBaseApplication(localLicenseApplicationEntity.ApplicationID);
            this.LicenseClassInfo = clsLicenseClass.Find(localLicenseApplicationEntity.LicenseClassID);
            this.Mode = enMode.Update;
        }

        public static DateTime GetMinimumApplicationDate()
        {
            return clsLocalLicenseApplicationData.GetMinimumApplicationDate();
        }

        public static DateTime GetMaximumApplicationDate()
        {
            return clsLocalLicenseApplicationData.GetMaximumApplicationDate();
        }

        public static bool IsLocalLicenseApplicationExist(int LocalLicenseApplicationID)
        {
            return clsLocalLicenseApplicationData.IsLocalLicenseApplicationExist(LocalLicenseApplicationID);
        }

        public static bool IsThereActiveLocalLicenseApplication(int PersonID, int LicenseClassID)
        {
            return clsLocalLicenseApplicationData.GetActiveApplicationIDForLicenseClass(PersonID, LicenseClassID) != -1;
        }

        public static clsLocalLicenseApplication GetActiveLocalLicenseApplication(int PersonID, int LicenseClassID)
        {
            int applicationID = clsLocalLicenseApplicationData.GetActiveApplicationIDForLicenseClass(PersonID, LicenseClassID);
            return applicationID != -1 ? Find(applicationID) : null;
        }

        public static DataTable GetAllLocalLicenseApplications()
        {
            return clsLocalLicenseApplicationData.GetAllLocalLicenseApplications();
        }

        public static clsLocalLicenseApplication Find(int LocalLicenseApplicationID)
        {
            clsLocalLicenseApplicationEntity localLicenseApplicationEntity = clsLocalLicenseApplicationData.FindLocalLicenseApplicationByID(LocalLicenseApplicationID);
            return localLicenseApplicationEntity != null ? new clsLocalLicenseApplication(localLicenseApplicationEntity) : null;
        }

        public static bool Delete(int LocalLicenseApplicationID)
        {
            int baseApplicationID = Find(LocalLicenseApplicationID).ApplicationInfo.ApplicationID;
            return clsLocalLicenseApplicationData.DeleteLocalLicenseApplication(LocalLicenseApplicationID) && 
                clsApplication.Delete(baseApplicationID);
        }

        public clsTestType.enTestType GetCurrentTestType()
        {
            switch (this.PassedTestsCount())
            {
                case 0:
                    return clsTestType.enTestType.Vision;
                case 1:
                    return clsTestType.enTestType.Written;
                default:
                    return clsTestType.enTestType.Street;
            }
        }

        public DataTable GetAllTestAppointments(clsTestType.enTestType TestType)
        {
            return clsLocalLicenseApplicationData.GetAllTestAppointments(this.LocalLicenseApplicationID, (int)TestType);
        }

        public bool IsThereActiveTestAppointment(clsTestType.enTestType testType)
        {
            return clsLocalLicenseApplicationData.GetActiveTestAppointmentID(
                    this.LocalLicenseApplicationID, (int)testType) != -1;
        }

        public bool IsPassedThisTestType(clsTestType.enTestType TestType)
        {
            return clsLocalLicenseApplicationData.GetPassedTestID(this.LocalLicenseApplicationID, (int)TestType) != -1;
        }

        public int AttemptsCountForTestType(clsTestType.enTestType TestType)
        {
            return clsLocalLicenseApplicationData.GetAttemptsCountForTestType(this.LocalLicenseApplicationID, (int)TestType);
        }

        public int PassedTestsCount()
        {
            return clsLocalLicenseApplicationData.GetPassedTestsCount(this.LocalLicenseApplicationID);
        }

        public bool IsPersonHasLicense()
        {
            return clsLicenseData.IsLicenseExist(this.ApplicationInfo.PersonInfo.PersonID, this.LicenseClassInfo.LicenseClassID);
        }

        /// <summary>
        /// Issues a new local license for the first time associated with this application.
        /// </summary>
        /// <param name="Notes">
        /// Additional notes or comments to be recorded with the license issuance.
        /// </param>
        /// <returns>
        /// The newly created <see cref="clsLicense.LicenseID"/> if the license is successfully issued;  
        /// otherwise, <c>-1</c> if the person already holds a license in this license class.
        /// </returns>
        /// <remarks>
        /// This method checks whether the person already has a license using 
        /// <see cref="IsPersonHasLicense"/>.  
        /// If no license exists, it creates a new <see cref="clsLicense"/> object, passing this 
        /// application and the provided notes, and issues the license.
        /// </remarks>
        /// <seealso cref="clsLicense"/>
        /// <seealso cref="IsPersonHasLicense"/>
        public int IssueLicenseForFirstTime(string Notes)
        {
            if (this.IsPersonHasLicense())
            {
                return -1;
            }

            return new clsLicense(this, Notes).IssueLicenseForFirstTime();
        }

        public bool Save()
        {
            switch (this.Mode)
            {
                case enMode.AddNew:
                    if (!this.ApplicationInfo.Save())
                    {
                        throw new InvalidOperationException($"Failed to save the base application.");
                    }

                    clsLocalLicenseApplicationEntity localLicenseApplicationEntity = _MapLocalLicenseApplicationObjectToLocalLicenseApplicationEntity(this);

                    if (clsLocalLicenseApplicationData.AddNewLocalLicenseApplication(localLicenseApplicationEntity))
                    {
                        this.LocalLicenseApplicationID = localLicenseApplicationEntity.LocalLicenseApplicationID;
                        this.Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        if (!clsApplication.Delete(this.ApplicationInfo.ApplicationID))
                        {
                            throw new InvalidOperationException(
                                $"Failed to delete the base application with ID ." +
                                $"[{this.ApplicationInfo.ApplicationID}].");
                        }

                        return false;
                    }
                case enMode.Update:
                    return clsLocalLicenseApplicationData.UpdateLicenseClassForLocalLicenseApplication(this.LocalLicenseApplicationID, this.LicenseClassInfo.LicenseClassID);
                default:
                    return false;
            }
        }
    
        private clsLocalLicenseApplicationEntity _MapLocalLicenseApplicationObjectToLocalLicenseApplicationEntity(clsLocalLicenseApplication localLicenseApplication)
        {
            return new clsLocalLicenseApplicationEntity(
                localLicenseApplication.LocalLicenseApplicationID,
                localLicenseApplication.ApplicationInfo.ApplicationID,
                localLicenseApplication.LicenseClassInfo.LicenseClassID
                );
        }

    }
}