using System;

/// <summary>
/// The DVLD.Entities namespace contains simple data container classes (DTOs)
/// that act as a communication layer between the Data Access Layer (DAL)
/// and the Business Logic Layer (BLL).
/// 
/// These entity classes are created to:
/// - Reduce the need for passing multiple parameters between layers.
/// - Group related data into one logical object.
/// - Make the code cleaner, easier to maintain, and less error-prone.
/// 
/// Without these entities, methods in DAL or BLL would require sending 
/// many separate arguments, which makes the code harder to read and extend.
/// 
/// In short, Entities simplify data transfer and enforce a clear separation 
/// of concerns between DAL and BLL.
/// </summary>
namespace DVLD.Entities
{
    /// <summary>
    /// The clsPersonEntity class represents a data transfer object (DTO) 
    /// that holds all person-related information as a single unit.
    /// 
    /// This class is used to:
    /// - Carry person data between the DAL and the BLL without passing multiple parameters.
    /// - Simplify database operations such as insert, update, and fetch by grouping data together.
    /// - Avoid tight coupling between DAL and BLL by acting as an intermediate data structure.
    /// 
    /// Why is it needed?
    /// Without PersonEntity, any CRUD operation on a person would require 
    /// passing 10+ separate arguments, which is hard to maintain, prone to errors, 
    /// and makes method signatures cluttered.
    /// 
    /// Using PersonEntity improves code readability, reduces duplication, 
    /// and aligns with clean architecture principles.
    /// </summary>
    public class clsPersonEntity
    {
        public enum enGender { Male, Female};

        public int PersonID { get; set; }
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
        public clsCountryEntity CountryInfo { get; set; }
        public string ImagePath { get; set; }
    }
}
