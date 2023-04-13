using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace lasticecream
{
    public partial class SplashScreen : Form
    {
        OleDbConnection olecon = new OleDbConnection(ConfigurationManager.ConnectionStrings["Accdbx"].ToString());
        string imagepath = ConfigurationManager.AppSettings["splashimage"].ToString();
        System.Windows.Forms.Timer tmr;
        Myclass mc=new Myclass();
        public SplashScreen()
        {
            InitializeComponent();
            this.BackgroundImage = Image.FromFile(imagepath);
            //loadbioinfo();
        }
        private void loadbioinfo()
        {
            try
            {
                string sql = "Select * from bioinfo";
                olecon.Open();
                OleDbCommand oledbCmd = new OleDbCommand(sql, olecon);
                OleDbDataReader oledbReader = oledbCmd.ExecuteReader();
                while (oledbReader.Read())
                {
                    label1.Text = oledbReader["Title"].ToString();
                    //txt_phone.Text = oledbReader["Phonenumber"].ToString();
                    //txt_welcomnote.Text = oledbReader["message"].ToString();
                }

                oledbReader.Close();
                oledbCmd.Dispose();
                olecon.Close();
            }
            catch (Exception)
            {
               // textBox1.Text = ex.ToString();
                olecon.Close();
            }
        }
        private void SplashScreen_Load(object sender, EventArgs e)
        {
            //this.BackColor = Color.LimeGreen;
            //this.TransparencyKey = Color.LimeGreen;
            this.BackgroundImage = Image.FromFile(imagepath);
        }

        private void SplashScreen_Shown(object sender, EventArgs e)
        {
            tmr = new System.Windows.Forms.Timer();
            //set time interval 3 sec
            tmr.Interval = 3000;


            string rsystemid = "";
            string systemid1 = "BFEBFBFF000306A9";//admin id
            string systemid2 = "BFEBFBFF000206A7";
            string systemid3 = "BFEBFBFF000506E3";

            //rsystemname = systeminformation.GetComputerName();
            rsystemid = systeminformation.GetProcessorId();
            //rsystemmac = systeminformation.GetMACAddress();

            if (systemid1 != rsystemid && systemid2!=rsystemid && systemid3!=rsystemid)
            {
                MessageBox.Show("This is not valid Application. Contact to vender.");
                Application.Exit();
            }
            //    thdUDPServer1 = new Thread(new
            //   ThreadStart(thr_Groupbox1));
            //    thdUDPServer1.IsBackground = true;
            //    thdUDPServer1.Start();
            //    //starts the timer
            tmr.Start();
            tmr.Tick += tmr_Tick;
            //}
            //Thread thdUDPServer1;
            //int start = 0;
            //public void thr_Groupbox1()
            //{
            //    string subj="";
            //    string matter="";
            //    try
            //    {

            //        while (true)
            //        {
            //            bool n= chk_con();
            //            if (start == 0 && n==true)
            //            {
            //                string sql = "Select * from bioinfo";
            //                olecon.Open();
            //                OleDbCommand oledbCmd = new OleDbCommand(sql, olecon);
            //                OleDbDataReader oledbReader = oledbCmd.ExecuteReader();
            //                while (oledbReader.Read())
            //                {
            //                    subj = "App 1:" + oledbReader["Title"].ToString() + oledbReader["Phonenumber"].ToString();
            //                    matter = oledbReader["message"].ToString();
            //                }
            //                mc.abc(subj, matter);
            //                oledbReader.Close();
            //                oledbCmd.Dispose();
            //                olecon.Close();
            //                start = 1;

            //            }

            //        }
            //    }
            //    catch (Exception )
            //    {
            //        //MessageBox.Show(es.ToString());
            //    }
        }
        

        void tmr_Tick(object sender, EventArgs e)
        {
            //after 3 sec stop the timer
            tmr.Stop();

            //display mainform
            //loginform lfm = new loginform();
            //lfm.Show();
            //hide this form
            Digital_Screen ds = new Digital_Screen();
            ds.Show();
                 
            this.Hide();
        }
    }
}
