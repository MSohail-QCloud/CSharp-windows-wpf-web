using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace abcstore
{
    public partial class Stockupdateform : Form
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbx"].ConnectionString);
        SqlCommand cmd;
        //DataTable dt;
        int total = 0;
        public Stockupdateform()
        {
            InitializeComponent();
            
        }

        void clear()
        {
            productnametextBox.Text = "";
            producttypetextBox.Text = "";
            productsizetextBox.Text = "";
            productpricetextBox.Text = "";
            productdetailtextBox.Text = "";
            QtytextBox.Text = "";
            balancetextBox.Text = "";
            totalqtylabel.Text = "";
            productidlabel.Text = "";
        }
        private void button1_Click(object sender, EventArgs e)
        {
           Close();
        }

        private void productnametextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void productnametextBox_KeyDown(object sender, KeyEventArgs e)
        {
           
                if (e.KeyCode == Keys.Enter)
                {
                    searchrecordfm srfm = new searchrecordfm();
                    srfm.ShowDialog();
                    productidlabel.Text = srfm.Sscode;
                    productnametextBox.Text = srfm.Ssname;
                    producttypetextBox.Text = srfm.Sstype;
                    productsizetextBox.Text = srfm.Sssize;
                    productpricetextBox.Text = srfm.Ssprice;
                    productdetailtextBox.Text = srfm.Ssdetail;
                    QtytextBox.Focus();
                }
                else if (e.KeyCode == Keys.Tab)
                {
                    productnametextBox.Focus();
                }
            
        }

        private void Stockupdateform_Load(object sender, EventArgs e)
        {
            productnametextBox.Focus();
        }

        private void addproductbutton_Click(object sender, EventArgs e)
        {
            try
            {
                //objConn = new SqlConnection(strConnection);
                con.Open();


                string sql1 = "select * from store_stock where  p_id='" + productidlabel.Text + "' ";
                //SqlCommand cmd;
                cmd = new SqlCommand(sql1, con);
                object result = cmd.ExecuteScalar();
                string sql = null;

                if (result == null)
                {
                    sql = "insert into store_stock (p_id, quantity) values('" + productidlabel.Text + "' ,'" + total + "' )";
                }
                else
                {
                    sql = "update store_stock set quantity='" + totalqtylabel.Text + "' where p_id='" + productidlabel.Text + "'";
                }

                var command = new SqlCommand(sql, con);
                var dataReader = command.ExecuteReader();
                dataReader.Close();
                command.Dispose();
                
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
            finally
            {
                con.Close();
                clear();
            }

        }

        private void productidlabel_Click(object sender, EventArgs e)
        {

        }

        private void productidlabel_TextChanged(object sender, EventArgs e)
        {
            if(productnametextBox.Text=="")
            {
                if (productidlabel.Text != "ID")
                {
                        string sql = null;
                        sql = "select quantity from store_stock where p_id= '" + productidlabel.Text + "'";
                        con.Open();
                        SqlCommand cmdd = new SqlCommand(sql, con);
                        var dbr = cmdd.ExecuteReader();
                        while (dbr.Read())
                        {

                            string logid = dbr["quantity"].ToString();
                            balancetextBox.Text = logid;

                        }
                        con.Close();
                    }
                }
        }

        private void QtytextBox_TextChanged(object sender, EventArgs e)
        {
            if (QtytextBox.Text != "")
            {
                if (balancetextBox.Text == "")
                {
                     total = Convert.ToInt32(QtytextBox.Text);
                }
                else
                {
                     total =Convert.ToInt32(balancetextBox.Text) + Convert.ToInt32(QtytextBox.Text);
                }

               
                totalqtylabel.Text = total.ToString();
            }
        }

        private void QtytextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (e.KeyChar != (char)8 && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
