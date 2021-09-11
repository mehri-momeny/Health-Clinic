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
using System.Globalization;


namespace Patient_clinic
{
    public partial class frmFollowEntry : Form
    {
        SqlConnection con = Program.CreateConnection();  //new SqlConnection("Data Source =(local) ; initial catalog = Health_clinic ; integrated security=true"); //Program.CreateConnection();
        SqlCommand cmd = new SqlCommand();
        PersianCalendar p = new PersianCalendar();
        int Patient_ID = 0;
        public frmFollowEntry()
        {
            InitializeComponent();
        }
        void Display_data()
        {
            int RecordCount = 0;
            con.Open();
            if (txtNational_Code.Text != "")
            {
                try
                {
                    cmd.Connection = con;
                    cmd.CommandText = "select count(national_code) from [FU_Patient_Demographic] where national_code =\'" + txtNational_Code.Text + "\'"; //@Code";
                                                                                                                                                          //cmd.Parameters.Add("@Code", txtNationalcode.Text);
                    RecordCount = Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch (Exception e)
                {
                    MessageBox.Show("مشکلی  پیش آمده است٬مجددا کد ملی را وارد نمایید\n" + e.Message);
                    txtNational_Code.Clear();
                }

                if (RecordCount > 0)

                {
                    cmd.Parameters.Clear();
                    cmd.CommandText = "select * from FU_Patient_Demographic where national_code =@NationalCode";
                    cmd.Parameters.AddWithValue("@NationalCode", txtNational_Code.Text);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Patient_ID = int.Parse(reader["Patient_ID"].ToString());
                        //آیتم ها لود میشود
                        //Patient_ID = reader["Patient_ID"];
                        txtFirstName.Text = reader["First_name"].ToString();
                        txtLastName.Text = reader["Last_name"].ToString();
                        txtBirth_Year.Text = reader["Year_Birth_date"].ToString();
                        txtMobile.Text = reader["Tel"].ToString();
                    }
                }
            }
            else if (chbNonIrani.Checked = true && txtarrchiveNumber.Text != "") //کد ملی نداشته باشه
            {
                //
            }

            con.Close();
        }

        private int Patient_ID_Retrieve()
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd.Connection = con;
            cmd.Parameters.Clear();
            cmd.CommandText = "SELECT Last_ID from FU_Last_ID";
            int P_ID = Convert.ToInt32(cmd.ExecuteScalar());
            P_ID++;
            //con.Close();
            return P_ID;
        }
        bool check_essensial_field()
        {
            if ((chbNonIrani.Checked == false) && !(Main_Functions.check_code(txtNational_Code.Text)))
            {
                txtNational_Code.Focus();
                return false;
            }
            if (txtFirstName.Text.Length == 0 || txtLastName.Text.Length == 0 || txtarrchiveNumber.Text.Length == 0 || cmbSurgeryType.SelectedIndex == -1 || txtMobile.Text.Length == 0)
            {
                if (txtFirstName.Text.Length == 0)
                    txtFirstName.BackColor = System.Drawing.Color.LightPink;
                if (txtLastName.Text.Length == 0)
                    txtLastName.BackColor = System.Drawing.Color.LightPink;
                if (txtarrchiveNumber.Text.Length == 0)
                    txtarrchiveNumber.BackColor = System.Drawing.Color.LightPink;
                if (cmbSurgeryType.SelectedIndex == -1)
                    cmbSurgeryType.BackColor = System.Drawing.Color.LightPink;
                if (txtMobile.Text.Length == 0)
                    txtMobile.BackColor = System.Drawing.Color.LightPink;
                //if (txtNationalcode.Text.Length == 0)
                //    txtNationalcode.BackColor = System.Drawing.Color.LightPink;
                MessageBox.Show("لطفا فیلد‌های مشخص شده را کامل نمایید.");
                return false;
            }
            //if (chbNonIrani.Checked == true && txtarrchiveNumber.Text.Length ==0)
            //{
            //    txtarrchiveNumber.BackColor = System.Drawing.Color.LightPink;
            //    MessageBox.Show("شماره پرونده بیمار را وارد نمایید.");
            //}
            return true;
        }

        bool save_data()
        {
            int follow_ID = 1;
            cmd.Connection = con;
            try
            {
                con.Open();
                if (Patient_ID == 0) // new patient
                {
                    Patient_ID = Patient_ID_Retrieve();
                    // insert Dempgraphic Record patient 
                    cmd.Parameters.Clear();
                    cmd.CommandText = "INSERT INTO [dbo].[FU_Patient_Demographic]" +
                                      "([Patient_ID],[First_name],[Last_name],[national_code],[Year_Birth_date],[Tel],[InsertLog])" +
                                        "VALUES" +
                                        "(@Patient_ID, @First_name, @Last_name, @national_code, @Year_Birth_date, @Tel,@InsertLog)";

                    cmd.Parameters.AddWithValue("@Patient_ID", Patient_ID);
                    cmd.Parameters.AddWithValue("@national_code", txtNational_Code.Text);
                    cmd.Parameters.AddWithValue("@First_name", txtFirstName.Text);
                    cmd.Parameters.AddWithValue("@Last_name", txtLastName.Text);
                    cmd.Parameters.AddWithValue("@Year_Birth_date", txtBirth_Year.Text);
                    cmd.Parameters.AddWithValue("@Tel", txtMobile.Text);
                    cmd.Parameters.AddWithValue("@InsertLog", DateTime.Now + " " + System.Security.Principal.WindowsIdentity.GetCurrent().Name);

                    cmd.ExecuteNonQuery();
                }
                else
                {
                    //update name and other information 
                    cmd.Parameters.Clear();
                    cmd.CommandText = "UPDATE [dbo].[FU_Patient_Demographic]" +
                        " SET [First_name] =@First_name,[Last_name] = @Last_name,[Year_Birth_date] =@Year_Birth_date,[Tel] = @Tel, [InsertLog]=@InsertLog " +
                        " WHERE [Patient_ID] =" + Patient_ID;
                    cmd.Parameters.AddWithValue("@First_name", txtFirstName.Text);
                    cmd.Parameters.AddWithValue("@Last_name", txtLastName.Text);
                    cmd.Parameters.AddWithValue("@Year_Birth_date", txtBirth_Year.Text);
                    cmd.Parameters.AddWithValue("@Tel", txtMobile.Text);
                    cmd.Parameters.AddWithValue("@InsertLog", DateTime.Now + " " + System.Security.Principal.WindowsIdentity.GetCurrent().Name);
                    cmd.ExecuteNonQuery();

                    //////temp for checking 
                    //string tmp = cmd.CommandText.ToString();
                    //foreach (SqlParameter p in cmd.Parameters)
                    //{
                    //    tmp = tmp.Replace('@' + p.ParameterName.ToString(), "'" + p.Value.ToString() + "'");
                    //}
                    ///////
                    ///
                    //*******get previous data of follow up*******\\
                    //cmd.Connection = con;
                    cmd.Parameters.Clear();
                    cmd.CommandText = "select count(Patient_ID) from FU_Follow_Patient_Clinical where Patient_ID =" + Patient_ID;
                    int RecordCount = Convert.ToInt32(cmd.ExecuteScalar());
                    follow_ID = ++RecordCount;
                }

                //insert Clinical Record 
                cmd.Parameters.Clear();
                cmd.CommandText = "INSERT INTO [dbo].[FU_Follow_Patient_Clinical] " +
                                     " ([Patient_ID],[Follow_ID],[Archive_number],[ref_turn],[Doc_name],[Admition_Date],[Discharge_Date],[Surgery_Type]) " +
                                     " VALUES(@Patient_ID, @Follow_ID, @Archive_number, @ref_turn, @Doc_name, @Admition_Date, @Discharge_Date, @Surgery_Type)";
                cmd.Parameters.AddWithValue("@Patient_ID", Patient_ID);
                cmd.Parameters.AddWithValue("@Follow_ID", follow_ID);
                cmd.Parameters.AddWithValue("@Archive_number", txtarrchiveNumber.Text);
                cmd.Parameters.AddWithValue("@ref_turn", txtrefturn.Text);
                cmd.Parameters.AddWithValue("@Doc_name", cmbDoc.Text);
                cmd.Parameters.AddWithValue("@Admition_Date", bpcalAdmitionDate.Text);
                cmd.Parameters.AddWithValue("@Discharge_Date", bpcalDischargeDate.Text);
                cmd.Parameters.AddWithValue("@Surgery_Type", cmbSurgeryType.SelectedValue);

                cmd.ExecuteNonQuery();

                //insert followup Record 
                cmd.Parameters.Clear();
                cmd.CommandText = "INSERT INTO [dbo].[FU_Follow_List]([Patient_ID],[Follow_ID],[FollowUp_Date],[Flag],[Follow_turn])" +
                                    "VALUES(@Patient_ID,@Follow_ID, @FollowUp_Date,0,1)";
                cmd.Parameters.AddWithValue("@Patient_ID", Patient_ID);
                cmd.Parameters.AddWithValue("@Follow_ID", follow_ID);
                cmd.Parameters.AddWithValue("@FollowUp_Date", bpcalFollowupDate.Text);

                cmd.ExecuteNonQuery();


                //بروزرسانی آخرین آیدی 
                cmd.CommandText = "UPDATE [dbo].[FU_Last_ID]  SET [Last_ID] =" + Patient_ID + " WHERE Last_ID < " + Patient_ID;
                cmd.ExecuteNonQuery();

                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                //اگر در هر مرحله ای به خطا خورد باید رکورد های مربوط به همین فالوآپ که ثبت شده حذف گردد
                cmd.CommandText = "Delete from [dbo].[FU_Follow_Patient_Clinical] where Patient_ID = " + Patient_ID + " and Follow_ID = " + follow_ID;
                cmd.ExecuteNonQuery();

                cmd.CommandText = "Delete from [dbo].[FU_Follow_List] where Patient_ID = " + Patient_ID + " and Follow_ID = " + follow_ID;
                cmd.ExecuteNonQuery();
                MessageBox.Show(ex.Message);
                con.Close();
                return false;
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if ((check_essensial_field()))  //بررسی پر بودن فیلد های ضروری
            {
                if (save_data())
                {
                    MessageBox.Show("ثبت مشخصات با موفقیت انجام شد", "ثبت موفق", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    EmptyForm();
                }
                else
                    MessageBox.Show("ثبت مشخصات با مشکل مواجه شد , مجددا سعی کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EmptyForm()
        {
            txtNational_Code.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtarrchiveNumber.Text = string.Empty;
            txtrefturn.Text = string.Empty;
            txtMobile.Text = string.Empty;
            txtBirth_Year.Text = string.Empty;

            bpcalAdmitionDate.Today_Click(null, null);
            bpcalAdmitionDate.ReadOnly = false;

            bpcalDischargeDate.Today_Click(null, null);
            bpcalDischargeDate.ReadOnly = false;

            bpcalFollowupDate.Today_Click(null, null);
            bpcalFollowupDate.ReadOnly = false;

            chbNonIrani.Checked = false;
            txtNational_Code.Enabled = true;
            Patient_ID = 0;
            LblAge.Text = ".";

            //cmbDoc.Text = string.Empty;
            //cmbSurgeryType.Text = string.Empty;


        }

        private void TxtNational_Code_Leave(object sender, EventArgs e)
        {
            Display_data();
        }

        private void FrmFollowEntry_Load(object sender, EventArgs e)
        {
            Load_Default_Value();
        }
        void Load_Default_Value()
        {
            cmbDoc.DisplayMember = "name";
            cmbDoc.ValueMember = "Staff_ID";
            cmbDoc.DataSource = Main_Functions.GetDoctor_List();

            bpcalAdmitionDate.Today_Click(null, null);
            bpcalAdmitionDate.ReadOnly = false;

            bpcalDischargeDate.Today_Click(null, null);
            bpcalDischargeDate.ReadOnly = false;

            bpcalFollowupDate.Today_Click(null, null);
            bpcalFollowupDate.ReadOnly = false;

            con.Open();
            //Diagnose combobox
            string query = "SELECT [Id],[Name]  FROM [dbo].[MI_Surgery_type]";
            SqlDataAdapter da = new SqlDataAdapter(query, con);

            DataSet ds = new DataSet();
            da.Fill(ds, "Surgery");
            cmbSurgeryType.DisplayMember = "Name";
            cmbSurgeryType.ValueMember = "Id";
            cmbSurgeryType.DataSource = ds.Tables["Surgery"];
            //cmbSurgeryType.SelectedIndex = 0;

            con.Close();

        }

        private void Btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TxtNational_Code_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            txtNational_Code.MaxLength = 10; // this will allow the user to enter only 10 digits
        }

        private void TxtNational_Code_Enter(object sender, EventArgs e)
        {
            txtNational_Code.BackColor = System.Drawing.Color.White;
        }

        private void TxtFirstName_Enter(object sender, EventArgs e)
        {
            txtFirstName.BackColor = System.Drawing.Color.White;
        }

        private void TxtLastName_Enter(object sender, EventArgs e)
        {
            txtLastName.BackColor = System.Drawing.Color.White;
        }

        private void TxtarrchiveNumber_Enter(object sender, EventArgs e)
        {
            txtarrchiveNumber.BackColor = System.Drawing.Color.White;
        }

        private void ChbNonIrani_CheckStateChanged(object sender, EventArgs e)
        {
            if (chbNonIrani.Checked == true)
                txtNational_Code.Enabled = false;
        }

        private void TxtBirth_Year_Leave(object sender, EventArgs e)
        {
            if (txtBirth_Year.Text.Length != 4)
            {
                MessageBox.Show("لطفا سال تولد را به فرمت صحیح وارد نمایید!");
                txtBirth_Year.Focus();
                return;
            }
            try
            {
                int age = p.GetYear(DateTime.Now) - int.Parse(txtBirth_Year.Text);
                /*((TimeSpan)(Convert.ToDateTime(bprefdate.Value) - Convert.ToDateTime(bpCal.Value))).Days/365*/
                LblAge.Text = age.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("لطفا اعداد را با قراردادن صفحه کلید در حالت زبان انگلیسی وارد نمایید");
                txtBirth_Year.Focus();
                return;
            }

        }

        private void TxtBirth_Year_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            txtBirth_Year.MaxLength = 4;
        }

        private void TxtarrchiveNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Txtrefturn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TxtMobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TxtMobile_Enter(object sender, EventArgs e)
        {
            txtMobile.BackColor = System.Drawing.Color.White;
        }
    }
}
