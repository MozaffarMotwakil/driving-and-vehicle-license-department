using System;
using System.IO;

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

    }
}
