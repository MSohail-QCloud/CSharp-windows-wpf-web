using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace abcstore
{
    public partial class ReveiwBillForm : Form
    {
        readonly SqlConnection _con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbx"].ConnectionString);

        public ReveiwBillForm()
        {
            InitializeComponent();
        }
        private void clear()
        {
            label22.Text="";
            label17.Text = "Transaction#";
            label19.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                clear();
                veiwBill();
                Invoicegrid();
                transNotextBox.Text = "";

            }
        }
        private void veiwBill()
        {
            if (transNotextBox.Text != "" )
            {
                try
                {
                    string sql = null;
                    sql = "select * from store_log where l_id= '" + transNotextBox.Text + "'";
                    _con.Open();
                    SqlCommand cmdd = new SqlCommand(sql, _con);
                    var dbr = cmdd.ExecuteReader();
                    while (dbr.Read())
                    {

                        int logid = (int)dbr["l_id"];
                        label17.Text = "Transaction ID:" + logid;

                        DateTime date = (DateTime)dbr["l_datetime"];
                        label19.Text =  date.ToString();

                        textBox4.Text = dbr["l_amount"].ToString();

                        textBox2.Text = dbr["l_paid"].ToString();

                        textBox3.Text = dbr["l_remaining"].ToString();

                        label22.Text = dbr["l_posted"].ToString();
                        

                    }
                    _con.Close();
                    
                    //Sumcal();
                }
                catch(Exception ds)
                {

                    MessageBox.Show("Error On Save Command:" + ds);
                }
                finally
                {
                    _con.Close();

                }
                
               
            }

        }
        private void Invoicegrid()
        {

            var str = "select p.p_name,p.p_size,p.p_price,b.b_qty,b.b_payableam  from store_product p right join store_bill b on  p.p_id=b.p_id where l_id= '" + transNotextBox.Text + "'";
            var com = new SqlCommand(str, _con);
            var ada = new SqlDataAdapter(com);
            var ds = new DataSet();
            ada.Fill(ds, "b_payableam");
            invoicedataGridView.DataMember = "b_payableam";
            invoicedataGridView.DataSource = ds;
            invoicedataGridView.Columns[0].HeaderCell.Value = "Name";
            invoicedataGridView.Columns[1].HeaderCell.Value = "Size";
            invoicedataGridView.Columns[2].HeaderCell.Value = "Rate";
            invoicedataGridView.Columns[3].HeaderCell.Value = "Quantity";
            invoicedataGridView.Columns[4].HeaderCell.Value = "Price";
        }

        private void transNotextBox_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

        private void savprintbutton_Click(object sender, EventArgs e)
        {

        }

        private void cancelbutton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ReveiwBillForm_Load(object sender, EventArgs e)
        {

        }

    }
}
