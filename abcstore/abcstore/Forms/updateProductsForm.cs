using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace abcstore.Forms
{
    public partial class UpdateProductsForm : Form
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbx"].ConnectionString);
        //string ResultRadiobutton;
        public int DeleteFm { get; set; }
        string disablYN;
        public UpdateProductsForm()
        {
            InitializeComponent();
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
                productcodetextBox.Text = srfm.Sscode;
                productnametextBox.Text = srfm.Ssname;
                producttypetextBox.Text = srfm.Sstype;
                productsizetextBox.Text = srfm.Sssize;
                productpricetextBox.Text = srfm.Ssprice;
                productdetailtextBox.Text = srfm.Ssdetail;
                
                if (srfm.Stukmess == "Mess")
                {
                    messradioButton.Checked = true;
                }
                else
                {
                    tukshopradioButton.Checked = true;
                }
                
            }
            if (e.KeyCode == Keys.Tab)
            {
                productnametextBox.Focus();
            }
        }

        public void Clear()
        {
            productnametextBox.Text = "";
            producttypetextBox.Text = "";
            productdetailtextBox.Text = "";
            productpricetextBox.Text = "";
            productsizetextBox.Text = "";

        }

        private void updateproductbutton_Click(object sender, EventArgs e)
        {
            string yy = "N";
            try
            {
                if (productnametextBox.Text != "" && productpricetextBox.Text != "" && producttypetextBox.Text != "" &&
                    productsizetextBox.Text != "" && productdetailtextBox.Text != "" && productcodetextBox.Text != "")
                {
                    string sql = "update store_product set p_name=@pn, p_type=@pt, p_size=@ps ,p_price=@pp , p_detail=@pd,Disable= @dis  where p_code='" + productcodetextBox.Text + "' ";
                    con.Open();
                    SqlCommand command = new SqlCommand(sql, con);
                   
                    command.Parameters.AddWithValue("@pn", productnametextBox.Text);
                    command.Parameters.AddWithValue("@pt", producttypetextBox.Text);
                    command.Parameters.AddWithValue("@ps", productsizetextBox.Text);
                    command.Parameters.AddWithValue("@pp", productpricetextBox.Text);
                    command.Parameters.AddWithValue("@pd", productdetailtextBox.Text);
                    command.Parameters.AddWithValue("@dis", yy);
                    command.ExecuteNonQuery();




                    con.Close();
                    MessageBox.Show("Record Update.");
                    Clear();
                    

                    productnametextBox.Focus();
                }
                else
                {
                    MessageBox.Show("Fill complete records.");
                    productnametextBox.Focus();
                }

            }
            catch (Exception ds)
            {

                MessageBox.Show("Error on save user:" + ds);
            }
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void UpdateProductsForm_Load(object sender, EventArgs e)
        {
            if (DeleteFm == 1)
            {
                updateproductbutton.Visible = false;
                Deletebutton.Visible = true;
                label7.Text = "Delete Product Form";

            }

        }

        private void messradioButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tukshopradioButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void productcodetextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (productcodetextBox.Text != "")
                {
                    string yy = "N";
                    string querry = ("select p_name,p_type,p_price,p_size,p_TuckMess,p_detail,Disable from store_product where Disable= '"+yy+"' and p_code = '" + productcodetextBox.Text + "' ");
                    SqlCommand cmdd = new SqlCommand(querry, con);
                    con.Open();

                    var dbr = cmdd.ExecuteReader();
                    while (dbr.Read())
                    {
                        
                        productnametextBox.Text = (string)dbr["p_name"];
                        producttypetextBox.Text = (string)dbr["p_type"];
                        productsizetextBox.Text = (string)dbr["p_size"];
                        productpricetextBox.Text = ((int) (dbr["p_price"])).ToString();
                        int messtuck = (int)dbr["p_TuckMess"];
                        productdetailtextBox.Text = (string)dbr["p_detail"];
                        disablYN = (string)dbr["Disable"];
                        if (messtuck == 0)
                        {
                            tukshopradioButton.Checked = true;
                        }
                        else
                        {
                            messradioButton.Checked = true;
                        }
                        
                    }
                    con.Close();
                }
            }
        }

        private void Deletebutton_Click(object sender, EventArgs e)
        {
            string yy = "Y";
            try
            {
                if (productnametextBox.Text != "" && productpricetextBox.Text != "" && producttypetextBox.Text != "" &&
                    productsizetextBox.Text != "" && productdetailtextBox.Text != "" && productcodetextBox.Text != "")
                {
                    string sql = "update store_product set Disable= @pt   where p_code='" + productcodetextBox.Text + "' ";
                    con.Open();
                    SqlCommand command = new SqlCommand(sql, con);
                    command.Parameters.AddWithValue("@pt", yy);
                    command.Parameters.AddWithValue("@word", productcodetextBox.Text);
                    command.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record Deleted.");
                    Clear();
                    productcodetextBox.Text = "";
                    

                    productnametextBox.Focus();
                }
                else
                {
                    MessageBox.Show("Fill complete records.");
                    productnametextBox.Focus();
                }

            }
            catch (Exception ds)
            {

                MessageBox.Show("Error on save user:" + ds);
            }
        }
    }
}
