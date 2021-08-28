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
using System.Text.RegularExpressions;
using System.Globalization;

namespace Patient_clinic
{
    public partial class DataEntry : Form
    {
        PersianCalendar p = new PersianCalendar();
        int refturn = 1;
        SqlConnection con = Program.CreateConnection();//new SqlConnection("Data Source =(local) ; initial catalog = Health_clinic ; integrated security=true");
        SqlCommand cmd = new SqlCommand();
        string last_national_code = "";
        //string User_ID;
        //public int  Patient_ID = 0;
        string Patient_ID_code = "HC-00-00-00";

        //-----------------Define Function---------------//
        #region Define Function
        void EmptyForm()
        {
            txtNationalcode.Text = string.Empty;
            txtPatientCode.Text = string.Empty;
            txtFirstname.Text = string.Empty;
            txtlastname.Text = string.Empty;
            txtfathername.Text = string.Empty;
            txttel.Text = string.Empty;
            txtBirth_year.Text = string.Empty;
            LblAge.Text = string.Empty;
            cmbpartner.Text = string.Empty;
            chbDM.Checked = false;
            chbhtn.Checked = false;
            chbAsthma.Checked = false;
            chbhd.Checked = false;
            chbhlp.Checked = false;
            chbmother.Checked = false;
            txtOtherdisease.Text = string.Empty;
            txtlastdesc.Text = string.Empty;
            txtrefDesc.Text = string.Empty;
            chbBefor.Checked = true;
            chbafter.Checked = false;
            chbdisease.Checked = false;
            chbbackdisease.Checked = false;
            rbhnationalcode.Checked = true;
            //txtrefturn.Text = "1";
            refturn = 1; //Reload

            //History Ithems 
            chbHistory.Checked = false;
            chbHistory.Visible = true;
            chbAsthma.Visible = false;
            chbCancer.Visible = false;
            chbDM.Visible = false;
            chbhd.Visible = false;
            chbhlp.Visible = false;
            chbhtn.Visible = false;
            chbmother.Visible = false;
            txtOtherdisease.Visible = false;



            load_default_values();
            New_Patient_ID_Retrieve();
            this.ActiveControl = txtNationalcode;

        }

        void Display_data()
        {
            int RecordCount = 0;
            con.Open();
            if (txtNationalcode.Text != "")
            {
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
                    cmd.Parameters.Clear();
                    cmd.CommandText = "select * from Patients where national_code =@NationalCode and ref_turn = @refturn ";
                    cmd.Parameters.AddWithValue("@NationalCode", txtNationalcode.Text);
                    cmd.Parameters.AddWithValue("@Refturn", RecordCount);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Program.Patient_ID = int.Parse(reader["Patient_ID"].ToString());
                        //آیتم ها لود میشود
                        //Patient_ID = reader["Patient_ID"];
                        txtFirstname.Text = reader["First_name"].ToString();
                        txtlastname.Text = reader["Last_name"].ToString();
                        txtfathername.Text = reader["Father_name"].ToString();
                        txtBirth_year.Text = reader["Year_Birth_date"].ToString();
                        LblAge.Text = reader["Age"].ToString();
                        cmbeducation.SelectedValue = reader["Education"].ToString();
                        cmbpartner.Text = reader["Patient_partner"].ToString();
                        cmbinsurance.SelectedValue = reader["Insurer"].ToString();
                        cmbInsuranceType.SelectedValue = reader["Insurance_type"].ToString();
                        txttel.Text = reader["Tel"].ToString();
                        //if (reader["History"].ToString() == "True")
                        //{
                        //    chbHistory.Checked = true;
                        //    chbHistory.Visible = false;
                        //    chbDM.Visible = true;
                        //    chbhtn.Visible = true;
                        //    chbAsthma.Visible = true;
                        //    chbhd.Visible = true;
                        //    chbhlp.Visible = true;
                        //    chbCancer.Visible = true;
                        //    chbmother.Visible = true;
                        //    txtOtherdisease.Visible = true;

                        //    Patient_ID = int.Parse(reader["Patient_ID"].ToString());
                        //    cmd.CommandText = "select code " +
                        //                        "from[Patient_History] PH,MI_HistoryDisease HD" +
                        //                        "where HD.ID = PH.History_ID and PH.Patient_ID = @Patient_ID and PH.ref_turn = @refturn ";
                        //    cmd.Parameters.AddWithValue("@Patient_ID", Patient_ID);
                        //    reader = cmd.ExecuteReader();
                        //    while (reader.Read())
                        //    {
                        //        switch (reader["code"].ToString())
                        //        {
                        //            case "DM":
                        //                chbDM.Checked = true;
                        //                break;
                        //            case "HTN":
                        //                chbhtn.Checked = true;
                        //                break;
                        //            case "Asthma":
                        //                chbhtn.Checked = true;
                        //                break;
                        //            case "IHD":
                        //                chbhtn.Checked = true;
                        //                break;
                        //            case "HLP":
                        //                chbhtn.Checked = true;
                        //                break;
                        //            case "Cancer":
                        //                chbhtn.Checked = true;
                        //                break;
                        //            case "Mother":
                        //                chbhtn.Checked = true;
                        //                break;
                        //        }
                        //    }
                        //    txtOtherdisease.Text = reader["OtherDisease"].ToString();
                        //}

                        txtlastdesc.Text = reader["visit_description"].ToString();
                        refturn = ++RecordCount;
                    }
                }
            }
            else if (Program.Patient_ID != 0)//txtPatientCode.Text != ""
            {
                cmd.Connection = con;
                try
                {
                    cmd.CommandText = "select count(Patient_ID) from Patients where Patient_ID =" + Program.Patient_ID;
                    RecordCount = Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch (Exception e)
                {
                    MessageBox.Show("مشکلی  پیش آمده است٬مجددا کد بیمار را وارد نمایید\n" + e.Message);
                    txtNationalcode.Clear();
                }

                if (RecordCount > 0)

                {
                    cmd.CommandText = "select * from Patients where Patient_ID  =@Patient_ID and ref_turn = @Refturn ";
                    cmd.Parameters.AddWithValue("@Patient_ID", Program.Patient_ID);
                    cmd.Parameters.AddWithValue("@Refturn", RecordCount);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        //Program.Patient_ID = int.Parse(reader["Patient_ID"].ToString());
                        //آیتم ها لود میشود
                        //Patient_ID = reader["Patient_ID"];
                        txtNationalcode.Text = reader["National_code"].ToString();
                        txtFirstname.Text = reader["First_name"].ToString();
                        txtlastname.Text = reader["Last_name"].ToString();
                        txtfathername.Text = reader["Father_name"].ToString();
                        txtBirth_year.Text = reader["Year_Birth_date"].ToString();
                        LblAge.Text = reader["Age"].ToString();
                        cmbeducation.SelectedValue = reader["Education"].ToString();
                        cmbpartner.Text = reader["Patient_partner"].ToString();
                        cmbinsurance.SelectedValue = reader["Insurer"].ToString();
                        cmbInsuranceType.SelectedValue = reader["Insurance_type"].ToString();
                        txttel.Text = reader["Tel"].ToString();
                        //if (reader["History"].ToString() == "True")
                        //{
                        //    chbHistory.Checked = true;
                        //    chbHistory.Visible = false;
                        //    chbDM.Visible = true;
                        //    chbhtn.Visible = true;
                        //    chbAsthma.Visible = true;
                        //    chbhd.Visible = true;
                        //    chbhlp.Visible = true;
                        //    chbCancer.Visible = true;
                        //    chbmother.Visible = true;
                        //    txtOtherdisease.Visible = true;

                        //    Patient_ID = int.Parse(reader["Patient_ID"].ToString());
                        //    cmd.CommandText = "select code " +
                        //                        "from[Patient_History] PH,MI_HistoryDisease HD" +
                        //                        "where HD.ID = PH.History_ID and PH.Patient_ID = @Patient_ID and PH.ref_turn = @refturn ";
                        //    cmd.Parameters.AddWithValue("@Patient_ID", Patient_ID);
                        //    while (reader.Read())
                        //    {
                        //        switch (reader["code"].ToString())
                        //        {
                        //            case "DM":
                        //                chbDM.Checked = true;
                        //                break;
                        //            case "HTN":
                        //                chbhtn.Checked = true;
                        //                break;
                        //            case "Asthma":
                        //                chbhtn.Checked = true;
                        //                break;
                        //            case "IHD":
                        //                chbhtn.Checked = true;
                        //                break;
                        //            case "HLP":
                        //                chbhtn.Checked = true;
                        //                break;
                        //            case "Cancer":
                        //                chbhtn.Checked = true;
                        //                break;
                        //            case "Mother":
                        //                chbhtn.Checked = true;
                        //                break;
                        //        }
                        //    }
                        //    txtOtherdisease.Text = reader["OtherDisease"].ToString();
                        //}

                        txtlastdesc.Text = reader["visit_description"].ToString();
                        refturn = ++RecordCount;
                    }
                }

            }

            con.Close();

            if (Program.Patient_ID == 0) //بیمار جدید کد بیمار مقداری نگرفته است
            {
                New_Patient_ID_Retrieve();
            }

            txtrefturn.Text = refturn.ToString();
            if (refturn == 1)
            {
                lbllastdesc.Enabled = false;
                txtlastdesc.Enabled = false;
            }
            //int lnth = Convert.ToInt32(Math.Ceiling(Math.Log10(Program.Patient_ID)));
            //txtPatientCode.Text = Patient_ID_code.Substring(0, Patient_ID_code.Length - lnth) + Program.Patient_ID.ToString();

            //create 6 digit code plus HC Code at first of them
            string temp_Code = Program.Patient_ID.ToString();
            temp_Code = temp_Code.PadLeft(6, '0');
            Patient_ID_code = "HC-" + Regex.Replace(temp_Code, ".{2}(?!$)", "$0-");
            txtPatientCode.Text = Patient_ID_code;


        }
        bool check_essensial_field()
        {
            if ((rbhnationalcode.Checked) && !(Main_Functions.check_code(txtNationalcode.Text)))
            {
                txtNationalcode.Focus();
                return false;
            }
            if (txtFirstname.Text.Length == 0 || txtlastname.Text.Length == 0 || txtBirth_year.Text.Length == 0)
            {
                if (txtFirstname.Text.Length == 0)
                    txtFirstname.BackColor = System.Drawing.Color.LightPink;
                if (txtlastname.Text.Length == 0)
                    txtlastname.BackColor = System.Drawing.Color.LightPink;
                //if (txtNationalcode.Text.Length == 0)
                //    txtNationalcode.BackColor = System.Drawing.Color.LightPink;
                if (txtBirth_year.Text.Length == 0)
                    txtBirth_year.BackColor = System.Drawing.Color.LightPink;
                MessageBox.Show("لطفا فیلد‌های مشخص شده را به درستی وارد نمایید.");
                return false;
            }
            return true;
        }


        void load_Data_for_edit()
        {
            //آیتم ها لود میشود
            Program.Patient_ID = int.Parse(frmshowdata.SelectedRow.Cells["Patient_ID"].Value.ToString());
            refturn = int.Parse(frmshowdata.SelectedRow.Cells["ref_turn"].Value.ToString());
            txtNationalcode.Text = frmshowdata.SelectedRow.Cells["national_code"].Value.ToString();
            txtPatientCode.Text = frmshowdata.SelectedRow.Cells["Patient_ID_Code"].Value.ToString();
            txtPatientCode.Enabled = false;
            txtFirstname.Text = frmshowdata.SelectedRow.Cells["First_name"].Value.ToString();
            txtlastname.Text = frmshowdata.SelectedRow.Cells["Last_name"].Value.ToString();
            txtfathername.Text = frmshowdata.SelectedRow.Cells["Father_name"].Value.ToString();
            txtBirth_year.Text = frmshowdata.SelectedRow.Cells["Year_Birth_date"].Value.ToString();
            LblAge.Text = frmshowdata.SelectedRow.Cells["Age"].Value.ToString();
            cmbeducation.SelectedValue = frmshowdata.SelectedRow.Cells["Education"].Value;
            cmbpartner.Text = frmshowdata.SelectedRow.Cells["Patient_partner"].Value.ToString();
            cmbinsurance.SelectedValue = frmshowdata.SelectedRow.Cells["insurer"].Value;

            load_Insurance_types(); //load Combobox of insurance type 

            cmbInsuranceType.SelectedValue = frmshowdata.SelectedRow.Cells["Insurance_type"].Value;
            txttel.Text = frmshowdata.SelectedRow.Cells["Tel"].Value.ToString();
            if (frmshowdata.SelectedRow.Cells["History"].Value.ToString() == "True")
            {
                chbHistory.Checked = true;
                chbHistory.Visible = false;
                chbDM.Visible = true;
                chbhtn.Visible = true;
                chbAsthma.Visible = true;
                chbhd.Visible = true;
                chbhlp.Visible = true;
                chbmother.Visible = true;
                txtOtherdisease.Visible = true;
                con.Open();
                cmd.Connection = con;
                cmd.Parameters.Clear();
                cmd.CommandText = "select History_ID " +
                                    "from[Patient_History] PH,MI_HistoryDisease HD " +
                                    "where HD.ID = PH.History_ID and PH.Patient_ID = @Patient_ID and PH.ref_turn = @refturn ";
                cmd.Parameters.AddWithValue("@Patient_ID", Program.Patient_ID);
                cmd.Parameters.AddWithValue("@refturn", refturn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    switch (Convert.ToInt32(reader["History_ID"]))//reader["code"].ToString()
                    {
                        case 1://"DM"
                            chbDM.Checked = true;
                            break;
                        case 2:// "HTN":
                            chbhtn.Checked = true;
                            break;
                        case 3:// "Asthma":
                            chbAsthma.Checked = true;
                            break;
                        case 4:// "IHD":
                            chbhd.Checked = true;
                            break;
                        case 5:// "HLP":
                            chbhlp.Checked = true;
                            break;
                        case 6:// "Cancer":
                            chbCancer.Checked = true;
                            break;
                        case 7:// "Mother":
                            chbmother.Checked = true;
                            break;
                    }

                }
                con.Close();
                txtOtherdisease.Text = frmshowdata.SelectedRow.Cells["OtherDisease"].Value.ToString();
            }
            bPCaltxtbox.Text = frmshowdata.SelectedRow.Cells["Ref_Date"].Value.ToString();
            //bprefdate.Value = Convert.ToDateTime(frmshowdata.SelectedRow.Cells["Ref_Date"].Value);
            cmbreftype.Text = frmshowdata.SelectedRow.Cells["Ref_type"].Value.ToString();
            txtrefDesc.Text = frmshowdata.SelectedRow.Cells["visit_description"].Value.ToString();
            txtrefturn.Text = frmshowdata.SelectedRow.Cells["Ref_turn"].Value.ToString();
            //cmbDoctor.SelectedValue = frmshowdata.SelectedRow.Cells["Doctor"].Value.ToString();
            if (frmshowdata.SelectedRow.Cells["Doctor"].Value.ToString() != "")
            {
                chbdoctor.Checked = true;
                cmbDoctor.SelectedValue = frmshowdata.SelectedRow.Cells["Doctor"].Value;
            }
            cmbdiagnose.SelectedValue = frmshowdata.SelectedRow.Cells["Diagnose"].Value.ToString();
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

        void load_default_values()
        {

           // bprefdate.Value = ParsePersianDate(lblDate.Text);
            //bprefdate.Value = Convert.ToDateTime(lblDate.Text);
            bPCaltxtbox.Today_Click(null, null);
            bPCaltxtbox.ReadOnly = false;
            //DateTime MyDateTime = DateTime.ParseExact(lblDate.Text, "yyyy/MM/dd", "fa-IR");
            //bprefdate.Value = MyDateTime;

            cmbreftype.SelectedIndex = 0;
            cmblearntype.SelectedIndex = 0;
            cmblearnasses.SelectedIndex = 2;
            cmbpartner.SelectedIndex = 0;
            chbBefor.Checked = true;
            //chbdoctor.Checked = false;

            con.Open();
            //Diagnose combobox
            string query = "select ID,abbreviation from MI_Diagnose order by _order";
            SqlDataAdapter da = new SqlDataAdapter(query, con);

            DataSet ds = new DataSet();
            da.Fill(ds, "Diagnose");
            cmbdiagnose.DisplayMember = "abbreviation";
            cmbdiagnose.ValueMember = "ID";
            cmbdiagnose.DataSource = ds.Tables["Diagnose"];
            cmbdiagnose.SelectedIndex = 0;


            //Education combobox
            query = "SELECT [Title],[code] FROM [Health_clinic].[dbo].[MI_Education]";
            da = new SqlDataAdapter(query, con);
            ds = new DataSet();
            da.Fill(ds, "Education");
            cmbeducation.DisplayMember = "Title";
            cmbeducation.ValueMember = "code";
            cmbeducation.DataSource = ds.Tables["Education"];
            cmbeducation.SelectedIndex = 0;

            // Insurance

            query = "select Name,Insurer_code from MI_insurers where Contract_end >'" + lblDate.Text + "'";
            da = new SqlDataAdapter(query, con);
            ds = new DataSet();
            da.Fill(ds, "Insurers");
            cmbinsurance.DisplayMember = "Name";
            cmbinsurance.ValueMember = "Insurer_code";
            cmbinsurance.DataSource = ds.Tables["Insurers"];
            cmbinsurance.SelectedIndex = 0;


            con.Close();

            ////Insurance Type
            //load_Insurance_types();


            //History button
            //query = "select ID,Code ,name from MI_HistoryDisease";
            //da = new SqlDataAdapter(query, con);
            //ds = new DataSet();
            //DataTable dt = new DataTable();
            //da.Fill(ds, "History");
            //dt = ds.Tables[0];

            //dgvHistories.DataSource = ds;
            //dgvHistories.DataMember = "History";
            //dgvHistories.DisplayedColumnCount = 2;


            //LVHistories.Columns.Add("ID", 300);
            //LVHistories.Columns.Add("Name", 300);

            //btnHistories = ds.Tables["History"];
            //List<string> Hist = new List<string>();
            //foreach (DataRow dr in dt.Rows)  // dt is a DataTable
            //{

            //    LVHistories.Items.Add(dr["History_name"].ToString());

            //    chlbHistories.Items.Add(dr["History_name"].ToString());
            //}
            //string[] myFruit = { "Apples", "Oranges", "Tomato" };
            //chlbHistories.Items.AddRange(Hist);
            // Changes the selection mode from double-click to single click.
            //chlbHistories.CheckOnClick = true;


        }
        private void Save_data()
        {
            cmd.Connection = con;
            cmd.Parameters.Clear();
            cmd.CommandText = "INSERT INTO [dbo].[Patients]" +
                "           ([Patient_ID],[Patient_ID_Code],[First_name],[Last_name],[national_code],[Father_name],[Year_Birth_date],[Tel],[Age],[Diagnose]" +
                "           ,[History],[OtherDisease]" +//[DM],[HTN],[Asthma],[HD],[HLP],[Cancer],
                "		  ,[Doctor],[Insurer],[Insurance_type] ,[Education],[Patient_partner],[Ref_Date],[Ref_type],[Ref_turn],[Train_type]" +
                "           ,[care_before_surgery],[care_after_surgery],[care_disease_type],[care_background_disease]" +
                "           ,[visit_description],[Learn_asses],[Instructor_name])" +
                "     VALUES" +
                "           (@Patient_ID,@Patient_ID_Code,@FirstName ,@Last_name,@national_code ,@father_name,@Year_Birth_date , @Tel,@Age, @Diagnose" +
                                ",@History,@OtherDisease" +//@DM,@HTN,@Asthma,@HD,@HLP,@Cancer,
                "          , @Doctor,@Insurer,@Insurance_type,@Education,@Patient_partner,@Ref_Date,@Ref_type,@Ref_turn,@Train_type" +
                                ",@care_before_surgery,@care_after_surgery,@care_disease_type,@care_background_disease" +
                "           ,@visit_description,@Learn_asses,@Instructor_name)";

            cmd.Parameters.AddWithValue("@Patient_ID", Program.Patient_ID);
            cmd.Parameters.AddWithValue("@Patient_ID_Code", txtPatientCode.Text);
            cmd.Parameters.AddWithValue("@FirstName", txtFirstname.Text);
            cmd.Parameters.AddWithValue("@Last_name", txtlastname.Text);
            cmd.Parameters.AddWithValue("@national_code", txtNationalcode.Text);
            cmd.Parameters.AddWithValue("@father_name", txtfathername.Text);
            cmd.Parameters.AddWithValue("@Year_Birth_date", txtBirth_year.Text);
            cmd.Parameters.AddWithValue("@Tel", txttel.Text);
            cmd.Parameters.AddWithValue("@Age", int.Parse(LblAge.Text));
            cmd.Parameters.AddWithValue("@Diagnose", cmbdiagnose.SelectedValue);
            cmd.Parameters.AddWithValue("@History", chbHistory.Checked);
            cmd.Parameters.AddWithValue("@OtherDisease", txtOtherdisease.Text);
            if (chbdoctor.Checked == true)
                cmd.Parameters.AddWithValue("@Doctor", cmbDoctor.SelectedValue);
            else
                cmd.Parameters.AddWithValue("@Doctor", "");

            cmd.Parameters.AddWithValue("@Insurer", cmbinsurance.SelectedValue);
            cmd.Parameters.AddWithValue("@Insurance_type", cmbInsuranceType.SelectedValue);
            cmd.Parameters.AddWithValue("@Education", cmbeducation.SelectedValue);
            cmd.Parameters.AddWithValue("@Patient_partner", cmbpartner.Text);

            cmd.Parameters.AddWithValue("@Ref_Date", bPCaltxtbox.Text);//bprefdate
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


            //History
            if (chbHistory.Checked)
            {
                //cmd.Parameters.AddWithValue("@Patient_id", Patient_ID);
                if (chbDM.Checked)
                {
                    cmd.CommandText = " IF not EXISTS (SELECT * FROM Patient_History where Patient_ID = " + Program.Patient_ID + " and ref_turn = " + refturn + " and History_ID=1)" +
                        "INSERT INTO [dbo].[Patient_History]([Patient_ID],[ref_turn],[History_ID])     VALUES     (" + Program.Patient_ID + "," + refturn + ",1)";  //کد مربوط به DM
                    //cmd.Parameters.AddWithValue("@Patient_id", Patient_ID);
                    cmd.ExecuteNonQuery();
                }
                if (chbhtn.Checked)
                {
                    cmd.CommandText = " IF not EXISTS (SELECT * FROM Patient_History where Patient_ID = " + Program.Patient_ID + " and ref_turn = " + refturn + " and History_ID=2)" +
                        "INSERT INTO [dbo].[Patient_History]([Patient_ID],[ref_turn],[History_ID])      VALUES     (" + Program.Patient_ID + "," + refturn + ",2) ";  //کد مربوط به HTN
                    //cmd.Parameters.AddWithValue("@Patient_id", Patient_ID);
                    cmd.ExecuteNonQuery();
                }
                if (chbAsthma.Checked)
                {
                    cmd.CommandText = " IF not EXISTS (SELECT * FROM Patient_History where Patient_ID = " + Program.Patient_ID + " and ref_turn = " + refturn + " and History_ID=3)" +
                        "INSERT INTO [dbo].[Patient_History]([Patient_ID],[ref_turn],[History_ID])     VALUES     (" + Program.Patient_ID + "," + refturn + ",3)";  //کد مربوط به Asthma
                    //cmd.Parameters.AddWithValue("@Patient_id", Patient_ID);
                    cmd.ExecuteNonQuery();
                }
                if (chbhd.Checked)
                {
                    cmd.CommandText = " IF not EXISTS (SELECT * FROM Patient_History where Patient_ID = " + Program.Patient_ID + " and ref_turn = " + refturn + " and History_ID=4)" +
                        "INSERT INTO [dbo].[Patient_History]([Patient_ID],[ref_turn],[History_ID])      VALUES     (" + Program.Patient_ID + "," + refturn + ",4)";  //کد مربوط به HD
                    //cmd.Parameters.AddWithValue("@Patient_id", Patient_ID);
                    cmd.ExecuteNonQuery();
                }
                if (chbhlp.Checked)
                {
                    cmd.CommandText = " IF not EXISTS (SELECT * FROM Patient_History where Patient_ID = " + Program.Patient_ID + " and ref_turn = " + refturn + " and History_ID=5)" +
                        "INSERT INTO [dbo].[Patient_History]([Patient_ID],[ref_turn],[History_ID])       VALUES     (" + Program.Patient_ID + "," + refturn + ",5)";  //کد مربوط به HLP
                    //cmd.Parameters.AddWithValue("@Patient_id", Patient_ID);
                    cmd.ExecuteNonQuery();
                }
                if (chbCancer.Checked)
                {
                    cmd.CommandText = " IF not EXISTS (SELECT * FROM Patient_History where Patient_ID = " + Program.Patient_ID + " and ref_turn = " + refturn + " and History_ID=6)" +
                        "INSERT INTO [dbo].[Patient_History]([Patient_ID],[ref_turn],[History_ID])      VALUES     (" + Program.Patient_ID + "," + refturn + ",6)";  //کد مربوط به Cancer
                    //cmd.Parameters.AddWithValue("@Patient_id", Patient_ID);
                    cmd.ExecuteNonQuery();
                }
                if (chbmother.Checked)
                {
                    cmd.CommandText = " IF not EXISTS (SELECT * FROM Patient_History where Patient_ID = " + Program.Patient_ID + " and ref_turn = " + refturn + " and History_ID=7)" +
                        "INSERT INTO [dbo].[Patient_History]([Patient_ID],[ref_turn],[History_ID])      VALUES     (" + Program.Patient_ID + "," + refturn + ",7)";  //کد مربوط به Mother
                    cmd.ExecuteNonQuery();
                }
                //cmd.Parameters.AddWithValue("@HTN", chbhtn.Checked);
                //cmd.Parameters.AddWithValue("@Asthma", chbAsthma.Checked);
                //cmd.Parameters.AddWithValue("@HD", chbhd.Checked);
                //cmd.Parameters.AddWithValue("@HLP", chbhlp.Checked);
                //cmd.Parameters.AddWithValue("@Cancer", chbCancer.Checked);
                //cmd.Parameters.AddWithValue("@Mother", chbmother.Checked);

            }
            //بروزرسانی آخرین آیدی 
            cmd.CommandText = "UPDATE [dbo].[Last_Patient_ID]  SET [Last_ID] =" + Program.Patient_ID + " WHERE Last_ID < " + Program.Patient_ID;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        bool Update_Data()
        {
            cmd.Connection = con;
            cmd.Parameters.Clear();
            cmd.CommandText = "UPDATE [dbo].[Patients]							" +
                            "   SET [First_name] = @First_name					" +
                            "      ,[Last_name] = @Last_name					" +
                            "      ,[national_code] = @national_code			" +
                            "      ,[Father_name] = @Father_name			" +
                            "      ,[Year_Birth_date] = @Year_Birth_date					" +
                            "      ,[Tel] = @Tel								" +
                            "      ,[Age] = @Age								" +
                            "      ,[Diagnose] = @Diagnose						" +

                            "      ,[History] = @History						" +
                            //"      ,[DM] = @DM									" +
                            //"      ,[HTN] = @HTN								" +
                            //"      ,[Asthma] = @Asthma							" +
                            //"      ,[HD] = @HD									" +
                            //"      ,[HLP] = @HLP								" +
                            //"      ,[Cancer] = @Cancer							" +
                            "      ,[OtherDisease] = @OtherDisease				" +
                            "      ,[Doctor] = @Doctor							" +
                            "      ,[Insurer] = @Insurer                        " +
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
                             " WHERE Patient_ID=@Patient_ID and ref_turn = @Ref_turn	";

            cmd.Parameters.AddWithValue("@Patient_ID", Program.Patient_ID);

            cmd.Parameters.AddWithValue("@First_name", txtFirstname.Text);
            cmd.Parameters.AddWithValue("@Last_name", txtlastname.Text);
            cmd.Parameters.AddWithValue("@national_code", txtNationalcode.Text);
            cmd.Parameters.AddWithValue("@Father_name", txtfathername.Text);
            cmd.Parameters.AddWithValue("@Year_Birth_date", txtBirth_year.Text);
            cmd.Parameters.AddWithValue("@Tel", txttel.Text);
            cmd.Parameters.AddWithValue("@Age", int.Parse(LblAge.Text));

            cmd.Parameters.AddWithValue("@Diagnose", cmbdiagnose.SelectedValue);
            //History
            cmd.Parameters.AddWithValue("@History", chbHistory.Checked);
            //cmd.Parameters.AddWithValue("@DM", chbDM.Checked);
            //cmd.Parameters.AddWithValue("@HTN", chbhtn.Checked);
            //cmd.Parameters.AddWithValue("@Asthma", chbAsthma.Checked);
            //cmd.Parameters.AddWithValue("@HD", chbhd.Checked);
            //cmd.Parameters.AddWithValue("@HLP", chbhlp.Checked);
            //cmd.Parameters.AddWithValue("@Cancer", chbCancer.Checked);
            //cmd.Parameters.AddWithValue("@Mother", chbmother.Checked);
            cmd.Parameters.AddWithValue("@OtherDisease", txtOtherdisease.Text);
            if (chbdoctor.Checked == true)
                cmd.Parameters.AddWithValue("@Doctor", cmbDoctor.SelectedValue);
            else
                cmd.Parameters.AddWithValue("@Doctor", "");

            cmd.Parameters.AddWithValue("@Insurer", cmbinsurance.SelectedValue);
            cmd.Parameters.AddWithValue("@Insurance_type", cmbInsuranceType.SelectedValue);
            cmd.Parameters.AddWithValue("@Education", cmbeducation.SelectedValue);
            cmd.Parameters.AddWithValue("@Patient_partner", cmbpartner.Text);

            cmd.Parameters.AddWithValue("@Ref_Date", bPCaltxtbox.Text);//bprefdate
            cmd.Parameters.AddWithValue("@Ref_type", cmbreftype.Text);
            cmd.Parameters.AddWithValue("@Ref_turn", txtrefturn.Text);
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
            if (cmd.ExecuteNonQuery() == 0)
            {
                MessageBox.Show("ویرایش انجام نشد!");
                con.Close();
                return false;
            }
            /*
            //History
            اگر هرکدام از بیماری های زمینه ای تیک آن برداشته شده باشد٬
            باید اطلاعات آن بیماری زمینه ای برای نوبت ارجاع مورد نظر حذف گردد از جدول بیماری های زمینه ای بیماران
            */
            if (chbHistory.Checked)
            {
                cmd.CommandText = "";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Patient_ID", Program.Patient_ID);
                cmd.Parameters.AddWithValue("@ref_turn", refturn);
                if (chbDM.Checked)
                {
                    cmd.CommandText = " IF not EXISTS (SELECT * FROM Patient_History where Patient_ID = @patient_ID and ref_turn = @ref_turn and History_ID=1)" +
                        "INSERT INTO [dbo].[Patient_History]([Patient_ID],[ref_turn],[History_ID])       VALUES     (@patient_ID,@ref_turn,1)";  //کد مربوط به DM
                    //cmd.Parameters.AddWithValue("@Patient_id", Patient_ID);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    cmd.CommandText = " IF EXISTS (SELECT * FROM Patient_History where Patient_ID = @patient_ID and ref_turn = @ref_turn and History_ID=1)" +
                        "DELETE FROM [dbo].[Patient_History]    WHERE Patient_ID =  @patient_ID and ref_turn =  @ref_turn and History_ID=1";  //کد مربوط به DM
                    cmd.ExecuteNonQuery();
                }
                if (chbhtn.Checked)
                {
                    cmd.CommandText = " IF not EXISTS (SELECT * FROM Patient_History where Patient_ID = @patient_ID and ref_turn =  @ref_turn and History_ID=2)" +
                        "INSERT INTO [dbo].[Patient_History]([Patient_ID],[ref_turn],[History_ID])       VALUES     (@patient_ID, @ref_turn,2) ";  //کد مربوط به HTN
                    //cmd.Parameters.AddWithValue("@Patient_id", Patient_ID);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    cmd.CommandText = " IF EXISTS (SELECT * FROM Patient_History where Patient_ID = @patient_ID and ref_turn = @ref_turn and History_ID=2)" +
                        "DELETE FROM [dbo].[Patient_History]    WHERE Patient_ID =  @patient_ID and ref_turn =  @ref_turn and History_ID=2";  //کد مربوط به HTN
                    cmd.ExecuteNonQuery();
                }
                if (chbAsthma.Checked)
                {
                    cmd.CommandText = " IF not EXISTS (SELECT * FROM Patient_History where Patient_ID = @patient_ID and ref_turn =  @ref_turn and History_ID=3)" +
                        "INSERT INTO [dbo].[Patient_History]([Patient_ID],[ref_turn],[History_ID])       VALUES     (@patient_ID, @ref_turn,3)";  //کد مربوط به Asthma
                    //cmd.Parameters.AddWithValue("@Patient_id", Patient_ID);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    cmd.CommandText = " IF EXISTS (SELECT * FROM Patient_History where Patient_ID = @patient_ID and ref_turn = @ref_turn and History_ID=3)" +
                        "DELETE FROM [dbo].[Patient_History]    WHERE Patient_ID =  @patient_ID and ref_turn =  @ref_turn and History_ID=3";  //کد مربوط به Asthma
                    cmd.ExecuteNonQuery();
                }
                if (chbhd.Checked)
                {
                    cmd.CommandText = " IF not EXISTS (SELECT * FROM Patient_History where Patient_ID = @patient_ID and ref_turn =  @ref_turn and History_ID=4)" +
                        "INSERT INTO [dbo].[Patient_History]([Patient_ID],[ref_turn],[History_ID])       VALUES     (@patient_ID, @ref_turn,4)";  //کد مربوط به HD
                    //cmd.Parameters.AddWithValue("@Patient_id", Patient_ID);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    cmd.CommandText = " IF EXISTS (SELECT * FROM Patient_History where Patient_ID = @patient_ID and ref_turn = @ref_turn and History_ID=4)" +
                        "DELETE FROM [dbo].[Patient_History]    WHERE Patient_ID =  @patient_ID and ref_turn =  @ref_turn and History_ID=4";  //کد مربوط به HD
                    cmd.ExecuteNonQuery();
                }
                if (chbhlp.Checked)
                {
                    cmd.CommandText = " IF not EXISTS (SELECT * FROM Patient_History where Patient_ID = @patient_ID and ref_turn =  @ref_turn and History_ID=5)" +
                        "INSERT INTO [dbo].[Patient_History]([Patient_ID],[ref_turn],[History_ID])       VALUES     (@patient_ID, @ref_turn,5)";  //کد مربوط به HLP
                    //cmd.Parameters.AddWithValue("@Patient_id", Patient_ID);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    cmd.CommandText = " IF EXISTS (SELECT * FROM Patient_History where Patient_ID = @patient_ID and ref_turn = @ref_turn and History_ID=5)" +
                        "DELETE FROM [dbo].[Patient_History]    WHERE Patient_ID =  @patient_ID and ref_turn =  @ref_turn and History_ID=5";  //کد مربوط به HLP
                    cmd.ExecuteNonQuery();
                }
                if (chbCancer.Checked)
                {
                    cmd.CommandText = " IF not EXISTS (SELECT * FROM Patient_History where Patient_ID = @patient_ID and ref_turn =  @ref_turn and History_ID=6)" +
                        "INSERT INTO [dbo].[Patient_History]([Patient_ID],[ref_turn],[History_ID])       VALUES     (@patient_ID, @ref_turn,6)";  //کد مربوط به Cancer
                    //cmd.Parameters.AddWithValue("@Patient_id", Patient_ID);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    cmd.CommandText = " IF EXISTS (SELECT * FROM Patient_History where Patient_ID = @patient_ID and ref_turn = @ref_turn and History_ID=6)" +
                        "DELETE FROM [dbo].[Patient_History]    WHERE Patient_ID =  @patient_ID and ref_turn =  @ref_turn and History_ID=6";  //کد مربوط به Cancer
                    cmd.ExecuteNonQuery();
                }
                if (chbmother.Checked)
                {
                    cmd.CommandText = " IF not EXISTS (SELECT * FROM Patient_History where Patient_ID = @patient_ID and ref_turn =  @ref_turn and History_ID=7)" +
                        "INSERT INTO [dbo].[Patient_History]([Patient_ID],[ref_turn],[History_ID])       VALUES     (@patient_ID, @ref_turn,7)";  //کد مربوط به Mother
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    cmd.CommandText = " IF EXISTS (SELECT * FROM Patient_History where Patient_ID = @patient_ID and ref_turn = @ref_turn and History_ID=7)" +
                        "DELETE FROM [dbo].[Patient_History]    WHERE Patient_ID =  @patient_ID and ref_turn =  @ref_turn and History_ID=7";  //کد مربوط به Mother
                    cmd.ExecuteNonQuery();
                }

            }
            con.Close();
            return true;

        }


        private void New_Patient_ID_Retrieve()
        {
            con.Open();
            cmd.Connection = con;
            cmd.Parameters.Clear();
            cmd.CommandText = "SELECT Last_ID from Last_Patient_ID";
            Program.Patient_ID = Convert.ToInt32(cmd.ExecuteScalar());
            Program.Patient_ID++;
            con.Close();
        }

        void load_Insurance_types()
        {
            int connection_flag = 0;  //اگر کانکشن برقرار بود توی این تابع باز و بسته نشه
            if (con.State == ConnectionState.Open)
                connection_flag = 1;
            else
                con.Open();

            string query = "SELECT IT.[Type_Code],[Description]" +
                              "FROM[MI_InsuranceTypes] IT ,[MI_InsuranceMethods] IM " +
                              "Where IT.Type_Code = IM.Type_Code and IM.Insurer_Code = " + cmbinsurance.SelectedValue.ToString();
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "Insurance_type");
            cmbInsuranceType.DisplayMember = "Description";
            cmbInsuranceType.ValueMember = "Type_Code";
            cmbInsuranceType.DataSource = ds.Tables["Insurance_type"];
            if (cmbInsuranceType.Items.Count == 0)
                MessageBox.Show("برای بیمه مورد نظر نوع بیمه موجود نیست");
            else
                cmbInsuranceType.SelectedIndex = 0;
            if (connection_flag == 0)
                con.Close();
        }

        


        #endregion
        //----------------------------//
        #region Load Form
        public DataEntry()
        {
            InitializeComponent();
        }
        private void DataEntry_Load(object sender, EventArgs e)
        {

            lblDate.Text = Main_Functions.Get_Today_Shamsi();
            lblinstructor.Text = Program.Read_User_Name();

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
            if (!(frmshowdata.SelectedRow is null))
            {
                last_national_code = frmshowdata.SelectedRow.Cells["national_code"].Value.ToString();
                load_Data_for_edit();
                btnsave.Visible = false;
                btnedit.Visible = true;
            }
            this.ActiveControl = txtNationalcode;
            // مدیریتی
            //یوزر مدیریتی قابلیت اضافه کردن حذف یا ویرایش تشخیص ها را داشته باشد
            if (Program.User_ID == "behbahanis1")   //باید با نوع یوزر باشه!!!
                btnAddDiagnose.Visible = true;


        }

        #endregion 



        private void txtNationalcode_Leave(object sender, EventArgs e)
        {
            txtNationalcode.BackColor = System.Drawing.Color.White;
            // اطلاعات از پایگاه داده گرفته شود در صورت وجود
            if (frmshowdata.SelectedRow is null)
                Display_data();
        }

        private void Btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
            //new frmshowdata().Show();

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
            if (Update_Data())
            {
                MessageBox.Show("ویرایش مشخصات با موفقیت انجام شد");
                EmptyForm();
                btnsave.Visible = true;
                btnedit.Visible = false;
            }
            else
                MessageBox.Show("مجددا تلاش نمایید");
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
            //if (chbHistory.Checked == false)
            //{
            chbHistory.Visible = false;
            chbAsthma.Visible = true;
            chbCancer.Visible = true;
            chbDM.Visible = true;
            chbhd.Visible = true;
            chbhlp.Visible = true;
            chbhtn.Visible = true;
            chbmother.Visible = true;
            txtOtherdisease.Visible = true;
            //}
        }

        private void Chbdoctor_CheckedChanged(object sender, EventArgs e)
        {
            if (chbdoctor.Checked == true)//&& cmbDoctor.Enabled == true
            {
                //Doctors Combobox
                cmbDoctor.Enabled = true;
                cmbDoctor.DisplayMember = "name";
                cmbDoctor.ValueMember = "Staff_ID";
                cmbDoctor.DataSource = Main_Functions.GetDoctor_List();

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
            txtBirth_year.MaxLength = 4;
        }

        private void TxtBirth_year_Leave_1(object sender, EventArgs e)
        {
            if (txtBirth_year.Text.Length != 4)
            {
                MessageBox.Show("لطفا سال تولد را به فرمت صحیح وارد نمایید!");
                txtBirth_year.Focus();
                return;
            }
            try
            {
                int age = p.GetYear(DateTime.Now) - int.Parse(txtBirth_year.Text);
                /*((TimeSpan)(Convert.ToDateTime(bprefdate.Value) - Convert.ToDateTime(bpCal.Value))).Days/365*/
                LblAge.Text = age.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("لطفا اعداد را با قراردادن صفحه کلید در حالت زبان انگلیسی وارد نمایید");
                txtBirth_year.Focus();
                return;
            }

        }

        private void Btnshowdata_Click(object sender, EventArgs e)
        {
            // Create a new instance of the Form2 class
            frmshowdata ShowForm = new frmshowdata();

            //this.Hide();//Hides the parent form.
            EmptyForm();
            ShowForm.ShowDialog(); //Shows the sub form.
                                   //ShowForm.Close();
                                   //this.Hide();
            if (!(frmshowdata.SelectedRow is null))
            {
                //last_national_code = frmshowdata.SelectedRow.Cells["national_code"].Value.ToString();
                load_default_values(); //داده های کمبو باکس ها پر شود
                load_Data_for_edit();
                btnsave.Visible = false;
                btnedit.Visible = true;
            }
            else if (Program.Patient_ID != 0)
            {
                Display_data();
            }
            //else
            //    EmptyForm();

            //this.Show();
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

        private void Rbhnationalcode_CheckedChanged(object sender, EventArgs e)
        {
            if (rbhnationalcode.Checked)
            {
                txtNationalcode.Enabled = true;
                txtPatientCode.Enabled = false;
            }
        }

        private void Rbnotnationalcode_CheckedChanged(object sender, EventArgs e)
        {
            if (rbnotnationalcode.Checked)
            {
                txtNationalcode.Enabled = false;
                //txtPatientCode.Enabled = true;
            }
        }

        private void Cmbinsurance_Leave(object sender, EventArgs e)
        {
            // load_Insurance_types();
        }


        private void CmbDoctor_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cmbDoctor.SelectedIndex = cmbDoctor.FindString(cmbDoctor.Text);
        }

        private void CmbDoctor_TextChanged(object sender, EventArgs e)
        {
            //cmbDoctor.SelectedIndex = cmbDoctor.FindString(cmbDoctor.Text);
        }

        private void Cmbreftype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbreftype.SelectedIndex == 0)  //cmbreftype.SelectedIndex != 0
            {
                cmbDoctor.Enabled = true;
                chbdoctor.Enabled = true;
                chbdoctor.Checked = true;

            }
            else

            {
                chbdoctor.Enabled = false;
                cmbDoctor.Enabled = false;
                chbdoctor.Checked = false;

            }
        }

        private void BtnAbout_Click(object sender, EventArgs e)
        {


        }

        private void Cmbinsurance_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!(cmbinsurance.SelectedValue is null))
            {
                load_Insurance_types();
            }
        }
    }
}
