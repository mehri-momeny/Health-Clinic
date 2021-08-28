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
//using Excel = Microsoft.Office.Interop.Excel;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System.IO;
using Stimulsoft.Report;
using System.Globalization;

namespace Patient_clinic
{
    public partial class frmshowdata : Form
    {
        public frmshowdata()
        {
            InitializeComponent();
        }
        SqlConnection con = Program.CreateConnection(); //new SqlConnection("Data Source = 'kh-e0211' ;initial catalog =Health_clinic ; integrated security=true");
        SqlCommand cmd = new SqlCommand();
        PersianCalendar p = new PersianCalendar();

        private void Frmshowdata_Load(object sender, EventArgs e)
        {
            Dgv_load();
            txtYear.Text = p.GetYear(DateTime.Now).ToString();
            //cmbmonth.SelectedIndex = p.GetMonth(DateTime.Now) - 1;
            lblCount.Text = dgvList.Rows.Count.ToString();
        }
        void Dgv_load()
        {
            SqlDataAdapter adp = new SqlDataAdapter();
            con.Open();
            DataSet ds = new DataSet();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "SELECT * FROM[dbo].[Patients] order by Patient_ID";
            adp.Fill(ds, "Patients");
            dgvList.DataSource = ds;
            dgvList.DataMember = "Patients";
            Convert_column_name(dgvList);
            con.Close();

        }
        void Convert_column_name(DataGridView dgvList)
        {
            dgvList.Columns["Patient_ID"].Width = 40;
            dgvList.Columns["Patient_ID"].HeaderText = "شناسه";
            dgvList.Columns["Patient_ID_code"].HeaderText = "کد بیمار";
            dgvList.Columns["First_name"].HeaderText = "نام";
            dgvList.Columns["Last_name"].HeaderText = "نام خانوادگی";
            dgvList.Columns["national_code"].HeaderText = "کد ملی";
            dgvList.Columns["Father_name"].HeaderText = "نام پدر";
            dgvList.Columns["Year_Birth_date"].HeaderText = "سال تولد";
            dgvList.Columns["Year_Birth_date"].Width = 55;
            dgvList.Columns["Age"].HeaderText = "سن";
            dgvList.Columns["Age"].Width = 45;
            dgvList.Columns["Tel"].HeaderText = "تلفن";
            dgvList.Columns["Tel"].Width = 80;
            dgvList.Columns["Diagnose"].HeaderText = "تشخیص";
            dgvList.Columns["History"].HeaderText = "سابقه بیماری";
            dgvList.Columns["OtherDisease"].HeaderText = "سایر بیماریها";
            dgvList.Columns["Doctor"].HeaderText = "پزشک معالج";
            dgvList.Columns["Insurer"].HeaderText = "بیمه کننده ";
            dgvList.Columns["Insurance_type"].HeaderText = "نوع بیمه";
            dgvList.Columns["Education"].HeaderText = "تحصیلات";
            dgvList.Columns["Patient_partner"].HeaderText = "همراهی بیمار";
            dgvList.Columns["Ref_Date"].HeaderText = "تاریخ مراجعه";
            dgvList.Columns["Ref_type"].HeaderText = "نحوه ارجاع";
            dgvList.Columns["Ref_turn"].HeaderText = "نوبت مراجعه";
            dgvList.Columns["Learn_asses"].HeaderText = "ارزیابی آموزش";
            dgvList.Columns["Instructor_name"].HeaderText = "آموزش دهنده";
            dgvList.Columns["visit_description"].HeaderText = "توضیحات";
            dgvList.Columns["Train_type"].HeaderText = "شیوه ارائه آموزش";
            dgvList.Columns["care_before_surgery"].HeaderText = "مراقبت قبل از عمل";
            dgvList.Columns["care_after_surgery"].HeaderText = "مراقبت بعد از عمل";
            dgvList.Columns["care_disease_type"].HeaderText = "نوع بیماری,نحوه درمان,مراقبت";
            dgvList.Columns["care_background_disease"].HeaderText = "آموزش درمورد بیماری‌های زمینه‌ای";
        }

        private void Btnexit_Click(object sender, EventArgs e)
        {
            SelectedRow = null;
            this.Close();
        }

        private void Btndelete_Click(object sender, EventArgs e)
        {
            Delete_data();
            SelectedRow = null;
            Dgv_load();
        }

        private void TxtFirstnamesearch_TextChanged(object sender, EventArgs e)
        {
            DataTable dt;
            SqlDataAdapter adp;
            con.Open();
            adp = new SqlDataAdapter("select * from [dbo].[Patients] where First_name like '" + txtFirstnamesearch.Text + "%'", con);
            dt = new DataTable();
            adp.Fill(dt);
            dgvList.DataSource = dt;
            Convert_column_name(dgvList);
            con.Close();
            lblCount.Text = dgvList.Rows.Count.ToString();
        }

        private void Txtlastnamesearch_TextChanged(object sender, EventArgs e)
        {
            DataTable dt;
            SqlDataAdapter adp;
            con.Open();
            adp = new SqlDataAdapter("select * from [dbo].[Patients] where last_name like '" + txtlastnamesearch.Text + "%'", con);
            dt = new DataTable();
            adp.Fill(dt);
            dgvList.DataSource = dt;
            Convert_column_name(dgvList);
            con.Close();

        }

        private void Txtnationalcodesearch_TextChanged(object sender, EventArgs e)
        {
            DataTable dt;
            SqlDataAdapter adp;
            con.Open();
            adp = new SqlDataAdapter("select * from [dbo].[Patients] where national_code like '" + txtnationalcodesearch.Text + "%'", con);
            dt = new DataTable();
            adp.Fill(dt);
            dgvList.DataSource = dt;
            Convert_column_name(dgvList);
            con.Close();
        }

        private void Txtfathername_TextChanged(object sender, EventArgs e)
        {
            DataTable dt;
            SqlDataAdapter adp;
            con.Open();
            adp = new SqlDataAdapter("select * from [dbo].[Patients] where father_name like '" + txtfathername.Text + "%'", con);
            dt = new DataTable();
            adp.Fill(dt);
            dgvList.DataSource = dt;
            Convert_column_name(dgvList);
            con.Close();
        }
        public static DataGridViewRow SelectedRow { get; set; }

        private void DgvList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //Set the Selected Row in Property.
                SelectedRow = dgvList.Rows[e.RowIndex];
            }
        }
        void Delete_data()
        {
            DialogResult Result;
            if (SelectedRow is null)
            {
                MessageBox.Show("سطر مورد نظر را ابتدا انتخاب بفرمایید..");
                return;

            }
            else
                Result = MessageBox.Show("آیا رکورد انتخاب شده حذف گردد؟", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (Result == System.Windows.Forms.DialogResult.Yes)
            {

                con.Open();
                try
                {

                    cmd.Connection = con;
                    cmd.Parameters.Clear();
                    cmd.CommandText = "DELETE FROM [dbo].[Patients]" +
                                     " WHERE Patient_ID=@Patient_ID and ref_turn = @Ref_turn";

                    cmd.Parameters.AddWithValue("@Patient_ID", SelectedRow.Cells["Patient_ID"].Value.ToString());

                    cmd.Parameters.AddWithValue("@Ref_turn", SelectedRow.Cells["Ref_turn"].Value.ToString());


                    cmd.ExecuteNonQuery();
                    MessageBox.Show("رکورد مورد نظر حذف گردید");
                }
                catch (Exception e)
                {
                    MessageBox.Show("مشکلی  پیش آمده است٬حذف انجام نشد!\n" + e.Message);
                }
                con.Close();
            }
        }

        private void Btnedit_Click(object sender, EventArgs e)
        {
            if (SelectedRow is null)
            {
                MessageBox.Show("سطر مورد نظر را ابتدا انتخاب بفرمایید..");
                return;

            }
            //Open the other Form
            //DataEntry frmEdit = new DataEntry();
            //frmEdit.Show();
            this.Close();
            //new DataEntry().Show();


        }
        private void BtnNwRef_Click(object sender, EventArgs e)
        {
            if (SelectedRow is null)
            {
                MessageBox.Show("سطر مورد نظر را ابتدا انتخاب بفرمایید..");
                return;
            }
            Program.Patient_ID = Convert.ToInt32(SelectedRow.Cells["Patient_ID"].Value);
            frmshowdata.SelectedRow = null;
            this.Close();

            //DataEntry ShowForm = new DataEntry();
            //this.Hide();
            //ShowForm.ShowDialog();
        }
        //private void BtnExcel_Click(object sender, EventArgs e)
        //{
        //    string savePath = "";
        //    string Month = "03";
        //    DataSet ds;
        //    SqlDataAdapter adp;
        //    con.Open();
        //    adp = new SqlDataAdapter("SP_Payesh \'" + Month + "\'", con);  //call Stored Procedure
        //    ds = new DataSet();
        //    adp.Fill(ds);


        //    SaveFileDialog sf = new SaveFileDialog();
        //    // Feed the dummy name to the save dialog
        //    sf.FileName = "Patient_List.xlsx";

        //    if (sf.ShowDialog() == DialogResult.OK)
        //    {
        //        // Now here's our save folder
        //        savePath = Path.GetDirectoryName(sf.FileName);
        //    }
        //    // Create the Excel worksheet from the data set
        //    try
        //    {
        //        ExcelLibrary.DataSetHelper.CreateWorkbook(savePath, ds);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("ذخیره فایل اکسل با خطا مواجه شده است. \n" + ex.Message);
        //    }
        //    con.Close();


        //}

        private void BtnReport_Click(object sender, EventArgs e)
        {
            frmClinicReport frmClinicReport = new frmClinicReport();
            frmClinicReport.ShowDialog();
            //string Month = "03";//cmbmonth.SelectedValue.ToString();
            ////DataSet ds;
            ////SqlDataAdapter adp;
            ////con.Open();
            ////adp = new SqlDataAdapter("SP_Payesh \'" + Month + "\'", con);  //call Stored Procedure
            ////ds = new DataSet();
            ////adp.Fill(ds);

            //try
            //{
            //    StiReport report = new StiReport();
            //    report.Load("Reports/rptPayesh.mrt");
            //    report.Compile();
            //    report["Month"] = Month;
            //    //report.RegData(ds);
            //    //report.Show();
            //    report.ShowWithRibbonGUI();

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("نمایش گزارش با خطا مواجه شده است. \n" + ex.Message);
            //}
            //con.Close();


        }

        private void Cmbmonth_SelectedValueChanged(object sender, EventArgs e)
        {
            //DataTable dt;
            //SqlDataAdapter adp;
            //if (con.State == ConnectionState.Closed) con.Open();
            //adp = new SqlDataAdapter("select * from [dbo].[Patients] where Substring(Ref_Date,0,8) =\'" + txtYear.Text + "/" + cmbmonth.Text.Substring(0, 2) + "\'", con);
            //dt = new DataTable();
            //adp.Fill(dt);
            //dgvList.DataSource = dt;
            //Convert_column_name(dgvList);
            //con.Close();

        }

        private void Cmbmonth_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Btn_filter_Click(object sender, EventArgs e)
        {
            DataTable dt;
            SqlDataAdapter adp;
            if (con.State == ConnectionState.Closed) con.Open();
            adp = new SqlDataAdapter("select * from [dbo].[Patients] where Substring(Ref_Date,0,8) =\'" + txtYear.Text + "/" + cmbmonth.Text.Substring(0, 2) + "\'", con);
            dt = new DataTable();
            adp.Fill(dt);
            dgvList.DataSource = dt;
            Convert_column_name(dgvList);
            con.Close();
            lblCount.Text = dgvList.Rows.Count.ToString();

        }
    }
}