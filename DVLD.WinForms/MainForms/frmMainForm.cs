using System;
using System.Windows.Forms;
using DVLD.WinForms.People;

namespace DVLD.WinForms.MainForms
{
    public partial class frmMainForm : Form
    {
        public frmMainForm()
        {
            InitializeComponent();
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManagePeople managePeopleForm = new frmManagePeople();
            managePeopleForm.ShowDialog();
        }

    }
}
