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
    /// Interaction logic for UpdatePeople.xaml
    /// </summary>
    public partial class UpdatePeople : Page
    {
        OleDbConnection olecon = new OleDbConnection(ConfigurationManager.ConnectionStrings["Accdbx"].ConnectionString);
        
        public UpdatePeople()
        {
            InitializeComponent();
            this.Loaded += Page1_Loaded;

        }

        private void Page1_Loaded(object sender, RoutedEventArgs e)
        {
            //string val;
            //if (NavigationContext.QueryString.TryGetValue("key1", out val))
            //{
            //    MessageBox.Show(val, "Information", MessageBoxButton.OK);
            //}
        }

        private void Updateinfo_Click(object sender, RoutedEventArgs e)
        {

        }

        public void SearchPerson(int id)
        {
            try
            {
                OleDbDataReader dr;
                olecon.Open();
                string query = "select PersonName,GaurdianName,mobileNumber,Cnic,Address,PersonCity,PersonBuisnessName,PersonAddress,PersonEmail,PersonType,PersonDescription,JoiningDate  from PersonInfo where Personid=" + id + " order by Personid desc";
                OleDbCommand cmd = new OleDbCommand(query, olecon);//Advised to use parameterized query
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtName.Text = (dr.GetValue(0).ToString());
                    txtGaurdian.Text = (dr.GetValue(1).ToString());
                    txtMobilenumber.Text = (dr.GetValue(2).ToString());
                    txtCNIC.Text = (dr.GetValue(3).ToString());
                    txtAddress.Text = (dr.GetValue(4).ToString());
                    txtCity.Text = (dr.GetValue(5).ToString());
                    txtJobBuisnessName.Text = (dr.GetValue(6).ToString());
                    txtBuisnessAddress.Text = (dr.GetValue(7).ToString());
                    txtemail.Text = (dr.GetValue(8).ToString());
                    txtType.SelectedValue = (dr.GetValue(9).ToString());
                    txtDescription.Text = (dr.GetValue(10).ToString());
                    dtpickerJoiningdate.SelectedDate = DateTime.Parse(dr.GetValue(11).ToString());
                }
                
                dr.Close();
                clear();


                olecon.Close();
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message.ToString());
                return;
            }

        }
        private void clear()
        {
            txtName.Text = "";
            txtGaurdian.Text = "";
            txtMobilenumber.Text = "";
            txtemail.Text = "";
            txtCNIC.Text = "";
            txtCity.Text = "";
            txtAddress.Text = "";
            txtJobBuisnessName.Text = "";
            txtDescription.Text = "";
            txtBuisnessAddress.Text = "";
        }

        private void PGUpdatePeople_Loaded(object sender, RoutedEventArgs e)
        {
            //Window3 w3 = new Window3();
            //SearchPerson(w3.PerosonID);
        }
    }
}
