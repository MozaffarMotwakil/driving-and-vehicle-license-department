using System;
using System.Media;
using System.Windows.Forms;

namespace DVLD.WinForms.Utils
{
    public static class clsValidation
    {
        public static void HandleNumericKeyPress(KeyPressEventArgs e, Control targetControl, ErrorProvider errorProvider,
            string errorMessage = "Cannot enter letters or special symbols, only numbers.")
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                SystemSounds.Asterisk.Play(); 
                errorProvider.SetError(targetControl, errorMessage); 
            }
            else
            {
                errorProvider.SetError(targetControl, "");
            }
        }

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

    }
}
