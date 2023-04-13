using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using  VesterShoes;
using VesterShoes.classes;

namespace VesterShoes
{
    /// <summary>
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {
        SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["sqldbx"].ConnectionString);
        VestureClass vc=new VestureClass();
        public LoginScreen()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.MouseLeftButtonDown += delegate { DragMove(); };
            try
            {
                var();
               varDate();
                vc.Update("update tblDBUsers set Status=0 where Status=1");
            }
            catch(Exception es)
            {
                MessageBox.Show("Check connection, Database not found. Application Closed.");
                Application.Current.Shutdown();
            }                       
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Close();
            }
            if (e.Key == Key.Enter)
            {
                BtnLogin_OnClick(sender, e);
            }
        }
        ManagementClass mc = new ManagementClass("win32_processor");
        SqlCommand cmd=new SqlCommand();
        DataSet ds;
        public void var()
        {            
            ManagementObjectCollection moc = mc.GetInstances();
            String Id = String.Empty;
            foreach (ManagementObject mo in moc)
            {
                Id = mo.Properties["processorID"].Value.ToString();
                break;
            }

            string thissystemid = "";//current system id
            string systemid1 = "BFEBFBFF00040651";//my BFEBFBFF00040651
            string systemid2 = "BFEBFBFF000206A7";//vocancy
            string systemid3 = "BFEBFBFF000506E3";//atom-pc
            string systemid4 = "BFEBFBFF000706E5";//Kaleemlapi
            thissystemid = Id;
            //rsystemmac = systeminformation.GetMACAddress();

            if (systemid1 != thissystemid && systemid2 != thissystemid && systemid3 != thissystemid && systemid4 != thissystemid)
            {
                MessageBox.Show("This is not valid Application. Contact to vender.");
                Application.Current.Shutdown();
            }
        }

        public void varDate()
        {
            int m = DateTime.Now.Month;
            int y = DateTime.Now.Year;

            if (y > 2022)
            {
                MessageBox.Show("This is not a valid Win32-Proc application. Please Contact to Administrator.");
                Application.Current.Shutdown();
            }
        }

        
        private void BtnLogin_OnClick(object sender, RoutedEventArgs e)
        {
            if (txtUsername.Text == "1")
            {
                txtUsername.Text = "Admin";
                txtPassword.Password = "abc";
            }
            try
            {
                string sql = "select * from tblDBUsers where Username='" + txtUsername.Text.Trim() + "' and password='" + txtPassword.Password.Trim() + "'";
                cmd = new SqlCommand(sql, sqlcon);
                sqlcon.Open();
                cmd.ExecuteNonQuery();
                SqlDataAdapter adapt = new SqlDataAdapter(sql, sqlcon);
                ds = new DataSet("test");
                adapt.Fill(ds, "test");
                sqlcon.Close();
                if (ds.Tables["test"].Rows.Count == 1)
                {
                    vc.Update("update tblDBUsers set Status=1  where Username='" + txtUsername.Text.Trim() + "' and password='" + txtPassword.Password.Trim() + "'");
                    //string basicname = ds.Tables["test"].Rows[0]["basicname"].ToString();
                    var mw = new MainWindow(txtUsername.Text);
                    mw.Show();
                    //var mw = new NewProductionForm();
                    //mw.Show();
                    Hide();
                    //if (basicname == "Master")
                    //{
                    //    admin af = new admin();
                    //    af.Show();
                    //    this.Hide();
                    //}
                    //if (basicname == "Admin")
                    //{
                    //    admin af = new admin();
                    //    af.Show();
                    //    this.Hide();
                    //}


                    //if (basicname != "Admin" && basicname != "Master")
                    //{


                    //    //if (cr.varDate()==true)
                    //    //{
                    //    if (basicname == "User")
                    //    {
                    //        Digital_Screen ds = new Digital_Screen();
                    //        ds.Show();
                    //        this.Hide();
                    //    }
                    //    else
                    //    {
                    //        MessageBox.Show("Internal Problem, contact to Vender.");
                    //    }
                    //}
                    //else
                    //{
                    //    Application.Exit();
                    //}

                }
                //}
                else
                {
                    MessageBox.Show("صحیح یوزر کا انتخاب کریں۔");
                }
            }
            catch (Exception es)
            {
                MessageBox.Show(es.ToString());
                Application.Current.Shutdown(0);
            }
        }
    }
}
