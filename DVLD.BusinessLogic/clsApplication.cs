using System;
using DVLD.DataAccess;
using DVLD.Entities;

namespace DVLD.BusinessLogic
{
    public class clsApplication
    {
        public int ApplicationID { get; set; }
        public clsPerson PersonInfo { get; set; }
        public clsApplicationType TypeInfo { get; set; }
        public clsApplicationStatus StatusInfo { get; set; }
        public clsUser CreatedByUserInfo { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastStatusDate { get; set; }
        public float PaidFees { get; set; }
        public enMode Mode { get; set; }

        public clsApplication()
        {
            ApplicationID = -1;
            PersonInfo = null;
            TypeInfo = null;
            StatusInfo = null;
            CreatedByUserInfo = null;
            CreatedDate = LastStatusDate = DateTime.Now;
            PaidFees = 0;
            this.Mode = enMode.AddNew;
        }

        private clsApplication(clsApplicationEntity applicationEntity)
        {
            this.ApplicationID = applicationEntity.ApplicationID;
            this.PersonInfo = clsPerson.Find(applicationEntity.PersonID);
            this.TypeInfo = clsApplicationType.Find(applicationEntity.TypeID);
            this.StatusInfo = clsApplicationStatus.Find(applicationEntity.StatusID);
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

        public static clsApplication Find(int ApplicationID)
        {
            return new clsApplication(clsApplicationData.FindApplicationByID(ApplicationID));
        }

        public static bool Delete(int ApplicationID)
        {
            return clsApplicationData.DeleteApplication(ApplicationID);
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
                application.StatusInfo.StatusID,
                application.CreatedByUserInfo.UserID,
                application.CreatedDate,
                application.LastStatusDate,
                application.PaidFees
                );
        }

    }
}
