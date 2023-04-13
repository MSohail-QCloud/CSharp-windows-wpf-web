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
using System.Web.Configuration;

namespace abcstore
{
    public partial class profileform : Form
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbx"].ConnectionString);
        public profileform()
        {
            InitializeComponent();
        }

        public int profiletype { get; set; }
        int inc=0;
        public int openprofilefm { get; set; }
        public int profilecode { get; set; }
        
        public void Clearall()
        {
            nametextBox.Text = "";
            fnametextbox.Text = "";
            mbileno1textbox.Text = "";
            mobileno2textbox.Text = "";
            companyNametextbox.Text = "";
            addtextBox.Text = "";
            emailidtextbox.Text = "";
            citytextbox.Text = "";
            countrytextbox.Text = "";
        }
       

        private void button1_Click(object sender, EventArgs e)
        {
                if (nametextBox.Text != "" && fnametextbox.Text != "" && mbileno1textbox.Text != "" && companyNametextbox.Text != "" && nametextBox.Text != "" && nametextBox.Text != "" && nametextBox.Text != "" && nametextBox.Text != ""  )
                {
                    var sql = "insert into Profile (Pro_code,Pro_name,pro_fname,pro_mno1,pro_mno2,pro_companyname,pro_add,pro_email,pro_city,Pro_country,pro_cv) VALUES ('" + codelabel.Text + "','" +
                                  nametextBox.Text + "','" + fnametextbox.Text + "','" + mbileno1textbox.Text + "','" + mobileno2textbox.Text + "','" + companyNametextbox.Text + "','" + addtextBox.Text + "','" + emailidtextbox.Text + "','" + citytextbox.Text + "','" + countrytextbox.Text + "','" + profilercomboBox.SelectedIndex + "')";
                    con.Open();
                    var command = new SqlCommand(sql, con);
                    var dataReader = command.ExecuteReader();
                    MessageBox.Show("Profile Created");
                    nametextBox.Focus();
                    Clearall();
                    codelabel.Text = inc.ToString();
                    dataReader.Close();
                    command.Dispose();
                    con.Close();
                 }
                else
                {
                    MessageBox.Show("NO Transaction ID is Selected. Contact to Vender.");
                }
       }

        private void companyNametextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void profilercomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void profile_id_generator()
        {
            string querry = ("SELECT top(1) Pro_code from [Profile] order by Pro_code desc");
            SqlCommand cmdd = new SqlCommand(querry, con);
            con.Open();
              var dbr = cmdd.ExecuteReader();
                while (dbr.Read())
                {

                    profilecode = (int)dbr["Pro_code"];
                    codelabel.Text = profilecode.ToString();
                }
            }
        
        private void profileform_Load(object sender, EventArgs e)
        {
            try
            {
                 profilercomboBox.Items.Add("Vender");
                    profilercomboBox.Items.Add("Customer");
                    profilercomboBox.SelectedIndex = profiletype;
                if (openprofilefm == 1)
                {
                    codelabel.Visible = false;
                    ProfileCodetextBox.Visible = true;
                    creatprofilebutton.Visible = false;
                    UpdateProbutton.Visible = true;
                    ProfileCodetextBox.Focus();


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

        private void nametextBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Closebutton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ProfileCodetextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UpdateProbutton.Visible = true;
                string querry = ("select Pro_code,Pro_name,pro_fname,pro_mno1,pro_mno2,pro_companyname,pro_add,pro_email,pro_city,Pro_country,pro_cv from Profile where Pro_code='" + ProfileCodetextBox.Text + "'");
                SqlCommand cmdd = new SqlCommand(querry, con);
                con.Open();
                var dbr = cmdd.ExecuteReader();
                while (dbr.Read())
                {
                    profilecode = (int)dbr["Pro_code"];
                    nametextBox.Text = (string)dbr["Pro_name"];
                    fnametextbox.Text = (string)dbr["pro_fname"];
                    mbileno1textbox.Text = (string)dbr["pro_mno1"];
                    mobileno2textbox.Text = (string)dbr["pro_mno2"];
                    companyNametextbox.Text = (string)dbr["pro_companyname"];
                    addtextBox.Text = (string)dbr["pro_add"];
                    emailidtextbox.Text = (string)dbr["pro_email"];
                    citytextbox.Text = (string)dbr["pro_city"];
                    countrytextbox.Text = (string)dbr["Pro_country"];
                    profilercomboBox.SelectedIndex = (int)dbr["pro_cv"];
                    
                }
                con.Close();
                nametextBox.Focus();
            }
        }

        private void UpdateProbutton_Click(object sender, EventArgs e)
        {
            string sql2 =
                        "update Profile set Pro_name=@n,pro_fname=@f,pro_mno1=@m1,pro_mno2=@m2,pro_companyname=@c,pro_add=@a,pro_email=@e,pro_city=@ci,Pro_country=@co,pro_cv=@cv where Pro_code='" +
                        profilecode + "' ";
            con.Open();
            SqlCommand command2 = new SqlCommand(sql2, con);
            command2.Parameters.AddWithValue("@n", nametextBox.Text);
            command2.Parameters.AddWithValue("@f", fnametextbox.Text);
            command2.Parameters.AddWithValue("@m1", mbileno1textbox.Text);
            command2.Parameters.AddWithValue("@m2", mobileno2textbox.Text);
            command2.Parameters.AddWithValue("@c", companyNametextbox.Text);
            command2.Parameters.AddWithValue("@a", addtextBox.Text); 
            command2.Parameters.AddWithValue("@e", emailidtextbox.Text);
            command2.Parameters.AddWithValue("@ci", citytextbox.Text);
            command2.Parameters.AddWithValue("@co", countrytextbox.Text);
            command2.Parameters.AddWithValue("@cv", profilercomboBox.SelectedIndex);
            command2.ExecuteNonQuery();
            con.Close();
            clear();
        }

        private void clear()
        {
            ProfileCodetextBox.Text = "";
            profilecode = 0;
            nametextBox.Text = "";
            fnametextbox.Text = "";
            mbileno1textbox.Text = "";
            mobileno2textbox.Text = "";
            companyNametextbox.Text = "";
            addtextBox.Text = "";
            emailidtextbox.Text = "";
            citytextbox.Text = "";
            countrytextbox.Text = "";


        }

        private void ProfileCodetextBox_TextChanged(object sender, EventArgs e)
        {
            clear();
        }

        private void nametextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                fnametextbox.Focus();
            }

        }

        private void fnametextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                mbileno1textbox.Focus();
            }
        }

        private void mbileno1textbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                mobileno2textbox.Focus();
            }
        }

        private void mobileno2textbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                companyNametextbox.Focus();
            }
        }

        private void companyNametextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                emailidtextbox.Focus();
            }
        }

        private void emailidtextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                citytextbox.Focus();
            }
        }

        private void citytextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                countrytextbox.Focus();
            }
        }

        private void countrytextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                addtextBox.Focus();
            }
        }

        private void addtextBox_KeyDown(object sender, KeyEventArgs e)
        {
           if (e.KeyCode == Keys.Enter)
            {
                if (openprofilefm == 1)
                {
                    UpdateProbutton.Focus();
                }
                else
                {
                    creatprofilebutton.Focus();
                }
            }
        
        }

        
    }
}
