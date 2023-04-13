using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VesterShoes.classes;
using VesterShoes.Reports;
using WaitWnd;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using Brushes = System.Windows.Media.Brushes;
using Button = System.Windows.Controls.Button;
using ContextMenu = System.Windows.Forms.ContextMenu;
using DragEventArgs = System.Windows.DragEventArgs;
using KeyEventArgs = System.Windows.Input.KeyEventArgs;
using MessageBox = System.Windows.MessageBox;
using MouseEventArgs = System.Windows.Forms.MouseEventArgs;
using TextBox = System.Windows.Forms.TextBox;
using System.IO;

namespace VesterShoes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string V = "-";
        SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["sqldbx"].ConnectionString);

        //VestureClass vc;

        public MainWindow(string loginuser)
        {
            InitializeComponent();
            // DigitalDataGrid.Paint += new PaintEventHandler(dataGrid_Paint);
            vc = new VestureClass();
            LoginUser = loginuser;
        }
        WaitWnd.WaitWndFun waitForm = new WaitWnd.WaitWndFun();

        int screenWidth;
        int screenHeight;
        int tb = 1;
        string LoginUser = "User";
        string PC = "default";
        functions f = new functions();
        public int custID { get; set; }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //waitForm.Show();
            screenWidth = int.Parse(SystemParameters.PrimaryScreenWidth.ToString());
            screenHeight = int.Parse(SystemParameters.PrimaryScreenHeight.ToString());
            MainTab.Width = this.screenWidth;
            MainTab.Height = this.screenHeight;
            SystemUser = System.Environment.UserName + "~" + System.Environment.MachineName;

            tbl_main.Columns.Add("Jobid");
            tbl_main.Columns.Add("Jobid2");
            tbl_main.Columns.Add("detail");
            tbl_main.Columns.Add("Qty");
            tbl_main.Columns.Add("cm");
            tbl_main.Columns.Add("sm");
            tbl_main.Columns.Add("pm");
            tbl_main.Columns.Add("pr");
            tbl_main.Columns.Add("am");
            tbl_main.Columns.Add("bm");
            tbl_main.Columns.Add("jm");
            tbl_main.Columns.Add("fm");
            tbl_main.Columns.Add("Party");
            tbl_main.Columns.Add("Sort");

            //LoadDigitalView(1);
            //DigitalDataGrid.DataSource = dtdigitalview;


            VenderLedgerToDatePicker.SelectedDate = DateTime.Today;
            DateTime day = DateTime.Today;
            if (day.DayOfWeek == DayOfWeek.Thursday)
            {
                day = day.AddDays(-1);
            }
            while (day.DayOfWeek != DayOfWeek.Thursday)
                day = day.AddDays(-1);

            VenderLedgerFromDatePicker.SelectedDate = day;
            //LoadAticle();
            //LoadType();
            //LoadColor();
            //LoadMaterial();
            //LoadSole();
            //fillDG_mixer();
            //tb_Firstfoot.IsEnabled = false;
            refreshCombo();//load profile combo vender and customer

            SqlCommand sqlCmdexp = new SqlCommand("select * from tblExpenseHead where MasterheadID='0'  and Active=1", sqlcon);
            if (sqlcon.State != ConnectionState.Open)
            {
                sqlcon.Open();
            }
            SqlDataReader sqlReaderExp = sqlCmdexp.ExecuteReader();
            Dictionary<int, string> DictionaryExpense = new Dictionary<int, string>();
            DictionaryExpense.Add(0, "Select Catagory");
            while (sqlReaderExp.Read())
            {
                string name = sqlReaderExp["ExpenseHead"].ToString().Trim();
                int Value = int.Parse(sqlReaderExp["expenseheadID"].ToString());
                DictionaryExpense.Add(Value, name);
            }
            Combcatogory.ItemsSource = new BindingSource(DictionaryExpense, null);
            Combcatogory.DisplayMemberPath = "Value";
            Combcatogory.SelectedValuePath = "Key";
            Combcatogory.SelectedIndex = 0;
            CombcatogoryView.ItemsSource = new BindingSource(DictionaryExpense, null);
            CombcatogoryView.DisplayMemberPath = "Value";
            CombcatogoryView.SelectedValuePath = "Key";
            CombcatogoryView.SelectedIndex = 0;
            sqlReaderExp.Close();
            if (sqlcon.State != ConnectionState.Closed)
            {
                sqlcon.Close();
            }

            DtPickDigitalViewFromdate.SelectedDate = DateTime.Today.AddMonths(-2);
            DtPickDigitalViewComboTodate.SelectedDate = DateTime.Today.AddDays(1);
            DtPickCustomerOrderBookFromdate.SelectedDate = DateTime.Today.AddMonths(-2);
            DtPickCustomerOrderBookTodate.SelectedDate = DateTime.Today.AddDays(1);
            CustLedgerFromDatePicker.SelectedDate = DateTime.Today.AddMonths(-1);
            CustLedgerToDatePicker.SelectedDate = DateTime.Today.AddDays(1);
            VenderLedgerToDatePicker.SelectedDate = DateTime.Today.AddDays(1);
            VenderLedgerFromDatePicker.SelectedDate = DateTime.Today.AddMonths(-1);

            //vender week
            DayOfWeek desiredDay = DayOfWeek.Friday;
            int offsetAmount = (int)desiredDay - (int)DateTime.Now.DayOfWeek;
            DateTime lastWeekfriday = DateTime.Now.AddDays(offsetAmount - 7);
            DtPickVenderOrderBookFromdate.SelectedDate = lastWeekfriday;
            DtPickVenderOrderBookTodate.SelectedDate = DateTime.Today;
            DtpickMyCompnyProdDelivFrom.SelectedDate=lastWeekfriday;
            DtpickMyCompnyProdDelivTo.SelectedDate = DateTime.Today;
            //DateTime nextWeekthursday = DateTime.Now.AddDays(7 + offsetAmount);
            //vender week end



            DateTime now = DateTime.Now;
            var startDate = new DateTime(now.Year, now.Month, 1);
            dtPickerExpenseFrom.SelectedDate = startDate;
            DtpickCashinHandFrom.SelectedDate = startDate;
            DtpickCashINHandTo.SelectedDate = DateTime.Today;
            dtPickerExpenseTo.SelectedDate = DateTime.Today;
            tb_LogDtPicker.SelectedDate = DateTime.Today;
            dtPickerExpenseDate.SelectedDate = DateTime.Today;
            var Friday = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Friday);
            //DtPickVenderWeeklySummaryFromdate.SelectedDate = Friday;
            //DtPickVenderWeeklySummaryTodate.SelectedDate = DateTime.Today;
            dtPickVenderLedgerPaidDate.SelectedDate = DateTime.Today;


            DigitalDataGrid.ItemsSource = tbl_main.DefaultView;
            DigitalDataGrid.DisplayMemberPath = tbl_main.Columns[0].ToString();
            CountData();
            //waitForm.Close();
            ExpComboFlag = 1;

            thdUDPServer1 = new Thread(new
           ThreadStart(backgroundservice));
            thdUDPServer1.IsBackground = true;
            thdUDPServer1.Start();
        }

        Thread thdUDPServer1;
        private void refreshCombo()
        {
            SqlCommand sqlCmd = new SqlCommand("select ProfileId,PCompanyName from tblProfile where PType='0'  and Active=1 order by PCompanyName", sqlcon);
            if (sqlcon.State != ConnectionState.Open)
            {
                sqlcon.Open();
            }
            SqlDataReader sqlReader = sqlCmd.ExecuteReader();
            Dictionary<int, string> DictionaryCustomer = new Dictionary<int, string>();
            DictionaryCustomer.Add(0, "Select Customer");
            while (sqlReader.Read())
            {
                string name = sqlReader["PCompanyName"].ToString().Trim();
                int Value = int.Parse(sqlReader["ProfileId"].ToString());
                DictionaryCustomer.Add(Value, name);
            }
            ComboDigitalViewCustomer.ItemsSource = new BindingSource(DictionaryCustomer, null);
            ComboDigitalViewCustomer.DisplayMemberPath = "Value";
            ComboDigitalViewCustomer.SelectedValuePath = "Key";
            ComboDigitalViewCustomer.SelectedIndex = 0;
            lblCompanyName.ItemsSource = new BindingSource(DictionaryCustomer, null);
            lblCompanyName.DisplayMemberPath = "Value";
            lblCompanyName.SelectedValuePath = "Key";
            lblCompanyName.SelectedIndex = 0;
            //lblCompanyNameVender.ItemsSource = new BindingSource(DictionaryCustomer, null);
            //lblCompanyNameVender.DisplayMemberPath = "Value";
            //lblCompanyNameVender.SelectedValuePath = "Key";
            //lblCompanyNameVender.SelectedIndex = -1;
            lblCustLedgerCompanyName.ItemsSource = new BindingSource(DictionaryCustomer, null);
            lblCustLedgerCompanyName.DisplayMemberPath = "Value";
            lblCustLedgerCompanyName.SelectedValuePath = "Key";
            lblCustLedgerCompanyName.SelectedIndex = -1;
            CombCustomerRatesCustomer.ItemsSource = new BindingSource(DictionaryCustomer, null);
            CombCustomerRatesCustomer.DisplayMemberPath = "Value";
            CombCustomerRatesCustomer.SelectedValuePath = "Key";
            sqlReader.Close();
            //load combo production digitalview Vender name
            SqlCommand sqlCmd2 = new SqlCommand("select ProfileId,PName from tblProfile where PType='1'  and Active=1 order by vender_type_id , PName", sqlcon);
            SqlDataReader sqlReader2 = sqlCmd2.ExecuteReader();
            Dictionary<int, string> DictionaryCustomer2 = new Dictionary<int, string>();
            DictionaryCustomer2.Add(-1, "Select Vender");
            while (sqlReader2.Read())
            {
                string name = sqlReader2["PName"].ToString();
                int Value = int.Parse(sqlReader2["ProfileId"].ToString());
                DictionaryCustomer2.Add(Value, name);
            }
            ComboDigitalViewVender.ItemsSource = new BindingSource(DictionaryCustomer2, null);
            ComboDigitalViewVender.DisplayMemberPath = "Value";
            ComboDigitalViewVender.SelectedValuePath = "Key";
            ComboDigitalViewVender.SelectedIndex = 0;
            lblVenderLedgerCompanyName.ItemsSource = new BindingSource(DictionaryCustomer2, null);
            lblVenderLedgerCompanyName.DisplayMemberPath = "Value";
            lblVenderLedgerCompanyName.SelectedValuePath = "Key";
            lblVenderLedgerCompanyName.SelectedIndex = 0;
            lblCompanyNameVender.ItemsSource = new BindingSource(DictionaryCustomer2, null);
            lblCompanyNameVender.DisplayMemberPath = "Value";
            lblCompanyNameVender.SelectedValuePath = "Key";
            lblCompanyNameVender.SelectedIndex = 0;
            CombVendRatesCustomer.ItemsSource = new BindingSource(DictionaryCustomer2, null);
            CombVendRatesCustomer.DisplayMemberPath = "Value";
            CombVendRatesCustomer.SelectedValuePath = "Key";
            lblCompanyNameVender.SelectedIndex = 0;
            sqlReader2.Close();
            RbProductiontbSearchbyBill.IsChecked = true;
            if (sqlcon.State != ConnectionState.Closed)
            {
                sqlcon.Close();
            }
        }

        private void btnAddOrderRefresh_Click(object sender, RoutedEventArgs e)
        {

        }
        //load customer ledger commision combo

        int loop = 0;
        private void backgroundservice()
        {
            try
            {

                while (loop == 1)
                {

                    //Application.Current.Dispatcher.Invoke((Action)(() =>
                    System.Windows.Application.Current.Dispatcher.Invoke((Action)(() =>
                    {
                        DateTime startdate = (DateTime)DtPickDigitalViewFromdate.SelectedDate;
                        string startdate1 = startdate.ToString("yyyy-MM-dd");
                        DateTime enddate = (DateTime)DtPickDigitalViewComboTodate.SelectedDate;
                        string enddate1 = enddate.ToString("yyyy-MM-dd");
                        //string s = ("select JobID,ItemsDescription,ItemsQty from tblOrders tp , tblItems ti where tp.ItemsID=ti.ItemsID and tp.JobStartDate >= '" + startdate1 + "' and tp.JobStartDate <=  '" + enddate1 + "' and tp.jobStates='" + calljobstates + "' order by JobID ");
                        //string s = "select jobid,ItemsDescription,ItemsQty,cust_company,Cust_name,CONCAT(cm_issu,cm,cm_ret) as cm from Vw_RunningProductionStatus";
                        string s = "select * from Vw_RunningProductionStatus";
                        DataTable dtproduction = vc.selectdatatable(s);
                        RunningProduction.ItemsSource = dtproduction.DefaultView;
                        RunningProduction.DisplayMemberPath = dtproduction.Columns[0].ToString();
                    }));
                    
                }


            }
            catch (Exception es)
            {
                //wf.Close();
                MessageBox.Show(es.Message);
            }
        }

        private void btnOrderForm_Click(object sender, RoutedEventArgs e)
        {
            this.Title = "ORDER";
        }

        // order form start here
        #region orderForm
        int flagF = 0;
        private void btnAddOrder_Click(object sender, RoutedEventArgs e)
        {
            chkbxSelectAllOrders.IsChecked = false;
            gvar = "Orderform";
            FormProfileFm fcf = new FormProfileFm(gvar, LoginUser, SystemUser);
            if (fcf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                custID = fcf.GlobalVar;
            };
            refreshCombo();
            if (custID == 0)
            {
                return;
            }
            flagF = 1;
            lblCompanyName.SelectedValue = custID;
            Loadgridorder();
            lblCustomerID.Content = custID.ToString();
            CountData();

        }

        private void CountData()
        {
            if (lblCustomerID.Content.ToString() != "")
            {
                int guardian = f.findnumber("select PGaurdianNameID from  tblprofile  where   ProfileId='" + custID + "' ");
                if (guardian > 0)
                {
                    string strbalanceamount = "select SUM(CreditAmount)-SUM(DebitAmount) as BalanceAmount  from tblLedger l, tblProfile p where l.ProfileId=p.ProfileId and PGaurdianNameID = '" + guardian + "' ";

                    int Bal = f.findnumber(strbalanceamount);
                    lblBalanceAmount.Content = Bal.ToString();
                }
                else
                {
                    int Bal = f.findnumber("select SUM(CreditAmount)-SUM(DebitAmount) as BalanceAmount  from tblLedger where ProfileId='" + custID + "' ");
                    lblBalanceAmount.Content = Bal.ToString();
                }
                int RunningOrders = f.findnumber("select COUNT(*) from tblOrders where ProfileId='" + custID + "' and Complete='0' and jobStates='1'");
                lblRunningOrders.Content = RunningOrders.ToString();
                int pendingOrders = f.findnumber("select COUNT(*) from tblOrders where ProfileId='" + custID + "' and Complete='0' and jobStates='0'");
                lblPendingOrders.Content = pendingOrders.ToString();
            }
            else
            {
                int RunningOrders = f.findnumber("select COUNT(*) from tblOrders where  Complete='0' and jobStates='1'");
                lblRunningOrders.Content = RunningOrders.ToString();
                int pendingOrders = f.findnumber("select COUNT(*) from tblOrders where  Complete='0' and jobStates='0'");
                lblPendingOrders.Content = pendingOrders.ToString();
            }


        }
        private void CountDataVender()
        {
            if (chkbxSelectAllWork.IsChecked == false)
            {
                int Bal = f.findnumber("select SUM(VAmount) as BalanceAmount  from tblVenderBills where ProfileId='" + venderid + "' ");
                LblBalanceAmountVender.Content = Bal.ToString();
                int RunningOrders = f.findnumber("select COUNT(*) from tblVenderOrders where ReturnDate is null and ProfileId ='" + venderid + "' ");
                lblRunningOrdersVender.Content = RunningOrders.ToString();
                int CompltOrders = f.findnumber("select COUNT(*) from tblVenderOrders where ReturnDate is not null and ProfileId ='" + venderid + "'");
                lblCompletedOrdersVender.Content = CompltOrders.ToString();
            }
            else
            {
                int Bal = f.findnumber("select SUM(VAmount) as BalanceAmount  from tblVenderBills  ");
                LblBalanceAmountVender.Content = Bal.ToString();
                int RunningOrders = f.findnumber("select COUNT(*) from tblVenderOrders where ReturnDate is null  ");
                lblRunningOrdersVender.Content = RunningOrders.ToString();
                int CompltOrders = f.findnumber("select COUNT(*) from tblVenderOrders where ReturnDate is not null ");
                lblCompletedOrdersVender.Content = CompltOrders.ToString();
            }


        }

        
        private void LoadVender_OrderBookform(int id)
        {
            if (id != 0)
            {
                try
                {
                    SqlDataReader dr;
                    sqlcon.Open();
                    string query = "Select pcompanyname,pname,paddress , vender_type_Descr from tblProfile f , tblProcessStates p where p.vender_type_id = f.vender_type_id and ProfileId ='" + id + "'";
                    SqlCommand cmd = new SqlCommand(query, sqlcon);//Advised to use parameterized query
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        lblVenderID.Content = id;
                        lblCompanyNameVender.Text = (dr.GetValue(0).ToString());

                    }
                    else
                    {
                        System.Windows.MessageBox.Show("No Record Found");

                    }
                    dr.Close();
                    lblCompanyNameVender.Visibility = Visibility.Visible;
                    LoadgridVenderorder();

                }
                catch (Exception es)
                {
                    System.Windows.Forms.MessageBox.Show(es.Message.ToString());
                    return;
                }
                finally
                {
                    sqlcon.Close();
                }
            }

        }
        private void LoadVender_Orderform(int id)
        {
            if (id != 0)
            {
                try
                {
                    SqlDataReader dr;
                    sqlcon.Open();
                    string query = "Select pcompanyname,pname,pofficenumber,paddress from tblProfile where ProfileId='" + id + "'";
                    SqlCommand cmd = new SqlCommand(query, sqlcon);//Advised to use parameterized query
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        lblVenderID.Content = id;
                        lblCompanyNameVender.Text = (dr.GetValue(0).ToString());
                    }
                    else
                    {
                        LblMsgVendOrderbook.Content = "No Vender Found";

                    }
                    dr.Close();
                    lblCompanyNameVender.Visibility = Visibility.Visible;
                    LoadgridVenderorder();

                }
                catch (Exception es)
                {
                    System.Windows.Forms.MessageBox.Show(es.Message.ToString());
                    return;
                }
                finally
                {
                    sqlcon.Close();
                }
            }

        }

        int sortid = 0;
        //private int col = 0;
        //int row = 1;
        //string Itemgselected = "";

        private void clearall1()
        {
            //TxtitemId.Text = "";

            //lblCustomerID.Content = "";
            //lblCompanyName.Text = "";
            //lblofficenumber.Visibility = Visibility.Hidden;
            //lblofficeaddress.Visibility = Visibility.Hidden;
            //lblpname.Visibility = Visibility.Hidden;
            //lblCompanyName.Visibility = Visibility.Hidden;

        }
        DataSet dtorder = new DataSet();
        DataSet dtLog = new DataSet();
        private void Loadgridorder()
        {
            try
            {
                btnRunningOrders.Foreground = Brushes.Blue;
                btnDeliverdOrders.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 8, 141, 14));
                btnCompletedOrders.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 8, 141, 14));
                btnPendingOrders.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 8, 141, 14));
                //DataSet ds = new DataSet();
                if (DtPickCustomerOrderBookTodate.SelectedDate != null && DtPickCustomerOrderBookFromdate.SelectedDate != null)
                {
                    string startdate = ((DateTime)DtPickCustomerOrderBookFromdate.SelectedDate).ToString("yyyy-MM-dd");
                    string enddate = ((DateTime)DtPickCustomerOrderBookTodate.SelectedDate).ToString("yyyy-MM-dd");
                    string s = "";
                    if (lblCustomerID.Content.ToString() != "")
                    {
                        s = "select o.orderdatetime,orderid,sortid,i.itemsdescription,itemsqty,orderstatus,jobid,invoiceid,p.PCompanyName,o.jobStates  from tblorders o , tblItems i, tblProfile p where o.ItemsID=i.ItemsID and o.ProfileId=p.ProfileId and o.ProfileId='" +
                               lblCustomerID.Content + "' and Complete=0 and jobStates <= 1 and o.OrderDatetime >= '" + startdate +
                               "' and o.OrderDatetime <=  '" + enddate + "'  order by OrderID desc";
                    }
                    else
                    {
                        s = "select o.orderdatetime,orderid,sortid,i.itemsdescription,itemsqty,orderstatus,jobid,invoiceid,p.PCompanyName,o.jobStates  from tblorders o , tblItems i, tblProfile p where o.ItemsID=i.ItemsID and o.ProfileId=p.ProfileId and Complete=0 and jobStates <= 1 and o.OrderDatetime >= '" + startdate +
                               "' and o.OrderDatetime <=  '" + enddate + "'  order by OrderID desc";
                    }

                    if (vc != null) dtorder = vc.Select(s);
                }
                loadPlotPanel();
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }

        private void ChkbxSelectAllOrders_OnChecked(object sender, RoutedEventArgs e)
        {
            //lblpname.Content = "";
            lblCustomerID.Content = "";
            lblCompanyName.Text = "";
            dtorder.Clear();
        }

        private void ChkbxSelectAllOrders_OnUnchecked(object sender, RoutedEventArgs e)
        {
            dtorder.Clear();
        }
        int varfontsize = 15;
        byte rforground = 255;
        byte gforground = 245;
        byte bforground = 238;
        byte rfontColor = 40;
        byte gfontColor = 40;
        byte bfontColor = 43;

        private void loadPlotPanel()
        {
            orderdetail.Children.Clear();
            orderdetail.RowDefinitions.Clear();
            int rowCounter = 0;

            try
            {
                int countorders = dtorder.Tables["table"].Rows.Count;
                for (int j = 0; j < countorders; j++)
                {
                    DateTime dt = DateTime.Parse(dtorder.Tables["Table"].Rows[j][0].ToString());
                    string orderdate = dt.ToString("dd-MM-yyyy");
                    //string orderdate = DateTime.Parse(dtorder.Tables["table"].Rows[j][0].ToString()).ToString("dd-MM-yyyy");
                    string order = (dtorder.Tables["table"].Rows[j][1].ToString());
                    string sorrt = (dtorder.Tables["table"].Rows[j][2].ToString());
                    string itemdetail = (dtorder.Tables["table"].Rows[j][3].ToString());
                    string sqty = (dtorder.Tables["table"].Rows[j][4].ToString());
                    string cstatus = (dtorder.Tables["table"].Rows[j][5].ToString());
                    string jobid = (dtorder.Tables["table"].Rows[j][6].ToString());
                    string invoice = (dtorder.Tables["table"].Rows[j][7].ToString());
                    string comp = (dtorder.Tables["table"].Rows[j][8].ToString());
                    string jobState = (dtorder.Tables["table"].Rows[j][9].ToString());

                    System.Windows.Controls.Label lblOrderdate = new System.Windows.Controls.Label
                    {
                        Name = "lblorderdate",
                        Content = orderdate,
                        FontSize = varfontsize,
                        Foreground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(rfontColor, gfontColor, bfontColor))
                    };
                    System.Windows.Controls.Label lblordernumber = new System.Windows.Controls.Label
                    {
                        Name = "lblordernumber_" + order + "_" + sorrt,
                        Content = order + "-" + sorrt,
                        FontSize = varfontsize,
                        Foreground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(rfontColor, gfontColor, bfontColor))
                    };
                    System.Windows.Controls.TextBlock lblitemdetail = new System.Windows.Controls.TextBlock
                    {
                        Name = "lblitemdetail",
                        Width = 500,
                        TextAlignment = System.Windows.TextAlignment.Center,
                        VerticalAlignment = System.Windows.VerticalAlignment.Center,
                        TextWrapping = System.Windows.TextWrapping.Wrap,
                        TextTrimming = TextTrimming.CharacterEllipsis,
                        FontSize = varfontsize,
                        LineStackingStrategy = LineStackingStrategy.BlockLineHeight,
                        //LineHeight =28,
                        Text = itemdetail,
                        Foreground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(rfontColor, gfontColor, bfontColor))
                    };
                    //System.Windows.Controls.Label lblitemdetail = new System.Windows.Controls.Label() { };

                    //lblitemdetail.Content = new TextBlock() { FontSize = varfontsize, Text = lblitemdetail1.Text, TextWrapping = TextWrapping.Wrap };
                    System.Windows.Controls.TextBlock lblCompany = new System.Windows.Controls.TextBlock
                    {
                        Name = "lblCompany",
                        Text = comp,
                        Width = 300,
                        VerticalAlignment = System.Windows.VerticalAlignment.Center,
                        TextAlignment = System.Windows.TextAlignment.Center,
                        TextWrapping = System.Windows.TextWrapping.Wrap,
                        TextTrimming = TextTrimming.CharacterEllipsis,
                        FontSize = varfontsize,
                        LineStackingStrategy = LineStackingStrategy.BlockLineHeight,
                        Foreground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(rfontColor, gfontColor, bfontColor))
                    };
                    System.Windows.Controls.Label lblqty = new System.Windows.Controls.Label
                    {
                        Name = "lblqty",
                        Content = sqty,
                        FontSize = varfontsize,
                        HorizontalContentAlignment = System.Windows.HorizontalAlignment.Center,
                        Foreground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(rfontColor, gfontColor, bfontColor))
                    };
                    //if (jobState == "0")
                    //{
                    //    cstatus = "0";
                    //}
                    System.Windows.Controls.CheckBox chkStatus = new System.Windows.Controls.CheckBox
                    {
                        Name = "chkStatus_" + order + "_" + sorrt,
                        FontSize = varfontsize + 10,
                        Foreground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(rfontColor, gfontColor, bfontColor))
                    };
                    if (jobState == "1")
                    {
                        chkStatus.IsChecked = true;
                        chkStatus.IsEnabled = false;
                    }
                    System.Windows.Controls.Label lbljobid = new System.Windows.Controls.Label
                    {
                        Name = "lbljobid",
                        Content = jobid,
                        FontSize = varfontsize,
                        Foreground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(rfontColor, gfontColor, bfontColor))
                    };
                    System.Windows.Controls.Label lblinvoiceid = new System.Windows.Controls.Label
                    {
                        Name = "invoiceid",
                        Content = invoice,
                        FontSize = varfontsize,
                        Foreground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(rfontColor, gfontColor, bfontColor))
                    };


                    Button btndetail = new Button
                    {
                        Name = "btndetail_" + order + "_" + sorrt,
                        Content = "Detail",
                        FontSize = varfontsize,
                        Foreground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(rfontColor, gfontColor, bfontColor))
                    };
                    if (jobState == "6")
                    {
                        lblordernumber.Foreground = Brushes.Red;
                        lblitemdetail.Foreground = Brushes.Red;
                        lblCompany.Foreground = Brushes.Red;
                        lblqty.Foreground = Brushes.Red;
                        chkStatus.Foreground = Brushes.Red;
                        lbljobid.Foreground = Brushes.Red;
                        lblinvoiceid.Foreground = Brushes.Red;
                        lblOrderdate.Foreground = Brushes.Red;
                        btndetail.Foreground = Brushes.Red;
                    }

                    if (j % 2 == 0)
                    {
                        lblordernumber.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(rforground, gforground, bforground));
                        //lblitemdetail.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(rforground, gforground, bforground));
                        //lblCompany.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(rforground, gforground, bforground));
                        lblqty.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(rforground, gforground, bforground));
                        //chkStatus.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(rforground, gforground, bforground));
                        lbljobid.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(rforground, gforground, bforground));
                        lblinvoiceid.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(rforground, gforground, bforground));
                        lblOrderdate.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(rforground, gforground, bforground));
                        btndetail.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(rforground, gforground, bforground));
                    }
                    else
                    {
                        lblordernumber.Background = Brushes.LightCyan;
                        //lblitemdetail.Background = Brushes.LightCyan;
                        //lblCompany.Background = Brushes.LightCyan;
                        lblqty.Background = Brushes.LightCyan;
                        //chkStatus.Background = Brushes.LightCyan;
                        lbljobid.Background = Brushes.LightCyan;
                        lblinvoiceid.Background = Brushes.LightCyan;
                        lblOrderdate.Background = Brushes.LightCyan;
                        btndetail.Background = Brushes.LightCyan;
                    }
                    //lPno.BorderBrush = System.Windows.Media.Brushes.OrangeRed;
                    //lPno.Background = System.Windows.Media.Brushes.OrangeRed;
                    //if (int.Parse(PlotSold) == 1)
                    //{
                    //    lPno.BorderBrush = System.Windows.Media.Brushes.Yellow;
                    //    lPno.Background = System.Windows.Media.Brushes.Yellow;
                    //}
                    //if (int.Parse(isininstallment) == 1)
                    //{
                    //    lPno.BorderBrush = System.Windows.Media.Brushes.LawnGreen;
                    //    lPno.Background = System.Windows.Media.Brushes.LawnGreen;
                    //}
                    //if (int.Parse(isforSold) == 0 && int.Parse(isininstallment) == 0)
                    //{
                    //    lPno.BorderBrush = System.Windows.Media.Brushes.White;
                    //    lPno.Background = System.Windows.Media.Brushes.DeepSkyBlue;
                    //}

                    chkStatus.Checked += new RoutedEventHandler(onOrdercheckstatus);
                    btndetail.Click += new RoutedEventHandler(Orderbtndetail_onclick);

                    //lPno.BorderBrush = Brushes.Black;
                    Grid.SetColumn(lblOrderdate, 0);
                    Grid.SetRow(lblOrderdate, rowCounter);
                    orderdetail.Children.Add(lblOrderdate);
                    Grid.SetColumn(lblordernumber, 1);
                    Grid.SetRow(lblordernumber, rowCounter);
                    orderdetail.Children.Add(lblordernumber);
                    Grid.SetColumn(lblitemdetail, 2);
                    Grid.SetRow(lblitemdetail, rowCounter);
                    orderdetail.Children.Add(lblitemdetail);
                    Grid.SetColumn(lblCompany, 3);
                    Grid.SetRow(lblCompany, rowCounter);
                    orderdetail.Children.Add(lblCompany);
                    Grid.SetColumn(lblqty, 4);
                    Grid.SetRow(lblqty, rowCounter);
                    orderdetail.Children.Add(lblqty);
                    Grid.SetColumn(chkStatus, 5);
                    Grid.SetRow(chkStatus, rowCounter);
                    orderdetail.Children.Add(chkStatus);
                    Grid.SetColumn(lbljobid, 6);
                    Grid.SetRow(lbljobid, rowCounter);
                    orderdetail.Children.Add(lbljobid);
                    Grid.SetColumn(lblinvoiceid, 7);
                    Grid.SetRow(lblinvoiceid, rowCounter);
                    orderdetail.Children.Add(lblinvoiceid);
                    Grid.SetColumn(btndetail, 8);
                    Grid.SetRow(btndetail, rowCounter);
                    orderdetail.Children.Add(btndetail);
                    int lengthdesc = itemdetail.Length;
                    int heightCol = 0;
                    if (lengthdesc < 61)
                    {
                        heightCol = 30;
                    }
                    else if (lengthdesc > 60)
                    {
                        heightCol = 50;
                    }
                    orderdetail.RowDefinitions.Add(new RowDefinition()
                    {
                        Height = new GridLength(heightCol),

                    });
                    rowCounter++;
                }
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }
        private void Orderbtndetail_onclick(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedcheckbox = (Button)sender;
                string selectedCBName = (selectedcheckbox.Name);
                string[] infoarr = selectedCBName.Split('_');
                int orderidd = int.Parse(infoarr[1]);
                int sortidd = int.Parse(infoarr[2]);
                formOrderModificationfm fomf = new formOrderModificationfm(orderidd, sortidd);
                fomf.ShowDialog();
                Loadgridorder();
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }
        private void onOrdercheckstatus(object sender, RoutedEventArgs e)
        {
            var selectedcheckbox = (System.Windows.Controls.CheckBox)sender;
            string selectedCBName = (selectedcheckbox.Name);
            string[] infoarr = selectedCBName.Split('_');
            string orderidd = (infoarr[1]);
            string sortidd = (infoarr[2]);
            int jobstates = f.findnumber("select jobStates from tblOrders where OrderID= '" + orderidd + "' and sortid='" + sortidd + "'");
            int pJobnumb = f.findnumber("select JobID from tblOrders where orderid='" + orderidd + "' and sortid='" + sortidd + "' ");
            if (pJobnumb == 0 && jobstates==0)
            {
                string dt = (DateTime.Today).ToString("yyyy-MM-dd");
                int Jobnumb = f.createNumber("select top(1) JobID from tblOrders order by JobID desc");
                vc.Update("update tblOrders set jobid='" + Jobnumb + "', jobStates='1' , OrderStatus='1', JobStartDate='" + dt + "', jobEnteredby='" + LoginUser + "', jobenteredon='" + DateTime.Now.ToString("yyyy-MM-dd HH:M:ss") + "' where orderid='" + orderidd + "' and sortid='" + sortidd + "'  ");
                Loadgridorder();
                jobCardForm jcd = new jobCardForm("", orderidd, sortidd);
                jcd.Show();
                CountData();
            }
            else
            {
                MessageBox.Show("Job already created or Order status is not in pending.");
               
                    jobCardForm jcd = new jobCardForm("Dupliate", orderidd, sortidd);
               

            }

        }


        private void BtnCompletedOrders_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                btnRunningOrders.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 8, 141, 14));
                btnPendingOrders.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 8, 141, 14));
                btnDeliverdOrders.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 8, 141, 14));
                btnAllOrders.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 8, 141, 14));
                btnCompletedOrders.Foreground = Brushes.Blue;
                if (DtPickCustomerOrderBookFromdate.SelectedDate != null && DtPickCustomerOrderBookTodate.SelectedDate != null)
                {
                    string startdate = ((DateTime)DtPickCustomerOrderBookFromdate.SelectedDate).ToString("yyyy-MM-dd");
                    string enddate = ((DateTime)DtPickCustomerOrderBookTodate.SelectedDate).ToString("yyyy-MM-dd");
                    // DataSet ds = new DataSet();
                    dtorder = lblCustomerID.Content.ToString() != "" ? vc.Select("select o.orderdatetime,orderid,sortid,i.itemsdescription,itemsqty,orderstatus,jobid,invoiceid,p.PCompanyName from tblorders o , tblItems i, tblProfile p  where o.ItemsID=i.ItemsID and o.ProfileId=p.ProfileId and o.ProfileId='" + lblCustomerID.Content + "' and Complete='1' and jobStates='5' and  o.OrderDatetime >= '" + startdate + "' and o.OrderDatetime <=  '" + enddate + "' order by OrderID desc") : vc.Select("select o.orderdatetime,orderid,sortid,i.itemsdescription,itemsqty,orderstatus,jobid,invoiceid,p.PCompanyName,o.jobStates from tblorders o , tblItems i, tblProfile p where o.ItemsID=i.ItemsID  and o.ProfileId=p.ProfileId  and Complete='1' and jobStates='5' and  o.OrderDatetime >= '" + startdate + "' and o.OrderDatetime <=  '" + enddate + "' order by OrderID desc");
                }
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }

            loadPlotPanel();
            CountData();
        }
        private void btnAllOrders_Click(object sender, RoutedEventArgs e)
        {
            btnRunningOrders.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 8, 141, 14));
            btnDeliverdOrders.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 8, 141, 14));
            btnPendingOrders.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 8, 141, 14));
            btnCompletedOrders.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 8, 141, 14));
            btnAllOrders.Foreground = Brushes.Blue;
            if (DtPickCustomerOrderBookFromdate.SelectedDate != null && DtPickCustomerOrderBookTodate.SelectedDate != null)
            {
                string startdate = ((DateTime)DtPickCustomerOrderBookFromdate.SelectedDate).ToString("yyyy-MM-dd");
                string enddate = ((DateTime)DtPickCustomerOrderBookTodate.SelectedDate).ToString("yyyy-MM-dd");
                // DataSet ds = new DataSet();
                dtorder = lblCustomerID.Content.ToString() != "" ? vc.Select("select o.orderdatetime,orderid,sortid,i.itemsdescription,itemsqty,orderstatus,jobid,invoiceid,p.PCompanyName,o.jobStates from tblorders o , tblItems i, tblProfile p where o.ItemsID=i.ItemsID  and o.ProfileId=p.ProfileId and o.ProfileId='" + lblCustomerID.Content + "' and  o.OrderDatetime >= '" + startdate + "' and o.OrderDatetime <=  '" + enddate + "' order by OrderID desc") : vc.Select("select o.orderdatetime,orderid,sortid,i.itemsdescription,itemsqty,orderstatus,jobid,invoiceid,p.PCompanyName,o.jobStates from tblorders o , tblItems i, tblProfile p where o.ItemsID=i.ItemsID  and o.ProfileId=p.ProfileId  and  o.OrderDatetime >= '" + startdate + "' and o.OrderDatetime <=  '" + enddate + "' order by OrderID desc");
            }
            loadPlotPanel();
            CountData();
        }
        private void BtnRunningOrders_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                btnCompletedOrders.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 8, 141, 14));
                btnDeliverdOrders.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 8, 141, 14));
                btnAllOrders.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 8, 141, 14));
                btnPendingOrders.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 8, 141, 14));
                btnRunningOrders.Foreground = Brushes.Blue;

                if (DtPickCustomerOrderBookTodate.SelectedDate != null && DtPickCustomerOrderBookFromdate.SelectedDate != null)
                {
                    string startdate = ((DateTime)DtPickCustomerOrderBookFromdate.SelectedDate).ToString("yyyy-MM-dd");
                    string enddate = ((DateTime)DtPickCustomerOrderBookTodate.SelectedDate).ToString("yyyy-MM-dd");
                    string s = "";
                    if (lblCustomerID.Content.ToString() != "")
                    {
                        s = "select o.orderdatetime,orderid,sortid,i.itemsdescription,itemsqty,orderstatus,jobid,invoiceid,p.PCompanyName,o.jobStates from tblorders o , tblItems i, tblProfile p where o.ItemsID=i.ItemsID and o.ProfileId=p.ProfileId and o.ProfileId='" +
                               lblCustomerID.Content + "' and Complete=0 and jobStates = 1 and o.OrderDatetime >= '" + startdate +
                               "' and o.OrderDatetime <=  '" + enddate + "'  order by OrderID desc";
                    }
                    else
                    {
                        s = "select o.orderdatetime,orderid,sortid,i.itemsdescription,itemsqty,orderstatus,jobid,invoiceid,p.PCompanyName,o.jobStates from tblorders o , tblItems i, tblProfile p where o.ItemsID=i.ItemsID and o.ProfileId=p.ProfileId and Complete=0 and jobStates = 1 and o.OrderDatetime >= '" + startdate +
                               "' and o.OrderDatetime <=  '" + enddate + "'  order by OrderID desc";
                    }

                    if (vc != null) dtorder = vc.Select(s);
                }
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }

            loadPlotPanel();
            CountData();
        }
        private void BtnPendingOrders_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                btnCompletedOrders.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 8, 141, 14));
                btnDeliverdOrders.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 8, 141, 14));
                btnAllOrders.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 8, 141, 14));
                btnRunningOrders.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 8, 141, 14));
                btnPendingOrders.Foreground = Brushes.Blue;

                if (DtPickCustomerOrderBookTodate.SelectedDate != null && DtPickCustomerOrderBookFromdate.SelectedDate != null)
                {
                    string startdate = ((DateTime)DtPickCustomerOrderBookFromdate.SelectedDate).ToString("yyyy-MM-dd");
                    string enddate = ((DateTime)DtPickCustomerOrderBookTodate.SelectedDate).ToString("yyyy-MM-dd");
                    string s = "";
                    if (lblCustomerID.Content.ToString() != "")
                    {
                        s = "select o.orderdatetime,orderid,sortid,i.itemsdescription,itemsqty,orderstatus,jobid,invoiceid,p.PCompanyName,o.jobStates from tblorders o , tblItems i, tblProfile p where o.ItemsID=i.ItemsID and o.ProfileId=p.ProfileId and o.ProfileId='" +
                               lblCustomerID.Content + "' and Complete=0 and jobStates = 0 and o.OrderDatetime >= '" + startdate +
                               "' and o.OrderDatetime <=  '" + enddate + "'  order by OrderID desc";
                    }
                    else
                    {
                        s = "select o.orderdatetime,orderid,sortid,i.itemsdescription,itemsqty,orderstatus,jobid,invoiceid,p.PCompanyName,o.jobStates from tblorders o , tblItems i, tblProfile p where o.ItemsID=i.ItemsID and o.ProfileId=p.ProfileId and Complete=0 and jobStates = 0 and o.OrderDatetime >= '" + startdate +
                               "' and o.OrderDatetime <=  '" + enddate + "'  order by OrderID desc";
                    }

                    if (vc != null) dtorder = vc.Select(s);
                }
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }

            loadPlotPanel();
            CountData();
        }

        private void BtnDeliverdOrders_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                btnRunningOrders.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 8, 141, 14));
                btnDeliverdOrders.Foreground = Brushes.Blue;
                btnCompletedOrders.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 8, 141, 14));
                btnPendingOrders.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 8, 141, 14));
                btnAllOrders.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 8, 141, 14));
                if (DtPickCustomerOrderBookFromdate.SelectedDate != null && DtPickCustomerOrderBookTodate.SelectedDate != null)
                {
                    string startdate = ((DateTime)DtPickCustomerOrderBookFromdate.SelectedDate).ToString("yyyy-MM-dd");

                    string enddate = ((DateTime)DtPickCustomerOrderBookTodate.SelectedDate).ToString("yyyy-MM-dd");
                    if (lblCustomerID.Content.ToString() != "")
                    {
                        dtorder =
                             vc.Select("select o.orderdatetime,orderid,sortid,i.itemsdescription,itemsqty,orderstatus,jobid,o.invoiceid,p.PCompanyName,o.jobStates from tblorders o , tblItems i,tblProfile p,tblMasterInvoice mi  where o.Invoiceid=mi.InvoiceID and  mi.ProfileId=p.ProfileId and o.ItemsID=i.ItemsID and mi.ProfileId='" +
                                       lblCustomerID.Content + "' and Complete='1' and  o.OrderDatetime >= '" + startdate +
                                       "' and o.OrderDatetime <=  '" + enddate + "' order by OrderID desc");
                    }
                    else
                    {
                        dtorder =
                           vc.Select("select o.orderdatetime,orderid,sortid,i.itemsdescription,itemsqty,orderstatus,jobid,o.invoiceid,p.PCompanyName,o.jobStates from tblorders o , tblItems i,tblProfile p,tblMasterInvoice mi  where o.Invoiceid=mi.InvoiceID and  mi.ProfileId=p.ProfileId and o.ItemsID=i.ItemsID and Complete='1' and  o.OrderDatetime >= '" + startdate +
                                     "' and o.OrderDatetime <=  '" + enddate + "' order by OrderID desc");
                    }
                    //deliver button chagne
                    //if (lblCustomerID.Content.ToString() != "")
                    //{
                    //    dtorder =
                    //         vc.Select("select o.orderdatetime,orderid,sortid,i.itemsdescription,itemsqty,orderstatus,jobid,o.invoiceid,p.PCompanyName,o.jobStates from tblorders o , tblItems i,tblProfile p,tblMasterInvoice mi  where o.Invoiceid=mi.InvoiceID and  mi.ProfileId=p.ProfileId and o.ItemsID=i.ItemsID and mi.ProfileId='" +
                    //                   lblCustomerID.Content + "' and Complete='1' and jobStates='8' and  o.OrderDatetime >= '" + startdate +
                    //                   "' and o.OrderDatetime <=  '" + enddate + "' order by OrderID desc");
                    //}
                    //else
                    //{
                    //    dtorder =
                    //       vc.Select("select o.orderdatetime,orderid,sortid,i.itemsdescription,itemsqty,orderstatus,jobid,o.invoiceid,p.PCompanyName,o.jobStates from tblorders o , tblItems i,tblProfile p,tblMasterInvoice mi  where o.Invoiceid=mi.InvoiceID and  mi.ProfileId=p.ProfileId and o.ItemsID=i.ItemsID and Complete='1' and jobStates='8' and  o.OrderDatetime >= '" + startdate +
                    //                 "' and o.OrderDatetime <=  '" + enddate + "' order by OrderID desc");
                    //}

                }
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }

            loadPlotPanel();
            CountData();
        }

        //public int CustomerID { get; set; }
        public string CompanyName { get; set; }
        public int itemID { get; set; }
        public string Item { get; set; }
        public int isstamp { get; set; }
        public int isbox { get; set; }
        public int itemQty { get; set; }
        public int itemRate { get; set; }
        public int total { get; set; }


        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

            //lblofficenumber.Visibility = Visibility.Hidden;
            //lblofficeaddress.Visibility = Visibility.Hidden;
            //lblpname.Visibility = Visibility.Hidden;
            //lblCompanyName.Visibility = Visibility.Hidden;

            //itemsForm itf = new itemsForm();
            //itf.Show();
        }

        private void LoadgridVenderorder()
        {
            DateTime dtf = DateTime.Parse(DtPickVenderOrderBookFromdate.SelectedDate.ToString());
            DateTime dtt = DateTime.Parse(DtPickVenderOrderBookTodate.SelectedDate.ToString());
            btnRunningOrdersVender.Foreground = Brushes.Blue;
            btnCompletedOrdersVender.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 8, 141, 14));
            btnLedgerVender.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 8, 141, 14));
            DataSet ds = new DataSet();
            ds.Tables.Clear();
            string str = "select IssueDate,VenderAccountid,ProcessiingID,v.ProfileId,ItemsDescription,IssueQty,IssueRate,(IssueQty*IssueRate)as TotalBill,ReturnDate,ReturnQty from tblVenderOrders v ,tblOrders o, tblItems i where v.ProcessiingID=o.JobID and o.ItemsID=i.ItemsID and v.ProfileId='" + lblVenderID.Content + "' and v.IssueDate >= '" + dtf.ToString("yyyy-MM-dd") + "' and v.IssueDate <=  '" + dtt.ToString("yyyy-MM-dd") + "' and ReturnDate is Null  order by ProcessiingID desc";
            if (vc != null) ds = vc.Select(str);
            //v.IssueDate >= '" + dtf.ToString("yyyy-MM-dd") + "' and v.IssueDate <=  '" + dtt.ToString("yyyy-MM-dd") + "' 
            GridVenderOrder.ItemsSource = ds.Tables[0].DefaultView;
            GridVenderOrder.DisplayMemberPath = ds.Tables[0].Columns[0].ToString();

        }
        VestureClass vc = new VestureClass();

        private void gridOrderDejtail_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void gridOrderDejtail_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //try
            //{
            //    int id = 0;
            //    DataRowView dataRow = (DataRowView)gridOrderDejtail.SelectedItem;
            //    if (dataRow != null)
            //    {
            //        string cellValue = dataRow.Row.ItemArray[0].ToString();
            //        vc.Delete("delete from tblOrders where orderdetailID='" + int.Parse(cellValue) + "'");
            //        Loadgridorder();
            //    }
            //}
            //catch (Exception es)
            //{
            //    MessageBox.Show(es.Message);
            //}
        }

        private void BtnaddItem_Onclick(object sender, RoutedEventArgs e)
        {

        }


        private void EventSetter_OnHandler(object sender, RoutedEventArgs e)
        {

        }


        int arrOrderID;
        int arrSortID;
        int arrProfileId;
        string arrCopanyname;
        int arrItemsID;
        string arrItemsDescription;
        int arrIsStampAdded;
        int arrisBoxAdded;
        int arrItemsQty;


        private void chkStatus_Unchecked(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("un  checked");
        }

        private void GridCustOrder_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ////////int id = 0;
            ////////DataRowView dataRow = (DataRowView)GridCustOrder.SelectedItem;
            ////////if (dataRow != null)
            ////////{
            ////////    string cellValue = dataRow.Row.ItemArray[15].ToString();
            ////////    if (cellValue != "")
            ////////    {
            ////////        id = int.Parse(cellValue);
            ////////        ProcessingControl fdf = new ProcessingControl(id);
            ////////        fdf.ShowDialog();
            ////////    }
            ////////}
        }

        private void BtnGenOrder_OnClick(object sender, RoutedEventArgs e)
        {
            if (lblCustomerID.Content.ToString() != "")
            {
                itemsForm Itf = new itemsForm(lblCompanyName.Text, lblCustomerID.Content.ToString(), LoginUser, SystemUser);
                if (Itf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                };
                Loadgridorder();
            }
            else
            {
                System.Windows.MessageBox.Show("پہلےکسٹمر سیلیکٹ کریں۔");
                btnAddOrder.Focus();
            }

            CountData();
        }

        private void BtnGenBill_OnClick(object sender, RoutedEventArgs e)
        {
            if (lblCustomerID.Content.ToString() != "")
            {
                GenerateBill Itf = new GenerateBill(lblCustomerID.Content.ToString(), lblCompanyName.Text, lblBalanceAmount.Content.ToString(), LoginUser, SystemUser);
                if (Itf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    //
                    // vc.Insert("insert into tblLedger (LedgerTypeID,EventID,ProfileId,DebitAmount,CreditAmount,datetime,SpecialNOte,VenderAccountID) values('2','" + jobid + "','" + VenderId + "','" + textBox2.Text + "',0,'" + DateTime.Now + "','" + "Vender Account" + "','" + venderAcountId + "')");

                };
                Loadgridorder();
            }
            else
            {
                System.Windows.MessageBox.Show("پہلےکسٹمر سیلیکٹ کریں۔");
                btnAddOrder.Focus();
            }
            CountData();
        }

        #endregion
        //order form end here
        public string SystemUser { get; set; }
        private void btnQout_Click(object sender, RoutedEventArgs e)
        {

        }


        private void LoadAticle()
        {
            DataSet ds = vc.Select("Select Article from tblArticle order by ArticleID asc");
            cmb_article.ItemsSource = ds.Tables["Table"].DefaultView;
        }

        private void LoadType()
        {
            DataSet ds = vc.Select("Select VesterType from tblVesterType order by VesterTypeID asc");
            cmb_type.ItemsSource = ds.Tables["Table"].DefaultView;
        }

        private void LoadColor()
        {
            DataSet ds = vc.Select("Select ColorName from tblColor order by ColorID asc");
            cmb_color.ItemsSource = ds.Tables["Table"].DefaultView;
        }

        private void LoadMaterial()
        {
            DataSet ds = vc.Select("Select MaterialName from tblMaterial order by MaterialName asc");
            cmb_materail.ItemsSource = ds.Tables["Table"].DefaultView;
        }

        private void LoadSole()
        {
            DataSet ds = vc.Select("Select SolName from tblSol order by SolID asc");
            cmb_sole.ItemsSource = ds.Tables["Table"].DefaultView;
        }

        private void cmb_article_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter && cmb_article.Text != "")
                {
                    DateTime dt = DateTime.Now;
                    vc.Insert(
                        "Insert into tblArticle (Article,articleDescription,Active,updateby,updatein,updateon) values ('" +
                        this.cmb_article.Text + "','" + "description" + "'," + 1 + ",'" + this.LoginUser + "','" + SystemUser +
                        "','" + dt + "')");
                    cmb_article.Text = "";
                    LoadAticle();
                }
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message.ToString());
            }
            finally
            {

            }
        }

        private void cmb_type_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter && cmb_type.Text != "")
                {
                    DateTime dt = DateTime.Now;
                    vc.Insert(
                        "Insert into tblVesterType (VesterType,typeDescription,Active,updateby,updatein,updateon) values ('" +
                        this.cmb_type.Text + "','" + "description" + "'," + 1 + ",'" + this.LoginUser + "','" + SystemUser +
                        "','" + dt + "')");
                    cmb_type.Text = "";
                    LoadType();
                }
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message.ToString());
            }
            finally
            {

            }
        }

        private void cmb_color_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter && cmb_color.Text != "")
                {
                    DateTime dt = DateTime.Now;

                    vc.Insert(
                        "Insert into tblColor (ColorName,colorDescription,Active,updateby,updatein,updateon) values ('" +
                        this.cmb_color.Text + "','" + "description" + "'," + 1 + ",'" + LoginUser + "','" + SystemUser +
                        "','" + dt + "')");
                    cmb_color.Text = "";
                    LoadColor();
                }
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message.ToString());
            }
            finally
            {

            }
        }

        private void cmb_materail_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter && cmb_materail.Text != "")
                {
                    DateTime dt = DateTime.Now;
                    vc.Insert(
                        "Insert into tblMaterial (MaterialName,materialDescription,Active,updateby,updatein,updateon) values ('" +
                        this.cmb_materail.Text + "','" + "description" + "'," + 1 + ",'" + LoginUser + "','" + SystemUser +
                        "','" + dt + "')");
                    cmb_materail.Text = "";
                    LoadMaterial();
                }
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message.ToString());
            }
            finally
            {

            }
        }

        private void cmb_sole_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter && cmb_sole.Text != "")
                {
                    DateTime dt = DateTime.Now;

                    vc.Insert(
                        "Insert into tblSol (SolName,soleDescription,Active,updateby,updatein,updateon) values ('" +
                        this.cmb_sole.Text + "','" + "description" + "'," + 1 + ",'" + LoginUser + "','" + SystemUser +
                        "','" + dt + "')");
                    cmb_sole.Text = "";
                    LoadSole();
                }
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message.ToString());
            }
            finally
            {

            }
        }

        private void btn_execute_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void btn_execute_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int Article, Type, Color, Material, Sole;
                //DataSet ds = vc.Select("Select typeName from IType order by typeName asc");
                //DG_Mixer.ItemsSource = ds.Tables["Table"].DefaultView;
                for (Article = 0; Article <= cmb_article.Items.Count - 1; Article++)
                {
                    cmb_article.SelectedIndex = Article;
                    for (Type = 0; Type <= cmb_type.Items.Count - 1; Type++)
                    {
                        cmb_type.SelectedIndex = Type;
                        for (Color = 0; Color <= cmb_color.Items.Count - 1; Color++)
                        {
                            cmb_color.SelectedIndex = Color;
                            for (Material = 0; Material <= cmb_materail.Items.Count - 1; Material++)
                            {
                                cmb_materail.SelectedIndex = Material;
                                for (Sole = 0; Sole <= cmb_sole.Items.Count - 1; Sole++)
                                {
                                    cmb_sole.SelectedIndex = Sole;

                                    string a = cmb_article.Text;
                                    string b = cmb_type.Text;
                                    string c = cmb_color.Text;
                                    string d = cmb_materail.Text;
                                    string EE = cmb_sole.Text;

                                    DataSet ds = new DataSet();
                                    //if(ds.Tables["Table"].Rows.Count>0)
                                    //{
                                    //    ds.Tables["Table"].Clear();
                                    //}
                                    ds.Clear();

                                    DateTime dt = DateTime.Now;
                                    string itemname = cmb_article.Text + " " + cmb_type.Text + " " + cmb_color.Text +
                                                      " " + cmb_materail.Text + " " + cmb_sole.Text;
                                    ds =
                                        vc.Select("Select ItemsDescription from tblItems where ItemsDescription='" +
                                                  itemname + "'");
                                    if (ds.Tables["Table"].Rows.Count == 0)
                                    {
                                        vc.Insert(
                                            "Insert into tblItems (ItemsDescription,itemRate,Active,updateby,updatein,updateon) values ('" +
                                            itemname + "','" + 0 + "'," + 1 + ",'" + LoginUser + "','" + SystemUser +
                                            "','" + dt + "')");
                                    }




                                    //DG_Mixer.Items.Add(new {
                                    //    A = cmb_article.Text,
                                    //    T = cmb_type.Text,
                                    //    C = cmb_color.Text,
                                    //    M = cmb_materail.Text,
                                    //    S = cmb_sole.Text
                                    //});

                                }
                            }
                        }
                    }
                }
                //fillDG_mixer();
            }
            catch (Exception es)
            {
                MessageBox.Show(es.ToString());
            }
            finally
            {

            }
        }

        DataSet _dsDg = new DataSet();

        private void fillDG_mixer()
        {
            _dsDg =
                vc.Select(
                    "Select il.items_list_id,ia.articleNumber,it.typeName,ic.colorName,im.materialName,iso.soleName, il.itemRate from ItemsList as il join IArticle ia on il.article_id=ia.article_id join IType it on il.type_id=it.type_id join IColor ic on il.color_id=ic.color_id join IMaterial im on im.matarial_id=il.matarial_id join ISole iso on iso.sole_id=il.sole_id where il.itemRate=0");
            //_dsDg = vc.Select("Select items_list_id,itemName, itemRate from ItemsList where itemRate=0");

            DG_Mixer.ItemsSource = _dsDg.Tables["Table"].DefaultView;
        }

        private void cmb_sole_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            test.Content = cmb_sole.SelectedIndex.ToString() + " " + cmb_sole.Text;
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_addproduct_Click(object sender, RoutedEventArgs e)
        {
            //string  ID = ((Button)sender).CommandParameter.ToString();

            var row = GetParent<DataGridRow>((Button)sender);
            var index = DG_Mixer.Items.IndexOf(row.Item);
            string value = _dsDg.Tables["Table"].Rows[index][0].ToString();
            string value1 = _dsDg.Tables["Table"].Rows[index][6].ToString();
            //string sv = "Update ItemsList set itemRate = '" + value1 + "' ok = '" + 1 + "' where items_list_id = '" + value + "'";
            vc.Update("Update ItemsList set itemRate = '" + value1 + "' , ok = '" + 1 + "' where items_list_id = '" +
                      value + "'");
            fillDG_mixer();
        }


        private TargetType GetParent<TargetType>(DependencyObject o)
            where TargetType : DependencyObject
        {
            if (o == null || o is TargetType) return (TargetType)o;
            return GetParent<TargetType>(VisualTreeHelper.GetParent(o));
        }

        //private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        //{

        //}

        private void btn_saveProfile_Click(object sender, RoutedEventArgs e)
        {
            //if (txt_profileuniqueName.Text != "" && txt_profileName.Text != "" && txt_profileFathername.Text != "")
            //{
            //    int active = 0;
            //    if (chkbx_profileActive.IsChecked == true)
            //    {
            //        active = 1;
            //    }
            //    DateTime dt = DateTime.Now;
            //    vc.Insert("Insert into Pprofile (uniqueName,name,fathername,Cnic,contactNumber1,contactNumber,tempAddres,permenentAddress,emailID,shopName,shopAddress,contactNumberShop,profile_type_id,vender_type_id,Active,updateby,updatein,updateon) values ('" + txt_profileuniqueName.Text + "','" + txt_profileName.Text + "','" + txt_profileFathername.Text + "','" + txt_profileCNIC.Text + "','" + txt_profileContactNumber1.Text + "','" + txt_profileContactNumber.Text + "','" + txt_profileTempAddress.Text + "','" + txt_profilepermenentAddress.Text + "','" + txt_profileemailAddress.Text + "','" + txt_profileShopename.Text + "','" + txt_profileAddres.Text + "','" + txt_profileContactnumberShop.Text + "','" + cmb_profileType.SelectedIndex + "','" + cmb_profilevenderType.SelectedIndex + "'," + active + ",'" + this.ActiveUser + "','" + PC + "','" + dt + "')");
            //    ClearProfileControls();
            //}

        }

        private void ClearProfileControls()
        {
            //txt_profileAddres.Text = "";
            //txt_profileCNIC.Text = "";
            //txt_profileContactNumber.Text = "";
            //txt_profileContactNumber1.Text = "";
            //txt_profileContactnumberShop.Text = "";
            //txt_profileemailAddress.Text = "";
            //txt_profileFathername.Text = "";
            //txt_profileName.Text = "";
            //txt_profilepermenentAddress.Text = "";
            //txt_profileShopename.Text = "";
            //txt_profileTempAddress.Text = "";
            //txt_profileuniqueName.Text = "";
            //cmb_profileType.SelectedIndex = 0;
            //cmb_profilevenderType.SelectedIndex = 0;
            //chkbx_profileActive.IsChecked = true;
        }

        public string gvar = "";

        private void tb_profile_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void LoadComboProfileType()
        {
            //DataSet ds = vc.Select("Select profile_type_name from PprofileType order by profile_type_id asc");
            //cmb_profileType.ItemsSource = ds.Tables["Table"].DefaultView;
        }



        private void cmb_profileType_DropDownClosed(object sender, DragEventArgs e)
        {
            //if (cmb_profileType.SelectedIndex == 3)
            //{
            //    cmb_profilevenderType.IsEnabled = true;
            //}
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void MainTab_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TabItem_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void orderStatus_Loaded(object sender, RoutedEventArgs e)
        {
            //this.Title = "ORDER";
            //TakeOrderGrid.Navigate(new System.Uri("FormOrderfm.xaml",
            //UriKind.RelativeOrAbsolute));
            //this.Title = "ORDER STATUS";
            //Loadorderdetail();


        }

        private void Loadorderdetail()
        {
            try
            {
                if (sqlcon.State != ConnectionState.Open)
                {
                    sqlcon.Open();
                }

                SqlCommand cmd3 = sqlcon.CreateCommand();
                cmd3.CommandType = CommandType.Text;
                cmd3.CommandText =
                    "Select * from tblMasterOrder tm join tblJobStates tj on tm.jobStates=tj.jobStates inner join tblProfile tf on tm.ProfileId=tf.ProfileId where tm.jobStates='" +
                    0 + "' order by tm.OrderId desc";
                cmd3.ExecuteNonQuery();
                //DataTable dtarticle = new DataTable();
                SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
                DataSet ds = new DataSet();
                da3.Fill(ds);
                //gridOrderDejtail.DataSource = dtarticle;


                if (sqlcon.State != ConnectionState.Closed)
                {
                    sqlcon.Close();
                }
                gridOrderstatusDetail.ItemsSource = ds.Tables[0].DefaultView;
                gridOrderstatusDetail.DisplayMemberPath = ds.Tables[0].Columns[0].ToString();
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }

        private void gridOrderstatusDetail_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //int id = 0;
            //DataRowView dataRow = (DataRowView) gridOrderstatusDetail.SelectedItem;
            //if (dataRow != null)
            //{
            //    string cellValue = dataRow.Row.ItemArray[1].ToString();
            //    id = int.Parse(cellValue);
            //    formOrderModificationfm fdf = new formOrderModificationfm(id);
            //    fdf.ShowDialog();
            //    Loadorderdetail();
            //}
        }

        private void ProductionOrders_Loaded(object sender, RoutedEventArgs e)
        {
            //Loadproductionorders();
        }

        //private void Loadproductionorders()
        //{
        //    try
        //    {
        //        if (sqlcon.State != ConnectionState.Open)
        //        {
        //            sqlcon.Open();
        //        }

        //        SqlCommand cmd3 = sqlcon.CreateCommand();
        //        cmd3.CommandType = CommandType.Text;
        //        cmd3.CommandText =
        //            "Select * from tblProcessingDetail  pid join tblJobStates tj on pid.jobStates=tj.jobStates inner join tblProfile tp on pid.CustProfileID=tp.ProfileId join tblItems ti on ti.ItemsID=pid.ItemID where pid.jobStates='0' order by ProcessiingID ";
        //        cmd3.ExecuteNonQuery();
        //        //DataTable dtarticle = new DataTable();
        //        SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
        //        DataSet ds = new DataSet();
        //        da3.Fill(ds);
        //        //gridOrderDejtail.DataSource = dtarticle;


        //        if (sqlcon.State != ConnectionState.Closed)
        //        {
        //            sqlcon.Close();
        //        }
        //        GridproductionOrder.ItemsSource = ds.Tables[0].DefaultView;
        //        GridproductionOrder.DisplayMemberPath = ds.Tables[0].Columns[0].ToString();
        //    }
        //    catch (Exception es)
        //    {
        //        MessageBox.Show(es.Message);
        //    }
        //}

        private void tbCustomerOrderstatus_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Loadorderdetail();
        }

        private void ProductionOrders_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //Loadproductionorders();
        }

        private void GridproductionOrder_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //int id = 0;
            //DataRowView dataRow = (DataRowView) GridproductionOrder.SelectedItem;
            //if (dataRow != null)
            //{
            //    string cellValue = dataRow.Row.ItemArray[0].ToString();
            //    id = int.Parse(cellValue);
            //    ProcessingControl fdf = new ProcessingControl(id);
            //    fdf.ShowDialog();
            //    //Loadproductionorders();
            //}
        }

        private void tb_productionINprocess_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //loadproductionINproces();
        }

        private void tb_productionINprocess_Loaded(object sender, RoutedEventArgs e)
        {
            //loadproductionINproces();
        }

        private void loadproductionINproces()
        {
            try
            {
                if (sqlcon.State != ConnectionState.Open)
                {
                    sqlcon.Open();
                }

                SqlCommand cmd3 = sqlcon.CreateCommand();
                cmd3.CommandType = CommandType.Text;
                cmd3.CommandText =
                    "Select * from tblProcessingDetail  pid join tblJobStates tj on pid.jobStates=tj.jobStates inner join tblProfile tp on pid.CustProfileID=tp.ProfileId join tblItems ti on ti.ItemsID=pid.ItemID where pid.jobStates >'0' and pid.jobStates <'5' order by ProcessiingID ";
                cmd3.ExecuteNonQuery();
                //DataTable dtarticle = new DataTable();
                SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
                DataSet ds = new DataSet();
                da3.Fill(ds);
                //gridOrderDejtail.DataSource = dtarticle;


                if (sqlcon.State != ConnectionState.Closed)
                {
                    sqlcon.Close();
                }
                GridproductionINProcess.ItemsSource = ds.Tables[0].DefaultView;
                GridproductionINProcess.DisplayMemberPath = ds.Tables[0].Columns[0].ToString();
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }

        private void GridproductionINProcess_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int id = 0;
            DataRowView dataRow = (DataRowView)GridproductionINProcess.SelectedItem;
            if (dataRow != null)
            {
                string cellValue = dataRow.Row.ItemArray[0].ToString();
                id = int.Parse(cellValue);
                ProcessingControl fdf = new ProcessingControl(id);
                fdf.ShowDialog();
                //loadproductionINproces();
            }
        }

        private void gridVenderOrderDetail_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void tb_Vender_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            loadpVenderOrderDetail();
        }

        private void tb_Vender_Loaded(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //DataSet ds = vc.Select("select ProfileId, PName from tblProfile where PType='1'");
            //OrderdetailCombVender.ItemsSource = ds.Tables["Table"].DefaultView;
            //OrderdetailCombVender.DisplayMemberPath = "PName";
            //OrderdetailCombVender.SelectedValuePath = "ProfileId";
            //LedgerCombVender.ItemsSource = ds.Tables["Table"].DefaultView;
            //LedgerCombVender.DisplayMemberPath = "PName";
            //LedgerCombVender.SelectedValuePath = "ProfileId";

            //    //DataSet dsa = vc.Select("select ProfileId, PName from tblProfile where PType='1'");
            //    //abc.ItemsSource = dsa.Tables["Table2"].DefaultView;
            //    //abc.DisplayMemberPath = "PName";
            //    //abc.SelectedValuePath = "ProfileId";

            //    //DataSet dss = vc.Select("select * from tblProcessStates");

            //    //OrderdetailCombVendertype.ItemsSource = dss.Tables["Table"].DefaultView;
            //    //OrderdetailCombVendertype.DisplayMemberPath = "vender_type_name";
            //    //OrderdetailCombVendertype.SelectedValuePath = "vender_type_id";


            //    SqlCommand sqlCmd = new SqlCommand("select * from tblProcessStates", sqlcon);
            //    if (sqlcon.State != ConnectionState.Open)
            //    {
            //        sqlcon.Open();
            //    }
            //    SqlDataReader sqlReader = sqlCmd.ExecuteReader();
            //    Dictionary<int, string> DictionaryVenderType = new Dictionary<int, string>();
            //    while (sqlReader.Read())
            //    {
            //        string name = sqlReader["vender_type_name"].ToString();
            //        int Value = int.Parse(sqlReader["vender_type_id"].ToString());
            //        DictionaryVenderType.Add(Value, name);
            //        //OrderdetailCombVendertype.Items.isert(new ListItem("Text", "Value"));
            //        //ComboBox item=new ComboBox();
            //        //item.Text = sqlReader["vender_type_name"].ToString();
            //        //item.value
            //        //OrderdetailCombVendertype.Items.Add();
            //    }
            //    OrderdetailCombVendertype.ItemsSource = new BindingSource(DictionaryVenderType, null);
            //    OrderdetailCombVendertype.DisplayMemberPath = "Value";
            //    OrderdetailCombVendertype.SelectedValuePath = "Key";

            //    sqlReader.Close();
            //    if (sqlcon.State != ConnectionState.Closed)
            //    {
            //        sqlcon.Close();
            //    }


            //}
            //catch (Exception es)
            //{
            //    MessageBox.Show(es.Message);
            //}

            //loadpVenderOrderDetail();
        }

        private void loadpVenderOrderDetail()
        {
            //try
            //{
            //    if (sqlcon.State != ConnectionState.Open)
            //    {
            //        sqlcon.Open();
            //    }

            //    SqlCommand cmd3 = sqlcon.CreateCommand();
            //    cmd3.CommandType = CommandType.Text;
            //    cmd3.CommandText =
            //        "Select * from tblVendersAccount tvc join tblProfile tf on tvc.ProfileId=tf.ProfileId order by VenderAccountid desc";
            //    cmd3.ExecuteNonQuery();
            //    //DataTable dtarticle = new DataTable();
            //    SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
            //    DataSet ds = new DataSet();
            //    da3.Fill(ds);
            //    //gridOrderDejtail.DataSource = dtarticle;


            //    if (sqlcon.State != ConnectionState.Closed)
            //    {
            //        sqlcon.Close();
            //    }
            //    gridVenderOrderDetail.ItemsSource = ds.Tables[0].DefaultView;
            //    gridVenderOrderDetail.DisplayMemberPath = ds.Tables[0].Columns[0].ToString();
            //}
            //catch (Exception es)
            //{
            //    MessageBox.Show(es.Message);
            //}
        }

        private void Tb_customer_OnMouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void GridallOrderstatusDetail_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int id = 0;
            DataRowView dataRow = (DataRowView)gridallOrderstatusDetail.SelectedItem;
            if (dataRow != null)
            {
                string cellValue = dataRow.Row.ItemArray[1].ToString();
                id = int.Parse(cellValue);
                OrderProduction op = new OrderProduction(id);
                op.ShowDialog();
                LoadallRunningorderdetail();
            }

        }

        private void TbCustomerAllOrders_OnLoaded(object sender, RoutedEventArgs e)
        {
            //LoadallRunningorderdetail();
        }

        private void LoadallRunningorderdetail()
        {
            try
            {
                if (sqlcon.State != ConnectionState.Open)
                {
                    sqlcon.Open();
                }

                SqlCommand cmd3 = sqlcon.CreateCommand();
                cmd3.CommandType = CommandType.Text;
                cmd3.CommandText =
                    "Select * from tblMasterOrder tm join tblJobStates tj on tm.jobStates=tj.jobStates join tblProfile tp on tm.ProfileId=tp.ProfileId  order by tm.OrderId desc";
                //*where tm.jobStates='" + 0 + "'*/
                cmd3.ExecuteNonQuery();
                //DataTable dtarticle = new DataTable();
                SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
                DataSet ds = new DataSet();
                da3.Fill(ds);
                //gridOrderDejtail.DataSource = dtarticle;


                if (sqlcon.State != ConnectionState.Closed)
                {
                    sqlcon.Close();
                }
                gridallOrderstatusDetail.ItemsSource = ds.Tables[0].DefaultView;
                gridallOrderstatusDetail.DisplayMemberPath = ds.Tables[0].Columns[0].ToString();
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }

        private void GridproductionOrder_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void GridHRAllProfile_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void BtnAddProfile_OnClick(object sender, RoutedEventArgs e)
        {
            gvar = "AddInfo";
            FormProfileFm fcf = new FormProfileFm(gvar, LoginUser, SystemUser);
            fcf.ShowDialog();
        }

        private void CombHRAllprofilePType_OnGotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void comboLoadProfile()
        {
            PtypeComboLoad();
        }

        private void PtypeComboLoad()
        {
            try
            {
                DataSet ds = vc.Select("select * from PprofileType");
                //combHRAllprofilePType.ValueMember = "PName";
                //combHRAllprofilePType.ValueMember = "ProfileId";
                combHRAllprofilePType.ItemsSource = ds.Tables["Table"].DefaultView;

            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }

        private void CombHRAllprofileVType_OnGotFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                DataSet ds = vc.Select("select vender_type_name from tblProcessStates");
                //combHRAllprofilePType.ValueMember = "PName";
                //combHRAllprofilePType.ValueMember = "ProfileId";
                combHRAllprofileVType.ItemsSource = ds.Tables["Table"].DefaultView;

            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);

            }
        }

        private void BtnHRallprofileExecute_OnClick(object sender, RoutedEventArgs e)
        {

        }

        private void tb_vender_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void OrderdetailCombVender_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            loadpVenderOrderDetailCustom("byName");
        }

        private void loadpVenderOrderDetailCustom(string abc)
        {
            //try
            //{
            //    //if (sqlcon.State != ConnectionState.Open)
            //    //{
            //    //    sqlcon.Open();
            //    //}

            //    //SqlCommand cmd3 = sqlcon.CreateCommand();
            //    //cmd3.CommandType = CommandType.Text;
            //    DataSet ds=new DataSet();
            //    if (abc == "byName")
            //        ds =
            //            vc.Select(
            //                "Select * from tblVendersAccount tvc join tblProfile tf on tvc.ProfileId=tf.ProfileId where tvc.ProfileId='" +
            //                OrderdetailCombVender.SelectedIndex + "' order by VenderAccountid desc");
            //    else if (abc== "ByProcessStates")
            //    {
            //        ds = vc.Select("Select * from tblVendersAccount tvc join tblProfile tf on tvc.ProfileId=tf.ProfileId where TF.vender_type_id='" +
            //                OrderdetailCombVendertype.SelectedIndex + "' order by VenderAccountid desc");
            //    }
            //    else if (abc== "ByProcessID")
            //    {
            //        ds = vc.Select("Select * from tblVendersAccount tvc join tblProfile tf on tvc.ProfileId=tf.ProfileId where tvc.VenderAccountID='" +
            //                txtvenderOrderDetailID.Text + "' order by VenderAccountid desc");
            //    }

            //    //cmd3.CommandText = "Select * from tblVendersAccount tvc join tblProfile tf on tvc.ProfileId=tf.ProfileId where TF.vender_type_id='" + OrderdetailCombVendertype.SelectedIndex + "'  order by VenderAccountid desc";
            //    //cmd3.ExecuteNonQuery();
            //    //DataTable dtarticle = new DataTable();
            //    //SqlDataAdapter da3 = new SqlDataAdapter(cmd3);

            //    //da3.Fill(ds);
            //    //gridOrderDejtail.DataSource = dtarticle;


            //    if (sqlcon.State != ConnectionState.Closed)
            //    {
            //        sqlcon.Close();
            //    }
            //    gridVenderOrderDetail.ItemsSource = ds.Tables[0].DefaultView;
            //    gridVenderOrderDetail.DisplayMemberPath = ds.Tables[0].Columns[0].ToString();
            //}
            //catch (Exception es)
            //{
            //    MessageBox.Show(es.Message);
            //}
        }

        private void OrderdetailCombVendertype_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            loadpVenderOrderDetailCustom("ByProcessStates");

        }

        private void TxtvenderOrderDetailID_OnKeyDown(object sender, KeyEventArgs e)
        {
            loadpVenderOrderDetailCustom("ByProcessID");
        }

        private void VenderOrderDetailAll_OnClick(object sender, RoutedEventArgs e)
        {
            loadpVenderOrderDetail();
        }

        private void GridVenderOrderDetail_OnPreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //int id = 0;
            //DataRowView dataRow = (DataRowView)gridVenderOrderDetail.SelectedItem;
            //if (dataRow != null)
            //{
            //    string cellValue = dataRow.Row.ItemArray[1].ToString();
            //    id = int.Parse(cellValue);
            //    ProcessingControl fdf = new ProcessingControl(id);
            //    fdf.ShowDialog();
            //}
        }

        private void LedgerCombVender_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // TxtSearchVenderLedgerId.Text = LedgerCombVender.SelectedValue.ToString();

        }

        private void txtSearchVenderLedgerID_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        DataSet dsl = new DataSet();
        DataSet dsl1 = new DataSet();
        private void BtnVenderLedgerExecute_OnClick(object sender, RoutedEventArgs e)
        {
            btnRunningOrdersVender.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 8, 141, 14));
            btnCompletedOrdersVender.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 8, 141, 14));
            btnLedgerVender.Foreground = Brushes.Blue;
            ledgerComponents.Visibility = Visibility.Visible;
            GridVenderOrderLedger.Visibility = Visibility.Visible;
            GridVenderOrder.Visibility = Visibility.Hidden;
            if (lblCompanyNameVender.Text == "")
            {
                return;
            }
            if (lblVenderID.Content.ToString() == "")
            {
                return;
            }

            dsl.Tables.Clear();
            DateTime dtf = DateTime.Parse(DtPickVenderOrderBookFromdate.SelectedDate.ToString());
            DateTime dtt = DateTime.Parse(DtPickVenderOrderBookTodate.SelectedDate.ToString());
            //string str1 = "select b.VID,cast(b.JobID as varchar)as JobID ,b.ProfileID,b.VDateTime,b.VFlag,i.ItemsID,i.ItemsDescription,CAST (r.AM as Varchar)AM,CAST (r.FM as Varchar)FM,cast(vo.IssueRate as varchar) as IssueRate,vo.ReturnQty,b.VAmount,b.VRemarks  from tblVenderBills b,tblVenderOrders vo,tblItems i,tblOrders o, tblRecipeStepsDetail r where b.VenderOrderId=vo.VenderAccountid and b.JobID=o.JobID and o.orderdetailID=r.orderdetailID and o.ItemsID=i.ItemsID and b.ProfileID='" + lblVenderID.Content.ToString() + "' and b.VDateTime >= '" + dtf.ToString("yyyy-MM-dd") + "' and b.VDateTime <= '" + dtt.ToString("yyyy-MM-dd") + "'  order by b.VDateTime ";
            string str = "select * from ((select b.VID,cast(b.JobID as varchar)as JobID ,b.ProfileID,b.VDateTime,b.VFlag,i.ItemsID,i.ItemsDescription,CAST (r.AM as Varchar)AM,CAST (r.FM as Varchar)FM,cast(vo.IssueRate as varchar) as IssueRate,vo.ReturnQty,b.VAmount,b.VRemarks  from tblVenderBills b,tblVenderOrders vo,tblItems i,tblOrders o, tblRecipeStepsDetail r where b.VenderOrderId=vo.VenderAccountid and b.JobID=o.JobID and o.orderdetailID=r.orderdetailID and o.ItemsID=i.ItemsID and b.ProfileID='" + lblVenderID.Content.ToString() + "' )union(select VID,'' as JobID,ProfileID,VDateTime,VFlag,'' as itemsid,VRemarks as ItemsDescription,''as am,'' as fm,'' as IssueRate,''as ReturnQty,VAmount,VRemarks from tblVenderBills where ProfileId ='" + lblVenderID.Content.ToString() + "' and ismanulaentry=1 ))b where b.VDateTime >= '" + dtf.ToString("yyyy-MM-dd") + "' and b.VDateTime <= '" + dtt.ToString("yyyy-MM-dd") + "'  order by b.VDateTime ";
            //ds = vc.Select("select * from Vw_VenderLedger where ProfileID= '" + lblVenderID.Content.ToString() + "'");
            dsl = vc.Select(str);
            if (sqlcon.State != ConnectionState.Closed)
            {
                sqlcon.Close();
            }
            GridVenderOrderLedger.ItemsSource = dsl.Tables[0].DefaultView;
            GridVenderOrderLedger.DisplayMemberPath = dsl.Tables[0].Columns[0].ToString();
            //payment grid


            string str1 = "select VID,ProfileID,VDateTime,ABS(VAmount )as VAmount,VRemarks from tblVenderBills where VFlag='D' and ProfileID='" + lblVenderID.Content.ToString() + "' and VDateTime >= '" + dtf.ToString("yyyy-MM-dd") + "' and VDateTime <= '" + dtt.ToString("yyyy-MM-dd") + "'  order by VDateTime ";
            dsl1 = vc.Select(str1);
            if (sqlcon.State != ConnectionState.Closed)
            {
                sqlcon.Close();
            }
            GridVenderPaidamounts.ItemsSource = dsl1.Tables[0].DefaultView;
            GridVenderPaidamounts.DisplayMemberPath = dsl1.Tables[0].Columns[0].ToString();

            int Bal = f.findnumber("select SUM(VAmount)as BalanceAmount  from tblVenderBills where ProfileId='" + lblVenderID.Content + "'");
            txtVenderLedgerBalance.Text = Bal.ToString();

            int sumqty = 0;
            int am = 0;
            int i = 0;
            foreach (DataRow dr in dsl.Tables[0].Rows)
            {
                string aam;
                string ffm;
                string a = dr["am"].ToString();
                if (a != "")
                {
                     aam= ((enumClass.RecipeDetailAM)int.Parse(dr["am"].ToString())).ToString();
                }
                else
                {
                    aam = "";
                }
                string b = dr["fm"].ToString();
                if (b != "")
                {
                     ffm = ((enumClass.RecipeDetailFM)int.Parse(dr["fm"].ToString())).ToString();
                }
                else
                {
                    ffm = "";
                }
                
                dsl.Tables[0].Rows[i]["am"] = aam;
                dsl.Tables[0].Rows[i]["fm"] = ffm;
                sumqty = sumqty + int.Parse(dr["ReturnQty"].ToString());
                am = am + int.Parse(dr["VAmount"].ToString());
                i++;
            }
            int paidam = 0;
            foreach (DataRow dr in dsl1.Tables[0].Rows)
            {
                paidam = paidam + int.Parse(dr["VAmount"].ToString());
            }

            DataRow drr = dsl.Tables[0].NewRow();
            drr["JobID"] = "کل جوڑے";
            drr["IssueRate"] = "کل کام";
            drr["ReturnQty"] = sumqty;
            drr["VAmount"] = am;
            //drr["ItemsDescription"] = "Total Sum";
            dsl.Tables[0].Rows.Add(drr);
            DataRow drr2 = dsl1.Tables[0].NewRow();
            drr2["VAmount"] = paidam;
            drr2["VRemarks"] = "آپ نے کل رقم جو وصول کی";
            dsl1.Tables[0].Rows.Add(drr2);
            if (sqlcon.State != ConnectionState.Closed)
            {
                sqlcon.Close();
            }



        }

        private void BtnSettingCleardatabae_OnClick(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Do You really want to clear DB.", "Verification", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                vc.Insert("DELETE FROM tblLedger");
                vc.Insert("DELETE FROM tblCustItemsRate");
                vc.Insert("DELETE FROM tblMasterInvoice");
                vc.Insert("DELETE FROM tblOrders");
                vc.Insert("DELETE FROM tblVenderOrders");
                vc.Insert("DELETE FROM tblRecipeStepsDetail");
                vc.Insert("DELETE FROM tblRecipeSteps");
                vc.Insert("DELETE FROM tblExpenses");
                //vc.Insert("DELETE FROM tblProcessingDetail");
                vc.Insert("delete tblDetailInvoice");
                vc.Insert("DELETE FROM tblVenderOrders");
            }

        }

        private void BtnAddCustomr_OnClick(object sender, RoutedEventArgs e)
        {

        }


        public int OrderID { get; set; }
        public int SortID { get; set; }
        public int ProductionID { get; set; }
        public int ProductID { get; set; }
        private void BtnaddItem_OnClick(object sender, RoutedEventArgs e)
        {

        }

        private void TxtRate_OnLostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void TxtRate_OnKeyDown(object sender, KeyEventArgs e)
        {

        }

        private void TxtRate_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            totalamount();
        }
        int rate, qty;
        private void totalamount()
        {
            //if (Txtqty.Text.Trim() == "")
            //{
            //    qty = 0;
            //}
            //else
            //{
            //    try
            //    {
            //        qty = int.Parse(Txtqty.Text.Trim());
            //    }
            //    catch (Exception)
            //    {
            //        Txtqty.Text = "";
            //        qty = 0;
            //    }
            //}
            //if (TxtRate.Text == "")
            //{
            //    rate = 0;
            //}
            //else
            //{
            //    try
            //    {
            //        rate = int.Parse(TxtRate.Text.Trim());
            //    }
            //    catch (Exception)
            //    {
            //        TxtRate.Text = "";
            //        rate = 0;
            //    }
            //}



            //TxtTotal.Text = (qty * rate).ToString();

        }

        private void Txtqty_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            totalamount();
        }

        private void Txtqty_OnKeyDown(object sender, KeyEventArgs e)
        {
            //if (e.Key == Key.Enter)
            //{
            //    TxtRate.Focus();
            //}
            //if (e.Key == Key.Tab)
            //{
            //    TxtRate.Focus();
            //}
        }
        //int sortid = 0;
        int col = 0;
        int row = 1;
        string Itemgselected = "";
        private void BtnSaveRec_OnClick(object sender, RoutedEventArgs e)
        {
            
        }
        private void gridOrderDetail_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {

        }
        private void gridOrderDetail_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
        }
        private void txtGrandTotal_TextChanged(object sender, TextChangedEventArgs e)
        {

        }



        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            
        }
       
        private void clear()
        {
            //TxtItemDescription.Text = "";
            //TxtRate.Text = "";
            //Txtqty.Text = "";
        }

        private void btnPrintVenLedgerSlip_Click(object sender, RoutedEventArgs e)
        {
            if (GridVenderOrderLedger.Items.Count > 0)
            {
                venderLedgerSlipForm vsl = new venderLedgerSlipForm(int.Parse(lblVenderID.Content.ToString()), lblCompanyNameVender.Text, dsl, dsl1,
                    int.Parse(txtVenderLedgerBalance.Text), DtPickVenderOrderBookFromdate.SelectedDate.Value.ToString("dd-MM-yyyy"),
                    DtPickVenderOrderBookTodate.SelectedDate.Value.ToString("dd-MM-yyyy"));
                vsl.Show();
            }
        }


        private void btnVenderLedgerPaid_Click(object sender, RoutedEventArgs e)
        {
            if (txtVenderLedgerPaid.Text != "")
            {
                DateTime startdate = (DateTime)dtPickVenderLedgerPaidDate.SelectedDate;
                string startdate1 = startdate.ToString("yyyy-MM-dd");
                int paidamount = (0 - (int.Parse(txtVenderLedgerPaid.Text)));
                string str = "INSERT INTO tblVenderBills (ProfileID,VDateTime,VAmount,EnteredON,EnteredBy,VFlag,VRemarks,EnteredIN) VALUES ('" + lblVenderID.Content + "','" + startdate1 + "','" + paidamount + "','" + DateTime.Now + "','" + LoginUser + "','D','Paid Amount '+'" + txtVenderLedgerPaidRemarks.Text + "','"+SystemUser+"')";
                vc.Insert(str);
                txtVenderLedgerPaid.Text = "";
            }
            BtnVenderLedgerExecute_OnClick(sender, e);
        }

        private void Tb_productionCompleted_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            loadproductionCompleted();

        }

        private void Tb_productionCompleted_OnLoaded(object sender, RoutedEventArgs e)
        {
            loadproductionCompleted();
        }

        private void GridInvoiceDetail_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
           
        }

        private void GridproductionCompleted_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int id = 0;
            DataRowView dataRow = (DataRowView)GridproductionCompleted.SelectedItem;
            if (dataRow != null)
            {
                string cellValue = dataRow.Row.ItemArray[0].ToString();
                id = int.Parse(cellValue);
                ProcessingControl fdf = new ProcessingControl(id);
                fdf.ShowDialog();
                loadproductionCompleted();
            }

        }

        private void gridVenderLedger_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //int id = 0;
            //DataRowView dataRow = (DataRowView)gridVenderLedger.SelectedItem;
            //if (dataRow != null)
            //{
            //    string cellValue = dataRow.Row.ItemArray[3].ToString();
            //    id = int.Parse(cellValue);
            //    ProcessingControl fdf = new ProcessingControl(id);
            //    fdf.ShowDialog();
            //    //loadproductionINproces();
            //}
        }


        private void VenderLedgerFromDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void loadproductionCompleted()
        {
            try
            {
                if (sqlcon.State != ConnectionState.Open)
                {
                    sqlcon.Open();
                }

                SqlCommand cmd3 = sqlcon.CreateCommand();
                cmd3.CommandType = CommandType.Text;
                cmd3.CommandText =
                    "Select * from tblOrders  pid join tblJobStates tj on pid.jobStates=tj.jobStates inner join tblProfile tp on pid.ProfileId=tp.ProfileId join tblItems ti on ti.ItemsID=pid.ItemsID where pid.jobStates ='5' order by JobID ";
                cmd3.ExecuteNonQuery();
                //DataTable dtarticle = new DataTable();
                SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
                DataSet ds = new DataSet();
                da3.Fill(ds);
                //gridOrderDejtail.DataSource = dtarticle;


                if (sqlcon.State != ConnectionState.Closed)
                {
                    sqlcon.Close();
                }
                GridproductionCompleted.ItemsSource = ds.Tables[0].DefaultView;
                GridproductionCompleted.DisplayMemberPath = ds.Tables[0].Columns[0].ToString();
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }

        DataTable tbl_main = new DataTable("tbl_main");
        int tbProductionCounPairs = 0;
        private void LoadDigitalView(string s, string order, string sort)
        {
            tbl_main.Clear();
            try
            {
                DataSet dsSelect = vc.Select(s);
                foreach (DataTable dt in dsSelect.Tables)
                {
                    foreach (DataRow dro in dt.Rows)
                    {
                        string sjob = dro["JobID"].ToString();
                        if (sjob == "")
                        {
                            int jobstates = f.findnumber("select jobStates from tblOrders where OrderID= '" + order + "' and sortid='" + sort + "'");
                            int pJobnumb = f.findnumber("select JobID from tblOrders where orderid='" + order + "' and sortid='" + sort+ "' ");
                            if(pJobnumb == 0 && jobstates ==0)
                            {
                                int Jobnumb = f.createNumber("select top(1) JobID from tblOrders order by JobID desc");
                                vc.Update("update tblOrders set jobid='" + Jobnumb + "', jobStates='1' , OrderStatus='1', JobStartDate='" + DateTime.Now.ToString("yyyy-MM-dd HH:M:ss") + "', jobEnteredby='" + LoginUser + "', jobenteredon='" + DateTime.Now.ToString("yyyy-MM-dd HH:M:ss") + "' where orderid='" + order + "' and sortid='" + sort + "'  ");
                                sjob = Jobnumb.ToString();
                            }
                            else
                            {
                                sjob = pJobnumb.ToString(); ;
                            }
                            
                        }
                        int job = int.Parse(sjob);
                        string descri = dro["ItemsDescription"].ToString();
                        string qty = dro["ItemsQty"].ToString();
                        tbProductionCounPairs = tbProductionCounPairs + int.Parse(qty);
                        DataRow drow = tbl_main.NewRow();
                        drow[0] = job.ToString();
                        drow[1] = job.ToString();
                        drow[2] = descri;
                        drow[3] = qty;
                        drow[4] = digitalSelect("select convert(date,IssueDate),PName,convert(date,ReturnDate) from tblVenderOrders v, tblProfile f where v.ProfileId=f.ProfileId and ProcessiingID='" + job + "' and v.vender_type_id=0", 1);
                        drow[5] = digitalSelect("select convert(date,IssueDate),PName,convert(date,ReturnDate) from tblVenderOrders v, tblProfile f where v.ProfileId=f.ProfileId and ProcessiingID='" + job + "' and v.vender_type_id=1", 1);
                        drow[6] = digitalSelect("select convert(date,IssueDate),PName,convert(date,ReturnDate) from tblVenderOrders v, tblProfile f where v.ProfileId=f.ProfileId and ProcessiingID='" + job + "' and v.vender_type_id=2", 1);
                        drow[7] = digitalSelect("select convert(date,IssueDate),PName,convert(date,ReturnDate) from tblVenderOrders v, tblProfile f where v.ProfileId=f.ProfileId and ProcessiingID='" + job + "' and v.vender_type_id=3", 1);
                        drow[8] = digitalSelect("select convert(date,IssueDate),PName,convert(date,ReturnDate) from tblVenderOrders v, tblProfile f where v.ProfileId=f.ProfileId and ProcessiingID='" + job + "' and v.vender_type_id=4", 1);
                        drow[9] = digitalSelect("select convert(date,IssueDate),PName,convert(date,ReturnDate) from tblVenderOrders v, tblProfile f where v.ProfileId=f.ProfileId and ProcessiingID='" + job + "' and v.vender_type_id=5", 1);
                        drow[10] = digitalSelect("select convert(date,IssueDate),PName,convert(date,ReturnDate) from tblVenderOrders v, tblProfile f where v.ProfileId=f.ProfileId and ProcessiingID='" + job + "' and v.vender_type_id=7", 1);
                        drow[11] = digitalSelect("select convert(date,IssueDate),PName,convert(date,ReturnDate) from tblVenderOrders v, tblProfile f where v.ProfileId=f.ProfileId and ProcessiingID='" + job + "' and v.vender_type_id=6", 1);
                        drow[12] = digitalSelect("select PCompanyName from tblOrders tp , tblProfile tf where tp.ProfileId=tf.ProfileId and JobID='" + job + "'", 0);
                        drow[13] = "1";
                        tbl_main.Rows.Add(drow);

                    }
                }


            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
            finally
            {
                CountPairs_tbProduction.Content = tbProductionCounPairs.ToString();
            }
        }

        public string digitalSelect(string s, int a)
        {
            SqlDataReader dr = null;
            try
            {

                //if (sqlcon.State != ConnectionState.Open)
                //{
                sqlcon.Open();
                //}
                string b = "";
                SqlCommand cmd = new SqlCommand(s, sqlcon); //Advised to use parameterized query
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    if (a == 1)
                    {
                        string issuedate = dr.GetValue(0).ToString();
                        string name = dr.GetValue(1).ToString();
                        string Returndate = dr.GetValue(2).ToString();
                        if (issuedate != "")
                        {
                            DateTime dt = DateTime.Parse(dr.GetValue(0).ToString());
                            issuedate = dt.ToString("dd-MM-yyyy");
                        }
                        else
                        {
                            issuedate = " __ ";
                        }
                        //if (name.Length>6)
                        //{
                        //    name = name.Substring(0, 6);
                        //}
                        //if (name.Length < 6)
                        //{
                        //    for (int i  = name.Length; i==6; i++)
                        //    {
                        //        name = name + " ";
                        //    }
                        //    //name = name.Substring(0, 6);
                        //}
                        if (Returndate != "")
                        {
                            DateTime dt = DateTime.Parse(dr.GetValue(0).ToString());
                            Returndate = dt.ToString("dd-MM-yyyy");
                        }
                        else
                        {
                            Returndate = " __ ";
                        }
                        b = issuedate + Environment.NewLine + name + Environment.NewLine + Returndate;
                    }
                    else
                    {
                        b = dr.GetValue(0).ToString();
                    }
                }

                //if (sqlcon.State != ConnectionState.Closed)
                //{
                sqlcon.Close();
                //}
                return b;
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message.ToString());
                return "";
            }
            finally
            {
                dr?.Close();
            }
        }



        ContextMenu m = new ContextMenu();
        int vtypeNumb;
        string vtype;
        string Jobid;
        int checkreturn;

        string selecteditem;


        private void DigitalDataGrid_MouseRightButtonDown(object sender, MouseEventArgs e)
        {

            //DataRowView dataCell = (DataRowView)DigitalDataGrid.SelectedItem;
            //int index = DigitalDataGrid.CurrentCell.Column.DisplayIndex;
            //string cellVal = dataCell.Row.ItemArray[index].ToString();
            //string abc = "";
            //int id = 0;
            //DataRowView dataRow = (DataRowView)GridproductionCompleted.SelectedItem;
            //if (dataRow != null)
            //{
            //    string cellValue = dataRow.Row.ItemArray[0].ToString();
            //    id = int.Parse(cellValue);
            //    ProcessingControl fdf = new ProcessingControl(id);
            //    fdf.ShowDialog();
            //    loadproductionCompleted();
            //}

            //TextBox textbox = (sender as TextBox);
            //if (textbox != null)
            //{
            //    selecteditem = textbox.Name;
            //    string[] info = textbox.Name.Split('_');
            //    vtype = info[0];
            //    //string desc = info[1];
            //    Jobid = info[2];

        }



        void menu_Click(object sender, EventArgs e)
        {
            string selected = ((System.Windows.Forms.MenuItem)sender).Text;
            string[] vender = selected.Split(' ');
            int vid = int.Parse(vender[0]);
            //MessageBox.Show(vender.ToString());
            DateTime dt = DateTime.Now;
            //menuInsert("");

            //startthread = 1;
            //selecteditem

            //foreach (Control childc in this.panel1.Controls)
            //{
            //    if (childc is TextBox && childc.Name.Contains(selecteditem))
            //    {
            //        childc.Text += vender[1];
            //        childc.Show();
            //        return;
            //    }

            //    //if (childc is TextBox && childc.Name.Contains("smpl"))
            //    //    smplratio += ((TextBox)childc).Text + ",";
            //}

        }

        //public void menuInsert(string s)
        //{
        //    //startthread = 1;
        //    if (sqlcon.State == ConnectionState.Closed)
        //    {
        //        sqlcon.Open();
        //    }
        //    SqlCommand cmd = new SqlCommand(s, sqlcon);
        //    cmd.ExecuteNonQuery();
        //    sqlcon.Close();
        //}

        //public DataSet menuSelect(string s)
        //{
        //    if (sqlcon.State == ConnectionState.Closed)
        //    {
        //        sqlcon.Open();
        //    }
        //    SqlDataAdapter da = new SqlDataAdapter(s, sqlcon);
        //    DataSet ds = new DataSet();
        //    da.Fill(ds);
        //    if *(sqlcon.State == ConnectionState.Open)
        //    {/7
        //        sqlcon.Close();
        //    }
        //    return ds;
        //}


        //System.Drawing.Point mouseposition ;

        int tblsortid;
        private void DigitalDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int stepNumb = -1;
            if (DigitalDataGrid.SelectedCells.Count == 0)
            {
                return;
            }
            DataGridCellInfo cell = DigitalDataGrid.CurrentCell;
            int columnindex = cell.Column.DisplayIndex;
            int rowIndex = DigitalDataGrid.Items.IndexOf(cell.Item);
            tblsortid = int.Parse(tbl_main.Rows[rowIndex][13].ToString());
            if (columnindex >= 4 && columnindex <= 11)
            {

                //if (columnindex == 4)
                //{
                //    vtype = "CM";
                //    stepNumb = 0;
                //}
                //else if (columnindex == 5)
                //{
                //    vtype = "SM";
                //    stepNumb = 1;
                //}
                //else if (columnindex == 6)
                //{
                //    vtype = "AM";
                //    stepNumb = 2;
                //}
                //else if (columnindex == 7)
                //{
                //    vtype = "BM";
                //    stepNumb = 3;
                //}
                //else if (columnindex == 8)
                //{+5--/t+-t
                //    vtype = "PM";
                //    stepNumb = 4;
                //}
                //else if (columnindex == 9)
                //{
                //    vtype = "PR";
                //    stepNumb = 5;
                //}
                //else if (columnindex == 10)
                //{
                //    vtype = "FM";
                //    stepNumb = 6;
                //}

                stepNumb = columnindex - 4;
                Jobid = tbl_main.Rows[rowIndex][0].ToString();
                checkreturn = 1;
                int returned = 0;
                string datevalu = "";
                string vender = "";
                int updateflag = 0;
                string showdataa = "";
                if (stepNumb == -1)
                {
                    return;
                }
                vtypeNumb =
                    f.findnumber("select vender_type_id from tblProcessStates where Sorting='" + stepNumb + "'");
                //vtypeNumb = stepNumb;

                selectVender sv = new selectVender(int.Parse(Jobid), vtypeNumb, LoginUser, SystemUser);
                if (sv.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    updateflag = sv.FlagUpdate;
                    showdataa = sv.showdata;
                }
                if (updateflag == 0)
                {
                    return;
                }
                tbl_main.Rows[rowIndex][columnindex] = showdataa;

            }
        }

        private void DigitalDataGrid_OnMouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            //int x = e.X;
            //int y = e.Y;
            //mouseposition = new System.Drawing.Point(0, 0);

        }

        int calljobstates = 1;
        private void Comb_DView_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Comb_DView.SelectedIndex == 0)
            {
                calljobstates = 1;
            }
            else if (Comb_DView.SelectedIndex == 1)
            {
                calljobstates = 5;
            }
            else if (Comb_DView.SelectedIndex == 2)
            {
                calljobstates = 8;
            }
        }

        private void Btnfindjobs_OnClick(object sender, RoutedEventArgs e)
        {
            WaitWnd.WaitForm wf = new WaitForm();

            try
            {
                wf.Show();
                DateTime startdate = (DateTime)DtPickDigitalViewFromdate.SelectedDate;
                string startdate1 = startdate.ToString("yyyy-MM-dd");
                DateTime enddate = (DateTime)DtPickDigitalViewComboTodate.SelectedDate;
                string enddate1 = enddate.ToString("yyyy-MM-dd");
                if (txtPendingOrders.Text != "")
                {
                    string abc = txtPendingOrders.Text;
                    if (abc.Contains('-'))
                    {
                        string[] abclist = abc.Split(char.Parse("-"));
                        string ord = abclist[0];
                        string srt = abclist[1];
                        txtPendingOrders.Text = "";
                        string s = ("select JobID,ItemsDescription,ItemsQty from tblOrders tp , tblItems ti where tp.ItemsID=ti.ItemsID and OrderID='" + ord + "' and SortID='" + srt + "'  order by JobID ");
                        LoadDigitalView(s, ord, srt);
                    }
                    
                }
                else if (ComboDigitalViewCustomer.SelectedIndex <= 0 && ComboDigitalViewVender.SelectedIndex <= 0)
                {
                    string s = ("select JobID,ItemsDescription,ItemsQty from tblOrders tp , tblItems ti where tp.ItemsID=ti.ItemsID and tp.JobStartDate >= '" + startdate1 + "' and tp.JobStartDate <=  '" + enddate1 + "' and tp.jobStates='" + calljobstates + "' order by JobID ");
                    LoadDigitalView(s, "", "");
                }

                else if (ComboDigitalViewVender.SelectedIndex > 0 && ComboDigitalViewCustomer.SelectedIndex <= 0)
                {
                    string s = ("select JobID,ItemsDescription,ItemsQty from tblOrders tp , tblItems ti , tblVenderOrders vo where tp.ItemsID=ti.ItemsID and tp.JobID=vo.ProcessiingID and tp.JobStartDate >= '" + startdate1 + "' and tp.JobStartDate <=  '" + enddate1 + "' and tp.jobStates='" + calljobstates + "' and vo.ProfileId='" + ComboDigitalViewVender.SelectedValue + "' order by JobID ");
                    LoadDigitalView(s, "", "");
                }
                else if (ComboDigitalViewCustomer.SelectedIndex > 0 && ComboDigitalViewVender.SelectedIndex <= 0)

                {
                    string s = ("select JobID,ItemsDescription,ItemsQty from tblOrders tp , tblItems ti where tp.ItemsID=ti.ItemsID and tp.JobStartDate >= '" + startdate1 + "' and tp.JobStartDate <=  '" + enddate1 + "' and tp.jobStates='" + calljobstates + "' and tp.ProfileId='" + ComboDigitalViewCustomer.SelectedValue + "' order by JobID ");
                    LoadDigitalView(s, "", "");
                }
                else if (ComboDigitalViewCustomer.SelectedIndex > 0 && ComboDigitalViewVender.SelectedIndex > 0)
                {
                    string s = ("select JobID,ItemsDescription,ItemsQty from tblOrders tp , tblItems ti , tblVenderOrders vo where tp.ItemsID=ti.ItemsID and tp.JobID=vo.ProcessiingID and tp.JobStartDate >= '" + startdate1 + "' and tp.JobStartDate <=  '" + enddate1 + "' and tp.jobStates='" + calljobstates + "' and tp.ProfileId='" + ComboDigitalViewCustomer.SelectedValue + "' and vo.ProfileId='" + ComboDigitalViewVender.SelectedValue + "' order by JobID ");
                    LoadDigitalView(s, "", "");

                }
                wf.Close();
            }
            catch (Exception es)
            {
                wf.Close();
                MessageBox.Show(es.Message);
            }

        }

        private void ComboDigitalViewCustomer_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboDigitalViewVender.SelectedIndex = 0;
            if (ComboDigitalViewCustomer.SelectedIndex == 0)
            {
                lblComboDigitalView.Content = "Select Customer";
            }
            else
            {
                lblComboDigitalView.Content = "Selected ID=" + ComboDigitalViewCustomer.SelectedIndex;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            dobackup();
            Environment.Exit(0);
        }

        private void DigitalDataGrid_OnLoadingRow(object sender, DataGridRowEventArgs e)
        {
            //DataGridRow gridRow = e.Row;
            //DataRow row = (gridRow.DataContext as DataRowView).Row;
            //string jobid = row[1].ToString();

            //if (jobid!="")
            //{
            //    gridRow.Background = new SolidColorBrush(Colors.AliceBlue);
            //}

            //switch (row.RowState)
            //{
            //    case DataRowState.Added:
            //        gridRow.Background = new SolidColorBrush(Colors.Green);
            //        break;
            //    case DataRowState.Modified:
            //        gridRow.Background = new SolidColorBrush(Colors.Yellow);
            //        break;
            //    case DataRowState.Deleted:
            //        gridRow.Background = new SolidColorBrush(Colors.Red);
            //        break;
            //}
        }

        //CustomerTab got focus
        DataSet ds1 = new DataSet();
        private void BtnCustLedgerExecute_OnClick(object sender, RoutedEventArgs e)
        {
            if (TxtSearchCustLedgerId.Text == "")
            {
                return;
            }
            string fromdt = DateTime.Parse(CustLedgerFromDatePicker.SelectedDate.ToString()).ToString("yyyy-MM-dd");
            string todt = DateTime.Parse(CustLedgerToDatePicker.SelectedDate.ToString()).ToString("yyyy-MM-dd");
            string strbalanceamount = "";
            SqlCommand cmd;
            if (tbCustomerChkboxCofLedger.IsChecked == true)
            {
                strbalanceamount = "select SUM(CreditAmount)-SUM(DebitAmount) as BalanceAmount  from tblLedger l, tblProfile p where l.ProfileId=p.ProfileId and PGaurdianNameID = '" + TxtSearchCustLedgerId.Text + "' ";
                cmd = new SqlCommand("CareOfcustomerLedger", sqlcon);
            }
            else
            {
                strbalanceamount = "select SUM(CreditAmount)-SUM(DebitAmount) as BalanceAmount  from tblLedger where ProfileId='" + TxtSearchCustLedgerId.Text + "' ";
                cmd = new SqlCommand("customerLedger", sqlcon);
            }
            cmd.CommandType = CommandType.StoredProcedure;
            ds1.Clear();
            cmd.Parameters.Add(new SqlParameter("@Customerid", TxtSearchCustLedgerId.Text));
            cmd.Parameters.Add(new SqlParameter("@fromdate", fromdt));
            cmd.Parameters.Add(new SqlParameter("@todate", todt));
            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            adap.Fill(ds1);
            adap.Dispose();
            if (sqlcon.State != ConnectionState.Closed)
            {
                sqlcon.Close();
            }
            GridCustLedger.ItemsSource = ds1.Tables[0].DefaultView;
            GridCustLedger.DisplayMemberPath = ds1.Tables[0].Columns[0].ToString(); 
            int Bal = f.findnumber(strbalanceamount);
           txtCustLedgerBalance.Text = Bal.ToString();

        }

        private void BtnAddCustLedger_OnClick(object sender, RoutedEventArgs e)
        {
            gvar = "Orderform";
            FormProfileFm fcf = new FormProfileFm(gvar, LoginUser, SystemUser);
            if (fcf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                TxtSearchCustLedgerId.Text = fcf.GlobalVar.ToString();
                //lblCustLedgerID.Content = fcf.GlobalVar.ToString();
            };
            flagF = 1;
            //lblCustLedgerCompanyName.Text = f.findname("select PCompanyName from tblProfile where ProfileId='" + TxtSearchCustLedgerId.Text + "'");

            lblCustLedgerCompanyName.SelectedValue = int.Parse(TxtSearchCustLedgerId.Text);


        }

        int venderid;
        private void FrameworkElement_OnLoaded(object sender, RoutedEventArgs e)
        {
            this.Title = "Vender";
        }

        private void BtnAddOrderVender_OnClick(object sender, RoutedEventArgs e)
        {
            flagF = 1;
            gvar = "Vendeform";
            FormProfileFm fcf = new FormProfileFm(gvar, LoginUser, SystemUser);
            if (fcf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                venderid = fcf.GlobalVar;
                lblVenderID.Content = venderid;
            };
            refreshCombo();
            if (venderid == 0)
            {
                LblMsgVendOrderbook.Content = "Please Seletct Vender.";
                return;
            }
            lblCompanyNameVender.SelectedValue = venderid;
            CountDataVender();
            // LoadVender_OrderBookform(venderid);

        }

        private void BtnRunningOrdersVender_OnClick(object sender, RoutedEventArgs e)
        {
            btnCompletedOrdersVender.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 8, 141, 14));
            btnLedgerVender.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 8, 141, 14));
            btnRunningOrdersVender.Foreground = Brushes.Blue;
            ledgerComponents.Visibility = Visibility.Hidden;
            GridVenderOrderLedger.Visibility = Visibility.Hidden;
            GridVenderOrder.Visibility = Visibility.Visible;
            if (lblVenderID.Content.ToString() == "")
            {
                return;
            }
            LoadgridVenderorder();
            CountDataVender();
        }
        DataSet VenderBillOrderDs = new DataSet();
        DataSet VenderWeeklyReportDS = new DataSet();
        private void BtnCompletedOrdersVender_OnClick(object sender, RoutedEventArgs e)
        {
            btnRunningOrdersVender.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 8, 141, 14));
            btnCompletedOrdersVender.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 8, 141, 14));
            btnLedgerVender.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 8, 141, 14));
            btnCompletedOrdersVender.Foreground = Brushes.Blue;
            GridVenderOrderLedger.Visibility = Visibility.Hidden;
            GridVenderOrder.Visibility = Visibility.Visible;

            DateTime dtf = DateTime.Parse(DtPickVenderOrderBookFromdate.SelectedDate.ToString());
            DateTime dtt = DateTime.Parse(DtPickVenderOrderBookTodate.SelectedDate.ToString());
            ledgerComponents.Visibility = Visibility.Hidden;
            //btnGenBillVender.Visibility = Visibility.Visible;
            //txtVenderSum.Visibility = Visibility.Visible;
            //lblsum.Visibility = Visibility.Visible;
            //btnGenBillVender.Content = "Generate Bill";


            if (lblVenderID.Content.ToString() == "")
            {
                return;
            }
            if (lblCompanyNameVender.Text == "")
            {
                return;
            }
            VenderBillOrderDs.Tables.Clear();
            string str = "select IssueDate,VenderAccountid,ProcessiingID,v.ProfileId,ItemsDescription,IssueQty,IssueRate,(IssueQty*IssueRate) as TotalBill,ReturnDate,ReturnQty from tblVenderOrders v ,tblOrders o, tblItems i where v.ProcessiingID=o.JobID and o.ItemsID=i.ItemsID and v.ProfileId='" + lblVenderID.Content + "' and v.ReturnDate >= '" + dtf.ToString("yyyy-MM-dd") + "' and v.ReturnDate <=  '" + dtt.ToString("yyyy-MM-dd") + "'   order by ReturnDate desc";
            if (vc != null) VenderBillOrderDs = vc.Select(str);
            //if (vc != null) VenderBillOrderDs = vc.Select("select IssueDate,VenderAccountid,ProcessiingID,v.ProfileId,ItemsDescription,IssueQty,IssueRate,(IssueQty*IssueRate) as TotalBill,ReturnDate,ReturnQty from tblVenderOrders v ,tblOrders o, tblItems i where v.ProcessiingID=o.JobID and o.ItemsID=i.ItemsID and v.ProfileId='" + lblVenderID.Content + "' and v.IssueDate >= '" + dtf.ToString("yyyy-MM-dd") + "' and v.IssueDate <=  '" + dtt.ToString("yyyy-MM-dd") + "' and VBill is null and ReturnDate is not Null  order by ProcessiingID desc");
            int sum = 0;
            for (int i = 0; i < VenderBillOrderDs.Tables[0].Rows.Count; i++)
            {
                sum = int.Parse(VenderBillOrderDs.Tables[0].Rows[i][7].ToString()) + sum;
            }
            //txtVenderSum.Text = sum.ToString();
            GridVenderOrder.ItemsSource = VenderBillOrderDs.Tables[0].DefaultView;
            GridVenderOrder.DisplayMemberPath = VenderBillOrderDs.Tables[0].Columns[0].ToString();

            CountDataVender();
        }


        private void CustLedger_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void GridVenderOrder_OnPreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int id = 0;
            DataRowView dataRow = (DataRowView)GridVenderOrder.SelectedItem;
            if (dataRow != null)
            {
                string cellValue = dataRow.Row.ItemArray[2].ToString();
                if (cellValue != "")
                {
                    id = int.Parse(cellValue);
                    ProcessingControl fdf = new ProcessingControl(id);
                    fdf.ShowDialog();
                }
            }
        }


        private void LblCompanyName_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (flagF == 1)
            {
                flagF = 0;
                return;
            }
            if (lblCompanyName.SelectedIndex > 0)
            {
                chkbxSelectAllOrders.IsChecked = false;

                custID = int.Parse(lblCompanyName.SelectedValue.ToString());
                lblCustomerID.Content = custID.ToString();
                CountData();
            }

            //lblCompanyName_DropDownClosed(sender, e);
        }

        private void lblCompanyName_DropDownClosed(object sender, EventArgs e)
        {

        }

        private void TxtSJobid_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter)
            {
                return;
            }
            if (txtSJobid.Text != "")
            {
                try
                {
                    btnCompletedOrders.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 8, 141, 14));
                    btnDeliverdOrders.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 8, 141, 14));
                    btnAllOrders.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 8, 141, 14));
                    btnRunningOrders.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 8, 141, 14));
                    txtBillnumber.Text = "";
                    if (txtSJobid.Text.Contains('-'))
                    {
                        string[] ord = txtSJobid.Text.Split('-');
                        if (DtPickCustomerOrderBookTodate.SelectedDate != null && DtPickCustomerOrderBookFromdate.SelectedDate != null)
                        {
                            string s = "select o.orderdatetime,orderid,sortid,i.itemsdescription,itemsqty,orderstatus,jobid,invoiceid,p.PCompanyName,o.jobStates  from tblorders o , tblItems i, tblProfile p where o.ItemsID=i.ItemsID and o.ProfileId=p.ProfileId and o.OrderID='" + ord[0] + "' and o.SortID='" + ord[1] + "'  order by OrderID desc";
                            if (vc != null) dtorder = vc.Select(s);
                        }
                    }
                    else
                    {
                        if (DtPickCustomerOrderBookTodate.SelectedDate != null && DtPickCustomerOrderBookFromdate.SelectedDate != null)
                        {
                            string s = "select o.orderdatetime,orderid,sortid,i.itemsdescription,itemsqty,orderstatus,jobid,invoiceid,p.PCompanyName,o.jobStates  from tblorders o , tblItems i, tblProfile p where o.ItemsID=i.ItemsID and o.ProfileId=p.ProfileId and JobID='" + txtSJobid.Text + "'  order by OrderID desc";
                            if (vc != null) dtorder = vc.Select(s);
                        }
                    }

                }
                catch (Exception es)
                {
                    MessageBox.Show(es.Message);
                }

                loadPlotPanel();
                CountData();
            }
        }

        private void TxtBillnumber_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter)
            {
                return;
            }
            if (txtBillnumber.Text != "") //searchbilllnumber
            {
                try
                {
                    btnCompletedOrders.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 8, 141, 14));
                    btnDeliverdOrders.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 8, 141, 14));
                    btnAllOrders.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 8, 141, 14));
                    btnRunningOrders.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 8, 141, 14));
                    txtSJobid.Text = "";

                    if (DtPickCustomerOrderBookTodate.SelectedDate != null && DtPickCustomerOrderBookFromdate.SelectedDate != null)
                    {
                        string s = "select o.orderdatetime,orderid,sortid,i.itemsdescription,itemsqty,orderstatus,jobid,invoiceid,p.PCompanyName,o.jobStates  from tblorders o , tblItems i, tblProfile p where o.ItemsID=i.ItemsID and o.ProfileId=p.ProfileId and Invoiceid='" + txtBillnumber.Text + "'  order by OrderID desc";
                        if (vc != null) dtorder = vc.Select(s);
                    }
                }
                catch (Exception es)
                {
                    MessageBox.Show(es.Message);
                }

                loadPlotPanel();
                CountData();
            }
        }

        private void ComboDigitalViewVender_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            ComboDigitalViewCustomer.SelectedIndex = 0;
            if (ComboDigitalViewVender.SelectedIndex == 0)
            {
                lblComboDigitalViewVender.Content = "Select Customer";
            }
            else
            {
                lblComboDigitalViewVender.Content = "Selected ID=" + ComboDigitalViewVender.SelectedIndex;
            }
        }

        private void LblCustomerRatesCustomer_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CombCustomerRatesCustomer.SelectedIndex > 0)
            {
                string s = "select r.CustItemRateID,a.Article,p.PCompanyName,m.MaterialName,t.VesterType,s.SolName,r.ItemRate from tblCustItemsRate r, tblProfile p, tblVesterType t,tblSol s, tblMaterial m,tblArticle a where r.vestertypeid=t.VesterTypeID and r.solid=s.SolID and r.materialid=m.MaterialID and r.articleid=a.ArticleID and r.ProfileId=p.ProfileId and r.Active=1 and p.ProfileId=" + CombCustomerRatesCustomer.SelectedValue + "";
                DataSet ds = new DataSet();
                if (vc != null) ds = vc.Select(s);
                DG_CustomerRates.ItemsSource = ds.Tables[0].DefaultView;
                DG_CustomerRates.DisplayMemberPath = ds.Tables[0].Columns[0].ToString();
            }
            else
            {
                DG_CustomerRates.Items.Clear();
            }

        }

        private void CombVendRatesCustomer_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CombVendRatesCustomer.SelectedIndex > 0)
            {
                string s = "select r.CustItemRateID,a.Article,p.PCompanyName,m.MaterialName,t.VesterType,s.SolName,r.ItemRate from tblCustItemsRate r, tblProfile p, tblVesterType t,tblSol s, tblMaterial m,tblArticle a where r.vestertypeid=t.VesterTypeID and r.solid=s.SolID and r.materialid=m.MaterialID and r.articleid=a.ArticleID and r.ProfileId=p.ProfileId and r.Active=1 and p.ProfileId=" + CombVendRatesCustomer.SelectedValue + "";
                DataSet ds = new DataSet();
                if (vc != null) ds = vc.Select(s);
                DG_VendRates.ItemsSource = ds.Tables[0].DefaultView;
                DG_VendRates.DisplayMemberPath = ds.Tables[0].Columns[0].ToString();
            }

        }

        private void LblCompanyNameVender_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (flagF == 1)
            {
                flagF = 0;
                return;
            }

            try
            {
                lblVenderID.Content = "";
                if (lblCompanyNameVender.SelectedIndex == 0)
                {
                    return;
                }
                venderid = int.Parse(lblCompanyNameVender.SelectedValue.ToString());
                lblVenderID.Content = venderid.ToString();
                //LoadgridVenderorder();
                CountDataVender();
            }
            catch (Exception)
            {


            }


        }

        private void BtnGenBillVender_OnClick(object sender, RoutedEventArgs e)
        {
            //if (txtVenderSum.Text!="" && GridVenderOrder.Items.Count>0)
            //{
            //    if (btnGenBillVender.Content.ToString() == "Print Bill")
            //    {
            //        venderLedgerSlipForm v= new venderLedgerSlipForm(int.Parse(txtSearchVenderBilll.Text));
            //        v.Show();
            //    }
            //    else
            //    {
            //        int bid = f.createNumber("select top 1 VBillID from tblVenderBills order by VBillID desc");
            //        vc.Insert("insert into tblVenderBills (VBillID,ProfileID,BillAmount,VDateTime,EnteredON,EnteredBy,VFlag) values('" + bid+"','" + lblVenderID.Content + "','" + txtVenderSum.Text + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + SystemUser + "','C')");
            //        for (int i = 0; i < VenderBillOrderDs.Tables[0].Rows.Count; i++)
            //        {
            //            int VorderID = int.Parse(VenderBillOrderDs.Tables[0].Rows[i][1].ToString());
            //            vc.Update("update tblVenderOrders set VBill='" + bid + "' where VenderAccountid='" + VorderID + "'");

            //        }

            //        BtnCompletedOrdersVender_OnClick(sender, e);
            //        venderLedgerSlipForm v = new venderLedgerSlipForm(bid);
            //        v.Show();
            //    }
            //}

        }

        private void lblCustLedgerCompanyName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //ds1.Tables[0].Rows.Clear();
            if (flagF == 1)
            {
                flagF = 0;
                return;
            }
            if (lblCustLedgerCompanyName.SelectedIndex > 0)
            {
                TxtSearchCustLedgerId.Text = lblCustLedgerCompanyName.SelectedValue.ToString();
            }
            else
            {
                TxtSearchCustLedgerId.Text = "";
            }
        }

        private void btnAddVenderLedger_Click(object sender, RoutedEventArgs e)
        {
            flagF = 1;
            gvar = "Vendeform";
            FormProfileFm fcf = new FormProfileFm(gvar, LoginUser, SystemUser);
            if (fcf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                TxtSearchVenderLedgerId.Text = fcf.GlobalVar.ToString();
            };

            if (int.Parse(TxtSearchVenderLedgerId.Text) == 0)
            {
                LblMsgVendOrderbook.Content = "Please Seletct Vender.";
                return;
            }
            lblVenderLedgerCompanyName.SelectedValue = int.Parse(TxtSearchVenderLedgerId.Text);
        }

        private void lblVenderLedgerCompanyName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (flagF == 1)
            {
                flagF = 0;
                return;
            }

            try
            {
                TxtSearchVenderLedgerId.Text = "";
                if (lblVenderLedgerCompanyName.SelectedIndex == 0)
                {
                    return;
                }
                TxtSearchVenderLedgerId.Text = (lblVenderLedgerCompanyName.SelectedValue.ToString());
                CountDataVender();
            }
            catch (Exception)
            {


            }
        }

        private void btnCustLedgerPaid_Click(object sender, RoutedEventArgs e)
        {
            if (txtCustLedgerPaid.Text != "")
            {
                vc.Insert("insert into tblLedger (LedgerTypeID,ProfileId,DebitAmount,datetime,SpecialNOte,updateby,updatein,updateon,Remarks) values (1,'" + TxtSearchCustLedgerId.Text + "','" + txtCustLedgerPaid.Text + "','" + tbCustomerLedgerDtPikPaid.SelectedDate + "','Amount Paid','" + LoginUser + "','" + SystemUser + "','" + DateTime.Now.ToString("yyyy-MM-dd hh:mm") + "','" + txtCustPaidRemarks.Text + "')");
                txtCustLedgerPaid.Text = "";
                txtCustPaidRemarks.Text = "";

            }
            BtnCustLedgerExecute_OnClick(sender, e);
        }

        int ExpComboFlag = 0;
        private void Combcatogory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ExpComboFlag == 0)
            {
                return;
            }
            SqlCommand sqlCmdexp1 = new SqlCommand("select * from tblExpenseHead where MasterheadID='" + Combcatogory.SelectedValue + "'  and Active=1", sqlcon);
            if (sqlcon.State != ConnectionState.Open)
            {
                sqlcon.Open();
            }
            SqlDataReader sqlReaderExp1 = sqlCmdexp1.ExecuteReader();
            Dictionary<int, string> DictionaryExpense = new Dictionary<int, string>();
            DictionaryExpense.Add(0, "Select Catagory");
            while (sqlReaderExp1.Read())
            {
                string name = sqlReaderExp1["ExpenseHead"].ToString().Trim();
                int Value = int.Parse(sqlReaderExp1["expenseheadID"].ToString());
                DictionaryExpense.Add(Value, name);
            }
            CombSubCatagory.ItemsSource = new BindingSource(DictionaryExpense, null);
            CombSubCatagory.DisplayMemberPath = "Value";
            CombSubCatagory.SelectedValuePath = "Key";
            CombSubCatagory.SelectedIndex = 0;

            if (sqlcon.State != ConnectionState.Closed)
            {
                sqlcon.Close();
            }
        }

        //private void TxtSearchVenderBilll_OnKeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.Key==Key.Enter)
        //    {
        //        btnRunningOrdersVender.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 8, 141, 14));
        //        btnCompletedOrders.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 8, 141, 14));
        //        btnAllOrders.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 8, 141, 14));
        //        btnCompletedOrdersVender.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 8, 141, 14));

        //        //btnGenBillVender.Visibility = Visibility.Visible;
        //        txtVenderSum.Visibility = Visibility.Visible;
        //        lblsum.Visibility = Visibility.Visible;
        //        //btnGenBillVender.Content = "Print Bill";

        //        VenderBillOrderDs.Tables.Clear();
        //        //DataSet ds = new DataSet();
        //        int a = f.findnumber("select ProfileID from tblVenderBills where VBillID='"+int.Parse(txtSearchVenderBilll.Text)+"'");
        //        lblCompanyNameVender.SelectedValue = a;
        //        if (vc != null) VenderBillOrderDs = vc.Select("select IssueDate,VenderAccountid,ProcessiingID,v.ProfileId,ItemsDescription,IssueQty,IssueRate,(IssueQty*IssueRate) as TotalBill,ReturnDate,ReturnQty from tblVenderOrders v ,tblOrders o, tblItems i where v.ProcessiingID=o.JobID and o.ItemsID=i.ItemsID and VBill ='"+txtSearchVenderBilll.Text+"' ");
        //        int sum = 0;
        //        for (int i = 0; i < VenderBillOrderDs.Tables[0].Rows.Count; i++)
        //        {
        //            sum = int.Parse(VenderBillOrderDs.Tables[0].Rows[i][7].ToString()) + sum;
        //        }
        //        txtVenderSum.Text = sum.ToString();
        //        GridVenderOrder.ItemsSource = VenderBillOrderDs.Tables[0].DefaultView;
        //        GridVenderOrder.DisplayMemberPath = VenderBillOrderDs.Tables[0].Columns[0].ToString();

        //        CountDataVender();

        //    }
        //}

        private void BtnExpenseSave_OnClick(object sender, RoutedEventArgs e)
        {
            if (txtexpamount.Text != "" && txtexpDetail.Text != "")
            {
                DateTime dt = DateTime.Parse(dtPickerExpenseDate.SelectedDate.ToString());

                vc.Insert("insert into tblExpenses (CatagoryID,ExpDetail,ExpAmount,ExpDate,updatein,updateon) values ('" + CombSubCatagory.SelectedValue + "','" + txtexpDetail.Text + "','" + txtexpamount.Text + "','" + dt.ToString("yyyy-MM-dd") + "','" + SystemUser + "','" + DateTime.Now.ToString("yyyy-MM-dd hh:mm") + "')");
                txtexpamount.Text = "";
                txtexpDetail.Text = "";
            }
            loadExpenseGrid();
        }

        private void loadExpenseGrid()
        {
            DataSet ds = new DataSet();
            ds = vc.Select("select * from tblExpenses e, tblExpenseHead h where e.expid=h.expenseheadID and e.Active='1'");
            if (sqlcon.State != ConnectionState.Closed)
            {
                sqlcon.Close();
            }
            DG_Expenses.ItemsSource = ds.Tables[0].DefaultView;
            DG_Expenses.DisplayMemberPath = ds.Tables[0].Columns[0].ToString();
            //int ope = f.findnumber("select (SUM(CreditAmount)-SUM(DebitAmount))as Opening from tblLedger where LedgerTypeID='1' and ProfileId='" + TxtSearchVenderLedgerId.Text + "' and datetime > = '" + VenderLedgerFromDatePicker.SelectedDate + "'");
            //lbltestopening.Content = ope.ToString();
            //int bal = f.findnumber("select (SUM(CreditAmount)-SUM(DebitAmount))as Balance from tblLedger where LedgerTypeID='1' and ProfileId='" + TxtSearchVenderLedgerId.Text + "' and datetime <= '" + VenderLedgerToDatePicker.SelectedDate + "'");
            //int Bal = f.findnumber("select SUM(CreditAmount)-SUM(DebitAmount) as BalanceAmount  from tblLedger where ProfileId='" + TxtSearchCustLedgerId.Text + "'");
            //txtCustLedgerBalance.Text = Bal.ToString();
        }

        private void CombcatogoryView_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ExpComboFlag == 0)
            {
                return;
            }
            SqlCommand sqlCmdexp1 = new SqlCommand("select * from tblExpenseHead where MasterheadID='" + CombcatogoryView.SelectedValue + "'  and Active=1", sqlcon);
            if (sqlcon.State != ConnectionState.Open)
            {
                sqlcon.Open();
            }
            SqlDataReader sqlReaderExp1 = sqlCmdexp1.ExecuteReader();
            Dictionary<int, string> DictionaryExpense = new Dictionary<int, string>();
            DictionaryExpense.Add(0, "Select Catagory");
            while (sqlReaderExp1.Read())
            {
                string name = sqlReaderExp1["ExpenseHead"].ToString().Trim();
                int Value = int.Parse(sqlReaderExp1["expenseheadID"].ToString());
                DictionaryExpense.Add(Value, name);
            }
            CombSubCatagoryView.ItemsSource = new BindingSource(DictionaryExpense, null);
            CombSubCatagoryView.DisplayMemberPath = "Value";
            CombSubCatagoryView.SelectedValuePath = "Key";
            CombSubCatagoryView.SelectedIndex = 0;

            if (sqlcon.State != ConnectionState.Closed)
            {
                sqlcon.Close();
            }
        }


        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            //return;
            DateTime startdate = (DateTime)dtPickerExpenseFrom.SelectedDate;
            string startdate1 = startdate.ToString("yyyy-MM-dd");
            DateTime enddate = (DateTime)dtPickerExpenseTo.SelectedDate;
            string enddate1 = enddate.ToString("yyyy-MM-dd");
            if (CombcatogoryView.SelectedIndex <= 0 && CombSubCatagoryView.SelectedIndex <= 0)
            {
                string s = ("select * from tblExpenses e, tblExpenseHead h where e.expid=h.expenseheadID and e.Active=1 and e.ExpDate >= '" + startdate1 + "' and e.ExpDate <=  '" + enddate1 + "' order by e.expID ");
                expenseviewDetail(s);

            }

            else if (CombcatogoryView.SelectedIndex > 0 && CombSubCatagoryView.SelectedIndex <= 0)
            {
                string s = ("select * from tblExpenses e, tblExpenseHead h where e.expid=h.expenseheadID and e.Active=1 and e.ExpDate >= '" + startdate1 + "' and e.ExpDate <=  '" + enddate1 + "' and h.MasterheadID='" + CombcatogoryView.SelectedValue + "' order by e.expID ");
                expenseviewDetail(s);

            }

            else if (CombcatogoryView.SelectedIndex > 0 && CombSubCatagoryView.SelectedIndex > 0)
            {
                string s = ("select * from tblExpenses e, tblExpenseHead h where e.expid=h.expenseheadID and e.Active=1 and e.ExpDate >= '" + startdate1 + "' and e.ExpDate <=  '" + enddate1 + "' and e.CatagoryID='" + CombSubCatagoryView.SelectedValue + "' order by e.expID ");
                expenseviewDetail(s);

            }
        }

        private void expenseviewDetail(string str)
        {
            DataSet ds = new DataSet();
            ds = vc.Select(str);
            if (sqlcon.State != ConnectionState.Closed)
            {
                sqlcon.Close();
            }
            DG_Expenses.ItemsSource = ds.Tables[0].DefaultView;
            DG_Expenses.DisplayMemberPath = ds.Tables[0].Columns[0].ToString();
        }

        private void ComboDigitalViewCustomer_OnLostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void CombcatogoryView_OnLostFocus(object sender, RoutedEventArgs e)
        {
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnLoadVenderWeeklySummaryReport_Click(object sender, RoutedEventArgs e)
        {
            VenderWeeklyReportDS.Tables.Clear();
            string s = "select * from Weekly_vender_Summary";
            if (vc != null) VenderWeeklyReportDS = vc.Select(s);
            int sum = 0;
            for (int i = 0; i < VenderWeeklyReportDS.Tables[0].Rows.Count; i++)
            {
                sum = int.Parse(VenderWeeklyReportDS.Tables[0].Rows[i][6].ToString()) + sum;
            }
            txtVenderAllSum.Text = sum.ToString();
            GridVenderWeeklySummary.ItemsSource = VenderWeeklyReportDS.Tables[0].DefaultView;
            GridVenderWeeklySummary.DisplayMemberPath = VenderWeeklyReportDS.Tables[0].Columns[0].ToString();
        }
        private void venderWeeklyReport_Find()
        {

        }

        private void btnVenderWeeklySummaryPrint_Click(object sender, RoutedEventArgs e)
        {

        }
        #region log Data
        private void countLogData()
        {
            string startdate = ((DateTime)tb_LogDtPicker.SelectedDate).ToString("yyyy-MM-dd");
            int CountOrder = f.findnumber("select COUNT(*) as i from tblOrders where Enteredby='" + CombLogUser.Text + "' and Enteredon>'" + startdate + "'  ");
            lblNewItemsAdd.Content = CountOrder.ToString();
            int CountJobs = f.findnumber("select COUNT(*) from tblOrders where ProfileId='" + custID + "' and Complete='0' and jobStates='1'");
            lblRunningOrders.Content = CountJobs.ToString();
            int CountInvoice = f.findnumber("select COUNT(*) from tblOrders where ProfileId='" + custID + "' and Complete='0' and jobStates='0'");
            lblPendingOrders.Content = CountInvoice.ToString();

        }
        private void CombLogUser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            countLogData();
        }
        private void BtnLogOrders_Click(object sender, RoutedEventArgs e)
        {
            if (CombLogUser.Text != "")
            { //btnAddCustLedger.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 8, 141, 14));
                BtnLogInvoice.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 8, 141, 14));
                BtnLogProduction.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 8, 141, 14));
                //BtnLogOrders.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 8, 141, 14));
                BtnLogOrders.Foreground = Brushes.Blue;
                if (tb_LogDtPicker.SelectedDate != null)
                {
                    string startdate = ((DateTime)tb_LogDtPicker.SelectedDate).ToString("yyyy-MM-dd");
                    dtLog = vc.Select("select CONCAT( o.OrderID,'-',o.SortID)as Order#,o.JobID as job#,os.OrderStatusDetail as Order_Status,js.JobStatesDesc as Job_Status,p.PCompanyName,i.ItemsDescription as Item_Detail,o.ItemsQty as Qty,o.ItemsRate as Rate,o.ItemsTotal as Total  from tblOrders o, tblProfile p,tblItems i, OrderStatus os,tblJobStates js   where o.jobStates=js.jobStates and o.ProfileId=p.ProfileId and o.ItemsID=i.ItemsID and os.OrderStatusID=o.OrderStatus and Enteredby='" + CombLogUser.Text + "' and Enteredon>'" + startdate + "' order by  o.OrderID , o.SortID ");
                    LogDetailGrid.ItemsSource = dtLog.Tables[0].DefaultView;
                }
                //LoadLogPanel();
                countLogData();

            }
            else
            {
                MessageBox.Show("Select Log User");
            }

        }
        private void LoadLogPanel()
        {

        }

        private void tb_Log_KeyDown(object sender, KeyEventArgs e)
        {

        }
        private void BtnLogProduction_Click(object sender, RoutedEventArgs e)
        {
            if (CombLogUser.Text != "")
            {
                BtnLogInvoice.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 8, 141, 14));
                //BtnLogProduction.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 8, 141, 14));
                BtnLogOrders.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 8, 141, 14));
                BtnLogProduction.Foreground = Brushes.Blue;
                if (tb_LogDtPicker.SelectedDate != null)
                {
                    string startdate = ((DateTime)tb_LogDtPicker.SelectedDate).ToString("yyyy-MM-dd");
                    dtLog = vc.Select("select vo.ProcessiingID as Job#, p.PName as _Name,ps.vender_type_Descr,vo.IssueQty,vo.IssueRate,vo.ReturnQty  from tblVenderOrders vo, tblProfile p, tblProcessStates ps where vo.ProfileId=p.ProfileId and vo.vender_type_id=ps.vender_type_id and EnteredBy    ='" + CombLogUser.Text + "' and entereddate>'" + startdate + "' order by  VO.ProcessiingID  ");
                    LogDetailGrid.ItemsSource = dtLog.Tables[0].DefaultView;
                }
                //LoadLogPanel();
                countLogData();

            }
            else
            {
                MessageBox.Show("Slect User.");
            }

        }





        #endregion

        private void tbCustomerChkboxCofLedger_Checked(object sender, RoutedEventArgs e)
        {
            SqlCommand sqlCmd = new SqlCommand("select ProfileId,PCompanyName from tblProfile where PType='3'  and Active=1 order by PCompanyName", sqlcon);
            if (sqlcon.State != ConnectionState.Open)
            {
                sqlcon.Open();
            }
            SqlDataReader sqlReader = sqlCmd.ExecuteReader();
            Dictionary<int, string> DictionaryCustomer = new Dictionary<int, string>();
            DictionaryCustomer.Add(0, "Select Customer");
            while (sqlReader.Read())
            {
                string name = sqlReader["PCompanyName"].ToString().Trim();
                int Value = int.Parse(sqlReader["ProfileId"].ToString());
                DictionaryCustomer.Add(Value, name);
            }
            lblCustLedgerCompanyName.ItemsSource = new BindingSource(DictionaryCustomer, null);
            lblCustLedgerCompanyName.DisplayMemberPath = "Value";
            lblCustLedgerCompanyName.SelectedValuePath = "Key";
            lblCustLedgerCompanyName.SelectedIndex = 0;

        }

        private void tbCustomerChkboxCofLedger_Unchecked(object sender, RoutedEventArgs e)
        {
            SqlCommand sqlCmd = new SqlCommand("select ProfileId,PCompanyName from tblProfile where PType='0'  and Active=1 order by PCompanyName", sqlcon);
            if (sqlcon.State != ConnectionState.Open)
            {
                sqlcon.Open();
            }
            SqlDataReader sqlReader = sqlCmd.ExecuteReader();
            Dictionary<int, string> DictionaryCustomer = new Dictionary<int, string>();
            DictionaryCustomer.Add(0, "Select Customer");
            while (sqlReader.Read())
            {
                string name = sqlReader["PCompanyName"].ToString().Trim();
                int Value = int.Parse(sqlReader["ProfileId"].ToString());
                DictionaryCustomer.Add(Value, name);
            }
            lblCustLedgerCompanyName.ItemsSource = new BindingSource(DictionaryCustomer, null);
            lblCustLedgerCompanyName.DisplayMemberPath = "Value";
            lblCustLedgerCompanyName.SelectedValuePath = "Key";
            lblCustLedgerCompanyName.SelectedIndex = 0;
        }

        private void btnPrintCustLedgerSlip_Click(object sender, RoutedEventArgs e)
        {
            if (ds1.Tables[0].Rows.Count > 0)
            {
                CustomerLederform clf = new CustomerLederform(ds1, TxtSearchCustLedgerId.Text, txtCustLedgerBalance.Text,DateTime.Parse( CustLedgerFromDatePicker.SelectedDate.ToString()).ToString("dd-MM-yyyy"),DateTime.Parse(CustLedgerToDatePicker.SelectedDate.ToString()).ToString("dd-MM-yyyy"));
                clf.ShowDialog();
            }
        }

        private void DataGridHyperlinkColumn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void invoicelink_Click(object sender, RoutedEventArgs e)
        {


        }

        private void GridCustLedger_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DataRowView row = (DataRowView)GridCustLedger.SelectedItems[0];
                if (row != null)
                {
                    string iid = row["EventID"].ToString();
                    if (iid != "")
                    {
                        string str = "select DeleteBill from tblMasterInvoice where InvoiceID='"+iid+"'";
                        int status = f.findnumber(str);
                        string invoicestatus = "Duplicate";
                        if (status == 1)
                        {
                            invoicestatus = "This Bill is Deleted.";
                        }
                        InvoiceSlipForm isp = new InvoiceSlipForm(int.Parse(iid), invoicestatus);
                        isp.Show();
                    }
                }
            }
            catch (Exception es)
            {

            }

        }

        private void txtPendingOrders_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtPendingOrders.Text != "" && txtPendingOrders.Text.Contains('-') && e.Key == Key.Enter)
            {
                Btnfindjobs_OnClick(sender, e);
            }

        }

        private void chkbxSelectAllWork_Unchecked(object sender, RoutedEventArgs e)
        {
            lblCompanyNameVender.IsEnabled = true;

        }

        private void chkbxSelectAllWork_Checked(object sender, RoutedEventArgs e)
        {
            lblCompanyNameVender.SelectedIndex = 0;
            lblCompanyNameVender.IsEnabled = false;
            lblVenderID.Content = "";

        }

        private void MainTab_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btn_tbmyCompany_prod_refresh_Click(object sender, RoutedEventArgs e)
        {
            //order Recieved
            DataSet ds = new DataSet();
            ds.Tables.Clear();
            if (vc != null) ds = vc.Select("select * from  Vw_OrderRecieved_by_VesterTypes");
            //v.IssueDate >= '" + dtf.ToString("yyyy-MM-dd") + "' and v.IssueDate <=  '" + dtt.ToString("yyyy-MM-dd") + "' 
            tb_mycompany_GridOrderRcievedStatus.ItemsSource = ds.Tables[0].DefaultView;
            tb_mycompany_GridOrderRcievedStatus.DisplayMemberPath = ds.Tables[0].Columns[0].ToString();
        }
        DataSet dsCashinHand = new DataSet();
        private void btn_tbmyCompany_CashINHand_refresh_Click(object sender, RoutedEventArgs e)
        {
            string fromdt = DateTime.Parse(DtpickCashinHandFrom.SelectedDate.ToString()).ToString("yyyy-MM-dd");
            /// string todt = DateTime.Parse(DtpickCashINHandTo.SelectedDate.ToString()).ToString("yyyy-MM-dd");
            
            SqlCommand cmd;
            cmd = new SqlCommand("sp_DailyCashInOut", sqlcon);
            cmd.CommandType = CommandType.StoredProcedure;
            dsCashinHand.Clear();
            cmd.Parameters.Add(new SqlParameter("@fromdate", fromdt));
            //cmd.Parameters.Add(new SqlParameter("@todate", todt));
            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            adap.Fill(dsCashinHand);
            adap.Dispose();
            if (sqlcon.State != ConnectionState.Closed)
            {
                sqlcon.Close();
            }
            tb_CashInHand_GridDetail.ItemsSource = dsCashinHand.Tables[0].DefaultView;
            tb_CashInHand_GridDetail.DisplayMemberPath = dsCashinHand.Tables[0].Columns[0].ToString();

        }

        private void btnSettingAdjustOrderBil_Click(object sender, RoutedEventArgs e)
        {
            TransferForm fm = new TransferForm(LoginUser,SystemUser);
            fm.ShowDialog();
        }
        DataSet dsproductionpairs = new DataSet();
        private void btn_tbmyCompany__refresh_Click(object sender, RoutedEventArgs e)
        {
            SqlCommand cmd;
            DateTime dtfrom = DateTime.Parse(DtpickMyCompnyProdDelivFrom.SelectedDate.ToString());
            DateTime dtto = DateTime.Parse(DtpickMyCompnyProdDelivTo.SelectedDate.ToString());
            if (RbProductiontbSearchbyBill.IsChecked == true)
            {
                if (txtProductiontbSearchbyBillfrom.Text == "")
                {
                    MessageBox.Show("Enter Range from bill number.");
                    return;
                }
                if (txtProductiontbSearchbyBillto.Text == "")
                {
                    MessageBox.Show("Enter Range from bill number.");
                    return;
                }
                cmd = new SqlCommand("spCountPairsProductionbyBill", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                dsproductionpairs.Clear();
                cmd.Parameters.Add(new SqlParameter("@BillFrom",( txtProductiontbSearchbyBillfrom.Text)));
                cmd.Parameters.Add(new SqlParameter("@BillTo", (txtProductiontbSearchbyBillto.Text)));
            }
            else
            {
                cmd = new SqlCommand("CountPairsProduction", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                dsproductionpairs.Clear();
                cmd.Parameters.Add(new SqlParameter("@fromdate", dtfrom));
                cmd.Parameters.Add(new SqlParameter("@todate", dtto));
            }
            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            adap.Fill(dsproductionpairs);
            adap.Dispose();
            if (sqlcon.State != ConnectionState.Closed)
            {
                sqlcon.Close();
            }
            tb_mycompany_GridProductionCompl.ItemsSource = dsproductionpairs.Tables[0].DefaultView;
            tb_mycompany_GridProductionCompl.DisplayMemberPath = dsproductionpairs.Tables[0].Columns[0].ToString();

        }

        private void btn_tbmyCompany__PrintReport_Click(object sender, RoutedEventArgs e)
        {
                DateTime dtfrom = DateTime.Parse(DtpickMyCompnyProdDelivFrom.SelectedDate.ToString());
                DateTime dtto = DateTime.Parse(DtpickMyCompnyProdDelivTo.SelectedDate.ToString());
                int f = 0;
                if (RbProductiontbSearchbyBill.IsChecked == true)
                {
                    f = 1;
                }
                ProductionCountByVTypeFrm fm = new ProductionCountByVTypeFrm(dtfrom.ToString("yyyy-MM-dd"),dtto.ToString("yyyy-MM-dd"),int.Parse(txtProductiontbSearchbyBillfrom.Text), int.Parse(txtProductiontbSearchbyBillto.Text),f);
                fm.Show();
        }

        private void btn_tbmyCompany__AllCustomerSummaryPrintReport_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AllCustomerBalance abs = new AllCustomerBalance();
                abs.ShowDialog();
            }catch(Exception es)
            {
                MessageBox.Show("All Customer Balance Report: "+es.Message);
            }
            
        }

        private void BtnBackupDatabase_OnClick(object sender, RoutedEventArgs e)
        {
            dobackup();
        }

        private void RbProductiontbSearchbyBill_Checked(object sender, RoutedEventArgs e)
        {
            if (RbProductiontbSearchbyBill.IsChecked == true)
            {
                DtpickMyCompnyProdDelivFrom.IsEnabled = false;
                DtpickMyCompnyProdDelivTo.IsEnabled = false;
                txtProductiontbSearchbyBillfrom.IsEnabled = true;
                txtProductiontbSearchbyBillto.IsEnabled = true;
            }
        }

        private void RbProductiontbSearchbyDate_Checked(object sender, RoutedEventArgs e)
        {
            if (RbProductiontbSearchbyDate.IsChecked == true)
            {
                txtProductiontbSearchbyBillfrom.IsEnabled = false;
                txtProductiontbSearchbyBillto.IsEnabled = false;
                DtpickMyCompnyProdDelivFrom.IsEnabled = true;
                DtpickMyCompnyProdDelivTo.IsEnabled = true;
            }
        }

        private void btnVenderManualWork_Click(object sender, RoutedEventArgs e)
        {
            if (lblVenderID.Content == "")
            {
                MessageBox.Show("کاریگر کا انتخاب کرئں۔");
                return;
            }
            if(txtVenderAdditionalAmount.Text!=""&& txtVenderAdditonalworkdetail.Text != "")
            {
                if(int.Parse(txtVenderAdditionalAmount.Text) > 0)
                {
                    string str = "insert into tblVenderBills(ProfileID,VAmount,VDateTime,EnteredON,EnteredBy,VFlag,VRemarks,EnteredIN,ismanulaentry) values('" + lblVenderID.Content+ "','" + txtVenderAdditionalAmount.Text + "','" + DateTime.Today + "','" + DateTime.Now + "','" + LoginUser + "','C','" + txtVenderAdditonalworkdetail.Text+"','"+SystemUser+"',1)";
                    vc.Insert(str);
                    txtVenderAdditonalworkdetail.Text = "";
                    txtVenderAdditionalAmount.Text = "";
                    BtnVenderLedgerExecute_OnClick(sender, e);

                }
                else
                {
                    MessageBox.Show("کام کی رقم 0 سے زیادہ ہونی چاہیئے۔");
                }
            }
            else
            {
                MessageBox.Show("کام کی تفصیل اور کام کی رقم بتائیں");
            }
        }

        private void dobackup()
        {
            // read connectionstring from config file
            var connectionString = ConfigurationManager.ConnectionStrings["sqldbx"].ConnectionString;

            // read backup folder from config file ("C:/temp/")
            string backupFolder = ConfigurationManager.AppSettings["BackupFolder"];
            //backupFolder= 


            var sqlConStrBuilder = new SqlConnectionStringBuilder(connectionString);

            // set backupfilename (you will get something like: "C:/temp/MyDatabase-2013-12-07.bak")
            var backupFileName = String.Format("{0}VesterShoes-{1}.bak",
                backupFolder,
                DateTime.Now.ToString("dd-MM-yyyy_HHmm"));
            //var backupFileName = String.Format(@"{0}{1}-{2}.bak",
            //    backupFolder, sqlConStrBuilder.InitialCatalog,
            //    DateTime.Now.ToString("yyyy-MM-dd_HHmm"));
            backupFileName = backupFileName.Replace("\\", @"\");
            using (var connection = new SqlConnection(sqlcon.ConnectionString))
            {
                var query = String.Format("BACKUP DATABASE VesterDB TO DISK='{0}'", backupFileName);
                //var query = String.Format("BACKUP DATABASE {0} TO DISK='{1}'",
                //    sqlConStrBuilder.InitialCatalog, backupFileName);

                using (var command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Successfully Created Backup to " + backupFileName);
                }
            }
        }
    }
}
