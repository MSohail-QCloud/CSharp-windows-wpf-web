using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
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

namespace NexusPOS_wpf
{
    /// <summary>
    /// Interaction logic for AccountsPayable.xaml
    /// </summary>
    public partial class AccountsPayable : Page
    {
        OleDbConnection olecon = new OleDbConnection(ConfigurationManager.ConnectionStrings["Accdbx"].ConnectionString);

        public AccountsPayable()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            loadGrid();
            DeleteExpense.IsEnabled = false;
            AddExpense.IsEnabled = false;

            MenuWriteoff.Visibility = Visibility.Hidden;
            MenuPrint.Visibility = Visibility.Hidden;
            MenuSave.Visibility = Visibility.Hidden;
            btnPurchaePaid.Visibility = Visibility.Hidden;
            btnPurchaeRecent.Visibility = Visibility.Hidden;
            btnPurchaeUnpaid.Visibility = Visibility.Hidden;
        }

        private void MenuAddPurchase_Click(object sender, RoutedEventArgs e)
        {
            Window2 w2 = new Window2();
            w2.FormName = "New_Purchase";
            w2.ShowDialog();
            Page_Loaded(sender, e);
        }

        private void AddExpense_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SaveExpense_Click(object sender, RoutedEventArgs e)
        {
            if (txtDescriptionExpese.Text != "" && txtAmount.Text != "0" && txtAmount.Text != "")
            {
                try
                {
                    string dt = DateTime.Now.ToString("dd-MM-yyyy hh:mm tt");
                    olecon.Open();
                    String query1 = "insert into MyExpenses (ExpenseDescription,PaidAmount ,ExpenseDate,ExpenseofMonth,ExpenseEnterOn,Active) values ('" + this.txtDescriptionExpese.Text + "','" + this.txtAmount.Text+ "','" + dtpickerExpensePaidDate.SelectedDate + "','" + ComboSelectMonth.Text + "','" + dt + "','" + 1 + "')";
                    OleDbCommand cmd1 = new OleDbCommand(query1, olecon);
                    cmd1.ExecuteNonQuery();
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

        private void clear()
        {
            txtAmount.Text = "";
            txtDescriptionExpese.Text = "";
        }

        private void loadGrid()
        {
            DataSet ds = new DataSet();
            string getEmpSQL = "SELECT * from MyExpenses where [Active]=1 order by ExpenseID desc ";
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
            //float sum = 0;
            //foreach (DataRow dr in ds.Tables[0].Rows)
            //{
            //    sum += float.Parse(dr["totalamount"].ToString());
            //}
            datagridAddExpense.ItemsSource = ds.Tables[0].DefaultView;
            datagridAddExpense.DisplayMemberPath = ds.Tables[0].Columns[0].ToString();
            //txtSubTotal.Text = sum.ToString();
        }

        private void datagridAddExpense_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DeleteExpense.IsEnabled = true;
        }

        private void DeleteExpense_Click(object sender, RoutedEventArgs e)
        {
            DataRowView dataRow = (DataRowView)datagridAddExpense.SelectedItem;
            //int index = DGListofCustomers.Columns[0].Column.DisplayIndex;
            string cellValue = dataRow.Row.ItemArray[0].ToString();
            try
            {
                olecon.Open();
                OleDbCommand command = new OleDbCommand(@"UPDATE MyExpenses SET Active = @active WHERE ExpenseID = @bnum ", olecon);
                command.Parameters.AddWithValue("@active", 0);
                command.Parameters.AddWithValue("@bnum", cellValue);
                command.ExecuteNonQuery();
                if (olecon.State == ConnectionState.Open)
                {
                    olecon.Close();
                }
                loadGrid();
                DeleteExpense.IsEnabled = false;    
            }
            catch (Exception es)
            {
                MessageBox.Show(es.ToString());
            }
        }

        private void datagridPurchase_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TabItem_GotFocus(object sender, RoutedEventArgs e)
        {
            loadPurchaseGrid();
        }

        private void loadPurchaseGrid()
        {
            DataSet ds = new DataSet();
            //q = "select dt.menu_qty,dt.menu_name,dt.menurate,dt.total,dt.detail_bill_id,mb.table_no,mb.billamount,mb.billDiscount,mb.grandTotal,mb.paidamount,mb.change from detailbill dt  inner join mastebill mb on mb.billnumber=dt.masterbill_id where mb.billnumber=" + txt__billnumber.Text + " and mb.deletebill=1";
            string getEmpSQL = "SELECT pr.PurchaseRegisterID, pi.PersonName,pr.POnumber,pr.TotalPO,pr.PaidPO,pr.PaidDate from PurchaseRegister pr inner join PersonInfo pi on pi.Personid=pr.Personid order by PurchaseRegisterID desc ";
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
            //float sum = 0;
            //foreach (DataRow dr in ds.Tables[0].Rows)
            //{
            //    sum += float.Parse(dr["totalamount"].ToString());
            //}
           datagridPurchase.ItemsSource = ds.Tables[0].DefaultView;
            datagridPurchase.DisplayMemberPath = ds.Tables[0].Columns[0].ToString();
            //txtSubTotal.Text = sum.ToString();
        }
    }
}
