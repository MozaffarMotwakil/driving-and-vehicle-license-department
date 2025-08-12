using System;
using System.Data;
using DVLD.DataAccess;
using DVLD.Entities;

namespace DVLD.BusinessLogic
{
    public class clsTestAppointment
    {
        public int TestAppointmentID { get; set; }
        public clsTestType.enTestType TestType { get; set; }
        public clsLocalLicenseApplication LocalLicenseApplicationInfo { get; set; }
        public DateTime AppointmentDate { get; set; }
        public float PaidFees { get; set; }
        public bool IsLocked { get; set; }
        public clsApplication RetakeTestApplicationInfo { get; set; }
        public clsUser CreatedByUserInfo { get; set; }
        private enMode Mode { get; set; }

        public clsTestAppointment()
        {
            TestAppointmentID = -1;
            TestType = clsTestType.enTestType.Vision;
            LocalLicenseApplicationInfo = null;
            RetakeTestApplicationInfo = null;
            CreatedByUserInfo = null;
            AppointmentDate = DateTime.Now.Date;
            PaidFees = 0;
            IsLocked = false;
            Mode = enMode.AddNew;
        }

        private clsTestAppointment(clsTestAppointmentEntity testAppointmentEntity)
        {
            TestAppointmentID = testAppointmentEntity.TestAppointmentID;
            TestType = (clsTestType.enTestType)testAppointmentEntity.TestTypeID;
            LocalLicenseApplicationInfo = clsLocalLicenseApplication.Find(testAppointmentEntity.LocalLicenseApplicationID);
            RetakeTestApplicationInfo = clsApplication.FindBaseApplication(testAppointmentEntity.RetakeTestApplicationID);
            CreatedByUserInfo = clsUser.Find(testAppointmentEntity.CreatedByUserID);
            AppointmentDate = testAppointmentEntity.AppointmentDate;
            PaidFees = testAppointmentEntity.PaidFees;
            IsLocked = testAppointmentEntity.IsLocked;
            Mode = enMode.Update;
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

        public bool Save()
        {
            clsTestAppointmentEntity testAppointmentEntity = _MapTestAppointmentObjectToTestAppointmentEntity(this);

            switch (Mode)
            {
                case enMode.AddNew:
                    if (clsTestAppointmentData.AddNewTestAppointment(testAppointmentEntity))
                    {
                        this.TestAppointmentID = testAppointmentEntity.TestAppointmentID;
                        this.Mode = enMode.Update;
                        return true;
                    }

                    return false;
                case enMode.Update:
                    return clsTestAppointmentData.UpdateAppointmentDate(this.TestAppointmentID, this.AppointmentDate);
                default:
                    return false;
            }
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
                testAppointment.RetakeTestApplicationInfo.ApplicationID,
                testAppointment.CreatedByUserInfo.UserID
                );
        }

    }
}
