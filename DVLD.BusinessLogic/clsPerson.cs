using System;
using System.Data;
using System.Net.NetworkInformation;
using DVLD.Entities;

namespace DVLD.BusinessLogic
{
    public class clsPerson
    {
        public enum enGender { Male, Female };
        public enum enMode { AddNew, Update };

        public int PersonID { get; }
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public enGender Gender { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int NationalityCountryID { get; set; }
        public string ImagePath { get; set; }
        public enMode Mode { get; set; }

        public clsPerson()
        {
            PersonID = -1;
            NationalNo = FirstName = SecondName = ThirdName = LastName = "";
            DateOfBirth = DateTime.Now;
            Gender = enGender.Male;
            Address = Phone = Email = ImagePath = "";
            NationalityCountryID = -1;
            Mode = enMode.AddNew;
        }

        private clsPerson(PersonEntity personEntity)
        {
            PersonID = personEntity.PersonID;
            NationalNo = personEntity.NationalNo;
            FirstName = personEntity.FirstName;
            SecondName = personEntity.SecondName;
            ThirdName = personEntity.ThirdName;
            LastName = personEntity.LastName;
            DateOfBirth = personEntity.DateOfBirth;
            Gender = (enGender)personEntity.Gender;
            Address = personEntity.Address;
            Phone = personEntity.Phone;
            Email = personEntity.Email;
            NationalityCountryID = personEntity.NationalityCountryID;
            ImagePath = personEntity.ImagePath;
            Mode = enMode.Update;
        }

        public string GetFullName()
        {
            if (string.IsNullOrEmpty(ThirdName))
            {
                return $"{FirstName} {SecondName} {LastName}";
            }
            else
            {
                return $"{FirstName} {SecondName} {ThirdName} {LastName}";
            }
        }

        public static bool IsPersonExist(int PersonID)
        {
            return DataAccess.PersonData.IsPersonExist(PersonID);
        }

        public static bool IsPersonExist(string NationalNo)
        {
            return DataAccess.PersonData.IsPersonExist(NationalNo);
        }

        public static clsPerson Find(int PersonID)
        {
            PersonEntity personEntity = DataAccess.PersonData.FindPersonByID(PersonID);
            return personEntity != null ? new clsPerson(personEntity) : null;
        }
        
        public static clsPerson Find(string NationalNo)
        {
            PersonEntity personEntity = DataAccess.PersonData.FindPersonByNationalNo(NationalNo);
            return personEntity != null ? new clsPerson(personEntity) : null;
        }

        public static DataTable GetAllPeople()
        {
            return DataAccess.PersonData.GetAllPeople();
        }

        public static bool Delete(int PersonID)
        {
            if (DataAccess.PersonData.IsPersonExist(PersonID))
            {
                return DataAccess.PersonData.DeletePerson(PersonID);
            }
            else
            {
                return false;
            }
        }

        public bool Save()
        {
            if (this.Mode == enMode.AddNew)
            {
                return DataAccess.PersonData.AddNewPerson(_ConvertPersonToEntity(this)) != -1;
            }
            else
            {
                return DataAccess.PersonData.UpdatePerson(_ConvertPersonToEntity(this));
            }
        }

        private static PersonEntity _ConvertPersonToEntity(clsPerson Person)
        {
            PersonEntity entity = new PersonEntity();

            entity.PersonID = Person.PersonID;
            entity.NationalNo = Person.NationalNo;
            entity.FirstName = Person.FirstName;
            entity.SecondName = Person.SecondName;
            entity.ThirdName = Person.ThirdName;
            entity.LastName = Person.LastName;
            entity.DateOfBirth = Person.DateOfBirth;
            entity.Gender = (PersonEntity.enGender)Person.Gender;
            entity.Address = Person.Address;
            entity.Phone = Person.Phone;
            entity.Email = Person.Email;
            entity.NationalityCountryID = Person.NationalityCountryID;
            entity.ImagePath = Person.ImagePath;

            return entity;
        }

    }
}
