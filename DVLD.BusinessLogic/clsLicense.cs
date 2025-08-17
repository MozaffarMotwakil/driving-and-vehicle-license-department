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
        public string Notes { get; set; }
        public float PaidFees { get; }
        public bool IsActive { get; }
        private enMode Mode { get; set; }


        public clsLicense(clsApplication application, clsLicenseClass licenseClass, enIssueReason issueReason)
        {
            if (application == null)
            {
                throw new ArgumentNullException(nameof(application), "Application cannot be null.");
            }

            if (licenseClass == null)
            {
                throw new ArgumentNullException(nameof(licenseClass), "License class cannot be null.");
            }

            if (IsPersonHasLicense(application.PersonInfo.PersonID, licenseClass.LicenseClassID) && issueReason == enIssueReason.FirstTime)
            {
                throw new InvalidOperationException("Person already have a license in this class, cannot issue a new license.");
            }

            this.LicenseID = -1;
            this.DriverInfo = clsDriver.IsDriverExist(application.PersonInfo.PersonID) ?
                clsDriver.Find(application.PersonInfo.PersonID) :
                new clsDriver(application.PersonInfo);
            this.ApplicationInfo = application;
            this.LicenseClassInfo = licenseClass;
            this.IssueReason = issueReason;
            this.CreatedByUserInfo = clsAppSettings.CurrentUser;
            this.Notes = string.Empty;
            this.PaidFees = LicenseClassInfo.ClassFees;
            this.IsActive = true;
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

        public static DataTable GetAllLicensesForPerson(int PersonID)
        {
            return clsLicenseData.GetAllLicensesForPerson(PersonID);
        }

        public bool SetDeactivated()
        {
            if (this.Mode != enMode.AddNew)
            {
                return false;
            }

            return clsLicenseData.SetLicenseToDeactivated(this.LicenseID);
        }

        public bool Issue()
        {
            switch (this.Mode)
            {
                case enMode.AddNew:
                    this.IssueDate = DateTime.Now;
                    this.ExpirationDate = DateTime.Now.AddYears(this.LicenseClassInfo.DefaultValidityLength);

                    if (this.DriverInfo.DriverID == -1 && !this.DriverInfo.Save())
                    {
                        throw new InvalidOperationException($"Failed to save the driver.");
                    }

                    if (!this.ApplicationInfo.SetCompleted())
                    {
                        throw new InvalidOperationException(
                                $"Failed to update status of the base aplication with ID " +
                                $"[{this.ApplicationInfo.ApplicationID}] to completed.");
                    }

                    clsLicenseEntity licenseEntity = _MapLicenseObjectToLicenseEntity(this);

                    if (clsLicenseData.AddNewLicense(licenseEntity))
                    {
                        this.LicenseID = licenseEntity.LicenseID;
                        this.Mode = enMode.Update;
                        return true;
                    }

                    return false;
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
