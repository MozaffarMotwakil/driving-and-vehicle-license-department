using System;
using DVLD.DataAccess;
using DVLD.Entities;
using System.Data;

namespace DVLD.BusinessLogic
{
    public class clsLicense
    {
        public enum enIssueReason
        {
            FirstTime = 1,
            Renew = 2,
            ReplacementForDamaged = 3,
            ReplacementForLost = 4
        }

        public int LicenseID { get; private set; }
        public clsDriver DriverInfo { get; }
        public clsApplication ApplicationInfo { get; }
        public clsLicenseClass LicenseClassInfo { get; }
        public enIssueReason IssueReason { get; }
        public clsUser CreatedByUserInfo { get; }
        public DateTime IssueDate { get; private set; }
        public DateTime ExpirationDate { get; private set; }
        public string Notes { get; }
        public float PaidFees { get; }
        public bool IsActive { get; }
        private enMode Mode { get; set; }


        public clsLicense(clsPerson person, clsApplication.enApplicationType applicationType, clsLicenseClass licenseClass, enIssueReason issueReason)
        {
            if (person == null)
            {
                throw new ArgumentNullException(nameof(person), "Person cannot be null.");
            }

            if (licenseClass == null)
            {
                throw new ArgumentNullException(nameof(licenseClass), "License class cannot be null.");
            }

            if (IsPersonHasLicense(person.PersonID, licenseClass.LicenseClassID) && issueReason == enIssueReason.FirstTime)
            {
                throw new InvalidOperationException("Person already have a license in this class, cannot create a new license.");
            }

            LicenseID = -1;
            DriverInfo = new clsDriver(person);
            ApplicationInfo = new clsApplication(person, applicationType);
            LicenseClassInfo = licenseClass;
            IssueReason = issueReason;
            CreatedByUserInfo = clsAppSettings.CurrentUser;
            Notes = string.Empty;
            PaidFees = LicenseClassInfo.ClassFees;
            IsActive = true;
            this.Mode = enMode.AddNew;
        }

        private clsLicense(clsLicenseEntity licenseEntity)
        {
            this.LicenseID = licenseEntity.LicenseID;
            this.DriverInfo = clsDriver.Find(licenseEntity.DriverID);
            this.ApplicationInfo = clsApplication.FindBaseApplication(licenseEntity.ApplicationID);
            this.LicenseClassInfo = clsLicenseClass.Find(licenseEntity.LicenseClassID);
            this.IssueReason = (enIssueReason)licenseEntity.IssueReasonID;
            this.CreatedByUserInfo = clsUser.Find(licenseEntity.CreatedByUserID);
            this.IssueDate = licenseEntity.IssueDate;
            this.ExpirationDate = licenseEntity.ExpirationDate;
            this.Notes = licenseEntity.Notes;
            this.PaidFees = licenseEntity.PaidFees;
            this.IsActive = licenseEntity.IsActive;
            this.Mode = enMode.Update;
        }

        public static bool IsPersonHasLicense(int PersonID, int LicenseClassID)
        {
            return clsLicenseData.IsLicenseExist(PersonID, LicenseClassID);
        }

        public static clsLicense Find(int ApplicationID)
        {
            clsLicenseEntity licenseEntity = clsLicenseData.FindLicenseByApplicationID(ApplicationID);
            return licenseEntity != null ? new clsLicense(licenseEntity) : null;
        }

        public DataTable GetAllLicense()
        {
            return clsLicenseData.GetAllLicensesForPerson(this.DriverInfo.PersonInfo.PersonID);
        }

        public bool SetDeactivated()
        {
            return clsLicenseData.SetLicenseToDeactivated(this.LicenseID);
        }

        public bool Save()
        {
            switch (this.Mode)
            {
                case enMode.AddNew:
                    this.IssueDate = DateTime.Now;
                    this.ExpirationDate = DateTime.Now.AddYears(this.LicenseClassInfo.DefaultValidityLength);

                    if (!this.DriverInfo.Save())
                    {
                        throw new InvalidOperationException($"Failed to save the driver.");
                    }

                    if (!this.ApplicationInfo.Save())
                    {
                        throw new InvalidOperationException($"Failed to save the base application.");
                    }

                    clsLicenseEntity licenseEntity = _MapLicenseObjectToLicenseEntity(this);

                    if (clsLicenseData.AddNewLicense(licenseEntity))
                    {
                        this.LicenseID = licenseEntity.LicenseID;
                        this.Mode = enMode.Update;
                        return true;
                    }

                    return false;
                case enMode.Update:
                    throw new InvalidOperationException("Cannot update license info.");
                default:
                    return false;
            }
        }

        private static clsLicenseEntity _MapLicenseObjectToLicenseEntity(clsLicense License)
        {
            return new clsLicenseEntity(
                License.LicenseID,
                License.DriverInfo.DriverID,
                License.ApplicationInfo.ApplicationID,
                License.LicenseClassInfo.LicenseClassID,
                (int)License.IssueReason,
                License.CreatedByUserInfo.UserID,
                License.IssueDate,
                License.ExpirationDate,
                License.Notes,
                License.PaidFees,
                License.IsActive
                );
        }

    }

}
