using System;
using System.Data;
using System.IO;
using DVLD.BusinessLogic;

namespace DVLD.WinForms.Global
{
    public static class clsSettings
    {
        private static string _AppDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        public static string PeopleImagesFolderPath
        {
            get
            {
                string peopleImagesFolderPath = Path.Combine(_AppDataFolder, "DVLD-People-Images");

                if (!Directory.Exists(peopleImagesFolderPath))
                {
                    Directory.CreateDirectory(peopleImagesFolderPath);
                }

                return peopleImagesFolderPath;
            }
        }

        public static string GetNewImagePathWithGUID()
        {
            return Path.Combine(PeopleImagesFolderPath, $"{Guid.NewGuid()}.JPG");
        }

        public static string[] GetCountries()
        {
            DataTable countriesFromDB = clsCountry.GetAllCountries();
            string[] countriesNames = new string[countriesFromDB.Rows.Count];

            for (int i = 0; i < countriesNames.Length; i++)
            {
                countriesNames[i] = countriesFromDB.Rows[i]["CountryName"].ToString();
            }

            return countriesNames;
        }

    }
}
