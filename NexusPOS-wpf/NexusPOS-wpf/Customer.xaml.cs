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
    /// Interaction logic for Customer.xaml
    /// </summary>
    public partial class Customer : Page
    {
        OleDbConnection olecon = new OleDbConnection(ConfigurationManager.ConnectionStrings["Accdbx"].ConnectionString);

        public Customer()
        {
            InitializeComponent();
        }

        private void MenuAddCust_Click(object sender, RoutedEventArgs e)
        {
            Window3 w3 = new Window3();
            w3.FormName = "Addpeople";
            w3.ShowDialog();
            
        }

        private void loadGridListofCustomers()
        {
            DataSet ds = new DataSet();
            string getEmpSQL = "SELECT * FROM PersonInfo where Active= " + 1 + " and PersonType='"+ "Customer" + "' order by Personid desc ";
            OleDbDataAdapter sda = new OleDbDataAdapter(getEmpSQL, olecon);

            try
            {
                olecon.Open();
                sda.Fill(ds);
            }
            catch (Exception se)
            {
                MessageBox.Show(se.ToString());
            }
            finally
            {
                olecon.Close();
            }
            DGListofCustomers.ItemsSource = ds.Tables[0].DefaultView;
            DGListofCustomers.DisplayMemberPath = ds.Tables[0].Columns[0].ToString();

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            loadGridListofCustomers();
            MenuEditCudt.IsEnabled = false;
            MenuDeleteCumstomer.IsEnabled = false;
        }

        private void MenuDeleteCumstomer_Click(object sender, RoutedEventArgs e)
        {
            DataRowView dataRow = (DataRowView)DGListofCustomers.SelectedItem;
            //int index = DGListofCustomers.Columns[0].Column.DisplayIndex;
            string cellValue = dataRow.Row.ItemArray[0].ToString();
            try
            {
                olecon.Open();
                OleDbCommand command = new OleDbCommand(@"UPDATE PersonInfo SET Active = @active WHERE Personid = @bnum ", olecon);
                command.Parameters.AddWithValue("@active", 0);
                command.Parameters.AddWithValue("@bnum", cellValue);
                command.ExecuteNonQuery();
                if (olecon.State == ConnectionState.Open)
                {
                    olecon.Close();
                }
                loadGridListofCustomers();
                MenuEditCudt.IsEnabled = false;
                MenuDeleteCumstomer.IsEnabled = false;
            }
            catch (Exception es)
            {
                MessageBox.Show(es.ToString());
            }
            
        }

        private void DGListofCustomers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MenuDeleteCumstomer.IsEnabled = true;
            MenuEditCudt.IsEnabled = true;
        }

        private void MenuInactiveCust_Click(object sender, RoutedEventArgs e)
        {
            DataSet ds = new DataSet();
            string getEmpSQL = "SELECT * FROM PersonInfo where Active= " + 0 + " and PersonType='" + "Customer" + "' order by Personid desc ";
            OleDbDataAdapter sda = new OleDbDataAdapter(getEmpSQL, olecon);

            try
            {
                olecon.Open();
                sda.Fill(ds);
            }
            catch (Exception se)
            {
                MessageBox.Show(se.ToString());
            }
            finally
            {
                olecon.Close();
            }
            DGListofCustomers.ItemsSource = ds.Tables[0].DefaultView;
            DGListofCustomers.DisplayMemberPath = ds.Tables[0].Columns[0].ToString();
        }
        //Active Customers
        private void MenuStoreCredit_Click(object sender, RoutedEventArgs e)
        {
            DataSet ds = new DataSet();
            string getEmpSQL = "SELECT * FROM PersonInfo where Active= " + 1 + " and PersonType='" + "Customer" + "' order by Personid desc ";
            OleDbDataAdapter sda = new OleDbDataAdapter(getEmpSQL, olecon);

            try
            {
                olecon.Open();
                sda.Fill(ds);
            }
            catch (Exception se)
            {
                MessageBox.Show(se.ToString());
            }
            finally
            {
                olecon.Close();
            }
            DGListofCustomers.ItemsSource = ds.Tables[0].DefaultView;
            DGListofCustomers.DisplayMemberPath = ds.Tables[0].Columns[0].ToString();
        }

        private void MenuShooAllCustomers_Click(object sender, RoutedEventArgs e)
        {
            DataSet ds = new DataSet();
            string getEmpSQL = "SELECT * FROM PersonInfo where  PersonType='" + "Customer" + "' order by Personid desc ";
            OleDbDataAdapter sda = new OleDbDataAdapter(getEmpSQL, olecon);

            try
            {
                olecon.Open();
                sda.Fill(ds);
            }
            catch (Exception se)
            {
                MessageBox.Show(se.ToString());
            }
            finally
            {
                olecon.Close();
            }
            DGListofCustomers.ItemsSource = ds.Tables[0].DefaultView;
            DGListofCustomers.DisplayMemberPath = ds.Tables[0].Columns[0].ToString();
        }

        private void MenuEditCudt_Click(object sender, RoutedEventArgs e)
        {
            DataRowView dataRow = (DataRowView)DGListofCustomers.SelectedItem;
            string cellValue = dataRow.Row.ItemArray[0].ToString();
            Window3 w3 = new Window3();
            w3.FormName = "Updatepeople";
            w3.PerosonID = int.Parse(cellValue);
            w3.ShowDialog();
        }
    }
}
