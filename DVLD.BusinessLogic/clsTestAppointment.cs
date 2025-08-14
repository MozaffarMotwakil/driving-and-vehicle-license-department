using System;
using System.Data;
using DVLD.DataAccess;
using DVLD.Entities;

namespace DVLD.BusinessLogic
{
    public class clsTestAppointment
    {
        public int TestAppointmentID { get; private set; }
        public clsLocalLicenseApplication LocalLicenseApplicationInfo { get; private set; }
        public clsTestType.enTestType TestType { get; private set; }
        public DateTime AppointmentDate { get; set; }
        public float PaidFees { get; private set; }
        public bool IsLocked { get; private set; }
        public clsUser CreatedByUserInfo { get; private set; }
        public clsApplication RetakeTestApplicationInfo { get; private set; }
        private enMode Mode { get; set; }

        public clsTestAppointment(clsLocalLicenseApplication localLicenseApplication, clsTestType.enTestType testType)
        {
            if (localLicenseApplication == null)
            {
                throw new ArgumentNullException(nameof(localLicenseApplication),
                    "Local license application cannot be null.");
            }

            if (IsActiveTestAppointmentExist(localLicenseApplication.LocalLicenseApplicationID, testType))
            {
                throw new InvalidOperationException(
                    "An active test appointment for the specified test type already exists.");
            }

            if (clsTest.IsHasPassedTest(localLicenseApplication.LocalLicenseApplicationID, (int)testType))
            {
                throw new InvalidOperationException("The applicant has already passed this test type.");
            }

            TestAppointmentID = -1;
            LocalLicenseApplicationInfo = localLicenseApplication;
            TestType = testType;
            AppointmentDate = DateTime.Now.Date;
            PaidFees = clsTestType.Get(testType).Fees;
            IsLocked = false;
            CreatedByUserInfo = clsAppSettings.CurrentUser;
            RetakeTestApplicationInfo = _GetRetakeTestApplication();
            Mode = enMode.AddNew;
        }

        private clsTestAppointment(clsTestAppointmentEntity testAppointmentEntity)
        {
            TestAppointmentID = testAppointmentEntity.TestAppointmentID;
            TestType = (clsTestType.enTestType)testAppointmentEntity.TestTypeID;
            LocalLicenseApplicationInfo = clsLocalLicenseApplication.Find(testAppointmentEntity.LocalLicenseApplicationID);
            RetakeTestApplicationInfo = testAppointmentEntity.RetakeTestApplicationID == -1 ? null : clsApplication.FindBaseApplication(testAppointmentEntity.RetakeTestApplicationID);
            CreatedByUserInfo = clsUser.Find(testAppointmentEntity.CreatedByUserID);
            AppointmentDate = testAppointmentEntity.AppointmentDate;
            PaidFees = testAppointmentEntity.PaidFees;
            IsLocked = testAppointmentEntity.IsLocked;
            Mode = enMode.Update;
        }

        public static bool IsActiveTestAppointmentExist(int LocalLicenseApplicationID, clsTestType.enTestType testType)
        {
            return clsTestAppointmentData.GetActiveTestAppointmentID(
                    LocalLicenseApplicationID, (int)testType) != -1;
        }
        
        public int GetActiveTestAppointmentID()
        {
            return clsTestAppointmentData.GetActiveTestAppointmentID(
                    this.LocalLicenseApplicationInfo.LocalLicenseApplicationID, (int)this.TestType);
        }

        public static DataTable GetAllTestAppointmentsForLocalLicenseApplication(int LocalLicenseApplicationID, int TestTypeID)
        {
            return clsTestAppointmentData.GetAllTestAppointmentsForLocalLicenseApplication(LocalLicenseApplicationID, TestTypeID);
        }

        public static clsTestAppointment Find(int TestAppointmentID)
        {
            clsTestAppointmentEntity testAppointmentEntity = clsTestAppointmentData.FindTestAppointmentByID(TestAppointmentID);
            return testAppointmentEntity != null ? new clsTestAppointment(testAppointmentEntity) : null;
        }

        public bool Locked()
        {
            return clsTestAppointmentData.SetTestAppointmentToLocked(this.TestAppointmentID);
        }

        public bool IsHasRetakeTestApplication()
        {
            return this.RetakeTestApplicationInfo != null;
        }

        public int GetPreviousAttemptsCount()
        {
            return clsTest.GetAttemptsCountForLocalLicenseApplication(
                this.LocalLicenseApplicationInfo.LocalLicenseApplicationID,
                (int)this.TestType
                );
        }

        public float CalculateTotalFees()
        {
            return this.RetakeTestApplicationInfo != null ?
                this.PaidFees + this.RetakeTestApplicationInfo.PaidFees :
                this.PaidFees;
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (this.AppointmentDate < DateTime.Now.Date)
                    {
                        throw new InvalidOperationException("Appointment date cannot be in the past.");
                    }

                    if (this.IsHasRetakeTestApplication() && !this.RetakeTestApplicationInfo.Save())
                    {
                        throw new InvalidOperationException($"Failed to save the retake test application with ID " +
                            $"[{this.RetakeTestApplicationInfo.ApplicationID}].");
                    }

                    clsTestAppointmentEntity testAppointmentEntity = _MapTestAppointmentObjectToTestAppointmentEntity(this);
                    if (clsTestAppointmentData.AddNewTestAppointment(testAppointmentEntity))
                    {
                        this.TestAppointmentID = testAppointmentEntity.TestAppointmentID;
                        this.Mode = enMode.Update;
                        return true;
                    }

                    return false;
                case enMode.Update:
                    if (this.IsLocked)
                    {
                        throw new InvalidOperationException("Cannot update the appointment because it is locked.");
                    }

                    return clsTestAppointmentData.UpdateAppointmentDate(this.TestAppointmentID, this.AppointmentDate);
                default:
                    return false;
            }
        }

        private clsApplication _GetRetakeTestApplication()
        {
            if (this.GetPreviousAttemptsCount() == 0)
            {
                return null;
            }

            return new clsApplication(
                this.LocalLicenseApplicationInfo.ApplicationInfo.PersonInfo,
                clsApplicationType.Get(clsApplication.enApplicationType.RetakeTest),
                clsAppSettings.CurrentUser
                );
        }

        private clsTestAppointmentEntity _MapTestAppointmentObjectToTestAppointmentEntity(clsTestAppointment testAppointment)
        {
            return new clsTestAppointmentEntity(
                testAppointment.TestAppointmentID,
                (int)testAppointment.TestType,
                testAppointment.LocalLicenseApplicationInfo.LocalLicenseApplicationID,
                testAppointment.AppointmentDate,
                testAppointment.PaidFees,
                testAppointment.IsLocked,
                testAppointment.RetakeTestApplicationInfo != null ? testAppointment.RetakeTestApplicationInfo.ApplicationID : -1,
                testAppointment.CreatedByUserInfo.UserID
                );
        }

    }
}