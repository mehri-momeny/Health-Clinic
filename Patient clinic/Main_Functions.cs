using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace Patient_clinic
{
    class Main_Functions
    {
        public static DataTable GetDoctor_List()
        {
            SqlConnection con = Program.CreateConnection();//new SqlConnection("Data Source =(local) ; initial catalog = Health_clinic ; integrated security=true");
            con.Open();
            DataSet ds = new DataSet();
            //لیست پزشکان متخصص٬ فلوشیپ٬ فوق تخصص
            string query = "SELECT [Staff_Last_Name]+' ـ '+[Staff_First_Name] as name,Staff_ID ,[Staff_Type],[Role_type],[Specialty]   FROM [MI_STF]" +
                             "where [Role_type] = 5 and(substring(Staff_Type, 0, 3) = 'SP' OR  substring(Staff_Type, 0, 3) = 'FE' OR  substring(Staff_Type, 0, 3) = 'PS') AND Active_Inactive = 1" +
                             " ORDER BY name";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            da.Fill(ds, "Doctors");
            con.Close();
            return ds.Tables["Doctors"];

        }

        public static bool check_code(string National_Code)
        {
            try
            {
                char[] chArray = National_Code.ToCharArray();
                int[] numArray = new int[chArray.Length];
                for (int i = 0; i < chArray.Length; i++)
                {
                    numArray[i] = (int)char.GetNumericValue(chArray[i]);
                }
                int num2 = numArray[9];
                switch (National_Code)
                {
                    case "0000000000":
                    case "1111111111":
                    case "22222222222":
                    case "33333333333":
                    case "4444444444":
                    case "5555555555":
                    case "6666666666":
                    case "7777777777":
                    case "8888888888":
                    case "9999999999":
                        MessageBox.Show("کد ملی وارد شده صحیح نمی باشد");
                        return false;
                }
                int num3 = ((((((((numArray[0] * 10) + (numArray[1] * 9)) + (numArray[2] * 8)) + (numArray[3] * 7)) + (numArray[4] * 6)) + (numArray[5] * 5)) + (numArray[6] * 4)) + (numArray[7] * 3)) + (numArray[8] * 2);
                int num4 = num3 - ((num3 / 11) * 11);
                if ((((num4 == 0) && (num2 == num4)) || ((num4 == 1) && (num2 == 1))) || ((num4 > 1) && (num2 == Math.Abs((int)(num4 - 11)))))
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("کد ملی نامعتبر است");
                    return false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("لطفا برای کد ملی یک عدد 10 رقمی وارد کنید");
                return false;
            }

        }

        public static string Get_Today_Shamsi()
        {
            System.Globalization.PersianCalendar p = new System.Globalization.PersianCalendar();
            return p.GetYear(DateTime.Now).ToString() + "/" + p.GetMonth(DateTime.Now).ToString("0#") + "/" + p.GetDayOfMonth(DateTime.Now).ToString("0#"); ;
        }

        public  static string GetSafeString(object value)
        {
            if (value == null)
            {
                return string.Empty;
            }

            return value.ToString();
        }

    }
}
