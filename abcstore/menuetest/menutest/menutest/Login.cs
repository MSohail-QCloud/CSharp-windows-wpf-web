using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Configuration;

namespace menutest
{
    public partial class Login : Form
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbx"].ConnectionString);
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUid.Text == "")
            {
                MessageBox.Show("Please insert User Name", "Not match", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtUid.Focus();
            }
            else if (txtpassword.Text == "")
            {
                MessageBox.Show("Please  insert Password", "Not match", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtpassword.Focus();
            }
            else
            {
                prosesLogin();
            }
        }

        private Boolean login1(string sUsername, string sPassword)
        {
            //SqlCommand cmd = new SqlCommand(
            //    "Select UID, Password from  tbl_user where u_name=@Username and u_password=@password", con);
            //cmd.Parameters.AddWithValue("@Username", sUsername);
            //cmd.Parameters.AddWithValue("@password", sPassword);
            //con.Open();
            //SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            //DataSet ds = new DataSet();
            //adapt.Fill(ds);
            //int count = ds.Tables[0].Rows.Count;
            //con.Close();
            ////If count is equal to 1, than show frmMain form
            //if (count == 1)
            //{
            //    return true;
            //}
            return true;
            

            ////string SQL = "Select UID, Password from  tbl_User";
            //string SQL = "Select UID, Password from  tbl_user";
            //con.Open();
            //SqlCommand cmd = new SqlCommand(SQL, con);
            //SqlDataReader reader = cmd.ExecuteReader();
            //while (reader.Read())
            //{
            //    if ((sUsername == reader.GetString(0)) && (sPassword == reader.GetString(1)))
            //    {
            //        con.Close();
            //        return true;
            //    }
            //}
            //con.Close();
            //return false;
        }
        private void prosesLogin()
        {
            try
            {
                if (login1(txtUid.Text, txtpassword.Text))
                {
                    FrmParent fp = new FrmParent(this.txtUid.Text);
                    fp.Show();
                   
                    base.Hide();

                }
                else
                {
                    MessageBox.Show("User ID or Password not match", "Not match", MessageBoxButtons.OK, MessageBoxIcon.Hand);

                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("User ID not exist   \n\n " + exception.Message, "Not match", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            finally
                {
                    con.Close();
                }
        }
    }
}
