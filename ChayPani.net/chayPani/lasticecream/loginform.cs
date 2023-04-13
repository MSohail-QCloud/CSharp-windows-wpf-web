using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace lasticecream
{
    public partial class loginform : Form
    {
        OleDbConnection olecon = new OleDbConnection(ConfigurationManager.ConnectionStrings["Accdbx"].ToString());
        OleDbCommand olecmd;
        DataSet ds;
        DateTime expirydate;
        string xpirydate;
        int countervalu;
        int limitcounter;
        OleDbDataReader dr;
        public loginform()
        {
            InitializeComponent();
        }

        string realmachin = "";
        
        private void loginform_Load(object sender, EventArgs e)
        {
            string systemname = "";
            string systemid = "";
            string systemmac = "";
            string rsystemname = "";
            string rsystemid = "";
            

            //getdata reality
            olecon.Open();
            string query = "select * from systeminformation ";
            OleDbCommand cmd = new OleDbCommand(query, olecon);//Advised to use parameterized query
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                systemname = dr.GetValue(1).ToString();
                systemid = dr.GetValue(2).ToString();
                systemmac = dr.GetValue(3).ToString();
            }
           
            dr.Close();
            olecon.Close();

            rsystemname = systeminformation.GetComputerName();
            rsystemid = systeminformation.GetProcessorId();
            //rsystemmac = systeminformation.GetMACAddress();

            if(systemid==rsystemid )
            {
                realmachin = "ok";
            }
        }
        private void countercounte()
        {

            OleDbDataReader dr;
            olecon.Open();
            string query = "select Countercount,limitcount from logiincounter ";
            OleDbCommand cmd = new OleDbCommand(query, olecon);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                countervalu = int.Parse(dr.GetValue(0).ToString());
                limitcounter = int.Parse(dr.GetValue(1).ToString());
                countervalu++;
                //update counter
                OleDbCommand olecmd = new OleDbCommand("update logiincounter set Countercount='" + countervalu + "' where ID=@id", olecon);

                olecmd.Parameters.AddWithValue("@id", "1");
                olecmd.ExecuteNonQuery();
                //end counter
            }
            olecon.Close();
        }

        private string checkvilidity()
        {
            string result = "ok";
            OleDbDataReader dr;
            olecon.Open();
            string query = "select expirydate from systeminformation ";
            OleDbCommand cmd = new OleDbCommand(query, olecon);//Advised to use parameterized query
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                expirydate = DateTime.Parse(dr.GetValue(0).ToString());
                xpirydate = expirydate.ToShortDateString();
                string dt = DateTime.Now.ToString("dd-MM-yyyy");

            }
            olecon.Close();
            if (xpirydate == DateTime.Now.ToShortDateString() || countervalu >= limitcounter || DateTime.Now.ToString("dd-MM-yyyy")==("15-09-2018"))
            {
                MessageBox.Show("آپکا ٹرائل ٹائم ختم ہو گیا ہے۔اپنے ایڈمنسٹریٹر سے رابطہ کریں۔شکریہ");
                result = "Expired";
            }
            return result;



        }

        private void loginform_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        

        private void btn_login_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "select * from user_login where username='" + txt_username.Text + "' and password='" + txt_password.Text + "'";
                olecmd = new OleDbCommand(sql, olecon);
                olecon.Open();
                olecmd.ExecuteNonQuery();
                OleDbDataAdapter adapt = new OleDbDataAdapter(sql, olecon);
                ds = new DataSet("test");
                adapt.Fill(ds, "test");
                olecon.Close();
                if (ds.Tables["test"].Rows.Count == 1)
                {
                    string basicname = ds.Tables["test"].Rows[0]["basicname"].ToString();
                    if (basicname == "Master" && checkBox1.Checked != true)
                    {
                        admin af = new admin();
                        af.Show();
                        this.Hide();
                    }
                    if (basicname == "Admin" && checkBox1.Checked != true)
                    {
                        admin af = new admin();
                        af.Show();
                        this.Hide();
                    }
                    if (checkBox1.Checked == true)
                    {
                        changepassword cp = new changepassword(basicname);
                        cp.Show();
                        this.Hide();
                    }
                    
                    if (basicname != "Admin" && basicname != "Master" && checkBox1.Checked != true)
                    {
                        if (realmachin == "ok")
                        {
                            countercounte();
                            string result = checkvilidity();
                            if (result != "Expired")
                            {
                                if (basicname == "User2")
                                {
                                    BillScreen bs = new BillScreen();
                                    bs.Show();
                                    bs.button1.Enabled = false;
                                    //bs.search_HightlightRow(1);
                                    //bs.clear_Selection();
                                    this.Hide();
                                    //Client cf = new Client();
                                    //cf.Show();
                                    //this.Hide();
                                }
                                else
                                {
                                    BillScreen bs = new BillScreen();
                                    bs.Show();
                                    //bs.search_HightlightRow(1);
                                    this.Hide();
                                 
                                    //parentform pf = new parentform();
                                    //pf.Show();
                                    //this.Hide();
                                }
                            }
                            else
                            {
                                Application.Exit();
                            }
                        }
                        else
                        {
                            Application.Exit();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("صحیح یوزر کا انتخاب کریں۔");
                }
            }
            catch (Exception es)
            {
                MessageBox.Show(es.ToString());
                Application.Exit();
            }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txt_username_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_password.Focus();
            }
        }

        private void txt_password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_login.Focus();
            }
        }
    }
}
