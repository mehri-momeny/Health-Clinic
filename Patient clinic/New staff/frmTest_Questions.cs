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
    public partial class frmTest_Questions : Form
    {
        #region Define Variable
        SqlConnection con = Program.CreateConnection();  //new SqlConnection("Data Source =(local) ; initial catalog = Health_clinic ; integrated security=true"); //Program.CreateConnection();
        SqlCommand cmd = new SqlCommand();

        int Test_ID = 0;
        int Q_ID = 0; //Question ID
        int S_ID = 0; //Staff_ID
        int Last_QA_ID = 0;
        int Correct_Answer = 0;
        int Q_Point = 0;
        DataTable Dt = new DataTable();
        int Q_Number = 1;
        int Total_Point = 0;
        int Last_Opt = 0;
        #endregion
        public frmTest_Questions(int Staff_ID, int test_ID)
        {
            S_ID = Staff_ID;
            Test_ID = test_ID;
            InitializeComponent();
        }

        private void FrmTest_Questions_Load(object sender, EventArgs e)
        {
            Get_Question_DataTable(Test_ID);
            UpdatePanels();
            //Dgv_load(Test_ID);
        }


        private void UpdatePanels()
        {
            Last_QA_ID = 0;
            if (Q_Number == Dt.Rows.Count)
            {
                btnNextQ.Enabled = false;
            }
            else if (Q_Number == 1)
            {
                btnPrevQ.Enabled = false;
            }
            else
            {
                btnPrevQ.Enabled = true;
                btnNextQ.Enabled = true;
            }

            cmd.Connection = con;
            if (con.State == ConnectionState.Closed)
                con.Open();

            gpQ.Text = "سوال شماره " + Q_Number;
            DataRow[] dr = Dt.Select("Row_num =" + Q_Number);

            foreach (DataRow row in dr)
            {
                Q_ID = Convert.ToInt32(row["ID"]);
                lblQ.Text = row["Text"].ToString();
                cmd.Parameters.Clear();
                cmd.CommandText = "  SELECT * FROM MI_Q_Answer_Options WHERE Q_ID = " + Q_ID;

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["opt1"].ToString() == "")
                        rbdopt1.Visible = false;
                    else
                        rbdopt1.Text = reader["opt1"].ToString();
                    if (reader["opt2"].ToString() == "")
                        rbdopt2.Visible = false;
                    else
                        rbdopt2.Text = reader["opt2"].ToString();
                    if (reader["opt3"].ToString() == "")
                        rbdopt3.Visible = false;
                    else
                        rbdopt3.Text = reader["opt3"].ToString();
                    if (reader["opt4"].ToString() == "")
                        rbdopt4.Visible = false;
                    else
                        rbdopt4.Text = reader["opt4"].ToString();
                    Q_Point = Convert.ToInt32(reader["Q_Point"]);
                    Correct_Answer = Convert.ToInt32(reader["Correct_Answer"]);
                }
                get_Latest_answer();
            }

            con.Close();
        }
        void Get_Question_DataTable(int Qtype)
        {
            SqlDataAdapter adp = new SqlDataAdapter();
            con.Open();
            //DataSet ds = new DataSet();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;

            adp.SelectCommand.CommandText = "SELECT ROW_NUMBER() OVER(ORDER BY ID ASC) Row_num,ID,Text FROM MI_Questions WHERE TYPE IN(" + Qtype + ")";

            adp.Fill(Dt);
            con.Close();
        }

        private void BtnNextQ_Click(object sender, EventArgs e)
        {
            Q_Number++;
            if (Save_Answers())
                UpdatePanels();
        }
        private int GetSelectedAnswer()
        {
            if (rbdopt1.Checked == true) { return 1; }
            if (rbdopt2.Checked == true) { return 2; }
            if (rbdopt3.Checked == true) { return 3; }
            if (rbdopt4.Checked == true) { return 4; }
            return 0;
        }
        bool Save_Answers()
        {
            int Ans = GetSelectedAnswer();
            //insert
            //update if exist   

            try
            {
                cmd.Connection = con;
                con.Open();
                if (Last_QA_ID != 0) // Update Answer
                {
                    cmd.Parameters.Clear();
                    cmd.CommandText = "UPDATE [dbo].[NS_Question_Answers] SET [Answer] = @Answer" +
                                      " WHERE [ID] = @ID";

                    cmd.Parameters.AddWithValue("@ID", Last_QA_ID);
                    cmd.Parameters.AddWithValue("@Answer", Ans);
                    cmd.ExecuteNonQuery();
                    if (Last_Opt == Correct_Answer && Ans != Last_Opt)
                        Total_Point -= Q_Point;
                    else if (Ans == Correct_Answer && Ans != Last_Opt)
                        Total_Point += Q_Point;
                }
                else    //Insert New Answer
                {
                    //INSERT
                    cmd.Parameters.Clear();
                    cmd.CommandText = "INSERT INTO [dbo].[NS_Question_Answers]([Q_ID],[T_ID],[S_ID],[Answer]) " +
                                                                     " VALUES(@Q_ID, @T_ID, @S_ID, @Answer)";

                    cmd.Parameters.AddWithValue("@Q_ID", Q_ID);
                    cmd.Parameters.AddWithValue("@T_ID", Test_ID);
                    cmd.Parameters.AddWithValue("@S_ID", S_ID);
                    cmd.Parameters.AddWithValue("@Answer", Ans);
                    cmd.ExecuteNonQuery();
                    if (Ans == Correct_Answer)
                        Total_Point += Q_Point;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
                return false;
            }
            con.Close();
            return true;
        }

        private void BtnPrevQ_Click(object sender, EventArgs e)
        {
            Q_Number--;
            if (Save_Answers())
                UpdatePanels();
        }

        void get_Latest_answer()
        {
            Last_Opt = 0;
            try
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "SELECT [ID],[Q_ID],[T_ID],[S_ID],[Answer]" +
                                  "FROM[dbo].[NS_Question_Answers] " +
                                  "WHERE[Q_ID] =@Q_ID AND [S_ID] =@S_ID AND [T_ID] =@T_ID ";

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Q_ID", Q_ID);
                cmd.Parameters.AddWithValue("@S_ID", S_ID);
                cmd.Parameters.AddWithValue("@T_ID", Test_ID);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Last_QA_ID = Convert.ToInt32(reader["ID"]);
                    Last_Opt = Convert.ToInt32(reader["Answer"]);
                }


                //int Opt = Convert.ToInt32(cmd.ExecuteScalar());
                switch (Last_Opt)
                {
                    case 1:
                        {
                            rbdopt1.Checked = true;
                            rbdopt2.Checked = false;
                            rbdopt3.Checked = false;
                            rbdopt4.Checked = false;
                            break;
                        }
                    case 2:
                        {
                            rbdopt1.Checked = false;
                            rbdopt2.Checked = true;
                            rbdopt3.Checked = false;
                            rbdopt4.Checked = false;
                            break;
                        }
                    case 3:
                        {
                            rbdopt1.Checked = false;
                            rbdopt2.Checked = false;
                            rbdopt3.Checked = true;
                            rbdopt4.Checked = false;
                            break;
                        }
                    case 4:
                        {
                            rbdopt1.Checked = false;
                            rbdopt2.Checked = false;
                            rbdopt3.Checked = false;
                            rbdopt4.Checked = true;
                            break;
                        }
                    default:
                        {
                            rbdopt1.Checked = false;
                            rbdopt2.Checked = false;
                            rbdopt3.Checked = false;
                            rbdopt4.Checked = false;
                            break;
                        }

                }

            }
            catch (Exception)
            {
                throw;
            }
            con.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            //delete all answers with this code
            if (Delete_Answers())
                this.Close();
            else
                MessageBox.Show("مشکلی پیش آمده است, مجددا تلاش بفرمایید");
        }
        bool Delete_Answers()
        {
            try
            {
                cmd.Connection = con;
                con.Open();
                //INSERT
                cmd.Parameters.Clear();
                cmd.CommandText = "DELETE FROM [dbo].[NS_Question_Answers] WHERE T_ID =@T_ID AND S_ID =@S_ID";

                cmd.Parameters.AddWithValue("@S_ID", S_ID);
                cmd.Parameters.AddWithValue("@T_ID", Test_ID);
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); ;
            }
            con.Close();
            return false;
        }

        private void Btnfinish_Click(object sender, EventArgs e)
        {
            //add total point to NS_Test_Result
            if (Save_Answers())
            {
                try
                {
                    cmd.Connection = con;
                    con.Open();
                    //INSERT
                    cmd.Parameters.Clear();
                    cmd.CommandText = "INSERT INTO [dbo].[NS_Test_Result] ([S_ID],[T_ID],[Point]) " +
                                                                  " VALUES(@S_ID, @T_ID, @Point)";

                    cmd.Parameters.AddWithValue("@S_ID", S_ID);
                    cmd.Parameters.AddWithValue("@T_ID", Test_ID);
                    cmd.Parameters.AddWithValue("@Point", Total_Point);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message); ;
                }
                con.Close();

                this.Close();
            }
            else
                MessageBox.Show("مشکلی پیش آمده است, مجددا تلاش بفرمایید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }









        //private void Display_Question_Dynamically()
        //{
        //    //this.groupPanel1.
        //    TextBox[] textBoxes = new TextBox[n];
        //    Label[] labels = new Label[n];

        //    for (int i = 0; i < n; i++)
        //    {
        //        textBoxes[i] = new TextBox();
        //        // Here you can modify the value of the textbox which is at textBoxes[i]

        //        labels[i] = new Label();
        //        // Here you can modify the value of the label which is at labels[i]
        //    }
        //    int H = 0;
        //    // This adds the controls to the form (you will need to specify thier co-ordinates etc. first)
        //    for (int i = 0; i < n; i++)
        //    {
        //        tableLayoutPanel1.Controls.Add(textBoxes[i]);
        //        textBoxes[i].Location = new Point(100, 50 * i + 10); //180 + (i * 10);
        //        tableLayoutPanel1.Controls.Add(labels[i]);
        //        labels[i].Location = new Point(150, 50 * i + 10);
        //        H = 50 * i;
        //    }
        //    this.Height = H + 100;
        //    this.HScroll = true;
        //}















    }
}
