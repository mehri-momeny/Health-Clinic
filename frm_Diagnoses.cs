using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Patient_clinic
{
    public partial class frm_Diagnoses : Form
    {
        SqlConnection con = new SqlConnection("Data Source =(local) ; initial catalog = Health_clinic ; integrated security=true");
        SqlCommand cmd = new SqlCommand();
        public frm_Diagnoses()
        {
            InitializeComponent();
        }

        private void Frm_Diagnoses_Load(object sender, EventArgs e)
        {
            Dgv_Diagnose_load();


        }
        void Dgv_Diagnose_load()
        {
            SqlDataAdapter adp = new SqlDataAdapter();
            con.Open();
            DataSet ds = new DataSet();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "SELECT * FROM[dbo].[MI_Diagnose]";
            adp.Fill(ds, "Diagnose");
            dgv_Diagnoses.DataSource = ds;
            dgv_Diagnoses.DataMember = "Diagnose";

            dgv_Diagnoses.Columns["ID"].HeaderText = "کد تشخیص";
            dgv_Diagnoses.Columns["name"].HeaderText = "نام";
            dgv_Diagnoses.Columns["Abbreviation"].HeaderText = "مخفف";




            con.Close();

        }
    }
}
