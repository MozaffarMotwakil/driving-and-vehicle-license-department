using System.Data;
using DVLD.DataAccess;
using DVLD.Entities;

namespace DVLD.BusinessLogic
{
    public class clsTestType
    {
        public enum enTestType { Vision = 1, Written = 2, Street = 3 };

        public int TypeID { get; }
        public string Title { get; set; }
        public string Description { get; set; }
        public float Fees { get; set; }

        private clsTestType(clsTestTypeEntity testTypeEntity)
        {
            this.TypeID = testTypeEntity.TypeID;
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

        public static clsTestType Get(enTestType testType)
        {
            return Find((int)testType);
        }

        public bool Save()
        {
            return clsTestTypeData.UpdateTestType(_MapTestTypeObjectToTestTypeEntity(this));
        }

        private static clsTestTypeEntity _MapTestTypeObjectToTestTypeEntity(clsTestType testType)
        {
            return new clsTestTypeEntity(
                testType.TypeID,
                testType.Title,
                testType.Description,
                testType.Fees
                );
        }

    }
}