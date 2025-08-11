using System;
using DVLD.DataAccess;
using System.Data;
using DVLD.Entities;

namespace DVLD.BusinessLogic
{
    public class clsLocalLicenseApplication
    {
        public int LocalLicenseApplicationID { get; set; }
        public clsApplication ApplicationInfo { get; set; }
        public clsLicenseClass LicenseClassInfo { get; set; }
        private enMode Mode { get; set; }

        public clsLocalLicenseApplication() 
        {
            LocalLicenseApplicationID = -1;
            this.ApplicationInfo = new clsApplication(clsApplication.enApplicationType.NewLocalDrivingLicenseService);
            this.LicenseClassInfo = new clsLicenseClass();
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

        public bool Save()
        {
            clsLocalLicenseApplicationEntity localLicenseApplicationEntity = _MapLocalLicenseApplicationObjectToLocalLicenseApplicationEntity(this);

            switch (Mode)
            {
                case enMode.AddNew:
                    if (clsLocalLicenseApplicationData.AddNewLocalLicenseApplication(localLicenseApplicationEntity))
                    {
                        this.LocalLicenseApplicationID = localLicenseApplicationEntity.LocalLicenseApplicationID;
                        this.Mode = enMode.Update;
                        return true;
                    }

                    return false;
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