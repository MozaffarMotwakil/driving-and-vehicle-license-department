using System.IO;
using DVLD.BusinessLogic;

namespace DVLD.WinForms.Utils
{
    public static class clsLoginManager
    {
        private static string LoginInfoFilePath
        {
            get { return Path.Combine(clsAppSettings.AppDataFolder, "Login-Information"); }
        }

        public static void SaveLoginInformation(string Username, string Password)
        {
            if (!File.Exists(LoginInfoFilePath) || GetSavedUsername() != Username)
            {
                File.WriteAllText(LoginInfoFilePath, $"{Username}\n{Password}");
            }
        }

        public static void UpdatedLoginInformation(string Username, string Password)
        {
            if (File.Exists(LoginInfoFilePath))
            {
                File.WriteAllText(LoginInfoFilePath, $"{Username}\n{Password}");
            }
        }

        public static void DeleteLoginInformation()
        {
            if (File.Exists(LoginInfoFilePath))
            {
                File.Delete(LoginInfoFilePath);
            }
        }

        public static bool IsLoginInformationExist()
        {
            return File.Exists(LoginInfoFilePath);
        }

        public static string GetSavedUsername()
        {
            return File.ReadAllLines(LoginInfoFilePath)[0];
        }

        public static string GetSavedPassword()
        {
            return File.ReadAllLines(LoginInfoFilePath)[1];
        }

    }
}
