using System;
using System.Collections.Generic;
using System.Configuration;
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
    /// Interaction logic for AddProducts.xaml
    /// </summary>
    public partial class AddProducts : Page
    {
        OleDbConnection olecon = new OleDbConnection(ConfigurationManager.ConnectionStrings["Accdbx"].ConnectionString);
        public int ProductID { get; set; }
        public AddProducts()
        {
            InitializeComponent();
        }

        private void SaveProduct_Click(object sender, RoutedEventArgs e)
        {
            if (txtItemDescription.Text != "" && txtCatogory.SelectedIndex >= 0)
            {
                try
                {

                    olecon.Open();
                    String query1 = "insert into ProductsInfo (ProductID,ProductDescription,Catagory,BrandName,SizeWidth,SizeLength,NetWeight,GrossWeight,SalesPrice,Cost,StockLevelMin,StockLevelMax,UnitUsed,ExpiryDuration,Comment,PackingType,Active) values ('" + this.lblproductId.Content + "','" + this.txtItemDescription.Text + "','" + this.txtCatogory.Text + "','" + txtbrandName.Text + "','" + txtSizeWidth.Text + "','" + txtSizeLength.Text + "','" + txtNetWeight.Text + "','" + txtGrossWeight.Text + "','" + txtSalePrice.Text + "','" + txtCost.Text + "','" + txtStockMinimum.Text + "','" + txtStockMaximum.Text + "','" + comboUnit.Text + "','" + txtExpiryDuration.Text + "','" + txtComment.Text + "','" + PackagingType + "','" + 1 + "')";
                    OleDbCommand cmd1 = new OleDbCommand(query1, olecon);
                    cmd1.ExecuteNonQuery();
                    olecon.Close();
                    clear();
                    CreateProductID();

                    //createPersonNumber();


                }
                catch (Exception es)
                {
                    MessageBox.Show(es.ToString());
                    olecon.Close();
                }
            }
            else
            {
                MessageBox.Show("Must Enter Item description.");
            }
        }
        private void clear()
        {
            txtItemDescription.Text = "";
            txtNetWeight.Text = "";
            txtGrossWeight.Text = "";
            txtSalePrice.Text = "";
            txtCost.Text = "";
            txtStockMaximum.Text = "";
            txtStockMinimum.Text = "";
            txtComment.Text = "";
        }

        private void CreateProductID()
        {
            try
            {
                OleDbDataReader dr;
                olecon.Open();
                string query = "select top 1 ProductID  from ProductsInfo order by ProductID desc";
                OleDbCommand cmd = new OleDbCommand(query, olecon);//Advised to use parameterized query
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    ProductID = int.Parse(dr.GetValue(0).ToString());
                    ProductID = ProductID + 1;
                }
                else
                {
                    ProductID = 1;

                }
                dr.Close();
                lblproductId.Content = ProductID.ToString();


                olecon.Close();
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message.ToString());
                return;
            }

        }

        private void AddProducts1_Loaded(object sender, RoutedEventArgs e)
        {
            CreateProductID();
        }

        string PackagingType = "";
        private void sheetType_Checked(object sender, RoutedEventArgs e)
        {
            PackagingType = "Sheet";
        }

        private void BottleType_Checked(object sender, RoutedEventArgs e)
        {
            PackagingType = "Bottle";
        }

        private void CottonType_Checked(object sender, RoutedEventArgs e)
        {
            PackagingType = "Carton";
        }

        private void BageType_Checked(object sender, RoutedEventArgs e)
        {
            PackagingType = "Bag";
        }
    }
}
