using System;

namespace DVLD.Entities
{
    public class clsTestAppointmentEntity
    {
        public int TestAppointmentID { get; set; }
        public int TestTypeID { get; set; }
        public int LocalLicenseApplicationID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public float PaidFees { get; set; }
        public bool IsLocked { get; set; }
        public int RetakeTestApplicationID { get; set; }
        public int CreatedByUserID { get; set; }

        public clsTestAppointmentEntity() { }

        public clsTestAppointmentEntity(int testAppointmentID, int testTypeID, int localLicenseApplicationID, DateTime appointmentDate, float paidFees, bool isLocked, int retakeTestApplicationID, int createdByUserID)
        {
            TestAppointmentID = testAppointmentID;
            TestTypeID = testTypeID;
            LocalLicenseApplicationID = localLicenseApplicationID;
            AppointmentDate = appointmentDate;
            PaidFees = paidFees;
            IsLocked = isLocked;
            RetakeTestApplicationID = retakeTestApplicationID;
            CreatedByUserID = createdByUserID;
        }

    }
}
