using System;
using System.Security.Cryptography;

namespace DVLD.WinForms.Utils
{
    internal static class clsPasswordHelper
    {
        private const int SaltSize = 16;
        private const int HashSize = 32;
        private const int Iterations = 10000;

        public static string CreateHashPasswordWithSalt(string password)
        {
            byte[] saltBytes = new byte[SaltSize];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(saltBytes);
            }

            using (var pbkdf2 = new Rfc2898DeriveBytes(password, saltBytes, Iterations, HashAlgorithmName.SHA256))
            {
                byte[] hashBytes = pbkdf2.GetBytes(HashSize);

                byte[] hashWithSalt = new byte[SaltSize + HashSize];
                Array.Copy(saltBytes, 0, hashWithSalt, 0, SaltSize);
                Array.Copy(hashBytes, 0, hashWithSalt, SaltSize, HashSize);

                // Converts the binary hash and salt to a safe Base64 string representation.
                // This is necessary because the raw binary data may contain special or unprintable characters,
                // that are problematic for database storage.
                return Convert.ToBase64String(hashWithSalt);
            }
        }

        public static bool VerifyPassword(string enteredPassword, string storedHashBase64)
        {
            byte[] hashWithSaltBytes = Convert.FromBase64String(storedHashBase64);

            byte[] saltBytes = new byte[SaltSize];
            Array.Copy(hashWithSaltBytes, 0, saltBytes, 0, SaltSize);

            byte[] originalHash = new byte[HashSize];
            Array.Copy(hashWithSaltBytes, SaltSize, originalHash, 0, HashSize);

            using (var pbkdf2 = new Rfc2898DeriveBytes(enteredPassword, saltBytes, Iterations, HashAlgorithmName.SHA256))
            {
                byte[] enteredHash = pbkdf2.GetBytes(HashSize);

                return AreEqual(originalHash, enteredHash);
            }
        }

        private static bool AreEqual(byte[] originalHash, byte[] enteredHash)
        {
            if (originalHash.Length != enteredHash.Length)
            {
                return false;
            }
            
            bool result = true;

            for (int i = 0; i < originalHash.Length; i++)
            {
                // This is a constant-time comparison to prevent timing attacks.
                // The comparison proceeds through the entire array, regardless of mismatches.
                result &= (originalHash[i] == enteredHash[i]);
            }

            return result;
        }

    }
}
