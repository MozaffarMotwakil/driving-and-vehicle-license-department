using System;
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

        public int ApplicationID { get; private set; }
        public clsPerson PersonInfo { get; }
        public clsApplicationType TypeInfo { get; }
        public enApplicationStatus Status { get; }
        public clsUser CreatedByUserInfo { get; }
        public DateTime CreatedDate { get; }
        public DateTime LastStatusDate { get; }
        public float PaidFees { get; }
        private enMode Mode { get; set; }

        public clsApplication(clsPerson person, enApplicationType applicationType)
        {
            if (person == null)
            {
                throw new ArgumentNullException(nameof(person), "Person cannot be null.");
            }

            ApplicationID = -1;
            PersonInfo = person;
            TypeInfo = clsApplicationType.Get(applicationType);
            Status = enApplicationStatus.New;
            CreatedByUserInfo = clsAppSettings.CurrentUser;
            PaidFees = TypeInfo.Fees;
            Mode = enMode.AddNew;
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
                application.PaidFees
                );
        }

    }
}
