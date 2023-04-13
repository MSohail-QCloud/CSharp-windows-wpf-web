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
    public partial class ViewAbill : Form
    {
        OleDbConnection olecon = new OleDbConnection(ConfigurationManager.ConnectionStrings["Accdbx"].ConnectionString);

        public int billnumber { get; set; }
        Myclass mc = new Myclass();
        public ViewAbill()
        {
           // billnumber = billnumbe;
            InitializeComponent();
        }

        private void ViewAbill_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            if (billnumber != 0)
            {
                txt__billnumber.Text = billnumber.ToString();
                gri_bill();
                //loadbill();
            }

            //loadcombobox();
        }

        //private void loadcombobox()
        //{

        //    DataSet ds = new DataSet();
        //    string getEmpSQL = "SELECT table_no FROM tableinfo order by tableid ;";
        //    OleDbDataAdapter sda = new OleDbDataAdapter(getEmpSQL, olecon);

        //    try
        //    {
        //        olecon.Open();
        //        sda.Fill(ds);
        //    }
        //    catch (Exception se)
        //    {
        //        MessageBox.Show("An error occured while connecting to database" + se.ToString());
        //    }
        //    finally
        //    {
        //        olecon.Close();
        //    }

        //    comboBox_tblnumber.DataSource = ds.Tables[0];
        //    comboBox_tblnumber.DisplayMember = ds.Tables[0].Columns[0].ToString();

        //}
        string dtimes="";
        private void loadbill()
        {
            string q;
            DataTable dt;
            DateTime dtime =DateTime.Parse( dateTimePicker1.Text);
            dtimes = dtime.ToString("MM-dd-yyyy");
            q = "select menu_qty,menu_name,menurate,total,detail_bill_id from detailbill where masterbill_id=" + txt__billnumber.Text + " and billingdate=#"+dtimes+"# order by detail_bill_id";
            dt = mc.fillgidview(q);
            gridview_bill.DataSource = dt;
            gridview_bill.Columns[0].HeaderText = "Qty";
            gridview_bill.Columns[1].HeaderText = "Menu";
            gridview_bill.Columns[2].HeaderText = "Rate";
            gridview_bill.Columns[3].HeaderText = "Total";
            gridview_bill.Columns[0].Width = 20;
            gridview_bill.Columns[1].Width = 120;
            gridview_bill.Columns[2].Width = 30;
            gridview_bill.Columns[3].Width = 40;
            //gridview_bill.Columns["detail_bill_id"].Visible = false;
            gridview_bill.Columns["detail_bill_id"].Visible = false;

            DataSet ds;
            string sql = "select table_no,billamount,WaiterName,PartyName,serviceCharges,billDiscount,[Complete],[Close],[deletebill] from mastebill where [billnumber]=" + txt__billnumber.Text.ToString() + " and billingdate=#"+dtimes+"# ";
            ds = new DataSet("test");
            OleDbDataAdapter DBAdapter = new OleDbDataAdapter();
            DBAdapter.SelectCommand = new OleDbCommand(sql, olecon);
            //ds.Tables["Table"].Clear();
            DBAdapter.Fill(ds);
            olecon.Close();
            if (ds.Tables["Table"].Rows.Count > 0)
            {
                txt_tableNumber.Text = ds.Tables["Table"].Rows[0]["table_no"].ToString();
                txtPartyName.Text = ds.Tables["Table"].Rows[0]["PartyName"].ToString();
               txtWaiterName.Text = ds.Tables["Table"].Rows[0]["WaiterName"].ToString();
                txt_totalbill.Text = ds.Tables["Table"].Rows[0]["billamount"].ToString();
                txtServiceCharges.Text = ds.Tables["Table"].Rows[0]["serviceCharges"].ToString();
                txtDiscount.Text = ds.Tables["Table"].Rows[0]["billDiscount"].ToString();
                string Complete = ds.Tables["Table"].Rows[0]["Complete"].ToString();
                string clos = ds.Tables["Table"].Rows[0]["Close"].ToString();
                string delete= ds.Tables["Table"].Rows[0]["deletebill"].ToString();

                if (Complete == "1" && clos=="0" && delete == "1")
                {
                    lblStatus.Text = "Completed";
                }
                else if(Complete == "0" && clos == "1" && delete == "1")
                {
                    lblStatus.Text = "Forcly Closed";
                }
                else if ( delete == "0")
                {
                    lblStatus.Text = "Deleted";
                }
                else
                {
                    lblStatus.Text = "Not-Confirmed or In Process";
                }
                gridview_bill.ClearSelection();
                olecon.Close();
                summition();
            }
            else
            {
                lblStatus.Text = "Invoice not generated.";
            }
            
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
        private void txt__billnumber_KeyDown(object sender, KeyEventArgs e)
        {
            //if (txt__billnumber.Text != "")
            //{
            //    if (e.KeyCode == Keys.D)
            //    {
            //        int billcount = checkbillnumber();
            //        if (billcount == 1)
            //        {
            //            bill = int.Parse(txt__billnumber.Text);
            //            Report rep = new Report(bill);
            //            rep.Duplication = "Duplicate Bill";
            //            rep.Show();
            //        }
            //        else
            //        {
            //            MessageBox.Show("Bill number " + txt__billnumber.Text + " not found.");
            //        }

            //    }
            //    if (e.KeyCode == Keys.Enter)
            //    {
            //        int checkbill = checkbillnumber();
            //        if (checkbill == 1)
            //        {
            //            loadExistingBill();
            //        }
            //        else
            //        {
            //            MessageBox.Show("Bill number " + txt__billnumber.Text + " not Found.");
            //            txt__billnumber.Text = "";
            //            gridview_bill.DataSource = null;
            //            dt.Clear();
            //            //comboBox_tblnumber.Text = "";
            //            txt_cange.Text = "0";
            //            txt_discount.Text = "0";
            //            txt_grandtotal.Text = "";
            //            txt_paidbill.Text = "0";
            //            txt_totalbill.Text = "";
            //            txt__billnumber.Focus();
            //        }
            //    }
            //}
            
        }
        private int checkbillnumber()
        {
            if (txt__billnumber.Text != "")
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
            else
            {
                return 0;
            }


        }
        int bill = 0;
        int existingbillnumb = 0;
        db dblayer = new db();
        private void loadExistingBill()
        {
            existingbillnumb = int.Parse(txt__billnumber.Text);
            gridview_bill.Enabled = false;
            gri_bill();
        }
        string q = "";
        DataTable dt=new DataTable();
        private void gri_bill()
        {

            //q = "select menu_qty,menu_name,menurate,total,detail_bill_id from detailbill where masterbill_id=" + txt__billnumber.Text + "  order by detail_bill_id";
            q = "select dt.menu_qty,dt.menu_name,dt.menurate,dt.total,dt.detail_bill_id,mb.table_no,mb.billamount,mb.billDiscount,mb.grandTotal,mb.paidamount,mb.change from detailbill dt  inner join mastebill mb on mb.billnumber=dt.masterbill_id where mb.billnumber=" + txt__billnumber.Text + " and mb.deletebill=1";
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
                gridview_bill.Columns["billamount"].Visible = false;
                gridview_bill.Columns["billDiscount"].Visible = false;
                gridview_bill.Columns["grandTotal"].Visible = false;
                gridview_bill.Columns["paidamount"].Visible = false;
                gridview_bill.Columns["change"].Visible = false;
                //comboBox_tblnumber.Text = gridview_bill.Rows[0].Cells["table_no"].Value.ToString();
                txt_totalbill.Text = gridview_bill.Rows[0].Cells["billamount"].Value.ToString();
                txt_discount.Text = gridview_bill.Rows[0].Cells["billDiscount"].Value.ToString();
                txt_grandtotal.Text = gridview_bill.Rows[0].Cells["grandTotal"].Value.ToString();
                txt_paidbill.Text = gridview_bill.Rows[0].Cells["paidamount"].Value.ToString();
                txt_cange.Text = gridview_bill.Rows[0].Cells["change"].Value.ToString();
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
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (txt__billnumber.Text != "")
            {
                try
                {
                    string sdate = dateTimePicker1.Value.ToString("dd-MM-yyyy");
                    OleDbCommand command = new OleDbCommand(@"UPDATE mastebill  SET deletebill = @titl WHERE billnumber =@bl and billingdate=#"+sdate+"#  ", olecon);

                    command.Parameters.AddWithValue("@titl", '0');
                    command.Parameters.AddWithValue("@bl", txt__billnumber.Text);

                    olecon.Open();
                    command.ExecuteNonQuery();
                    olecon.Close();
                    string msg = "BillNumber:" + txt__billnumber.Text + ":sDate:" + sdate + ": are Deleted by user.";

                    mc.updateLog(msg);
                    txt__billnumber.Text = "";

                    gridview_bill.DataSource = null;
                    dt.Clear();
                    //comboBox_tblnumber.Text = "";
                    txt_cange.Text = "0";
                    txt_discount.Text = "0";
                    txt_grandtotal.Text = "";
                    txt_paidbill.Text = "0";
                    txt_totalbill.Text = "";

                    
                }
                catch (Exception es)
                {
                    MessageBox.Show(es.ToString());
                }
                
            }
            else
            {
                MessageBox.Show("ڈیلیٹ کرنےکیلئے ریکارڈ سیلیکٹ کریں۔");
            }
        }

        private void txt__billnumber_TextChanged(object sender, EventArgs e)
        {
            dtimes = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            lblStatus.Text = "";
            txtPartyName.Text = "";
            txt_tableNumber.Text = "";
            txt_totalbill.Text = "";
            txtWaiterName.Text = "";
            lblStatus.Visible = true;
            if (txt__billnumber.Text != "")
            {
                loadbill();
            }
            else
            {
                MessageBox.Show("Enter Bill Number.");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //duplicate bill
            if (dtimes != "" && txt__billnumber.Text!="")
            {
                string sdate = dateTimePicker1.Value.ToString("dd-MM-yyyy");
                bill = int.Parse(txt__billnumber.Text);
                Report rep = new Report(bill, dtimes);
                rep.Duplication = "Duplicate";

                rep.print = 1;
                rep.Show();

                string msg = "BillNumber:" + txt__billnumber.Text + ":sDate:" + sdate + ": duplicate print by user.";
                mc.updateLog(msg);
            }
            else
            {
                MessageBox.Show("View Bill and then click on Duplicate to print Duplicate Bill.");
            }


            //Report rep = new Report(bill, sdate);
            //rep.Duplication = "";

            //rep.print = 1;
            //rep.Show();
        }
    }
}
