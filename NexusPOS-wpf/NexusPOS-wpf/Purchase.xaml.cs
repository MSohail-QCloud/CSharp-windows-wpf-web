using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NexusPOS_wpf
{
    /// <summary>
    /// Interaction logic for Purchase.xaml
    /// </summary>
    public partial class Purchase : Page
    {
        OleDbConnection olecon = new OleDbConnection(ConfigurationManager.ConnectionStrings["Accdbx"].ConnectionString);
        public int POnumber { get; set; }
        public Purchase()
        {
            InitializeComponent();
        }
        private void AddPurchase_Loaded(object sender, RoutedEventArgs e)
        {
            createPONumber();
            LoadComboVenderlist();
            dtpickerDeliveryDate.SelectedDate = DateTime.Today;
            loadGrid();
            combVenderName_DropDownClosed(sender, e);
            LoadComboCatagoryList();
            LoadComboProductList();
        }
        private void btnAddPerson_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SaveItem_Click(object sender, RoutedEventArgs e)
        {
            if (txtTotalAmount.Text != "" && txtTotalAmount.Text != "0" && txtRate.Text != "")
            {
                try
                {
                    string dt = DateTime.Now.ToString("dd-MM-yyyy hh:mm tt");
                    olecon.Open();
                    String query1 = "insert into DetailPO (POnumber,ProductID ,Qty,Rate,Total,TransportationCharges,TotalAmount,DeliveryDate,DeliveryStatus,Active) values ('" + this.lblPOnumber.Content + "','" + this.lblProductID.Content + "','" + txtQty.Text + "','" + txtRate.Text + "','" + txtTotal.Text + "','" + txtTransportationCharg.Text + "','" + txtTotalAmount.Text + "','" + dtpickerDeliveryDate.SelectedDate + "','" + ComboDeliveryStatus.Text + "','" + 0 + "')";
                    OleDbCommand cmd1 = new OleDbCommand(query1, olecon);
                    cmd1.ExecuteNonQuery();
                    //update stck
                    string query3 = " insert into ProductStock (ProductID , POnumber , Qty ,Notification,StockDate  ) values ('" + this.lblProductID.Content + "','" + this.lblPOnumber.Content + "','" + txtQty.Text + "' ,'" + "Purchase" + "' ,'" + dt + "' )";
                    OleDbCommand cmd3 = new OleDbCommand(query3, olecon);
                    cmd3.ExecuteNonQuery();
                    olecon.Close();
                    clear();
                    loadGrid();

                }
                catch (Exception es)
                {
                    MessageBox.Show(es.ToString());
                    olecon.Close();
                }
            }
            else
            {
                MessageBox.Show("Must Fill All Forms.");
            }
        }

        private void loadGrid()
        {
            DataSet ds = new DataSet();
            //q = "select dt.menu_qty,dt.menu_name,dt.menurate,dt.total,dt.detail_bill_id,mb.table_no,mb.billamount,mb.billDiscount,mb.grandTotal,mb.paidamount,mb.change from detailbill dt  inner join mastebill mb on mb.billnumber=dt.masterbill_id where mb.billnumber=" + txt__billnumber.Text + " and mb.deletebill=1";
            //string getEmpSQL = "SELECT * from DetailPO dp  inner join MasterPO mp on mp.POnumber=dp.POnumber where mp.POnumber=" + lblPOnumber.Content + " and mp.deletePO= 0 and mp.Complete=0 and mp.CancelPO=0 and [dp.Active]=" + 1 + " order by dp.POid ";
            string getEmpSQL = "SELECT * from DetailPO  where POnumber=" + lblPOnumber.Content + " and [Active]=" + 0 + " order by POid ";
            OleDbDataAdapter sda = new OleDbDataAdapter(getEmpSQL, olecon);

            try
            {
                olecon.Open();
                sda.Fill(ds);
            }
            catch (Exception se)
            {
                MessageBox.Show("An error occured while connecting to database" + se.ToString());
            }
            finally
            {
                olecon.Close();
            }
            float sum = 0;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                sum += float.Parse(dr["totalamount"].ToString());
            }
            datagridPO.ItemsSource = ds.Tables[0].DefaultView;
            datagridPO.DisplayMemberPath = ds.Tables[0].Columns[0].ToString();
            txtSubTotal.Text = sum.ToString();
            //combCustomerName.SelectedIndex = 0;
        }

        private void clear()
        {
            txtQty.Text = "";
            //txtRate.Text = "";
            txtTransportationCharg.Text = "";
            txtTotalAmount.Text = "";
            txtDiscount.Text = "0";
            txtSubTotal.Text = "0";
        }



        private void createPONumber()
        {
            try
            {
                OleDbDataReader dr;
                olecon.Open();
                string query = "select top 1 POnumber  from MasterPO order by POnumber desc";
                OleDbCommand cmd = new OleDbCommand(query, olecon);//Advised to use parameterized query
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    POnumber = int.Parse(dr.GetValue(0).ToString());
                    POnumber = POnumber + 1;
                }
                else
                {
                    POnumber = 1;

                }
                dr.Close();
                lblPOnumber.Content = POnumber.ToString();
                olecon.Close();
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message.ToString());
                return;
            }

        }
        private void LoadComboVenderlist()
        {
            DataSet ds = new DataSet();
            string getEmpSQL = "SELECT PersonName FROM PersonInfo where PersonType='Vender' and [Active]=" + 1 + " order by Personid ";
            OleDbDataAdapter sda = new OleDbDataAdapter(getEmpSQL, olecon);

            try
            {
                olecon.Open();
                sda.Fill(ds);
            }
            catch (Exception se)
            {
                MessageBox.Show("An error occured while connecting to database" + se.ToString());
            }
            finally
            {
                olecon.Close();
            }

            combVenderName.ItemsSource = ds.Tables[0].DefaultView;
            combVenderName.DisplayMemberPath = ds.Tables[0].Columns[0].ToString();
            combVenderName.SelectedIndex = 0;

        }

        private void LoadComboCatagoryList()
        {
            DataSet ds = new DataSet();
            string getEmpSQL = "SELECT DISTINCT Catagory FROM ProductsInfo order by Catagory ";
            OleDbDataAdapter sda = new OleDbDataAdapter(getEmpSQL, olecon);

            try
            {
                olecon.Open();
                sda.Fill(ds);
            }
            catch (Exception se)
            {
                MessageBox.Show("An error occured while connecting to database" + se.ToString());
            }
            finally
            {
                olecon.Close();
            }

            ComboCatagory.ItemsSource = ds.Tables[0].DefaultView;
            ComboCatagory.DisplayMemberPath = ds.Tables[0].Columns[0].ToString();
            ComboCatagory.SelectedIndex = 0;

        }
        private void LoadComboProductList()
        {
            DataSet ds = new DataSet();
            string getEmpSQL = "SELECT  ProductDescription FROM ProductsInfo order by ProductDescription ";
            OleDbDataAdapter sda = new OleDbDataAdapter(getEmpSQL, olecon);

            try
            {
                olecon.Open();
                sda.Fill(ds);
            }
            catch (Exception se)
            {
                MessageBox.Show("An error occured while connecting to database" + se.ToString());
            }
            finally
            {
                olecon.Close();
            }

            ComboProduct.ItemsSource = ds.Tables[0].DefaultView;
            ComboProduct.DisplayMemberPath = ds.Tables[0].Columns[0].ToString();
            ComboProduct.SelectedIndex = 0;

        }

        private void btnAddPerson_Click_1(object sender, RoutedEventArgs e)
        {
            Window3 w3 = new Window3();
            w3.FormName = "Addpeople";
            w3.ShowDialog();
            LoadComboVenderlist();
        }

        private void combVenderName_DropDownClosed(object sender, EventArgs e)
        {
            try
            {
                if (combVenderName.Items.Count > 0)
                {
                    OleDbDataReader dr;
                    if (olecon.State == ConnectionState.Closed)
                    {
                        olecon.Open();
                    }

                    string query = "select Personid,mobileNumber from PersonInfo where [PersonName]='" + combVenderName.Text + "' ";
                    OleDbCommand cmd = new OleDbCommand(query, olecon);//Advised to use parameterized query
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        lblVenderID.Content = (dr.GetValue(0).ToString());
                        txtPhoneVender.Text = (dr.GetValue(1).ToString());
                    }
                    dr.Close();
                    Myclass mc = new Myclass();
                    if (lblVenderID.Content.ToString() != "")
                    {
                        lblPreviouseBalance.Content = (mc.findVenderBalance(int.Parse(lblVenderID.Content.ToString())));

                    }

                    //olecon.Close();
                }
            }
            catch (Exception es)
            {
                MessageBox.Show(es.ToString());
            }
            finally
            {
                if (olecon.State == ConnectionState.Open)
                {
                    olecon.Close();
                }
            }
        } 

        private void txtPhoneVender_SelectionChanged(object sender, RoutedEventArgs e)
        {
            combVenderName_DropDownClosed(sender, e);
        }

        private void txtSizeWidth_TextChanged(object sender, TextChangedEventArgs e)
        {
            findSize();
            findtotal();
            totalamount();
        }

        private void txtSizeLength_TextChanged(object sender, TextChangedEventArgs e)
        {
            findSize();
            findtotal();
            totalamount();
        }

        private void findSize()
        {
            if (txtSizeLength.Text != "" && txtSizeWidth.Text != "")
            {
                txtSizetotal.Text = (float.Parse(txtSizeLength.Text) * float.Parse(txtSizeWidth.Text)).ToString();
            }
            else
            {
                txtSizetotal.Text = "0";
            }
        }

        private void findtotal()
        {
            if (txtSizetotal.Text != "" && txtRate.Text != "" && txtQty.Text != "")
            {
                txtTotal.Text = (float.Parse(txtSizetotal.Text) * float.Parse(txtRate.Text) * float.Parse(txtQty.Text)).ToString();
            }
            else
            {
                txtTotalAmount.Text = "0";
            }

        }
        private void totalamount()
        {
            if (txtTransportationCharg.Text == "")
            {
                txtTransportationCharg.Text = "0";
            }
            

            if (txtTotal.Text != "")
            {
                txtTotalAmount.Text = (float.Parse(txtTotal.Text) + float.Parse(txtTransportationCharg.Text) ).ToString();
            }
        }

        private void txtQty_TextChanged(object sender, TextChangedEventArgs e)
        {
            findSize();
            findtotal();
            totalamount();
        }

        private void txtRate_TextChanged(object sender, TextChangedEventArgs e)
        {
            findSize();
            findtotal();
            totalamount();
        }

        private void txtTransportationCharg_TextChanged(object sender, TextChangedEventArgs e)
        {
            findSize();
            findtotal();
            totalamount();
        }

        private void btnGenerateBill_Click(object sender, RoutedEventArgs e)
        {
            if (txtSubTotal.Text != "" && txtSubTotal.Text != "0" && datagridPO.Items.Count >= 1 && lblVenderID.Content.ToString() !="")
            {
                try
                {
                    string dt = DateTime.Now.ToString("dd-MM-yyyy hh:mm tt");
                    olecon.Open();
                    //insert into master PO
                    String query1 = " insert into MasterPO (POnumber , Personid , SubTotal , Discount , GrandTotal , printdatetime , deletePO , Complete,CancelPO  ) values ('" + this.lblPOnumber.Content + "','" + this.lblVenderID.Content + "','" + txtSubTotal.Text + "' ,'" + txtDiscount.Text + "' ,'" + txtGrandtotal.Text + "' ,'" + dt + "','" + "0" + "','" + "1" + "','" + "0" + "')";
                    OleDbCommand cmd1 = new OleDbCommand(query1, olecon);
                    cmd1.ExecuteNonQuery();
                    string query2 = " insert into PurchaseRegister (Personid , POnumber , TotalPO , PaidPO , PaidDate , PaidNotice  ) values ('" + this.lblVenderID.Content + "','" + this.lblPOnumber.Content + "','" + txtGrandtotal.Text + "' ,'" + txtAdvancPaid.Text + "' ,'" + dt + "' ,'" + "Advance Paid " + "')";
                    OleDbCommand cmd2 = new OleDbCommand(query2, olecon);
                    cmd2.ExecuteNonQuery();
                    //activate bill
                    OleDbCommand command = new OleDbCommand(@"UPDATE DetailPO SET Active = @active WHERE POnumber = @bnum ", olecon);
                    command.Parameters.AddWithValue("@active", 1);
                    command.Parameters.AddWithValue("@bnum", lblPOnumber.Content);
                    command.ExecuteNonQuery();
                    if (olecon.State == ConnectionState.Open)
                    {
                        olecon.Close();
                    }
                    clear();
                    createPONumber();
                    combVenderName_DropDownClosed(sender, e);
                    loadGrid();
                }
                catch (Exception es)
                {
                    MessageBox.Show(es.ToString());
                    olecon.Close();
                }
            }
            else
            {
                MessageBox.Show("Must Fill All Forms.");

            }
        }
        private void findgrantotal()
        {
            if (txtSubTotal.Text != "")
            {
                if (txtDiscount.Text == "")
                {
                    txtDiscount.Text = "0";
                }

                txtGrandtotal.Text = (float.Parse(txtSubTotal.Text) - float.Parse(txtDiscount.Text)).ToString();
            }
        }

        private void txtSubTotal_TextChanged(object sender, TextChangedEventArgs e)
        {
            findgrantotal();
        }

        private void txtDiscount_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtDiscount.Text != "" && txtSubTotal.Text != "")
            {
                if (int.Parse(txtDiscount.Text) < int.Parse(txtSubTotal.Text))
                {
                    findgrantotal();
                }
                else
                {
                    MessageBox.Show("Discount is Greater then Sub total.");
                    txtDiscount.Text = "";
                }
            }
        }

        private void txtGrandtotal_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtAdvancPaid.Text = txtGrandtotal.Text;
        }
        private void findRemainingPayment()
        {
            if (txtAdvancPaid.Text != "" && int.Parse(txtAdvancPaid.Text) >= 0)
            {
                txtremainig.Text = (int.Parse(txtGrandtotal.Text) - int.Parse(txtAdvancPaid.Text)).ToString();
            }
        }

        private void txtAdvancPaid_TextChanged(object sender, TextChangedEventArgs e)
        {
            findRemainingPayment();
        }

        private void ComboProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
        private void getproductDetail()
        {
            try
            {
                if (ComboProduct.Items.Count > 0)
                {
                    OleDbDataReader dr;
                    if (olecon.State == ConnectionState.Closed)
                    {
                        olecon.Open();
                    }

                    string query = "select ProductID,Catagory,BrandName,SizeWidth,SizeLength,NetWeight,GrossWeight,SalesPrice,Comment,PackingType from ProductsInfo where [ProductDescription]='" + ComboProduct.Text + "' ";
                    OleDbCommand cmd = new OleDbCommand(query, olecon);//Advised to use parameterized query
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        lblProductID.Content = (dr.GetValue(0).ToString());
                        ComboCatagory.SelectedValue = (dr.GetValue(1).ToString());
                        txtSizeWidth.Text = (dr.GetValue(3).ToString());
                        txtSizeLength.Text = (dr.GetValue(4).ToString());
                        txtNetWeight.Text = (dr.GetValue(5).ToString());
                        txtGrossweight.Text = (dr.GetValue(6).ToString());
                        txtRate.Text = (dr.GetValue(7).ToString());
                    }
                    dr.Close();
                    txtQty.Focus();
                }
            }
            catch (Exception es)
            {
                MessageBox.Show(es.ToString());
            }
            finally
            {
                if (olecon.State == ConnectionState.Open)
                {
                    olecon.Close();
                }
            }
        }

        private void ComboProduct_DropDownClosed(object sender, EventArgs e)
        {
            getproductDetail();
        }

        private void txtQty_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);

        }

        private void txtRate_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var regex = new Regex(@"^[0-9]*(?:\.[0-9]*)?$");
            if (regex.IsMatch(e.Text) && !(e.Text == "." && ((TextBox)sender).Text.Contains(e.Text)))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtTransportationCharg_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void txtDiscount_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void txtAdvancPaid_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void btnCancelBill_Click(object sender, RoutedEventArgs e)
        {
            if (datagridPO.Items.Count>0)
            {
                try
                {
                    string dt = DateTime.Now.ToString("dd-MM-yyyy hh:mm tt");
                    olecon.Open();
                    //insert into master PO
                    String query1 = " insert into MasterPO (POnumber , Personid , SubTotal , Discount , GrandTotal , printdatetime , deletePO , Complete,CancelPO  ) values ('" + this.lblPOnumber.Content + "','" + this.lblVenderID.Content + "','" + txtSubTotal.Text + "' ,'" + txtDiscount.Text + "' ,'" + txtGrandtotal.Text + "' ,'" + dt + "','" + "0" + "','" + "1" + "','" + "1" + "')";
                    OleDbCommand cmd1 = new OleDbCommand(query1, olecon);
                    cmd1.ExecuteNonQuery();
                    //update stck cancel record
                    OleDbCommand command1 = new OleDbCommand(@"UPDATE ProductStock SET CancellPO = @can WHERE POnumber = @bnum ", olecon);
                    command1.Parameters.AddWithValue("@can", 1);
                    command1.Parameters.AddWithValue("@bnum", lblPOnumber.Content);
                    command1.ExecuteNonQuery();
                    //connection close
                    olecon.Close();
                    clear();
                    createPONumber();
                    combVenderName_DropDownClosed(sender, e);
                    loadGrid();

                }
                catch (Exception es)
                {
                    MessageBox.Show(es.ToString());
                    olecon.Close();
                }
            }
            else
            {
                MessageBox.Show("Must Fill All Forms.");
            }
        }
    }
}
