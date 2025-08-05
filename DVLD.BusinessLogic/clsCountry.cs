using System.Data;
using DVLD.DataAccess;
using DVLD.Entities;

namespace DVLD.BusinessLogic
{
    public class clsCountry
    {
        public int CountryID { get; set; }
        public string CountryName { get; set; }

        private clsCountry(clsCountryEntity countryEntity)
        {
            this.CountryID = countryEntity.CountryID;
            this.CountryName = countryEntity.CountryName;
        }

        public static DataTable GetAllCountries()
        {
            return clsCountryData.GetAllCountries();
        }

        public static clsCountry Find(int CountryID)
        {
            return new clsCountry(clsCountryData.FindCountryByID(CountryID));
        }
        
        public static clsCountry Find(string CountryName)
        {
            return new clsCountry(clsCountryData.FindCountryByName(CountryName));
        }

    }
}
