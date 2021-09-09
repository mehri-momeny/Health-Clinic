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

namespace Patient_clinic
{
    public partial class frmClinicReport : Form
    {
        SqlConnection con = Program.CreateConnection();//new SqlConnection("Data Source =. ;initial catalog =Health_clinic ; integrated security=true"); //Program.CreateConnection();
        SqlCommand cmd = new SqlCommand();
        PersianCalendar p = new PersianCalendar();
        public frmClinicReport()
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
            adp = new SqlDataAdapter("SP_PAYESH_Clinic \'" + YearMonth + "\'," + txtTotalNum.Text, con);  //call Stored Procedure
            dt = new DataTable();
            adp.Fill(dt);
            worksheet.Cells[0, 1].Value = "فرم پایش کلینیک های پرستاری آموزش سلامت در سال 1400 بیمارستان تخصصی چشم پزشکی خاتم الانبیاء (ص) مشهد :";
            #region ColumnName
            dt.Columns["Patient_Count"].ColumnName = "تعداد کل مراجعین ";
            dt.Columns["Patient_PERCENT"].ColumnName = " نسبت تعداد مراجعین به کلینیک پرستاری به کل بیماران مراجعه کننده به درمانگاه درشیفت های فعالیت کلینیک";
           dt.Columns["IHD_count"].ColumnName = "تعداد بیماران قلبی ";
            dt.Columns["IHD_PERCENT"].ColumnName = "درصد بیماران قلبی";
            dt.Columns["DM_count"].ColumnName = "تعداد بیماران دیابتی";
            dt.Columns["DM_PERCENT"].ColumnName = "درصد بیماران دیابتی";
            dt.Columns["HTN_count"].ColumnName = "تعداد بیماران فشارخون بالا ";
            dt.Columns["HTN_PERCENT"].ColumnName = "درصد بیماران فشارخون بالا ";
            dt.Columns["Asthma_count"].ColumnName = "تعداد بیماران تنفسی";
            dt.Columns["Asthma_PERCENT"].ColumnName = "درصد بیماران تنفسی";
            dt.Columns["HLP_count"].ColumnName = "تعداد بیماران چربی خون بالا  ";
            dt.Columns["HLP_PERCENT"].ColumnName = "درصد بیماران چربی خون بالا ";
            dt.Columns["Cancer_count"].ColumnName = "تعداد بیماران کانسری";
            dt.Columns["Cancer_PERCENT"].ColumnName = "درصد بیماران کانسری";
            dt.Columns["Mother_count"].ColumnName = "تعداد زنان باردار و شیر ده";
            dt.Columns["Mother_PERCENT"].ColumnName = "درصد زنان باردار و شیر ده";
            dt.Columns["Other_Dis_Count"].ColumnName = "تعداد سایر بیماری ها";
            dt.Columns["Other_Dis_PERCENT"].ColumnName = "درصد سایر بیماری ها";
            dt.Columns["Doc_Ref_count"].ColumnName = "تعداد ارجاع از پزشک به کلینیک";
            dt.Columns["Doc_Ref_PERCENT"].ColumnName = "درصد ارجاع از پزشک به کلینیک ";
            dt.Columns["Dep_Ref_count"].ColumnName = "تعداد ارجاع از بخش ";
            dt.Columns["Dep_Ref_PERCENT"].ColumnName = "درصد ارجاع از بخش ";

            #endregion
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
            sf.FileName = "Clinic_Report";
            string savePath = "";
            if (sf.ShowDialog() == DialogResult.OK)
            {
                // Now here's our save folder
                savePath = Path.GetDirectoryName(sf.FileName);
            }
            // Create the Excel worksheet from the data set
            try
            {
                workbook.Save(savePath + "Clinic_Report.xlsx");
                MessageBox.Show("فایل اکسل با موفقیت در محل انتخاب شده به آدرس زیر ذخیره گردید. \n" + savePath, "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
            Dgv_Load(txtYear.Text + "/" + cmbmonth.Text.Substring(0, 2), Convert.ToInt32(txtTotalNum.Text));

        }

        void Dgv_Load(string YearMonth, int Total_Num)
        {
            SqlDataAdapter adp = new SqlDataAdapter();
            con.Open();
            DataSet ds = new DataSet();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "SP_PAYESH_Clinic \'" + YearMonth + "\'," + Total_Num;

            adp.Fill(ds, "Report");

            radGvReport.DataSource = ds;
            radGvReport.DataMember = "Report";
            Convert_column_name(radGvReport);
            con.Close();
        }

        private void Convert_column_name(RadGridView radGvReport)
        {

            radGvReport.Columns["Patient_Count"].HeaderText = "تعداد کل مراجعین";
            radGvReport.Columns["Patient_Count"].Width = 80;
            radGvReport.Columns["Patient_Count"].WrapText = true;
            radGvReport.Columns["Patient_Count"].TextAlignment = ContentAlignment.MiddleCenter;

            radGvReport.Columns["Patient_PERCENT"].HeaderText = "نسبت تعداد مراجعین به کلینیک پرستاری به کل بیماران مراجعه کننده به درمانگاه درشیفت های فعالیت کلینیک";
            radGvReport.Columns["Patient_PERCENT"].Width = 80;
            radGvReport.Columns["Patient_PERCENT"].WrapText = true;
            radGvReport.Columns["Patient_PERCENT"].TextAlignment = ContentAlignment.MiddleCenter;

            radGvReport.Columns["IHD_count"].HeaderText = "تعداد بیماران قلبی";
            radGvReport.Columns["IHD_count"].Width = 80;
            radGvReport.Columns["IHD_count"].WrapText = true;
            radGvReport.Columns["IHD_count"].TextAlignment = ContentAlignment.MiddleCenter;

            radGvReport.Columns["IHD_PERCENT"].HeaderText = "درصد بیماران قلبی";
            radGvReport.Columns["IHD_PERCENT"].Width = 80;
            radGvReport.Columns["IHD_PERCENT"].WrapText = true;
            radGvReport.Columns["IHD_PERCENT"].TextAlignment = ContentAlignment.MiddleCenter;

            radGvReport.Columns["DM_count"].HeaderText = "تعداد بیماران دیابتی";
            radGvReport.Columns["DM_count"].Width = 80;
            radGvReport.Columns["DM_count"].WrapText = true;
            radGvReport.Columns["DM_count"].TextAlignment = ContentAlignment.MiddleCenter;

            radGvReport.Columns["DM_PERCENT"].HeaderText = "درصد بیماران دیابتی";
            radGvReport.Columns["DM_PERCENT"].Width = 80;
            radGvReport.Columns["DM_PERCENT"].WrapText = true;
            radGvReport.Columns["DM_PERCENT"].TextAlignment = ContentAlignment.MiddleCenter;


            radGvReport.Columns["HTN_count"].HeaderText = "تعداد بیماران فشارخون بالا";
            radGvReport.Columns["HTN_count"].Width = 80;
            radGvReport.Columns["HTN_count"].WrapText = true;
            radGvReport.Columns["HTN_count"].TextAlignment = ContentAlignment.MiddleCenter;

            radGvReport.Columns["HTN_PERCENT"].HeaderText = "درصد بیماران فشارخون بالا";
            radGvReport.Columns["HTN_PERCENT"].Width = 80;
            radGvReport.Columns["HTN_PERCENT"].WrapText = true;
            radGvReport.Columns["HTN_PERCENT"].TextAlignment = ContentAlignment.MiddleCenter;

            radGvReport.Columns["Asthma_count"].HeaderText = "تعداد بیماران تنفسی";
            radGvReport.Columns["Asthma_count"].Width = 80;
            radGvReport.Columns["Asthma_count"].WrapText = true;
            radGvReport.Columns["Asthma_count"].TextAlignment = ContentAlignment.MiddleCenter;

            radGvReport.Columns["Asthma_PERCENT"].HeaderText = "درصد بیماران تنفسی";
            radGvReport.Columns["Asthma_PERCENT"].Width = 80;
            radGvReport.Columns["Asthma_PERCENT"].WrapText = true;
            radGvReport.Columns["Asthma_PERCENT"].TextAlignment = ContentAlignment.MiddleCenter;

            radGvReport.Columns["HLP_count"].HeaderText = "تعداد بیماران چربی خون بالا";
            radGvReport.Columns["HLP_count"].Width = 80;
            radGvReport.Columns["HLP_count"].WrapText = true;
            radGvReport.Columns["HLP_count"].TextAlignment = ContentAlignment.MiddleCenter;

            radGvReport.Columns["HLP_PERCENT"].HeaderText = "درصد بیماران چربی خون بالا";
            radGvReport.Columns["HLP_PERCENT"].Width = 80;
            radGvReport.Columns["HLP_PERCENT"].WrapText = true;
            radGvReport.Columns["HLP_PERCENT"].TextAlignment = ContentAlignment.MiddleCenter;

            radGvReport.Columns["Cancer_count"].HeaderText = "تعداد بیماران کانسری";
            radGvReport.Columns["Cancer_count"].Width = 80;
            radGvReport.Columns["Cancer_count"].WrapText = true;
            radGvReport.Columns["Cancer_count"].TextAlignment = ContentAlignment.MiddleCenter;

            radGvReport.Columns["Cancer_PERCENT"].HeaderText = "درصد بیماران کانسری";
            radGvReport.Columns["Cancer_PERCENT"].Width = 80;
            radGvReport.Columns["Cancer_PERCENT"].WrapText = true;
            radGvReport.Columns["Cancer_PERCENT"].TextAlignment = ContentAlignment.MiddleCenter;

            radGvReport.Columns["Mother_count"].HeaderText = "تعداد زنان باردار و شیر ده";
            radGvReport.Columns["Mother_count"].Width = 80;
            radGvReport.Columns["Mother_count"].WrapText = true;
            radGvReport.Columns["Mother_count"].TextAlignment = ContentAlignment.MiddleCenter;

            radGvReport.Columns["Mother_PERCENT"].HeaderText = "درصد زنان باردار و شیر ده";
            radGvReport.Columns["Mother_PERCENT"].Width = 80;
            radGvReport.Columns["Mother_PERCENT"].WrapText = true;
            radGvReport.Columns["Mother_PERCENT"].TextAlignment = ContentAlignment.MiddleCenter;


            radGvReport.Columns["Other_Dis_Count"].HeaderText = "تعداد سایر بیماری ها";
            radGvReport.Columns["Other_Dis_Count"].Width = 80;
            radGvReport.Columns["Other_Dis_Count"].WrapText = true;
            radGvReport.Columns["Other_Dis_Count"].TextAlignment = ContentAlignment.MiddleCenter;

            radGvReport.Columns["Other_Dis_PERCENT"].HeaderText = "درصد سایر بیماری ها";
            radGvReport.Columns["Other_Dis_PERCENT"].Width = 80;
            radGvReport.Columns["Other_Dis_PERCENT"].WrapText = true;
            radGvReport.Columns["Other_Dis_PERCENT"].TextAlignment = ContentAlignment.MiddleCenter;

            radGvReport.Columns["Doc_Ref_count"].HeaderText = "تعداد ارجاع از پزشک به کلینیک";
            radGvReport.Columns["Doc_Ref_count"].Width = 80;
            radGvReport.Columns["Doc_Ref_count"].WrapText = true;
            radGvReport.Columns["Doc_Ref_count"].TextAlignment = ContentAlignment.MiddleCenter;

            radGvReport.Columns["Doc_Ref_PERCENT"].HeaderText = "درصد ارجاع از پزشک به کلینیک";
            radGvReport.Columns["Doc_Ref_PERCENT"].Width = 80;
            radGvReport.Columns["Doc_Ref_PERCENT"].WrapText = true;
            radGvReport.Columns["Doc_Ref_PERCENT"].TextAlignment = ContentAlignment.MiddleCenter;

            radGvReport.Columns["Dep_Ref_count"].HeaderText = "تعداد ارجاع از بخش";
            radGvReport.Columns["Dep_Ref_count"].Width = 80;
            radGvReport.Columns["Dep_Ref_count"].WrapText = true;
            radGvReport.Columns["Dep_Ref_count"].TextAlignment = ContentAlignment.MiddleCenter;


            radGvReport.Columns["Dep_Ref_PERCENT"].HeaderText = "درصد ارجاع از بخش";
            radGvReport.Columns["Dep_Ref_PERCENT"].Width = 80;
            radGvReport.Columns["Dep_Ref_PERCENT"].WrapText = true;
            radGvReport.Columns["Dep_Ref_PERCENT"].TextAlignment = ContentAlignment.MiddleCenter;
            


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
            cmbmonth.SelectedIndex = p.GetMonth(DateTime.Now) - 1;

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

