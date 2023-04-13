using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace abcstore
{
    public  partial class adminform : Form
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbx"].ConnectionString);
        //SqlConnection con = new SqlConnection(@"Data Source=DRYABADI-PC\SQLEXPRESS;Initial Catalog=abcstore;Integrated Security=True");
        //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbx"].ConnectionString);
        SqlCommand cmd;
        //SqlDataAdapter adpt;
        public adminform()
        {
            InitializeComponent();
        }

        public string user { get; set; }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
            MainWindow mw =new MainWindow();
            mw.Show();
        }

        private void save_updatebutton_Click(object sender, EventArgs e)
        {
            try
            {
                if (companynametextBox.Text != "" && companytitletextBox.Text != "" && companydesctextBox.Text != "" &&
                    ownernametextBox.Text != "" && ownernumbertextBox.Text != "" && billnumbertextBox.Text != "" &&
                    addresstextBox.Text != "" && endnotetextBox.Text != "")
                {
                    cmd =
                        new SqlCommand(
                            "update company set c_name=@name,c_title=@title,c_description=@desc,c_ownername=@ownname,c_ownernumber=@ownnumb,c_billnumbers=@billnumb,c_address=@add,c_endnote=@endnote",
                            con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@name", companynametextBox.Text);
                    cmd.Parameters.AddWithValue("@title", companytitletextBox.Text);
                    cmd.Parameters.AddWithValue("@desc", companydesctextBox.Text);
                    cmd.Parameters.AddWithValue("@ownname", ownernametextBox.Text);
                    cmd.Parameters.AddWithValue("@ownnumb", ownernumbertextBox.Text);
                    cmd.Parameters.AddWithValue("@billnumb", billnumbertextBox.Text);
                    cmd.Parameters.AddWithValue("@add", addresstextBox.Text);
                    cmd.Parameters.AddWithValue("@endnote", endnotetextBox.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Updated Successfully");
                    userregtextBox.Focus();


                }
                else
                {
                    MessageBox.Show("Please Enter Records to Update");
                    companynametextBox.Focus();
                }
            }

            catch
                (Exception es)
            {
                MessageBox.Show("Error on Login" + es);

            }
            finally
            {
                con.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (userregtextBox.Text != "" && passwordregtextBox.Text != "")
                {
                    SqlCommand com = new SqlCommand();
                    com.Connection = con;
                    con.Open();
                    com.CommandText = ("INSERT INTO store_users (u_name, u_password, u_type ) VALUES ('" + userregtextBox.Text + "','" +
                                       passwordregtextBox.Text + "','" + usertypecomboBox.Text + "');");
                    com.ExecuteNonQuery();
                    MessageBox.Show("Record Saved.");
                }

            }
            catch (Exception ds)
            {

                MessageBox.Show("Error on save user:" + ds);
            }
            finally
            {
                con.Close();
            }
            
        }

        private void updateuserbutton_Click(object sender, EventArgs e)
        {

        }

        private void adminform_Load(object sender, EventArgs e)
        {
            adminuserlabel.Text = user;
            //combobox type
            usertypecomboBox.Items.Add("Admin");
            usertypecomboBox.Items.Add("Owner");
            usertypecomboBox.Items.Add("Manager");
            usertypecomboBox.Items.Add("User");
            usertypecomboBox.SelectedIndex = 3;


            //select company information 
            string querry = ("select c_id, c_name,c_title,c_description,c_ownername,c_ownernumber,c_billnumbers,c_address,c_endnote from company where c_id=1");
            SqlCommand cmdd = new SqlCommand(querry, con);
            SqlDataReader dbr;
            con.Open();

            try
            {
                dbr = cmdd.ExecuteReader();
                while (dbr.Read())
                {

                    string mch1 = (string)dbr["c_name"];
                    companynametextBox.Text = mch1;
                    string shf1 = (string)dbr["c_title"];
                    companytitletextBox.Text = shf1;
                    string mch2 = (string)dbr["c_description"];
                    companydesctextBox.Text = mch2;
                    string shf2 = (string)dbr["c_ownername"];
                    ownernametextBox.Text = shf2;
                    string mch3 = (string)dbr["c_ownernumber"];
                    ownernumbertextBox.Text = mch3;
                    string shf4 = (string)dbr["c_billnumbers"];
                    billnumbertextBox.Text = shf4;
                    string mch = (string)dbr["c_address"];
                    addresstextBox.Text = mch;
                    string shf = (string)dbr["c_endnote"];
                    endnotetextBox.Text = shf;
                }

            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);

            }

            finally
            {
                con.Close();

            }


        }

        private void companynametextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                companytitletextBox.Focus();
            }
        }

        private void companytitletextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                companydesctextBox.Focus();
            }
        }

        private void companydesctextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ownernametextBox.Focus();
            }
        }

        private void ownernametextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ownernumbertextBox.Focus();
            }
        }

        private void ownernumbertextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                billnumbertextBox.Focus();
            }
        }

        private void billnumbertextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                addresstextBox.Focus();
            }
        }

        private void addresstextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                endnotetextBox.Focus();
            }
        }

        private void endnotetextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                save_updatebutton.Focus();
            }
        }

        private void userregtextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                passwordregtextBox.Focus();
            }
        }

        private void passwordregtextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                usertypecomboBox.Focus();
            }
        }

        private void deleteuserbutton_Click(object sender, EventArgs e)
        {

        }
    }
    
    
}
