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

namespace lasticecream.ChayPaniForms
{
    public partial class Tables : Form
    {
        OleDbConnection olecon = new OleDbConnection(ConfigurationManager.ConnectionStrings["Accdbx"].ConnectionString);
        public int table { get; set; }

        public Tables()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tableNumb(1);
        }

        private void tableNumb(int t)
        {
            table = t;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tableNumb(2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tableNumb(3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tableNumb(5);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tableNumb(5);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            tableNumb(6);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            tableNumb(7);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            tableNumb(8);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            tableNumb(9);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            tableNumb(10);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            tableNumb(11);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            tableNumb(12);
        }

        private void Tables_Load(object sender, EventArgs e)
        {
            CheckTable();
        }

        private void CheckTable()
        {
            try
            {
                DataSet ds;
                olecon.Open();
                string sql = "select table_no from mastebill where [Complete]=" + '0' + " and [Close]=" + '0' + " and [deletebill]=" + '1' +"  ";
                ds = new DataSet("test");
                OleDbDataAdapter DBAdapter = new OleDbDataAdapter();
                DBAdapter.SelectCommand = new OleDbCommand(sql, olecon);
                DBAdapter.Fill(ds);
                int i = ds.Tables["Table"].Rows.Count;
                if (ds.Tables["Table"].Rows.Count != 0)
                {
                    for(int j = 0; j < ds.Tables["Table"].Rows.Count; j++)
                    {
                        int k;
                        k = int.Parse( ds.Tables["Table"].Rows[j]["table_no"].ToString());
                        find(k);
                    }
                    
                }

            }
            catch (Exception es)
            {
                MessageBox.Show(es.ToString());
            }
            finally
            {
                if (olecon.State == ConnectionState.Open)
                {
                    olecon.Close();
                }
            }
        }
        private void find(int k)
        {
            if (k == 1)
            {
                button1.FlatAppearance.BorderColor = Color.DarkGreen;
                return;
            }
            if (k == 2)
            {
                button2.FlatAppearance.BorderColor = Color.DarkGreen;
                return;
            }
            if (k == 3)
            {
                button3.FlatAppearance.BorderColor = Color.DarkGreen;
                return;
            }
            if (k == 4)
            {
                button4.FlatAppearance.BorderColor = Color.DarkGreen;
                return;
            }
            if (k == 5)
            {
                button5.FlatAppearance.BorderColor = Color.DarkGreen;
                return;
            }
            if (k == 6)
            {
                button6.FlatAppearance.BorderColor = Color.DarkGreen;
                return;
            }
            if (k == 7)
            {
                button7.FlatAppearance.BorderColor = Color.DarkGreen;
                return;
            }
            if (k == 8)
            {
                button8.FlatAppearance.BorderColor = Color.DarkGreen;
                return;
            }
            if (k == 9)
            {
                button9.FlatAppearance.BorderColor = Color.DarkGreen;
                return;
            }
            if (k == 10)
            {
                button10.FlatAppearance.BorderColor = Color.DarkGreen;
                return;
            }
            if (k == 11)
            {
                button11.FlatAppearance.BorderColor = Color.DarkGreen;
                return;
            }
            if (k == 12)
            {
                button12.FlatAppearance.BorderColor = Color.DarkGreen;
                return;
            }
            if (k == 13)
            {
                button24.FlatAppearance.BorderColor = Color.DarkGreen;
                return;
            }
            if (k == 14)
            {
                button23.FlatAppearance.BorderColor = Color.DarkGreen;
                return;
            }
            if (k == 15)
            {
                button21.FlatAppearance.BorderColor = Color.DarkGreen;
                return;
            }
            if (k == 16)
            {
                button18.FlatAppearance.BorderColor = Color.DarkGreen;
                return;
            }
            if (k == 17)
            {
                button22.FlatAppearance.BorderColor = Color.DarkGreen;
                return;
            }
            if (k == 18)
            {
                button19.FlatAppearance.BorderColor = Color.DarkGreen;
                return;
            }
            if (k == 19)
            {
                button16.FlatAppearance.BorderColor = Color.DarkGreen;
                return;
            }
            if (k == 20)
            {
                button15.FlatAppearance.BorderColor = Color.DarkGreen;
                return;
            }
            if (k == 21)
            {
                button20.FlatAppearance.BorderColor = Color.DarkGreen;
                return;
            }
            if (k == 22)
            {
                button17.FlatAppearance.BorderColor = Color.DarkGreen;
                return;
            }
            if (k == 23)
            {
                button14.FlatAppearance.BorderColor = Color.DarkGreen;
                return;
            }
            if (k == 24)
            {
                button13.FlatAppearance.BorderColor = Color.DarkGreen;
                return;
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            tableNumb(13);
        }

        private void button23_Click(object sender, EventArgs e)
        {
            tableNumb(14);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            tableNumb(15);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            tableNumb(16);
        }

        private void button22_Click(object sender, EventArgs e)
        {
            tableNumb(17);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            tableNumb(18);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            tableNumb(19);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            tableNumb(20);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            tableNumb(21);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            tableNumb(22);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            tableNumb(23);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            tableNumb(24);
        }
    }
}
