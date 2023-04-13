using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace abcstore.Forms
{
    public partial class ChangePassword : Form
    {
        public string username { get; set; }

        public ChangePassword()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbx"].ConnectionString);
        private void ChangePassword_Load(object sender, EventArgs e)
        {
            usernametextBox.Text = username;
            passwordtextBox.Focus();

            
            
        }
        private void verifypassword()
        {
            //verify password
            if (usernametextBox.Text == "")
            {
                MessageBox.Show("Please Enter Username");
                return;
            }
            if (passwordtextBox.Text == "")
            {
                MessageBox.Show("Please provide Password.");
                return;
            }
            else
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("Select * from store_users where u_name=@Username and u_password=@password", con);
                    cmd.Parameters.AddWithValue("@Username", usernametextBox.Text);
                    cmd.Parameters.AddWithValue("@password", passwordtextBox.Text);
                    con.Open();
                    SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapt.Fill(ds);
                    int count = ds.Tables[0].Rows.Count;

                    //If count is equal to 1, than show frmMain form
                    if (count == 1)
                    {
                        NewpasswordtextBox.Visible = true;
                        ConfirmPasswordtextBox.Visible = true;
                        label4.Visible = true;
                        label5.Visible = true;
                        label6.Text = "Password Verification Successfull";
                        NewpasswordtextBox.Focus();
                        label7.Visible = true;

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

        private void ConfirmPasswordtextBox_TextChanged(object sender, EventArgs e)
        {
            if (NewpasswordtextBox.Text != "")
            {
                Errorlabel.Text = "";
                if (NewpasswordtextBox.Text != ConfirmPasswordtextBox.Text)
                {

                    Errorlabel.Visible = true;
                    Errorlabel.Text = "Password Never Match";
                }

            }
        }

        private void passwordtextBox_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void passwordtextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                verifypassword();
                

            }
        }

        private void ConfirmPasswordtextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ConfirmPasswordtextBox.Focus();
                changepassword();

            }
        }

        private void changepassword()
        {
            if (NewpasswordtextBox.Text != "" && ConfirmPasswordtextBox.Text != "")
            {
                if (NewpasswordtextBox.Text == ConfirmPasswordtextBox.Text)
                {
                    //update passwrd
                    string sql = null;

                    sql = "update store_users set u_password=@pc where u_name ='" + usernametextBox + "' ";
                    con.Open();
                    SqlCommand command = new SqlCommand(sql, con);
                    command.Parameters.AddWithValue("@pc", NewpasswordtextBox.Text);
                    
                   
                    command.ExecuteNonQuery();
                    con.Close();

                   
                }
            }
        }

        private void NewpasswordtextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ConfirmPasswordtextBox.Focus();


            }
        }
    }
}
