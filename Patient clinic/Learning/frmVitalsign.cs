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
    public partial class frmVitalsign : Form
    {
        public frmVitalsign()
        {
            InitializeComponent();
        }

        private void Btncancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
