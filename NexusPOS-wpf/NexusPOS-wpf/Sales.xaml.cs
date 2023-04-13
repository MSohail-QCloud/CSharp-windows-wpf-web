using NexusPOS_wpf.Reports;
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
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        OleDbConnection olecon = new OleDbConnection(ConfigurationManager.ConnectionStrings["Accdbx"].ConnectionString);

        public Page1()
        {
            InitializeComponent();
        }

        private void MenuNewSale_Click(object sender, RoutedEventArgs e)
        {

            Window2 w2 = new Window2();
            w2.FormName = "New_Sale";
             w2.ShowDialog();
            Page_Loaded(sender, e);
        }

        private void MenuOrder_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuExchange_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuCancel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuPrintRecipt_Click(object sender, RoutedEventArgs e)
        {
            DataRowView dataRow = (DataRowView)datagridBill.SelectedItem;
            int cellValue = int.Parse( dataRow.Row.ItemArray[0].ToString());
            BillSlip rep = new BillSlip(cellValue);
            rep.Duplication = "Duplicate";

            rep.print = 1;
            rep.Show();
        }
        string getEmpSQL;
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            MenuPrintRecipt.IsEnabled = false;
            MenuExchange.IsEnabled = false;
            getEmpSQL = "SELECT * FROM mastebill where Complete= " + 1 + "  and deletebill= " + 0 + " order by billnumber desc ";

            loadGridListofBill();
            
        }

        private void loadGridListofBill()
        {
            DataSet ds = new DataSet();
            OleDbDataAdapter sda = new OleDbDataAdapter(getEmpSQL, olecon);

            try
            {
                olecon.Open();
                sda.Fill(ds);
            }
            catch (Exception se)
            {
                MessageBox.Show( se.ToString());
            }
            finally
            {
                olecon.Close();
            }
            float sum = 0;
            int discount = 0;
            int total = 0;
            int paid = 0;
            int remaining = 0;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                sum += float.Parse(dr["SubTotal"].ToString());
                discount += int.Parse(dr["Discount"].ToString());
                total += int.Parse(dr["GrandTotal"].ToString());
                paid += int.Parse(dr["PaidBill"].ToString());
                remaining += int.Parse(dr["RemainingBill"].ToString());
            }

            datagridBill.ItemsSource = ds.Tables[0].DefaultView;
            datagridBill.DisplayMemberPath = ds.Tables[0].Columns[0].ToString();
            txtSum.Text = sum.ToString();
            txtDiscount.Text = discount.ToString();
            txtTotal.Text = total.ToString();
            txtPaid.Text = paid.ToString();
            txtremaining.Text = remaining.ToString();
        }

        private void checkbxDailysale_Checked(object sender, RoutedEventArgs e)
        {
            DateTime dt = DateTime.Today;
            dtfrom.SelectedDate = dt;
            dtto.SelectedDate = dt.AddDays(1);
        }

        private void dtfrom_CalendarOpened(object sender, RoutedEventArgs e)
        {
            checkbxDailysale.IsChecked = false;
        }

        private void dtto_CalendarOpened(object sender, RoutedEventArgs e)
        {
            checkbxDailysale.IsChecked = false;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string dtfroms = ((DateTime)dtfrom.SelectedDate).ToString("dd-MM-yyyy");
            string dttos = ((DateTime)dtto.SelectedDate).ToString("dd-MM-yyyy");

            getEmpSQL = "SELECT * FROM mastebill where Complete= " + 1 + "  and deletebill= " + 0 + " and printdatetime between #"+ dtfroms +"#  and #"+ dttos +"#  order by billnumber desc ";

            loadGridListofBill();
        }

        private void datagridBill_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MenuPrintRecipt.IsEnabled = true;
            //MenuExchange.IsEnabled = false;
        }

        private void MenuDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to delete Bill and all transactions ?","Confirm Delete", MessageBoxButton.YesNo)==MessageBoxResult.Yes)
            {
                DataRowView dataRow = (DataRowView)datagridBill.SelectedItem;
                string cellValue = dataRow.Row.ItemArray[0].ToString();
                try
                {
                    olecon.Open();
                    {
                        //de active master bill
                        OleDbCommand command = new OleDbCommand(@"UPDATE mastebill SET deletebill = @active WHERE billnumber = @bnum ", olecon);
                        command.Parameters.AddWithValue("@active", 1);
                        command.Parameters.AddWithValue("@bnum", cellValue);
                        command.ExecuteNonQuery();
                    }
                    {
                        //de active detail bill
                        OleDbCommand command = new OleDbCommand(@"UPDATE detailbill SET Active = @active WHERE billnumber = @bnum ", olecon);
                        command.Parameters.AddWithValue("@active", 0);
                        command.Parameters.AddWithValue("@bnum", cellValue);
                        command.ExecuteNonQuery();
                    }
                    {
                        OleDbCommand command = new OleDbCommand(@"UPDATE SaleRegister SET Deleted = @active WHERE billnumber = @bnum ", olecon);
                        command.Parameters.AddWithValue("@active", 1);
                        command.Parameters.AddWithValue("@bnum", cellValue);
                        command.ExecuteNonQuery();
                    }
                    if (olecon.State == ConnectionState.Open)
                    {
                        olecon.Close();
                    }
                    loadGridListofBill();
                }
                catch (Exception es)
                {
                    MessageBox.Show(es.ToString());
                }
            }
        }
    }
}
