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
    /// Interaction logic for AddPeople.xaml
    /// </summary>
    public partial class AddPeople : Page
    {
        OleDbConnection olecon = new OleDbConnection(ConfigurationManager.ConnectionStrings["Accdbx"].ConnectionString);
        public int PersonNumber { get; set; }
        public AddPeople()
        {
            InitializeComponent();
        }

        private void SavePerson_Click(object sender, RoutedEventArgs e)
        {
            if (txtMobilenumber.Text != "" && txtName.Text != "")
            {
                try
                {

                    olecon.Open();
                    String query1 = "insert into PersonInfo (Personid,PersonName,GaurdianName,mobileNumber,Cnic,Address,PersonCity,PersonBuisnessName,PersonAddress,PersonEmail,PersonType,PersonDescription,JoiningDate,Active) values ('" + this.PersonNumber + "','" + this.txtName.Text + "','" + txtGaurdian.Text + "','" + txtMobilenumber.Text + "','" + txtCNIC.Text + "','" + txtAddress.Text + "','" + txtCity.Text + "','" + txtJobBuisnessName.Text + "','" + txtAddress.Text + "','" + txtemail.Text + "','" + txtType.Text + "','" + txtDescription.Text + "','" + dtpickerJoiningdate.SelectedDate + "','" + 1 + "')";
                    OleDbCommand cmd1 = new OleDbCommand(query1, olecon);
                    cmd1.ExecuteNonQuery();
                    olecon.Close();
                    clear();
                    createPersonNumber();

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
                MessageBox.Show("Must Enter Mobile Number and Name.");
            }

            //Application.Current.Windows[0].Close();
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
        private void createPersonNumber()
        {
            try
            {
                OleDbDataReader dr;
                olecon.Open();
                string query = "select top 1 Personid  from PersonInfo order by Personid desc";
                OleDbCommand cmd = new OleDbCommand(query, olecon);//Advised to use parameterized query
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    PersonNumber = int.Parse(dr.GetValue(0).ToString());
                    PersonNumber = PersonNumber + 1;
                }
                else
                {
                    PersonNumber = 1;

                }
                dr.Close();
                lblpersonNumber.Content = PersonNumber.ToString();

                
                olecon.Close();
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message.ToString());
                return;
            }

        }

        
        //private void LoadComboCustomerlist()
        //{
        //    DataSet ds = new DataSet();
        //    string getEmpSQL = "SELECT PersonName FROM PersonInfo where PersonType='Customer' and [Active]=" + 1 + " order by Personid ";
        //    OleDbDataAdapter sda = new OleDbDataAdapter(getEmpSQL, olecon);

        //    try
        //    {
        //        olecon.Open();
        //        sda.Fill(ds);
        //    }
        //    catch (Exception se)
        //    {
        //        MessageBox.Show("An error occured while connecting to database" + se.ToString());
        //    }
        //    finally
        //    {
        //        olecon.Close();
        //    }

        //    combCustomerName.ItemsSource = ds.Tables[0].DefaultView;
        //    combCustomerName.DisplayMemberPath = ds.Tables[0].Columns[0].ToString();
        //    combCustomerName.SelectedIndex = 0;

        //}

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            createPersonNumber();
            dtpickerJoiningdate.SelectedDate = DateTime.Today;
        }
    }
}
