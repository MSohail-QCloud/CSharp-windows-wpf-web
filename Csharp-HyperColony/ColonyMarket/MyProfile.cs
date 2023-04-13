using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ColonyMarket.classes;
using Application = System.Windows.Application;
using MessageBox = System.Windows.MessageBox;

namespace ColonyMarket
{
    public partial class MyProfile : Form
    {
        OleDbConnection oleconP = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=appdb.accdb; Jet OLEDB:Database Password=myhyperdb");
        functions f = new functions();
        public MyProfile()
        {
            InitializeComponent();
        }

        private void btnChangeUsername_Click(object sender, EventArgs e)
        {
            if (txtnewusername.Text=="")
            {
                return;
            }
            if (userid==0)
            {
                lblerrormsg.Text = "Please Verify User.";
                return;
            }
            try
            {
                lblerrormsg.Text = "";
                Update("update DBUsers set Username='" + txtnewusername.Text + "'  where UserID=" + userid + " ");
                lblerrormsg.Text = "User Updated.";
            }
            catch (Exception s)
            {
                lblerrormsg.Text = s.Message;
            }
           
        }

        public void Update(string s)
        {
            if (oleconP.State == ConnectionState.Closed)
            {
                oleconP.Open();
            }
            OleDbCommand cmd = new OleDbCommand(s, oleconP);
            cmd.ExecuteNonQuery();
            oleconP.Close();
        }

        private void MyProfile_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtoldpassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtoldusername_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        OleDbCommand cmd = new OleDbCommand();
        DataSet ds;
        int userid = 0;
        private void btnVerify_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "select * from DBUsers where Username='" + txtoldusername.Text.Trim() + "' and Upassword='" + txtoldpassword.Text.Trim() + "'";
                cmd = new OleDbCommand(sql, oleconP);
                oleconP.Open();
                cmd.ExecuteNonQuery();
                OleDbDataAdapter adapt = new OleDbDataAdapter(sql, oleconP);
                ds = new DataSet("test");
                adapt.Fill(ds, "test");
                oleconP.Close();
                if (ds.Tables["test"].Rows.Count == 1)
                {
                    userid =int.Parse(ds.Tables["test"].Rows[0][0].ToString());
                    groupBox1.Enabled = true;
                    txtoldusername.Enabled = false;
                    txtoldpassword.Enabled = false;
                }
                else
                {
                    System.Windows.MessageBox.Show("صحیح یوزر کا انتخاب کریں۔");
                }
            }
            catch (Exception es)
            {
                MessageBox.Show(es.ToString());
                //Application.Current.Shutdown(0);
            }
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            if (txtnewusername.Text == "")
            {
                return;
            }
            if (userid == 0)
            {
                lblerrormsg.Text = "Please Verify User.";
                return;
            }
            try
            {
                lblerrormsg.Text = "";
                //Update("update DBUsers set Username='" + txtnewusername.Text + "'  where UserID=" + userid + " ");
                Update("update DBUsers set Upassword=" + txtnewpassword.Text + "  where UserID=" + userid + " ");

                lblerrormsg.Text = "User Updated.";
            }
            catch (Exception s)
            {
                lblerrormsg.Text = s.Message;
            }

            
           

        }

        private void txtnewpassword_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void txtnewpassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (e.KeyChar != (char)8 && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtnewpassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtnewusername_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lblerrormsg_Click(object sender, EventArgs e)
        {

        }
    }
}
