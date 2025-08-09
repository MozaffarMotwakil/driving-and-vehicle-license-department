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
        public enMode Mode { get; set; }

        public clsLocalLicenseApplication() 
        {
            LocalLicenseApplicationID = -1;
            this.ApplicationInfo = null;
            this.LicenseClassInfo = null;
            this.Mode = enMode.AddNew;
        }

        private clsLocalLicenseApplication(clsLocalLicenseApplicationEntity localLicenseApplicationEntity)
        {
            this.LocalLicenseApplicationID = localLicenseApplicationEntity.LocalLicenseApplicationID;
            this.ApplicationInfo = clsApplication.Find(localLicenseApplicationEntity.ApplicationID);
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
            return clsLocalLicenseApplicationData.DeleteLocalLicenseApplication(LocalLicenseApplicationID);
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
