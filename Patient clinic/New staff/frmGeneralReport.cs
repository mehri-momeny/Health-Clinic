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
using Telerik.WinControls.UI;

namespace Patient_clinic.New_staff
{
    public partial class frmGeneralReport : Form
    {
        SqlConnection con = Program.CreateConnection();  //new SqlConnection("Data Source =(local) ; initial catalog = Health_clinic ; integrated security=true"); //Program.CreateConnection();
        SqlCommand cmd = new SqlCommand();
        public frmGeneralReport()
        {
            InitializeComponent();
        }

        private void FrmGeneralReport_Load(object sender, EventArgs e)
        {
            Load_Default_Value();
            dgv_load();
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

        private void BtnShow_Data_Click(object sender, EventArgs e)
        {
            dgv_load();
        }
        void dgv_load()
        {
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();

                SqlDataAdapter adp = new SqlDataAdapter();
                DataSet ds = new DataSet();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;

                adp.SelectCommand.CommandText = "SELECT National_code,First_Name,Last_Name,Point ,Date "+
                                                "FROM NS_Test_Result TR, NS_Staffs S "+
                                                "WHERE S.ID = TR.S_ID AND TR.T_ID = @T_ID ";

                adp.SelectCommand.Parameters.AddWithValue("T_ID", cmbTest.SelectedValue);

                adp.Fill(ds, "Report");

                radGvReport.DataSource = ds;
                radGvReport.DataMember = "Report";
                Convert_column_name(radGvReport);
            }
            catch (Exception ex)
            {

                MessageBox.Show("مشکلی  پیش آمده است٬مجددا امتحان کنید\n" + ex.Message);
            }

            con.Close();
        }
        private void Convert_column_name(RadGridView radGvReport)
        {
            radGvReport.TableElement.RowHeight = 30;
            radGvReport.Columns["National_code"].HeaderText = "کد ملی ";
            radGvReport.Columns["National_code"].Width = 100;
            radGvReport.Columns["National_code"].TextAlignment = ContentAlignment.MiddleCenter;

            radGvReport.Columns["First_Name"].HeaderText = "نام";
            radGvReport.Columns["First_Name"].Width = 90;
            radGvReport.Columns["First_Name"].TextAlignment = ContentAlignment.MiddleLeft;

            radGvReport.Columns["Last_Name"].HeaderText = "نام خانوادگی ";
            radGvReport.Columns["Last_Name"].Width = 120;
            radGvReport.Columns["Last_Name"].TextAlignment = ContentAlignment.MiddleLeft;

            radGvReport.Columns["Point"].HeaderText = "نمره";
            radGvReport.Columns["Point"].Width = 70;
            radGvReport.Columns["Point"].TextAlignment = ContentAlignment.MiddleLeft;

            radGvReport.Columns["Date"].HeaderText = "تاریخ";
            radGvReport.Columns["Date"].Width = 80;
            radGvReport.Columns["Date"].TextAlignment = ContentAlignment.MiddleCenter;


        }

        private void Btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CmbTest_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dgv_load();
            }
        }
    }
}
