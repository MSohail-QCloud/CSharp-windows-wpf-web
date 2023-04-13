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
    public partial class addproductform : Form
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbx"].ConnectionString);
        int inc;
        private UrduTextBoxDemo.UrduTextBox urduTextBox1;

        public int ResultRadiobutton { get; set; }
        
        //private Rectangle nametextBoxreRectangle;
        //private Rectangle typetextBoxreRectangle;
        //private Rectangle detailtextBoxreRectangle;
        //private Rectangle pricetextBoxreRectangle;
        //private Rectangle sizetextBoxreRectangle;
        //private Rectangle codetextBoxreRectangle;
        //private Rectangle addproductbuttonRectangle;
        //private Rectangle button1Rectangle;
        //private Rectangle label1Rectangle;
        //private Rectangle label2Rectangle;
        //private Rectangle label3Rectangle;
        //private Rectangle label4Rectangle;
        //private Rectangle label5Rectangle;
        //private Rectangle label66Rectangle;
        //private Size formoriginalsize;

        public addproductform()
        {
            
            InitializeComponent();
            //test
            this.urduTextBox1 = new UrduTextBoxDemo.UrduTextBox();
            this.SuspendLayout();

            this.urduTextBox1.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.urduTextBox1.Location = new System.Drawing.Point(8, 8);
            this.urduTextBox1.Name = "urduTextBox1";
            this.urduTextBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.urduTextBox1.Size = new System.Drawing.Size(280, 32);
            this.urduTextBox1.TabIndex = 0;
            this.urduTextBox1.Text = "urduTextBox1";
            this.urduTextBox1.TextChanged += new System.EventHandler(this.urduTextBox1_TextChanged);
        }
        private void urduTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        public void Clear()
        {
            productnametextBox.Text = "";
            producttypetextBox.Text = "";
            productdetailtextBox.Text = "";
            productpricetextBox.Text = "";
            productsizetextBox.Text = "";

        }

        private void addproductbutton_Click(object sender, EventArgs e)
        {
            string yy="N";
            try
            {
                if (productnametextBox.Text != "" && productpricetextBox.Text != "" && producttypetextBox.Text != "" &&
                    productsizetextBox.Text != "" && productdetailtextBox.Text != "" && productcodetextBox.Text != "")
                {
                    if (messradioButton.Checked == true)
                    {
                        ResultRadiobutton = 1;
                    }
                    else
                    {
                        ResultRadiobutton = 0;
                    }

                    var sql = "INSERT INTO store_product (p_code ,p_name, p_type, p_size ,p_price ,p_TuckMess, p_detail,Disable ) VALUES ('" +
                                 productcodetextBox.Text + "','" + productnametextBox.Text + "','" + producttypetextBox.Text +
                                 "' ,'" + productsizetextBox.Text + "' ,'" + productpricetextBox.Text + "','" + ResultRadiobutton + "' ,'" +
                                 productdetailtextBox.Text + "','"+yy+"')";
                   con.Open();
                    var command = new SqlCommand(sql, con);
                    var dataReader = command.ExecuteReader();
                    dataReader.Close();
                    command.Dispose();
                    con.Close();
                    MessageBox.Show("Record Saved.");
                    Clear();
                    inc = inc + 1;
                    productcodetextBox.Text = inc.ToString();
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
            //Abcinvoice mfm = new Abcinvoice();
            //mfm.Focus();
        }
        //function for resulution

        //private void Resizechildrencontrols()
        //{
        //    Resizecontrol(nametextBoxreRectangle, productnametextBox);
        //    Resizecontrol(typetextBoxreRectangle, producttypetextBox);
        //    Resizecontrol(detailtextBoxreRectangle, productdetailtextBox);
        //    Resizecontrol(pricetextBoxreRectangle, productpricetextBox);
        //    Resizecontrol(sizetextBoxreRectangle, productsizetextBox);
        //    Resizecontrol(codetextBoxreRectangle, productcodetextBox);
        //    Resizecontrol(addproductbuttonRectangle, addproductbutton);
        //    Resizecontrol(button1Rectangle, button1);
        //    Resizecontrol(label1Rectangle, label1);
        //    Resizecontrol(label2Rectangle, label2);
        //    Resizecontrol(label3Rectangle, label3);
        //    Resizecontrol(label4Rectangle, label4);
        //    Resizecontrol(label5Rectangle, label5);
        //    Resizecontrol(label66Rectangle, label6);
        //}


        //private void Resizecontrol(Rectangle originalcontrolrect, Control control)
        //{
        //float xRatio = (float)(this.Width)/(float)(formoriginalsize.Width);
        //float yRatio=(float)(this.Height)/(float)(formoriginalsize.Height);

        //int newX=(int)(originalcontrolrect.X*xRatio);
        //int newY=(int)(originalcontrolrect.Y*yRatio);

        //int newWidth = (int) (control.Size.Width*xRatio);
        //int newHeight=(int)(control.Size.Height*yRatio);

        //    control.Location = new Point (newX, newY);
        //    control.Size = new Size(newWidth, newHeight);
        //}

        //function end for resolution
        private void addproductform_Load(object sender, EventArgs e)
        {
            //resolution part start
            
            //formoriginalsize =this.Size;
            //nametextBoxreRectangle = new Rectangle(productnametextBox.Location.X,productnametextBox.Location.Y,productnametextBox.Width,productnametextBox.Height);
            //typetextBoxreRectangle = new Rectangle(producttypetextBox.Location.X, producttypetextBox.Location.Y, producttypetextBox.Width, producttypetextBox.Height);
            //detailtextBoxreRectangle = new Rectangle(productdetailtextBox.Location.X, productdetailtextBox.Location.Y, productdetailtextBox.Width, productdetailtextBox.Height);
            //pricetextBoxreRectangle = new Rectangle(productpricetextBox.Location.X, productpricetextBox.Location.Y, productpricetextBox.Width, productpricetextBox.Height);
            //sizetextBoxreRectangle = new Rectangle(productsizetextBox.Location.X, productsizetextBox.Location.Y, productsizetextBox.Width, productsizetextBox.Height);
            //codetextBoxreRectangle = new Rectangle(productcodetextBox.Location.X, productcodetextBox.Location.Y, productcodetextBox.Width, productcodetextBox.Height);
            //addproductbuttonRectangle = new Rectangle(addproductbutton.Location.X, addproductbutton.Location.Y, addproductbutton.Width, addproductbutton.Height);
            //button1Rectangle = new Rectangle(button1.Location.X, button1.Location.Y, button1.Width, button1.Height);
            //label1Rectangle = new Rectangle(label1.Location.X, label1.Location.Y, label1.Width, label1.Height);
            //label2Rectangle = new Rectangle(label2.Location.X, label2.Location.Y, label2.Width, label2.Height);
            //label3Rectangle = new Rectangle(label3.Location.X, label3.Location.Y, label3.Width, label3.Height);
            //label4Rectangle = new Rectangle(label4.Location.X, label4.Location.Y, label4.Width, label4.Height);
            //label5Rectangle = new Rectangle(label5.Location.X, label5.Location.Y, label5.Width, label5.Height);
            //label66Rectangle = new Rectangle(label6.Location.X, label6.Location.Y, label6.Width, label6.Height);
            
            //resolution part end

            messradioButton.Checked = true;


            string querry = ("SELECT top(1) p_code from [store_product] order by p_code desc");
            SqlCommand cmdd = new SqlCommand(querry, con);
            con.Open();

            try
            {
                var dbr = cmdd.ExecuteReader();
                while (dbr.Read())
                {

                    int mch = (int)dbr["p_code"];
                     mch = mch + 1;
                     inc = mch;
                     productcodetextBox.Text = mch.ToString();
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

        private void productnametextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                producttypetextBox.Focus();
            }
        }

        private void producttypetextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                productdetailtextBox.Focus();
            }
        }

        private void productdetailtextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                productpricetextBox.Focus();
            }
        }

        private void productpricetextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                productsizetextBox.Focus();
            }
        }

        private void productsizetextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               addproductbutton_Click(sender,e);
            }
        }

       


    }
}