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
using Telerik.WinControls.UI;
using GemBox.Spreadsheet;
using System.IO;


namespace Patient_clinic.health_education_indicators
{
    public partial class frmReport_EI : Form
    {
        SqlConnection con = Program.CreateConnection();//new SqlConnection("Data Source =. ;initial catalog =Health_clinic ; integrated security=true"); //Program.CreateConnection();
        SqlCommand cmd = new SqlCommand();
        PersianCalendar p = new PersianCalendar();
        string Form_Name = "";
        int Form_ID = 0;
        string Section = "";
        int Section_ID = 0;

        public frmReport_EI(string Form_Name_, int Form_ID_, string Section_, int Section_ID_)
        {
            InitializeComponent();
            Form_Name = Form_Name_;
            Form_ID = Form_ID_;
            Section = Section_;
            Section_ID = Section_ID_;
        }

        private void FrmReport_EI_Load(object sender, EventArgs e)
        {
            txtYear.Text = p.GetYear(DateTime.Now).ToString();
            cmbmonth.SelectedIndex = p.GetMonth(DateTime.Now) - 1;
            LblForm_Name.Text = Form_Name;
            lblSection_Name.Text = Section;
            Load_Data(txtYear.Text + "/" + cmbmonth.Text.Substring(0, 2));
        }

        private void BtnShow_Data_Click(object sender, EventArgs e)
        {
            string Date_Month = txtYear.Text + "/" + cmbmonth.Text.Substring(0, 2);
            Load_Data(Date_Month);
            dgv_load(Date_Month);
        }
        void Load_Data(string Date)
        {
            if (con.State != ConnectionState.Open)
                con.Open();
            cmd.Connection = con;
            cmd.Parameters.Clear();
            cmd.CommandText = "SELECT FP.SECTION_ID,FP.FORM_ID,POINT,FPT.FORM_POINT *FORM_COUNT TOTAL_POINT " +
                                            "FROM (SELECT COUNT(ID) FORM_COUNT, SUM(Result) POINT, Form_ID, Section_ID " +
                                            "       FROM EI_Forms_Point where substring(Date,0,8) = @Date" +
                                            "       GROUP BY Form_ID, Section_ID) AS FP, " +
                                            " 	(SELECT COUNT(F.ID) * 2 FORM_POINT, F.ID " +
                                            "        FROM MI_Forms F, MI_Questions Q " +

                                            "        WHERE F.ID = Q.type GROUP BY F.ID) AS FPT " +
                                            "WHERE FPT.ID = FP.Form_ID " +

                                            "        AND Form_ID = @Form_ID AND Section_ID = @Section_ID";
            cmd.Parameters.AddWithValue("@Date", Date);
            cmd.Parameters.AddWithValue("@Form_ID", Form_ID);
            cmd.Parameters.AddWithValue("@Section_ID", Section_ID);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                txtPoint.Text = reader["POINT"].ToString();
                txttotalPoint.Text = reader["TOTAL_POINT"].ToString();
                lblPercent.Text = Math.Floor((Convert.ToDecimal(txtPoint.Text) / Convert.ToDecimal(txttotalPoint.Text)) * 100).ToString();
            }
            con.Close();
        }
        void dgv_load(string Date)
        {
            if (con.State != ConnectionState.Open)
                con.Open();

            SqlDataAdapter adp = new SqlDataAdapter();
            DataSet ds = new DataSet();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            if (rbdBad0.Checked == true)
            {  //سوالاتی که پاسخ ضعیف داشتند
                adp.SelectCommand.CommandText = "SELECT Q.TEXT,COUNT_Q, Section_ID,Form_ID,Q_ID " +
                                                "FROM (SELECT COUNT(QR.ID) COUNT_Q, QR.Section_ID, QR.Form_ID, QR.Q_ID " +
                                                 "      FROM EI_Forms_Point FP, EI_Question_Result QR   WHERE Answer = 0   AND substring(FP.Date, 0, 8) = @Date  AND FP.ID = QR.Form_Point_ID" +
                                                 "  GROUP BY QR.Section_ID, QR.Form_ID, QR.Q_ID) AS QR " +
                                                 "     , MI_Questions AS Q " +
                                                " WHERE QR.Q_ID = Q.ID AND Form_ID = @Form_ID AND Section_ID = @Section_ID";
            }
            else
            { // سوالاتی که پاسخ متوسط داشتند
                adp.SelectCommand.CommandText = "SELECT Q.TEXT,COUNT_Q, Section_ID,Form_ID,Q_ID " +
                                                "FROM (SELECT COUNT(QR.ID) COUNT_Q, QR.Section_ID, QR.Form_ID, QR.Q_ID " +
                                                 "      FROM EI_Forms_Point FP, EI_Question_Result QR   WHERE Answer = 1   AND substring(FP.Date, 0, 8) = @Date  AND FP.ID = QR.Form_Point_ID" +
                                                 "  GROUP BY QR.Section_ID, QR.Form_ID, QR.Q_ID) AS QR " +
                                                 "     , MI_Questions AS Q " +
                                                " WHERE QR.Q_ID = Q.ID AND Form_ID = @Form_ID AND Section_ID = @Section_ID";
            }
            adp.SelectCommand.Parameters.AddWithValue("@Date", Date);
            adp.SelectCommand.Parameters.AddWithValue("@Form_ID", Form_ID);
            adp.SelectCommand.Parameters.AddWithValue("@Section_ID", Section_ID);

            adp.Fill(ds, "Report");

            radGvReport.DataSource = ds;
            radGvReport.DataMember = "Report";
            Convert_column_name(radGvReport);
            con.Close();
        }

        
        private void Convert_column_name(RadGridView radGvReport)
        {
            radGvReport.TableElement.RowHeight = 30;
            radGvReport.Columns["TEXT"].HeaderText = "عنوان سوال ";
            radGvReport.Columns["TEXT"].Width = 475;
            radGvReport.Columns["TEXT"].WrapText = true;
            radGvReport.Columns["TEXT"].TextAlignment = ContentAlignment.MiddleLeft;

            radGvReport.Columns["COUNT_Q"].HeaderText = "تعداد ";
            radGvReport.Columns["COUNT_Q"].Width = 35;
            radGvReport.Columns["COUNT_Q"].WrapText = true;
            radGvReport.Columns["COUNT_Q"].TextAlignment = ContentAlignment.MiddleCenter;


            radGvReport.Columns["Section_ID"].IsVisible = false;
            radGvReport.Columns["Q_ID"].IsVisible = false;
            radGvReport.Columns["Form_ID"].IsVisible = false;

        }

        private void RbdMiddle1_CheckedChanged(object sender, EventArgs e)
        {
            dgv_load(txtYear.Text + "/" + cmbmonth.Text.Substring(0, 2));  
        }

        private void RbdBad0_CheckedChanged(object sender, EventArgs e)
        {
            dgv_load(txtYear.Text + "/" + cmbmonth.Text.Substring(0, 2));
        }

        private void Cmbmonth_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Load_Data(txtYear.Text + "/" + cmbmonth.Text.Substring(0, 2));
                rbdBad0.Checked = false;
                rbdMiddle1.Checked = false;
                radGvReport.DataSource = null;
                //radGvReport.DataBind();
            }
        }

        private void Btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnExcel_Click(object sender, EventArgs e)
        {
            SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");
            var workbook = new ExcelFile();
            var worksheet = workbook.Worksheets.Add("DataTable to Sheet");

            //var dataTable = new DataTable();
            string YearMonth = txtYear.Text + "/" + cmbmonth.Text.Substring(0, 2);
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            //Month = cmbmonth.SelectedValue.ToString();

            adp.SelectCommand.CommandText = "SELECT S.Name AS SECTION_NAME,F.Name AS FORM_NAME,Q.Text AS QUESTION,COUNT_Q_0,COUNT_Q_1 "+
                                            "FROM MI_Forms F,MI_Sections S, MI_Questions AS Q, "+
                                            " 		(SELECT ISNULL(COUNT_Q_0, 0)COUNT_Q_0, ISNULL(COUNT_Q_1, 0)COUNT_Q_1, "+
                                            "                 ISNULL(QA_0.Section_ID, QA_1.Section_ID)Section_ID, ISNULL(QA_0.Form_ID, QA_1.Form_ID)Form_ID, ISNULL(QA_0.Q_ID, QA_1.Q_ID)Q_ID " +
                                            "         FROM " +
                                            "         (SELECT COUNT(QR.ID) COUNT_Q_0, QR.Section_ID, QR.Form_ID, Q_ID " +
                                            "             FROM EI_Forms_Point FP, EI_Question_Result QR " +
                                            "             WHERE QR.Answer = 0 AND substring(FP.Date, 0, 8) = @Date  AND FP.ID = QR.Form_Point_ID " +
                                            "             GROUP BY QR.Section_ID, QR.Form_ID, QR.Q_ID) AS QA_0 " +
                                            "         FULL JOIN " +
                                            "         (SELECT COUNT(QR.ID) COUNT_Q_1, QR.Section_ID, QR.Form_ID, Q_ID " +
                                            "             FROM EI_Forms_Point FP, EI_Question_Result QR " +
                                            "             WHERE QR.Answer = 1 AND substring(FP.Date, 0, 8) = @Date  AND FP.ID = QR.Form_Point_ID " +
                                            "             GROUP BY QR.Section_ID, QR.Form_ID, QR.Q_ID)  AS QA_1 " +
                                            "         ON QA_0.Section_ID = QA_1.Section_ID  AND QA_0.Form_ID = QA_1.Form_ID AND QA_0.Q_ID = QA_1.Q_ID) AS MERGE_TABLE " +
                                            "WHERE MERGE_TABLE.Q_ID = Q.ID AND MERGE_TABLE.Section_ID = S.ID AND MERGE_TABLE.Form_ID = F.ID";
            adp.SelectCommand.Parameters.AddWithValue("@Date", YearMonth);

            dt = new DataTable();
            adp.Fill(dt);

            worksheet.Cells[0, 1].Value = " پایش سوالات فرم‌های ارزیابی شاخص های آموزش سلامت  "+Program.Clinic_Name+" در "+ cmbmonth.Text.Substring(3) + " ماه سال  "+txtYear.Text +" که نمرات ضعیف یا متوسط کسب شده است :";

            dt.Columns["SECTION_NAME"].ColumnName = "عنوان بخش";
            dt.Columns["FORM_NAME"].ColumnName = "عنوان فرم";
            dt.Columns["QUESTION"].ColumnName = "متن سوال";
            dt.Columns["COUNT_Q_0"].ColumnName = "تعداد پاسخ های ضعیف";
            dt.Columns["COUNT_Q_1"].ColumnName = "تعداد پاسخ های متوسط";


            // Insert DataTable to an Excel worksheet.
            worksheet.InsertDataTable(dt,
                new InsertDataTableOptions()
                {
                    ColumnHeaders = true,
                    StartRow = 2
                });
            worksheet.ViewOptions.ShowColumnsFromRightToLeft = true;   //layout right to left
            // set width of column 
            worksheet.Columns["B"].Width = 9000;  //FORM_NAME
            worksheet.Columns["C"].Width = 35000; //QUESTION
            worksheet.Columns["D"].Width = 4500;  //COUNT_Q_0
            worksheet.Columns["E"].Width = 4500;  //COUNT_Q_1


            SaveFileDialog sf = new SaveFileDialog();
            // Feed the dummy name to the save dialog
            sf.FileName = "EI_Report";
            string savePath = "";
            if (sf.ShowDialog() == DialogResult.OK)
            {
                // Now here's our save folder
                savePath = Path.GetDirectoryName(sf.FileName);
            }
            // Create the Excel worksheet from the data set
            try
            {
                workbook.Save(savePath + "EI_Report.xlsx");
                MessageBox.Show("فایل اکسل با موفقیت در محل انتخاب شده به آدرس زیر ذخیره گردید. \n" + savePath, "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

            catch (Exception ex)
            {
                MessageBox.Show("ذخیره فایل اکسل با خطا مواجه شده است. \n اگر فایل اکسل از قبل باز هست لطفا ابتدا فایل را ببندید سپس امتحان بفرمایید. \n" + ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            con.Close();
        }
    }
}
