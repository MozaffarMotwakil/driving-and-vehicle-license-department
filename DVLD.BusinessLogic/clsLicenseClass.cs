using System;
using DVLD.DataAccess;
using System.Data;
using DVLD.Entities;

namespace DVLD.BusinessLogic
{
    public class clsLicenseClass
    {
        public int LicenseClassID { get; set; }
        public string ClassName { get; set; }
        public string ClassDescription { get; set; }
        public byte MinimumAllowedAge { get; set; }
        public byte DefaultValidityLength { get; set; }
        public float ClassFees { get; set; }

        public clsLicenseClass() { }

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

        public bool Save()
        {
            return clsLicenseClassData.UpdateLicenseClass(_MapLicenseClassObjectToLicenseClassEntity(this));
        }

        private static clsLicenseClassEntity _MapLicenseClassObjectToLicenseClassEntity(clsLicenseClass LicenseClass)
        {
            return new clsLicenseClassEntity(
                LicenseClass.LicenseClassID,
                LicenseClass.ClassName,
                LicenseClass.ClassDescription,
                LicenseClass.MinimumAllowedAge,
                LicenseClass.DefaultValidityLength,
                LicenseClass.ClassFees
                );
        }

    }
}
