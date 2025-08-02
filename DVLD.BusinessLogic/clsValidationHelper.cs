using System;

namespace DVLD.BusinessLogic
{
    public static class clsValidationHelper
    {
        public static bool IsValidPhone(string PhoneNumber)
        {
            for (int i = 0; i < PhoneNumber.Length; i++)
            {
                if (!char.IsDigit(PhoneNumber[i]))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool IsValidEmail(string Email)
        {
            return Email.EndsWith("@gmail.com");
        }

        private static bool IsTextHasLowerCaseLetter(string Text)
        {
            for (int i = 0; i < Text.Length; i++)
            {
                if (char.IsLower(Text[i]))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool IsTextHasUpperCaseLetter(string Text)
        {
            for (int i = 0; i < Text.Length; i++)
            {
                if (char.IsUpper(Text[i]))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool IsTextHasNumber(string Text, int DigitsCount = 1)
        {
            if (DigitsCount < 1)
            {
                DigitsCount = 1;
            }

            for (int i = 0; i < Text.Length; i++)
            {
                if (char.IsDigit(Text[i]))
                {
                    if (--DigitsCount == 0)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static bool IsValidPassword(string Password)
        {
            return Password.Length >= 8 && IsTextHasLowerCaseLetter(Password) &&
                IsTextHasUpperCaseLetter(Password) && IsTextHasNumber(Password, 4);
        }

    }
}
