using System;
using DVLD.DataAccess;
using DVLD.Entities;

namespace DVLD.BusinessLogic
{
    public class clsTest
    {
        public int TestID { get; private set; }
        public clsTestAppointment TestAppointmentInfo { get; private set; }
        public bool TestResult { get; set; }
        public string Notes { get; set; }
        public clsUser CreatedByUserInfo { get; private set; }

        public clsTest(clsTestAppointment testAppointment)
        {
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

        public static int GetAttemptsCountForLocalLicenseApplication(int LocalLicenseApplicationID, int TestTypeID)
        {
            return clsTestData.GetAttemptsCountForLocalLicenseApplication(LocalLicenseApplicationID, TestTypeID);
        }

        public static int GetPassedTestsCountForLocalLicenseApplication(int LcoalLicenseApplicationID)
        {
            return clsTestData.GetPassedTestsCountForLocalLicenseApplication(LcoalLicenseApplicationID);
        }

        public static int GetPassedTestID(int LocalLicenseApplicationID, int TestTypeID)
        {
            return clsTestData.GetPassedTestID(LocalLicenseApplicationID, TestTypeID);
        }

        public static bool IsHasPassedTest(int LocalLicenseApplicationID, int TestTypeID)
        {
            return clsTestData.GetPassedTestID(LocalLicenseApplicationID, TestTypeID) != -1;
        }

        public static clsTest Find(int TestAppointmentID)
        {
            clsTestEntity testEntity = clsTestData.FindTestByID(TestAppointmentID);
            return testEntity != null ? new clsTest(testEntity) : null;
        }

        public bool Save()
        {
            if (this.TestAppointmentInfo.IsHasRetakeTestApplication())
            {
                this.TestAppointmentInfo.RetakeTestApplicationInfo.Status = clsApplication.enApplicationStatus.Completed;

                if (!this.TestAppointmentInfo.RetakeTestApplicationInfo.Save())
                {
                    this.TestAppointmentInfo.RetakeTestApplicationInfo.Status = clsApplication.enApplicationStatus.New;
                    throw new InvalidOperationException(
                        $"Failed to update status of the ratake test appointment with ID " +
                        $"[{this.TestAppointmentInfo.RetakeTestApplicationInfo.ApplicationID}] to completed.");
                }
            }

            if (!this.TestAppointmentInfo.Locked())
            {
                throw new InvalidOperationException(
                    $"Failed to update the test appointment with ID " +
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
