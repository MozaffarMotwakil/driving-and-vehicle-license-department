using System;
using DVLD.DataAccess;
using DVLD.Entities;

namespace DVLD.BusinessLogic
{
    public class clsTest
    {
        public int TestID { get; private set; }
        public clsTestAppointment TestAppointmentInfo { get; }
        public bool TestResult { get; set; }
        public string Notes { get; set; }
        public clsUser CreatedByUserInfo { get; }

        public clsTest(clsTestAppointment testAppointment)
        {
            if (testAppointment == null)
            {
                throw new ArgumentNullException(nameof(testAppointment), "Test appointment cannot be null.");
            }

            if (testAppointment.IsLocked)
            {
                throw new InvalidOperationException("Test appointment is locked, cannot create an exam.");
            }

            TestID = -1;
            TestAppointmentInfo = testAppointment;
            TestResult = false;
            Notes = string.Empty;
            CreatedByUserInfo = clsAppSettings.CurrentUser;
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
            if (this.TestAppointmentInfo.IsHasRetakeTestApplication() && !this.TestAppointmentInfo.RetakeTestApplicationInfo.SetCompleted())
            {
                throw new InvalidOperationException(
                    $"Failed to update status of the ratake test application with ID " +
                    $"[{this.TestAppointmentInfo.RetakeTestApplicationInfo.ApplicationID}] to completed.");
            }

            if (!this.TestAppointmentInfo.Locked())
            {
                throw new InvalidOperationException(
                    $"Failed to set the test appointment with ID " +
                    $"[{this.TestAppointmentInfo.TestAppointmentID}] to locked.");
            }

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
