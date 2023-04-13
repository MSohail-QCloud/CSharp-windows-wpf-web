using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Configuration;

namespace lasticecream
{
    public partial class changepassword : Form
    {
        OleDbConnection olecon = new OleDbConnection(ConfigurationManager.ConnectionStrings["Accdbx"].ToString());
        string role;
        public changepassword(string basicname)
        {
            InitializeComponent();
            role = basicname;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_username.Text != "" && txt_password.Text != "" && txt_retypepassword.Text != "")
            {
                if (txt_password.Text == txt_retypepassword.Text)
                {
                    try
                    {
                        string username = txt_username.Text;
                        string password = txt_password.Text;
                        OleDbCommand olcmd = new OleDbCommand("delete * from user_login where basicname=@id ", olecon);
                        olecon.Open();
                        olcmd.Parameters.AddWithValue("@id", role);
                        olcmd.ExecuteNonQuery();
                        olecon.Close();

                        String query = "insert into user_login ([username],[password],[basicname]) values ('" + txt_username.Text + "','" + txt_password.Text + "','" + role + "');";
                        olecon.Open();
                        OleDbCommand cmd = new OleDbCommand(query, olecon);
                        cmd.ExecuteNonQuery();
                        olecon.Close();
                        MessageBox.Show("Password Updated.");
                    }
                    catch(Exception es)
                    {
                        MessageBox.Show(es.ToString());
                    }
                    }
                else
                {
                    MessageBox.Show("دونوں پاسورڈ ایک جیسے نہیں ہیں۔");
                }
            }
            else
            {
                MessageBox.Show("تبدیل کرنےکیلئے ریکارڈ سلیکٹ کریں۔");
            }
        }

        private void changepassword_Load(object sender, EventArgs e)
        {

        }
    }
}
