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
        public DateTime IssueDate { get; }
        public DateTime ExpirationDate { get; }
        public string Notes { get; }
        public float PaidFees { get; }
        public bool IsActive { get; }
        private enMode Mode { get; set; }

        public clsLicense(clsApplication application, clsLicenseClass licenseClass, enIssueReason issueReason, string notes)
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

            if (application.PersonInfo.GetAge() < licenseClass.MinimumAllowedAge)
            {
                throw new InvalidOperationException("Person's age less than the allowed age for this license class .");
            }

            this.LicenseID = -1;
            this.DriverInfo = clsDriver.IsDriverExist(application.PersonInfo.PersonID) ?
                clsDriver.FindByPersonID(application.PersonInfo.PersonID) :
                new clsDriver(application.PersonInfo);
            this.ApplicationInfo = application;
            this.LicenseClassInfo = licenseClass;
            this.IssueReason = issueReason;
            this.CreatedByUserInfo = clsAppSettings.CurrentUser;
            this.Notes = notes;
            this.PaidFees = LicenseClassInfo.ClassFees;
            this.IssueDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now.AddYears(licenseClass.DefaultValidityLength);
            this.IsActive = true;
            this.Mode = enMode.AddNew;
        }

        public clsLicense(clsLocalLicenseApplication localLicenseApplication, string notes) :
            this(localLicenseApplication.ApplicationInfo, localLicenseApplication.LicenseClassInfo, enIssueReason.FirstTime, notes)
        {
            if (localLicenseApplication == null)
            {
                throw new ArgumentNullException(nameof(localLicenseApplication), "Local license application cannot be null.");
            }
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

        public bool SetDeactivated()
        {
            if (this.Mode != enMode.AddNew)
            {
                return false;
            }

            return clsLicenseData.SetLicenseToDeactivated(this.LicenseID);
        }

        /// <summary>
        /// Issues a new license for the first time.
        /// </summary>
        /// <remarks>
        /// This method is only valid when the current object is in <see cref="enMode.AddNew"/> mode 
        /// and the <see cref="IssueReason"/> is set to <see cref="enIssueReason.FirstTime"/>.
        /// It will attempt to save driver information if it hasn't been persisted yet, 
        /// mark the base application as completed, and insert a new license record in the database.
        /// </remarks>
        /// <returns>
        /// The <see cref="LicenseID"/> of the newly created license if successful; 
        /// otherwise, returns <c>-1</c> if the preconditions are not met.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when:
        /// <list type="bullet">
        ///   <item><description>Saving the driver information fails.</description></item>
        ///   <item><description>Updating the base application status to completed fails.</description></item>
        /// </list>
        /// </exception>
        /// <seealso cref="DriverInfo"/>
        /// <seealso cref="ApplicationInfo"/>
        /// <seealso cref="clsLicenseData"/>
        internal int IssueLicenseForFirstTime()
        {
            if (Mode != enMode.AddNew || IssueReason != enIssueReason.FirstTime)
            {
                return -1;
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

            clsLicenseEntity licenseEntity = _MapLicenseObjectToLicenseEntity(this);

            if (clsLicenseData.AddNewLicense(licenseEntity))
            {
                this.LicenseID = licenseEntity.LicenseID;
                this.Mode = enMode.Update;
            }

            return this.LicenseID;
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
