using System;
using System.Windows.Forms;
using DVLD.WinForms.MainForms;
using DVLD.WinForms.Users;

namespace DVLD.WinForms
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMainForm());
            //Application.Run(new frmAddUpdateUser());
        }
    }
}
