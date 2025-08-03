using System.Data;
using DVLD.DataAccess;
using DVLD.Entities;

namespace DVLD.BusinessLogic
{
    public class clsTestType
    {
        public int ID { get; }
        public string Title { get; set; }
        public string Description { get; set; }
        public float Fees { get; set; }

        private clsTestType(clsTestTypeEntity testTypeEntity)
        {
            this.ID = testTypeEntity.ID;
            this.Title = testTypeEntity.Title;
            this.Description = testTypeEntity.Description;
            this.Fees = testTypeEntity.Fees;
        }

        public static DataTable GetAllTestTypes()
        {
            return clsTestTypeData.GetAllTestTypes();
        }

        public static clsTestType Find(int TestTypeID)
        {
            return new clsTestType(clsTestTypeData.FindTestTypeByID(TestTypeID));
        }

        public bool Save()
        {
            return clsTestTypeData.UpdateTestType(_MapTestTypeObjectToTestTypeEntity(this));
        }

        private static clsTestTypeEntity _MapTestTypeObjectToTestTypeEntity(clsTestType testType)
        {
            return new clsTestTypeEntity(
                testType.ID,
                testType.Title,
                testType.Description,
                testType.Fees
                );
        }
    }
}
