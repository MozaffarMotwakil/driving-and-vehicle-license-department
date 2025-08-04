using System;
using DVLD.DataAccess;
using DVLD.Entities;

namespace DVLD.BusinessLogic
{
    public class clsApplication
    {
        public int ApplicationID { get; set; }
        public int PersonID { get; set; }
        public int TypeID { get; set; }
        public int StatusID { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastStatusDate { get; set; }
        public float PaidFees { get; set; }
        public enMode Mode { get; set; }

        public clsApplication()
        {
            ApplicationID = PersonID = TypeID =
                StatusID = CreatedByUserID = -1;

            CreatedDate = LastStatusDate = DateTime.Now;
            PaidFees = 0;
            this.Mode = enMode.AddNew;
        }

        private clsApplication(clsApplicationEntity applicationEntity)
        {
            this.ApplicationID = applicationEntity.ApplicationID;
            this.PersonID = applicationEntity.PersonID;
            this.TypeID = applicationEntity.TypeID;
            this.StatusID = applicationEntity.StatusID;
            this.CreatedByUserID = applicationEntity.CreatedByUserID;
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
                application.PersonID,
                application.TypeID,
                application.StatusID,
                application.CreatedByUserID,
                application.CreatedDate,
                application.LastStatusDate,
                application.PaidFees
                );
        }

    }
}
