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
using System.Configuration;
using System.Data.OleDb;


namespace Patient_clinic
{
    public partial class DataEntry : Form
    {
        System.Globalization.PersianCalendar p = new System.Globalization.PersianCalendar();
        int refturn = 1;
        SqlConnection con = new SqlConnection("Data Source =(local) ; initial catalog = Health_clinic ; integrated security=true");
        SqlCommand cmd = new SqlCommand();
        string last_national_code = "";

        public DataEntry()
        {
            InitializeComponent();
        }

        private void Btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNationalcode_Leave(object sender, EventArgs e)
        {
            txtNationalcode.BackColor = System.Drawing.Color.White;
        }

        void Display_data()
        {
            int RecordCount = 0;
            if (txtNationalcode.Text != "")
            {
                con.Open();
                try
                {
                    cmd.Connection = con;
                    cmd.CommandText = "select count(national_code) from Patients where national_code =\'" + txtNationalcode.Text + "\'"; //@Code";
                                                                                                                                         //cmd.Parameters.Add("@Code", txtNationalcode.Text);
                    RecordCount = Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch (Exception e)
                {
                    MessageBox.Show("مشکلی  پیش آمده است٬مجددا کد ملی را وارد نمایید\n" + e.Message);
                    txtNationalcode.Clear();
                }

                if (RecordCount > 0)
                {

                    cmd.CommandText = "select * from Patients where national_code =@NationalCode and ref_turn = @refturn ";
                    cmd.Parameters.AddWithValue("@NationalCode", txtNationalcode.Text);
                    cmd.Parameters.AddWithValue("@Refturn", RecordCount);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        //آیتم ها لود میشود
                        txtFirstname.Text = reader["First_name"].ToString();
                        txtlastname.Text = reader["Last_name"].ToString();
                        txtBirth_year.Text = reader["Year_Birth_date"].ToString();
                        LblAge.Text = reader["Age"].ToString();
                        cmbeducation.Text = reader["Education"].ToString();
                        cmbpartner.Text = reader["Patient_partner"].ToString();
                        cmbinsurance.Text = reader["Insurance_type"].ToString();
                        txttel.Text = reader["Tel"].ToString();
                        chlbHistories.Items

                        //History disease
/*                        if (reader["History"].ToString() == "True")
                        {
                            chbHistory.Visible = false;
                            chbDM.Visible = true;
                            chbhtn.Visible = true;
                            chbAsthma.Visible = true;
                            chbhd.Visible = true;
                            chbhlp.Visible = true;
                            txtOtherdisease.Visible = true;
                            if (reader["DM"].ToString() == "True")
                            {
                                chbDM.Checked = true;
                            }
                            if (reader["HTN"].ToString() == "True")
                            {
                                chbhtn.Checked = true;
                            }
                            if (reader["Asthma"].ToString() == "True")
                            {
                                chbAsthma.Checked = true;
                            }
                            if (reader["HD"].ToString() == "True")
                            {
                                chbhd.Checked = true;
                            }
                            if (reader["HLP"].ToString() == "True")
                            {
                                chbhlp.Checked = true;
                            }*/

                            txtOtherdisease.Text = reader["OtherDisease"].ToString();
                        }

                        txtlastdesc.Text = reader["visit_description"].ToString();
                        refturn = ++RecordCount;
                    }
                }
                con.Close();
                txtrefturn.Text = refturn.ToString();
                if (refturn == 1)
                {
                    lbllastdesc.Enabled = false;
                    txtlastdesc.Enabled = false;
                }

            }
        }
        private void Btnsave_Click(object sender, EventArgs e)
        {
            if ((check_essensial_field()))  //بررسی پر بودن فیلد های ضروری
            {
                Save_data();
                MessageBox.Show("ثبت مشخصات با موفقیت انجام شد");
                EmptyForm();

                //if (btnsave.Visible)

                //{
                //    Save_data();
                //    MessageBox.Show("ثبت مشخصات با موفقیت انجام شد");
                //    EmptyForm();

                //}
                //else
                //{
                //    Update_Data();
                //    MessageBox.Show("ویرایش مشخصات با موفقیت انجام شد");
                //    EmptyForm();
                //    btnsave.Visible = true;
                //    btnedit.Visible = false;

                //}

            }
            //}
            //else
            //{
            //    Update_Data();
            //    MessageBox.Show("ثبت مشخصات با موفقیت انجام شد");
            //    //update
            //}

        }
        private void Btnedit_Click(object sender, EventArgs e)
        {
            Update_Data();
            MessageBox.Show("ویرایش مشخصات با موفقیت انجام شد");
            EmptyForm();
            btnsave.Visible = true;
            btnedit.Visible = false;
        }
        bool check_essensial_field()
        {
            if (txtNationalcode.Text.Length != 10)
            {
                MessageBox.Show("لطفا کد ملی را به فرمت صحیح وارد نمایید!");
                txtNationalcode.Focus();
                return false;
            }
            if (txtFirstname.Text.Length == 0 || txtlastname.Text.Length == 0 || txtNationalcode.Text.Length == 0 || txtBirth_year.Text.Length == 0)
            {
                if (txtFirstname.Text.Length == 0)
                    txtFirstname.BackColor = System.Drawing.Color.LightPink;
                if (txtlastname.Text.Length == 0)
                    txtlastname.BackColor = System.Drawing.Color.LightPink;
                if (txtNationalcode.Text.Length == 0)
                    txtNationalcode.BackColor = System.Drawing.Color.LightPink;
                if (txtBirth_year.Text.Length == 0)
                    txtBirth_year.BackColor = System.Drawing.Color.LightPink;
                MessageBox.Show("لطفا فیلد‌های مشخص شده را به درستی وارد نمایید.");
                return false;
            }
            return true;
        }
        private void DataEntry_Load(object sender, EventArgs e)
        {

            lblDate.Text = p.GetYear(DateTime.Now).ToString() + "/" + p.GetMonth(DateTime.Now).ToString("0#") + "/" + p.GetDayOfMonth(DateTime.Now).ToString("0#");
            string user_name = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            lblinstructor.Text = user_name.Replace("MUMS\\", "");

            switch (DateTime.Now.DayOfWeek)
            {
                case DayOfWeek.Friday:
                    lblDay.Text = "جمعه";
                    break;
                case DayOfWeek.Saturday:
                    lblDay.Text = "شنبه";
                    break;
                case DayOfWeek.Sunday:
                    lblDay.Text = "یکشنبه";
                    break;
                case DayOfWeek.Monday:
                    lblDay.Text = "دوشنبه";
                    break;
                case DayOfWeek.Tuesday:
                    lblDay.Text = "سه‌شنبه";
                    break;
                case DayOfWeek.Wednesday:
                    lblDay.Text = "چهارشنبه";
                    break;
                case DayOfWeek.Thursday:
                    lblDay.Text = "پنج‌شنبه";
                    break;
            }


            load_default_values();

            //if (N_code != "")
            //if(frmshowdata.SelectedRow is null)
            //{

            //load_default_values();

            //}
            //else
            //{
            //    load_Data_for_edit();
            //    //Update_Data();
            //}
        }

        private void Save_data()
        {
            cmd.Connection = con;
            cmd.Parameters.Clear();
            cmd.CommandText = "INSERT INTO [dbo].[Patients]" +
                "           ([First_name],[Last_name],[national_code],[Year_Birth_date],[Tel],[Age],[Diagnose]" +
                "           ,[History],[DM],[HTN],[Asthma],[HD],[HLP],[Cancer],[OtherDisease]" +
                "		  ,[Doctor],[Insurance_type] ,[Education],[Patient_partner],[Ref_Date],[Ref_type],[Ref_turn],[Train_type]" +
                "           ,[care_before_surgery],[care_after_surgery],[care_disease_type],[care_background_disease]" +
                "           ,[visit_description],[Learn_asses],[Instructor_name])" +
                "     VALUES" +
                "           (@FirstName ,@Last_name,@national_code ,@Year_Birth_date , @Tel,@Age, @Diagnose" +
                                ",@History,@DM,@HTN,@Asthma,@HD,@HLP,@Cancer,@OtherDisease" +
                "          , @Doctor,@Insurance_type,@Education,@Patient_partner,@Ref_Date,@Ref_type,@Ref_turn,@Train_type" +
                                ",@care_before_surgery,@care_after_surgery,@care_disease_type,@care_background_disease" +
                "           ,@visit_description,@Learn_asses,@Instructor_name)";

            cmd.Parameters.AddWithValue("@FirstName", txtFirstname.Text);
            cmd.Parameters.AddWithValue("@Last_name", txtlastname.Text);
            cmd.Parameters.AddWithValue("@national_code", txtNationalcode.Text);
            cmd.Parameters.AddWithValue("@Year_Birth_date", txtBirth_year.Text);
            cmd.Parameters.AddWithValue("@Tel", txttel.Text);
            cmd.Parameters.AddWithValue("@Age", int.Parse(LblAge.Text));
            cmd.Parameters.AddWithValue("@Diagnose", cmbdiagnose.Text);
            
            //History
            cmd.Parameters.AddWithValue("@History", chbHistory.Checked);
            cmd.Parameters.AddWithValue("@DM", chbDM.Checked);
            cmd.Parameters.AddWithValue("@HTN", chbhtn.Checked);
            cmd.Parameters.AddWithValue("@Asthma", chbAsthma.Checked);
            cmd.Parameters.AddWithValue("@HD", chbhd.Checked);
            cmd.Parameters.AddWithValue("@HLP", chbhlp.Checked);
            cmd.Parameters.AddWithValue("@Cancer", chbCancer.Checked);
            cmd.Parameters.AddWithValue("@OtherDisease", txtOtherdisease.Text);

            cmd.Parameters.AddWithValue("@Doctor", cmbDoctor.Text);

            cmd.Parameters.AddWithValue("@Insurance_type", cmbinsurance.Text);////باید کد ثبت بشه
            cmd.Parameters.AddWithValue("@Education", cmbeducation.Text);   ////باید کد ثبت بشه
            //cmbeducation.SelectedValue
            cmd.Parameters.AddWithValue("@Patient_partner", cmbpartner.Text);////باید کد ثبت بشه

            cmd.Parameters.AddWithValue("@Ref_Date", bprefdate.Text);
            cmd.Parameters.AddWithValue("@Ref_type", cmbreftype.Text);
            cmd.Parameters.AddWithValue("@Ref_turn", refturn);
            cmd.Parameters.AddWithValue("@Train_type", cmblearntype.Text);
            //Train title
            cmd.Parameters.AddWithValue("@care_before_surgery", chbBefor.Checked);
            cmd.Parameters.AddWithValue("@care_after_surgery", chbafter.Checked);
            cmd.Parameters.AddWithValue("@care_disease_type", chbdisease.Checked);
            cmd.Parameters.AddWithValue("@care_background_disease", chbbackdisease.Checked);

            cmd.Parameters.AddWithValue("@visit_description", txtrefDesc.Text);
            cmd.Parameters.AddWithValue("@Learn_asses", cmblearnasses.Text);

            cmd.Parameters.AddWithValue("@Instructor_name", lblinstructor.Text);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        void load_Data_for_edit()
        {
            //آیتم ها لود میشود
            txtNationalcode.Text = frmshowdata.SelectedRow.Cells["national_code"].Value.ToString();
            txtFirstname.Text = frmshowdata.SelectedRow.Cells["First_name"].Value.ToString();
            txtlastname.Text = frmshowdata.SelectedRow.Cells["Last_name"].Value.ToString();
            txtBirth_year.Text = frmshowdata.SelectedRow.Cells["Year_Birth_date"].Value.ToString();
            //LblAge.Text = frmshowdata.SelectedRow.Cells["Age"].Value.ToString();  
            cmbeducation.Text = frmshowdata.SelectedRow.Cells["Education"].Value.ToString();
            cmbpartner.Text = frmshowdata.SelectedRow.Cells["Patient_partner"].Value.ToString();
            cmbinsurance.Text = frmshowdata.SelectedRow.Cells["Insurance_type"].Value.ToString();
            txttel.Text = frmshowdata.SelectedRow.Cells["Tel"].Value.ToString();
            if (frmshowdata.SelectedRow.Cells["History"].Value.ToString() == "True")
            {
                chbHistory.Visible = false;
                chbDM.Visible = true;
                chbhtn.Visible = true;
                chbAsthma.Visible = true;
                chbhd.Visible = true;
                chbhlp.Visible = true;
                txtOtherdisease.Visible = true;
                if (frmshowdata.SelectedRow.Cells["DM"].Value.ToString() == "True")
                {
                    chbDM.Checked = true;
                }
                if (frmshowdata.SelectedRow.Cells["HTN"].Value.ToString() == "True")
                {
                    chbhtn.Checked = true;
                }
                if (frmshowdata.SelectedRow.Cells["Asthma"].Value.ToString() == "True")
                {
                    chbAsthma.Checked = true;
                }
                if (frmshowdata.SelectedRow.Cells["HD"].Value.ToString() == "True")
                {
                    chbhd.Checked = true;
                }
                if (frmshowdata.SelectedRow.Cells["HLP"].Value.ToString() == "True")
                {
                    chbhlp.Checked = true;
                }

                txtOtherdisease.Text = frmshowdata.SelectedRow.Cells["OtherDisease"].Value.ToString();
            }
            bprefdate.Value = Convert.ToDateTime(frmshowdata.SelectedRow.Cells["Ref_Date"].Value);
            cmbreftype.Text = frmshowdata.SelectedRow.Cells["Ref_type"].Value.ToString();
            txtrefDesc.Text = frmshowdata.SelectedRow.Cells["visit_description"].Value.ToString();
            txtrefturn.Text = frmshowdata.SelectedRow.Cells["Ref_turn"].Value.ToString();
            if (frmshowdata.SelectedRow.Cells["Doctor"].Value.ToString() != "")
            {
                chbdoctor.Checked = true;
                cmbDoctor.Text = frmshowdata.SelectedRow.Cells["Doctor"].Value.ToString();
            }
            cmbdiagnose.Text = frmshowdata.SelectedRow.Cells["Diagnose"].Value.ToString();
            cmblearntype.Text = frmshowdata.SelectedRow.Cells["Train_type"].Value.ToString();
            cmblearnasses.Text = frmshowdata.SelectedRow.Cells["Learn_asses"].Value.ToString();
            if (frmshowdata.SelectedRow.Cells["care_before_surgery"].Value.ToString() == "True")
            {
                chbBefor.Checked = true;
            }
            if (frmshowdata.SelectedRow.Cells["care_after_surgery"].Value.ToString() == "True")
            {
                chbafter.Checked = true;
            }
            if (frmshowdata.SelectedRow.Cells["care_disease_type"].Value.ToString() == "True")
            {
                chbdisease.Checked = true;
            }
            if (frmshowdata.SelectedRow.Cells["care_background_disease"].Value.ToString() == "True")
            {
                chbbackdisease.Checked = true;
            }
        }
        void Update_Data()
        {
            cmd.Connection = con;
            cmd.Parameters.Clear();
            cmd.CommandText = "UPDATE [dbo].[Patients]							" +
                            "   SET [First_name] = @First_name					" +
                            "      ,[Last_name] = @Last_name					" +
                            "      ,[national_code] = @national_code			" +
                            "      ,[Year_Birth_date] = @Year_Birth_date					" +
                            "      ,[Tel] = @Tel								" +
                            "      ,[Age] = @Age								" +
                            "      ,[Diagnose] = @Diagnose						" +
                            "      ,[DM] = @DM									" +
                            "      ,[HTN] = @HTN								" +
                            "      ,[Asthma] = @Asthma							" +
                            "      ,[HD] = @HD									" +
                            "      ,[HLP] = @HLP								" +
                            "      ,[Cancer] = @Cancer							" +
                            "      ,[OtherDisease] = @OtherDisease				" +
                            "      ,[Doctor] = @Doctor							" +
                            "      ,[Insurance_type] = @Insurance_type			" +
                            "      ,[Education] = @Education					" +
                            "      ,[Patient_partner] = @Patient_partner		" +
                            "      ,[Ref_Date] = @Ref_Date						" +
                            "      ,[Ref_type] = @Ref_type						" +
                            "      ,[Ref_turn] = @Ref_turn						" +
                            "      ,[Train_type] = @Train_type					" +
                            "      ,[care_before_surgery] = @care_before_surgery" +
                            "      ,[care_after_surgery] = @care_after_surgery	" +
                            "      ,[care_disease_type] = @care_disease_type	" +
                            "      ,[care_background_disease] = @care_background_disease " +
                            "      ,[visit_description] = @visit_description " +
                            "      ,[Learn_asses] = @Learn_asses				" +
                            "      ,[Instructor_name] = @Instructor_name		" +
                             " WHERE national_code=@last_national_code and ref_turn = @Ref_turn				";

            cmd.Parameters.AddWithValue("@last_national_code", last_national_code);

            cmd.Parameters.AddWithValue("@First_name", txtFirstname.Text);
            cmd.Parameters.AddWithValue("@Last_name", txtlastname.Text);
            cmd.Parameters.AddWithValue("@national_code", txtNationalcode.Text);
            cmd.Parameters.AddWithValue("@Year_Birth_date", txtBirth_year.Text);
            cmd.Parameters.AddWithValue("@Tel", txttel.Text);
            cmd.Parameters.AddWithValue("@Age", int.Parse(LblAge.Text));

            cmd.Parameters.AddWithValue("@Diagnose", cmbdiagnose.Text);
            //History
            cmd.Parameters.AddWithValue("@DM", chbDM.Checked);
            cmd.Parameters.AddWithValue("@HTN", chbhtn.Checked);
            cmd.Parameters.AddWithValue("@Asthma", chbAsthma.Checked);
            cmd.Parameters.AddWithValue("@HD", chbhd.Checked);
            cmd.Parameters.AddWithValue("@HLP", chbhlp.Checked);
            cmd.Parameters.AddWithValue("@Cancer", chbCancer.Checked);
            cmd.Parameters.AddWithValue("@OtherDisease", txtOtherdisease.Text);

            cmd.Parameters.AddWithValue("@Doctor", cmbDoctor.Text);
            cmd.Parameters.AddWithValue("@Insurance_type", cmbinsurance.Text);
            cmd.Parameters.AddWithValue("@Education", cmbeducation.Text);
            cmd.Parameters.AddWithValue("@Patient_partner", cmbpartner.Text);

            cmd.Parameters.AddWithValue("@Ref_Date", bprefdate.Text);
            cmd.Parameters.AddWithValue("@Ref_type", cmbreftype.Text);
            cmd.Parameters.AddWithValue("@Ref_turn", txtrefturn.Text);
            cmd.Parameters.AddWithValue("@Train_type", bprefdate.Text);
            //Train title
            cmd.Parameters.AddWithValue("@care_before_surgery", chbBefor.Checked);
            cmd.Parameters.AddWithValue("@care_after_surgery", chbafter.Checked);
            cmd.Parameters.AddWithValue("@care_disease_type", chbdisease.Checked);
            cmd.Parameters.AddWithValue("@care_background_disease", chbbackdisease.Checked);
            cmd.Parameters.AddWithValue("@visit_description", txtrefDesc.Text);
            cmd.Parameters.AddWithValue("@Learn_asses", cmblearnasses.Text);
            cmd.Parameters.AddWithValue("@Instructor_name", lblinstructor.Text);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }


        void EmptyForm()
        {
            txtNationalcode.Text = string.Empty;
            txtFirstname.Text = string.Empty;
            txtlastname.Text = string.Empty;
            txttel.Text = string.Empty;
            txtBirth_year.Text = string.Empty;
            LblAge.Text = string.Empty;
            cmbpartner.Text = string.Empty;
            chbDM.Checked = false;
            chbhtn.Checked = false;
            chbAsthma.Checked = false;
            chbhd.Checked = false;
            chbhlp.Checked = false;
            txtOtherdisease.Text = string.Empty;
            txtlastdesc.Text = string.Empty;
            txtrefDesc.Text = string.Empty;
            chbBefor.Checked = true;
            chbafter.Checked = false;
            chbdisease.Checked = false;
            chbbackdisease.Checked = false;
            load_default_values();

        }
        void load_default_values()
        {
            bprefdate.Value = Convert.ToDateTime(lblDate.Text);
            cmbinsurance.SelectedIndex = 0;
            cmbreftype.SelectedIndex = 0;
            cmblearntype.SelectedIndex = 0;
            cmblearnasses.SelectedIndex = 2;
            cmbpartner.SelectedIndex = 0;
            chbBefor.Checked = true;
            chbdoctor.Checked = false;
            //History Ithems 

            chbAsthma.Visible = false;
            chbCancer.Visible = false;
            chbDM.Visible = false;
            chbhd.Visible = false;
            chbhlp.Visible = false;
            chbhtn.Visible = false;
            txtOtherdisease.Visible = false;

            chbHistory.Checked = false;
            chbHistory.Visible = true;

            //Diagnose combobox
            string query = "select ID,abbreviation from MI_Diagnose";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            con.Open();
            DataSet ds = new DataSet();
            da.Fill(ds, "Diagnose");
            cmbdiagnose.DisplayMember = "abbreviation";
            cmbdiagnose.ValueMember = "ID";
            cmbdiagnose.DataSource = ds.Tables["Diagnose"];
            cmbdiagnose.SelectedIndex = 0;

            //Education combobox
            query = "select code,title from MI_Education";
            da = new SqlDataAdapter(query, con);
            ds = new DataSet();
            da.Fill(ds, "Education");
            cmbeducation.DisplayMember = "title";
            cmbeducation.ValueMember = "code";
            cmbeducation.DataSource = ds.Tables["Education"];
            cmbeducation.SelectedIndex = 0;

            //patient_partner combobox
            query = "select code,title from MI_Education";
            da = new SqlDataAdapter(query, con);
            ds = new DataSet();
            da.Fill(ds, "Education");
            cmbpartner.DisplayMember = "title";
            cmbpartner.ValueMember = "code";
            cmbpartner.DataSource = ds.Tables["Education"];
            cmbpartner.SelectedIndex = 0;


            //History button
            query = "select Code + ' ' +name as History from MI_HistoryDisease";
            da = new SqlDataAdapter(query, con);
            ds = new DataSet();
            DataTable dt = new DataTable();
            da.Fill(ds, "History");
            dt = ds.Tables[0];
            //btnHistories = ds.Tables["History"];
            List<string> Hist = new List<string>();
            foreach (DataRow dr in dt.Rows)  // dt is a DataTable
            {
                chlbHistories.Items.Add(dr["History"].ToString());
            }
            //string[] myFruit = { "Apples", "Oranges", "Tomato" };
            //chlbHistories.Items.AddRange(Hist);
            // Changes the selection mode from double-click to single click.
            chlbHistories.CheckOnClick = true;
            con.Close();

        }

        private void TxtNationalcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            txtNationalcode.MaxLength = 10; // this will allow the user to enter only 10 digits

        }

        private void TxtNationalcode_Validating(object sender, CancelEventArgs e)
        {
            // اطلاعات از پایگاه داده گرفته شود در صورت وجود
            Display_data();
        }

        private void Txttel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }


        private void ChbHistory_CheckedChanging(object sender, DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs e)
        {
            if (chbHistory.Checked == false)
            {
                chbHistory.Visible = false;

                chbAsthma.Visible = true;
                chbCancer.Visible = true;
                chbDM.Visible = true;
                chbhd.Visible = true;
                chbhlp.Visible = true;
                chbhtn.Visible = true;
                txtOtherdisease.Visible = true;
            }
        }

        private void Chbdoctor_CheckedChanged(object sender, EventArgs e)
        {
            if (cmbDoctor.Enabled == false)
            {
                //Doctors Combobox
                cmbDoctor.Enabled = true;
                string query = "select ID,abbreviation from MI_Diagnose";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                con.Open();
                DataSet ds = new DataSet();
                query = "SELECT [First_name]+' '+[Last_name] as name  FROM [dbo].[MI_Doctors]";
                da = new SqlDataAdapter(query, con);
                da.Fill(ds, "Doctors");
                cmbDoctor.DisplayMember = "name";
                //cmbDoctor.ValueMember = "last_name";
                cmbDoctor.DataSource = ds.Tables["Doctors"];
                con.Close();

            }
            else
            {
                cmbDoctor.Enabled = false;
                cmbDoctor.DataSource = null;
            }
        }

        private void TxtFirstname_Enter(object sender, EventArgs e)
        {

            txtFirstname.BackColor = System.Drawing.Color.White;
        }

        private void Txtlastname_Enter(object sender, EventArgs e)
        {

            txtlastname.BackColor = System.Drawing.Color.White;
        }

        private void TxtBirth_year_Enter(object sender, EventArgs e)
        {

            txtBirth_year.BackColor = System.Drawing.Color.White;
        }

        private void TxtBirth_year_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            txtNationalcode.MaxLength = 4;
        }

        private void TxtBirth_year_Leave_1(object sender, EventArgs e)
        {
            if (txtBirth_year.Text.Length != 4)
            {
                MessageBox.Show("لطفا سال تولد را به فرمت صحیح وارد نمایید!");
                txtBirth_year.Focus();
                return;
            }
            int age = p.GetYear(DateTime.Now) - int.Parse(txtBirth_year.Text);
            /*((TimeSpan)(Convert.ToDateTime(bprefdate.Value) - Convert.ToDateTime(bpCal.Value))).Days/365*/
            LblAge.Text = age.ToString();
        }

        private void Btnshowdata_Click(object sender, EventArgs e)
        {
            // Create a new instance of the Form2 class
            frmshowdata ShowForm = new frmshowdata();

            //this.Hide();
            this.Hide(); //Hides the parent form.
            ShowForm.ShowDialog(); //Shows the sub form.
                                   //ShowForm.Close();

            if (!(frmshowdata.SelectedRow is null))
            {
                last_national_code = frmshowdata.SelectedRow.Cells["national_code"].Value.ToString();
                load_Data_for_edit();
                btnsave.Visible = false;
                btnedit.Visible = true;
            }
            else
                EmptyForm();
            this.Show();

            //new frmshowdata().Show();
        }

        private void Btnrefresh_Click(object sender, EventArgs e)
        {
            EmptyForm();
        }

        private void BtnAddDiagnose_Click(object sender, EventArgs e)
        {
            new frm_Diagnoses().Show();

        }


    }
}
