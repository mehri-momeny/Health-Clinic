using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Patient_clinic.New_staff
{
    public partial class frmReportNSTests : Form
    {
        SqlConnection con = Program.CreateConnection();  //new SqlConnection("Data Source =(local) ; initial catalog = Health_clinic ; integrated security=true"); //Program.CreateConnection();
        SqlCommand cmd = new SqlCommand();
        public frmReportNSTests()
        {
            InitializeComponent();
        }

        private void TxtYear_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtNational_Code_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            txtNational_Code.MaxLength = 10; // this will allow the user to enter only 10 digits
        }

        private void FrmReportNSTests_Load(object sender, EventArgs e)
        {
            Load_Default_Value();
        }
        void Load_Default_Value()
        {
            con.Open();
            //Section combobox
            string query = "SELECT [Id],[Title]  FROM [dbo].[NS_Tests]";
            SqlDataAdapter da = new SqlDataAdapter(query, con);

            DataSet ds = new DataSet();
            da.Fill(ds, "Tests");
            cmbTest.DisplayMember = "Title";
            cmbTest.ValueMember = "Id";
            cmbTest.DataSource = ds.Tables["Tests"];
            //cmbSurgeryType.SelectedIndex = 0;

            con.Close();
        }
    }
}
