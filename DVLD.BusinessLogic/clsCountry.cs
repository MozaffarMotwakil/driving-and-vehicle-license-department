using System.Data;
using DVLD.DataAccess;

namespace DVLD.BusinessLogic
{
    public class clsCountry
    {
        public static DataTable GetAllCountries()
        {
            return DataAccess.CountryData.GetAllCountries();
        }

        public static string FindCountryByID(int CountryID)
        {
            return CountryData.FindCountryByID(CountryID);
        }

    }
}
