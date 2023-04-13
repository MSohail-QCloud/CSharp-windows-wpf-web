using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace lasticecream
{
    public partial class admin : Form
    {
        OleDbConnection olecon = new OleDbConnection(ConfigurationManager.ConnectionStrings["Accdbx"].ToString());
        private static admin alreadyOpened = null;
        public admin()
        {
            if (alreadyOpened != null && !alreadyOpened.IsDisposed)
            {
                alreadyOpened.Focus();            // Bring the old one to top
                Shown += (s, e) => this.Close();  // and destroy the new one.
                return;
            }

            // Otherwise store this one as reference
            alreadyOpened = this;

            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_active_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Activation Starting";
            btn_active.Enabled = false;
            string sysname = systeminformation.GetComputerName();
            string sid = systeminformation.GetProcessorId();
            string mac = systeminformation.GetMACAddress();
            DateTime sdate = DateTime.Now;
            DateTime ldate = DateTime.Now.AddDays(15);

            String query = "insert into systeminformation (SystemName,systemId,systemMac,Startingdate,expirydate) values ('" + sysname + "','" + sid + "','" + mac + "','" + sdate + "','" + ldate + "')";
            try
            {
                olecon.Open();
                OleDbCommand cmd = new OleDbCommand(query, olecon);
                cmd.ExecuteNonQuery();
                olecon.Close();
                textBox1.Text = textBox1.Text + "/n" + "Trial Activated Successfully.";


            }
            catch (Exception es)
            {
                textBox1.Text = textBox1.Text + "/n" + es;
                olecon.Close();
                btn_active.Enabled = true;
            }

        }

        private void admin_Load(object sender, EventArgs e)
        {
            try
            {
                string sql = "Select * from systeminformation";
                olecon.Open();
                OleDbCommand oledbCmd = new OleDbCommand(sql, olecon);
                OleDbDataReader oledbReader = oledbCmd.ExecuteReader();
                while (oledbReader.Read())
                {
                    btn_active.Enabled = false;
                    textBox1.Text = "Your Application is Already Active.";
                }

                oledbReader.Close();
                oledbCmd.Dispose();
                olecon.Close();
            }
            catch (Exception ex)
            {
                textBox1.Text = ex.ToString();
                olecon.Close();
            }

            loadbioinfo();
        }
        private void loadbioinfo()
        {
            try
            {
                string sql = "Select * from bioinfo";
                olecon.Open();
                OleDbCommand oledbCmd = new OleDbCommand(sql, olecon);
                OleDbDataReader oledbReader = oledbCmd.ExecuteReader();
                while (oledbReader.Read())
                {
                    txt_title.Text = oledbReader["Title"].ToString();
                    txt_phone.Text = oledbReader["Phonenumber"].ToString();
                    txt_welcomnote.Text = oledbReader["message"].ToString();
                }

                oledbReader.Close();
                oledbCmd.Dispose();
                olecon.Close();
            }
            catch (Exception ex)
            {
                textBox1.Text = ex.ToString();
                olecon.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbCommand command = new OleDbCommand(@"UPDATE bioinfo  SET Title = @titl, Phonenumber = @phon, message=@msg WHERE BioID =@CID ", olecon);

            command.Parameters.AddWithValue("@titl", txt_title.Text);
            command.Parameters.AddWithValue("@phon", txt_phone.Text);
            command.Parameters.AddWithValue("@msg", txt_welcomnote.Text);
            command.Parameters.AddWithValue("@CID", '1');

            try
            {
                olecon.Open();
                command.ExecuteNonQuery();
                olecon.Close();
                MessageBox.Show("DATA UPDATED");
                loadbioinfo();
            }
            catch (Exception expe)
            {
                MessageBox.Show(expe.ToString());
                olecon.Close();
            }
        }
    }
}
