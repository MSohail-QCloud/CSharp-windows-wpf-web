using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows;
using VesterShoes;
using System.Data.SqlClient;
using System.Management;

namespace ColonyMarket.classes
{
    class functions
{

        OleDbConnection olecon = new OleDbConnection(ConfigurationManager.ConnectionStrings["Accdbx"].ConnectionString);
        public string test(string i)
        {
            return "test Successfull1";
        }
        
        public DataTable ReturnDataTable(string s)
        {
            olecon.Open();
            OleDbCommand command = olecon.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = s;
            command.ExecuteNonQuery();
            DataTable dataTable = new DataTable();
            new OleDbDataAdapter(command).Fill(dataTable);
            olecon.Close();
            return dataTable;
        }

        public void Insert(string s)
        {
            if (VerifySystemID())
            {
                throw new Exception("This Project is Read-Only");               
            }
            if (olecon.State == ConnectionState.Closed)
            {
                olecon.Open();
            }
            OleDbCommand cmd = new OleDbCommand(s, olecon);
            cmd.ExecuteNonQuery();
            olecon.Close();
        }

        public void Delete(string s)
        {
            if (VerifySystemID())
            {
                throw new Exception("This Project is Read-Only");
            }
            if (olecon.State == ConnectionState.Closed)
            {
                olecon.Open();
            }
            OleDbCommand cmd = new OleDbCommand(s, olecon);
            cmd.ExecuteNonQuery();
            olecon.Close();
        }

        public bool Selectbool(string s)
        {
            OleDbDataReader dr;
            if (olecon.State == ConnectionState.Closed)
            {
                olecon.Open();
            }
            OleDbCommand cmd = new OleDbCommand(s, olecon);//Advised to use parameterized query
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                dr.Close();
                olecon.Close();
                return true;
            }
            olecon.Close();
            dr.Close();
            return false;
        }
        public DataSet Select(string s)
        {
            if (olecon.State == ConnectionState.Closed)
            {
                olecon.Open();
            }
            OleDbDataAdapter da = new OleDbDataAdapter(s, olecon);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (olecon.State == ConnectionState.Open)
            {
                olecon.Close();
            }
            return ds;
        }

        public void Update(string s)
        {
            if (VerifySystemID())
            {
                throw new Exception("This Project is Read-Only");
            }
            if (olecon.State == ConnectionState.Closed)
            {
                olecon.Open();
            }
            OleDbCommand cmd = new OleDbCommand(s, olecon);
            cmd.ExecuteNonQuery();
            if (olecon.State == ConnectionState.Open)
            {
                olecon.Close();
            }
        }
        
        public string SystemID()
        {
            ManagementClass mc = new ManagementClass("win32_processor");

            ManagementObjectCollection moc = mc.GetInstances();
            String Id = String.Empty;
            foreach (ManagementObject mo in moc)
            {

                Id = mo.Properties["processorID"].Value.ToString();
                break;
            }
            
            string abc = findName("select SysID from SystemId ");
            string s = "insert into SystemId(ID,SysID) Values(0,'" + Id + "')";
            if (abc == "")
            {
                if (olecon.State == ConnectionState.Closed)
                {
                    olecon.Open();
                }
                OleDbCommand cmd = new OleDbCommand(s, olecon);
                cmd.ExecuteNonQuery();
                olecon.Close();
            }
            return Id;
        }

        public bool VerifySystemID()
        {
            ManagementClass mc = new ManagementClass("win32_processor");

            ManagementObjectCollection moc = mc.GetInstances();
            String Id = String.Empty;
            foreach (ManagementObject mo in moc)
            {

                Id = mo.Properties["processorID"].Value.ToString();
                break;
            }

            string abc = findName("select SysID from SystemId ");
            if (abc == Id)
                return false;
            else
                return true;
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
        //    //olecon.Open();
        //    //OleDbCommand cmd3 = olecon.CreateCommand();
        //    //cmd3.CommandType = CommandType.Text;
        //    //cmd3.CommandText = "SELECT ItemNumber,ItemName,Itemrate,ItemBalance  FROM ItemsList ";
        //    //cmd3.ExecuteNonQuery();
        //    //DataTable dt22 = new DataTable();
        //    //OleDbDataAdapter da3 = new OleDbDataAdapter(cmd3);
        //    //da3.Fill(dt22);
        //    //olecon.Close();
        //    //return dt22;
            
        //}

        public int createNumber(string query)
        {
            try
            {
                OleDbDataReader dr;
                if (olecon.State != ConnectionState.Open)
                {
                    olecon.Open();
                }
                int b = 0;
                //string query = "Select top 1 profileid  from tblprofile  order by profileid desc";
                OleDbCommand cmd = new OleDbCommand(query, olecon);//Advised to use parameterized query
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    string a = dr.GetValue(0).ToString();
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
                if (olecon.State != ConnectionState.Closed)
                {
                    olecon.Close();
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
                OleDbDataReader dr;
                if (olecon.State != ConnectionState.Open)
                {
                    olecon.Open();
                }
                 int b = 0;
                OleDbCommand cmd = new OleDbCommand(query, olecon);//Advised to use parameterized query
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    if (!dr.IsDBNull(0))
                    {
                        b = (int.Parse(dr.GetValue(0).ToString()));
                    }
                }
                dr.Close();
                if (olecon.State != ConnectionState.Closed)
                {
                    olecon.Close();
                }
                return b;
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message.ToString());
                return 0;
            }

        }
        public float findFloatNumber(string query)
        {
            try
            {
                OleDbDataReader dr;
                if (olecon.State != ConnectionState.Open)
                {
                    olecon.Open();
                }
                float b = 0;
                OleDbCommand cmd = new OleDbCommand(query, olecon);//Advised to use parameterized query
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    if (!dr.IsDBNull(0))
                    {
                        b = (float.Parse(dr.GetValue(0).ToString()));
                    }
                }
                dr.Close();
                if (olecon.State != ConnectionState.Closed)
                {
                    olecon.Close();
                }
                return b;
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message.ToString());
                return 0;
            }

        }
        public long findLongnumber(string query)
        {
            try
            {
                OleDbDataReader dr;
                if (olecon.State != ConnectionState.Open)
                {
                    olecon.Open();
                }
                long b = 0;
                OleDbCommand cmd = new OleDbCommand(query, olecon);//Advised to use parameterized query
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    if (!dr.IsDBNull(0))
                    {
                        b = (long.Parse(dr.GetValue(0).ToString()));
                    }
                }
                dr.Close();
                if (olecon.State != ConnectionState.Closed)
                {
                    olecon.Close();
                }
                return b;
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message.ToString());
                return 0;
            }

        }

        public string findName(string query)
        {
            try
            {
                OleDbDataReader dr;
                if (olecon.State != ConnectionState.Open)
                {
                    olecon.Open();
                }
                string b = "";
                OleDbCommand cmd = new OleDbCommand(query, olecon);//Advised to use parameterized query
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    if (!dr.IsDBNull(0))
                    {
                        b = ((dr.GetValue(0).ToString()));
                    }
                }
                dr.Close();
                if (olecon.State != ConnectionState.Closed)
                {
                    olecon.Close();
                }
                return b;
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message.ToString());
                return "";
            }

        }
    }
}

