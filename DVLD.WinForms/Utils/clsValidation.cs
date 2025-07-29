using System;
using System.Media;
using System.Threading;
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

        public static void ValidatingRequiredField(Control control, string ErrorMessage, ErrorProvider errorProvider)
        {
            if (string.IsNullOrWhiteSpace(control.Text))
            {
                errorProvider.SetError(control, ErrorMessage);
            }
            else
            {
                errorProvider.SetError(control, "");
            }
        }

        /// <summary>
        /// Validates all input fields within UserControl or Form's controls.
        /// </summary>
        /// <remarks>
        /// This method runs validation for all child controls using <c>ValidateChildren</c>,
        /// then manually checks for any validation errors using a <c>foreach</c> loop.
        ///
        /// Unlike the standard validation flow that relies on <c>e.Cancel</c> to stop focus change
        /// when a control is invalid, this method intentionally avoids that behavior.
        ///
        /// The goal behind using a <c>foreach</c> loop is to allow users to freely navigate
        /// between fields even if some contain invalid data. Error messages will still appear
        /// via the <c>ErrorProvider</c>, but users won't be blocked from moving around.
        ///
        /// This design provides a smoother user experience by postponing strict validation enforcement
        /// until the point of saving, rather than interrupting the user's input flow.
        ///
        /// </remarks>
        /// <returns>
        /// <c>true</c> if all fields are valid (no validation errors); otherwise, <c>false</c>.
        /// </returns>
        public static bool IsDataValid(UserControl userControl, ErrorProvider errorProvider)
        {
            userControl.ValidateChildren();

            foreach (Control control in userControl.Controls)
            {
                if (errorProvider.GetError(control) != "")
                {
                    return false;
                }
            }

            return true;
        }

        public static bool IsDataValid(Form form, Control.ControlCollection collection, ErrorProvider errorProvider)
        {
            form.ValidateChildren();

            foreach (Control control in collection)
            {
                if (errorProvider.GetError(control) != "")
                {
                    return false;
                }
            }

            return true;
        }

    }
}
