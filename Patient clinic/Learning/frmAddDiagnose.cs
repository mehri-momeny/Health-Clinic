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
    public partial class frmAddDiagnose : Form
    {
        SqlConnection con = Program.CreateConnection();//new SqlConnection("Data Source =(local) ; initial catalog = Health_clinic ; integrated security=true");
        SqlCommand cmd = new SqlCommand();
        bool EditForm = false;
        public frmAddDiagnose(int AddOrEdit)  // if this variable is 0 its Add Forms if its 1 this form as a editForm
        {
            if (AddOrEdit == 1)
                EditForm = true;
            InitializeComponent();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (EditForm)
            {
                try
                {
                    cmd.Connection = con;
                    cmd.Parameters.Clear();
                    cmd.CommandText = "UPDATE [dbo].[MI_Diagnose] SET [name] =@Title ,[abbreviation] =@Abb WHERE ID = @Code";
                    cmd.Parameters.AddWithValue("@Code", int.Parse(txtCode.Text));
                    cmd.Parameters.AddWithValue("@Title", txtTitle.Text);
                    cmd.Parameters.AddWithValue("@Abb", txtAbb.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ویرایش باخطا مواجه شد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);//+ ex.Message
                }

            }
            else
            {
                try
                {
                    cmd.Connection = con;
                    cmd.Parameters.Clear();
                    cmd.CommandText = "INSERT INTO [dbo].[MI_Diagnose]([ID],[name],[abbreviation]) " +
                                            "VALUES(@Code, @Title, @Abb)";
                    cmd.Parameters.AddWithValue("@Code", int.Parse(txtCode.Text));
                    cmd.Parameters.AddWithValue("@Title", txtTitle.Text);
                    cmd.Parameters.AddWithValue("@Abb", txtAbb.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("افزودن کد تشخیصی جدید با خطا مواجه شد٬ مجددا سعی نمایید\n دقت شود که کد تشخیصی نباید تکراری باشد \n", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);//+ ex.Message
                }
            }

        }

        private void FrmAddDiagnose_Load(object sender, EventArgs e)
        {
            if (EditForm)  //ویرایش
            {
                this.Text = "ویرایش عنوان تشخیصی";
                txtCode.Enabled = false;
                txtCode.Text = frm_Diagnoses.SelectedDiagnoseRow.Cells["ID"].Value.ToString();
                txtTitle.Text = frm_Diagnoses.SelectedDiagnoseRow.Cells["name"].Value.ToString();
                txtAbb.Text = frm_Diagnoses.SelectedDiagnoseRow.Cells["Abbreviation"].Value.ToString();
            }
            //else
            //{
            //}
        }
    }
}
