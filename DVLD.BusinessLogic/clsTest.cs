using System;
using DVLD.DataAccess;
using DVLD.Entities;

namespace DVLD.BusinessLogic
{
    public class clsTest
    {
        public int TestID { get; set; }
        public clsTestAppointment TestAppointmentInfo { get; set; }
        public bool TestResult { get; set; }
        public string Notes { get; set; }
        public clsUser CreatedByUserInfo { get; set; }

        public clsTest()
        {
            TestID = -1;
            TestAppointmentInfo = null;
            TestResult = false;
            Notes = string.Empty;
            CreatedByUserInfo = null;
        }

        private clsTest(clsTestEntity testEntity)
        {
            TestID = testEntity.TestID;
            TestAppointmentInfo = clsTestAppointment.Find(testEntity.TestAppointmentID);
            TestResult = testEntity.TestResult;
            Notes = testEntity.Notes;
            CreatedByUserInfo = clsUser.Find(testEntity.CreatedByUserID);
        }

        public static clsTest Find(int TestAppointmentID)
        {
            clsTestEntity testEntity = clsTestData.FindTestByID(TestAppointmentID);
            return testEntity != null ? new clsTest(testEntity) : null;
        }

        public bool Save()
        {
            clsTestEntity testEntity = _MapTestObjectToTestEntity(this);

            if (clsTestData.AddNewTest(testEntity))
            {
                this.TestID = testEntity.TestID;
                return true;
            }

            return false;
        }

        private clsTestEntity _MapTestObjectToTestEntity(clsTest test)
        {
            return new clsTestEntity(
                test.TestID,
                test.TestAppointmentInfo.TestAppointmentID,
                test.TestResult,
                test.Notes,
                test.CreatedByUserInfo.UserID
                );
        }

    }
}
