using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Management;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ColonyMarket.classes;
using ColonyMarket;

namespace ColonyMarket
{
    /// <summary>
    /// Interaction logic for LoginForm.xaml
    /// </summary>
    public partial class LoginForm : Window
    {
        OleDbConnection oleconP = new OleDbConnection();
        OleDbCommand cmd = new OleDbCommand();
       
        DataSet ds;
        public LoginForm()
        {
            
            var filePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string root = Path.GetDirectoryName(filePath);
            InitializeComponent();
             oleconP = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source="+root+"\\appdb.accdb; Jet OLEDB:Database Password=myhyperdb");

        }

        functions f=new functions();
        //ClassConnectionString cstring = new ClassConnectionString();
        private void LoginForm_OnLoaded(object sender, RoutedEventArgs e)
        {
            this.MouseLeftButtonDown += delegate { DragMove(); };
            try
            {
            //    var();
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
            txtUsername.Focus();
        }
        public bool Selectbool(string s)
        {
            OleDbDataReader dr;
            if (oleconP.State == ConnectionState.Closed)
            {
                oleconP.Open();
            }
            OleDbCommand cmd = new OleDbCommand(s, oleconP);//Advised to use parameterized query
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                dr.Close();
                oleconP.Close();
                return true;
            }
            oleconP.Close();
            dr.Close();
            return false;
        }
        public void Update(string s)
        {
            if (oleconP.State == ConnectionState.Closed)
            {
                oleconP.Open();
            }
            OleDbCommand cmd = new OleDbCommand(s, oleconP);
            cmd.ExecuteNonQuery();
            oleconP.Close();
        }

        private void LoginForm_OnKeyDown(object sender, KeyEventArgs e)
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
        
        public void var()
        {
            ManagementClass mc = new ManagementClass("win32_processor");
            ManagementObjectCollection moc = mc.GetInstances();
            String Id = String.Empty;
            foreach (ManagementObject mo in moc)
            {

                Id = mo.Properties["processorID"].Value.ToString();
                break;
            }
            bool isvalid= Selectbool("select BoardID from AllowedPC where BoardID='"+Id+"'");
            if (isvalid==false)
            {
                MessageBox.Show("This is not a win valid Application. Contact to vender.");
                Application.Current.Shutdown();
            }
        }

        public void varDate()
        {
            int m = DateTime.Now.Month;
            int y = DateTime.Now.Year;

            if (y > 2021)
            {
                MessageBox.Show("This is not a valid Win32-Proc application. Please Contact to Administrator(date).");
                Application.Current.Shutdown();
            }
        }

        private void BtnLogin_OnClick(object sender, RoutedEventArgs e)
        { 
            if (txtUsername.Text=="Admin" && txtPassword.Password=="Adminxyz")
            {
               
            }
            else
            {
                try
                {

                    string sql = "select * from DBUsers where Username='" + txtUsername.Text.Trim() +
                                 "' and Upassword='" + txtPassword.Password.Trim() + "'";
                    cmd = new OleDbCommand(sql, oleconP);
                    oleconP.Open();
                    cmd.ExecuteNonQuery();
                    OleDbDataAdapter adapt = new OleDbDataAdapter(sql, oleconP);
                    ds = new DataSet("test");
                    adapt.Fill(ds, "test");
                    oleconP.Close();
                    if (ds.Tables["test"].Rows.Count == 1)
                    {
                        // Update("update DBUsers set Status=1  where Username='" + txtUsername.Text.Trim() + "' and password='" + txtPassword.Password.Trim() + "'");
                        //string basicname = ds.Tables["test"].Rows[0]["basicname"].ToString();
                        var mw = new MainWindow();
                        mw.Show();
                        Hide();

                    }
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
}
