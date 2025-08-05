using System;

namespace DVLD.Entities
{
    public class clsApplicationStatusEntity
    {
        public int StatusID { get; set; }
        public string StatusName { get; set; }

        public clsApplicationStatusEntity() { }

        public clsApplicationStatusEntity(int StatusID, string StatusName) 
        {
            this.StatusID = StatusID;
            this.StatusName = StatusName;
        }

    }
}
