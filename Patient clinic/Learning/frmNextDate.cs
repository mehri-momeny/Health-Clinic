using System;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace Patient_clinic
{
    public partial class frmNextDate : Form
    {
        int Patient_ID_ = 0;
        int Follow_ID_ = 0;
        int Prior_Follow_turn =0;
        SqlConnection con = Program.CreateConnection();//new SqlConnection("Data Source =. ;initial catalog =Health_clinic ; integrated security=true"); //Program.CreateConnection();
        SqlCommand cmd = new SqlCommand();
        public frmNextDate(string Patient_ID, string Follow_ID, int Prior_turn= 0)   //Prior_turn have data when user want change the Date , else wanna make new record of follow up
        {
            Patient_ID_ = int.Parse(Patient_ID);
            Follow_ID_ = int.Parse(Follow_ID);
            Prior_Follow_turn = Prior_turn;
            InitializeComponent();
        }

        private void FrmNextDate_Load(object sender, EventArgs e)
        {
            bpcalNextDate.Today_Click(null, null);
            if ((Patient_ID_ == 0))
            {
                MessageBox.Show("مشکلی پیش آمده است, به منوی قبلی بازمیگردید ,مجددا رکورد مورد نظر را برای تغییر تاریخ انتخاب بفرمایید.");
                this.Close();
            }

        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (Prior_Follow_turn != 0)
            {
                //if (Prior_Date_ == bpcalNextDate.Text)
                //{
                //    MessageBox.Show("تاریخ جدید نباید با تاریخ فعلی پیگیری یکسان باشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}
                //else if (DateTime.Compare(Convert.ToDateTime(Prior_Date_), Convert.ToDateTime(bpcalNextDate.Text)) == 1)
                //{
                //    MessageBox.Show("تاریخ جدید نباید از تاریخ فعلی قبل تر باشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}
                //else
                //{
                    Update_Date();
                //}

            }
            else
            {
                Save_Date();

            }
            this.Close();
        }

        bool Update_Date() // Update current record
        {
            int Follow_turn = 0;
            cmd.Connection = con;
            try
            {
                con.Open();
                cmd.Parameters.Clear();
                cmd.CommandText = "select count(Patient_ID) from FU_Follow_List where Patient_ID =" + Patient_ID_ + " AND [Follow_ID] =" + Follow_ID_;
                Follow_turn = Convert.ToInt32(cmd.ExecuteScalar());


               
                cmd.Parameters.Clear();
                cmd.CommandText = "UPDATE [dbo].[FU_Follow_List] SET [Flag] = 2  WHERE [Patient_ID] =" + Patient_ID_ + " AND [Follow_ID] =" + Follow_ID_ + " AND [Follow_turn] = '" + Prior_Follow_turn + "'";
                cmd.ExecuteNonQuery();




                cmd.Parameters.Clear();
                cmd.CommandText = "INSERT INTO [dbo].[FU_Follow_List]([Patient_ID],[Follow_ID],[FollowUp_Date],[Flag],[Follow_turn])" +
                                                                 "  VALUES(@Patient_ID, @Follow_ID, @FollowUp_Date,0,@Follow_turn)";
                cmd.Parameters.AddWithValue("@Patient_ID", Patient_ID_);
                cmd.Parameters.AddWithValue("@Follow_ID", Follow_ID_);
                cmd.Parameters.AddWithValue("@FollowUp_Date", bpcalNextDate.Text);
                cmd.Parameters.AddWithValue("@Follow_turn", ++Follow_turn);
                cmd.ExecuteNonQuery();

                con.Close();
                MessageBox.Show("تاریخ پیگیری با موفقیت تغییر یافت.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception EX)
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "UPDATE [dbo].[FU_Follow_List] SET [Flag] = 0  WHERE [Patient_ID] =" + Patient_ID_ + " AND [Follow_ID] =" + Follow_ID_ + " AND [Follow_turn] = " + Prior_Follow_turn;
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("فرآیند تغییر تاریخ پیگیری با خطا مواجه شد ،مجددا ثبت نمایید.", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
                throw;

            }
        }

        bool Save_Date() // new record
        {
            cmd.Connection = con;
            try
            {
                con.Open();

                cmd.Parameters.Clear();
                cmd.CommandText = "select count(Patient_ID) from FU_Follow_List where Patient_ID =" + Patient_ID_ + " AND [Follow_ID] =" + Follow_ID_;
                int Follow_turn = Convert.ToInt32(cmd.ExecuteScalar());


                cmd.Parameters.Clear();
                cmd.CommandText = "INSERT INTO[dbo].[FU_Follow_List] " +
                                            "([Patient_ID],[Follow_ID],[FollowUp_Date],[Flag],[Follow_turn])" +
                                       " VALUES(@Patient_ID, @Follow_ID, @FollowUp_Date,0,@Follow_turn)";
                cmd.Parameters.AddWithValue("@Patient_ID", Patient_ID_);
                cmd.Parameters.AddWithValue("@Follow_ID", Follow_ID_);
                cmd.Parameters.AddWithValue("@FollowUp_Date", bpcalNextDate.Text);
                cmd.Parameters.AddWithValue("@Follow_turn", ++Follow_turn);
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                con.Close();
                return false;
                throw;
            }
        }
    }
}
