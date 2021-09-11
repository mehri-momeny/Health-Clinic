using GemBox.Spreadsheet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace Patient_clinic
{
    public partial class FrmFollowList : Form
    {
        SqlConnection con = Program.CreateConnection();//new SqlConnection("Data Source =. ;initial catalog =Health_clinic ; integrated security=true"); //Program.CreateConnection();
        SqlCommand cmd = new SqlCommand();
        //string Today = Main_Functions.Get_Today_Shamsi();
        System.Globalization.PersianCalendar p = new System.Globalization.PersianCalendar();
        bool Active_Item = false;
        //DataTable Surgeries_Datatable = new DataTable();
        public static GridViewRowInfo SelectedRow { get; set; }
        public FrmFollowList()
        {
            InitializeComponent();

            this.radGVFollow_List.TableElement.RowHeight = 35;
        }

        //void Load_ComboBoxes_Datasources()
        //{
        //    con.Open();
        //    //Diagnose combobox
        //    string query = "SELECT [Id],[Name]  FROM [dbo].[MI_Surgery_type]";
        //    SqlDataAdapter da = new SqlDataAdapter(query, con);

        //    DataSet ds = new DataSet();
        //    da.Fill(ds, "Surgery");
        //    con.Close();
        //    Surgeries_Datatable = ds.Tables["Surgery"];
        //}

        void Dgv_load(string StartDate, string EndDate)
        {

            SqlDataAdapter adp = new SqlDataAdapter();
            con.Open();
            DataSet ds = new DataSet();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            if (Active_Item)
            {

                adp.SelectCommand.CommandText = "SELECT PCD.*,FL.FOLLOWUP_DATE, " +
                                                "  CASE " +
                                                "    WHEN FL.FLAG = -1 THEN 'ناموفق' " +
                                                "    WHEN FL.FLAG = 1 THEN 'موفق' " +
                                                "    WHEN FL.FLAG = 2 THEN 'تکرار در تاریخ دیگر' " +
                                                "    ELSE 'در صف پیگیری' " +
                                                "  END FLAG_TITLE ,FLAG, FL.Follow_turn " +
                                                "FROM[FU_FOLLOW_LIST] FL " +
                                                "JOIN(SELECT PD.*, PC.FOLLOW_ID, PC.ADMITION_DATE, PC.DISCHARGE_DATE, PC.ARCHIVE_NUMBER, PC.DOC_NAME, PC.REF_TURN, S.Name AS SURGERY_TYPE " +
                                                "             FROM FU_PATIENT_DEMOGRAPHIC PD " +
                                                "               INNER JOIN FU_FOLLOW_PATIENT_CLINICAL PC  ON PD.PATIENT_ID = PC.PATIENT_ID " +
                                                "               JOIN MI_Surgery_type S ON PC.Surgery_Type = S.Id) PCD   ON PCD.PATIENT_ID = FL.PATIENT_ID AND PCD.FOLLOW_ID = FL.FOLLOW_ID " +
                                                "WHERE FL.FOLLOWUP_DATE  between  \'" + StartDate + "\' and \'" + EndDate + "\' AND FL.FLAG = 0";

                //adp.SelectCommand.CommandText = "SELECT PCD.*,FL.FOLLOWUP_DATE,FL.FLAG,FL.Follow_turn FROM[FU_FOLLOW_LIST] FL " +
                //                         "JOIN " +
                //                         "    (SELECT PD.*, PC.FOLLOW_ID, PC.ADMITION_DATE, PC.DISCHARGE_DATE, PC.ARCHIVE_NUMBER, PC.DOC_NAME, PC.REF_TURN, PC.SURGERY_TYPE " +
                //                         "     FROM FU_PATIENT_DEMOGRAPHIC PD " +
                //                         "     INNER JOIN FU_FOLLOW_PATIENT_CLINICAL PC " +
                //                         "     ON PD.PATIENT_ID = PC.PATIENT_ID) PCD " +
                //                         "  ON PCD.PATIENT_ID = FL.PATIENT_ID AND PCD.FOLLOW_ID = FL.FOLLOW_ID " +
                //                         "WHERE FL.FOLLOWUP_DATE between  \'" + StartDate + "\' and \'" + EndDate + "\' AND FL.FLAG = 0";

                adp.Fill(ds, "Patients");
            }
            else
            {

                adp.SelectCommand.CommandText = "SELECT PCD.*,FL.FOLLOWUP_DATE, " +
                                                "  CASE " +
                                                "    WHEN FL.FLAG = -1 THEN 'ناموفق' " +
                                                "    WHEN FL.FLAG = 1 THEN 'موفق' " +
                                                "    WHEN FL.FLAG = 2 THEN 'تکرار در تاریخ دیگر' " +
                                                "    ELSE 'در صف پیگیری' " +
                                                "  END FLAG_TITLE ,FLAG, FL.Follow_turn " +
                                                "FROM[FU_FOLLOW_LIST] FL " +
                                                "JOIN(SELECT PD.*, PC.FOLLOW_ID, PC.ADMITION_DATE, PC.DISCHARGE_DATE, PC.ARCHIVE_NUMBER, PC.DOC_NAME, PC.REF_TURN, S.Name AS SURGERY_TYPE " +
                                                "             FROM FU_PATIENT_DEMOGRAPHIC PD " +
                                                "               INNER JOIN FU_FOLLOW_PATIENT_CLINICAL PC  ON PD.PATIENT_ID = PC.PATIENT_ID " +
                                                "               JOIN MI_Surgery_type S ON PC.Surgery_Type = S.Id) PCD   ON PCD.PATIENT_ID = FL.PATIENT_ID AND PCD.FOLLOW_ID = FL.FOLLOW_ID " +
                                                "WHERE FL.FOLLOWUP_DATE  between  \'" + StartDate + "\' and \'" + EndDate + "\'";


                //adp.SelectCommand.CommandText = "SELECT PCD.*,FL.FOLLOWUP_DATE,FL.FLAG,FL.Follow_turn FROM[FU_FOLLOW_LIST] FL " +
                //                         "JOIN " +
                //                         "    (SELECT PD.*, PC.FOLLOW_ID, PC.ADMITION_DATE, PC.DISCHARGE_DATE, PC.ARCHIVE_NUMBER, PC.DOC_NAME, PC.REF_TURN, PC.SURGERY_TYPE " +
                //                         "     FROM FU_PATIENT_DEMOGRAPHIC PD " +
                //                         "     INNER JOIN FU_FOLLOW_PATIENT_CLINICAL PC " +
                //                         "     ON PD.PATIENT_ID = PC.PATIENT_ID) PCD " +
                //                         "  ON PCD.PATIENT_ID = FL.PATIENT_ID AND PCD.FOLLOW_ID = FL.FOLLOW_ID " +
                //                         "WHERE FL.FOLLOWUP_DATE  between  \'" + StartDate + "\' and \'" + EndDate + "\'";

                adp.Fill(ds, "Patients");
            }
            radGVFollow_List.DataSource = ds;
            radGVFollow_List.DataMember = "Patients";
            Convert_column_name(radGVFollow_List);
            radGVFollow_List.Columns["FLAG"].IsVisible = false;
            radGVFollow_List.Columns["InsertLog"].IsVisible = false;
            con.Close();

        }

        //---------Telerik Component------------/////


        private void RadGVFollow_List_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            if (this.radGVFollow_List.DataMember != "")
            {
                UpdatePanelInfo(this.radGVFollow_List.CurrentRow);
                change_selected_row(this.radGVFollow_List.CurrentRow);
            }

        }

        private void UpdatePanelInfo(GridViewRowInfo currentRow)
        {
            if (currentRow != null && !(currentRow is GridViewNewRowInfo))
            {
                this.radtxtName.Text = Main_Functions.GetSafeString(currentRow.Cells["First_name"].Value + " " + currentRow.Cells["Last_name"].Value);
                this.radtxtNational_Code.Text = Main_Functions.GetSafeString(currentRow.Cells["national_code"].Value);
                this.radTxtAge.Text = (p.GetYear(DateTime.Now) - Convert.ToInt32(currentRow.Cells["Year_Birth_date"].Value)).ToString();
                this.radTxtSurgery_type.Text = currentRow.Cells["Surgery_Type"].Value.ToString();
                    //Surgeries_Datatable.Select("Id =" + Convert.ToInt32(currentRow.Cells["Surgery_Type"].Value))[0][1].ToString();
                //if (Convert.ToInt32(currentRow.Cells["Surgery_Type"].Value) == 1)
                //{
                //    this.radTxtSurgery_type.Text = "پیوند قرنیه";
                //}
                //else if (Convert.ToInt32(currentRow.Cells["Surgery_Type"].Value) == 2)
                //{
                //    this.radTxtSurgery_type.Text = "گلوکوم حاد";
                //}

                this.radtxtFollowDate.Text = Main_Functions.GetSafeString(currentRow.Cells["FOLLOWUP_DATE"].Value);
                this.radTxtTel.Text = Main_Functions.GetSafeString(currentRow.Cells["Tel"].Value);

                switch (Main_Functions.GetSafeString(currentRow.Cells["Flag"].Value))
                {
                    case "-1":
                        {
                            radTxtResult.Text = "ناموفق";
                            this.radPanel1.BackColor = Color.LightPink;
                            break;
                        }
                    case "1":
                        {
                            radTxtResult.Text = "موفق";
                            this.radPanel1.BackColor = Color.LightGreen;
                            break;
                        }
                    case "2":
                        {
                            radTxtResult.Text = "تکرار در تاریخ دیگر";
                            this.radPanel1.BackColor = Color.LightBlue;
                            break;
                        }
                    case "0":
                        {
                            this.radPanel1.BackgroundImage = new Bitmap(10, 10);
                            this.radPanel1.BackColor = Color.Transparent;
                            radTxtResult.Text = "";
                            break;
                        }
                        //default:
                        //    radTxtResult.Text = "";
                }

                //string salesPerson = this.GetSafeString(currentRow.Cells["SalesRepresentative"].Value);

                //if (!string.IsNullOrEmpty(salesPerson.Trim()))
                //{
                //    this.radComboBox1.SelectedIndex = this.radComboBox1.FindString(salesPerson);
                //}
                //else
                //{
                //    this.radComboBox1.SelectedIndex = -1;
                //    this.radComboBox1.Text = string.Empty;
                //}
            }
            else
            {
                this.radtxtName.Text = string.Empty;
                this.radtxtNational_Code.Text = string.Empty;
                this.radTxtSurgery_type.Text = string.Empty;
                this.radTxtTel.Text = string.Empty;
                this.radPanel1.BackgroundImage = new Bitmap(10, 10);
                this.radTxtResult.Text = string.Empty;
            }
        }

        void Convert_column_name(Telerik.WinControls.UI.RadGridView dgvList)
        {

            dgvList.Columns["Patient_ID"].HeaderText = "کد بیمار";
            dgvList.Columns["Patient_ID"].WrapText = true;
            dgvList.Columns["Patient_ID"].Width = 35;
            dgvList.Columns["First_name"].HeaderText = "نام";
            dgvList.Columns["First_name"].Width = 80;
            dgvList.Columns["Last_name"].HeaderText = "نام خانوادگی";
            dgvList.Columns["Last_name"].Width = 110;
            dgvList.Columns["national_code"].HeaderText = "کد ملی";
            dgvList.Columns["national_code"].Width = 80;
            dgvList.Columns["Year_Birth_date"].HeaderText = "تولد";
            dgvList.Columns["Year_Birth_date"].Width = 35;
            dgvList.Columns["Tel"].HeaderText = "تلفن";
            dgvList.Columns["Tel"].Width = 80;
            dgvList.Columns["Follow_ID"].HeaderText = "کد پیگیری";
            dgvList.Columns["Follow_ID"].Width = 40;
            dgvList.Columns["Follow_ID"].WrapText = true;
            dgvList.Columns["Archive_number"].HeaderText = "شماره پرونده";
            dgvList.Columns["Archive_number"].Width = 45;
            dgvList.Columns["Archive_number"].WrapText = true;
            dgvList.Columns["ref_turn"].HeaderText = "نوبت مراجعه";
            dgvList.Columns["ref_turn"].Width = 45;
            dgvList.Columns["ref_turn"].WrapText = true;
            dgvList.Columns["Doc_name"].HeaderText = "پزشک";
            dgvList.Columns["Doc_name"].Width = 75;
            dgvList.Columns["Admition_Date"].HeaderText = "تاریخ بستری";
            dgvList.Columns["Admition_Date"].Width = 75;
            dgvList.Columns["Discharge_Date"].HeaderText = "تاریخ نرخیص";
            dgvList.Columns["Discharge_Date"].Width = 75;
            dgvList.Columns["Surgery_Type"].HeaderText = "نوع عمل";
            dgvList.Columns["Surgery_Type"].WrapText = true;
            dgvList.Columns["Surgery_Type"].Width = 40;
            dgvList.Columns["FollowUp_Date"].HeaderText = "تاریخ پیگیری";
            dgvList.Columns["FollowUp_Date"].Width = 70;
            dgvList.Columns["Follow_turn"].HeaderText = "نوبت پیگیری";
            dgvList.Columns["Follow_turn"].Width = 40;
            dgvList.Columns["Follow_turn"].WrapText = true;
            dgvList.Columns["FLAG_TITLE"].HeaderText = "نتیجه";
            dgvList.Columns["FLAG_TITLE"].Width = 40;
        }
        //---------------//


        /*    void Convert_column_name(DataGridView dgvList)
            {

                dgvList.Columns["Patient_ID"].HeaderText = "کد بیمار";
                dgvList.Columns["Patient_ID"].Width = 45;
                dgvList.Columns["First_name"].HeaderText = "نام";
                dgvList.Columns["Last_name"].HeaderText = "نام خانوادگی";
                dgvList.Columns["national_code"].HeaderText = "کد ملی";
                dgvList.Columns["national_code"].Width = 80;
                dgvList.Columns["Age"].HeaderText = "سن";
                dgvList.Columns["Age"].Width = 40;
                dgvList.Columns["Tel"].HeaderText = "تلفن";
                dgvList.Columns["Tel"].Width = 75;
                dgvList.Columns["Follow_ID"].HeaderText = "کد پیگیری";
                dgvList.Columns["Follow_ID"].Width = 50;
                //dgvList.Columns["Archive_number"].HeaderText = "شماره پرونده";
                //dgvList.Columns["ref_turn"].HeaderText = "نوبت مراجعه";
                dgvList.Columns["Doc_name"].HeaderText = "پزشک";
                dgvList.Columns["Admition_Date"].HeaderText = "تاریخ بستری";
                dgvList.Columns["Admition_Date"].Width = 75;
                dgvList.Columns["Discharge_Date"].HeaderText = "تاریخ نرخیص";
                dgvList.Columns["Discharge_Date"].Width = 75;
                dgvList.Columns["Surgery_Type"].HeaderText = "نوع عمل";
                dgvList.Columns["Surgery_Type"].Width = 40;
                dgvList.Columns["FollowUp_Date"].HeaderText = "تاریخ پیگیری";
                dgvList.Columns["Flag"].HeaderText = "نتیجه";
                dgvList.Columns["Flag"].Width = 35;
            }

    */


        private void BtnNwRef_Click(object sender, EventArgs e)
        {
            if (SelectedRow is null)
            {
                MessageBox.Show("سطر مورد نظر را ابتدا انتخاب بفرمایید..");
                return;

            }
            else
            {
                FrmQueries frmQueries = new FrmQueries(int.Parse(SelectedRow.Cells["Surgery_Type"].Value.ToString()), SelectedRow.Cells["Patient_ID"].Value.ToString(), SelectedRow.Cells["Follow_ID"].Value.ToString(), SelectedRow.Cells["First_name"].Value.ToString() + " " + SelectedRow.Cells["Last_name"].Value.ToString(), (int)(SelectedRow.Cells["Follow_turn"].Value));  //مقدار دهی میشود بر اساس نوع فالوآپ
                frmQueries.ShowDialog();
                Dgv_load(bpcalDate.Text, bpCalUntil.Text);
                change_selected_row(this.radGVFollow_List.CurrentRow);
            }
        }

        private void Btnexit_Click(object sender, EventArgs e)
        {
            SelectedRow = null;
            this.Close();
        }

        private void change_selected_row(GridViewRowInfo gv)
        {
            SelectedRow = gv;
            if (!(gv is null))
            {
                switch (Main_Functions.GetSafeString(gv.Cells["FLAG"].Value))
                {
                    case "-1":
                        {
                            btnFailedCall.Enabled = false;
                            btnNwRef.Enabled = false;
                            BtnChangeDate.Enabled = true;
                            break;
                        }
                    case "0":
                        {
                            BtnChangeDate.Enabled = true;
                            btnFailedCall.Enabled = true;
                            btnNwRef.Enabled = true;
                            break;
                        }
                    default:
                        {
                            BtnChangeDate.Enabled = false;
                            btnFailedCall.Enabled = false;
                            btnNwRef.Enabled = false;
                            break;
                        }

                        //default:
                        //    radTxtResult.Text = "";
                }

            }
            //if (!(gv is null) && this.GetSafeString(gv.Cells["FLAG"].Value) == "0")
            //{

            //}
            //else if (!(gv is null) && this.GetSafeString(gv.Cells["FLAG"].Value) == "2")
            //{

            //}
            //else
            //{

            //}
        }

        private void FrmFollowList_Load(object sender, EventArgs e)
        {
            //Load_ComboBoxes_Datasources();
            bpcalDate.Today_Click(null, null);
            bpCalUntil.Today_Click(null, null);
            //Dgv_load(bpcalDate.Text);
            //change_selected_row(this.radGVFollow_List.CurrentRow);
            //SelectedRow = this.radGVFollow_List.CurrentRow;
        }
        /*
        private void TxtFirstnamesearch_TextChanged(object sender, EventArgs e)
        {
            DataTable dt;
            SqlDataAdapter adp;
            con.Open();
            adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            //adp = new SqlDataAdapter("select * from [dbo].[FollowUp_List] where First_Name like '" + txtFirstnamesearch.Text + "%' and " + " FollowUp_Date = \'" + bpcalDate.Text + "\'", con);
            adp.SelectCommand.CommandText = "SELECT Distinct PD.[Patient_ID],[First_name],[Last_name],[national_code]," + p.GetYear(DateTime.Now) + "-[Year_Birth_date] as Age,[Tel]" +
                                              ",PC.[Follow_ID],[Doc_name],[Admition_Date],[Discharge_Date],[Surgery_Type]" +
                                              ",[FollowUp_Date],[Flag]" +
                                              " FROM FU_Patient_Demographic PD,FU_Follow_Patient_Clinical PC,[FU_Follow_List] FL" +
                                              " WHERE PD.[Patient_ID] = PC.[Patient_ID] and PC.[Follow_ID] = FL.[Follow_ID]" +
                                              "AND FollowUp_Date =  \'" + bpcalDate.Text + "\' AND First_name like '" + txtFirstnamesearch.Text + "%' ";
            dt = new DataTable();
            adp.Fill(dt);
            dgvFollowList.DataSource = dt;
            Convert_column_name(dgvFollowList);
            con.Close();
        }

        private void Txtlastnamesearch_TextChanged(object sender, EventArgs e)
        {
            DataTable dt;
            SqlDataAdapter adp;
            con.Open();
            //adp = new SqlDataAdapter("select * from [dbo].[FollowUp_List] where Last_Name like '" + txtlastnamesearch.Text + "%' and " + " FollowUp_Date = \'" + bpcalDate.Text + "\'", con);
            adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "SELECT Distinct PD.[Patient_ID],[First_name],[Last_name],[national_code]," + p.GetYear(DateTime.Now) + "-[Year_Birth_date] as Age,[Tel]" +
                                         ",PC.[Follow_ID],[Doc_name],[Admition_Date],[Discharge_Date],[Surgery_Type]" +
                                         ",[FollowUp_Date],[Flag]" +
                                         " FROM FU_Patient_Demographic PD,FU_Follow_Patient_Clinical PC,[FU_Follow_List] FL" +
                                         " WHERE PD.[Patient_ID] = PC.[Patient_ID] and PC.[Follow_ID] = FL.[Follow_ID]" +
                                         "AND FollowUp_Date =  \'" + bpcalDate.Text + "\' AND Last_name like '" + txtlastnamesearch.Text + "%' ";
            dt = new DataTable();
            adp.Fill(dt);
            dgvFollowList.DataSource = dt;
            Convert_column_name(dgvFollowList);
            con.Close();
        }

        private void Txtnationalcodesearch_TextChanged(object sender, EventArgs e)
        {
            DataTable dt;
            SqlDataAdapter adp;
            con.Open();
            //adp = new SqlDataAdapter("select * from [dbo].[FollowUp_List] where national like '" + txtnationalcodesearch.Text + "%' and " + " FollowUp_Date = \'" + bpcalDate.Text + "\'", con);
            adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "SELECT Distinct PD.[Patient_ID],[First_name],[Last_name],[national_code]," + p.GetYear(DateTime.Now) + "-[Year_Birth_date] as Age,[Tel]" +
                                         ",PC.[Follow_ID],[Doc_name],[Admition_Date],[Discharge_Date],[Surgery_Type]" +
                                         ",[FollowUp_Date],[Flag]" +
                                         " FROM FU_Patient_Demographic PD,FU_Follow_Patient_Clinical PC,[FU_Follow_List] FL" +
                                         " WHERE PD.[Patient_ID] = PC.[Patient_ID] and PC.[Follow_ID] = FL.[Follow_ID]" +
                                         "AND FollowUp_Date =  \'" + bpcalDate.Text + "\' AND national_code like '" + txtnationalcodesearch.Text + "%' ";
            dt = new DataTable();
            adp.Fill(dt);
            dgvFollowList.DataSource = dt;
            Convert_column_name(dgvFollowList);
            con.Close();
        }
        */

        private void DgvFollowList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //Set the Selected Row in Property.
                change_selected_row(this.radGVFollow_List.CurrentRow);
                //SelectedRow = this.radGVFollow_List.CurrentRow;
            }
        }

        private void BpcalDate_TextChanged(object sender, EventArgs e)
        {
            Dgv_load(bpcalDate.Text, bpCalUntil.Text);
            change_selected_row(this.radGVFollow_List.CurrentRow);
            //SelectedRow = this.radGVFollow_List.CurrentRow;
        }

        private void RadGVFollow_List_SelectionChanged(object sender, EventArgs e)
        {
        }

        private void RadGVFollow_List_CellClick(object sender, GridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //Set the Selected Row in Property.
                change_selected_row(this.radGVFollow_List.CurrentRow);
                //SelectedRow = this.radGVFollow_List.CurrentRow;
            }
        }

        private void RadBtnSave_Click(object sender, EventArgs e)
        {

        }

        private void BtnChangeDate_Click(object sender, EventArgs e)
        {
            if (SelectedRow is null)
            {
                MessageBox.Show("سطر مورد نظر را ابتدا انتخاب بفرمایید..");
                return;

            }
            else
            {
                new frmNextDate(SelectedRow.Cells["Patient_ID"].Value.ToString(), SelectedRow.Cells["Follow_ID"].Value.ToString(), (int)(SelectedRow.Cells["Follow_turn"].Value)).ShowDialog();
                Dgv_load(bpcalDate.Text, bpCalUntil.Text);
                change_selected_row(this.radGVFollow_List.CurrentRow);

            }
        }

        private void BtnFailedCall_Click(object sender, EventArgs e)
        {
            if (SelectedRow is null)
            {
                MessageBox.Show("سطر مورد نظر را ابتدا انتخاب بفرمایید..");
                return;

            }
            else
            {
                if (MessageBox.Show("آیا از خاتمه پیگیری برای \"" + SelectedRow.Cells["First_name"].Value.ToString() + " " + SelectedRow.Cells["Last_name"].Value.ToString() + "\" اطمینان دارید؟", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.No)
                    return;
                try
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.Parameters.Clear();
                    cmd.CommandText = "UPDATE[dbo].[FU_Follow_List]   SET [Flag] = -1 WHERE [Patient_ID] =" + SelectedRow.Cells["Patient_ID"].Value + " AND [Follow_ID] =" + SelectedRow.Cells["Follow_ID"].Value + " AND [Follow_turn] =" + SelectedRow.Cells["Follow_turn"].Value;
                    cmd.ExecuteNonQuery();

                    con.Close();

                }
                catch (Exception ex)
                {

                    throw;
                }
                MessageBox.Show("ثبت شد.");
                Dgv_load(bpcalDate.Text, bpCalUntil.Text);
                change_selected_row(this.radGVFollow_List.CurrentRow);
                //UpdatePanelInfo(this.radGVFollow_List.CurrentRow);
            }
        }

        private void RadchbEnable_CheckStateChanged(object sender, EventArgs e)
        {
            if (radchbEnable.Checked == true)
            {
                Active_Item = true;
            }
            else
            {
                Active_Item = false;
            }
            Dgv_load(bpcalDate.Text, bpCalUntil.Text);
            change_selected_row(this.radGVFollow_List.CurrentRow);

        }

        private void RadGVFollow_List_RowFormatting(object sender, RowFormattingEventArgs e)
        {
            switch ((int)e.RowElement.RowInfo.Cells["FLAG"].Value)
            {
                case 0:
                    {
                        e.RowElement.ResetValue(LightVisualElement.BackColorProperty, ValueResetFlags.Local);
                        e.RowElement.ResetValue(LightVisualElement.GradientStyleProperty, ValueResetFlags.Local);
                        e.RowElement.ResetValue(LightVisualElement.DrawFillProperty, ValueResetFlags.Local);
                        break;
                    }
                case 1:
                    {
                        e.RowElement.DrawFill = true;
                        e.RowElement.GradientStyle = GradientStyles.Solid;
                        e.RowElement.BackColor = Color.LightGreen;
                        break;
                    }
                case -1:
                    {
                        e.RowElement.DrawFill = true;
                        e.RowElement.GradientStyle = GradientStyles.Solid;
                        e.RowElement.BackColor = Color.LightPink;
                        break;
                    }
                case 2:
                    {
                        e.RowElement.DrawFill = true;
                        e.RowElement.GradientStyle = GradientStyles.Solid;
                        e.RowElement.BackColor = Color.LightBlue;
                        break;
                    }
            }
        }

        private void Btnexcel_Click(object sender, EventArgs e)
        {
            frmReportRange frmReportRange = new frmReportRange();
            frmReportRange.ShowDialog();
            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter();
            if (Program.SavePath != "" && Program.DateRange != "")
            {
                SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");
                var workbook = new ExcelFile();
                var worksheet = workbook.Worksheets.Add("Follow_List");

                if (con.State == ConnectionState.Closed) con.Open();
                adp = new SqlDataAdapter("SELECT PCD.*,FL.FOLLOWUP_DATE, " +
                                                "  CASE " +
                                                "    WHEN FL.FLAG = -1 THEN 'ناموفق' " +
                                                "    WHEN FL.FLAG = 1 THEN 'موفق' " +
                                                "    WHEN FL.FLAG = 2 THEN 'تکرار در تاریخ دیگر' " +
                                                "    ELSE 'در صف پیگیری' " +
                                                "  END FLAG , FL.Follow_turn " +
                                                "FROM[FU_FOLLOW_LIST] FL " +
                                                "JOIN(SELECT PD.*, PC.FOLLOW_ID, PC.ADMITION_DATE, PC.DISCHARGE_DATE, PC.ARCHIVE_NUMBER, PC.DOC_NAME, PC.REF_TURN, S.Name AS SURGERY_TYPE " +
                                                "             FROM FU_PATIENT_DEMOGRAPHIC PD " +
                                                "               INNER JOIN FU_FOLLOW_PATIENT_CLINICAL PC  ON PD.PATIENT_ID = PC.PATIENT_ID " +
                                                "               JOIN MI_Surgery_type S ON PC.Surgery_Type = S.Id) PCD   ON PCD.PATIENT_ID = FL.PATIENT_ID AND PCD.FOLLOW_ID = FL.FOLLOW_ID " +
                                                "WHERE FL.FOLLOWUP_DATE  " + Program.DateRange, con);
                adp.Fill(dt);
                //dgvList.DataSource = dt;

                Excel_column_name(dt);
                // Insert DataTable to an Excel worksheet.
                worksheet.InsertDataTable(dt,
                    new InsertDataTableOptions()
                    {
                        ColumnHeaders = true,
                        StartRow = 0
                    });
                worksheet.ViewOptions.ShowColumnsFromRightToLeft = true;   //layout right to left


                #region Set Excel Column Option
                //worksheet.Columns[13].Width = 10000;
                //worksheet.Columns[13].AutoFit();

                #endregion


                try
                {
                    workbook.Save(Program.SavePath + "Follow_List_Report.xlsx");
                    MessageBox.Show("فایل اکسل با موفقیت در محل انتخاب شده به آدرس زیر ذخیره گردید. \n" + Program.SavePath, "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }

                catch (Exception ex)
                {
                    MessageBox.Show("ذخیره فایل اکسل با خطا مواجه شده است. \n اگر فایل اکسل از قبل باز هست لطفا ابتدا فایل را ببندید سپس امتحان بفرمایید. \n" + ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                con.Close();

            }
            else
            {
                MessageBox.Show("مشکلی پیش آمده است مجددا امتحان کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void Excel_column_name(DataTable dt)
        {
            dt.Columns["Patient_ID"].ColumnName = "کد بیمار";
            dt.Columns["First_name"].ColumnName = "نام";
            dt.Columns["Last_name"].ColumnName = "نام خانوادگی";
            dt.Columns["national_code"].ColumnName = "کد ملی";
            dt.Columns["Year_Birth_date"].ColumnName = "تولد";
            dt.Columns["Tel"].ColumnName = "تلفن";
            dt.Columns["Follow_ID"].ColumnName = "کد پیگیری";
            dt.Columns["Archive_number"].ColumnName = "شماره پرونده";
            dt.Columns["ref_turn"].ColumnName = "نوبت مراجعه";
            dt.Columns["Doc_name"].ColumnName = "پزشک";
            dt.Columns["Admition_Date"].ColumnName = "تاریخ بستری";
            dt.Columns["Discharge_Date"].ColumnName = "تاریخ نرخیص";
            dt.Columns["Surgery_Type"].ColumnName = "نوع عمل";
            dt.Columns["FollowUp_Date"].ColumnName = "تاریخ پیگیری";
            dt.Columns["Follow_turn"].ColumnName = "نوبت پیگیری";
            dt.Columns["Flag"].ColumnName = "نتیجه";

            //return dt;
        }
    }
}
