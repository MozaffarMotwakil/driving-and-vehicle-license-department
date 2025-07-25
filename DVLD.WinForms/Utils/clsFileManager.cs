using System;
using System.IO;

namespace DVLD.WinForms.Utils
{
    public static class clsFileManager
    {
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

    }
}
