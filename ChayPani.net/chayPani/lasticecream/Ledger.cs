using CrystalDecisions.CrystalReports.Engine;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace lasticecream
{
    public partial class Ledger : Form
    {
        OleDbConnection olecon = new OleDbConnection(ConfigurationManager.ConnectionStrings["Accdbx"].ConnectionString);

        public Ledger()
        {
            InitializeComponent();
        }

        private void Ledger_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            datepickerTo.MaxDate = DateTime.Today;
            datepickerTo.Value = DateTime.Today;
            datepicker_from.MaxDate = DateTime.Today;
            datepicker_from.Value = DateTime.Today;
            //loadcomboboxTablenumber();
            //combo_Billnumber.Items.Add("All");
            //combo_tablenumber.Items.Add("All");
            //if(combo_Billnumber.Items.Count >  0)
            //{
            //    combo_Billnumber.SelectedIndex = 0;
            //}
            if(combo_tablenumber.Items.Count > 0 )
            {
                combo_tablenumber.SelectedIndex = 0;
            }
        }

        private void loadcomboboxBillnumber()
        {

            DataSet ds = new DataSet();
            string getEmpSQL = "SELECT billnumber FROM mastebill order by billnumber ;";
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

            combo_Billnumber.DataSource = ds.Tables[0];
            combo_Billnumber.DisplayMember = ds.Tables[0].Columns[0].ToString();

        }
        private void loadcomboboxTablenumber()
        {

            DataSet ds = new DataSet();
            string getEmpSQL = "SELECT table_no FROM tableinfo order by tableid ;";
            OleDbDataAdapter sda = new OleDbDataAdapter(getEmpSQL, olecon);

            try
            {
                if (olecon.State != ConnectionState.Open)
                {
                    olecon.Open();
                }
                
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

            combo_tablenumber.DataSource = ds.Tables[0];
            combo_tablenumber.DisplayMember = ds.Tables[0].Columns[0].ToString();

        }

        private void combo_tablenumber_DropDownClosed(object sender, EventArgs e)
        {
           
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
        }
        string dtfrom = "";
        string dtto = "";
        private void loadgrid(string q)
        {
            //if (combo_Billnumber.Text != "" && combo_tablenumber.Text != "")
            {
                try
                {
                    
                    //string query = "select billingdate, table_no,billnumber,billamount,paidamount,change from mastebill where table_no='" + combo_tablenumber.Text.ToString() + "' and billnumber=" + int.Parse(combo_Billnumber.Text.ToString()) + " and billingdate between #" + dtfrom + "# and #" + dtto + "#  order by billnumber";
                    if (olecon.State != ConnectionState.Open)
                    {
                        olecon.Open();
                    }
                    
                    DataTable dt1 = new DataTable();
                    dt1.Clear();
                    OleDbDataAdapter oleadapt = new OleDbDataAdapter(q, olecon);
                    oleadapt.Fill(dt1);
                    oleadapt.Dispose();
                    gridview_data.DataSource = dt1;
                    //gridview_data.Columns[0].HeaderText = "تاریخ";
                    //gridview_data.Columns[1].HeaderText = "ٹیبل نمبر";
                    //gridview_data.Columns[2].HeaderText = "بل نمبر";
                    //gridview_data.Columns[3].HeaderText = "بل رقم";
                    //gridview_data.Columns[4].HeaderText = "ڈسکاوئنٹ";
                    //gridview_data.Columns[5].HeaderText = "گرینڈٹوٹل";
                    //gridview_data.Columns[6].HeaderText = "رقم وصول";
                    //gridview_data.Columns[7].HeaderText = "چینج";
                    //gridview_data.ClearSelection();
                    gridview_data.Refresh();
                    summition();
                }
                catch(Exception es)
                {
                    MessageBox.Show(es.Message.ToString());
                }
                finally
                {
                    olecon.Close();
                }
                
            }
        }

        void summition()
        {
            int totalbill = 0;
            int discount = 0;
            int grandtotal = 0;
            int paidamount = 0;
            int change = 0;
            foreach (DataGridViewRow row in gridview_data.Rows)
            {
                if (!row.IsNewRow)
                    totalbill += Convert.ToInt32(row.Cells[3].Value.ToString());
                    //discount += Convert.ToInt32(row.Cells[4].Value.ToString());
                    //grandtotal += Convert.ToInt32(row.Cells[5].Value.ToString());
                    //paidamount += Convert.ToInt32(row.Cells[6].Value.ToString());
                    //change += Convert.ToInt32(row.Cells[7].Value.ToString());
            }


            txt_totalamount.Text = totalbill.ToString();
            txt_dscount.Text = discount.ToString();
            txt_grnadtotal.Text = grandtotal.ToString();
            txt_paidamount.Text = paidamount.ToString();
            txt_changeReturn.Text = change.ToString();
        }

        private void combo_Billnumber_SelectedIndexChanged(object sender, EventArgs e)
        {

            string query = "select billingdate, table_no, billnumber, billamount,billDiscount,grandTotal, paidamount, change from mastebill where  billnumber = " + int.Parse(combo_Billnumber.Text.ToString()) + " and deletebill=1  order by billnumber";
            loadgrid(query);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void combo_tablenumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string query = "select billingdate, table_no, billnumber, billamount,billDiscount,grandTotal, paidamount, change from mastebill where table_no = '" + combo_tablenumber.Text.ToString() + "' and deletebill=1    order by billnumber";
            //loadgrid(query);
        }
        
        private void btn_execute_time_Click(object sender, EventArgs e)
        {
            dtfrom = datepicker_from.Value.ToString("MM-dd-yyyy");
            dtto = datepickerTo.Value.ToString("MM-dd-yyyy");
            string query = "select billingdate, table_no, billnumber, billamount,WaiterName,printdatetime from mastebill where billingdate between #" + dtfrom + "# and #" + dtto + "#  and deletebill=1    order by billnumber";
             loadgrid(query);

            //if (chk_billnumbe.Checked!=true && chk_tablnumber.Checked!=true)
            //{
            //    string query = "select billingdate, table_no, billnumber, billamount,billDiscount,grandTotal, paidamount, change from mastebill where billingdate between #" + dtfrom + "# and #" + dtto + "#  and deletebill=1    order by billnumber";
            //    loadgrid(query);
            //}
            //else if(chk_billnumbe.Checked == true && chk_tablnumber.Checked == false)
            //{
            //    string query = "select billingdate, table_no,billnumber,billamount,billDiscount,grandTotal,paidamount,change from mastebill where  billnumber=" + int.Parse(combo_Billnumber.Text.ToString()) + " and billingdate between #" + dtfrom + "# and #" + dtto + "# and deletebill=1    order by billnumber";
            //    loadgrid(query);
            //}
            //else if (chk_billnumbe.Checked == false && chk_tablnumber.Checked == true)
            //{
            //    string query = "select billingdate, table_no,billnumber,billamount,billDiscount,grandTotal,paidamount,change from mastebill where table_no='" + combo_tablenumber.Text.ToString() + "' and billingdate between #" + dtfrom + "# and #" + dtto + "#  and deletebill=1   order by billnumber";
            //    loadgrid(query);
            //}
            //else if (chk_billnumbe.Checked != false && chk_tablnumber.Checked != false)
            //{
            //    string query = "select billingdate, table_no,billnumber,billamount,billDiscount,grandTotal,paidamount,change from mastebill where table_no='" + combo_tablenumber.Text.ToString() + "' and billnumber=" + int.Parse(combo_Billnumber.Text.ToString()) + " and billingdate between #" + dtfrom + "# and #" + dtto + "#  and deletebill=1   order by billnumber";
            //    loadgrid(query);
            //}

        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {

                string query = "select billingdate, table_no,billnumber,billamount,billDiscount,grandTotal,paidamount,change from mastebill  where deletebill=1   order by billnumber";
                    if (olecon.State != ConnectionState.Open)
                    {
                        olecon.Open();
                    }

                    DataTable dt1 = new DataTable();
                    dt1.Clear();
                    OleDbDataAdapter oleadapt = new OleDbDataAdapter(query, olecon);
                    oleadapt.Fill(dt1);
                    oleadapt.Dispose();
                    gridview_data.DataSource = dt1;
                    gridview_data.Columns[0].HeaderText = "تاریخ";
                    gridview_data.Columns[1].HeaderText = "ٹیبل نمبر";
                    gridview_data.Columns[2].HeaderText = "بل نمبر";
                    gridview_data.Columns[3].HeaderText = "بل رقم";
                    gridview_data.Columns[4].HeaderText = "ڈسکاوئنٹ";
                    gridview_data.Columns[5].HeaderText = "گرینڈٹوٹل";
                    gridview_data.Columns[6].HeaderText = "رقم وصول";
                    gridview_data.Columns[7].HeaderText = "چینج";
                    gridview_data.ClearSelection();
                    gridview_data.Refresh();
                    summition();
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message.ToString());
            }
            finally
            {
                olecon.Close();
            }

        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            //Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
            //PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream("d:\\Test.pdf", FileMode.Create));

            //doc.Open();//Open Document to write


            //Paragraph paragraph = new Paragraph("data Exported From DataGridview!");

            ////Create table by setting table value

            //Table t1 ;
            //DataTable dt = (DataTable)dataGridView1.DataSource;

            ////Create Table Header

            //Cell cid = new Cell("ID");
            //Cell cname = new Cell("Name");

            //t1.AddCell(cid);
            //t1.AddCell(cname);

            //foreach (DataGridViewRow rows in dataGridView1.Rows)
            //{

            //    string id = dataGridView1.Rows[rows.Index].Cells["empid"].Value.ToString();
            //    string name = dataGridView1.Rows[rows.Index].Cells["ename"].Value.ToString();
            //    //Create Cells
            //    Cell c2 = new Cell(id);
            //    Cell c1 = new Cell(name);
            //    //Adding cells
            //    t1.AddCell(c1);
            //    t1.AddCell(c2);

            //}
            //doc.Add(paragraph);
            //doc.Add(t1);
            //doc.Close(); //Close document
            //             //
            //MessageBox.Show("PDF Created!");
        }

        private void gridview_data_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    int billnumber = int.Parse(gridview_data.Rows[e.RowIndex].Cells["billnumber"].Value.ToString());
                    //ViewAbill vab = new ViewAbill(billnumber);
                    //vab.Show();
                }
                
            }
            catch (Exception )
            {

            }
            
        }

        private void txt_grnadtotal_BackColorChanged(object sender, EventArgs e)
        {


            

        }

        private void btn_analysis_Click(object sender, EventArgs e)
        {
            
        }
    }
}
