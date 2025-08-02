using System;

namespace DVLD.Entities
{
    public class clsUserEntity
    {
        public int UserID { get; set; }
        public int PersonID { get; set; }
        public string Username { get; set; }
        public string HashedPassword { get; set; }
        public bool IsActive { get; set; }
    }
}
