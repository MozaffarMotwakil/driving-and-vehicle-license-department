using System;
using DVLD.DataAccess;
using System.Data;
using DVLD.Entities;

namespace DVLD.BusinessLogic
{
    public class clsApplicationStatus
    {
        public int StatusID { get; set; }
        public string StatusName { get; set; }

        private clsApplicationStatus(clsApplicationStatusEntity applicationStatusEntity)
        {
            this.StatusID = applicationStatusEntity.StatusID;
            this.StatusName = applicationStatusEntity.StatusName;
        }

        public static DataTable GetAllApplicationStatuses()
        {
            return clsApplicationStatusData.GetAllApplicationStatuses();
        }

        public static clsApplicationStatus Find(int ApplicationStatusID)
        {
            return new clsApplicationStatus(clsApplicationStatusData.FindApplicationStatusByID(ApplicationStatusID));
        }

        public static clsApplicationStatus Find(string ApplicationStatusName)
        {
            return new clsApplicationStatus(clsApplicationStatusData.FindApplicationStatusByName(ApplicationStatusName));
        }

    }
}
