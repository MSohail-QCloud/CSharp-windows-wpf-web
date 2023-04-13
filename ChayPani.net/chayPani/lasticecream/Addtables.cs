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
    public partial class Addtables : Form
    {
        OleDbConnection olecon = new OleDbConnection(ConfigurationManager.ConnectionStrings["Accdbx"].ConnectionString);
        DataSet ds = new DataSet();
        private static Addtables alreadyOpened = null;
        public Addtables()
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

        private void Addtables_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            showtablelist();
            txt_tblno.Focus();
        }
        private void showtablelist()
        {
            olecon.Open();
            DataTable dt = new DataTable();
            OleDbDataAdapter oleadapt = new OleDbDataAdapter("select table_no,tableid from tableinfo order by tableid", olecon);
            oleadapt.Fill(dt);
            dataGrid_tblist.DataSource = dt;
            dataGrid_tblist.Columns[0].HeaderText = "Table no#";
            dataGrid_tblist.Columns[1].HeaderText = "Code ID";
            olecon.Close();
        }
        //save table
        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_tblno.Text != "")
            {
                try
                {
                    OleDbCommand olecmd;
                    string sql = "select * from tableinfo where table_no='" + txt_tblno.Text + "'";
                    olecmd = new OleDbCommand(sql, olecon);
                    olecon.Open();
                    olecmd.ExecuteNonQuery();
                    OleDbDataAdapter adapt = new OleDbDataAdapter(sql, olecon);
                    ds = new DataSet("test");
                    adapt.Fill(ds, "test");
                    olecon.Close();
                    if (ds.Tables["test"].Rows.Count != 1)
                    {
                        lbl_tblid.Visible = false;
                        String query = "insert into tableinfo (table_no) values ('" + this.txt_tblno.Text + "')";
                        //SqlDataReader dbr;

                        olecon.Open();
                        OleDbCommand cmd = new OleDbCommand(query, olecon);
                        cmd.ExecuteNonQuery();
                        olecon.Close();
                        //dbr = cmd.ExecuteReader();
                        //MessageBox.Show("Table add");
                        showtablelist();
                    }
                    clear();




                }
                catch (Exception es)
                {
                    MessageBox.Show(es.Message);
                }
            }
            else
            {
              
            }
            
        }

        private void clear()
        {
            txt_tblno.Text = "";
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGrid_tblist_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            lbl_tblid.Visible = true;
            txt_tblno.Text = dataGrid_tblist.Rows[e.RowIndex].Cells[0].Value.ToString();
            lbl_tblid.Text = dataGrid_tblist.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        //delete
        private void button2_Click(object sender, EventArgs e)
        {
            if (txt_tblno.Text != ""&& lbl_tblid.Text!=".")
            {
                try
                {
                    OleDbCommand olcmd = new OleDbCommand("delete * from tableinfo where tableid=@id ", olecon);
                    olecon.Open();
                    olcmd.Parameters.AddWithValue("@id", lbl_tblid.Text);
                    olcmd.ExecuteNonQuery();
                    olecon.Close();
                    MessageBox.Show("ٹیبل ڈیلیٹ کر دیا گیا ہے۔");
                    showtablelist();
                    clear();
                    lbl_tblid.Visible = false;

                }
                catch(Exception es)
                {
                    MessageBox.Show(es.ToString());
                }
            }
            else
            {
                MessageBox.Show("ڈیلیٹ کرنےکیلئے ریکارڈ سیلیکٹ کریں۔");
            }
        }

        private void txt_tblno_KeyPress(object sender, KeyPressEventArgs e)
        {
            //base.OnKeyPress(e);
            //if (e.KeyChar != (char)8 && !char.IsNumber(e.KeyChar))
            //{
            //    e.Handled = true;
            //}
        }

        private void txt_tblno_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }
    }
}
