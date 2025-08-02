using System.Media;
using System.Windows.Forms;
using DVLD.BusinessLogic;

namespace DVLD.WinForms.Utils
{
    public static class clsFormValidation
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

        public static void ValidatingPassword(Control PasswordTextBox, ErrorProvider errorProvider)
        {
            if (!string.IsNullOrEmpty(PasswordTextBox.Text))
            {
                if (string.IsNullOrEmpty(PasswordTextBox.Text) || !clsValidationHelper.IsValidPassword(PasswordTextBox.Text))
                {
                    errorProvider.SetError(PasswordTextBox, "Password must be at least 8 characters long, contain at least 4 numbers, one uppercase letter, and one lowercase letter.");
                }
                else
                {
                    errorProvider.SetError(PasswordTextBox, "");
                }
            }
        }

        public static void ValidatingConfirmPassword(Control PasswordTextBox, Control ConfirmPasswordTextBox, ErrorProvider errorProvider)
        {
            if (ConfirmPasswordTextBox.Text != PasswordTextBox.Text)
            {
                errorProvider.SetError(ConfirmPasswordTextBox, "Passwords is not match.");
            }
            else
            {
                errorProvider.SetError(ConfirmPasswordTextBox, "");
            }
        }

    }
}
