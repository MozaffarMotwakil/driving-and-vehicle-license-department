using System;
using System.Windows.Forms;
using DVLD.BusinessLogic;
using DVLD.WinForms.Utils;

namespace DVLD.WinForms.Licenses
{
    public partial class ctrDriverLicenseInfoWithFilter : UserControl
    {
        public clsLicense License { get; private set; }

        public bool EnableSearch
        {
            get { return gbFilter.Enabled; }
            set { gbFilter.Enabled = value; }
        }

        public event Action<clsLicense> FoundLicense;
        protected virtual void OnFoundLicense()
        {
            FoundLicense?.Invoke(License);
        }

        public event Action NotFoundLicense;
        protected virtual void OnNotFoundLicense()
        {
            NotFoundLicense?.Invoke();
        }

        public ctrDriverLicenseInfoWithFilter()
        {
            InitializeComponent();
            EnableSearch = true;
            License = null;
        }

        private void ctrDriverLicenseInfoWithFilter_Load(object sender, EventArgs e)
        {
            ctrDriverLicenseInfo.Visible = DesignMode;
        }

        private void txtFilterText_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsFormValidation.HandleNumericKeyPress(e, txtFilterText, errorProvider);
        }

        private void txtFilterText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _DoSearch();
                e.Handled = true;
            }
        }

        private void btnFindLicense_Click(object sender, EventArgs e)
        {
            _DoSearch();
        }

        private void _DoSearch()
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
                ctrDriverLicenseInfo.Visible = true;
                OnFoundLicense();
            }
            else
            {
                Clear();
                ctrDriverLicenseInfo.Visible = false;
                OnNotFoundLicense();
            }
        }

        public void Clear()
        {
            License = null;
            ctrDriverLicenseInfo.Clear();
        }

        public void LoadData(clsLicense License)
        {
            if (License != null)
            {
                txtFilterText.Text = License.LicenseID.ToString();
                ctrDriverLicenseInfo.LoadLicenseDataForDisplay(License);
                ctrDriverLicenseInfo.Visible = true;
            }
            else
            {
                Clear();
                ctrDriverLicenseInfo.Visible = false;
            }
        }

        public void PerformSearch(int LicenseID)
        {
            txtFilterText.Text = LicenseID.ToString();
            _DoSearch();
        }

        public void FocusOnFilterText()
        {
            txtFilterText.Focus();
        }

    }
}