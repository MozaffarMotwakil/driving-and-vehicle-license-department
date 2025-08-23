using System;

namespace DVLD.Entities
{
    public class clsDetainedLicenseEntity
    {
        public int DetainID { get; set; }
        public int LicenseID { get; set; }
        public DateTime DetainDate { get; set; }
        public float FineFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsReleased { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int ReleaseApplicationID { get; set; }
        public int ReleasedByUserID { get; set; }

        public clsDetainedLicenseEntity() { }

        public clsDetainedLicenseEntity(int detainID, int licenseID, DateTime detainDate, float fineFees, int createdByUserID, 
            bool isReleased, DateTime releaseDate, int releaseApplicationID, int releasedByUserID)
        {
            DetainID = detainID;
            LicenseID = licenseID;
            DetainDate = detainDate;
            FineFees = fineFees;
            CreatedByUserID = createdByUserID;
            IsReleased = isReleased;
            ReleaseDate = releaseDate;
            ReleaseApplicationID = releaseApplicationID;
            ReleasedByUserID = releasedByUserID;
        }

    }
}