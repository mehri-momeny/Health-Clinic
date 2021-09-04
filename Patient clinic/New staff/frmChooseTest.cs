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
    public partial class frmChooseTest : Form
    {
        SqlConnection con = Program.CreateConnection();  //new SqlConnection("Data Source =(local) ; initial catalog = Health_clinic ; integrated security=true"); //Program.CreateConnection();
        SqlCommand cmd = new SqlCommand();
        int Staff_ID = 0;
        public frmChooseTest()
        {
            InitializeComponent();
        }

        private void Btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnTestStart_Click(object sender, EventArgs e)
        {
            if (!(Main_Functions.check_code(txtNational_Code.Text)))
            {
                txtNational_Code.Focus();
            }
            else
            {
                int Test_ID = Convert.ToInt32(cmbTest.SelectedValue);
                if (check_First_Time(Test_ID) == 0)
                {
                    if (Staff_ID != 0 && Update_Staff_Info())
                    {
                        frmTest_Questions frmTest_Questions = new frmTest_Questions(Staff_ID, Test_ID,bpcalTestDate.Text);
                        frmTest_Questions.ShowDialog();
                    }
                    else
                    {
                        if (Save_Staff_Info())
                        {
                            frmTest_Questions frmTest_Questions = new frmTest_Questions(Staff_ID, Test_ID, bpcalTestDate.Text);
                            frmTest_Questions.ShowDialog();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("شما قبلا این آزمون را پاسخ داده‌اید ، امکان ثبت مجدد نمی‌باشد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNational_Code.Text = String.Empty;
                    txtFirst_name.Text = String.Empty;
                    txtLast_name.Text = String.Empty;
                    txtNational_Code.Focus();
                }
            }

        }
        int check_First_Time(int T_ID) // اگر قبلا این آزمون توسط این فرد انجام شده است امکان پاسخ دهی مجدد نمیباشد
        {
            int ID = 0;
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd.Connection = con;
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "SELECT [ID],[S_ID],[T_ID],[Point]  FROM[Health_clinic].[dbo].[NS_Test_Result]  WHERE S_ID =@S_ID AND T_ID = @T_ID";

                cmd.Parameters.AddWithValue("@S_ID", Staff_ID);
                cmd.Parameters.AddWithValue("@T_ID", T_ID);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    ID = Convert.ToInt32(reader["ID"]);
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("مشکلی  پیش آمده است٬مجددا تلاش نمایید\n" + e.Message);
            }
            con.Close();
            return ID;
        }
        void Load_Staff_Info()
        {
            con.Open();
            cmd.Connection = con;
            try
            {
                cmd.CommandText = "select * from [NS_Staffs] where National_code =\'" + txtNational_Code.Text + "\'";
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    txtFirst_name.Text = reader["First_Name"].ToString();
                    txtLast_name.Text = reader["Last_Name"].ToString();
                    Staff_ID = int.Parse(reader["ID"].ToString());
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("مشکلی  پیش آمده است٬مجددا کد ملی را وارد نمایید\n" + e.Message);
                txtNational_Code.Clear();
            }
            con.Close();

        }
        bool Update_Staff_Info()
        // add new staff
        {
            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.Parameters.Clear();
                cmd.CommandText = "UPDATE [dbo].[NS_Staffs] SET [First_Name] =@First_Name,[Last_Name] = @Last_Name "+
                                        "WHERE [National_code] = @National_code";

                cmd.Parameters.AddWithValue("@National_code", txtNational_Code.Text);
                cmd.Parameters.AddWithValue("@First_Name", txtFirst_name.Text);
                cmd.Parameters.AddWithValue("@Last_Name", txtLast_name.Text);
                cmd.ExecuteNonQuery();


                cmd.Parameters.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show("ثبت اطلاعات با مشکل مواجه شده است, مجددا امتحان بفرمایید\n" + ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
                return false;
            }
            con.Close();
            return true;
        }
        bool Save_Staff_Info()
        // add new staff
        {
            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.Parameters.Clear();
                cmd.CommandText = "INSERT INTO [dbo].[NS_Staffs]" +
                                  "([National_code],[First_Name],[Last_Name])" +
                                    "VALUES" +
                                    "(@National_code, @First_Name, @Last_Name)";

                cmd.Parameters.AddWithValue("@National_code", txtNational_Code.Text);
                cmd.Parameters.AddWithValue("@First_Name", txtFirst_name.Text);
                cmd.Parameters.AddWithValue("@Last_Name", txtLast_name.Text);
                cmd.ExecuteNonQuery();


                cmd.Parameters.Clear();
                cmd.CommandText = "SELECT MAX(ID) FROM NS_Staffs";
                Staff_ID = Convert.ToInt32(cmd.ExecuteScalar());

            }
            catch (Exception ex)
            {
                MessageBox.Show("ثبت اطلاعات با مشکل مواجه شده است, مجددا امتحان بفرمایید\n" + ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
                return false;
            }
            con.Close();
            return true;
        }


        private void FrmChooseTest_Load(object sender, EventArgs e)
        {
            txtNational_Code.Focus();
            Load_Default_Value();
            bpcalTestDate.Today_Click(null, null);
            bpcalTestDate.ReadOnly = false;
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

        private void TxtNational_Code_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            txtNational_Code.MaxLength = 10; // this will allow the user to enter only 10 digits
        }

        private void TxtNational_Code_Leave(object sender, EventArgs e)
        {
            Load_Staff_Info();
        }

        private void GroupPanel1_Click(object sender, EventArgs e)
        {

        }
    }
}
