using System;
using System.Windows.Forms;
using DVLD.BusinessLogic;
using DVLD.WinForms.Utils;

namespace DVLD.WinForms.Tests
{
    public partial class frmUpdateTestType : Form
    {
        private clsTestType _TestType;

        public bool IsSaveSuccess { get; set; }

        public frmUpdateTestType(int TestTypeID)
        {
            InitializeComponent();
            IsSaveSuccess = false;
            _TestType = clsTestType.Find(TestTypeID);
        }

        private void frmUpdateApplicationType_Load(object sender, EventArgs e)
        {
            if (_TestType == null)
            {
                clsFormMessages.ShowTestTypeNotFoundError();
                this.Close();
                return;
            }

            _LoadDataFromTestTypeObjectToUI();
        }

        private void txtTitle_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            clsFormValidation.ValidatingRequiredField(txtTitle, "Title is required field.", errorProvider);
        }

        private void txtDescription_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            clsFormValidation.ValidatingRequiredField(txtDescription, "Description is required field.", errorProvider);
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

            _FillTestTypeObjectFromUI();

            if (clsFormMessages.ConfirmSava())
            {
                if (_TestType.Save())
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

        private void _LoadDataFromTestTypeObjectToUI()
        {
            lblApplicationTypeID.Text = _TestType.ID.ToString();
            txtTitle.Text = _TestType.Title;
            txtDescription.Text = _TestType.Description;
            txtFees.Text = _TestType.Fees.ToString();
        }

        private void _FillTestTypeObjectFromUI()
        {
            _TestType.Title = txtTitle.Text;
            _TestType.Description = txtDescription.Text;
            _TestType.Fees = float.Parse(txtFees.Text);
        }

    }
}
