using System;

namespace DVLD.Entities
{
    public class clsTestTypeEntity
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public float Fees { get; set; }

        public clsTestTypeEntity() { }

        public clsTestTypeEntity (int ID, string Title, string Description, float Fees)
        {
            this.ID = ID;
            this.Title = Title;
            this.Description = Description;
            this.Fees = Fees;
        }

    }
}
