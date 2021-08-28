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
using Excel = Microsoft.Office.Interop.Excel;

namespace Patient_clinic
{
    public partial class frmshowdata : Form
    {
        public frmshowdata()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source = (Local);initial catalog =Health_clinic ; integrated security=true");
        SqlCommand cmd = new SqlCommand();

        private void Frmshowdata_Load(object sender, EventArgs e)
        {
            Dgv_load();
        }
        void Dgv_load()
        {
            SqlDataAdapter adp = new SqlDataAdapter();
            con.Open();
            DataSet ds = new DataSet();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "SELECT * FROM[dbo].[Patients]";
            adp.Fill(ds, "Patients");
            dgvList.DataSource = ds;
            dgvList.DataMember = "Patients";
            Convert_column_name(dgvList);



            con.Close();

        }
        void Convert_column_name(DataGridView dgvList)
        {
            dgvList.Columns["First_name"].HeaderText = "نام";
            dgvList.Columns["Last_name"].HeaderText = "نام خانوادگی";
            dgvList.Columns["national_code"].HeaderText = "کد ملی";
            dgvList.Columns["Year_Birth_date"].HeaderText = "سال تولد";
            dgvList.Columns["Age"].HeaderText = "سن";
            dgvList.Columns["Tel"].HeaderText = "تلفن";
            dgvList.Columns["Diagnose"].HeaderText = "تشخیص";
            dgvList.Columns["History"].HeaderText = "سابقه بیماری";
            dgvList.Columns["Doctor"].HeaderText = "پزشک معالج";
            dgvList.Columns["Insurance_type"].HeaderText = "بیمه";
            dgvList.Columns["Education"].HeaderText = "تحصیلات";
            dgvList.Columns["Patient_partner"].HeaderText = "همراهی بیمار";
            dgvList.Columns["Ref_Date"].HeaderText = "تاریخ مراجعه";
            dgvList.Columns["Learn_asses"].HeaderText = "ارزیابی آموزش";
            dgvList.Columns["Instructor_name"].HeaderText = "آموزش دهنده";
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
        public static DataGridViewRow SelectedRow { get; set; }
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



        }

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
            if (SelectedRow is null)
            {
                MessageBox.Show("سطر مورد نظر را ابتدا انتخاب بفرمایید..");
                return;

            }
            con.Open();
            try
                {

                cmd.Connection = con;
                cmd.Parameters.Clear();
                cmd.CommandText = "DELETE FROM [dbo].[Patients]" +
                                 " WHERE national_code=@national_code and ref_turn = @Ref_turn";

                cmd.Parameters.AddWithValue("@national_code", SelectedRow.Cells["national_code"].Value.ToString());

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

        /*
         * BtnExcel_Click
         * 
        private void copyAlltoClipboard()
        {
            dgvList.SelectAll();
            DataObject dataObj = dgvList.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }
        private void BtnExcel_Click(object sender, EventArgs e)
        {
            copyAlltoClipboard();
            Microsoft.Office.Interop.Excel.Application xlexcel;
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            xlexcel = new Excel.Application();
            xlexcel.Visible = true;
            xlWorkBook = xlexcel.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            Excel.Range CR = (Excel.Range)xlWorkSheet.Cells[1, 1];
            CR.Select();
            xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
        }*/
    }
}