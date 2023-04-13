using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using NexusPOS_wpf.Reports;

namespace NexusPOS_wpf
{
    /// <summary>
    /// Interaction logic for W2NewSale.xaml
    /// </summary>
    public partial class W2NewSale : Page
    {
        OleDbConnection olecon = new OleDbConnection(ConfigurationManager.ConnectionStrings["Accdbx"].ConnectionString);
        public int Billnumber { get; set; }

        public W2NewSale()
        {
            InitializeComponent();
        }

        private void SaveItem_Click(object sender, RoutedEventArgs e)
        {
            if (txtTotalAmount.Text != "" && txtTotalAmount.Text != "0" && txtItemDescription.Text!="")
            {
                try
                {

                    olecon.Open();
                    String query1 = "insert into detailbill (billnumber,ItemDescription,SizeWidth,SizeLength,TotalSize,Qty,Rate,Total,LabourCharges,DesignCharges,PositiveCharges,totalamount,DeliveryPromiseDate,Active) values ('" + this.Billnumber + "','" + this.txtItemDescription.Text + "','" + txtSizeWidth.Text + "','" + txtSizeLength.Text + "','" + txtSizetotal.Text + "','" + txtQty.Text + "','" + txtRate.Text + "','" + txtTotal.Text + "','" + txtLabourCharges.Text + "','" + txtDesignCharges.Text + "','" + txtPositiveCharges.Text + "','" + txtTotalAmount.Text + "','" + dtpickerDeliveryDate.SelectedDate + "','" + 0 + "')";
                    OleDbCommand cmd1 = new OleDbCommand(query1, olecon);
                    cmd1.ExecuteNonQuery();
                    olecon.Close();
                    clear();
                    loadGrid();
                    summition();
                    combCustomerName.IsEnabled = false;

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
            //try
            //{

            //    datagridBill.Items.Add(new { DEl = "Delete", Qty = txtQty.Text, des = txtItemDescription.Text, width = txtSizeWidth.Text, length = txtSizeLength.Text, TotalSize = txtSizetotal.Text, rate = txtRate.Text, amount = txtTotal.Text, Labourcharg = txtLabourCharges.Text, DesignCharges = txtDesignCharges.Text, Positivecharges = txtPositiveCharges.Text , DeliveryDate=dtpickerDeliveryDate.SelectedDate , SubTotal = txtTotalAmount.Text });
            //    summition();

            //}
            //catch (Exception es)
            //{
            //    MessageBox.Show(es.ToString());
            //}
        }

        private void loadGrid()
        {
            DataSet ds = new DataSet();
            string getEmpSQL = "SELECT * FROM detailbill where billnumber=" + Billnumber + " and Active=" + 1 + " order by detail_bill_id ";
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
            datagridBill.ItemsSource = ds.Tables[0].DefaultView;
            datagridBill.DisplayMemberPath = ds.Tables[0].Columns[0].ToString();
            txtSubTotal.Text = sum.ToString();
            //combCustomerName.SelectedIndex = 0;
        }

        private void clear()
        {
            txtSizeWidth.Text = "";
            txtSizeLength.Text = "";
            txtItemDescription.Text = "";
            txtQty.Text = "";
            txtRate.Text = "";
            txtLabourCharges.Text = "";
            txtDesignCharges.Text = "";
            txtPositiveCharges.Text = "";
        }

        void summition()
        {
            ////decimal valorAcumulado = 0;
            ////for (int i = 0; i < listViewBill.Items.Count; i++)
            ////{
            ////    valorAcumulado += decimal.Parse((listViewBill .Columns[11].GetCellContent(listViewBill.Items[i]) as TextBlock).Text);
            ////}
            ////string abc=   (datagridBill.Columns[11].GetCellContent(datagridBill.Items[0]) as TextBox).Text;
            //decimal sum = 0m;
            //for (int i = 0; i < datagridBill.Items.Count; i++)
            //{
            //    sum += (decimal.Parse((datagridBill.Columns[11].GetCellContent(datagridBill.Items[i]) as TextBlock).Text));
            //}
            ////decimal sum = 0m;
            ////foreach (DataRow row in datagridBill.Items.Columns[11])
            ////{
            ////    sum += (decimal)row["Total Amount"];
            ////}
            //txtSubTotal.Text = sum.ToString();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            createbillnumber();
            LoadComboCustomerlist();
            dtpickerDeliveryDate.SelectedDate = DateTime.Today;
            loadGrid();
            combCustomerName_DropDownClosed(sender, e);
        }

        private void createbillnumber()
        {
            try
            {
                OleDbDataReader dr;
                olecon.Open();
                string query = "select top 1 billnumber  from mastebill order by billnumber desc";
                OleDbCommand cmd = new OleDbCommand(query, olecon);//Advised to use parameterized query
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    Billnumber = int.Parse(dr.GetValue(0).ToString());
                    Billnumber = Billnumber+ 1;
                }
                else
                {
                    Billnumber = 1;

                }
                dr.Close();
                lblBillnumber.Content = Billnumber.ToString();

                //insert record bill number and table number
                //string pdatetime = DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");
                //string bdate = DateTime.Now.ToString("dd/MM/yyyy");
                //String query1 = "insert into mastebill (table_no,billnumber,billamount,billDiscount,grandTotal,paidamount,change,billingdate,printdatetime,deletebill,[Complete],[Close],WaiterName) values ('" + this.txt_tableNumber.Text + "'," + this.txtBillnumber.Text + ",'" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + bdate + "','" + pdatetime + "',1,0,0,'" + this.combo_Waiters.Text + "')";
                //OleDbCommand cmd1 = new OleDbCommand(query1, olecon);
                //cmd1.ExecuteNonQuery();
                olecon.Close();
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message.ToString());
                return;
            }

        }
        private void LoadComboCustomerlist()
        {
            DataSet ds = new DataSet();
            string getEmpSQL = "SELECT PersonName FROM PersonInfo where PersonType='Customer' and [Active]=" + 1 + " order by Personid ";
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

            combCustomerName.ItemsSource = ds.Tables[0].DefaultView;
            combCustomerName.DisplayMemberPath = ds.Tables[0].Columns[0].ToString();
            combCustomerName.SelectedIndex = 0;

        }

        private void btnAddPerson_Click(object sender, RoutedEventArgs e)
        {
            Window3 w3 = new Window3();
            w3.FormName = "Addpeople";
            w3.ShowDialog();
            LoadComboCustomerlist();
        }

        private void combCustomerName_DropDownClosed(object sender, EventArgs e)
        {
            try
            {
                
               
                //tring sql = "select mobileNumber from PersonInfo where [PersonName]='" + combCustomerName.Text + "' ";
                OleDbDataReader dr;
                if(olecon.State== ConnectionState.Closed)
                {
                    olecon.Open();
                }
                
                string query = "select Personid,mobileNumber from PersonInfo where [PersonName]='" + combCustomerName.Text + "' ";
                OleDbCommand cmd = new OleDbCommand(query, olecon);//Advised to use parameterized query
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    lblCustomerID.Content = (dr.GetValue(0).ToString());
                    txtPhoneCustomer.Text = (dr.GetValue(1).ToString());
                }
                dr.Close();
                Myclass mc = new Myclass();

                lblPreviouseBalance.Content = (mc.findCustomerBalance(int.Parse(lblCustomerID.Content.ToString())));
                txtremainingBalance.Text = (int.Parse(lblPreviouseBalance.Content.ToString()) + (int.Parse(txtremainig.Text.ToString()))).ToString();
                //olecon.Close();
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

        private void txtPhoneCustomer_SelectionChanged(object sender, RoutedEventArgs e)
        {
            combCustomerName_DropDownClosed(sender, e);
        }

        private void txtSizeWidth_TextChanged(object sender, TextChangedEventArgs e)
        {
            findSize();
            findtotal();
            totalamount();
        }

        private void findSize()
        {
            if(txtSizeLength.Text!="" && txtSizeWidth.Text != "")
            {
                txtSizetotal.Text =(float.Parse(txtSizeLength.Text) * float.Parse(txtSizeWidth.Text)).ToString();
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
            if (txtLabourCharges.Text == "")
            {
                txtLabourCharges.Text = "0";
            }
            else if (txtDesignCharges.Text == "")
            {
                txtDesignCharges.Text = "0";
            }
            else if (txtPositiveCharges.Text == "")
            {
                txtPositiveCharges.Text = "0";
            }

            if(txtTotal.Text!="")
            {
               txtTotalAmount.Text = (float.Parse(txtTotal.Text) + float.Parse(txtLabourCharges.Text) + float.Parse(txtDesignCharges.Text) + float.Parse(txtPositiveCharges.Text)).ToString();
            }
        }

        private void txtSizeLength_TextChanged(object sender, TextChangedEventArgs e)
        {
            findSize();
            findtotal();
            totalamount();
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

        private void txtPositiveCharges_TextChanged(object sender, TextChangedEventArgs e)
        {
            findSize();
            findtotal();
            totalamount();
        }

        private void txtDesignCharges_TextChanged(object sender, TextChangedEventArgs e)
        {
            findSize();
            findtotal();
            totalamount();
        }

        private void txtLabourCharges_TextChanged(object sender, TextChangedEventArgs e)
        {
            findSize();
            findtotal();
            totalamount();
        }

        private void btnGenerateBill_Click(object sender, RoutedEventArgs e)
        {
            if (txtSubTotal.Text != "" && txtSubTotal.Text != "0" && datagridBill.Items.Count>=1)
            {
                try
                {
                    string dt = DateTime.Now.ToString("dd-MM-yyyy hh:mm tt");
                    olecon.Open();
                    //String query1 = "insert into mastebill (Personid,billnumber,SubTotal,Discount,GrandTotal,deletebill,Complete,Close) values ('" + this.lblCustomerID.Content + "','" + this.lblBillnumber.Content+ "','" + txtSubTotal.Text + "','" + txtDiscount.Text + "','" + txtGrandtotal.Text + "','" + 0 + "','" + 0 + "','" + 0 + "')";
                    String query1 = " insert into mastebill (billnumber , Personid, PersonName , SubTotal , Discount , GrandTotal , PaidBill, RemainingBalance ,RemainingBill, printdatetime , deletebill , Complete  ) values ('" + this.lblBillnumber.Content+ "','" + this.lblCustomerID.Content + "', '" + this.combCustomerName.Text + "','" + txtSubTotal.Text + "' ,'" + txtDiscount.Text + "' ,'" + txtGrandtotal.Text + "'  ,'" + txtAdvancPaid.Text + "' ,'" + txtremainig.Text + "' ,'" + txtremainingBalance.Text + "','" + dt + "','" + "0" + "','" + "1" + "')";
                    //String query1 = "insert into detailbill (billnumber,ItemDescription,SizeWidth,SizeLength,TotalSize,Qty,Rate,Total,LabourCharges,DesignCharges,PositiveCharges,totalamount,DeliveryPromiseDate,Active) values ('" + this.Billnumber + "','" + this.txtItemDescription.Text + "','" + txtSizeWidth.Text + "','" + txtSizeLength.Text + "','" + txtSizetotal.Text + "','" + txtQty.Text + "','" + txtRate.Text + "','" + txtTotal.Text + "','" + txtLabourCharges.Text + "','" + txtDesignCharges.Text + "','" + txtPositiveCharges.Text + "','" + txtTotalAmount.Text + "','" + dtpickerDeliveryDate.SelectedDate + "','" + 0 + "')";
                    OleDbCommand cmd1 = new OleDbCommand(query1, olecon);
                    cmd1.ExecuteNonQuery();
                     string query2 = " insert into SaleRegister (Personid , billnumber , TotalBill , PaidBill , PaidDate , PaidNotice  ) values ('" + this.lblCustomerID.Content + "','" + this.lblBillnumber.Content + "','" + txtGrandtotal.Text + "' ,'" + txtAdvancPaid.Text + "' ,'" + dt + "' ,'" + "Advance Paid " + "')";
                    OleDbCommand cmd2 = new OleDbCommand(query2, olecon);
                    cmd2.ExecuteNonQuery();
                    //activate bill
                    OleDbCommand command = new OleDbCommand(@"UPDATE detailbill SET Active = @active WHERE billnumber = @bnum ", olecon);
                    command.Parameters.AddWithValue("@active", 1);
                    command.Parameters.AddWithValue("@bnum", lblBillnumber.Content);
                    command.ExecuteNonQuery();
                    if (olecon.State == ConnectionState.Open)
                    {
                        olecon.Close();
                    }
                    //print slip
                    if (ChkboxPrintSlip.IsChecked == true)
                    {
                        BillSlip rep = new BillSlip(Billnumber);
                        rep.Duplication = "";

                        rep.print = 1;
                        rep.Show();
                    }
                    ///////////////
                    clear();
                    createbillnumber();
                    combCustomerName_DropDownClosed(sender,e);
                    loadGrid();
                    combCustomerName.IsEnabled = true;

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

       
        private void txtSizeWidth_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            //base.OnKeyPress(e);
            //if (e.Key != (char)8 && !char.IsNumber(e.KeyChar))
            //{
            //    e.Handled = true;
            //}
        }
        private void findgrantotal()
        {
            if (txtSubTotal.Text != "")
            {
                if (txtDiscount.Text == "")
                {
                    txtDiscount.Text = "0";
                }

                txtGrandtotal.Text = (float.Parse(txtSubTotal.Text) - float.Parse(txtDiscount.Text) ).ToString();
            }
        }
             

        private void txtSubTotal_TextChanged(object sender, TextChangedEventArgs e)
        {
            findgrantotal();
        }

        private void txtDiscount_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtDiscount.Text != "" && txtSubTotal.Text!="")
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
        
        private void txtGrandtotal_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            txtAdvancPaid.Text = txtGrandtotal.Text;
        }

        private void findRemainingPayment()
        {
            if(txtAdvancPaid.Text!="" && int.Parse(txtAdvancPaid.Text) >= 0)
            {
                int remainingbill = (int.Parse(txtGrandtotal.Text) - int.Parse(txtAdvancPaid.Text));
                if (lblPreviouseBalance.Content != null)
                {
                    int remainingbalance = (int.Parse(lblPreviouseBalance.Content.ToString()) + remainingbill);
                    txtremainingBalance.Text = remainingbalance.ToString();
                }
                txtremainig.Text = remainingbill.ToString();
                
            }
        }

        private void txtAdvancPaid_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtAdvancPaid.Text == "")
            {
                txtremainig.Text = "0";
                txtremainingBalance.Text = lblPreviouseBalance.Content.ToString();
            }
            findRemainingPayment();
        }

        private void txtremainig_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(lblPreviouseBalance.Content != null)
            {
                txtremainingBalance.Text = int.Parse(lblPreviouseBalance.Content.ToString() + int.Parse(txtremainig.Text)).ToString();
            }
            
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            LoadComboCustomerlist();
        }

        private void datagridBill_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataRowView dataRow = (DataRowView)datagridBill.SelectedItem;
            //int index = DGListofCustomers.Columns[0].Column.DisplayIndex;
            string cellValue = dataRow.Row.ItemArray[0].ToString();
            try
            {
                olecon.Open();
                OleDbCommand command = new OleDbCommand(@"UPDATE detailbill SET Active = @active WHERE detail_bill_id = @bnum ", olecon);
                command.Parameters.AddWithValue("@active", 0);
                command.Parameters.AddWithValue("@bnum", cellValue);
                command.ExecuteNonQuery();
                if (olecon.State == ConnectionState.Open)
                {
                    olecon.Close();
                }
                loadGrid();
            }
            catch (Exception es)
            {
                MessageBox.Show(es.ToString());
            }
        }


        //private void findbillnumber()
        //{
        //    try
        //    {
        //        //DateTime today = DateTime.Today;
        //        //string tod = today.ToString("dd-MM-yyyy");
        //        DataSet ds;
        //        olecon.Open();
        //        //string sql = "select billnumber from mastebill where [table_no]='" + tablenumber.ToString() + "' and billingdate=#"+ tod +"# and [Complete]=" + '0' + " and [Close]=" + '0' + "  ";
        //        string sql = "select billnumber,billingdate from mastebill where [table_no]='" + tablenumber.ToString() + "' and [Complete]=" + '0' + " and [Close]=" + '0' + "  ";
        //        ds = new DataSet("test");
        //        OleDbDataAdapter DBAdapter = new OleDbDataAdapter();
        //        DBAdapter.SelectCommand = new OleDbCommand(sql, olecon);
        //        //ds.Tables["Table"].Clear();
        //        DBAdapter.Fill(ds);
        //        olecon.Close();
        //        if (ds.Tables["Table"].Rows.Count != 0)
        //        {
        //            txtBillnumber.Text = ds.Tables["Table"].Rows[0]["billnumber"].ToString();
        //            //sdate = ds.Tables["Table"].Rows[0]["billingdate"].ToString();
        //            dateTimePicker1.Value = DateTime.Parse(ds.Tables["Table"].Rows[0]["billingdate"].ToString());
        //            sdate = dateTimePicker1.Value.ToString("dd-MM-yyyy");
        //        }
        //        else
        //        {
        //            createbillnumber();
        //        }
        //    }
        //    catch (Exception es)
        //    {
        //        MessageBox.Show(es.ToString());
        //    }
        //    finally
        //    {
        //        if (olecon.State == ConnectionState.Open)
        //        {
        //            olecon.Close();
        //        }
        //    }

        //}
    }
}
