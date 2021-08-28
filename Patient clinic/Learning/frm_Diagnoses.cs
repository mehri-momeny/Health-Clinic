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
    public partial class frm_Diagnoses : Form
    {
        SqlConnection con = Program.CreateConnection();//new SqlConnection("Data Source =(local) ; initial catalog = Health_clinic ; integrated security=true");
        SqlCommand cmd = new SqlCommand();
        public static DataGridViewRow SelectedDiagnoseRow { get; set; }
        public frm_Diagnoses()
        {
            InitializeComponent();
        }

        private void Frm_Diagnoses_Load(object sender, EventArgs e)
        {
            Dgv_Diagnose_load();


        }
        void Dgv_Diagnose_load()
        {
            SqlDataAdapter adp = new SqlDataAdapter();
            con.Open();
            DataSet ds = new DataSet();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "SELECT * FROM[dbo].[MI_Diagnose]";
            adp.Fill(ds, "Diagnose");
            dgv_Diagnoses.DataSource = ds;
            dgv_Diagnoses.DataMember = "Diagnose";

            dgv_Diagnoses.Columns["ID"].HeaderText = "کد تشخیص";
            dgv_Diagnoses.Columns["name"].HeaderText = "نام";
            dgv_Diagnoses.Columns["Abbreviation"].HeaderText = "مخفف";
            con.Close();

        }
        
        private void Dgv_Diagnoses_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //Set the Selected Row in Property.
                SelectedDiagnoseRow = dgv_Diagnoses.Rows[e.RowIndex];
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            Delete_data();
            SelectedDiagnoseRow = null;
            Dgv_Diagnose_load();

        }
        void Delete_data()
        {
            DialogResult Result;
            if (SelectedDiagnoseRow is null)
            {
                MessageBox.Show("سطر مورد نظر را ابتدا انتخاب بفرمایید..");
                return;

            }
            else
                Result= MessageBox.Show("آیا رکورد انتخاب شده حذف گردد؟", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (Result == System.Windows.Forms.DialogResult.Yes)
            {
             
            con.Open();
            try
            {

                cmd.Connection = con;
                cmd.Parameters.Clear();
                cmd.CommandText = "DELETE FROM [dbo].[MI_Diagnose]" +
                                 " WHERE ID=@Code";

                cmd.Parameters.AddWithValue("@Code", SelectedDiagnoseRow.Cells["ID"].Value);
                cmd.ExecuteNonQuery();
                MessageBox.Show("رکورد مورد نظر حذف گردید");
            }
            catch (Exception e)
            {
                MessageBox.Show("مشکلی  پیش آمده است٬حذف انجام نشد!\n" + e.Message);
            }
            con.Close();
                // Closes the parent form.
                //this.Close();
            }
        }
        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            new frmAddDiagnose(0).ShowDialog();
            Dgv_Diagnose_load();

        }
        //public DataTable BindSource()
        //{
        //    string sqlCon = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\DB\Database1.mdf;Integrated Security=True";
        //    string sqlSelect = @"select * from Table1";
        //    using (SqlConnection conn = new SqlConnection(sqlCon))
        //    {
        //        using (SqlCommand cmd = new SqlCommand(sqlSelect, conn))
        //        {
        //            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
        //            {
        //                ds.Clear();
        //                adapter.Fill(ds);
        //                dt = ds.Tables[0];
        //                conn.Close();
        //            }
        //        }
        //    }
        //    return dt;
        //}


        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (SelectedDiagnoseRow is null)
            {
                MessageBox.Show("سطر مورد نظر را ابتدا انتخاب بفرمایید..");
                return;

            }
            new frmAddDiagnose(1).ShowDialog();
            Dgv_Diagnose_load();
        }
        //protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
        //{

        //    if (e.CommandName == "Insert") //- this is needed to explain that the INSERT command will only work when INSERT is clicked
        //    {
        //        gv.DataBind();

        //        DataTable d = dbcon.GetDataTable("SELECT * FROM CIS.CIS_TRANS ORDER BY ID DESC", "ProjectCISConnectionString");

        //        string transCode = "", fundCode = "", BSA_CD = "", DP_TYPE = "";

        //        if (d.Rows.Count > 0)
        //        {
        //            transCode = d.Rows[0]["TRANS_CD"].ToString();
        //            fundCode = d.Rows[0]["FUND_CD"].ToString();
        //            BSA_CD = d.Rows[0]["BSA_CD"].ToString();
        //            DP_TYPE = d.Rows[0]["DP_TYPE"].ToString();

        //            if (transCode.Trim().Length > 0)
        //            {
        //                dbcon.Execute("INSERT INTO CIS.CIS_TRANS (ID,TRANS_CD) VALUES(CIS.S_CIS_TRANS.nextval,'')", "ProjectCISConnectionString");

        //                gv.DataBind();
        //            }
        //        }
        //        gv.EditIndex = gv.Rows.Count - 1;

        //    }
        //    else if (e.CommandName == "Cancel")
        //    {
        //        DataTable d = dbcon.GetDataTable("SELECT * FROM CIS.CIS_TRANS ORDER BY ID DESC", "ProjectCISConnectionString");

        //        string transCode = "";

        //        if (d.Rows.Count > 0)
        //        {
        //            transCode = d.Rows[0]["TRANS_CD"].ToString();

        //            if (transCode.Trim().Length == 0)
        //            {
        //                dbcon.Execute(string.Format("DELETE CIS.CIS_TRANS WHERE ID = '{0}'", d.Rows[0]["ID"]), "ProjectCISConnectionString");

        //                gv.DataBind();
        //            }
        //        }

    }
}
