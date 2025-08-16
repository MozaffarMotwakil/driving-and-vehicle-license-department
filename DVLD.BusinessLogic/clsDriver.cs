using System;
using System.Data;
using DVLD.DataAccess;
using DVLD.Entities;

namespace DVLD.BusinessLogic
{
    public class clsDriver
    {
        public int DriverID { get; private set; }
        public clsPerson PersonInfo { get; }
        public clsUser CreatedByUserInfo { get; }
        public DateTime CreatedDate { get; }
        private enMode Mode { get; set; }

        public clsDriver(clsPerson person)
        {
            if (person == null)
            {
                throw new ArgumentNullException(nameof(person), "Person cannot be null.");
            }

            if (IsDriverExist(person.PersonID))
            {
                throw new InvalidOperationException("Person already is driver.");
            }

            this.DriverID = -1;
            this.PersonInfo = person;
            this.CreatedByUserInfo = clsAppSettings.CurrentUser;
            this.Mode = enMode.AddNew; 
        }

        private clsDriver(clsDriverEntity driverEntity)
        {
            this.DriverID = driverEntity.DriverID;
            this.PersonInfo = clsPerson.Find(driverEntity.PersonID);
            this.CreatedByUserInfo = clsUser.Find(driverEntity.CreatedByUserID);
            this.CreatedDate = driverEntity.CreatedDate;
            this.Mode = enMode.Update;
        }

        public static bool IsDriverExist(int PersonID)
        {
            return clsDriverData.IsDriverExist(PersonID);
        }
        public static DataTable GetAllDrivers()
        {
            return clsDriverData.GetAllDrivers();
        }

        public static clsDriver Find(int DriverID)
        {
            clsDriverEntity driverEntity = clsDriverData.FindDriverByDriverID(DriverID);
            return driverEntity != null ? new clsDriver(driverEntity) : null;
        }

        public bool Save()
        {
            switch (this.Mode)
            {
                case enMode.AddNew:
                    clsDriverEntity driverEntity = _MapDriverObjectToDriverEntity(this);

                    if (clsDriverData.AddNewDriver(driverEntity))
                    {
                        this.DriverID = driverEntity.DriverID;
                        this.Mode = enMode.Update;
                        return true;
                    }

                    return false;
                case enMode.Update:
                    throw new InvalidOperationException("Cannot update driver info.");
                default:
                    return false;
            }
        }

        private clsDriverEntity _MapDriverObjectToDriverEntity(clsDriver driver)
        {
            return new clsDriverEntity(
                driver.DriverID,
                driver.PersonInfo.PersonID,
                driver.CreatedByUserInfo.UserID,
                driver.CreatedDate
                );
        }

    }
}
