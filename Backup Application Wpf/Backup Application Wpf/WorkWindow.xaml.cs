using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security.Principal;
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
using Microsoft.VisualBasic.FileIO;
using System.Data.OleDb;
//using System.Windows.Forms;


namespace Backup_Application_Wpf
{
    /// <summary>
    /// Interaction logic for WorkWindow.xaml
    /// </summary>
    public partial class WorkWindow : Window
    {
        SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["dbx"].ConnectionString);
        OleDbConnection con = new OleDbConnection(ConfigurationManager.ConnectionStrings["Accdbx"].ConnectionString);

        public WorkWindow()
        {
            InitializeComponent();
             //loadjob();
            
        }

        private void MenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            NewBackup nb=new NewBackup();
            nb.ShowDialog();

        }

        public int idbpinfo { get; set; }
        public string filename { get; set; }
        public string Filepathfrom { get; set; }
        public string filepathto { get; set; }
        public string Filext { get; set; }
        public string ServerCat { get; set; }
        public string  ServerLoc { get; set; }
        public string CopIPAddress { get; set; }
        public string CopyUsername { get; set; }
        public string CopyPassword { get; set; }
        public string PasteIPaddress { get; set; }
        public string PasteUsername { get; set; }
        public string PastePassword { get; set; }

        int jobnumber = 0;
        DateTime Bpday = DateTime.Now.Date.AddDays(-1);
        SqlCommand cmd;
        SqlDataAdapter adapt;
        DataSet ds;
        int i = 0;
        int counterbackup = 1;
        string sql = null;

        private void BtnStartJob_OnClick(object sender, RoutedEventArgs e)
        {
            
           
           


                //for (int i = 0; i < Idbpinfo.Length; i++)
                //{
                //    Lbl_count.Content = i;
                //    Lbl_filename.Content = Filename[i];
                //    Lbl_ServerCatogry.Content = Servertype[i];
                //    Lbl_copyPath.Content = FilePathFrom[i];
                //    Lbl_ipadd.Content = CopyIpaddress[i];

                //    ////start backup
                //    ////Setting up my Source File Path
                //    //string source = FilePathFrom[i];
                //    ////Setting up my Destination Path
                //    //string destination = FilePathTo[i];
                //    //try
                //    //{
                //    //    MessageBox.Show("{}", FilePathFrom[i]);
                //    //    //Console.WriteLine("Start Copying....");
                //    //    ////Copying the File From Source to 
                //    //    //// Destination
                //    //    //FileSystem.CopyDirectory(source,
                //    //    //    destination, UIOption.AllDialogs);
                //    //    //Console.WriteLine("SuccessFully Copied!!!");
                //    //    //Console.ReadKey();
                //    //}
                //    //    //If the Copying Operation is Cancelled in
                //    //    // the midway
                //    //    //then it throws an Exception which is
                //    //    //carried by this catch block
                //    //    //catch (OperationCanceledException)
                //    //    //{
                //    //    //    Console.WriteLine("Copying Cancelled!!!");
                //    //    //    Console.ReadKey();
                //    //    //}
                //    //catch (Exception es)
                //    //{
                //    //    MessageBox.Show("errorr"+es);
                //    //}
                //    ////end copy code
                //}



            //}
        }

        private void ShowJob(int j)
        {
            //MessageBox.Show(ds.Tables[0].Rows[i].ItemArray[0] + " -- " + ds.Tables[0].Rows[i].ItemArray[1]);
                idbpinfo = Convert.ToInt16(ds.Tables[0].Rows[j].ItemArray[0]);
                filename = ds.Tables[0].Rows[j].ItemArray[1].ToString();
                Filepathfrom = ds.Tables[0].Rows[j].ItemArray[2].ToString();
                filepathto = ds.Tables[0].Rows[j].ItemArray[3].ToString();
                Filext = ds.Tables[0].Rows[j].ItemArray[4].ToString();
                ServerCat = ds.Tables[0].Rows[j].ItemArray[5].ToString();
                ServerLoc = ds.Tables[0].Rows[j].ItemArray[6].ToString();
                CopIPAddress = ds.Tables[0].Rows[j].ItemArray[7].ToString();
                CopyUsername = ds.Tables[0].Rows[j].ItemArray[8].ToString();
                CopyPassword = ds.Tables[0].Rows[j].ItemArray[9].ToString();
                PasteIPaddress = ds.Tables[0].Rows[j].ItemArray[10].ToString();
                PasteUsername = ds.Tables[0].Rows[j].ItemArray[11].ToString();
                PastePassword = ds.Tables[0].Rows[j].ItemArray[12].ToString();

            Lbl_iddb.Content = idbpinfo;
            Lbl_count.Content = Convert.ToString(counterbackup) + " Of " + ds.Tables[0].Rows.Count;
            Lbl_filename.Content = filename + Bpday;
            Lbl_copyPath.Content = Filepathfrom;
            Lbl_ipadd.Content = CopIPAddress;
            lbl_pastepath.Content = filepathto;
            Lbl_ipadd_paste.Content = PasteIPaddress;
            Lbl_ServerCatogry.Content = ServerCat;
            Lbl_backupschedule.Content = BpScheduleCombo.SelectedItem.ToString();
               
        }

        private void selectjob()
        {
            //update labels
            Lbl_count.Content = Convert.ToString(counterbackup) + " Of " + ds.Tables[0].Rows.Count;
            Lbl_filename.Content = filename + Bpday;
            Lbl_ipadd.Content = CopIPAddress;
            Lbl_ServerCatogry.Content = ServerCat;
            Lbl_backupschedule.Content = "Daily";
            MyDelay(100);
            counterbackup++;
        }

        public  void MyDelay(int seconds)
        {
            DateTime dt = DateTime.Now + TimeSpan.FromSeconds(seconds);

            do
            {
                
            }
            while (DateTime.Now < dt);
            
        }



        private void Btn_Close_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Btn_startjob_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Btn_back_Click(object sender, RoutedEventArgs e)
        {
            if (jobnumber == 0)
            {

            }
            else
            {
                jobnumber--;
                Btn_Next.IsEnabled = true;
                ShowJob(jobnumber);
                if (jobnumber == 0)
                {
                    Btn_back.IsEnabled = false;
                }
            } 
           
        }

        private void Btn_Next_Click(object sender, RoutedEventArgs e)
        {
            
            if (jobnumber == ds.Tables[0].Rows.Count-1)
            {
                MessageBox.Show("This is Last Job.");
            }
            else
            {

                jobnumber++;
                Btn_back.IsEnabled = true;
                ShowJob(jobnumber);
                if(jobnumber==ds.Tables[0].Rows.Count-1)
                {
                    Btn_Next.IsEnabled = false;
                }
            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            BpScheduleCombo.Items.Add("Daily");
            BpScheduleCombo.Items.Add("Weekly");
            BpScheduleCombo.Items.Add("Monthly");
            BpScheduleCombo.Items.Add("Annual");
            BpScheduleCombo.SelectedIndex = 0;
            
            
            //loadjob();
            //ShowJob(1);
            Btn_back.IsEnabled = false;

        }
        private void loadjob()
        {
            //sql = "select * from BackupFile_Info where IsActive='y' and BackupSchedule= 'Daily'";
            

            try
            {
                con.Open();
                sql = "select * from BackupFile_Info where IsActive='y' AND BackupSchedule='" + BpScheduleCombo.SelectedItem + "'";
                OleDbCommand cmd = new OleDbCommand(sql, con);
                OleDbDataAdapter sda = new OleDbDataAdapter(cmd);
                //ds = new DataSet("test");
                ////command.CommandText =("select * from BackupFile_Info where IsActive='y' AND BackupSchedule='" + BpScheduleCombo.SelectedItem + "'");
                ////command.CommandType = CommandType.Text;
                ////command.Connection = con;
                
                //cmd.ExecuteNonQuery();
                //cmd.ExecuteReader();
                //adapter.Fill(ds, "test");

                //adapter.Dispose();
                //command.Dispose();
                DataTable dtt=new DataTable();
                //adapt.SelectCommand = new SqlCommand(sql, con);
                sda.Fill(dtt);
                dtt = ds.Tables["test"];

                for (i = 0; i <= ds.Tables["test"].Rows.Count - 1; i++)
                {
                    idbpinfo = Convert.ToInt16(ds.Tables["test"].Rows[i].ItemArray[0]);
                    filename = ds.Tables["test"].Rows[i].ItemArray[1].ToString();
                    Filepathfrom = ds.Tables["test"].Rows[i].ItemArray[2].ToString();
                    filepathto = ds.Tables["test"].Rows[i].ItemArray[3].ToString();
                    Filext = ds.Tables["test"].Rows[i].ItemArray[4].ToString();
                    ServerCat = ds.Tables["test"].Rows[i].ItemArray[5].ToString();
                    ServerLoc = ds.Tables["test"].Rows[i].ItemArray[6].ToString();
                    CopIPAddress = ds.Tables["test"].Rows[i].ItemArray[7].ToString();
                    CopyUsername = ds.Tables["test"].Rows[i].ItemArray[8].ToString();
                    CopyPassword = ds.Tables["test"].Rows[i].ItemArray[9].ToString();
                    PasteIPaddress = ds.Tables["test"].Rows[i].ItemArray[10].ToString();
                    PasteUsername = ds.Tables["test"].Rows[i].ItemArray[11].ToString();
                    PastePassword = ds.Tables["test"].Rows[i].ItemArray[12].ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection ! " + ex);
            }
            finally
            {
                con.Close();
            }
        }

        public string Sr { get; set; }
        public string destinationIP { get; set; }
        public string SysUser  { get; set; }
        public string SysPwd { get; set; }
        public string SqlServerName { get; set; }
        public string  sqlUser { get; set; }
        public string SqlPwd { get; set; }
        private void ComboBackupSchedule_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            loadjob();
            
        }

        private void btnLoadSqlBackup_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                con.Open();
                sql = "select * from sqlbk ";
                OleDbCommand cmd = new OleDbCommand(sql, con);
                OleDbDataAdapter sda = new OleDbDataAdapter(cmd);
                
                DataTable dtt = new DataTable();
                sda.Fill(dtt);
                ds.Tables.Add(dtt);

                DataGridSql.ItemsSource = dtt.DefaultView;
                DataGridSql.AutoGenerateColumns = true;


                //for (i = 0; i <= ds.Tables["sqldb"].Rows.Count - 1; i++)
                //{

                //    //Sr = dtt[i][""].ToString();
                //    destinationIP = ds.Tables["sqldb"].Rows[0].ItemArray[2].ToString();
                //    SysUser = ds.Tables["sqldb"].Rows[0].ItemArray[3].ToString();
                //    SysPwd = ds.Tables["sqldb"].Rows[0].ItemArray[4].ToString();
                //    SqlServerName = ds.Tables["sqldb"].Rows[0].ItemArray[5].ToString();
                //    sqlUser = ds.Tables["sqldb"].Rows[0].ItemArray[6].ToString();
                //    SqlPwd = ds.Tables["sqldb"].Rows[0].ItemArray[7].ToString();

                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection ! " + ex);
            }
            finally
            {
                con.Close();
            }
        }

        private void ShowSqlJob(int j)
        {
            //MessageBox.Show(ds.Tables[0].Rows[i].ItemArray[0] + " -- " + ds.Tables[0].Rows[i].ItemArray[1]);
            Sr = ds.Tables["sqldb"].Rows[i].ItemArray[1].ToString();
            destinationIP = ds.Tables["sqldb"].Rows[i].ItemArray[2].ToString();
            SysUser = ds.Tables["sqldb"].Rows[i].ItemArray[3].ToString();
            SysPwd = ds.Tables["sqldb"].Rows[i].ItemArray[4].ToString();
            SqlServerName = ds.Tables["sqldb"].Rows[i].ItemArray[5].ToString();
            sqlUser = ds.Tables["sqldb"].Rows[i].ItemArray[6].ToString();
            SqlPwd = ds.Tables["sqldb"].Rows[i].ItemArray[7].ToString();

            Lbl_iddb.Content = idbpinfo;
            Lbl_count.Content = Convert.ToString(counterbackup) + " Of " + ds.Tables[0].Rows.Count;
            Lbl_filename.Content = filename + Bpday;
            Lbl_copyPath.Content = Filepathfrom;
            Lbl_ipadd.Content = CopIPAddress;
            lbl_pastepath.Content = filepathto;
            Lbl_ipadd_paste.Content = PasteIPaddress;
            Lbl_ServerCatogry.Content = ServerCat;
            Lbl_backupschedule.Content = BpScheduleCombo.SelectedItem.ToString();

        }
    }
}
