using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace lasticecream
{
    public partial class Form1 : Form
    {
        OleDbConnection olcon = new OleDbConnection(ConfigurationManager.ConnectionStrings["Accdbx"].ToString());
        string imagepath = ConfigurationManager.AppSettings["tableimage"].ToString();
        string Parsalimagepath = ConfigurationManager.AppSettings["parsalimage"].ToString();
        DataSet ds = new DataSet();
        int formwidth;
        int formheight;
        int imagewidth;
        int imageheight;
        public Form1()
        {
            InitializeComponent();
            //label1.Text = formheight + "x" + formwidth;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized; 
            formheight = this.Height;
            formwidth = this.Width;
            label1.Text = formheight + "x" + formwidth;
            Image img = Image.FromFile(imagepath);
            imagewidth = img.Width;
            imageheight = img.Height;
            label2.Text = imagewidth + "x" + imageheight;
            //imagewidth = 150;
            //imageheight = 100;
            int countimagesinarow = (formwidth - 200) / imagewidth;
            createimagetables(countimagesinarow);
        }

        private void createimagetables(int tablesinarow)
        {
            if (ds.Tables["table"] != null)
            {
                ds.Tables["table"].Clear();
            }
            
            //Refresh();
            olcon.Open();
            string checkNow = "select table_no,Status,table_description from tableinfo order by table_no";
            OleDbDataAdapter oladapt = new OleDbDataAdapter(checkNow, olcon);
            oladapt.Fill(ds, "table");
            olcon.Close();
            PictureBox[] Shapes = new PictureBox[ds.Tables["table"].Rows.Count];
            Label[] lblshape = new Label[ds.Tables["table"].Rows.Count];
            int formcenter = formwidth / 2;
            int picturesize = imagewidth * tablesinarow;
            int distancesize = (tablesinarow - 1) * 5;
            int centerpointpictures = (picturesize + distancesize) / 2;

            int xaxis = (formcenter - centerpointpictures)-160 ;
            //xaxis = -60;
            int x = xaxis;
            int y = 20;
            label3.Text = xaxis.ToString() + "-" + y;
            int i;
            string[] str = new string[3];
            //50 is space from end side
            int k = tablesinarow;
            int totaltable = ds.Tables["table"].Rows.Count;
            //int tablerows = tablesinarow / totaltable;
            for (i = 0; i < ds.Tables["table"].Rows.Count; i++)
            {
                if (i == k)
                {
                    x = xaxis;
                    y = y + imageheight + 5;
                    k = k + tablesinarow;
                 }
                str[0] = ds.Tables["table"].Rows[i]["table_no"].ToString();
                str[1] = ds.Tables["table"].Rows[i]["Status"].ToString();
                str[2] = ds.Tables["table"].Rows[i]["table_description"].ToString();
                x = x + imagewidth+5;
                Shapes[i] = new PictureBox();
                lblshape[i] = new Label();
                
                if (ds.Tables["table"].Rows[i]["table_no"].ToString()=="0")
                {
                    Shapes[i].Name =parsal.Parsal.ToString();
                    //Shapes[i].Image = System.Drawing.Image.FromFile(Parsalimagepath);
                }
                else
                {
                    Shapes[i].Name = (i).ToString();
                    //Shapes[i].Image = System.Drawing.Image.FromFile(imagepath);lblshape[i].Text = "ٹیبل-" + (i).ToString();
                }
               
                Shapes[i].Location = new Point(x, y);
                Shapes[i].Size = new Size(imagewidth, imageheight);
                Shapes[i].BorderStyle = BorderStyle.FixedSingle;
                Shapes[i].Visible = true;
                Shapes[i].BackgroundImageLayout = ImageLayout.Stretch;
                Shapes[i].BackColor = Color.Transparent;
                
                Shapes[i].SendToBack();
                Shapes[i].Click += Form1_Click;
                //labels
                lblshape[i] = new Label();
                String label1 = i.ToString();
                if (i.ToString()==((int)parsal.Parsal).ToString())
                {
                    lblshape[i].Text = "پارسل".ToString();
                }
                else
                {
                    lblshape[i].Text = "ٹیبل-" + (i).ToString();
                }
                lblshape[i].Location = new Point(x+10, y+50);
                lblshape[i].Font = new Font("Arial", 16, FontStyle.Bold);
                lblshape[i].Visible = true;
                lblshape[i].BringToFront();
                //add controls
                this.Controls.Add(Shapes[i]);

                this.Controls.Add(lblshape[i]);
                lblshape[i].BringToFront();
            }
           
           
    }
        private void Form1_Click(object sender, EventArgs e)
        {
            PictureBox img = sender as PictureBox;
            BillScreen fm = new BillScreen();
            fm.tablename = img.Name;
            fm.Show();
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            formheight = this.Height;
            formwidth = this.Width;
            label1.Text = formheight + "x" + formwidth;
            
            int countimagesinarow = (formwidth - 200) / imagewidth;
            //createimagetables(countimagesinarow);
            //Form1_Load(null, EventArgs.Empty);


        }
    }
}
