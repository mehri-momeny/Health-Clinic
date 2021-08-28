using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using Patient_clinic.health_education_indicators;
using Patient_clinic.New_staff;

namespace Patient_clinic
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            PersianCalendar p = new PersianCalendar();
            lblUser.Text = Program.Read_User_Name();
            lblsrv.Text = Program.SrvAdd;
            lblDate.Text = p.GetYear(DateTime.Now).ToString() + "/" + p.GetMonth(DateTime.Now).ToString("0#") + "/" + p.GetDayOfMonth(DateTime.Now).ToString("0#");
            switch (DateTime.Now.DayOfWeek)
            {
                case DayOfWeek.Friday:
                    lblDay.Text = "جمعه";
                    break;
                case DayOfWeek.Saturday:
                    lblDay.Text = "شنبه";
                    break;
                case DayOfWeek.Sunday:
                    lblDay.Text = "یکشنبه";
                    break;
                case DayOfWeek.Monday:
                    lblDay.Text = "دوشنبه";
                    break;
                case DayOfWeek.Tuesday:
                    lblDay.Text = "سه‌شنبه";
                    break;
                case DayOfWeek.Wednesday:
                    lblDay.Text = "چهارشنبه";
                    break;
                case DayOfWeek.Thursday:
                    lblDay.Text = "پنج‌شنبه";
                    break;
            }
        }

        private void BtnTraining_Click(object sender, EventArgs e)
        {
            DataEntry dataEntry = new DataEntry();
            dataEntry.ShowDialog();
        }

        private void BtnFollowUP_Click(object sender, EventArgs e)
        {
            new frmFollowMain().ShowDialog();
        }

        private void BtnAbout_Click(object sender, EventArgs e)
        {
            new frmAbout().Show();
        }

        private void BtnIndicator_Click(object sender, EventArgs e)
        {
            frmIndicator_Main dataIndicator= new frmIndicator_Main();
            dataIndicator.ShowDialog();
        }

        private void ButtonX1_Click(object sender, EventArgs e)
        {
            frmNewStaff_Main frmNewStaff_Main = new frmNewStaff_Main();
            frmNewStaff_Main.ShowDialog();
        }
    }
}
