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
        public clsLicenseClass LicenseClassInfo { get; }
        private enMode Mode { get; set; }

        public clsLocalLicenseApplication(clsPerson person, clsLicenseClass licenseClass) 
        {
            if (licenseClass == null)
            {
                throw new ArgumentNullException(nameof(licenseClass), "License class cannot be null.");
            }

            LocalLicenseApplicationID = -1;
            this.ApplicationInfo = new clsApplication(person, clsApplication.enApplicationType.NewLocalDrivingLicenseService);
            
            if (IsActiveLocalLicenseApplicationExist(person.PersonID, licenseClass.LicenseClassID))
            {
                throw new InvalidOperationException("Person already have an active application for the selected class.");
            }

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

        public static bool IsActiveLocalLicenseApplicationExist(int PersonID, int LicenseClassID)
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

        public int GetPassedTestCount()
        {
            return clsTest.GetPassedTestsCountForLocalLicenseApplication(this.LocalLicenseApplicationID);
        }

        public clsTestType.enTestType GetCurrentTestType()
        {
            switch (this.GetPassedTestCount())
            {
                case 0:
                    return clsTestType.enTestType.Vision;
                case 1:
                    return clsTestType.enTestType.Written;
                default:
                    return clsTestType.enTestType.Street;
            }
        }

        public bool Save()
        {
            clsLocalLicenseApplicationEntity localLicenseApplicationEntity = _MapLocalLicenseApplicationObjectToLocalLicenseApplicationEntity(this);

            switch (Mode)
            {
                case enMode.AddNew:
                    if (!this.ApplicationInfo.Save())
                    {
                        throw new InvalidOperationException($"Failed to save the base application.");
                    }

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
                    return clsLocalLicenseApplicationData.UpdateLocalLicenseApplication(localLicenseApplicationEntity);
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