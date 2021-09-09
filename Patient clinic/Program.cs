using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;


namespace Patient_clinic
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new DataEntry());
            Application.Run(new FrmMain());
        }
        private static string _clinic_Name = "بیمارستان تخصصی چشم خاتم الانبیاء";
        public static string Clinic_Name
        {
            get { return _clinic_Name; }
            set { _clinic_Name = value; }
        }
        private static int _patient_ID = 0;
        public static int Patient_ID
        {
            get { return _patient_ID; }
            set { _patient_ID = value; }
        }
        private static string _DateRange="";
        public static string DateRange
        {
            get { return _DateRange; }
            set { _DateRange = value; }
        }
        private static string ـSavePath = "";
        public static string SavePath
        {
            get { return ـSavePath; }
            set { ـSavePath = value; }
        }

        private static int localConnettion = -1;
        public static string User_ID { get; private set; }
        public static string SrvAdd { get; private set; }

        public static SqlConnection CreateConnection()
        {
            string mainconn = "";
            /*
             * اگر در شبکه بیمارستان بود به سرور اصلی وصل شود در غیر این صورت به سرور محلی
             */
            if (Environment.MachineName != "KH-E0401") // (Environment.MachineName.Substring(0, 2) == "KH")
            {
                mainconn = ConfigurationManager.ConnectionStrings["MyConnetion"].ConnectionString; //get connection string from App.config
                SrvAdd = mainconn.Substring(12, 8);
            }
            else
            {
                if (localConnettion == -1)
                {
                    if (MessageBox.Show("برنامه به سرور اصلی وصل شود ؟", "انتخاب سرور", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                        localConnettion = 0;
                    else
                        localConnettion = 1;
                }

                if (localConnettion == 0)
                {
                    mainconn = ConfigurationManager.ConnectionStrings["MyConnetion"].ConnectionString; //get connection string from App.config
                    SrvAdd = mainconn.Substring(12, 8);
                }
                else
                {
                    SrvAdd = Environment.MachineName;
                    mainconn = "Data Source =. ;initial catalog =Health_clinic ; integrated security=true; MultipleActiveResultSets=true";
                }
            }
            SqlConnection connection = new SqlConnection(mainconn);

            //SrvAdd = "kh-E0211"; //آدرس سرور
            //string connectionString = ConfigurationManager.AppSettings["..."];
            //SqlConnection connection = new SqlConnection("Data Source = "+SrvAdd+" ;initial catalog =Health_clinic ; integrated security=true; MultipleActiveResultSets=true"); //'kh-e0211'
            return connection;
        }

        public static String Read_User_Name()
        {
            SqlConnection con = CreateConnection();
            SqlCommand cmd = new SqlCommand();
            string user_name = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            user_name = user_name.Replace("MUMS\\", "");
            User_ID = user_name;
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT [Staff_First_Name]+ ' '+[Staff_Last_Name] Name  FROM[MI_STF]  where Staff_ID =@user_name";
            cmd.Parameters.AddWithValue("@user_name", user_name);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            user_name = reader["name"].ToString();

            con.Close();
            return user_name;
        }
    }
}
