using System.Data;
using DVLD.DataAccess;
using DVLD.Entities;

namespace DVLD.BusinessLogic
{
    public class clsApplicationType
    {
        public int ID { get; }
        public string Title { get; set; }
        public float Fees { get; set; }

        private clsApplicationType(clsApplicationTypeEntity applicationTypeEntity)
        {
            this.ID = applicationTypeEntity.ID;
            this.Title = applicationTypeEntity.Title;
            this.Fees = applicationTypeEntity.Fees;
        }

        public static DataTable GetAllApplicationTypes()
        {
            return clsApplicationTypeData.GetAllApplicationTypes();
        }

        public static clsApplicationType Find(int ApplicationTypeID)
        {
            return new clsApplicationType(clsApplicationTypeData.FindApplicationTypeByID(ApplicationTypeID));
        }

        public bool Save()
        {
            return clsApplicationTypeData.UpdateApplicationType(_MapApplicationTypeObjectToApplicationTypeEntity(this));
        }

        private static clsApplicationTypeEntity _MapApplicationTypeObjectToApplicationTypeEntity(clsApplicationType applicationType)
        {
            return new clsApplicationTypeEntity(
                applicationType.ID,
                applicationType.Title,
                applicationType.Fees
                );
        }

    }
}
