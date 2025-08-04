using System;

namespace DVLD.Entities
{
    public class clsApplicationEntity
    {
        public int ApplicationID { get; set; }
        public int PersonID { get; set; }
        public int TypeID { get; set; }
        public int StatusID { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastStatusDate { get; set; }
        public float PaidFees { get; set; }

        public clsApplicationEntity() { }

        public clsApplicationEntity(int ApplicationID, int PersonID, int TypeID, int StatusID,
            int CreatedByUserID, DateTime CreatedDate, DateTime LastStatusDate, float PaidFees)
        {
            this.ApplicationID = ApplicationID;
            this.PersonID = PersonID;
            this.TypeID = TypeID;
            this.StatusID = StatusID;
            this.CreatedByUserID = CreatedByUserID;
            this.CreatedDate = CreatedDate;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
        }

    }
}
