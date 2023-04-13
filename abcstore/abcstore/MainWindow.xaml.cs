using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using  System.Data.SqlClient;
using  System.Configuration;
using System.Data;
using System.Windows.Forms;
using KeyEventArgs = System.Windows.Input.KeyEventArgs;
using MessageBox = System.Windows.MessageBox;

namespace abcstore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbx"].ConnectionString);

        public MainWindow()
        {
            InitializeComponent();
            
        }
        
        private void loginbtn_Click(object sender, RoutedEventArgs e)
        {
            
        
            if (usernametextbox.Text == "")
            {
                MessageBox.Show("Please Enter Username");
                return;
            }
            if (Passwordtextbox.Password == "")
            {
                MessageBox.Show("Please provide Password.");
                return;
            }
            else
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("Select * from store_users where u_name=@Username and u_password=@password", con);
                    cmd.Parameters.AddWithValue("@Username", usernametextbox.Text);
                    cmd.Parameters.AddWithValue("@password", Passwordtextbox.Password);
                    con.Open();
                    SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapt.Fill(ds);
                    int count = ds.Tables[0].Rows.Count;

                    //If count is equal to 1, than show frmMain form
                    if (count == 1)
                    {
                        if (ds.Tables[0].Rows[0]["u_type"].ToString() == "User")
                        {
                            MainForm mfm = new MainForm {Username = usernametextbox.Text};
                            mfm.ShowDialog();
                            //mfm.Show();
                            Hide();
                        }
                        else if (ds.Tables[0].Rows[0]["u_type"].ToString() == "Manager")
                        {
                           managerform fm = new managerform();
                            fm.Show();
                            Hide();
                        }
                        else if (ds.Tables[0].Rows[0]["u_type"].ToString() == "Owner")
                        {
                           ownerform fm = new ownerform();
                            fm.Show();
                            Hide();
                        }
                        else if (ds.Tables[0].Rows[0]["u_type"].ToString() == "Admin")
                            {
                                adminform fm = new adminform();
                                fm.user = usernametextbox.Text;
                                fm.Show();
                                Hide();
                            }
                            else
                            {
                                MessageBox.Show("Authentication failed.Please contact to service provide.");
                                return;
                            }

                       // String menu = "select * from abc U inner join xyz M on U.MODULEID=M.MODULEID where userId='" + userId + "' AND U.rights='1'";
                       //// OleDbConnection myConnectionmenu = new OleDbConnection(oracleConnection);
                       // SqlCommand myCommandmenu = new SqlCommand(menu, con);
                       // myCommandmenu.Parameters.Add("@p1", SqlDbType.Char, 5).Value = "Test%";
                       // con.Open();
                       // SqlDataAdapter damenu = new SqlDataAdapter(menu, con);
                       // damenu.Fill(ds, "menu");
                       // con.Close();
                       // int i;
                       // MainForm mfm=new MainForm();
                       // mfm.toolStrip1.DropDownItems.Clear();
                       // for (i = 0; i < ds.Tables["menu"].Rows.Count; i++)
                       // {
                       //     string str = ds.Tables["menu"].Rows[i]["MODULEDESC"].ToString();
                       //     ToolStripMenuItem SSMenu = new ToolStripMenuItem(str, null, ChildClick);
                       //     menuStrip1.DropDownItems.Add(SSMenu);
                       //     changePasswordToolStripMenuItem.Visible = true;
                       // }

                    }
                    else
                    {
                        //ErrorLabel.Visibility = Visibility.Visible;
                        //ErrorLabel.Content = "Enter Valid Information.";
                        //ErrorLabel.Visibility =Visibility.Visible;
                        //ErrorLabel.Content = "Please enter correct password";
                    }




                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
            
        }



        private void exitbtn_click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void usernametextbox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void usernametextbox_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    buybutton.Focus();
            //}
        }

        private void Grid_Loaded_1(object sender, RoutedEventArgs e)
        {
            usernametextbox.Focus();
        }
    }
}
