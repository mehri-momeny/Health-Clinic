using Patient_clinic.Follow_up;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Patient_clinic
{
    public partial class frmFollowMain : Form
    {
        public frmFollowMain()
        {
            InitializeComponent();
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            frmFollowEntry frmFollowEntry = new frmFollowEntry();
            frmFollowEntry.ShowDialog();
            //this.Close();
        }

        private void ButtonX1_Click(object sender, EventArgs e)
        {
            FrmFollowList frmFollowList = new FrmFollowList();
            frmFollowList.ShowDialog();
            //this.Close();
        }

        private void Btnreport_Click(object sender, EventArgs e)
        {
            frmReport frmreport = new frmReport();
            frmreport.ShowDialog();
        }
    }
}
