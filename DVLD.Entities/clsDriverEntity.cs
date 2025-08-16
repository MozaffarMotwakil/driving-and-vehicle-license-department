using System;

namespace DVLD.Entities
{
    public class clsDriverEntity
    {
        public int DriverID { get; set; }
        public int PersonID { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime CreatedDate { get; set; }

        public clsDriverEntity() { }

        public clsDriverEntity(int driverID, int personID, int createdByUserID, DateTime createdDate)
        {
            DriverID = driverID;
            PersonID = personID;
            CreatedDate = createdDate;
            CreatedByUserID = createdByUserID;
        }
    }
}
