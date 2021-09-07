using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Patient_clinic.health_education_indicators
{
    public partial class frmQuestions : Form
    {
        SqlConnection con = Program.CreateConnection();//new SqlConnection("Data Source =. ;initial catalog =Health_clinic ; integrated security=true"); //Program.CreateConnection();
        SqlCommand cmd = new SqlCommand();
        //PersianCalendar p = new PersianCalendar();
        string Form_Name = "";
        int Form_ID = 0;
        string Section = "";
        int Section_ID = 0;
        int Patient_ID = 0;
        int Nurse_ID = 0;
        int Point = 0;
        public frmQuestions(string Form_Name_, int Form_ID_, string Section_, int Section_ID_)
        {
            InitializeComponent();
            Form_Name = Form_Name_;
            Form_ID = Form_ID_;
            Section = Section_;
            Section_ID = Section_ID_;
        }

        private void FrmQuestions_Load(object sender, EventArgs e)
        {
            lblFrm_name.Text = Form_Name;
            lbl_Section.Text = Section;
            bpDate.Today_Click(null, null);
            bpDate.ReadOnly = false;
            lblClinicName.Text = Program.Clinic_Name;
            Display_HeaderForm(Form_ID);
            Display_Question(Form_ID);
            //radGVQuestions.SplitMode = Telerik.WinControls.UI.RadGridViewSplitMode.Vertical;
 


        }

        int Calculate_Point()
        {
            Point = 0;
            for (int i = 0; i < radGVQuestions.RowCount; i++)
            {
                if (Main_Functions.GetSafeString(radGVQuestions.Rows[i].Cells["Answers"].Value) == string.Empty)
                {
                    MessageBox.Show("لطفا همه ی سوالات را پاسخ دهید\n سوال شماره "+ (i+1).ToString(), "نقص اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 0;
                }
                Point += Convert.ToInt32(radGVQuestions.Rows[i].Cells["Answers"].Value);
            }
            return Point;
        }

        private void Display_HeaderForm(int Qtype)
        {
            switch (Qtype)
            {
                //case 20:
                //    {
                //        GPHeaderForm20.Visible = true;
                //        GPHeaderForm21.Visible = false;
                //        GPHeaderForm23.Visible = false;
                //        load_Combo_values();
                //        break;
                //    }
                case 21:
                    {
                        GPHeaderForm20.Visible = false;
                        GPHeaderForm21.Visible = true;
                        GPHeaderForm23.Visible = false;
                        load_Combo_values(Qtype);
                        chbNational_Code.Checked = false;
                        break;
                    }
                case 23:
                    {
                        GPHeaderForm20.Visible = false;
                        GPHeaderForm21.Visible = false;
                        GPHeaderForm23.Visible = true;
                        load_Combo_values(Qtype);
                        chbNational_Code.Checked = false;
                        break;
                    }
                default:
                    {
                        GPHeaderForm20.Visible = true;
                        GPHeaderForm21.Visible = false;
                        GPHeaderForm23.Visible = false;
                        load_Combo_values();
                        //GPQuestions.Location = new Point(GPQuestions.Location.X, 80);
                        //GPQuestions.Size = new Size(GPQuestions.Size.Width, 523);
                        break;
                    }
            }
        }
        void load_Combo_values(int form_ID = 0)
        {
            con.Open();
            SqlDataAdapter da;
            string query = "";
            DataSet ds = new DataSet();
            switch (form_ID)
            {

                case 21:
                    {
                        //Education combobox
                        query = "SELECT [Title],[code] FROM [Health_clinic].[dbo].[MI_Education]";
                        da = new SqlDataAdapter(query, con);
                        da.Fill(ds, "Education");
                        cmbNurseEducation.DisplayMember = "Title";
                        cmbNurseEducation.ValueMember = "code";
                        cmbNurseEducation.DataSource = ds.Tables["Education"];
                        cmbNurseEducation.SelectedIndex = 2;
                        break;
                    }
                case 23:
                    {
                        //Education combobox
                        query = "SELECT [Title],[code] FROM [Health_clinic].[dbo].[MI_Education]";
                        da = new SqlDataAdapter(query, con);
                        da.Fill(ds, "Education");
                        cmbPatientEducation.DisplayMember = "Title";
                        cmbPatientEducation.ValueMember = "code";
                        cmbPatientEducation.DataSource = ds.Tables["Education"];
                        cmbPatientEducation.SelectedIndex = 0;
                        break;
                    }
                default:
                    {

                        //Diagnose combobox
                        query = "select ID,abbreviation from MI_Diagnose order by _order";
                        da = new SqlDataAdapter(query, con);
                        da.Fill(ds, "Diagnose");
                        cmbdiagnose.DisplayMember = "abbreviation";
                        cmbdiagnose.ValueMember = "ID";
                        cmbdiagnose.DataSource = ds.Tables["Diagnose"];
                        cmbdiagnose.SelectedIndex = 0;

                        break;
                    }
            }
            con.Close();
        }

        private void Display_Question(int Qtype)
        {
            //MessageBox.Show(Form_ID.ToString() + Section);
            SqlDataAdapter adp = new SqlDataAdapter();
            con.Open();
            DataTable dt = new DataTable();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "SELECT ROW_NUMBER() OVER(ORDER BY ID ASC) Row_num,ID,Text FROM MI_Questions WHERE TYPE IN(" + Qtype + ")";
            con.Close();
            adp.Fill(dt);
            radGVQuestions.DataSource = dt;
            radGVQuestions.Columns["ID"].IsVisible = false;
            dt.Columns.Add(new DataColumn("Answers", typeof(int)));
            //dt.Columns.Add(new DataColumn("Description", typeof(string)));
            //Convert_column_name(radGVQuestions);


            radGVQuestions.TableElement.RowHeight = 30;

            radGVQuestions.Columns["Row_num"].HeaderText = "ردیف";
            radGVQuestions.Columns["Row_num"].Width = 35;
            radGVQuestions.Columns["Row_num"].TextAlignment = ContentAlignment.MiddleCenter;
            radGVQuestions.Columns["Row_num"].ReadOnly = true;
            radGVQuestions.Columns["Text"].HeaderText = "سوال";
            radGVQuestions.Columns["Text"].Width = 745;
            radGVQuestions.Columns["Text"].WrapText = true;
            radGVQuestions.Columns["Text"].ReadOnly = true;

            this.radGVQuestions.MasterTemplate.BeginUpdate();

            this.radGVQuestions.Columns.RemoveAt(3);

            RadioButtonColumn column = new RadioButtonColumn("Answers");
            column.HeaderText = "پاسخ";
            column.Width = 170;
            column.ReadOnly = true;
            this.radGVQuestions.Columns.Add(column);

            dt.Columns.Add(new DataColumn("Description", typeof(string)));
            radGVQuestions.Columns["Description"].HeaderText = "توضیحات";
            radGVQuestions.Columns["Description"].Width = 120;
            radGVQuestions.Columns["Description"].WrapText = true;
            radGVQuestions.Columns["Description"].ReadOnly = false;

            this.radGVQuestions.MasterTemplate.EndUpdate();


        }

        /*  private void Display_Question_Dynamically()
      {
          //this.groupPanel1.
          TextBox[] textBoxes = new TextBox[n];
          Label[] labels = new Label[n];

          for (int i = 0; i < n; i++)
          {
              textBoxes[i] = new TextBox();
              // Here you can modify the value of the textbox which is at textBoxes[i]

              labels[i] = new Label();
              // Here you can modify the value of the label which is at labels[i]
          }
          int H = 0;
          // This adds the controls to the form (you will need to specify thier co-ordinates etc. first)
          for (int i = 0; i < n; i++)
          {
              tableLayoutPanel1.Controls.Add(textBoxes[i]);
              textBoxes[i].Location = new Point(100, 50 * i + 10); //180 + (i * 10);
              tableLayoutPanel1.Controls.Add(labels[i]);
              labels[i].Location = new Point(150, 50 * i + 10);
              H = 50 * i;
          }
          this.Height = H + 100;
          this.HScroll = true;
      }*/

        private void Btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool check_Essensial_field()
        {
            if ((chbNational_Code.Checked) && !(Main_Functions.check_code(txtNationalcode.Text)))
            {
                txtNationalcode.Focus();
                return false;
            }
            if (txtArchiveNumber.Text.Length == 0 || txtRefTurn.Text.Length == 0)
            {
                if (txtArchiveNumber.Text.Length == 0)
                    txtArchiveNumber.BackColor = System.Drawing.Color.LightPink;
                if (txtRefTurn.Text.Length == 0)
                    txtRefTurn.BackColor = System.Drawing.Color.LightPink;
                MessageBox.Show("لطفا فیلد‌های مشخص شده را به درستی وارد نمایید.");
                return false;
            }
            return true;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (check_Essensial_field() && Calculate_Point() > 0)  //اطلاعات وارد شده است
            {
                btnCalculate.Text = Point.ToString();
                btnCalculate.Font = new Font(btnCalculate.Font.FontFamily, 12); ;

                if (Save_data())
                {
                    MessageBox.Show("ثبت اطلاعات با موفقیت انجام شد");
                    this.Close();
                }
                else
                    MessageBox.Show("ثبت اطلاعات با مشکل مواجه شد , مجددا سعی کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        bool Save_data()
        {
            int _ID_OF_Form_Point = 0;
            bool new_patient = false;
            cmd.Connection = con;
            try
            {
                con.Open();
                //****check the patient exist in table or not
                cmd.Parameters.Clear();
                cmd.CommandText = "select * from [EI_Patient_Data] where [Archive_number] = @Archive_number AND [ref_turn] = @ref_turn";
                cmd.Parameters.AddWithValue("@Archive_number", txtArchiveNumber.Text);
                cmd.Parameters.AddWithValue("@ref_turn", txtRefTurn.Text);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read()) Patient_ID = int.Parse(reader["Patient_ID"].ToString());
                else
                    Patient_ID = 0;

                con.Close();
                //******
                if (Patient_ID == 0)
                {
                    Patient_ID = Patient_ID_Retrieve();
                    new_patient = true;
                }
                con.Open();
                //Patient Data
                if (Form_ID == 23)
                {
                    if (new_patient)
                    {
                        cmd.Parameters.Clear();
                        cmd.CommandText = "INSERT INTO [dbo].[EI_Patient_Data] ([Patient_ID],[Archive_number],[ref_turn]," +
                                          "    [Gender],[Education],[Job],[Marital_status]) " +
                                          " VALUES(@Patient_ID, @Archive_number, @ref_turn,  " +
                                          "      @Gender, @Education, @Job, @Marital_status)";

                        cmd.Parameters.AddWithValue("@Patient_ID", Patient_ID);
                        cmd.Parameters.AddWithValue("@Archive_number", Convert.ToInt32(txtArchiveNumber.Text));
                        cmd.Parameters.AddWithValue("@ref_turn", Convert.ToInt32(txtRefTurn.Text));
                        //cmd.Parameters.AddWithValue("@First_name", txtFirst_Name.Text);
                        //cmd.Parameters.AddWithValue("@Last_name", txtLast_name.Text);
                        //cmd.Parameters.AddWithValue("@national_code", txtNationalcode.Text);
                        cmd.Parameters.AddWithValue("@Gender", RdbNurseFemale.IsChecked);
                        //cmd.Parameters.AddWithValue("@Tel", txttel.Text);
                        cmd.Parameters.AddWithValue("@Education", cmbPatientEducation.Text);
                        cmd.Parameters.AddWithValue("@Job", txtPatientJob.Text);
                        cmd.Parameters.AddWithValue("@Marital_status", RdbMarried.IsChecked);
                        //cmd.Parameters.AddWithValue("@Addmition_Cause", cmbdiagnose.SelectedValue);
                        //cmd.Parameters.AddWithValue("@Admition_History", radchkPatientHistory.Checked);
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        cmd.Parameters.Clear();
                        cmd.CommandText = "UPDATE [dbo].[EI_Patient_Data] " +
                                          " SET [Gender] = @Gender,[Education] = @Education,[Job] = @Job,[Marital_status] = @Marital_status" +
                                          " WHERE[Patient_ID] = @Patient_ID";

                        cmd.Parameters.AddWithValue("@Patient_ID", Patient_ID);
                        cmd.Parameters.AddWithValue("@Gender", RdbNurseFemale.IsChecked);
                        cmd.Parameters.AddWithValue("@Education", cmbPatientEducation.Text);
                        cmd.Parameters.AddWithValue("@Job", txtPatientJob.Text);
                        cmd.Parameters.AddWithValue("@Marital_status", RdbMarried.IsChecked);
                        cmd.ExecuteNonQuery();

                    }

                }
                else if (Form_ID == 21) //ثبت اطلاعات پرستار
                {
                    //Patient_Data
                    if (new_patient)
                    {
                        cmd.Parameters.Clear();
                        cmd.CommandText = "INSERT INTO [dbo].[EI_Patient_Data] ([Patient_ID],[Archive_number],[ref_turn])" +
                                          " VALUES(@Patient_ID, @Archive_number, @ref_turn)  ";

                        cmd.Parameters.AddWithValue("@Patient_ID", Patient_ID);
                        cmd.Parameters.AddWithValue("@Archive_number", Convert.ToInt32(txtArchiveNumber.Text));
                        cmd.Parameters.AddWithValue("@ref_turn", Convert.ToInt32(txtRefTurn.Text));
                        cmd.ExecuteNonQuery();
                    }
                    //nurse table
                    cmd.Parameters.Clear();
                    cmd.CommandText = "INSERT INTO [dbo].[EI_Nurse] ([Gender],[Experience],[Emp_type],[Education]) " +
                                                " VALUES(@Gender, @Experience, @Emp_type, @Education)";

                    cmd.Parameters.AddWithValue("@Gender", RdbNurseFemale.IsChecked);
                    cmd.Parameters.AddWithValue("@Experience", txtNurseExperience.Text);
                    cmd.Parameters.AddWithValue("@Emp_type", txtNurseEMPType.Text);
                    cmd.Parameters.AddWithValue("@Education", cmbNurseEducation.Text);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.CommandText = "SELECT MAX(ID) FROM EI_Nurse";
                    Nurse_ID = Convert.ToInt32(cmd.ExecuteScalar());


                }
                else
                {
                    if (new_patient)
                    {
                        cmd.Parameters.Clear();
                        cmd.CommandText = "INSERT INTO [dbo].[EI_Patient_Data] ([Patient_ID],[Archive_number],[ref_turn],[First_name],[Last_name] " +
                                          "    ,[national_code],[Tel],[Addmition_Cause],[Admition_History]) " +
                                          " VALUES(@Patient_ID, @Archive_number, @ref_turn, @First_name, @Last_name, " +
                                          "       @national_code, @Tel, @Addmition_Cause, @Admition_History)";

                        cmd.Parameters.AddWithValue("@Patient_ID", Patient_ID);
                        cmd.Parameters.AddWithValue("@Archive_number", Convert.ToInt32(txtArchiveNumber.Text));
                        cmd.Parameters.AddWithValue("@ref_turn", Convert.ToInt32(txtRefTurn.Text));
                        cmd.Parameters.AddWithValue("@First_name", txtFirst_Name.Text);
                        cmd.Parameters.AddWithValue("@Last_name", txtLast_name.Text);
                        cmd.Parameters.AddWithValue("@national_code", txtNationalcode.Text);
                        //cmd.Parameters.AddWithValue("@Gender", RdbNurseFemale.IsChecked);
                        cmd.Parameters.AddWithValue("@Tel", txttel.Text);
                        //cmd.Parameters.AddWithValue("@Education", cmbPatientEducation.Text);
                        //cmd.Parameters.AddWithValue("@Job", txtPatientJob.Text);
                        //cmd.Parameters.AddWithValue("@Marital_status", RdbMarried.IsChecked);
                        cmd.Parameters.AddWithValue("@Addmition_Cause", cmbdiagnose.SelectedValue);
                        cmd.Parameters.AddWithValue("@Admition_History", radchkPatientHistory.Checked);

                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        cmd.Parameters.Clear();
                        cmd.CommandText = "UPDATE[dbo].[EI_Patient_Data] " +
                                          " SET[First_name] = @First_name,[Last_name] = @Last_name,[national_code] = @national_code" +
                                          "	,[Tel] = @Tel ,[Addmition_Cause] = @Addmition_Cause,[Admition_History] = @Admition_History" +
                                          " WHERE[Patient_ID] = @Patient_ID";

                        cmd.Parameters.AddWithValue("@Patient_ID", Patient_ID);
                        cmd.Parameters.AddWithValue("@First_name", txtFirst_Name.Text);
                        cmd.Parameters.AddWithValue("@Last_name", txtLast_name.Text);
                        cmd.Parameters.AddWithValue("@national_code", txtNationalcode.Text);
                        cmd.Parameters.AddWithValue("@Tel", txttel.Text);
                        cmd.Parameters.AddWithValue("@Addmition_Cause", cmbdiagnose.SelectedValue);
                        cmd.Parameters.AddWithValue("@Admition_History", radchkPatientHistory.Checked);
                        cmd.ExecuteNonQuery();

                    }

                }
                //Form Data
                cmd.Parameters.Clear();
                cmd.CommandText = "INSERT INTO [dbo].[EI_Forms_Point] ([Form_ID],[Section_ID],[Result],[Date],[Evaluator_name],[Patient_ID],[Description],[Nurse_ID]) " +
                                  "  VALUES(@Form_ID, @Section_ID, @Result, @Date, @Evaluator_name, @Patient_ID, @Description,@Nurse_ID)";

                cmd.Parameters.AddWithValue("@Form_ID", Form_ID);
                cmd.Parameters.AddWithValue("@Section_ID", Section_ID);
                cmd.Parameters.AddWithValue("@Result", Point);
                cmd.Parameters.AddWithValue("@Date", bpDate.Text);
                cmd.Parameters.AddWithValue("@Evaluator_name", txtVisitorName.Text);
                cmd.Parameters.AddWithValue("@Patient_ID", Patient_ID);
                cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                cmd.Parameters.AddWithValue("@Nurse_ID", Nurse_ID);

                cmd.ExecuteNonQuery();


                cmd.CommandText = "SELECT MAX(ID) FROM EI_Forms_Point";
                _ID_OF_Form_Point = Convert.ToInt32(cmd.ExecuteScalar());


                //Answers For Question
                for (int i = 0; i < radGVQuestions.RowCount; i++)
                {
                    cmd.Parameters.Clear();
                    cmd.CommandText = "INSERT INTO [dbo].[EI_Question_Result] ([Q_ID],[Section_ID],[Patient_ID] " +
                                      "  ,[Answer],[Description],[Nurse_ID],[Form_ID],[Form_Point_ID]) " +
                                      "   VALUES(@Q_ID, @Section_ID, @Patient_ID, @Answer, @Description, @Nurse_ID,@Form_ID,@Form_Point_ID)";
                    cmd.Parameters.AddWithValue("@Q_ID", Convert.ToInt32(radGVQuestions.Rows[i].Cells["ID"].Value));
                    cmd.Parameters.AddWithValue("@Section_ID", Section_ID);
                    cmd.Parameters.AddWithValue("@Patient_ID", Patient_ID);
                    cmd.Parameters.AddWithValue("@Answer", Convert.ToInt32(radGVQuestions.Rows[i].Cells["Answers"].Value));
                    cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                    cmd.Parameters.AddWithValue("@Nurse_ID", Nurse_ID);  //برای فرم ۲1 باید مقدار بگیره بعد از پر کردن اطلاعات پرستار در جدول
                    cmd.Parameters.AddWithValue("@Form_ID", Form_ID);
                    cmd.Parameters.AddWithValue("@Form_Point_ID", _ID_OF_Form_Point);

                    cmd.ExecuteNonQuery();
                }



                //Update Patient_ID 
                cmd.Parameters.Clear();
                //بروزرسانی آخرین آیدی 
                cmd.CommandText = "UPDATE [dbo].[EI_Last_Patient_ID]  SET [Last_ID] =" + Patient_ID + " WHERE Last_ID < " + Patient_ID;
                cmd.ExecuteNonQuery();

                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                cmd.Parameters.Clear();

                cmd.CommandText = " DELETE FROM[dbo].[EI_Question_Result]  WHERE  [Patient_ID] =" + Patient_ID + " AND [Section_ID] = " + Section_ID + " AND [Form_ID] = " + Form_ID + " AND  [Nurse_ID] =" + Nurse_ID;
                cmd.ExecuteNonQuery();

                cmd.Parameters.Clear();
                cmd.CommandText = " DELETE FROM[dbo].[EI_Forms_Point]  WHERE [ID] =" + _ID_OF_Form_Point ;
                cmd.ExecuteNonQuery();

                cmd.Parameters.Clear();
                cmd.CommandText = " DELETE FROM[dbo].[EI_Patient_Data]  WHERE [Patient_ID] =" + Patient_ID;
                cmd.ExecuteNonQuery();


                cmd.Parameters.Clear();
                cmd.CommandText = " DELETE FROM[dbo].[EI_Nurse]  WHERE [ID] =" + Nurse_ID;
                cmd.ExecuteNonQuery();
                con.Close();
                //throw;  
                return false;
            }

        }
        private int Patient_ID_Retrieve()
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            cmd.Parameters.Clear();
            //cmd.Connection = con;
            cmd.CommandText = "SELECT Last_ID from EI_Last_Patient_ID";
            int P_ID = Convert.ToInt32(cmd.ExecuteScalar());
            P_ID++;
            con.Close();
            return P_ID;
        }

        private void ChbNational_Code_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chbNational_Code.Checked == false)
                txtNationalcode.Enabled = false;
            else
                txtNationalcode.Enabled = true;

        }

        private void TxtNurseExperience_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TxtNationalcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            txtNationalcode.MaxLength = 10; // this will allow the user to enter only 10 digits

        }

        private void Txttel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            txttel.MaxLength = 11; // this will allow the user to enter only 11 digits
        }

        private void TxtRefTurn_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TxtArchiveNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TxtRefTurn_Enter_1(object sender, EventArgs e)
        {

            txtRefTurn.BackColor = System.Drawing.Color.White;
        }

        private void TxtArchiveNumber_Enter(object sender, EventArgs e)
        {
            txtArchiveNumber.BackColor = System.Drawing.Color.White;
        }


        private void BtnCalculate_Click(object sender, EventArgs e)
        {
            btnCalculate.Text = Calculate_Point().ToString();
            btnCalculate.Font = new Font(btnCalculate.Font.FontFamily, 12); ;
            //btnCalculate.Enabled = false;
        }


        //protected override void OnLoad(EventArgs e)
        //{
        //    base.OnLoad(e);

        //    DataTable dt = new DataTable();
        //    dt.Columns.Add(new DataColumn("Id", typeof(int)));
        //    dt.Columns.Add(new DataColumn("Name", typeof(string)));
        //    dt.Columns.Add(new DataColumn("FavouriteColor", typeof(int)));

        //    Random rand = new Random();
        //    for (int i = 0; i < 50; i++)
        //    {
        //        DataRow dr = dt.NewRow();
        //        dr[0] = i;
        //        dr[1] = "John" + i.ToString();
        //        dr[2] = rand.Next(3);
        //        dt.Rows.Add(dr);
        //    }

        //    this.radGVQuestions.DataSource = dt;

        //    this.radGVQuestions.MasterTemplate.BeginUpdate();

        //    this.radGVQuestions.Columns.RemoveAt(2);

        //    RadioButtonColumn column = new RadioButtonColumn("FavouriteColor");
        //    column.HeaderText = "Favourite Color";
        //    column.Width = 170;
        //    column.ReadOnly = true;
        //    this.radGVQuestions.Columns.Add(column);

        //    this.radGVQuestions.MasterTemplate.EndUpdate();
        //}

    }
}
