using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Windows.Media;
using VesterShoes.classes;
using VesterShoes.Reports;
using MessageBox = System.Windows.MessageBox;

namespace VesterShoes
{
    /// <summary>
    /// Interaction logic for FormOrderfm.xaml
    /// </summary>
    public partial class FormOrderfm : Page
    {
        SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["sqldbx"].ConnectionString);
        functions f = new functions();
        public FormOrderfm(string loguser,string systemuser)
        {
            InitializeComponent();
            SystemUser = systemuser;
            LoginUser = loguser;
        }
        
        public string gvar="";
        int custID = 0;
        public string SystemUser { get; set; }
        public string LoginUser { get; set; }


        private void btnAddOrder_Click(object sender, RoutedEventArgs e)
        {
            gvar = "Orderform";
            FormProfileFm fcf = new FormProfileFm(gvar,LoginUser,SystemUser);
            if (fcf.ShowDialog() == DialogResult.OK)
            {
                custID = fcf.GlobalVar;
            };
           
            LoadCustomer(custID);
           
            CountData();
        }

        private void CountData()
        {
            int Bal = f.findnumber("select top(1) BalanceAmount from tblLedger where ProfileId='"+custID+"' order by ledgerID desc");
            lblBalanceAmount.Content = Bal.ToString();
            int RunningOrders = f.findnumber("select COUNT(*) from tblOrders where ProfileId='"+custID+"' and Complete='0' and jobStates='1'");
            lblRunningOrders.Content = RunningOrders.ToString();
            int pendingOrders = f.findnumber("select COUNT(*) from tblOrders where ProfileId='"+custID+"' and Complete='0' and jobStates='0'");
            lblPendingOrders.Content = pendingOrders.ToString();
        }
       
        private void LoadCustomer(int id)
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
                        lblCustomerID.Content = id;
                        lblCompanyName.Text = (dr.GetValue(0).ToString());
                        lblpname.Content = (dr.GetValue(1).ToString());
                        lblofficenumber.Content = (dr.GetValue(2).ToString());
                        lblofficeaddress.Content = (dr.GetValue(3).ToString());

                    }
                    else
                    {
                        System.Windows.MessageBox.Show("No Record Found");

                    }
                    dr.Close();
                    lblofficenumber.Visibility = Visibility.Visible;
                    lblofficeaddress.Visibility = Visibility.Visible;
                    lblpname.Visibility = Visibility.Visible;
                    lblCompanyName.Visibility = Visibility.Visible;
                    Loadgridorder();

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

        private void gridOrderDetail_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
        }

        private void gridOrderDetail_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {

        }
        int sortid = 0;
        int col = 0;
        int row = 1;
        string Itemgselected="";

        private void clearall()
        {
            //TxtitemId.Text = "";
            
            lblCustomerID.Content = "";
            lblCompanyName.Text = "";
            lblofficenumber.Visibility = Visibility.Hidden;
            lblofficeaddress.Visibility = Visibility.Hidden;
            lblpname.Visibility = Visibility.Hidden;
            lblCompanyName.Visibility = Visibility.Hidden;

        }

        private void Loadgridorder()
        {
            btnRunningOrders.Foreground = Brushes.Blue;
            btnDeliverdOrders.Foreground= new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 8, 141, 14));
            btnCompletedOrders.Foreground= new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 8, 141, 14));
            DataSet ds = new DataSet();
            if (vc != null) ds = vc.Select("select * from tblorders o , tblItems i where o.ItemsID=i.ItemsID and ProfileId='"+lblCustomerID.Content+ "' and Complete=0 and jobStates=1 order by OrderID desc");

            GridCustOrder.ItemsSource = ds.Tables[0].DefaultView;
            GridCustOrder.DisplayMemberPath = ds.Tables[0].Columns[0].ToString();
            
        }
        private void BtnCompletedOrders_OnClick(object sender, RoutedEventArgs e)
        {
            btnRunningOrders.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 8, 141, 14));
            btnDeliverdOrders.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 8, 141, 14));
            btnCompletedOrders.Foreground = Brushes.Blue;

            if (lblCustomerID.Content.ToString() == "")
            {
                return;
            }
            DataSet ds = new DataSet();
            if (vc != null) ds = vc.Select("select * from tblorders o , tblItems i where o.ItemsID=i.ItemsID and ProfileId='" + lblCustomerID.Content + "' and Complete='1' and jobStates='5' order by OrderID desc");

            GridCustOrder.ItemsSource = ds.Tables[0].DefaultView;
            GridCustOrder.DisplayMemberPath = ds.Tables[0].Columns[0].ToString();
            CountData();
        }
        private void BtnRunningOrders_OnClick(object sender, RoutedEventArgs e)
        {
            if (lblCustomerID.Content.ToString() == "")
            {
                return;
            }
            Loadgridorder();
            CountData();
        }

        private void BtnDeliverdOrders_OnClick(object sender, RoutedEventArgs e)
        {
            btnRunningOrders.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 8, 141, 14));
            btnDeliverdOrders.Foreground = Brushes.Blue;
            btnCompletedOrders.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 8, 141, 14));

            if (lblCustomerID.Content.ToString() == "")
            {
                return;
            }
            DataSet ds = new DataSet();
            if (vc != null) ds = vc.Select("select * from tblorders o , tblItems i where o.ItemsID=i.ItemsID and ProfileId='" + lblCustomerID.Content + "' and Complete='1' and jobStates='8' order by OrderID desc");

            GridCustOrder.ItemsSource = ds.Tables[0].DefaultView;
            GridCustOrder.DisplayMemberPath = ds.Tables[0].Columns[0].ToString();
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
           
            lblofficenumber.Visibility = Visibility.Hidden;
            lblofficeaddress.Visibility = Visibility.Hidden;
            lblpname.Visibility = Visibility.Hidden;
            lblCompanyName.Visibility = Visibility.Hidden;

            //itemsForm itf = new itemsForm();
            //itf.Show();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    DateTime dt = DateTime.Now;
            //    string StrQuery = "UPDATE tblMaterOrde SET TotalAmount = '" + txtGrandTotal.Text + "' , Enteredon='" + dt + "',Enteredby='" + "" + "', OrderSave='" + 0 + "' ,Cancel='"+1+"' WHERE MaterOrderID = '" + lblOrderID.Content + "' ";

            //    sqlcon.Open();
            //    SqlCommand command1 = new SqlCommand(StrQuery, sqlcon);
            //    command1.ExecuteNonQuery();sqlcon.Close();
            //    clearall();
            //    Loadgridorder();
            //    btnAddOrder.IsEnabled = true;

            //}
            //catch (Exception es)
            //{
            //    System.Windows.MessageBox.Show(es.ToString());

            //}
            //finally
            //{
            //    sqlcon.Close();
            //}
         }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            //if (gridOrderDejtail.Items.Count!=0)
            //{
            //    try
            //    {
            //        DateTime dt = DateTime.Now;
            //        string strQuery = "UPDATE tblMasterOrder SET TotalAmount = '" + txtGrandTotal.Text + "' , Enteredon='" + dt + "',Enteredby='" + "" + "', jobStates='" + comborderstatess.SelectedIndex + "' WHERE OrderId = '" + lblOrderID.Content + "' ";
            //        sqlcon.Open();
            //        SqlCommand command1 = new SqlCommand(strQuery, sqlcon); ;
            //        command1.ExecuteNonQuery();
            //        sqlcon.Close();
            //    }
            //    catch (Exception es)
            //    {
            //        System.Windows.MessageBox.Show(es.ToString());

            //    }
            //    finally
            //    {
            //        sqlcon.Close();
            //    }
            //}
            //else
            //{
            //    try
            //    {
            //        vc.Delete("delete from tblMasterOrder where OrderID='" + lblOrderID.Content + "'");
            //        vc.Delete("delete from tblOrders where OrderID='" + lblOrderID.Content + "'");
            //    }
            //    catch (Exception es)
            //    {

            //        MessageBox.Show(es.Message);
            //    }

            //}
            //clearall();
            //sortid = 0;
            //Loadgridorder();
            //btnAddOrder.IsEnabled = true;

        }

        //int rate, qty;
        //private void totalamount()
        //{
        //    if (Txtqty.Text.Trim() == "")
        //    {
        //        qty = 0;
        //    }
        //    else
        //    {
        //        try
        //        {
        //            qty = int.Parse(Txtqty.Text.Trim());
        //        }
        //        catch (Exception)
        //        {
        //            Txtqty.Text = "";
        //            qty = 0;
        //        }
        //    }
        //    if (TxtRate.Text == "")
        //    {
        //        rate = 0;
        //    }
        //    else
        //    {
        //        try
        //        {
        //            rate= int.Parse(TxtRate.Text.Trim());
        //        }
        //        catch (Exception)
        //        {
        //            TxtRate.Text = "";
        //            rate= 0;
        //        }
        //    }



        //    TxtTotal.Text = (qty * rate).ToString();
            
        //}
        private void txtRate_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }



        private void txtqty_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void txtGrandTotal_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnCompleted_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    DateTime dt = DateTime.Now;
            //    string StrQuery = "UPDATE tblMaterOrde SET TotalAmount = '" + txtGrandTotal.Text + "' , Enteredon='" + dt + "',Enteredby='" + "" + "', OrderSave='" + 0 + "' ,Cancel='" + 0 + "' , Completed='"+1+"' WHERE MaterOrderID = '" + lblOrderID.Content + "' ";

            //    sqlcon.Open();
            //    SqlCommand command1 = new SqlCommand(StrQuery, sqlcon);
            //    command1.ExecuteNonQuery(); sqlcon.Close();
            //    clearall();
            //    Loadgridorder();
            //    btnAddOrder.IsEnabled = true;

            //}
            //catch (Exception es)
            //{
            //    System.Windows.MessageBox.Show(es.ToString());

            //}
            //finally
            //{
            //    sqlcon.Close();
            //}
        
    }

        private void txtRate_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            
        }

        private void comborderstatess_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (comborderstatess.SelectedIndex != 0)
            //{
            //    System.Windows.MessageBox.Show("Order Must be Saved First, then Starts.");
            //    comborderstatess.SelectedIndex = 0;
            //}
        }
        VestureClass vc = new VestureClass();
        private void TxtRate_LostFocus(object sender, RoutedEventArgs e)
        {
            
        }

        private void Txtqty_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            
        }

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

        private void chkStatus_Checked(object sender, RoutedEventArgs e)
        {

            
            DataRowView dataRow = (DataRowView)GridCustOrder.SelectedItem;
            if (dataRow != null)
            {
                int Orderid = int.Parse(dataRow.Row.ItemArray[1].ToString());
                int sortid = int.Parse(dataRow.Row.ItemArray[2].ToString());
                int CustID = int.Parse(dataRow.Row.ItemArray[3].ToString());
                int itemId = int.Parse(dataRow.Row.ItemArray[4].ToString());
                int ItemsQty = int.Parse(dataRow.Row.ItemArray[5].ToString());
                int a = int.Parse(dataRow.Row.ItemArray[8].ToString());


                if (a==1)
                {
                    //Loadgridorder();
                    return;
                }

                string dt = (DateTime.Today).ToString("yyyy-MM-dd");
                int Jobnumb = f.createNumber("select top(1) JobID from tblOrders order by JobID desc");
                vc.Update("update tblOrders set jobid='" + Jobnumb + "', jobStates='1' , OrderStatus='1', JobStartDate='" + dt+ "', jobEnteredby='"+"User"+ "', jobenteredon='"+DateTime.Now+"' where orderid='" + Orderid + "' and sortid='" + sortid + "'  ");
                Loadgridorder();
                //jobCardForm jcd = new jobCardForm("", DateTime.Today, CustID, itemId, Orderid.ToString(), Jobnumb, ItemsQty,lblpname.Content.ToString());
                //jcd.Show();
                CountData();
            }
        }

        private void chkStatus_Unchecked(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("un  checked");
        }

        private void GridCustOrder_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int id = 0;
            DataRowView dataRow = (DataRowView)GridCustOrder.SelectedItem;
            if (dataRow != null)
            {
                string cellValue = dataRow.Row.ItemArray[15].ToString();
                if (cellValue != "")
                {
                    id = int.Parse(cellValue);
                    ProcessingControl fdf = new ProcessingControl(id);
                    fdf.ShowDialog();
                }
            }
        }

        private void BtnGenOrder_OnClick(object sender, RoutedEventArgs e)
        {
            if (lblCustomerID.Content.ToString() != "")
            {
                itemsForm Itf = new itemsForm(lblCompanyName.Text, lblCustomerID.Content.ToString(),LoginUser,SystemUser);
                if (Itf.ShowDialog() == DialogResult.OK)
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
                GenerateBill Itf = new GenerateBill(lblCustomerID.Content.ToString(),lblCompanyName.Text,lblBalanceAmount.Content.ToString(),LoginUser,SystemUser);
                if (Itf.ShowDialog() == DialogResult.OK)
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


        
    }


}
