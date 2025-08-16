using System;

namespace DVLD.Entities
{
    public class clsLicenseEntity
    {
        public int LicenseID { get; set; }
        public int DriverID { get; set; }
        public int ApplicationID { get; set; }
        public int LicenseClassID { get; set; }
        public int IssueReasonID { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Notes { get; set; }
        public float PaidFees { get; set; }
        public bool IsActive { get; set; }

        public clsLicenseEntity() { }

        public clsLicenseEntity(int licenseID, int driverID, int applicationID, int licenseClassID, int issueReasonID,
            int createdByUserID, DateTime issueDate, DateTime expirationDate, string notes, float paidFees, bool isActive)
        {
            LicenseID = licenseID;
            DriverID = driverID;
            ApplicationID = applicationID;
            LicenseClassID = licenseClassID;
            IssueReasonID = issueReasonID;
            CreatedByUserID = createdByUserID;
            IssueDate = issueDate;
            ExpirationDate = expirationDate;
            Notes = notes;
            PaidFees = paidFees;
            IsActive = isActive;
        }
    }
}
