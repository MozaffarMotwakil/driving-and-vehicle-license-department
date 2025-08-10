using System;
using System.Runtime.CompilerServices;
using DVLD.DataAccess;
using DVLD.Entities;

namespace DVLD.BusinessLogic
{
    public class clsApplication
    {
        public enum enApplicationType
        {
            NewLocalDrivingLicenseService = 1,
            RenewDrivingLicenseService = 2,
            ReplacementForLostDrivingLicense = 3,
            ReplacementForDamagedDrivingLicense = 4,
            ReleaseDetainedDrivingLicence = 5,
            NewInternationalLicense = 6,
            RetakeTest = 7
        }

        public enum enApplicationStatus
        {
            New = 1,
            Cancelled = 2,
            Completed = 3
        }

        public int ApplicationID { get; set; }
        public clsPerson PersonInfo { get; set; }
        public clsApplicationType TypeInfo { get; set; }
        public enApplicationStatus Status { get; set; }
        public clsUser CreatedByUserInfo { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastStatusDate { get; set; }
        public float PaidFees { get; set; }
        private enMode Mode { get; set; }

        internal clsApplication(enApplicationType applicationType)
        {
            ApplicationID = -1;
            PersonInfo = new clsPerson();
            CreatedByUserInfo = new clsUser();
            TypeInfo = clsApplicationType.Get(applicationType);
            Status = enApplicationStatus.New;
            CreatedDate = LastStatusDate = DateTime.Now;
            PaidFees = 0;
            this.Mode = enMode.AddNew;
        }

        private clsApplication(clsApplicationEntity applicationEntity)
        {
            this.ApplicationID = applicationEntity.ApplicationID;
            this.PersonInfo = clsPerson.Find(applicationEntity.PersonID);
            this.TypeInfo = clsApplicationType.Find(applicationEntity.TypeID);
            this.Status = (enApplicationStatus)applicationEntity.StatusID;
            this.CreatedByUserInfo = clsUser.Find(applicationEntity.CreatedByUserID);
            this.CreatedDate = applicationEntity.CreatedDate;
            this.LastStatusDate = applicationEntity.LastStatusDate;
            this.PaidFees = applicationEntity.PaidFees;
            this.Mode = enMode.Update;
        }

        public static int CreateApplication(int PersonID, enApplicationType applicationType)
        {
            clsApplication application = new clsApplication(applicationType);
            application.PersonInfo.PersonID = PersonID;
            application.CreatedByUserInfo.UserID = clsAppSettings.CurrentUser.UserID;
            application.PaidFees = application.TypeInfo.Fees;

            return application.Save() ? application.ApplicationID : -1;
        }

        public static bool IsApplicaionExist(int ApplicationID)
        {
            return clsApplicationData.IsApplicationExist(ApplicationID);
        }

        public static clsApplication FindBaseApplication(int BaseApplicationID)
        {
            return new clsApplication(clsApplicationData.FindApplicationByID(BaseApplicationID));
        }

        public static bool Delete(int ApplicationID)
        {
            return clsApplicationData.DeleteApplication(ApplicationID);
        }

        public bool SetCanclled()
        {
            if (this.Status != enApplicationStatus.New)
            {
                return false;
            }

            return clsApplicationData.UpdateStatus(this.ApplicationID, (int)enApplicationStatus.Cancelled);
        }

        public bool SetCompleted()
        {
            if (this.Status != enApplicationStatus.New)
            {
                return false;
            }

            return clsApplicationData.UpdateStatus(this.ApplicationID, (int)enApplicationStatus.Completed);
        }

        public static int GetActiveApplicationID(int PersonID, enApplicationType applicationType)
        {
            return clsApplicationData.GetActiveApplicationID(PersonID, (int)applicationType);
        }

        public bool Save()
        {
            clsApplicationEntity applicationEntity = _MapApplicationObjectToApplicationEntity(this);

            switch (Mode)
            {
                case enMode.AddNew:
                    if (clsApplicationData.AddNewApplication(applicationEntity))
                    {
                        this.ApplicationID = applicationEntity.ApplicationID;
                        this.Mode = enMode.Update;
                        return true;

                    }
                    
                    return false;
                case enMode.Update:
                    return clsApplicationData.UpdateApplication(applicationEntity);
                default:
                    return false;
            }

        }

        private clsApplicationEntity _MapApplicationObjectToApplicationEntity(clsApplication application)
        {
            return new clsApplicationEntity(
                application.ApplicationID,
                application.PersonInfo.PersonID,
                application.TypeInfo.TypeID,
                (int)application.Status,
                application.CreatedByUserInfo.UserID,
                application.CreatedDate,
                application.LastStatusDate,
                application.PaidFees
                );
        }

    }
}
