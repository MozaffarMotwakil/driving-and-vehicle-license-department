using System;
using DVLD.DataAccess;
using System.Data;
using DVLD.Entities;

namespace DVLD.BusinessLogic
{
    public class clsLicenseClass
    {
        public int LicenseClassID { get; }
        public string ClassName { get; }
        public string ClassDescription { get; }
        public byte MinimumAllowedAge { get; }
        public byte DefaultValidityLength { get; }
        public float ClassFees { get; }

        private clsLicenseClass(clsLicenseClassEntity licenseClassEntity)
        {
            this.LicenseClassID = licenseClassEntity.LicenseClassID;
            this.ClassName = licenseClassEntity.ClassName;
            this.ClassDescription = licenseClassEntity.ClassDescription;
            this.MinimumAllowedAge = licenseClassEntity.MinimumAllowedAge;
            this.DefaultValidityLength = licenseClassEntity.DefaultValidityLength;
            this.ClassFees = licenseClassEntity.ClassFees;
        }

        public static DataTable GetAllLicenseClasses()
        {
            return clsLicenseClassData.GetAllLicenseClasses();
        }

        public static clsLicenseClass Find(int LicenseClassID)
        {
            return new clsLicenseClass(clsLicenseClassData.FindLicenseClassByID(LicenseClassID));
        }

    }
}
