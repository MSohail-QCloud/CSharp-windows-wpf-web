using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VesterShoes;
using System.Data.SqlClient;

namespace VesterShoes.classes
{
    class functions
{

        SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["sqldbx"].ConnectionString);
        public string test(string i)
        {
            return "test Successfull1";
        }

        public DataTable ReturnDataTable(string s)
        {
            sqlcon.Open();
            SqlCommand command = sqlcon.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = s;
            command.ExecuteNonQuery();
            DataTable dataTable = new DataTable();
            new SqlDataAdapter(command).Fill(dataTable);
            sqlcon.Close();
            return dataTable;
        }
        public void var()
        {
            //string rsystemid = "";//current system id
            //string systemid1 = "BFEBFBFF000306A9";//admin id
            //string systemid2 = "BFEBFBFF000206A7";//vocancy
            //string systemid3 = "BFEBFBFF000506E3";//atom-pc
            //rsystemid = GetProcessorId();
            ////rsystemmac = systeminformation.GetMACAddress();

            //if (systemid1 != rsystemid && systemid2 != rsystemid && systemid3 != rsystemid)
            //{
            //    MessageBox.Show("This is not valid Application. Contact to vender.");
            //    Application.Exit();
            //}
        }

        //public bool varDate()
        //{
        //    //int m = DateTime.Now.Month;
        //    //int y = DateTime.Now.Year;

        //    //if (m > 4 && y >= 2019)
        //    //{
        //    //    MessageBox.Show("آپکا ٹرائل ٹائم ختم ہو گیا ہے۔اپنے ایڈمنسٹریٹر سے رابطہ کریں۔شکریہ");
        //    //    Application.Exit();
        //    //    return false;
        //    //}
        //    //else
        //    //{
        //    //    return true;
        //    //}
            
        //}

        

        //public static String GetProcessorId()
        //{

        //    //ManagementClass mc = new ManagementClass("win32_processor");
        //    //ManagementObjectCollection moc = mc.GetInstances();
        //    //String Id = String.Empty;
        //    //foreach (ManagementObject mo in moc)
        //    //{

        //    //    Id = mo.Properties["processorID"].Value.ToString();
        //    //    break;
        //    //}
        //    //return Id;

        //}


        //Timer tmr;
        
        //public string timer()
        //{
        //    tmr = new System.Windows.Forms.Timer();
        //    //set time interval 3 sec
        //    tmr.Interval = 3000;
        //    var();
        //    varDate();

        //    //    thdUDPServer1 = new Thread(new
        //    //   ThreadStart(thr_Groupbox1));
        //    //    thdUDPServer1.IsBackground = true;
        //    //    thdUDPServer1.Start();
        //    //    //starts the timer
        //    tmr.Start();
        //    tmr.Tick += tmr_Tick;
        //    return abc;
        //}
        void tmr_Tick(object sender, EventArgs e)
        {
            //after 3 sec stop the timer
            //abc = "OK";
            //tmr.Stop();
            
            
        }

        //public DataTable loadListofItems()
        //{
        //    //sqlcon.Open();
        //    //OleDbCommand cmd3 = sqlcon.CreateCommand();
        //    //cmd3.CommandType = CommandType.Text;
        //    //cmd3.CommandText = "SELECT ItemNumber,ItemName,Itemrate,ItemBalance  FROM ItemsList ";
        //    //cmd3.ExecuteNonQuery();
        //    //DataTable dt22 = new DataTable();
        //    //OleDbDataAdapter da3 = new OleDbDataAdapter(cmd3);
        //    //da3.Fill(dt22);
        //    //sqlcon.Close();
        //    //return dt22;
            
        //}

        public int createNumber(string query)
        {
            try
            {
                SqlDataReader dr;
                if (sqlcon.State != ConnectionState.Open)
                {
                    sqlcon.Open();
                }
                int b = 0;
                //string query = "Select top 1 profileid  from tblprofile  order by profileid desc";
                SqlCommand cmd = new SqlCommand(query, sqlcon);//Advised to use parameterized query
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    string a = dr[0].ToString();
                    if (a != "")
                    {
                        b = (int.Parse(dr.GetValue(0).ToString()) + 1); //incremented
                    }
                    else
                    {
                        b = 1;
                    }
                    
                }
                else
                {
                    b= 1;
                }
                dr.Close();
                if (sqlcon.State != ConnectionState.Closed)
                {
                    sqlcon.Close();
                }
                return b;
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message.ToString());
                return 0;
            }
            

        }
        public int findnumber(string query)
        {
            try
            {
                SqlDataReader dr;
                if (sqlcon.State != ConnectionState.Open)
                {
                    sqlcon.Open();
                }
                int b = 0;
                SqlCommand cmd = new SqlCommand(query, sqlcon);//Advised to use parameterized query
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    if (!dr.IsDBNull(0))
                    {
                        b = (int.Parse(dr[0].ToString()));
                    }
                }
                dr.Close();
                if (sqlcon.State != ConnectionState.Closed)
                {
                    sqlcon.Close();
                }
                return b;
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message.ToString());
                return 0;
            }

        }
        public float findnumberfloat(string query)
        {
            try
            {
                SqlDataReader dr;
                if (sqlcon.State != ConnectionState.Open)
                {
                    sqlcon.Open();
                }
                float b = 0;
                SqlCommand cmd = new SqlCommand(query, sqlcon);//Advised to use parameterized query
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    if (!dr.IsDBNull(0))
                    {
                        b = (float.Parse(dr[0].ToString()));
                    }
                }
                dr.Close();
                if (sqlcon.State != ConnectionState.Closed)
                {
                    sqlcon.Close();
                }
                return b;
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message.ToString());
                return 0;
            }

        }

        public string findname(string query)
        {
            try
            {
                string s = "";
                SqlDataReader dr;
                if (sqlcon.State != ConnectionState.Open)
                {
                    sqlcon.Open();
                }
                SqlCommand cmd = new SqlCommand(query, sqlcon);//Advised to use parameterized query
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    s = dr.GetValue(0).ToString();
                }
                dr.Close();
                if (sqlcon.State != ConnectionState.Closed)
                {
                    sqlcon.Close();
                }
                return s;
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message.ToString());
                return "";
            }

        }
    }
}

