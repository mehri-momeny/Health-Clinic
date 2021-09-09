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
using System.IO;
using Telerik.WinControls.UI;
using System.Globalization;
using Telerik.WinControls.UI.Export;
using Telerik.WinControls.Data;
using Telerik.WinControls.Export;
using GemBox.Spreadsheet;

namespace Patient_clinic.Follow_up
{
    public partial class frmReport : Form
    {
        SqlConnection con = Program.CreateConnection();//new SqlConnection("Data Source =. ;initial catalog =Health_clinic ; integrated security=true"); //Program.CreateConnection();
        SqlCommand cmd = new SqlCommand();
        PersianCalendar p = new PersianCalendar();
        public frmReport()
        {
            InitializeComponent();
        }

        private void BtnExcel_Click(object sender, EventArgs e)
        {
            if (txtTotalNum.TextLength == 0)
            {
                MessageBox.Show("لطفا تعداد کل بیماران را وارد نمایید.");
                return;
            }
            SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");
            var workbook = new ExcelFile();
            var worksheet = workbook.Worksheets.Add("DataTable to Sheet");


            //var dataTable = new DataTable();
            string YearMonth = txtYear.Text + "/" + cmbmonth.Text.Substring(0, 2);
            DataTable dt;
            SqlDataAdapter adp;
            con.Open();
            //Month = cmbmonth.SelectedValue.ToString();
            adp = new SqlDataAdapter("SP_FOLLOW_UP_REPORT \'" + YearMonth + "\',"+ txtTotalNum.Text, con);  //call Stored Procedure
            dt = new DataTable();
            adp.Fill(dt);
            worksheet.Cells[0, 1].Value = "فرم پایش فالوآپ بيماران در کلینیک پرستاری آموزش سلامت درسه ماهه اول سال 1400 بیمارستان تخصصي چشم پزشكي خاتم الانبياء :";
            dt.Columns["FOLLOWUP_COUNT"].ColumnName = " تعداد بيماران فالوآپ شده گلوکوم و پيوند قرنيه";
            dt.Columns["FOLLOW_UP_PERCENT"].ColumnName = "درصد بيماران فالوآپ شده";
            dt.Columns["READMITION_COUNT"].ColumnName = "تعداد بستري مجدد ";
            dt.Columns["READMITION_PERCENT"].ColumnName = "درصد بستري مجدد";
            dt.Columns["REFER_DOC_COUNT"].ColumnName = "تعداد بيماران ارجاع به پزشك";
            dt.Columns["REFER_DOC_PERCENT"].ColumnName = "درصد بيماران ارجاع به پزشك";
            
            
            // Insert DataTable to an Excel worksheet.
            worksheet.InsertDataTable(dt,
                new InsertDataTableOptions()
                {
                    ColumnHeaders = true,
                    StartRow = 2
                });
            worksheet.ViewOptions.ShowColumnsFromRightToLeft = true;   //layout right to left
            SaveFileDialog sf = new SaveFileDialog();
            // Feed the dummy name to the save dialog
            sf.FileName = "FollowUp_Report";
            string savePath = "";
            if (sf.ShowDialog() == DialogResult.OK)
            {
                // Now here's our save folder
                savePath = Path.GetDirectoryName(sf.FileName);
            }
            // Create the Excel worksheet from the data set
            try
            {
                workbook.Save(savePath+ "FollowUp_Report.xlsx");
                MessageBox.Show("فایل اکسل با موفقیت در محل انتخاب شده به آدرس زیر ذخیره گردید. \n" + savePath,"",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
            }

            catch (Exception ex)
            {
                MessageBox.Show("ذخیره فایل اکسل با خطا مواجه شده است. \n اگر فایل اکسل از قبل باز هست لطفا ابتدا فایل را ببندید سپس امتحان بفرمایید. \n" + ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            con.Close();
        }

        private void BtnShow_Data_Click(object sender, EventArgs e)
        {
            if (txtTotalNum.TextLength == 0)
            {
                MessageBox.Show("لطفا تعداد کل بیماران را وارد نمایید.");
                return;
            }
            Dgv_Load(txtYear.Text+"/"+ cmbmonth.Text.Substring(0, 2), Convert.ToInt32(txtTotalNum.Text));

        }

        void Dgv_Load(string YearMonth,int Total_Num)
        {
            SqlDataAdapter adp = new SqlDataAdapter();
            con.Open();
            DataSet ds = new DataSet();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "SP_FOLLOW_UP_REPORT \'"+ YearMonth + "\',"+ Total_Num;

            adp.Fill(ds, "Report");

            radGvReport.DataSource = ds;
            radGvReport.DataMember = "Report";
            Convert_column_name(radGvReport);
            con.Close();
        }

        private void Convert_column_name(RadGridView radGvReport)
        {
            radGvReport.Columns["FOLLOWUP_COUNT"].HeaderText = " تعداد بيماران فالوآپ شده";
            radGvReport.Columns["FOLLOWUP_COUNT"].Width = 80;
            radGvReport.Columns["FOLLOWUP_COUNT"].WrapText = true;
            radGvReport.Columns["FOLLOWUP_COUNT"].TextAlignment = ContentAlignment.MiddleCenter;

            radGvReport.Columns["FOLLOW_UP_PERCENT"].HeaderText = "درصد بيماران فالوآپ شده";
            radGvReport.Columns["FOLLOW_UP_PERCENT"].Width = 80;
            radGvReport.Columns["FOLLOW_UP_PERCENT"].WrapText = true;
            radGvReport.Columns["FOLLOW_UP_PERCENT"].TextAlignment = ContentAlignment.MiddleCenter;

            radGvReport.Columns["READMITION_COUNT"].HeaderText = "تعداد بستري مجدد";
            radGvReport.Columns["READMITION_COUNT"].Width = 80;
            radGvReport.Columns["READMITION_COUNT"].WrapText = true;
            radGvReport.Columns["READMITION_COUNT"].TextAlignment = ContentAlignment.MiddleCenter;

            radGvReport.Columns["READMITION_PERCENT"].HeaderText = "درصد بستري مجدد";
            radGvReport.Columns["READMITION_PERCENT"].Width = 80;
            radGvReport.Columns["READMITION_PERCENT"].WrapText = true;
            radGvReport.Columns["READMITION_PERCENT"].TextAlignment = ContentAlignment.MiddleCenter;

            radGvReport.Columns["REFER_DOC_COUNT"].HeaderText = "تعداد بيماران ارجاع به پزشك";
            radGvReport.Columns["REFER_DOC_COUNT"].Width = 80;
            radGvReport.Columns["REFER_DOC_COUNT"].WrapText = true;
            radGvReport.Columns["REFER_DOC_COUNT"].TextAlignment = ContentAlignment.MiddleCenter;

            radGvReport.Columns["REFER_DOC_PERCENT"].HeaderText = "درصد بيماران ارجاع به پزشك";
            radGvReport.Columns["REFER_DOC_PERCENT"].Width = 80;
            radGvReport.Columns["REFER_DOC_PERCENT"].WrapText = true;
            radGvReport.Columns["REFER_DOC_PERCENT"].TextAlignment = ContentAlignment.MiddleCenter;
        }

        private void TxtTotalNum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //enter key is down
                if (txtTotalNum.TextLength == 0)
                {
                    MessageBox.Show("لطفا تعداد کل بیماران را وارد نمایید.");
                    return;
                }
                Dgv_Load(txtYear.Text + "/" + cmbmonth.Text.Substring(0, 2), Convert.ToInt32(txtTotalNum.Text));
            }
        }

        private void FrmReport_Load(object sender, EventArgs e)
        {
            
            txtYear.Text = p.GetYear(DateTime.Now).ToString();
            cmbmonth.SelectedIndex= p.GetMonth(DateTime.Now) - 1;

        }

        private void BtnReport_Click(object sender, EventArgs e)
        {

        }

        private void Btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}

