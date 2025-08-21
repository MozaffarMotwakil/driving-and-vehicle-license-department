using System;
using System.Windows.Forms;
using DVLD.BusinessLogic;
using DVLD.WinForms.Utils;

namespace DVLD.WinForms.Licenses
{
    public partial class ctrDriverLicenseInfoWithFilter : UserControl
    {
        public clsLicense License { get; private set; }

        public event Action FoundLicense;
        protected virtual void OnFoundLicense()
        {
            FoundLicense?.Invoke();
        }

        public event Action NotFoundLicense;
        protected virtual void OnNotFoundLicense()
        {
            NotFoundLicense?.Invoke();
        }

        public ctrDriverLicenseInfoWithFilter()
        {
            InitializeComponent();
            License = null;
        }

        private void txtFilterText_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsFormValidation.HandleNumericKeyPress(e, txtFilterText, errorProvider);
        }

        private void txtFilterText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnFindLicense.PerformClick();
                e.Handled = true;
            }
        }

        private void btnFindLicense_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFilterText.Text) || 
                (License != null && License.LicenseID == int.Parse(txtFilterText.Text)))
            {
                return;
            }

            License = clsLicense.FindByLicenseID(int.Parse(txtFilterText.Text));

            if (License != null)
            {
                ctrDriverLicenseInfo.LoadLicenseDataForDisplay(License);
                OnFoundLicense();
            }
            else
            {
                Clear();
                OnNotFoundLicense();
            }
        }

        public void Clear()
        {
            License = null;
            ctrDriverLicenseInfo.Clear();
        }

        public void FocusOnFilterText()
        {
            txtFilterText.Focus();
        }

    }
}
