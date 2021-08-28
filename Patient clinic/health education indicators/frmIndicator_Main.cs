using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Patient_clinic.health_education_indicators
{
    public partial class frmIndicator_Main : Form
    {

        SqlConnection con = Program.CreateConnection();  //new SqlConnection("Data Source =(local) ; initial catalog = Health_clinic ; integrated security=true"); //Program.CreateConnection();
        SqlCommand cmd = new SqlCommand();
        public frmIndicator_Main()
        {
            InitializeComponent();
        }

        private void Btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btnshowform_Click(object sender, EventArgs e)
        {
            frmQuestions frmQuestions = new frmQuestions( cmbForms.Text,Convert.ToInt32(cmbForms.SelectedValue),cmbreftype.Text, Convert.ToInt32(cmbreftype.SelectedValue));
            frmQuestions.ShowDialog();
        }

        void Load_Default_Value()
        {
            con.Open();
            //Section combobox
            string query = "SELECT [Id],[Name]  FROM [dbo].[MI_Sections]";
            SqlDataAdapter da = new SqlDataAdapter(query, con);

            DataSet ds = new DataSet();
            da.Fill(ds, "Sections");
            cmbreftype.DisplayMember = "Name";
            cmbreftype.ValueMember = "Id";
            cmbreftype.DataSource = ds.Tables["Sections"];
            //cmbSurgeryType.SelectedIndex = 0;

            //Forms combobox
            query = "SELECT [Id],[Name],[KeyWords_name]  FROM [dbo].[MI_Forms]";
            da = new SqlDataAdapter(query, con);
            da.Fill(ds, "Forms");
            cmbForms.DisplayMember = "Name";
            cmbForms.ValueMember = "Id";
            cmbForms.DataSource = ds.Tables["Forms"];




            con.Close();
        }

        private void FrmIndicator_Main_Load(object sender, EventArgs e)
        {
            Load_Default_Value();

        }

        private void ButtonX2_Click(object sender, EventArgs e)
        {
            frmReport_EI frmReport_EI = new frmReport_EI(cmbForms.Text, Convert.ToInt32(cmbForms.SelectedValue), cmbreftype.Text, Convert.ToInt32(cmbreftype.SelectedValue));
            frmReport_EI.ShowDialog();
        }
    }
}
