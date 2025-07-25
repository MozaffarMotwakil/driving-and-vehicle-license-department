﻿using System;
using System.Data;
using DVLD.DataAccess;
using DVLD.Entities;

namespace DVLD.BusinessLogic
{
    public class clsPerson
    {
        public enum enGender { Male, Female };
        public enum enMode { AddNew, Update };

        public int PersonID { get; private set; }
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
        public clsCountry CountryInfo { get; set; }
        public string ImagePath { get; set; }
        public enMode Mode { get; set; }

        public clsPerson()
        {
            PersonID = -1;
            NationalNo = FirstName = SecondName = ThirdName = LastName = string.Empty;

            // Because the system does not allow anyone under 18 years old.
            DateOfBirth = DateTime.Now.AddYears(-18).Date;
            Gender = enGender.Male;
            Address = Phone = Email = ImagePath = string.Empty;

            // ID of Sudan country
            CountryInfo = clsCountry.Find(165); 
            Mode = enMode.AddNew;
        }

        private clsPerson(clsPersonEntity personEntity)
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
            CountryInfo = new clsCountry(personEntity.CountryInfo);
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
            return DataAccess.clsPersonData.IsPersonExist(PersonID);
        }

        public static bool IsPersonExist(string NationalNo)
        {
            return DataAccess.clsPersonData.IsPersonExist(NationalNo);
        }

        public static clsPerson Find(int PersonID)
        {
            clsPersonEntity personEntity = DataAccess.clsPersonData.FindPersonByID(PersonID);
            return personEntity != null ? new clsPerson(personEntity) : null;
        }
        
        public static clsPerson Find(string NationalNo)
        {
            clsPersonEntity personEntity = DataAccess.clsPersonData.FindPersonByNationalNo(NationalNo);
            return personEntity != null ? new clsPerson(personEntity) : null;
        }

        public static DataTable GetAllPeople()
        {
            return DataAccess.clsPersonData.GetAllPeople();
        }

        public static bool Delete(int PersonID)
        {
            if (DataAccess.clsPersonData.IsPersonExist(PersonID))
            {
                return DataAccess.clsPersonData.DeletePerson(PersonID);
            }
            else
            {
                return false;
            }
        }

        public bool Save()
        {
            clsPersonEntity personEntity = _MapPersonObjectToPersonEntity(this); 

            switch (Mode)
            {
                case enMode.AddNew:
                    if (clsPersonData.AddNewPerson(personEntity)) 
                    {
                        this.PersonID = personEntity.PersonID; 
                        this.Mode = enMode.Update;
                        return true;
                    }

                    return false;
                case enMode.Update:
                    return clsPersonData.UpdatePerson(personEntity);
                default:
                    return false;
            }
        }

        private static clsPersonEntity _MapPersonObjectToPersonEntity(clsPerson Person)
        {
            clsPersonEntity entity = new clsPersonEntity();

            entity.PersonID = Person.PersonID;
            entity.NationalNo = Person.NationalNo;
            entity.FirstName = Person.FirstName;
            entity.SecondName = Person.SecondName;
            entity.ThirdName = Person.ThirdName;
            entity.LastName = Person.LastName;
            entity.DateOfBirth = Person.DateOfBirth;
            entity.Gender = (clsPersonEntity.enGender)Person.Gender;
            entity.Address = Person.Address;
            entity.Phone = Person.Phone;
            entity.Email = Person.Email;
            entity.CountryInfo = new clsCountryEntity
            {
                CountryID = Person.CountryInfo.CountryID,
                CountryName = Person.CountryInfo.CountryName
            };
            entity.ImagePath = Person.ImagePath;

            return entity;
        }

    }
}
