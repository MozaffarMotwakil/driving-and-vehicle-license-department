using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DVLD.BusinessLogic;
using DVLD.WinForms.Properties;

namespace DVLD.WinForms.Global
{
    public static class clsSettings
    {
        private static string _AppDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        public static string PeopleImagesFolderPath
        {
            get
            {
                string peopleImagesFolderPath = Path.Combine(_AppDataFolder, "DVLD-People-Images");

                if (!Directory.Exists(peopleImagesFolderPath))
                {
                    Directory.CreateDirectory(peopleImagesFolderPath);
                }

                return peopleImagesFolderPath;
            }
        }

        public static string GetNewImagePathWithGUID()
        {
            return Path.Combine(PeopleImagesFolderPath, $"{Guid.NewGuid()}.JPG");
        }

        public static string[] GetCountries()
        {
            DataTable countriesFromDB = clsCountry.GetAllCountries();
            string[] countriesNames = new string[countriesFromDB.Rows.Count];

            for (int i = 0; i < countriesNames.Length; i++)
            {
                countriesNames[i] = countriesFromDB.Rows[i]["CountryName"].ToString();
            }

            return countriesNames;
        }

        public static Image GetDefaultPersonImage(clsPerson.enGender Gender)
        {
            return Gender == clsPerson.enGender.Male ? Resources.Male_512 : Resources.Female_512;
        }
        
        public static Image GetDefaultPersonImage(bool IsMale)
        {
            return IsMale ? Resources.Male_512 : Resources.Female_512;
        }

        public static int RefreshDataGridViewWithFiltter(DataGridView dataGridView, DataView DataSource, string FilterColumn, string Text)
        {
            DataView list = (DataView)dataGridView.DataSource;

            // Apply different filter logic based on the selected column.
            // 'LIKE' is used for text columns, '=' for exact ID match.
            if (!FilterColumn.EndsWith("ID") && FilterColumn != "IsActive")
            {
                list.RowFilter = $"{FilterColumn} LIKE '{Text}%'";
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(Text))
                {
                    list.RowFilter = $"{FilterColumn} = {Text}";
                }
                else
                {
                    // If ID filter is empty, show all people again.
                    // Why: To avoid an empty list when the ID filter is cleared.
                    DataSource.RowFilter = string.Empty;
                    return RefreshDataGridView(dataGridView, DataSource);
                }
            }

            // The DataSource is updated with the filtered DataView.
            // Why: Filtering on the DataView directly is efficient as it works on the
            // already loaded data, avoiding re-querying the database just for filtering.
            return RefreshDataGridView(dataGridView, list);
        }

        public static int RefreshDataGridView(DataGridView dataGridView, object DataSource)
        {
            dataGridView.DataSource = DataSource;
            return dataGridView.RowCount;
        }

        /// <summary>
        /// Select the entire row where the right mouse button was pressed, and check the selected is not column.
        /// rather than selecting a single cell because the context menu is on the person, not the cell.
        /// </summary>
        public static void SelecteEntireRow(DataGridView dataGridView, DataGridViewCellMouseEventArgs e)
        {
            if ((e.Clicks == 2 || e.Button == MouseButtons.Right) && e.RowIndex >= 0)
            {
                dataGridView.ClearSelection();
                dataGridView.Rows[e.RowIndex].Selected = true;
                dataGridView.CurrentCell = dataGridView.SelectedRows[0].Cells[0];
            }
        }

        public static void DeselectCellsAndRows(DataGridView dataGridView, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hit = dataGridView.HitTest(e.X, e.Y);

            if (e.Button == MouseButtons.Right || e.Button == MouseButtons.Left && hit.Type == DataGridViewHitTestType.None)
            {
                foreach (DataGridViewCell cell in dataGridView.SelectedCells)
                {
                    cell.Selected = false;
                }

                foreach (DataGridViewRow row in dataGridView.SelectedRows)
                {
                    row.Selected = false;
                }
            }
        }

        public static int GetSelectedRowID(DataGridView dataGridView)
        {
            return Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
        }

    }
}
