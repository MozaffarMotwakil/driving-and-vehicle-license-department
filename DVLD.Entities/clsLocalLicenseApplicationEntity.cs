using System;

namespace DVLD.Entities
{
    public class clsLocalLicenseApplicationEntity
    {
        public int LocalLicenseApplicationID { get; set; }
        public int ApplicationID { get; set; }
        public int LicenseClassID { get; set; }

        public clsLocalLicenseApplicationEntity() { }
        public clsLocalLicenseApplicationEntity(int LocalLicenseApplicationID, int ApplicationID, int LicenseClassID)
        {
            this.LocalLicenseApplicationID = LocalLicenseApplicationID;
            this.ApplicationID = ApplicationID;
            this.LicenseClassID = LicenseClassID;
        }

    }
}
