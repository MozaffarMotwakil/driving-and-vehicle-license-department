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
        public static int RefreshDataGridViewWithFilter(DataGridView dataGridView, DataView DataSource, string FilterColumn, string FilterText)
        {
            DataView list = (DataView)dataGridView.DataSource;

            if (!FilterColumn.EndsWith("ID") && FilterColumn != "IsActive")
            {
                list.RowFilter = $"{FilterColumn} LIKE '{FilterText}%'";
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(FilterText))
                {
                    list.RowFilter = $"{FilterColumn} = {FilterText}";
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

        public static void ReapplyAndHighlightFilterText(TextBox textBox)
        {
            if (!string.IsNullOrEmpty(textBox.Text))
            {
                string temp = textBox.Text;
                textBox.Text = string.Empty;
                textBox.Text = temp;

                textBox.SelectionStart = 0;
                textBox.SelectionLength = textBox.TextLength;
            }
        }

        /// <summary>
        /// Select the entire row where the right mouse button was pressed, and check the selected is not column.
        /// rather than selecting a single cell because the context menu is on the record, not the cell.
        /// </summary>
        public static void SelectEntireRow(DataGridView dataGridView, DataGridViewCellMouseEventArgs e)
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
