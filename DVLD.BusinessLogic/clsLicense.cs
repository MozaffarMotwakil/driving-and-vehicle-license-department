using System;
using DVLD.DataAccess;
using DVLD.Entities;
using System.Data;
using System.ComponentModel;

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
        public bool IsActive { get; private set; }
        private enMode Mode { get; set; }

        public clsLicense(clsLocalLicenseApplication localLicenseApplication, string notes)
        {
            if (localLicenseApplication == null)
            {
                throw new ArgumentNullException(nameof(localLicenseApplication), "Local license application cannot be null.");
            }

            if (!localLicenseApplication.IsPersonPassedAllTests())
            {
                throw new InvalidOperationException("The applicant has not passed all tests yet.");
            }

            if (IsPersonHasLicense(localLicenseApplication.ApplicationInfo.PersonInfo.PersonID, localLicenseApplication.LicenseClassInfo.LicenseClassID))
            {
                throw new InvalidOperationException("Person already have a license in this class, cannot issue a new license.");
            }

            if (localLicenseApplication.ApplicationInfo.PersonInfo.GetAge() < localLicenseApplication.LicenseClassInfo.MinimumAllowedAge)
            {
                throw new InvalidOperationException("Person's age less than the allowed age for this license class .");
            }

            this.LicenseID = -1;
            this.DriverInfo = clsDriver.IsDriverExist(localLicenseApplication.ApplicationInfo.PersonInfo.PersonID) ?
                clsDriver.FindByPersonID(localLicenseApplication.ApplicationInfo.PersonInfo.PersonID) :
                new clsDriver(localLicenseApplication.ApplicationInfo.PersonInfo);
            this.ApplicationInfo = localLicenseApplication.ApplicationInfo;
            this.LicenseClassInfo = localLicenseApplication.LicenseClassInfo;
            this.IssueReason = enIssueReason.FirstTime;
            this.CreatedByUserInfo = clsAppSettings.CurrentUser;
            this.Notes = notes;
            this.PaidFees = LicenseClassInfo.ClassFees;
            this.IsActive = true;
            this.Mode = enMode.AddNew;
        }

        private clsLicense(clsLicense oldLicense, string notes, enIssueReason issueReason)
        {
            if (oldLicense == null)
            {
                throw new ArgumentNullException(nameof(oldLicense), "The old license cannot be null.");
            }

            if (issueReason == enIssueReason.FirstTime)
            {
                throw new ArgumentNullException(nameof(oldLicense), "Issue reason cannot be for first time.");
            }

            if (IsPersonHasAnActiveLicense(oldLicense.DriverInfo.PersonInfo.PersonID, oldLicense.LicenseClassInfo.LicenseClassID))
            {
                throw new InvalidOperationException($"Person already has an active license in this license class.");
            }

            this.LicenseID = -1;
            this.DriverInfo = oldLicense.DriverInfo;
            this.ApplicationInfo = new clsApplication(
                oldLicense.DriverInfo.PersonInfo,
                GetApplicationTypeDependingOnIssueReason(issueReason)
                );
            this.LicenseClassInfo = oldLicense.LicenseClassInfo;
            this.IssueReason = issueReason;
            this.CreatedByUserInfo = clsAppSettings.CurrentUser;
            this.Notes = notes;
            this.PaidFees = LicenseClassInfo.ClassFees;
            this.IsActive = true;
            this.Mode = enMode.AddNew;
        } 


        private clsLicense(clsLicenseEntity licenseEntity)
        {
            this.LicenseID = licenseEntity.LicenseID;
            this.DriverInfo = clsDriver.FindByDriverID(licenseEntity.DriverID);
            this.ApplicationInfo = clsApplication.FindBaseApplication(licenseEntity.ApplicationID);
            this.LicenseClassInfo = clsLicenseClass.Find(licenseEntity.LicenseClassID);
            this.IssueReason = (enIssueReason)licenseEntity.IssueReasonID;
            this.CreatedByUserInfo = clsUser.Find(licenseEntity.CreatedByUserID);
            this.Notes = licenseEntity.Notes;
            this.PaidFees = licenseEntity.PaidFees;
            this.IssueDate = licenseEntity.IssueDate;
            this.ExpirationDate = licenseEntity.ExpirationDate;
            this.IsActive = licenseEntity.IsActive;
            this.Mode = enMode.Update;
        }

        public static bool IsPersonHasLicense(int PersonID, int LicenseClassID)
        {
            return clsLicenseData.IsLicenseExist(PersonID, LicenseClassID);
        }

        public static clsLicense GetActiveLicenseForPerosn(int PersonID, int LicenseClassID)
        {
            clsLicenseEntity licenseEntity = clsLicenseData.GetActiveLicenseForPerosn(PersonID, LicenseClassID);
            return licenseEntity != null ? new clsLicense(licenseEntity) : null;
        }

        public static bool IsPersonHasAnActiveLicense(int PersonID, int LicenseClassID)
        {
            return clsLicenseData.IsPersonHasAnActiveLicense(PersonID, LicenseClassID);
        }

        public static clsLicense FindByLicenseID(int LicenseID)
        {
            clsLicenseEntity licenseEntity = clsLicenseData.FindLicenseByLicenseID(LicenseID);
            return licenseEntity != null ? new clsLicense(licenseEntity) : null;
        }

        public static clsLicense FindByApplicationID(int ApplicationID)
        {
            clsLicenseEntity licenseEntity = clsLicenseData.FindLicenseByApplicationID(ApplicationID);
            return licenseEntity != null ? new clsLicense(licenseEntity) : null;
        }

        public static DataTable GetAllLicensesForPerson(int PersonID)
        {
            return clsLicenseData.GetAllLicensesForPerson(PersonID);
        }

        public string GetIssueReasonAsText()
        {
            switch (this.IssueReason)
            {
                case enIssueReason.FirstTime:
                    return "First Time";
                case enIssueReason.Renew:
                    return "Renew";
                case enIssueReason.ReplacementForDamaged:
                    return "Replacement For Damaged";
                case enIssueReason.ReplacementForLost:
                    return "Replacement For Lost";
                default:
                    return "Invalid Issue Reason";
            }
        }

        public bool SetInactive()
        {
            if (this.Mode == enMode.AddNew)
            {
                return false;
            }

            this.IsActive = false;
            return clsLicenseData.SetLicenseToInactive(this.LicenseID);
        }

        public bool IsLicenseExpired()
        {
            return this.ExpirationDate < DateTime.Now;
        }

        public float GetTotalFees()
        {
            return this.ApplicationInfo.PaidFees + this.PaidFees;
        }

        internal clsLicense Issue()
        {
            if (Mode != enMode.AddNew || IssueReason != enIssueReason.FirstTime)
            {
                return null;
            }

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

            this.IssueDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now.AddYears(this.LicenseClassInfo.DefaultValidityLength);
            clsLicenseEntity licenseEntity = _MapLicenseObjectToLicenseEntity(this);

            if (clsLicenseData.AddNewLicense(licenseEntity))
            {
                this.LicenseID = licenseEntity.LicenseID;
                this.Mode = enMode.Update;
            }

            return this;
        }

        public clsLicense Renew(string notes)
        {
            if (!this.IsLicenseExpired() || this.Mode == enMode.AddNew)
            {
                return null;
            }

            clsLicense newLicense = new clsLicense(this, notes, enIssueReason.Renew);
            newLicense.IssueDate = DateTime.Now;
            newLicense.ExpirationDate = DateTime.Now.AddYears(newLicense.LicenseClassInfo.DefaultValidityLength);

            if (!newLicense.ApplicationInfo.Save())
            {
                throw new InvalidOperationException($"Failed to save the base application.");
            }

            if (!newLicense.ApplicationInfo.SetCompleted())
            {
                throw new InvalidOperationException(
                        $"Failed to update status of the base aplication with ID " +
                        $"[{this.ApplicationInfo.ApplicationID}] to completed.");
            }

            if (!this.SetInactive())
            {
                throw new InvalidOperationException(
                        $"Failed to update status of current license with ID " +
                        $"[{this.LicenseID}] to inactive.");
            }

            clsLicenseEntity newLicenseEntity = _MapLicenseObjectToLicenseEntity(newLicense);

            if (clsLicenseData.AddNewLicense(newLicenseEntity))
            {
                newLicense.LicenseID = newLicenseEntity.LicenseID;
                newLicense.Mode = enMode.Update;
            }

            return newLicense;
        }

        private clsApplication.enApplicationType GetApplicationTypeDependingOnIssueReason(enIssueReason issueReason)
        {
            switch (issueReason)
            {
                case enIssueReason.FirstTime:
                    return clsApplication.enApplicationType.NewLocalDrivingLicenseService;
                case enIssueReason.Renew:
                    return clsApplication.enApplicationType.RenewDrivingLicenseService;
                case enIssueReason.ReplacementForDamaged:
                    return clsApplication.enApplicationType.ReplacementForDamagedDrivingLicense;
                case enIssueReason.ReplacementForLost:
                    return clsApplication.enApplicationType.ReplacementForLostDrivingLicense;
                default:
                    throw new InvalidEnumArgumentException("Issue reason not valid.");
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
