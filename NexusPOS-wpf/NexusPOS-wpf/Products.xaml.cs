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
    /// Interaction logic for Products.xaml
    /// </summary>
    public partial class Products : Page
    {
        OleDbConnection olecon = new OleDbConnection(ConfigurationManager.ConnectionStrings["Accdbx"].ConnectionString);

        public Products()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            loadGridListofProducts();
            MenuEdit.IsEnabled = false;
            MenuDelete.IsEnabled = false;

        }

        private void MenuDisableProduct_Click(object sender, RoutedEventArgs e)
        {
            DataSet ds = new DataSet();
            string getEmpSQL = "SELECT * FROM ProductsInfo where Active= " + 0 + "  order by ProductID desc ";
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
            DGListofProducts.ItemsSource = ds.Tables[0].DefaultView;
            DGListofProducts.DisplayMemberPath = ds.Tables[0].Columns[0].ToString();
        }

        private void MenuExpiry_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuLabel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuStock_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuDelete_Click(object sender, RoutedEventArgs e)
        {
            DataRowView dataRow = (DataRowView)DGListofProducts.SelectedItem;
            //int index = DGListofCustomers.Columns[0].Column.DisplayIndex;
            string cellValue = dataRow.Row.ItemArray[0].ToString();
            try
            {
                olecon.Open();
                OleDbCommand command = new OleDbCommand(@"UPDATE ProductsInfo SET Active = @active WHERE ProductID = @bnum ", olecon);
                command.Parameters.AddWithValue("@active", 0);
                command.Parameters.AddWithValue("@bnum", cellValue);
                command.ExecuteNonQuery();
                if (olecon.State == ConnectionState.Open)
                {
                    olecon.Close();
                }
                loadGridListofProducts();
                MenuEdit.IsEnabled = false;
                MenuDelete.IsEnabled = false;
            }
            catch (Exception es)
            {
                MessageBox.Show(es.ToString());
            }
        }

        private void MenuEdit_Click(object sender, RoutedEventArgs e)
        {
            DataRowView dataRow = (DataRowView)DGListofProducts.SelectedItem;
            string cellValue = dataRow.Row.ItemArray[0].ToString();
            Window3 w3 = new Window3();
            //w3.FormName = "Updatepeople";
            //w3.PerosonID = int.Parse(cellValue);
            w3.ShowDialog();
        }

        private void MenuAdd_Click(object sender, RoutedEventArgs e)
        {
            Window3 w2 = new Window3();
            w2.FormName = "Add_Products";
            w2.ShowDialog();
            //Page_Loaded(sender, e);
        }

        private void loadGridListofProducts()
        {
            DataSet ds = new DataSet();
            string getEmpSQL = "SELECT * FROM ProductsInfo where Active= " + 1 + " order by ProductID desc ";
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
            DGListofProducts.ItemsSource = ds.Tables[0].DefaultView;
            DGListofProducts.DisplayMemberPath = ds.Tables[0].Columns[0].ToString();

        }

        private void MenuAddSupplier_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuEditSupplier_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuDeletesupplier_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuDeletePrint_Click(object sender, RoutedEventArgs e)
        {

        }

        private void menuNewInventory_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuEditInventory_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuDeleteInventory_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuStockInventory_Click(object sender, RoutedEventArgs e)
        {

        }

        private void menuSaveInventory_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DGListofProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MenuEdit.IsEnabled = true;
            MenuDelete.IsEnabled = true;
        }

        private void MenuActive_Click(object sender, RoutedEventArgs e)
        {
            DataSet ds = new DataSet();
            string getEmpSQL = "SELECT * FROM ProductsInfo where Active= " + 1 + "  order by ProductID desc ";
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
            DGListofProducts.ItemsSource = ds.Tables[0].DefaultView;
            DGListofProducts.DisplayMemberPath = ds.Tables[0].Columns[0].ToString();
        }

        private void MenushowAllProduct_Click(object sender, RoutedEventArgs e)
        {
            DataSet ds = new DataSet();
            string getEmpSQL = "SELECT * FROM ProductsInfo order by ProductID desc ";
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
            DGListofProducts.ItemsSource = ds.Tables[0].DefaultView;
            DGListofProducts.DisplayMemberPath = ds.Tables[0].Columns[0].ToString();
        }
    }
}
