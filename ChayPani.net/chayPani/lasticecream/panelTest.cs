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
    public partial class panelTest : Form
    {
        OleDbConnection olcon = new OleDbConnection(ConfigurationManager.ConnectionStrings["Accdbx"].ToString());
        string imagepath = ConfigurationManager.AppSettings["tableimage"].ToString();
        string Parsalimagepath = ConfigurationManager.AppSettings["parsalimage"].ToString();
        DataSet ds = new DataSet();
        int screenWidth;
        int screenHeight;
        

        public panelTest()
        {
            InitializeComponent();
        }

        private void panelTest_Load(object sender, EventArgs e)
        {
            screenWidth = Screen.PrimaryScreen.Bounds.Width;
            screenHeight = Screen.PrimaryScreen.Bounds.Height;
            tableLayoutPanel1.Height=screenHeight-10;
            createimagetables(25);
        }

        private void createimagetables(int tablesinarow)
        {
            if (ds.Tables["table"] != null)
            {
                ds.Tables["table"].Clear();
            }

            //Refresh();
            olcon.Open();
            string checkNow = "select MenuNumber,menuname,menutype,menurate from menuinfo order by MenuNumber";
            OleDbDataAdapter oladapt = new OleDbDataAdapter(checkNow, olcon);
            oladapt.Fill(ds, "table");
            olcon.Close();

            int rowsTblLayout = ds.Tables["table"].Rows.Count;
            rowsTblLayout = rowsTblLayout / 2;

            tableLayoutPanel1.RowCount = rowsTblLayout;
            int row = 0;
            int col = 0;
            

            //int formcenter = formwidth / 2;
            //int picturesize = imagewidth * tablesinarow;
            //int distancesize = (tablesinarow - 1) * 5;
            //int centerpointpictures = (picturesize + distancesize) / 2;

            //int xaxis = (formcenter - centerpointpictures) - 60;
            ////xaxis = -60;
            //int x = xaxis;
            //int y = 20;
            //label3.Text = xaxis.ToString() + "-" + y;
            int i;
            string[] str = new string[4];
            ////50 is space from end side
            //int k = tablesinarow;
            Button[] Shapes = new Button[ds.Tables["table"].Rows.Count];

            //TableLayoutPanelCellPosition pos = tableLayoutPanel1.GetCellPosition(Shapes[1]);
            //int Cwidth = tableLayoutPanel1.GetColumnWidths()[pos.Column];
            //int Rheight = tableLayoutPanel1.GetRowHeights()[pos.Row];

            for (i = 0; i < ds.Tables["table"].Rows.Count; i++)
            {

                str[0] = ds.Tables["table"].Rows[i]["MenuNumber"].ToString();
                str[1] = ds.Tables["table"].Rows[i]["menuname"].ToString();
                str[2] = ds.Tables["table"].Rows[i]["menutype"].ToString();
                str[3] = ds.Tables["table"].Rows[i]["menurate"].ToString();
                Shapes[i] = new Button();
                Shapes[i].Name = (i).ToString();
                Shapes[i].Text = (i).ToString()+" "+ ds.Tables["table"].Rows[i]["menuname"].ToString() + " "+ ds.Tables["table"].Rows[i]["menurate"].ToString();
                Shapes[i].Font = new Font("Arial Narrow", 10.25f);
                Shapes[i].Visible = true;
                Shapes[i].BackColor = Color.White;
                Shapes[i].ForeColor= Color.Black;
                Shapes[i].Width= 230;
                Shapes[i].Click += Form1_Click;
                tableLayoutPanel1.Controls.Add(Shapes[i], row, col);
                row++;
                if (row == rowsTblLayout)
                {
                    row = 0;
                    col++;
                }
            }
        }
             private void Form1_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            CalculatorForm cf = new CalculatorForm();
            cf.MenuNumber = btn.Text;
            cf.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int number = int.Parse(textBox1.Text);
            //number.focus
        }
    }
    }

