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
    public partial class frmChooseReport : Form
    {
        public frmChooseReport()
        {
            InitializeComponent();
        }

        private void FrmChooseReport_Load(object sender, EventArgs e)
        {

        }

        private void Btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnshowTestform_Click(object sender, EventArgs e)
        {
            frmGeneralReport frm = new frmGeneralReport();
            frm.ShowDialog();
        }

        private void BtnReport_Click(object sender, EventArgs e)
        {
            frmReportNSTests frmReportNSTests = new frmReportNSTests();
            frmReportNSTests.ShowDialog();
        }
    }
}
