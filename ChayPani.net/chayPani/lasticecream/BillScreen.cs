
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
    public partial class BillScreen : Form
    {
        OleDbConnection olecon = new OleDbConnection(ConfigurationManager.ConnectionStrings["Accdbx"].ConnectionString);
        DataTable dt_bill = new DataTable();
        DataRow dr_billgrid;
        OleDbDataReader dr;
        int indexbill = 0;
        int billnumber = 0;
        public string tablename { get; set; }
        Myclass mc = new Myclass();
        private static BillScreen alreadyOpened = null;
        CalculatorForm cform;
        public string abc = "";
        public BillScreen()
        {
            if (alreadyOpened != null && !alreadyOpened.IsDisposed)
            {
                alreadyOpened.Focus();          // Bring the old one to top
                Shown += (s, e) => this.Close();  // and destroy the new one.
                return;
            }

            // Otherwise store this one as reference
            alreadyOpened = this;
            
            InitializeComponent();
        }

        private void findbillnumber()
        {
            try
            {
                //OleDbCommand olecmd = new OleDbCommand();
                DataSet ds;
                olecon.Open();
                string sql = "select billnumber from mastebill where [table_no]='" + comboBox_tblnumber.Text + "' and [Complete]=" + '0' + " and [Close]=" + '0' + "  ";
                //olecmd = new OleDbCommand(sql, olecon);

                ////olecmd.ExecuteNonQuery();
                //OleDbDataAdapter adapt = new OleDbDataAdapter(sql, olecon);
                ds = new DataSet("test");
                //adapt.Fill(ds, "test");

                OleDbDataAdapter DBAdapter = new OleDbDataAdapter();
                DBAdapter.SelectCommand = new OleDbCommand(sql, olecon);
                //ds.Tables["Table"].Clear();
                DBAdapter.Fill(ds);
                int i = ds.Tables["Table"].Rows.Count;
                if (ds.Tables["Table"].Rows.Count != 0)
                {
                    txt__billnumber.Text = ds.Tables["Table"].Rows[0]["billnumber"].ToString();
                }
                else
                {
                    createbillnumber();
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



        private void BillScreen_Load(object sender, EventArgs e)
        {
            try
            {
                (panel1 as Control).KeyPress += new KeyPressEventHandler(Control_KeyPress);

                Fillgridview_catagory1();
                Fillgridview_catagory2();
                Fillgridview_catagory3();
                Fillgridview_catagory4();
                Fillgridview_catagory5();
                Fillgridview_catagory6();
                Fillgridview_catagory7();
                Fillgridview_catagory8();
                //Fillgridview_catagory9();
                this.WindowState = FormWindowState.Maximized;

                dt_bill.Columns.Add("نمبر شمار");
                dt_bill.Columns.Add("مینو نام");
                dt_bill.Columns.Add("قیمیت");
                dt_bill.Columns.Add("تعداد");
                dt_bill.Columns.Add("ٹوٹل");

                panel1.Focus();
                loadcombobox();
                findbillnumber();
                //createbillnumber();
                //billclear();
                gri_bill();
                txt_menuid.Visible = true;
                txt__billnumber.Visible = true;
                txt_totalbill.Visible = true;
                //txt_discount.Visible = true;
                //txt_grandtotal.Visible = true;
                //txt_paidbill.Visible = true;
                //clear_Selection();
                countemenues();
                //panel1.Width = this.Width;
                //panel1.Height = this.Height;
                //cform = new CalculatorForm();
                search_HightlightRow(1);
            }
            catch (Exception)
            {

            }
            

        }

        private void loadcombobox()
        {

            DataSet ds = new DataSet();
            string getEmpSQL = "SELECT table_no FROM tableinfo order by tableid ;";
            OleDbDataAdapter sda = new OleDbDataAdapter(getEmpSQL, olecon);

            try
            {
                olecon.Open();
                sda.Fill(ds);
            }
            catch (Exception se)
            {
                MessageBox.Show("An error occured while connecting to database" + se.ToString());
            }
            finally
            {
                olecon.Close();
            }

            comboBox_tblnumber.DataSource = ds.Tables[0];
            comboBox_tblnumber.DisplayMember = ds.Tables[0].Columns[0].ToString();
            comboBox_tblnumber.SelectedIndex = int.Parse(tablename);
        }
        private void createbillnumber()
        {
            try
            {
                //olecon.Open();
                string query = "select top 1 billnumber  from mastebill order by billnumber desc";
                OleDbCommand cmd = new OleDbCommand(query, olecon);//Advised to use parameterized query
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    billnumber = int.Parse(dr.GetValue(0).ToString());
                    billnumber = billnumber + 1;


                }
                else
                {
                    billnumber = 1;

                }
                dr.Close();
                txt__billnumber.Text = billnumber.ToString();

                //insert record bill number and table number
                string pdatetime = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");
                String query1 = "insert into mastebill (table_no,billnumber,billamount,billDiscount,grandTotal,paidamount,change,billingdate,printdatetime,deletebill,[Complete],[Close]) values ('" + this.comboBox_tblnumber.Text + "'," + this.txt__billnumber.Text + ",'" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + DateTime.Now.ToString("dd-MMM-yy") + "','" + pdatetime + "',1,0,0)";
                OleDbCommand cmd1 = new OleDbCommand(query1, olecon);
                cmd1.ExecuteNonQuery();
                //
                //olecon.Close();
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message.ToString());
                return;
            }

        }

        private void txt_qty_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void txt_qty_TextChanged(object sender, EventArgs e)
        {

        }
        private void clear()
        {
            txt_menuid.Text = "01";
            //txt_discount.Text = "0";
            //txt_grandtotal.Text = "0";
            //txt_menuname.Text = "";
            //txt_menurate.Text = "";

            lbl_jama.Text = ".";
        }

        private void btn_saveprint_Click(object sender, EventArgs e)
        {
            int amount = int.Parse(txt_totalbill.Text);
            if (txt__billnumber.Text != "" && txt__billnumber.Text != "0"  && amount>0)
            {
                try
                {
                    string pdatetime = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");
                    btn_saveprint.FlatStyle = FlatStyle.Standard;
                    OleDbCommand olecmd = new OleDbCommand();
                    DataSet ds;
                    string sql = "select billnumber from mastebill where billnumber=" + txt__billnumber.Text + " ";
                    olecmd = new OleDbCommand(sql, olecon);
                    olecon.Open();
                    olecmd.ExecuteNonQuery();
                    OleDbDataAdapter adapt = new OleDbDataAdapter(sql, olecon);
                    ds = new DataSet("test");
                    adapt.Fill(ds, "test");
                    olecon.Close();
                    if (ds.Tables["test"].Rows.Count == 1)
                    {
                        OleDbCommand command = new OleDbCommand(@"UPDATE mastebill SET billamount = @bamount, billingdate = @bdate, printdatetime = @pdate, [Complete]=@com WHERE billnumber = @bnum", olecon);

                        command.Parameters.AddWithValue("@bamount", txt_totalbill.Text);
                        command.Parameters.AddWithValue("@bdate", DateTime.Now.ToString("dd-MMM-yy"));
                        command.Parameters.AddWithValue("@pdate", DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));
                        command.Parameters.AddWithValue("@com", 1);
                        command.Parameters.AddWithValue("@bnum", txt__billnumber.Text);
                        olecon.Open();
                        command.ExecuteNonQuery();
                        if (olecon.State == ConnectionState.Open)
                        {
                            olecon.Close();
                        }




                        //String query = "insert into mastebill (table_no,billnumber,billamount,billDiscount,grandTotal,paidamount,change,billingdate,printdatetime,deletebill) values ('" + this.comboBox_tblnumber.Text + "'," + this.txt__billnumber.Text + "," + this.txt_totalbill.Text + ",'"+ 0+ "','" + this.txt_totalbill.Text + "'," + this.txt_totalbill.Text + ",'" + 0 + "','" + DateTime.Now.ToString("dd-MMM-yy") + "','" + pdatetime + "',1)";
                        //olecon.Open();
                        //OleDbCommand cmd = new OleDbCommand(query, olecon);
                        //cmd.ExecuteNonQuery();

                        int bill = int.Parse(txt__billnumber.Text);
                        if (checkBox_noprinter.Checked != true)
                        {
                            //Report rep = new Report(bill);
                            //rep.Duplication = "";

                            //rep.print = 1;
                            //rep.Show();
                        }

                        gridview_bill.DataSource = null;
                        dt_bill.Clear();
                        txt_totalbill.Text = "";

                        
                        indexbill = 0;

                        //createbillnumber();
                        this.Close();
                        //btn_saveprint.FlatStyle = FlatStyle.Flat;
                        //btn_saveprint.BackColor = Color.GreenYellow;
                        //panel1.Focus();
                    }
                    else
                    {
                        MessageBox.Show("ڈپلیکیٹ بل نمبر۔");
                        panel1.Focus();

                    }
                }
                catch (Exception es)
                {
                    MessageBox.Show(es.Message);
                    if (olecon.State == ConnectionState.Open)
                    {
                        olecon.Close();
                    }
                    panel1.Focus();
                }
            }
            else
            {
                MessageBox.Show("تمام ریکارڈز مکمل کریں۔");
                panel1.Focus();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            parentform pf = new parentform();
            pf.Show();
            this.Close();
        }

        private void txt_tablenumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //txt_qty.Focus();
            }
        }

        private void txt_qty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //btn_savemenu.Focus();
            }
        }

        private void txt_paidbill_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_saveprint.Focus();
                //btn_saveprint.BackColor = Color.Pink;
            }
        }

        private void txt_tablenumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (e.KeyChar != (char)8 && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt__billnumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (e.KeyChar != (char)8 && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_menuid_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (e.KeyChar != (char)8 && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_menurate_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (e.KeyChar != (char)8 && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_qty_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
               && !char.IsDigit(e.KeyChar)
               && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }

            //base.OnKeyPress(e);
            //if (e.KeyChar != (char)8 && !char.IsNumber(e.KeyChar))
            //{
            //    e.Handled = true;
            //}
        }

        private void txt_totalbill_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (e.KeyChar != (char)8 && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_paidbill_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (e.KeyChar != (char)8 && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        //load gridview
        private void Fillgridview_catagory1()
        {
            DataTable dt1;
            string querry = "select MenuNumber,iPriority,menuname,menurate from menuinfo where menutype='" + (menucatagory)1 + "' order by MenuNumber";
            dt1 = mc.fillgidview(querry);
            grid_menu_catagory1.DataSource = dt1;
            grid_menu_catagory1.Columns[0].HeaderText = "کوڈ";
            grid_menu_catagory1.Columns[2].HeaderText = "مینیو نام";
            grid_menu_catagory1.Columns[3].HeaderText = "ریٹ";
            grid_menu_catagory1.Columns[0].Width = 30;
            grid_menu_catagory1.Columns[2].Width = 110;
            grid_menu_catagory1.Columns[3].Width = 50;
            grid_menu_catagory1.Columns["iPriority"].Visible = false;
            grid_menu_catagory1.ClearSelection();
            olecon.Close();
        }
        private void Fillgridview_catagory2()
        {
            DataTable dt1;
            string querry = "select MenuNumber,iPriority,menuname,menurate from menuinfo where menutype='" + (menucatagory)2 + "' order by MenuNumber";
            dt1 = mc.fillgidview(querry);
            grid_menu_catagory2.DataSource = dt1;
            grid_menu_catagory2.Columns[0].HeaderText = "کوڈ";
            grid_menu_catagory2.Columns[2].HeaderText = "مینیو نام";
            grid_menu_catagory2.Columns[3].HeaderText = "ریٹ";
            grid_menu_catagory2.Columns[0].Width = 30;
            grid_menu_catagory2.Columns[2].Width = 110;
            grid_menu_catagory2.Columns[3].Width = 50;
            grid_menu_catagory2.Columns["iPriority"].Visible = false;
            olecon.Close();
        }
        private void Fillgridview_catagory3()
        {
            DataTable dt1;
            string querry = "select MenuNumber,iPriority,menuname,menurate from menuinfo where menutype='" + (menucatagory)3 + "' order by MenuNumber";
            dt1 = mc.fillgidview(querry);
            grid_menu_catagory3.DataSource = dt1;
            grid_menu_catagory3.Columns[0].HeaderText = "کوڈ";
            grid_menu_catagory3.Columns[2].HeaderText = "مینیو نام";
            grid_menu_catagory3.Columns[3].HeaderText = "ریٹ";
            grid_menu_catagory3.Columns[0].Width = 30;
            grid_menu_catagory3.Columns[2].Width = 110;
            grid_menu_catagory3.Columns[3].Width = 50;
            grid_menu_catagory3.Columns["iPriority"].Visible = false;
            olecon.Close();
        }
        private void Fillgridview_catagory4()
        {
            DataTable dt1;
            string querry = "select MenuNumber,iPriority,menuname,menurate from menuinfo where menutype='" + (menucatagory)4 + "' order by MenuNumber";
            dt1 = mc.fillgidview(querry);
            grid_menu_catagory4.DataSource = dt1;
            grid_menu_catagory4.Columns[0].HeaderText = "کوڈ";
            grid_menu_catagory4.Columns[2].HeaderText = "مینیو نام";
            grid_menu_catagory4.Columns[3].HeaderText = "ریٹ";
            grid_menu_catagory4.Columns[0].Width = 30;
            grid_menu_catagory4.Columns[2].Width = 110;
            grid_menu_catagory4.Columns[3].Width = 50;
            grid_menu_catagory4.Columns["iPriority"].Visible = false;
            olecon.Close();
        }
        private void Fillgridview_catagory5()
        {
            DataTable dt1;
            string querry = "select MenuNumber,iPriority,menuname,menurate from menuinfo where menutype='" + (menucatagory)5 + "' order by MenuNumber";
            dt1 = mc.fillgidview(querry);
            grid_menu_catagory5.DataSource = dt1;
            grid_menu_catagory5.Columns[0].HeaderText = "کوڈ";
            grid_menu_catagory5.Columns[2].HeaderText = "مینیو نام";
            grid_menu_catagory5.Columns[3].HeaderText = "ریٹ";
            grid_menu_catagory5.Columns[0].Width = 30;
            grid_menu_catagory5.Columns[2].Width = 110;
            grid_menu_catagory5.Columns[3].Width = 50;
            grid_menu_catagory5.Columns["iPriority"].Visible = false;
            olecon.Close();
        }
        private void Fillgridview_catagory6()
        {
            DataTable dt1;
            string querry = "select MenuNumber,iPriority,menuname,menurate from menuinfo where menutype='" + (menucatagory)6 + "' order by MenuNumber";
            dt1 = mc.fillgidview(querry);
            grid_menu_catagory6.DataSource = dt1;
            grid_menu_catagory6.Columns[0].HeaderText = "کوڈ";
            grid_menu_catagory6.Columns[2].HeaderText = "مینیو نام";
            grid_menu_catagory6.Columns[3].HeaderText = "ریٹ";
            grid_menu_catagory6.Columns[0].Width = 30;
            grid_menu_catagory6.Columns[2].Width = 110;
            grid_menu_catagory6.Columns[3].Width = 50;
            grid_menu_catagory6.Columns["iPriority"].Visible = false;
            olecon.Close();
        }
        private void Fillgridview_catagory7()
        {
            DataTable dt1;
            string querry = "select MenuNumber,iPriority,menuname,menurate from menuinfo where menutype='" + (menucatagory)7 + "' order by MenuNumber";
            dt1 = mc.fillgidview(querry);
            grid_menu_catagory7.DataSource = dt1;
            grid_menu_catagory7.Columns[0].HeaderText = "کوڈ";
            grid_menu_catagory7.Columns[2].HeaderText = "مینیو نام";
            grid_menu_catagory7.Columns[3].HeaderText = "ریٹ";
            grid_menu_catagory7.Columns[0].Width = 30;
            grid_menu_catagory7.Columns[2].Width = 110;
            grid_menu_catagory7.Columns[3].Width = 50;
            grid_menu_catagory7.Columns["iPriority"].Visible = false;
            olecon.Close();
        }
        private void Fillgridview_catagory8()
        {
            DataTable dt1;
            string querry = "select MenuNumber,iPriority,menuname,menurate from menuinfo where menutype='" + (menucatagory)8 + "' order by MenuNumber";
            dt1 = mc.fillgidview(querry);
            grid_menu_catagory8.DataSource = dt1;
            grid_menu_catagory8.Columns[0].HeaderText = "کوڈ";
            grid_menu_catagory8.Columns[2].HeaderText = "مینیو نام";
            grid_menu_catagory8.Columns[3].HeaderText = "ریٹ";
            grid_menu_catagory8.Columns[0].Width = 30;
            grid_menu_catagory8.Columns[2].Width = 110;
            grid_menu_catagory8.Columns[3].Width = 50;
            grid_menu_catagory8.Columns["iPriority"].Visible = false;

            olecon.Close();
        }
        //private void Fillgridview_catagory9()
        //{
        //    DataTable dt1;
        //    string querry = "select MenuNumber,iPriority,menuname,menurate from menuinfo where menutype='" + (menucatagory)9 + "' order by MenuNumber";
        //    dt1 = mc.fillgidview(querry);
        //    grid_menu_catagory9.DataSource = dt1;
        //    grid_menu_catagory9.Columns[0].HeaderText = "کوڈ";
        //    grid_menu_catagory9.Columns[2].HeaderText = "مینیو نام";
        //    grid_menu_catagory9.Columns[3].HeaderText = "ریٹ";
        //    grid_menu_catagory9.Columns[0].Width = 30;
        //    grid_menu_catagory9.Columns[2].Width = 110;
        //    grid_menu_catagory9.Columns[3].Width = 40;
        //    grid_menu_catagory9.Columns["iPriority"].Visible = false;
        //    grid_menu_catagory9.ClearSelection();
        //    olecon.Close();
        //}


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                dt_bill.Rows.Clear();
                clear();

                //Fillgridview_catagory1();
                //Fillgridview_catagory2();
                //Fillgridview_catagory3();
                //Fillgridview_catagory4();
                //Fillgridview_catagory5();
                //Fillgridview_catagory6();
                //Fillgridview_catagory7();
                //Fillgridview_catagory8();
                //Fillgridview_catagory9();
                //clear_Selection();
                billclear();
                //search_HightlightRow(1);
                gridview_bill.Enabled = true;
                btn_saveprint.Enabled = true;
                comboBox_tblnumber.SelectedIndex = int.Parse(tablename);
                //countemenues();
            }
            catch(Exception es)
            {
                MessageBox.Show(es.Message);
            }
            finally
            {
                search_HightlightRow(1);
            }
            


        }

        private void billclear()
        {
            //createbillnumber();
            OleDbCommand olcmd = new OleDbCommand("delete * from detailbill where masterbill_id=@id ", olecon);
            olecon.Open();
            olcmd.Parameters.AddWithValue("@id", txt__billnumber.Text);
            olcmd.ExecuteNonQuery();
            olecon.Close();

            gri_bill();

        }

        private void txt_paidbill_TextChanged(object sender, EventArgs e)
        {

            //if (txt_totalbill.Text != "" && txt_paidbill.Text != "" && txt_discount.Text != "")
            //{
            //    float paid = float.Parse(txt_paidbill.Text);
            //    float total = float.Parse(txt_grandtotal.Text);
            //    lbl_remaining.Text = (paid - total).ToString();
            //}


        }

        private void txt_customername_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    txt_paidbill.Focus();
            //}
        }



        private void openCalculator(string i)
        {
            try
            {
                cform = new CalculatorForm();
                cform.MenuNumber = i;
                cform.billnumber = int.Parse(txt__billnumber.Text);
                cform.ShowDialog();
                abc = cform.know;
                //findbillnumber();
                //createbillnumber();
                gri_bill();
                summition();
                panel1.Focus();
            }
            catch (Exception es)
            {
                MessageBox.Show(es.ToString());
                panel1.Focus();
            }

        }

        private void txt_menuid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txt_menuid.Text.Length == 2)
                {
                    search_HightlightRow(int.Parse(txt_menuid.Text));
                }
            }
        }
        public void clear_Selection()
        {
            try
            {
                grid_menu_catagory1.ClearSelection();
                grid_menu_catagory2.ClearSelection();
                grid_menu_catagory3.ClearSelection();
                grid_menu_catagory4.ClearSelection();
                grid_menu_catagory5.ClearSelection();
                grid_menu_catagory6.ClearSelection();
                grid_menu_catagory7.ClearSelection();
                grid_menu_catagory8.ClearSelection();
            }
            catch (Exception)
            {

            }
            
        }
        public void search_HightlightRow(int i)
        {
            clear_Selection();
            int rowIndex = -1;
            try
            {

                foreach (DataGridViewRow row in grid_menu_catagory1.Rows)
                {
                    if (grid_menu_catagory1.Rows[row.Index].Cells[0].Value.ToString().Equals(i.ToString()))
                    {
                        rowIndex = row.Index;
                        grid_menu_catagory1.Rows[row.Index].Cells[0].Selected = true;
                        return;
                    }
                }
                foreach (DataGridViewRow row in grid_menu_catagory2.Rows)
                {
                    if (grid_menu_catagory2.Rows[row.Index].Cells[0].Value.ToString().Equals(i.ToString()))
                    {
                        rowIndex = row.Index;
                        grid_menu_catagory2.Rows[row.Index].Cells[0].Selected = true;
                        return;
                    }
                }
                foreach (DataGridViewRow row in grid_menu_catagory3.Rows)
                {
                    if (grid_menu_catagory3.Rows[row.Index].Cells[0].Value.ToString().Equals(i.ToString()))
                    {
                        rowIndex = row.Index;
                        grid_menu_catagory3.Rows[row.Index].Cells[0].Selected = true;
                        return;
                    }
                }
                foreach (DataGridViewRow row in grid_menu_catagory4.Rows)
                {
                    if (grid_menu_catagory4.Rows[row.Index].Cells[0].Value.ToString().Equals(i.ToString()))
                    {
                        rowIndex = row.Index;
                        grid_menu_catagory4.Rows[row.Index].Cells[0].Selected = true;
                        return;
                    }
                }
                foreach (DataGridViewRow row in grid_menu_catagory4.Rows)
                {
                    if (grid_menu_catagory4.Rows[row.Index].Cells[0].Value.ToString().Equals(i.ToString()))
                    {
                        rowIndex = row.Index;
                        grid_menu_catagory4.Rows[row.Index].Cells[0].Selected = true;
                        return;
                    }
                }
                foreach (DataGridViewRow row in grid_menu_catagory5.Rows)
                {
                    if (grid_menu_catagory5.Rows[row.Index].Cells[0].Value.ToString().Equals(i.ToString()))
                    {
                        rowIndex = row.Index;
                        grid_menu_catagory5.Rows[row.Index].Cells[0].Selected = true;
                        return;
                    }
                }
                foreach (DataGridViewRow row in grid_menu_catagory6.Rows)
                {
                    if (grid_menu_catagory6.Rows[row.Index].Cells[0].Value.ToString().Equals(i.ToString()))
                    {
                        rowIndex = row.Index;
                        grid_menu_catagory6.Rows[row.Index].Cells[0].Selected = true;
                        return;
                    }
                }
                foreach (DataGridViewRow row in grid_menu_catagory7.Rows)
                {
                    if (grid_menu_catagory7.Rows[row.Index].Cells[0].Value.ToString().Equals(i.ToString()))
                    {
                        rowIndex = row.Index;
                        grid_menu_catagory7.Rows[row.Index].Cells[0].Selected = true;
                        return;
                    }
                }
                foreach (DataGridViewRow row in grid_menu_catagory8.Rows)
                {
                    if (grid_menu_catagory8.Rows[row.Index].Cells[0].Value.ToString().Equals(i.ToString()))
                    {
                        rowIndex = row.Index;
                        grid_menu_catagory8.Rows[row.Index].Cells[0].Selected = true;
                        return;
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                panel1.Focus();
            }

        }

        string key = "01";

        public static bool IsNumber(Keys key)
        {
            string num = key.ToString().Substring(key.ToString().Length - 1);
            Int64 i64;
            if (Int64.TryParse(num, out i64))
            {
                return true;
            }
            return false;
        }



        int go = 01;

        int count = 1;
        //private void BillScreen_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    count = 1;
        //    //(panel1 as Control).KeyPress += new KeyPressEventHandler(Control_KeyPress);

        //}
        //keypress event
        int menues = 0;
        private void Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (key.Length == 2)
            {
                key = "";
            }
            if (Char.IsDigit(e.KeyChar))
            {
                key = key + e.KeyChar;
                txt_menuid.Text = key;
                if (key.Length == 2)
                {
                    if (key.ToString() != "00")
                    {
                        if (int.Parse(key) <= menues)
                        {
                            search_HightlightRow(int.Parse(key));
                            count++;
                        }
                        else
                        {
                            grid_menu_catagory1.ClearSelection();
                            panel1.Focus();
                            txt_menuid.Text = "";
                            key = "";
                            return;
                        }
                    }
                    else
                    {
                        btn_saveprint_Click(sender, e);
                    }
                    
                }
            }
        } 

        private void countemenues()
        {
            try
            {
                olecon.Open();
                string query = "select top 1 MenuNumber  from menuinfo order by MenuNumber desc";
                OleDbCommand cmd = new OleDbCommand(query, olecon);//Advised to use parameterized query
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    menues = int.Parse(dr.GetValue(0).ToString());
                }
                dr.Close();
                olecon.Close();
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message.ToString());
            }

        }


        private void panel1_Click(object sender, EventArgs e)
        {
            panel1.Focus();
        }
        #region cell click events on gridview
        private void grid_menu_catagory1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string menuNumber = grid_menu_catagory1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txt_menuid.Text = menuNumber;
            search_HightlightRow(int.Parse(menuNumber));
            openCalculator(menuNumber);
        }

        private void grid_menu_catagory2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string menuNumber = grid_menu_catagory2.Rows[e.RowIndex].Cells[0].Value.ToString();
            txt_menuid.Text = menuNumber;
            search_HightlightRow(int.Parse(menuNumber));
            openCalculator(menuNumber);
        }

        private void grid_menu_catagory3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string menuNumber = grid_menu_catagory3.Rows[e.RowIndex].Cells[0].Value.ToString();
            txt_menuid.Text = menuNumber;
            search_HightlightRow(int.Parse(menuNumber));
            openCalculator(menuNumber);
        }

        private void grid_menu_catagory4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string menuNumber = grid_menu_catagory4.Rows[e.RowIndex].Cells[0].Value.ToString();
            txt_menuid.Text = menuNumber;
            search_HightlightRow(int.Parse(menuNumber));
            openCalculator(menuNumber);
        }

        private void grid_menu_catagory5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string menuNumber = grid_menu_catagory5.Rows[e.RowIndex].Cells[0].Value.ToString();
            txt_menuid.Text = menuNumber;
            search_HightlightRow(int.Parse(menuNumber));
            openCalculator(menuNumber);
        }

        private void grid_menu_catagory6_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string menuNumber = grid_menu_catagory6.Rows[e.RowIndex].Cells[0].Value.ToString();
            txt_menuid.Text = menuNumber;
            search_HightlightRow(int.Parse(menuNumber));
            openCalculator(menuNumber);
        }

        private void grid_menu_catagory7_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string menuNumber = grid_menu_catagory7.Rows[e.RowIndex].Cells[0].Value.ToString();
            txt_menuid.Text = menuNumber;
            search_HightlightRow(int.Parse(menuNumber));
            openCalculator(menuNumber);
        }

        private void grid_menu_catagory8_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string menuNumber = grid_menu_catagory8.Rows[e.RowIndex].Cells[0].Value.ToString();
            txt_menuid.Text = menuNumber;
            search_HightlightRow(int.Parse(menuNumber));
            openCalculator(menuNumber);
        }

        //private void grid_menu_catagory9_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    string menuNumber = grid_menu_catagory9.Rows[e.RowIndex].Cells[0].Value.ToString();
        //    openCalculator(menuNumber);
        //}
        #endregion

        string q = "";
        
       public void gri_bill()
        {
            DataTable dt;
            q = "select menu_qty,menu_name,menurate,total,detail_bill_id from detailbill where masterbill_id=" + txt__billnumber.Text + " order by detail_bill_id";
            dt = mc.fillgidview(q);
            gridview_bill.DataSource = dt;
            gridview_bill.Columns[0].HeaderText = "تعداد";
            gridview_bill.Columns[1].HeaderText = "مینیو نام";
            gridview_bill.Columns[2].HeaderText = "ریٹ";
            gridview_bill.Columns[3].HeaderText = "ٹوٹل";
            gridview_bill.Columns[0].Width = 30;
            gridview_bill.Columns[1].Width = 110;
            gridview_bill.Columns[2].Width = 40;
            gridview_bill.Columns[3].Width = 40;
            gridview_bill.Columns["detail_bill_id"].Visible = false;
            gridview_bill.ClearSelection();
            olecon.Close();
            summition();

        }

        void summition()
        {
            int sum = 0;
            foreach (DataGridViewRow row in gridview_bill.Rows)
            {
                if (!row.IsNewRow)
                    sum += Convert.ToInt32(row.Cells[3].Value.ToString());
            }


            txt_totalbill.Text = sum.ToString();
        }

        private void gridview_bill_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox_tblnumber_DropDownClosed(object sender, EventArgs e)
        {
            panel1.Focus();
        }

        private void txt_menuid_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        private int checkbillnumber()
        {
            OleDbCommand olecmd;
            DataSet ds;
            string sql = "select * from mastebill where billnumber=" + txt__billnumber.Text + " and deletebill=1 ";
            olecmd = new OleDbCommand(sql, olecon);
            olecon.Open();
            olecmd.ExecuteNonQuery();
            OleDbDataAdapter adapt = new OleDbDataAdapter(sql, olecon);
            ds = new DataSet("test");
            adapt.Fill(ds, "test");
            olecon.Close();
            return ds.Tables["test"].Rows.Count;

        }
        private void txt__billnumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.D)
            {
                int billcount = checkbillnumber();
                if (billcount == 1)
                {
                    bill = int.Parse(txt__billnumber.Text);
                    //Report rep = new Report(bill); uncoment these lines and add bill date parameter.
                    //rep.Duplication = "Duplicate Bill";
                    //rep.Show();
                }
                else
                {
                    MessageBox.Show("Bill number "+txt__billnumber.Text+" not found.");
                    gridview_bill.DataSource = null;
                    dt_bill.Clear();
                    clear();
                }
                 
            }
            else if (e.KeyCode == Keys.Enter)
            {
                int checkbill = checkbillnumber();
                if (checkbill == 1)
                {
                    loadExistingBill();
                }
                else
                {
                    MessageBox.Show("Bill number "+txt__billnumber.Text+" not Found.");
                    gridview_bill.DataSource = null;
                    dt_bill.Clear();
                    clear();
                }
            }
            else if(e.KeyCode == Keys.Escape)
            {
                panel1.Focus();
            }

        }
        int bill = 0;
        int existingbillnumb = 0;
        db dblayer = new db();
        private void loadExistingBill()
        {
            existingbillnumb =int.Parse( txt__billnumber.Text);
            gridview_bill.Enabled = false;
            btn_saveprint.Enabled = false;
            gri_billex();
        }
        private void gri_billex()
        {
            DataTable dt;
            //q = "select menu_qty,menu_name,menurate,total,detail_bill_id from detailbill where masterbill_id=" + txt__billnumber.Text + "  order by detail_bill_id";
            q = "select dt.menu_qty,dt.menu_name,dt.menurate,dt.total,dt.detail_bill_id,mb.table_no from detailbill dt  inner join mastebill mb on mb.billnumber=dt.masterbill_id where mb.billnumber=" + txt__billnumber.Text + " and mb.deletebill=1";
            dt = mc.fillgidview(q);
            gridview_bill.DataSource = dt;
            if (gridview_bill.Rows.Count > 0)
            {
                gridview_bill.Columns[0].HeaderText = "تعداد";
                gridview_bill.Columns[1].HeaderText = "مینیو نام";
                gridview_bill.Columns[2].HeaderText = "ریٹ";
                gridview_bill.Columns[3].HeaderText = "ٹوٹل";
                gridview_bill.Columns[0].Width = 30;
                gridview_bill.Columns[1].Width = 110;
                gridview_bill.Columns[2].Width = 40;
                gridview_bill.Columns[3].Width = 40;
                gridview_bill.Columns["detail_bill_id"].Visible = false;
                gridview_bill.Columns["table_no"].Visible = false;
                comboBox_tblnumber.Text = gridview_bill.Rows[0].Cells["table_no"].Value.ToString();
                gridview_bill.ClearSelection();
                olecon.Close();
                summition();
            }
            else
            {
                dt.Clear();
                gridview_bill.DataSource = null;
                Refresh();
            }
        }
        private void txt_totalbill_TextChanged(object sender, EventArgs e)
        {
            //if (txt_totalbill.Text != "")
            //{
            //    int total = int.Parse(txt_totalbill.Text);
            //    int discount = int.Parse(txt_discount.Text);

            //    txt_grandtotal.Text = (total - discount).ToString();
            //}
        }

        private void txt_discount_TextChanged(object sender, EventArgs e)
        {
            //if(txt_discount.Text!="" && txt_discount.Text!="0")
            //{
            //    int discount = int.Parse(txt_discount.Text);
            //    int total = int.Parse(txt_totalbill.Text);
            //    txt_grandtotal.Text = (total - discount).ToString();
            //}
        }

        private void txt_grandtotal_TextChanged(object sender, EventArgs e)
        {
            //txt_paidbill.Text = txt_grandtotal.Text;
        }

        private void txt_discount_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    txt_paidbill.Focus();
            //}
        }

        private void gridview_bill_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int id =int.Parse( gridview_bill.Rows[e.RowIndex].Cells[4].Value.ToString());

            OleDbCommand olcmd = new OleDbCommand("delete * from detailbill where detail_bill_id=@id ", olecon);
            olecon.Open();
            olcmd.Parameters.AddWithValue("@id", id);
            olcmd.ExecuteNonQuery();
            olecon.Close();
            gri_bill();
            panel1.Focus();

        }

        private void txt__billnumber_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (e.KeyChar != (char)8 && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_discount_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (e.KeyChar != (char)8 && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void txt_discount_Leave(object sender, EventArgs e)
        {
            //if (txt_discount.Text == "")
            //{
            //    txt_discount.Text = "0";
            //}
        }

        private void txt_paidbill_Leave(object sender, EventArgs e)
        {
            //if (txt_paidbill.Text == "")
            //{
            //    txt_paidbill.Text = "0";
            //}
        }

        private void txt__billnumber_TextChanged(object sender, EventArgs e)
        {
            if (txt__billnumber.Text != "" && txt__billnumber.Text!="0")
            {
                //if (int.Parse(txt__billnumber.Text) == existingbillnumb)
                //{
                //    gridview_bill.Enabled = true;
                //}
            }
            
        }

        private void gridview_bill_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void grid_menu_catagory1_KeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show("gridview1");
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void urduTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            panel1.Focus();
        }

        private void grid_menu_catagory2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            panel1.Focus();
        }

        private void grid_menu_catagory5_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            panel1.Focus();
        }

        private void grid_menu_catagory1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            panel1.Focus();
        }

        private void btn_saveprint_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                panel1.Focus();
            }
        }

        private void checkBox_noprinter_KeyDown(object sender, KeyEventArgs e)
        {
            btn_saveprint_KeyDown( sender,  e);
        }

        private void comboBox_tblnumber_KeyDown(object sender, KeyEventArgs e)
        {
            btn_saveprint_KeyDown(sender, e);
        }

        private void BillScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        private void urduTextBox7_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}
