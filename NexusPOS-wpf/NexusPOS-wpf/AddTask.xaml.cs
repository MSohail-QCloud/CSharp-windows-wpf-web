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
    /// Interaction logic for AddTask.xaml
    /// </summary>
    public partial class AddTask : Page
    {
        OleDbConnection olecon = new OleDbConnection(ConfigurationManager.ConnectionStrings["Accdbx"].ConnectionString);
        public int PersonNumber { get; set; }
        public AddTask()
        {
            InitializeComponent();
        }

        private void AddTask1_Loaded(object sender, RoutedEventArgs e)
        {
            dtpickerTagetDate.IsEnabled = false;
            txtWeekday.IsEnabled = false;
            txtMonthday.IsEnabled = false;
            EverydayofWeek.IsChecked = true;
            SpecificDate.IsChecked = true;
            Bill.IsChecked = true;
            
        }

       
        private void SaveTask_Click(object sender, RoutedEventArgs e)
        {
            if (txtTaskDescription.Text != "")
            {

                DateTime dt = DateTime.Today.Date;
                try
                {
                    String query1 = "";

                    if (SpecificDate.IsChecked == true)
                    {
                        if (dtpickerTagetDate.SelectedDate != null)
                        {
                            DateTime targtdate = (DateTime)dtpickerTagetDate.SelectedDate;
                            if (targtdate > dt)
                            {
                                query1 = "insert into Alarms (AlarmDescription,AlarmDate,AlarmPlane,billnumber,POnumber,Personid,[Notification],[Active],[Close]) values ('" + this.txtTaskDescription.Text + "','" + (DateTime)dtpickerTagetDate.SelectedDate + "','" + (int)RemindPlane.specificDateRemind + "','" + txtBillNumber.Text + "','" + txtPONumber.Text + "','" + lblPersonID.Content + "','" + txtNotification.Text + "','" + 1 + "','" + 0 + "')";
                                OleDbCommand cmd1 = new OleDbCommand(query1, olecon);
                                olecon.Open();
                                cmd1.ExecuteNonQuery();
                                olecon.Close();
                                clear();
                            }
                            else
                            {
                                MessageBox.Show("Please select date in coming days. ");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please select a date.");
                        }


                    }
                    else if (EverydayofWeek.IsChecked == true)
                    {
                        if (txtWeekday.SelectedIndex > 0)
                        {
                            query1 = "insert into Alarms (AlarmDescription,AlarmPlane,AlarmWeekDay,billnumber,POnumber,Personid,[Notification],[Active],[Close]) values ('" + this.txtTaskDescription.Text + "','" + (int)RemindPlane.WeekofDayRemind + "','" + txtWeekday.Text + "','" + txtBillNumber.Text + "','" + txtPONumber.Text + "','" + lblPersonID.Content + "','" + txtNotification.Text + "','" + 1 + "','" + 0 + "')";
                            OleDbCommand cmd1 = new OleDbCommand(query1, olecon);
                            olecon.Open();
                            cmd1.ExecuteNonQuery();
                            olecon.Close();
                            clear();
                        }
                        else
                        {
                            MessageBox.Show("Please Select a day to remind.");
                        }

                    }
                    else if (Monthly.IsChecked == true)
                    {
                        if (txtMonthday.SelectedIndex > 0)
                        {
                            query1 = "insert into Alarms (AlarmDescription,AlarmPlane,AlarmMonthly,billnumber,POnumber,Personid,[Notification],[Active],[Close]) values ('" + this.txtTaskDescription.Text + "','" + txtMonthday.Text + "','" + txtBillNumber.Text + "','" + txtPONumber.Text + "','" + lblPersonID.Content + "','" + txtNotification.Text + "','" + 1 + "','" + 0 + "')";
                            OleDbCommand cmd1 = new OleDbCommand(query1, olecon);
                            olecon.Open();
                            cmd1.ExecuteNonQuery();
                            olecon.Close();
                            clear();
                        }
                        else
                        {
                            MessageBox.Show("Please Select Month for Reminder.");
                        }

                    }
                    else
                    {
                        MessageBox.Show("No Remind plan is Selected.");
                    }
                }
                catch (Exception es)
                {
                    MessageBox.Show(es.ToString());
                    olecon.Close();
                }
            }
            //else
            //{
            //    MessageBox.Show("Date Must be Greater then Today.");
            //}

            //}
            else
            {
                MessageBox.Show("Must Enter Description.");
            }
        }

        private void clear()
        {
            txtTaskDescription.Text = "";
            txtNotification.Text = "";
            txtBillNumber.Text = "";
            txtPONumber.Text = "";
        }

        private void SpecificDate_Checked(object sender, RoutedEventArgs e)
        {
            dtpickerTagetDate.IsEnabled = true;
            txtWeekday.IsEnabled = false;
            txtMonthday.IsEnabled = false;
        }

        private void Monthly_Checked(object sender, RoutedEventArgs e)
        {
            dtpickerTagetDate.IsEnabled = false;
            txtWeekday.IsEnabled = false;
            txtMonthday.IsEnabled = true;
        }

        private void EverydayofWeek_Checked(object sender, RoutedEventArgs e)
        {
            dtpickerTagetDate.IsEnabled = false;
            txtWeekday.IsEnabled = true;
            txtMonthday.IsEnabled = false;
        }

        private void LoadComboCustomerlist()
        {
            DataSet ds = new DataSet();
            string getEmpSQL = "SELECT PersonName FROM PersonInfo where PersonType='"+PersonType+"' and [Active]=" + 1 + " order by Personid ";
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

            txtCustomerNAME.ItemsSource = ds.Tables[0].DefaultView;
            txtCustomerNAME.DisplayMemberPath = ds.Tables[0].Columns[0].ToString();
            txtCustomerNAME.SelectedIndex = 0;

        }
        string PersonType = "";
        private void Bill_Checked(object sender, RoutedEventArgs e)
        {
            txtBillNumber.IsEnabled = true;
            txtPONumber.IsEnabled = false;
            txtPONumber.Text = "0";
            PersonType = "Customer";
            LoadComboCustomerlist();
        }

        private void PurchaseOrder_Checked(object sender, RoutedEventArgs e)
        {
            txtBillNumber.IsEnabled = false;
            txtPONumber.IsEnabled = true;
            txtBillNumber.Text = "0";
            PersonType = "Vender";
            LoadComboCustomerlist();
        }

        private void txtBillNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void txtPONumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void txtCustomerNAME_DropDownClosed(object sender, EventArgs e)
        {
            try
            {


                //tring sql = "select mobileNumber from PersonInfo where [PersonName]='" + combCustomerName.Text + "' ";
                OleDbDataReader dr;
                if (olecon.State == ConnectionState.Closed)
                {
                    olecon.Open();
                }

                string query = "select Personid,mobileNumber from PersonInfo where [PersonName]='" + txtCustomerNAME.Text + "' ";
                OleDbCommand cmd = new OleDbCommand(query, olecon);//Advised to use parameterized query
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    lblPersonID.Content = (dr.GetValue(0).ToString());
                    lblphonePerson.Content = (dr.GetValue(1).ToString());
                }
                dr.Close();
                Myclass mc = new Myclass();

                lblBalancePerson.Content = (mc.findCustomerBalance(int.Parse(lblPersonID.Content.ToString())));
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

        private void txtCustomerNAME_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtCustomerNAME_DropDownClosed(sender, e);
        }
    }
}
