using System;

// Show documentation in clsPersonEntity
namespace DVLD.Entities
{
    /// <summary>
    /// Represents a country entity used in the application for storing country information.
    /// This class is part of the Entities Layer and serves as a Data Transfer Object (DTO)
    /// to pass data between the DAL and BLL layers in a decoupled manner.
    /// </summary>
    public class clsCountryEntity
    {
        public int CountryID { get; set; }
        public string CountryName { get; set; }
    }
}
