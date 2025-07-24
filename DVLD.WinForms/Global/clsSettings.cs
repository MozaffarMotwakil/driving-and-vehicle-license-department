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

        public static void DeletePersonImageFromLocalFolder(string IamgePath)
        {
            try
            {
                File.Delete(IamgePath);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void SavePersonImageToLocalFolder(string SourceIamgePath, string DestImagePath)
        {
            try
            {
                File.Copy(SourceIamgePath, DestImagePath);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string GetNewImagePathWithGUID()
        {
            return Path.Combine(Global.clsSettings.PeopleImagesFolderPath, $"{Guid.NewGuid()}.JPG");
        }

    }
}
