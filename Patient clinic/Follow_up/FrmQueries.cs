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
    public partial class FrmQueries : Form
    {
        SqlConnection con = Program.CreateConnection();//new SqlConnection("Data Source =. ;initial catalog =Health_clinic ; integrated security=true"); //Program.CreateConnection();
        SqlCommand cmd = new SqlCommand();
        int Form_type = 0;
        int Patient_ID_ = 0;
        int Follow_ID_ =0;
        int Follow_turn_ = 0;
        string Full_Name_ = "";
        //int Q14 = 0;
        int Q15 = 0;
        int Q16 = 0;
        public FrmQueries(int type_s, string Patient_ID, string Follow_ID, string Full_Name,int Follow_turn)
        {
            Form_type = type_s;
            Patient_ID_ = int.Parse(Patient_ID);
            Follow_ID_ = int.Parse(Follow_ID);
            Full_Name_ = Full_Name;
            Follow_turn_ = Follow_turn;
            InitializeComponent();
        }

        private void FrmQueries_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'health_clinicDataSet.MI_FollowUp_Questions' table. You can move, or remove it, as needed.
            //this.mI_FollowUp_QuestionsTableAdapter.Fill(this.health_clinicDataSet.MI_FollowUp_Questions);
            //radTxtNationalCode.Text = National_Code_;
            //radTxtArchive.Text = Archive_Number_;
            radTxtPatient.Text = Full_Name_;
            radtxtTurn.Text = Follow_turn_.ToString();
            Load_List_Of_Question(Form_type);
            //switch (Form_type)
            //{
            //    case 1:
            //        {
            //            Load_List_Of_Question(Form_type);

            //            //tbcornea.Visible = true;
            //            //tbglocoma.Visible = false;
            //            break;
            //        }
            //    case 2:
            //        {
            //            Load_List_Of_Question(Form_type);
            //            //tbglocoma.Visible = true;
            //            //tbcornea.Visible = false;
            //            break;
            //        }
            //}

        }

        private void Load_List_Of_Question(int Qtype)
        {
            SqlDataAdapter adp = new SqlDataAdapter();
            con.Open();
            DataSet ds = new DataSet();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "SELECT ID,Text FROM MI_FollowUp_Questions WHERE TYPE IN(0, " + Qtype + ")";
            //adp.SelectCommand.CommandText = "SELECT Text,FA.Answer "+
            //                                "FROM MI_FollowUp_Questions FQ "+
            //                                "Join FU_FollowUp_Answers FA "+
            //                                "on FA.Q_ID = FQ.ID "+
            //                                "WHERE TYPE IN(0, "+ Qtype +") AND FA.Patient_ID ="+ Patient_ID_ +" AND FA.Follow_ID = "+ Follow_ID_;
            adp.Fill(ds, "Questions");
            //radLvQuestions.DataSource = ds;
            //radLvQuestions.DataMember = "Questions";


            radGVQuestions.DataSource = ds;
            radGVQuestions.DataMember = "Questions";
            radGVQuestions.Columns["Text"].HeaderText = "سوال";
            radGVQuestions.Columns["Text"].Width = 600;

            radGVQuestions.Columns["ID"].IsVisible = false;

            //radGVQuestions.DataMember.Append = "Condition";

            Telerik.WinControls.UI.GridViewCheckBoxColumn chk = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            radGVQuestions.Columns.Add(chk);
            chk.HeaderText = "بلی / خیر";
            chk.Name = "chk";
            radGVQuestions.Columns["chk"].Width = 70;
            //radGVQuestions.Columns["chk"].ReadOnly = false;
            con.Close();
        }

        private void Btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            //Q14 = (int)(MessageBox.Show("آيا بيمار دوباره بستري شد؟", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information));  //6 yes 7 No
            Q15 = (int)(MessageBox.Show("آيا بيمار نیاز به ارجاع به پزشك دارد؟", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information));  //6 yes 7 No
            Q16 = (int)(MessageBox.Show("آيا بيمار نياز به تماس مجدد دارد؟", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information));
            //int Q15
            //    int Q16 
            //if (Q14 == 6) Q14 = 1;
            //else Q14 = 0;

            if (Q15 == 6) Q15 = 1;
            else Q15 = 0;

            if (Q16 == 6)
            {
                Q16 = 1;
                new frmNextDate(Patient_ID_.ToString(), Follow_ID_.ToString()).ShowDialog();
            }
            else Q16 = 0;


            if (Save_data())
            {
                MessageBox.Show("ثبت اطلاعات با موفقیت انجام شد");
                this.Close();
            }
            else
                MessageBox.Show("ثبت اطلاعات با مشکل مواجه شد , مجددا سعی کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        bool Save_data()
        {
            
            cmd.Connection = con;
            try
            {
                con.Open();
                for (int i = 0; i < radGVQuestions.RowCount; i++)
                {
                    cmd.Parameters.Clear();
                    cmd.CommandText = "INSERT INTO[dbo].[FU_FollowUp_Answers] " +
                                    "        ([Patient_ID],[Follow_ID],[Q_ID],[Answer])" +
                                    "    VALUES(@Patient_ID, @Follow_ID, @Q_ID, @Answer)";

                    cmd.Parameters.AddWithValue("@Patient_ID", Patient_ID_);
                    cmd.Parameters.AddWithValue("@Follow_ID", Follow_ID_);
                    cmd.Parameters.AddWithValue("@Q_ID", Convert.ToInt32(radGVQuestions.Rows[i].Cells["ID"].Value));
                    cmd.Parameters.AddWithValue("@Answer", Convert.ToBoolean(radGVQuestions.Rows[i].Cells["chk"].Value));

                    cmd.ExecuteNonQuery();
                }
                //Q15
                cmd.Parameters.Clear();
                cmd.CommandText = "INSERT INTO[dbo].[FU_FollowUp_Answers] " +
                                "        ([Patient_ID],[Follow_ID],[Q_ID],[Answer])" +
                                "    VALUES(@Patient_ID, @Follow_ID, @Q_ID, @Answer)";

                cmd.Parameters.AddWithValue("@Patient_ID", Patient_ID_);
                cmd.Parameters.AddWithValue("@Follow_ID", Follow_ID_);
                cmd.Parameters.AddWithValue("@Q_ID", 15);
                cmd.Parameters.AddWithValue("@Answer", Q15);

                cmd.ExecuteNonQuery();

                //Q16
                cmd.Parameters.Clear();
                cmd.CommandText = "INSERT INTO[dbo].[FU_FollowUp_Answers] " +
                                "        ([Patient_ID],[Follow_ID],[Q_ID],[Answer])" +
                                "    VALUES(@Patient_ID, @Follow_ID, @Q_ID, @Answer)";

                cmd.Parameters.AddWithValue("@Patient_ID", Patient_ID_);
                cmd.Parameters.AddWithValue("@Follow_ID", Follow_ID_);
                cmd.Parameters.AddWithValue("@Q_ID", 16);
                cmd.Parameters.AddWithValue("@Answer", Q16);

                cmd.ExecuteNonQuery();

                //Update Flag as Succesfull
                cmd.Parameters.Clear();
                cmd.CommandText = "UPDATE[dbo].[FU_Follow_List]   SET [Flag] = 1 WHERE [Patient_ID] ="+ Patient_ID_ +" AND [Follow_ID] ="+ Follow_ID_ + " AND [Follow_turn] = "+ Follow_turn_;
                cmd.ExecuteNonQuery();

                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                cmd.Parameters.Clear();
                cmd.CommandText = " DELETE FROM[dbo].[FU_FollowUp_Answers]  WHERE [Patient_ID] =" + Patient_ID_ + " AND [Follow_ID] =" + Follow_ID_;
                cmd.ExecuteNonQuery();
                MessageBox.Show(ex.Message);
                con.Close();
                //throw;  
                return false;
            }

        }
    }
}
