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
//using Telerik.WinControls.UI.Export;

namespace Patient_clinic.New_staff
{
    public partial class frmReportNSTests : Form
    {
        SqlConnection con = Program.CreateConnection();  //new SqlConnection("Data Source =(local) ; initial catalog = Health_clinic ; integrated security=true"); //Program.CreateConnection();
        SqlCommand cmd = new SqlCommand();
        int S_ID = 0;
        public frmReportNSTests()
        {
            InitializeComponent();
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

        private void CmbTest_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Load_Data();
                dgv_load();
            }
        }
        void Load_Data()
        {
            S_ID = Get_S_ID(txtNational_Code.Text);
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                cmd.Connection = con;
                cmd.Parameters.Clear();
                cmd.CommandText = "SELECT Point,Date FROM NS_Test_Result WHERE S_ID = @S_ID AND T_ID = @T_ID";
                cmd.Parameters.AddWithValue("S_ID", S_ID);
                cmd.Parameters.AddWithValue("T_ID", cmbTest.SelectedValue);


                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())  //while (reader.Read())
                {
                    txtPoint.Text = Convert.ToInt32(reader["Point"]).ToString();
                    lblDate.Text = reader["Date"].ToString();
                }
                else
                {
                    txtPoint.Text = String.Empty;
                    lblDate.Text = "آزمون انجام نشده است";
                }

                reader.Close();
                


                //total point of test 
                cmd.Parameters.Clear();
                cmd.CommandText = "SELECT [Total_Point] FROM [NS_Tests] WHERE ID = @T_ID";
                cmd.Parameters.AddWithValue("T_ID", cmbTest.SelectedValue);
                lbltotalPoint.Text = cmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("مشکلی  پیش آمده است٬مجددا امتحان کنید\n" + ex.Message);
            }
            

            con.Close();
        }
        int Get_S_ID(string National_Code)
        {
            int S_ID;
            con.Open();
            cmd.Connection = con;
            try
            {
                cmd.CommandText = "select ID from [NS_Staffs] where National_code =\'" + txtNational_Code.Text + "\'";
                S_ID = Convert.ToInt32(cmd.ExecuteScalar());
               
            }
            catch (Exception e)
            {
                MessageBox.Show("مشکلی  پیش آمده است٬مجددا کد ملی را وارد نمایید\n" + e.Message);
                txtNational_Code.Clear();
                S_ID = 0;
            }
            con.Close();
            return S_ID;
        }

        private void BtnShow_Data_Click(object sender, EventArgs e)
        {
            Load_Data();
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

                adp.SelectCommand.CommandText = "SELECT  ROW_NUMBER() OVER(ORDER BY Q.ID ASC) Row_num,Q.Text, " +
                                                       " CASE "+
                                                        "    WHEN Answer = 1 THEN opt1 "+
                                                        "    WHEN Answer = 2 THEN opt2 "+
                                                        "   WHEN Answer = 3 THEN opt3 "+
                                                        "    WHEN Answer = 4 THEN opt4 "+
                                                        "    ELSE '' "+
                                                        "END AS S_answer, "+
                                                        "CASE "+
                                                        "   WHEN Correct_Answer = 1 THEN opt1 "+
                                                        "    WHEN Correct_Answer = 2 THEN opt2 "+
                                                        "    WHEN Correct_Answer = 3 THEN opt3 "+
                                                        "    WHEN Correct_Answer = 4 THEN opt4 "+
                                                        "    ELSE '' "+
                                                        "END AS C_answer "+
                                                    "FROM NS_Question_Answers NSQA, MI_Q_Answer_Options MIQO,MI_Questions Q "+
                                                    "WHERE NSQA.Q_ID = MIQO.Q_ID AND S_ID = @S_ID AND T_ID = @T_ID AND Answer != Correct_Answer AND NSQA.Q_ID = Q.ID";
                adp.SelectCommand.Parameters.AddWithValue("S_ID", S_ID);
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
            radGvReport.Columns["Row_num"].HeaderText = "ردیف ";
            radGvReport.Columns["Row_num"].Width = 35;
            radGvReport.Columns["Row_num"].TextAlignment = ContentAlignment.MiddleLeft;

            radGvReport.Columns["Text"].HeaderText = "عنوان سوال ";
            radGvReport.Columns["Text"].Width = 493;
            radGvReport.Columns["Text"].WrapText = true;
            radGvReport.Columns["Text"].TextAlignment = ContentAlignment.MiddleLeft;

            radGvReport.Columns["S_answer"].HeaderText = "پاسخ انتخاب شده ";
            radGvReport.Columns["S_answer"].Width = 170;
            radGvReport.Columns["S_answer"].WrapText = true;
            radGvReport.Columns["S_answer"].TextAlignment = ContentAlignment.MiddleCenter;

            radGvReport.Columns["C_answer"].HeaderText = "پاسخ صحیح ";
            radGvReport.Columns["C_answer"].Width = 170;
            radGvReport.Columns["C_answer"].WrapText = true;
            radGvReport.Columns["C_answer"].TextAlignment = ContentAlignment.MiddleCenter;

        }

        private void TxtNational_Code_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Load_Data();
                dgv_load();
            }
        }


        private void Btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }
    }
}
