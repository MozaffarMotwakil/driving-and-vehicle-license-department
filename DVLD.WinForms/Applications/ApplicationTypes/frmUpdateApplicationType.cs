using System;
using System.Windows.Forms;
using DVLD.BusinessLogic;
using DVLD.WinForms.Utils;

namespace DVLD.WinForms.Applications
{
    public partial class frmUpdateApplicationType : Form
    {
        private clsApplicationType _ApplicationType;

        public bool IsSaveSuccess { get; set; }

        public frmUpdateApplicationType(int ApplicationTypeID)
        {
            InitializeComponent();
            IsSaveSuccess = false;
            _ApplicationType = clsApplicationType.Find(ApplicationTypeID);
        }

        private void frmUpdateApplicationType_Load(object sender, EventArgs e)
        {
            if (_ApplicationType == null)
            {
                clsFormMessages.ShowApplicationTypeNotFoundError();
                this.Close();
                return;
            }

            _LoadDataFromApplicationTypeObjectToUI();
        }

        private void txtTitle_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            clsFormValidation.ValidatingRequiredField(txtTitle, "Title is required field.", errorProvider);
        }

        private void txtFees_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            clsFormValidation.ValidatingRequiredField(txtFees, "Fees is required field.", errorProvider);
        }

        private void txtFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsFormValidation.HandleNumericKeyPress(e, txtFees, errorProvider);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!clsFormValidation.IsDataValid(this, this.Controls, errorProvider))
            {
                clsFormMessages.ShowInvalidDataError();
                return;
            }

            _FillApplicationTypeObjectFromUI();

            if (clsFormMessages.ConfirmSava())
            {
                if (_ApplicationType.Save())
                {
                    clsFormMessages.ShowSuccess("Saved successfully.");
                    IsSaveSuccess = true;
                }
                else
                {
                    clsFormMessages.ShowError("Failed Save.");
                }
            }
        }

        private void btnCloseScreen_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _LoadDataFromApplicationTypeObjectToUI()
        {
            lblApplicationTypeID.Text = _ApplicationType.TypeID.ToString();
            txtTitle.Text = _ApplicationType.Title;
            txtFees.Text = _ApplicationType.Fees.ToString();
        }

        private void _FillApplicationTypeObjectFromUI()
        {
            _ApplicationType.Title = txtTitle.Text;
            _ApplicationType.Fees = float.Parse(txtFees.Text);
        }

    }
}
