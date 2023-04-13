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

namespace abcstore
{
    public partial class ManageRights : Form
    {
         SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbx"].ConnectionString);
         int menu_parent_value;
         int menu_submenu_value;
        public ManageRights()
        {
            InitializeComponent();
        }

        private void ManageRights_Load(object sender, EventArgs e)
        {
            loadUsers();
            loadForms();
        }

        //
        public void loadUsers()
        {
            string str = ("select u_name from store_users");
            var com = new SqlCommand(str, con);
            con.Open();
            SqlDataReader DR = com.ExecuteReader();
            UsercomboBox.Items.Add(" --Select User--");
            UsercomboBox.SelectedIndex = 0;
            while (DR.Read())
            {
                UsercomboBox.Items.Add(DR[0]);
             }
            con.Close();
        }
        //load forms 
        public void loadForms()
        {
            string str = ("select  form_Name from MenuSubmenue");
            var com = new SqlCommand(str, con);
            con.Open();
            SqlDataReader DR = com.ExecuteReader();
            FormcomboBox.Items.Add(" --Select Form--");
            FormcomboBox.SelectedIndex = 0;
            while (DR.Read())
            {
               FormcomboBox.Items.Add(DR[0]);
                
            }
            

            con.Close();
        }

        private void FormcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FormcomboBox.SelectedIndex != 0)
            {
                slectform();
            }
        }

        
        private void slectform()
        {
            
            //po number generate
            string q = " select menue_submenue_code,Manu_Par_value,form_Name from MenuSubmenue where form_Name='"+ FormcomboBox.SelectedItem +"'";
            SqlCommand cmdd = new SqlCommand(q, con);
            con.Open();
            var dbr = cmdd.ExecuteReader();
            while (dbr.Read())
            {
                
                menu_parent_value = (int)dbr["Manu_Par_value"];
                menu_submenu_value = (int)dbr["menue_submenue_code"];
             }
            formNOlabel.Text = menu_submenu_value.ToString();
            dbr.Close();
            con.Close();
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void UsercomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (UsercomboBox.SelectedIndex != 0)
            {
                rightsgrid();
            }
        }
        private void rightsgrid()
        {

            var str = "select r.u_name, msm.form_Name from Rights r inner join MenuSubmenue msm on r.menue_submenue_code=msm.menue_submenue_code where r.u_name='"+UsercomboBox.SelectedItem+"' ";
            var com = new SqlCommand(str, con);
            var ada = new SqlDataAdapter(com);
            var ds = new DataSet();
            ada.Fill(ds, "b_payableam");
            rightsdataGridView.DataMember = "b_payableam";
            rightsdataGridView.DataSource = ds;
            rightsdataGridView.Columns[1].HeaderCell.Value = "Forms";
           
        }

        private void addformbutton_Click(object sender, EventArgs e)
        {
            if (UsercomboBox.SelectedIndex !=0 && FormcomboBox.SelectedIndex != 0)
            {
                try
                {
                    int Rights_invisible = 1;
                    string sql1 = null;
                    sql1 = "INSERT INTO Rights (u_name,Manu_Par_value,menue_submenue_code,Rights_invisible ) VALUES ('" + UsercomboBox.SelectedItem +
                           "','" + menu_parent_value + "','" + menu_submenu_value + "','" + Rights_invisible + "')";
                    con.Open();
                    var command1 = new SqlCommand(sql1, con);
                    var dataReader1 = command1.ExecuteReader();
                    dataReader1.Close();
                    command1.Dispose();
                    con.Close();
                    rightsgrid();
                   
                   // Clear();
                }
                catch (Exception ds)
                {

                    MessageBox.Show("Error On Saveing Rights; Rights not saved:" + ds);
                }
            }
        }
    }
}
