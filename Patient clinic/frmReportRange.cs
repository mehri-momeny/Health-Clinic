using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Patient_clinic
{
    public partial class frmReportRange : Form
    {
        //string savePath = "";
        public frmReportRange()
        {
            InitializeComponent();
        }

        private void BtnPath_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            // Feed the dummy name to the save dialog
            sf.FileName = "Report";
            if (sf.ShowDialog() == DialogResult.OK)
            {
                // Now here's our save folder
                Program.SavePath = Path.GetDirectoryName(sf.FileName);
                txtPath.Text = Program.SavePath;
            }
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            Program.DateRange = " between \'" + bPCalFrom.Text + "\' and \'" + bpcalTo.Text+"\' ";
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmReportRange_Load(object sender, EventArgs e)
        {
            bPCalFrom.Today_Click(null, null);
            bpcalTo.Today_Click(null, null);
        }
    }
}
