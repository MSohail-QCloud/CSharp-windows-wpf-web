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
    /// Interaction logic for Alarms.xaml
    /// </summary>
    public partial class Alarms : Page
    {
        public Alarms()
        {
            InitializeComponent();
        }
        OleDbConnection olecon = new OleDbConnection(ConfigurationManager.ConnectionStrings["Accdbx"].ConnectionString);

        string getEmpSQL;

        private void Alarms1_Loaded(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Alarm Load");
            getEmpSQL = "SELECT * FROM Alarms where [Close]= " + 0 + "  and [Active]= " + 1 + " order by AlarmID desc ";
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
                MessageBox.Show(se.ToString());
            }
            finally
            {
                olecon.Close();
            }
            //float sum = 0;
            //int discount = 0;
            //int total = 0;
            //int paid = 0;
            //int remaining = 0;
            //foreach (DataRow dr in ds.Tables[0].Rows)
            //{
            //    sum += float.Parse(dr["SubTotal"].ToString());
            //    discount += int.Parse(dr["Discount"].ToString());
            //    total += int.Parse(dr["GrandTotal"].ToString());
            //    paid += int.Parse(dr["PaidBill"].ToString());
            //    remaining += int.Parse(dr["RemainingBill"].ToString());
            //}

            datagridBill.ItemsSource = ds.Tables[0].DefaultView;
            datagridBill.DisplayMemberPath = ds.Tables[0].Columns[0].ToString();
            //txtSum.Text = sum.ToString();
            //txtDiscount.Text = discount.ToString();
            //txtTotal.Text = total.ToString();
            //txtPaid.Text = paid.ToString();
            //txtremaining.Text = remaining.ToString();
        }
        private void btnAddTask_Click(object sender, RoutedEventArgs e)
        {
            Window3 w3 = new Window3();
            w3.FormName = "AddTask";
            w3.ShowDialog();
        }

        private void btnDebit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAlarm_Click(object sender, RoutedEventArgs e)
        {

        }

        private void dtto_CalendarOpened(object sender, RoutedEventArgs e)
        {
            checkbxDailysale.IsChecked = false;
        }

        private void dtfrom_CalendarOpened(object sender, RoutedEventArgs e)
        {
            checkbxDailysale.IsChecked = false;

        }

        private void checkbxDailysale_Checked(object sender, RoutedEventArgs e)
        {
            DateTime dt = DateTime.Today;
            dtfrom.SelectedDate = dt;
            dtto.SelectedDate = dt.AddDays(1);
        }

        private void btnExecute_Click(object sender, RoutedEventArgs e)
        {
            //string dtfroms = ((DateTime)dtfrom.SelectedDate).ToString("dd-MM-yyyy");
            //string dttos = ((DateTime)dtto.SelectedDate).ToString("dd-MM-yyyy");

            //getEmpSQL = "SELECT * FROM Alarms where Close= " + 1 + "  and Active= " + 0 + " and printdatetime between #" + dtfroms + "#  and #" + dttos + "#  order by billnumber desc ";

            //loadGridListofBill();
        }

        private void datagridBill_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
