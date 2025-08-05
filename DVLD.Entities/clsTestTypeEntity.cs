using System;

namespace DVLD.Entities
{
    public class clsTestTypeEntity
    {
        public int TypeID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public float Fees { get; set; }

        public clsTestTypeEntity() { }

        public clsTestTypeEntity (int ID, string Title, string Description, float Fees)
        {
            this.TypeID = ID;
            this.Title = Title;
            this.Description = Description;
            this.Fees = Fees;
        }

    }
}
