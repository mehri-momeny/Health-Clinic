using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Patient_clinic.New_staff
{
    public partial class frmNewStaff_Main : Form
    {
        public frmNewStaff_Main()
        {
            InitializeComponent();
        }

        private void Btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btnshowform_Click(object sender, EventArgs e)
        {
            frmChooseTest frmChooseTest = new frmChooseTest();
            frmChooseTest.ShowDialog();
        }
    }
}
