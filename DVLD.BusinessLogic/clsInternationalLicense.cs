using System;
using System.Data;
using DVLD.DataAccess;
using DVLD.Entities;

namespace DVLD.BusinessLogic
{
    public class clsInternationalLicense
    {
        public int InternationalLicenseID { get; private set; }
        public clsApplication ApplicationInfo { get; }
        public clsDriver DriverInfo { get; }
        public clsLicense IssuedUsingLocalLicenseInfo { get; }
        public clsUser CreatedByUserInfo { get; }
        public DateTime IssueDate { get; }
        public DateTime ExpirationDate { get; }
        public bool IsActive { get; }
        private enMode Mode { get; set; }

        public clsInternationalLicense(clsLicense LocalLicense)
        {
            if (LocalLicense == null)
            {
                throw new ArgumentNullException(nameof(LocalLicense), "Local license cannot be null.");
            }

            if (!LocalLicense.IsActive)
            {
                throw new InvalidOperationException("Local license is not active.");
            }

            if (LocalLicense.ExpirationDate < DateTime.Now)
            {
                throw new InvalidOperationException("Local license is not valid.");
            }

            if (IsPersonHasAnActiveInternationalLicense(LocalLicense.DriverInfo.PersonInfo.PersonID))
            {
                throw new InvalidOperationException("Person already has an active international license.");
            }

            this.InternationalLicenseID = -1;
            this.ApplicationInfo = new clsApplication(LocalLicense.DriverInfo.PersonInfo,
                clsApplication.enApplicationType.NewInternationalLicense);
            this.DriverInfo = LocalLicense.DriverInfo;
            this.IssuedUsingLocalLicenseInfo = LocalLicense;
            this.CreatedByUserInfo = clsAppSettings.CurrentUser;
            this.IssueDate = DateTime.Now;
            this.ExpirationDate = this.IssueDate.AddYears(1);
            this.IsActive = true;
            this.Mode = enMode.AddNew;
        }

        private clsInternationalLicense(clsInternationalLicenseEntity internationalLicenseEntity)
        {
            this.InternationalLicenseID = internationalLicenseEntity.InternationalLicenseID;
            this.ApplicationInfo = clsApplication.FindBaseApplication(internationalLicenseEntity.ApplicationID);
            this.DriverInfo = clsDriver.FindByDriverID(internationalLicenseEntity.DriverID);
            this.IssuedUsingLocalLicenseInfo = clsLicense.FindByLicenseID(internationalLicenseEntity.IssuedUsingLocalLicenseID);
            this.CreatedByUserInfo = clsUser.Find(internationalLicenseEntity.CreatedByUserID);
            this.IssueDate = internationalLicenseEntity.IssueDate;
            this.ExpirationDate = internationalLicenseEntity.ExpirationDate;
            this.IsActive = internationalLicenseEntity.IsActive;
            this.Mode = enMode.Update;
        }

        public static bool IsPersonHasAnActiveInternationalLicense(int PersonID)
        {
            return clsInternationalLicenseData.IsPersonHasAnActiveInternationalLicense(PersonID);
        }

        public static clsInternationalLicense Find(int InternationalLicenseID)
        {
            clsInternationalLicenseEntity internationalLicenseEntity = clsInternationalLicenseData.FindInternationalLicenseByID(InternationalLicenseID);
            return internationalLicenseEntity != null ? new clsInternationalLicense(internationalLicenseEntity) : null;
        }

        public static DataTable GetAllInternationalLicensesForPerson(int PersonID)
        {
            return clsInternationalLicenseData.GetAllInternationalLicensesForPerson(PersonID);
        }

        internal bool SetToDeactivated()
        {
            return clsInternationalLicenseData.SetInternationalLicenseToDeactivated(this.InternationalLicenseID);
        }

        public bool Save()
        {
            switch (this.Mode)
            {
                case enMode.AddNew:
                    if (!this.ApplicationInfo.Save())
                    {
                        throw new InvalidOperationException($"Failed to save the base application.");
                    }

                    clsInternationalLicenseEntity internationalLicenseEntity = _MapInternationalLicenseObjectToInternationalLicenseEntity(this);

                    if (clsInternationalLicenseData.AddNewInternationalLicense(internationalLicenseEntity))
                    {
                        this.InternationalLicenseID = internationalLicenseEntity.InternationalLicenseID;
                        this.Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        if (!clsApplication.Delete(this.ApplicationInfo.ApplicationID))
                        {
                            throw new InvalidOperationException(
                                $"Failed to delete the base application with ID ." +
                                $"[{this.ApplicationInfo.ApplicationID}].");
                        }

                        return false;
                    }
                default:
                    return false;
            }
        }

        private static clsInternationalLicenseEntity _MapInternationalLicenseObjectToInternationalLicenseEntity(clsInternationalLicense internationalLicense)
        {
            return new clsInternationalLicenseEntity(
                internationalLicense.InternationalLicenseID,
                internationalLicense.ApplicationInfo.ApplicationID,
                internationalLicense.DriverInfo.DriverID,
                internationalLicense.IssuedUsingLocalLicenseInfo.LicenseID,
                internationalLicense.CreatedByUserInfo.UserID,
                internationalLicense.IssueDate,
                internationalLicense.ExpirationDate,
                internationalLicense.IsActive
                );
        }

    }
}
