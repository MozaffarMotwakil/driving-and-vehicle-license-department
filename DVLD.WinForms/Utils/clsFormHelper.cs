using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DVLD.BusinessLogic;
using DVLD.WinForms.Properties;

namespace DVLD.WinForms.Utils
{
    public static class clsFormHelper
    {
        public static int GetSelectedRowID(DataGridView dataGridView)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                return Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
            }

            return -1;
        }

        public static Point GetCurrentPoint(Control control)
        {
            return control.PointToClient(Cursor.Position);
        }

        public static DataGridView.HitTestInfo GetHitTestInfo(DataGridView dataGridView)
        {
            Point point = GetCurrentPoint(dataGridView);
            return dataGridView.HitTest(point.X, point.Y);
        }

        public static void PreventContextMenuOnHeaderOrEmptySpace(DataGridView dataGridView, System.ComponentModel.CancelEventArgs e)
        {
            DataGridView.HitTestInfo hit = GetHitTestInfo(dataGridView);

            if (hit.Type == DataGridViewHitTestType.None || hit.Type == DataGridViewHitTestType.ColumnHeader)
            {
                e.Cancel = true;
            }
        }

         public static void ShowAnotherContextMenuOnEmptySpaceInDGV(DataGridView dataGridView, ContextMenuStrip contextMenuStrip)
        {
            DataGridView.HitTestInfo hit = clsFormHelper.GetHitTestInfo(dataGridView);

            if (hit.Type == DataGridViewHitTestType.None)
            {
                contextMenuStrip.Show(dataGridView, clsFormHelper.GetCurrentPoint(dataGridView));
            }
        }

        public static void SetDefaultValuesToCountriesComboBox(ComboBox countriesComboBox)
        {
            countriesComboBox.Items.Add("All");
            countriesComboBox.Items.AddRange(clsAppSettings.GetCountries());
            countriesComboBox.SelectedIndex = 0;
        }
        
        public static void SetLicenseClassesToComboBox(ComboBox licenseClassesComboBox)
        {
            DataTable licenseClasses = clsLicenseClass.GetAllLicenseClasses();

            foreach (DataRow licenseClass in licenseClasses.Rows)
            {
                licenseClassesComboBox.Items.Add(licenseClass["ClassName"]);
            }
        }

        public static Image GetDefaultPersonImage(clsPerson.enGender gender)
        {
            return gender == clsPerson.enGender.Male ? Resources.Male_512 : Resources.Female_512;
        }

        public static void ShowPassword(object sender, MouseEventArgs e)
        {
            if (sender is PictureBox pictureBox)
            {
                if (pictureBox.Tag is TextBox textBox)
                {
                    textBox.UseSystemPasswordChar = false;
                }
            }
        }

        public static void HidePassword(object sender, MouseEventArgs e)
        {
            if (sender is PictureBox pictureBox)
            {
                if (pictureBox.Tag is TextBox textBox)
                {
                    textBox.UseSystemPasswordChar = true;
                }
            }
        }

        public static void SetPasswordsVisibility(TextBox[] passwordFields, bool isVisible)
        {
            foreach (TextBox textBox in passwordFields)
            {
                textBox.UseSystemPasswordChar = !isVisible;
            }
        }

    }
}
