using NumericKeyPad;
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
using lasticecream.ChayPaniForms;
using System.Threading;

namespace lasticecream
{
    public partial class Digital_Screen : Form
    {
        private TextBox focusedTextbox = null;
        OleDbConnection olecon = new OleDbConnection(ConfigurationManager.ConnectionStrings["Accdbx"].ConnectionString);
        CalculatorForm cform;
        int tablenumber;
        Myclass mc;
        public Digital_Screen()
        {
            InitializeComponent();
            mc = new Myclass();


        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }


        private void Digital_Screen_Load(object sender, EventArgs e)
        {
            //touchScreen1.OnUserControlButtonClicked += new TouchScreen.ButtonClickedEventHandler(touchScreen1_OnUserControlButtonClicked);
            dateTimePicker1.Value = DateTime.Now;
            loadcombobox();
            TabControlMenu.Enabled = false;


            Thread thdUDPServer1 = new Thread(new
                ThreadStart(loadTabs));
            thdUDPServer1.IsBackground = true;
            thdUDPServer1.Start();

            //btn_SelectTable_Click(sender, e);

        }

        private void loadTabs()
        {
            if (InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    tab_1.Text = ((menucatagory)1).ToString();
                    tab_2.Text = ((menucatagory)2).ToString();
                    tab_3.Text = ((menucatagory)3).ToString();
                    tab_4.Text = ((menucatagory)4).ToString();
                    tab_5.Text = ((menucatagory)5).ToString();
                    tab_6.Text = ((menucatagory)6).ToString();
                    tab_7.Text = ((menucatagory)7).ToString();
                    tab_8.Text = ((menucatagory)8).ToString();
                    //Thread.Sleep(10000);
                    Fillgridview_catagory1();
                    Fillgridview_catagory2();
                    Fillgridview_catagory3();
                    Fillgridview_catagory4();
                    Fillgridview_catagory5();
                    Fillgridview_catagory6();
                    Fillgridview_catagory7();
                    Fillgridview_catagory8();


                }));


            }

        }

        private void Fillgridview_catagory1()
        {
            DataTable dt1;
            string querry = "select MenuNumber,menuname,menurate from menuinfo where menutype='" + (menucatagory)1 + "' order by MenuNumber";
            dt1 = mc.fillgidview(querry);
            grid_menu_catagory1.DataSource = dt1;
            //grid_menu_catagory1.Columns[0].HeaderText = "کوڈ";
            //grid_menu_catagory1.Columns[1].HeaderText = "مینیو نام";
            //grid_menu_catagory1.Columns[2].HeaderText = "ریٹ";
            //grid_menu_catagory1.Columns[0].Width = 30;
            //grid_menu_catagory1.Columns[1].Width = 110;
            //grid_menu_catagory1.Columns[2].Width = 50;
            //grid_menu_catagory1.Columns["iPriority"].Visible = false;
            grid_menu_catagory1.ClearSelection();
            olecon.Close();
        }
        private void Fillgridview_catagory2()
        {
            DataTable dt1;
            string querry = "select MenuNumber,menuname,menurate from menuinfo where menutype='" + (menucatagory)2 + "' order by MenuNumber";
            dt1 = mc.fillgidview(querry);
            grid_menu_catagory2.DataSource = dt1;
            //grid_menu_catagory2.Columns[0].HeaderText = "کوڈ";
            //grid_menu_catagory2.Columns[1].HeaderText = "مینیو نام";
            //grid_menu_catagory2.Columns[2].HeaderText = "ریٹ";
            //grid_menu_catagory2.Columns[0].Width = 30;
            //grid_menu_catagory2.Columns[1].Width = 110;
            //grid_menu_catagory2.Columns[2].Width = 50;
            //grid_menu_catagory2.Columns["iPriority"].Visible = false;
            olecon.Close();
        }
        private void Fillgridview_catagory3()
        {
            DataTable dt1;
            string querry = "select MenuNumber,menuname,menurate from menuinfo where menutype='" + (menucatagory)3 + "' order by MenuNumber";
            dt1 = mc.fillgidview(querry);
            grid_menu_catagory3.DataSource = dt1;
            //grid_menu_catagory3.Columns[0].HeaderText = "کوڈ";
            //grid_menu_catagory3.Columns[1].HeaderText = "مینیو نام";
            //grid_menu_catagory3.Columns[2].HeaderText = "ریٹ";
            //grid_menu_catagory3.Columns[0].Width = 30;
            //grid_menu_catagory3.Columns[1].Width = 110;
            //grid_menu_catagory3.Columns[2].Width = 50;
            //grid_menu_catagory3.Columns["iPriority"].Visible = false;
            olecon.Close();
        }
        private void Fillgridview_catagory4()
        {
            DataTable dt1;
            string querry = "select MenuNumber,menuname,menurate from menuinfo where menutype='" + (menucatagory)4 + "' order by MenuNumber";
            dt1 = mc.fillgidview(querry);
            grid_menu_catagory4.DataSource = dt1;
            olecon.Close();
        }
        private void Fillgridview_catagory5()
        {
            DataTable dt1;
            string querry = "select MenuNumber,menuname,menurate from menuinfo where menutype='" + (menucatagory)5 + "' order by MenuNumber";
            dt1 = mc.fillgidview(querry);
            grid_menu_catagory5.DataSource = dt1;
            olecon.Close();
        }
        private void Fillgridview_catagory6()
        {
            DataTable dt1;
            string querry = "select MenuNumber,menuname,menurate from menuinfo where menutype='" + (menucatagory)6 + "' order by MenuNumber";
            dt1 = mc.fillgidview(querry);
            grid_menu_catagory6.DataSource = dt1;
            olecon.Close();
        }
        private void Fillgridview_catagory7()
        {
            DataTable dt1;
            string querry = "select MenuNumber,menuname,menurate from menuinfo where menutype='" + (menucatagory)7 + "' order by MenuNumber";
            dt1 = mc.fillgidview(querry);
            grid_menu_catagory7.DataSource = dt1;


            olecon.Close();
        }
        private void Fillgridview_catagory8()
        {
            DataTable dt1;
            string querry = "select MenuNumber,menuname,menurate from menuinfo where menutype='" + (menucatagory)8 + "' order by MenuNumber";
            dt1 = mc.fillgidview(querry);
            grid_menu_catagory8.DataSource = dt1;
            olecon.Close();
        }


        private void loadcombobox()
        {
            DataSet ds = new DataSet();
            string getEmpSQL = "SELECT Emp_Name FROM Staff where Emp_Designation='Waiter' and [Closed]=" + 0 + " order by ID ";
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

            combo_Waiters.DataSource = ds.Tables[0];
            combo_Waiters.DisplayMember = ds.Tables[0].Columns[0].ToString();
            combo_Waiters.SelectedIndex = 0;
        }

        private void btn_1000_Click(object sender, EventArgs e)
        {
            //openCalculator(btn_1000.Text);
        }

        private void openCalculator(string i)
        {
            try
            {
                string abc;
                cform = new CalculatorForm();
                cform.MenuNumber = i;
                cform.billdate = dateTimePicker1.Value;
                cform.billnumber = int.Parse(txtBillnumber.Text);
                cform.ShowDialog();
                abc = cform.know;
                //findbillnumber();
                //createbillnumber();
                fill_partial_bill();
                //summition();

            }
            catch (Exception es)
            {
                MessageBox.Show(es.ToString());
            }

        }

        private void findbillnumber()
        {
            try
            {
                //DateTime today = DateTime.Today;
                //string tod = today.ToString("dd-MM-yyyy");
                DataSet ds;
                olecon.Open();
                //string sql = "select billnumber from mastebill where [table_no]='" + tablenumber.ToString() + "' and billingdate=#"+ tod +"# and [Complete]=" + '0' + " and [Close]=" + '0' + "  ";
                string sql = "select billnumber,billingdate from mastebill where [table_no]='" + tablenumber.ToString() + "' and [Complete]=" + '0' + " and [Close]=" + '0' + "  ";
                ds = new DataSet("test");
                OleDbDataAdapter DBAdapter = new OleDbDataAdapter();
                DBAdapter.SelectCommand = new OleDbCommand(sql, olecon);
                //ds.Tables["Table"].Clear();
                DBAdapter.Fill(ds);
                olecon.Close();
                if (ds.Tables["Table"].Rows.Count != 0)
                {
                    txtBillnumber.Text = ds.Tables["Table"].Rows[0]["billnumber"].ToString();
                    //sdate = ds.Tables["Table"].Rows[0]["billingdate"].ToString();
                    dateTimePicker1.Value = DateTime.Parse(ds.Tables["Table"].Rows[0]["billingdate"].ToString());
                    sdate = dateTimePicker1.Value.ToString("dd-MM-yyyy");
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

        int billnumber;
        private void createbillnumber()
        {
            try
            {
                dateTimePicker1.Value = DateTime.Today;
                sdate = dateTimePicker1.Value.ToString("MM-dd-yyyy");
                OleDbDataReader dr;
                olecon.Open();
                string query = "select top 1 billnumber  from mastebill where billingdate=#" + sdate + "#  order by billnumber desc";
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
                txtBillnumber.Text = billnumber.ToString();

                //insert record bill number and table number
                string pdatetime = DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");
                string bdate = DateTime.Now.ToString("dd/MM/yyyy");
                String query1 = "insert into mastebill (table_no,billnumber,billamount,billDiscount,grandTotal,paidamount,change,billingdate,printdatetime,deletebill,[Complete],[Close],WaiterName) values ('" + this.txt_tableNumber.Text + "'," + this.txtBillnumber.Text + ",'" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + bdate + "','" + pdatetime + "',1,0,0,'" + this.combo_Waiters.Text + "')";
                OleDbCommand cmd1 = new OleDbCommand(query1, olecon);
                cmd1.ExecuteNonQuery();
                //
                olecon.Close();
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message.ToString());
                return;
            }

        }

        string q;

        public void fill_final_bill()
        {
            DataTable dt;
            Myclass mc = new Myclass();
            sdate = dateTimePicker1.Value.ToString("MM-dd-yyyy");
            q = "select menu_name,menu_qty,menurate,total,detail_bill_id from detailbill where masterbill_id=" + txtBillnumber.Text + " and billingdate=#" + sdate + "# and partialBill=" + 1 + " order by detail_bill_id";
            dt = mc.fillgidview(q);
            grid_finalBill.DataSource = dt;
            grid_finalBill.Columns[0].HeaderText = "ProductName";
            grid_finalBill.Columns[1].HeaderText = "Qty";
            grid_finalBill.Columns[2].HeaderText = "Price";
            grid_finalBill.Columns[3].HeaderText = "Sum";
            grid_finalBill.Columns[0].Width = 110;
            grid_finalBill.Columns[1].Width = 30;
            grid_finalBill.Columns[2].Width = 40;
            grid_finalBill.Columns[3].Width = 40;
            grid_finalBill.Columns["detail_bill_id"].Visible = false;
            grid_finalBill.ClearSelection();
            olecon.Close();
            summition();

        }
        public void fill_partial_bill()
        {

            grid_partialBill.Refresh();
            sdate = dateTimePicker1.Value.ToString("MM-dd-yyyy");
            DataTable dt = new DataTable();
            dt.Clear();
            Myclass mc = new Myclass();
            q = "select menu_name,menu_qty,menurate,total,detail_bill_id from detailbill where masterbill_id=" + txtBillnumber.Text + " and billingdate=#" + sdate + "# and partialBill=" + 0 + "  order by detail_bill_id";
            dt = mc.fillgidview(q);
            grid_partialBill.DataSource = dt;
            grid_partialBill.Columns[0].HeaderText = "ProductName";
            grid_partialBill.Columns[1].HeaderText = "Qty";
            grid_partialBill.Columns[2].HeaderText = "Price";
            grid_partialBill.Columns[3].HeaderText = "Total";
            grid_partialBill.Columns[0].Width = 110;
            grid_partialBill.Columns[1].Width = 30;
            grid_partialBill.Columns[2].Width = 40;
            grid_partialBill.Columns[3].Width = 40;
            grid_partialBill.Columns["menurate"].Visible = false;
            grid_partialBill.Columns["total"].Visible = false;
            grid_partialBill.Columns["detail_bill_id"].Visible = false;
            grid_partialBill.ClearSelection();
            olecon.Close();
            //summition();

        }

        void summition()
        {
            //try
            //{
                float sum = 0;
                foreach (DataGridViewRow row in grid_finalBill.Rows)
                {
                    if (!row.IsNewRow)
                        sum += float.Parse(row.Cells[3].Value.ToString());
                }
                txt_subTotal.Text = sum.ToString();
            //}
            //catch (Exception es)
            //{
            //    MessageBox.Show(es.ToString());
            //}
        }

        private void btn_partialPrint_Click(object sender, EventArgs e)
        {
            if (grid_partialBill.Rows.Count > 0)
            {
                try
                {
                    //show report
                    sdate = dateTimePicker1.Value.ToString("MM-dd-yyyy");
                    billnumber = int.Parse(txtBillnumber.Text);
                    miniReportForm mrf = new miniReportForm(billnumber, sdate);
                    mrf.Show();
                    //
                    //print partial
                    OleDbCommand command = new OleDbCommand(@"UPDATE detailbill SET partialBill = @bamount WHERE masterbill_id = @bnum and billingdate=#" + sdate + "#", olecon);
                    command.Parameters.AddWithValue("@bamount", 1);
                    command.Parameters.AddWithValue("@bnum", txtBillnumber.Text);
                    olecon.Open();
                    command.ExecuteNonQuery();
                    if (olecon.State == ConnectionState.Open)
                    {
                        olecon.Close();
                    }
                }
                catch (Exception es)
                {
                    MessageBox.Show(es.ToString());
                }

                fill_final_bill();
                fill_partial_bill();
            }
        }

        private void btn_SelectTable_Click(object sender, EventArgs e)
        {
            txt_tableNumber.Text = "";
            groupBox4.Enabled = true;
            TabControlMenu.Enabled = true;
            using (var form = new Tables())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    txtBillnumber.Text = "";
                    int val = form.table;
                    tablenumber = val;
                    txt_tableNumber.Text = tablenumber.ToString();
                }
            }

        }

        private void touchScreen1_OnUserControlButtonClicked(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (focusedTextbox != null)
            {
                if (b.Text == "Back")
                {
                    if (focusedTextbox.Text.Length > 1)
                    {
                        focusedTextbox.Text = focusedTextbox.Text.Substring(0, focusedTextbox.Text.Length - 1);
                    }
                    else
                    {
                        focusedTextbox.Text = string.Empty;
                    }
                }
                else
                {
                    if (MyGlobal.bTouch)
                        focusedTextbox.Text = b.Text;
                    else
                    {
                        MyGlobal.bTouch = false;
                        focusedTextbox.Text += b.Text;
                    }
                }
            }
        }

        private void txt_tableNumber_Enter(object sender, EventArgs e)
        {
            focusedTextbox = (TextBox)sender;
        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void txt_tableNumber_TextChanged(object sender, EventArgs e)
        {
            if (txt_tableNumber.Text != "")
            {
                if (grid_finalBill.Visible == false)
                {
                    grid_finalBill.Visible = true;
                    grid_partialBill.Visible = true;
                }
                findbillnumber();
                fill_partial_bill();
                fill_final_bill();
            }

        }

        private void txt_subTotal_TextChanged(object sender, EventArgs e)
        {
            if (txtDiscount.Text != "" && txtServiceCharges.Text != "" && txt_subTotal.Text != "")
            {
                float abc = (float.Parse(txt_subTotal.Text) + float.Parse(txtServiceCharges.Text) - float.Parse(txtDiscount.Text));
                txtTotalBill.Text = ((int)Math.Round(abc)).ToString();
            }
            else if (txtDiscount.Text == "")
            {
                float abc = (float.Parse(txt_subTotal.Text) + float.Parse(txtServiceCharges.Text));
                txtTotalBill.Text = ((int)Math.Round(abc)).ToString();
            }
            else if (txtServiceCharges.Text == "")
            {
                float abc = (float.Parse(txt_subTotal.Text) - float.Parse(txtDiscount.Text));
                txtTotalBill.Text = ((int)Math.Round(abc)).ToString();
            }

            textBox4_TextChanged(sender, e);
            txtDiscountPercent_TextChanged(sender, e);
        }

        private void txtServiceCharges_TextChanged(object sender, EventArgs e)
        {
            if (txt_subTotal.Text != "" && txtServiceCharges.Text!="")
            {
                if (txtDiscount.Text != "")
                {
                    float abc = (float.Parse(txtServiceCharges.Text) + float.Parse(txt_subTotal.Text) - float.Parse(txtDiscount.Text));
                    txtTotalBill.Text = ((int)Math.Round(abc)).ToString();
                }
                else
                {
                    float abc = (float.Parse(txtServiceCharges.Text) + float.Parse(txt_subTotal.Text) );
                    txtTotalBill.Text = ((int)Math.Round(abc)).ToString();
                }
                
            }
            else if (txtServiceCharges.Text == "" && txt_subTotal.Text != "")
            {
                if (txtDiscount.Text != "")
                {
                    float abc = float.Parse(txt_subTotal.Text) - float.Parse(txtDiscount.Text);
                    txtTotalBill.Text = ((int)Math.Round(abc)).ToString();
                }
                else
                {
                    float abc = float.Parse(txt_subTotal.Text);
                    txtTotalBill.Text = ((int)Math.Round(abc)).ToString();
                }
                
            }
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            if (txt_subTotal.Text != "" && txtDiscount.Text != "")
            {
                if (txtServiceCharges.Text != "")
                {
                    float abc = ((float.Parse(txt_subTotal.Text) - float.Parse(txtDiscount.Text)) + float.Parse(txtServiceCharges.Text));
                    txtTotalBill.Text = ((int)Math.Round(abc)).ToString();
                }
                else
                {
                    float abc = ((float.Parse(txt_subTotal.Text) - float.Parse(txtDiscount.Text)) );
                    txtTotalBill.Text = ((int)Math.Round(abc)).ToString();
                }
                
            }
            else if (txtDiscount.Text == "" && txt_subTotal.Text != "")
            {
                if (txtServiceCharges.Text != "")
                {
                    float abc = (float.Parse(txtServiceCharges.Text) + float.Parse(txt_subTotal.Text));
                    txtTotalBill.Text = ((int)Math.Round(abc)).ToString();
                }
                else
                {
                    float abc =  float.Parse(txt_subTotal.Text);
                    txtTotalBill.Text = ((int)Math.Round(abc)).ToString();
                }
            }

        }

        private void tab_1_Click(object sender, EventArgs e)
        {

        }

        private void grid_menu_catagory5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView8_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void grid_menu_catagory1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string menuNumber = grid_menu_catagory1.Rows[e.RowIndex].Cells[0].Value.ToString();
            //txt_menuid.Text = menuNumber;
            search_HightlightRow(int.Parse(menuNumber));
            openCalculator(menuNumber);
        }

        private void grid_menu_catagory2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string menuNumber = grid_menu_catagory2.Rows[e.RowIndex].Cells[0].Value.ToString();
            //txt_menuid.Text = menuNumber;
            //search_HightlightRow(int.Parse(menuNumber));
            openCalculator(menuNumber);
        }

        private void grid_menu_catagory3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string menuNumber = grid_menu_catagory3.Rows[e.RowIndex].Cells[0].Value.ToString();
            //txt_menuid.Text = menuNumber;
            //search_HightlightRow(int.Parse(menuNumber));
            openCalculator(menuNumber);
        }

        private void grid_menu_catagory4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string menuNumber = grid_menu_catagory4.Rows[e.RowIndex].Cells[0].Value.ToString();
            //txt_menuid.Text = menuNumber;
            //search_HightlightRow(int.Parse(menuNumber));
            openCalculator(menuNumber);
        }

        private void grid_menu_catagory5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string menuNumber = grid_menu_catagory5.Rows[e.RowIndex].Cells[0].Value.ToString();
            //txt_menuid.Text = menuNumber;
            //search_HightlightRow(int.Parse(menuNumber));
            openCalculator(menuNumber);
        }

        private void grid_menu_catagory6_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string menuNumber = grid_menu_catagory6.Rows[e.RowIndex].Cells[0].Value.ToString();
            //txt_menuid.Text = menuNumber;
            //search_HightlightRow(int.Parse(menuNumber));
            openCalculator(menuNumber);
        }

        private void grid_menu_catagory7_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string menuNumber = grid_menu_catagory7.Rows[e.RowIndex].Cells[0].Value.ToString();
            //txt_menuid.Text = menuNumber;
            //search_HightlightRow(int.Parse(menuNumber));
            openCalculator(menuNumber);
        }

        private void grid_menu_catagory8_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string menuNumber = grid_menu_catagory8.Rows[e.RowIndex].Cells[0].Value.ToString();
            //txt_menuid.Text = menuNumber;
            //search_HightlightRow(int.Parse(menuNumber));
            openCalculator(menuNumber);
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
        string sdate = "";
        private void btnPrintBill_Click(object sender, EventArgs e)
        {
            if (grid_finalBill.Rows.Count > 0)
            {
                //int amount = int.Parse(txtTotalBill.Text);
                if (txtTotalBill.Text != "" && txtBillnumber.Text != "0" && float.Parse(txtTotalBill.Text) > 0)
                {
                    //try
                    //{
                        btnPrintBill.FlatStyle = FlatStyle.Flat;
                        //btnPrintBill.BackColor = Color.GreenYellow;
                        string pdatetime = DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");
                        //    DateTime date =DateTime.Parse( dateTimePicker1.Text);
                        //sdate = date.ToString("dd-MM-yyyy");
                        sdate = dateTimePicker1.Value.ToString("MM-dd-yyyy");
                        btnPrintBill.FlatStyle = FlatStyle.Standard;
                        OleDbCommand olecmd = new OleDbCommand();
                        DataSet ds;
                        string sql = "select billnumber from mastebill where billnumber=" + txtBillnumber.Text + " and billingdate=#" + sdate + "# ";
                        olecmd = new OleDbCommand(sql, olecon);
                        olecon.Open();
                        olecmd.ExecuteNonQuery();
                        OleDbDataAdapter adapt = new OleDbDataAdapter(sql, olecon);
                        ds = new DataSet("test");
                        adapt.Fill(ds, "test");
                        olecon.Close();
                        if (ds.Tables["test"].Rows.Count == 1)
                        {
                            //int tbil = int.Parse(txtTotalBill.Text);
                            //OleDbCommand command = new OleDbCommand(@"UPDATE mastebill SET billamount = @bamount,serviceCharges=@Scharge  WHERE billnumber = @bnum and billingdate=#" + sdate+"#", olecon);
                            OleDbCommand command = new OleDbCommand(@"UPDATE mastebill SET billamount = @bamount,serviceCharges=@Scharge,billDiscount=@Disc, billingdate = @bdate, printdatetime = @pdate, [Complete]=@com WHERE billnumber = @bnum and billingdate=#"+sdate+"#", olecon);
                            //command.Parameters.AddWithValue("@bamount", txtTotalBill.Text);
                            command.Parameters.AddWithValue("@bamount", txtTotalBill.Text);
                            command.Parameters.AddWithValue("@Scharge", txtServiceCharges.Text);
                            command.Parameters.AddWithValue("@Disc", txtDiscount.Text);
                            command.Parameters.AddWithValue("@bdate", DateTime.Now.ToString("dd-MM-yyyy"));
                            command.Parameters.AddWithValue("@pdate", DateTime.Now.ToString("dd/MM/yyyy hh:mm tt"));
                            command.Parameters.AddWithValue("@com", 1);
                            command.Parameters.AddWithValue("@bnum", txtBillnumber.Text);
                            olecon.Open();
                            command.ExecuteNonQuery();
                            if (olecon.State == ConnectionState.Open)
                            {
                                olecon.Close();
                            }
                            int bill = int.Parse(txtBillnumber.Text);
                            if (checkBoxNoPrinter.Checked != true)
                            {
                                Report rep = new Report(bill, sdate);
                                rep.Duplication = "";

                                rep.print = 0;
                                rep.Show();
                            }

                            grid_finalBill.DataSource = null;
                            grid_partialBill.DataSource = null;
                            // dt_bill.Clear();


                            //indexbill = 0;

                            //createbillnumber();
                            //this.Close();
                            btnPrintBill.FlatStyle = FlatStyle.Standard;
                            TabControlMenu.Enabled = false;
                            txt_tableNumber.Text = "";
                            txt_subTotal.Text = "";
                            txtServiceCharges.Text = "";
                            txtTotalBill.Text = "0";
                            txtDiscount.Text = "0";
                            //btn_SelectTable_Click(sender, e);
                            //btn_saveprint.BackColor = Color.GreenYellow;
                            //panel1.Focus();
                        }
                        else
                        {
                            MessageBox.Show("Duplicate Bill number or No Record Found.");
                        }
                    //}
                    //catch (Exception es)
                    //{
                    //    MessageBox.Show(es.Message);
                    //    if (olecon.State == ConnectionState.Open)
                    //    {
                    //        olecon.Close();
                    //    }
                    //}
                }
                else
                {
                    MessageBox.Show("Fill All Fields.");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ViewAbill vb = new ViewAbill();
            vb.Show();
        }

        private void Digital_Screen_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnAnalysisReport_Click(object sender, EventArgs e)
        {
            AnalysisForm af = new AnalysisForm();
            af.Show();
        }

        private void btnMenuInquiry_Click(object sender, EventArgs e)
        {
            additems ai = new additems();
            ai.Show();
        }

        private void combo_Waiters_Leave(object sender, EventArgs e)
        {
            olecon.Open();
            sdate = dateTimePicker1.Value.ToString("MM-dd-yyyy");
            OleDbCommand command = new OleDbCommand(@"UPDATE mastebill SET [WaiterName]=@com WHERE billnumber = @bnum and billingdate=#" + sdate + "#", olecon);
            command.Parameters.AddWithValue("@com", combo_Waiters.Text);
            command.Parameters.AddWithValue("@bnum", txtBillnumber.Text);

            command.ExecuteNonQuery();
            if (olecon.State == ConnectionState.Open)
            {
                olecon.Close();
            }

        }

        private void grid_menu_catagory5_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button26_Click(object sender, EventArgs e)
        {
            openCalculator("69");
        }

        private void button27_Click(object sender, EventArgs e)
        {
            openCalculator("70");

        }

        private void button28_Click(object sender, EventArgs e)
        {
            openCalculator("71");

        }

        private void button29_Click(object sender, EventArgs e)
        {
            openCalculator("72");

        }

        private void button30_Click(object sender, EventArgs e)
        {
            openCalculator("73");

        }

        private void button31_Click(object sender, EventArgs e)
        {
            openCalculator("74");

        }

        private void button32_Click(object sender, EventArgs e)
        {
            openCalculator("75");

        }

        private void button33_Click(object sender, EventArgs e)
        {
            openCalculator("76");

        }

        private void button34_Click(object sender, EventArgs e)
        {
            openCalculator("77");

        }

        private void btnDailySale_Click(object sender, EventArgs e)
        {
            Ledger lg = new Ledger();
            lg.Show();
        }

        private void grid_partialBill_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string menunaem = (grid_partialBill.Rows[e.RowIndex].Cells[0].Value.ToString());
            sdate = dateTimePicker1.Value.ToString("MM-dd-yyyy");
            OleDbCommand olcmd = new OleDbCommand("delete * from detailbill where menu_name=@id and billingdate=#" + sdate + "#  and masterbill_id=@bid and  partialBill=" + 0 + "", olecon);
            olecon.Open();
            olcmd.Parameters.AddWithValue("@id", menunaem);
            olcmd.Parameters.AddWithValue("@bid", txtBillnumber.Text);
            olcmd.ExecuteNonQuery();
            olecon.Close();
            fill_partial_bill();
            //gri_bill();
            //panel1.Focus();
        }

        private void grid_finalBill_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                string menunaem = (grid_finalBill.Rows[e.RowIndex].Cells[0].Value.ToString());
                sdate = dateTimePicker1.Value.ToString("MM-dd-yyyy");
                OleDbCommand olcmd = new OleDbCommand("delete * from detailbill where menu_name=@id and billingdate=#" + sdate + "#  and masterbill_id=@bid and  partialBill=" + 1 + "", olecon);
                olecon.Open();
                olcmd.Parameters.AddWithValue("@id", menunaem);
                olcmd.Parameters.AddWithValue("@bid", txtBillnumber.Text);
                olcmd.ExecuteNonQuery();
                olecon.Close();
                fill_final_bill();
            }
            catch (Exception es)
            {
                MessageBox.Show("Exception on Deleting Record: " + es.Message);
            }
        }

        private void btnCloseBill_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTotalBill.Text =="")
                {
                    txtTotalBill.Text = "0";
                }
                btnCloseBill.FlatStyle = FlatStyle.Flat;
                string pdatetime = DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");
                sdate = dateTimePicker1.Value.ToString("MM-dd-yyyy");
                btnCloseBill.FlatStyle = FlatStyle.Standard;

                OleDbCommand command = new OleDbCommand(@"UPDATE mastebill SET billamount = @bamount, printdatetime = @pdate, [Close]=@com WHERE billnumber = @bnum and billingdate=#" + sdate + "#", olecon);

                command.Parameters.AddWithValue("@bamount", txtTotalBill.Text);
                //command.Parameters.AddWithValue("@bdate", DateTime.Now.ToString("dd-MM-yyyy"));
                command.Parameters.AddWithValue("@pdate", DateTime.Now.ToString("dd/MM/yyyy hh:mm tt"));
                command.Parameters.AddWithValue("@com", 1);
                command.Parameters.AddWithValue("@bnum", txtBillnumber.Text);
                olecon.Open();
                command.ExecuteNonQuery();
                if (olecon.State == ConnectionState.Open)
                {
                    olecon.Close();
                }

                string msg = "BillNumber:"+txtBillnumber.Text+":TableNumber:"+txt_tableNumber.Text+":sDate:"+sdate+": are Closed by user.";
                mc.updateLog(msg);
                
                grid_finalBill.DataSource = null;
                grid_partialBill.DataSource = null;
                txtTotalBill.Text = "";
                btnPrintBill.FlatStyle = FlatStyle.Standard;
                TabControlMenu.Enabled = false;
                txt_tableNumber.Text = "";
            }

            catch (Exception es)
            {
                MessageBox.Show(es.Message);
                if (olecon.State == ConnectionState.Open)
                {
                    olecon.Close();
                }
            }
        }

        private void txtPartyName_Leave(object sender, EventArgs e)
        {
            olecon.Open();
            sdate = dateTimePicker1.Value.ToString("MM-dd-yyyy");
            OleDbCommand command = new OleDbCommand(@"UPDATE mastebill SET [PartyName]=@com WHERE billnumber = @bnum and billingdate=#" + sdate + "#", olecon);
            command.Parameters.AddWithValue("@com", txtPartyName.Text);
            command.Parameters.AddWithValue("@bnum", txtBillnumber.Text);

            command.ExecuteNonQuery();
            if (olecon.State == ConnectionState.Open)
            {
                olecon.Close();
            }
        }

        private void txtServiceCharges_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (e.KeyChar != (char)8 && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (e.KeyChar != (char)8 && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (e.KeyChar != (char)8 && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtDiscountPercent_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (e.KeyChar != (char)8 && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtDiscountPercent_TextChanged(object sender, EventArgs e)
        {
            if(txtDiscountPercent.Text!="" && txt_subTotal.Text != "")
            {
                //percentage = (yourNumber / totalNumber) * 100;
                //number = (percentage / 100) * totalNumber;
                float dp = float.Parse(txtDiscountPercent.Text);
                float total = float.Parse(txt_subTotal.Text);
                float discout = (dp/100)*total;
                string disc = discout.ToString("0.00");
                txtDiscount.Text = disc;
            }
            else if (txtDiscountPercent.Text == "")
            {
                txtDiscount.Text = "0";
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text != "" && txt_subTotal.Text != "")
            {
                //percentage = (yourNumber / totalNumber) * 100;
                //number = (percentage / 100) * totalNumber;
                float dp = float.Parse(textBox4.Text);
                float total = float.Parse(txt_subTotal.Text);
                float discout = (dp / 100) * total;
                string disc = discout.ToString("0.00");
                txtServiceCharges.Text = disc;
            }
            else if (textBox4.Text == "")
            {
                txtServiceCharges.Text = "0";
            }
        }

        private void combo_Waiters_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            loadcombobox();
            Fillgridview_catagory1();
            Fillgridview_catagory2();
            Fillgridview_catagory3();
            Fillgridview_catagory4();
            Fillgridview_catagory5();
            Fillgridview_catagory6();
            Fillgridview_catagory7();
            Fillgridview_catagory8();
        }

        private void txtPartyName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
