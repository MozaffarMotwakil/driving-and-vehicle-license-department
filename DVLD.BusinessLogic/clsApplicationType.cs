using System.Data;
using DVLD.DataAccess;
using DVLD.Entities;

namespace DVLD.BusinessLogic
{
    public class clsApplicationType
    {
        public int TypeID { get; }
        public clsApplication.enApplicationType Type
        {
            get { return (clsApplication.enApplicationType)this.TypeID; }
        }
        public string Title { get; set; }
        public float Fees { get; set; }

        private clsApplicationType(clsApplicationTypeEntity applicationTypeEntity)
        {
            this.TypeID = applicationTypeEntity.TypeID;
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

        public static clsApplicationType Get(clsApplication.enApplicationType applicationType)
        {
            return Find((int)applicationType);
        }

        public bool Save()
        {
            return clsApplicationTypeData.UpdateApplicationType(_MapApplicationTypeObjectToApplicationTypeEntity(this));
        }

        private static clsApplicationTypeEntity _MapApplicationTypeObjectToApplicationTypeEntity(clsApplicationType applicationType)
        {
            return new clsApplicationTypeEntity(
                applicationType.TypeID,
                applicationType.Title,
                applicationType.Fees
                );
        }

    }
}
