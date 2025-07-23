using System.Windows.Forms;

namespace DVLD.WinForms.Utils
{
    public static class clsMessages
    {
        public static void ShowImageNotFoundWarning()
        {
            MessageBox.Show(
                "The selected image file no longer exists. Please select a new image.",
                "Image Not Found",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );
        }

        public static void ShowSuccess(string message, string title = "Success")
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ShowError(string message, string title = "Error")
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        
        public static void ShowWarning(string message, string title = "Warning")
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static bool Confirm(string message, string title = "Confirm", MessageBoxIcon messageBoxIcon = MessageBoxIcon.Question, 
            MessageBoxDefaultButton messageBoxDefaultButton = MessageBoxDefaultButton.Button1)
        {
            return MessageBox.Show(message, title, MessageBoxButtons.YesNo, messageBoxIcon, messageBoxDefaultButton) == DialogResult.Yes;
        }
        
    }
}
