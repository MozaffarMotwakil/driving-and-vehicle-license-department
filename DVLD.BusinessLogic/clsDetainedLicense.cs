using System;
using System.Data;
using DVLD.DataAccess;
using DVLD.Entities;

namespace DVLD.BusinessLogic
{
    public class clsDetainedLicense
    {
        public int DetainID { get; }
        public clsLicense LicenseInfo { get; }
        public DateTime DetainDate { get; }
        public float FineFees { get; }
        public clsUser CreatedByUserInfo { get; }
        public bool IsReleased { get; }
        public DateTime ReleaseDate { get; }
        public clsApplication ReleaseApplicationInfo { get; }
        public clsUser ReleasedByUserInfo { get; }

        private clsDetainedLicense() { }

        private clsDetainedLicense(clsDetainedLicenseEntity detainedLicenseEntity)
        {
            this.DetainID = detainedLicenseEntity.DetainID;
            this.LicenseInfo = clsLicense.FindByLicenseID(detainedLicenseEntity.LicenseID);
            this.DetainDate = detainedLicenseEntity.DetainDate;
            this.FineFees = detainedLicenseEntity.FineFees;
            this.CreatedByUserInfo = clsUser.Find(detainedLicenseEntity.CreatedByUserID);
            this.IsReleased = detainedLicenseEntity.IsReleased;
            this.ReleaseDate = detainedLicenseEntity.ReleaseDate;
            this.ReleaseApplicationInfo = clsApplication.FindBaseApplication(detainedLicenseEntity.ReleaseApplicationID);
            this.ReleasedByUserInfo = clsUser.Find(detainedLicenseEntity.ReleasedByUserID);
        }

        public static bool IsLicenseDetained(int LicenseID)
        {
            return clsDetainedLicenseData.IsLicenseDetained(LicenseID);
        }
        
        public static clsDetainedLicense Find(int LicenseID)
        {
            clsDetainedLicenseEntity detainedLicenseEntity = clsDetainedLicenseData.FindDetainedLicense(LicenseID);
            return detainedLicenseEntity != null ? new clsDetainedLicense(detainedLicenseEntity) : null;
        }

        public static bool DetainLicense(int LicenseID, DateTime DetainDate, float FineFees, int CreatedByUserID)
        {
            return clsDetainedLicenseData.DetainLicense(LicenseID, DetainDate, FineFees, CreatedByUserID);
        }

        public static bool ReleaseDetainedLicense(int LicenseID, DateTime ReleaseDate, int ReleasedByUserID, int ReleaseApplicationID)
        {
            return clsDetainedLicenseData.ReleaseDetainedLicense(LicenseID, ReleaseDate, ReleasedByUserID, ReleaseApplicationID);
        }

        public static DataTable GetAllDetainedLicenses()
        {
            return clsDetainedLicenseData.GetAllDetainedLicenses();
        }

    }
}