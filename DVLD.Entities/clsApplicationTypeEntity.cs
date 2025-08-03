using System;

namespace DVLD.Entities
{
    public class clsApplicationTypeEntity
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public float Fees { get; set; }

        public clsApplicationTypeEntity(int ID, string Title, float Fees)
        {
            this.ID = ID;
            this.Title = Title;
            this.Fees = Fees;
        }

    }
}
