using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using DVLD.WinForms.People;

namespace DVLD.WinForms
{
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();
        }

        private void Test_Load(object sender, EventArgs e)
        {
            string appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string dvldImagesFolder = Path.Combine(appDataFolder, "DVLD-People-Images");

            if (!Directory.Exists(dvldImagesFolder))
            {
                Directory.CreateDirectory(dvldImagesFolder);
            }

            string destinationFile = Path.Combine(dvldImagesFolder, $"{Guid.NewGuid()}.JPG");
            File.Copy("C:\\Users\\mozaf\\GitHub\\csharp-database\\ContactsProject-WindowsForms\\ContactsProject-WindowsForms\\Resources\\Mohammed AbuHadhoud.JPG", destinationFile);

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
