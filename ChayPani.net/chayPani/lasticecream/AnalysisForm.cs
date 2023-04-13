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
    public partial class AnalysisForm : Form
    {
        OleDbConnection olecon = new OleDbConnection(ConfigurationManager.ConnectionStrings["Accdbx"].ConnectionString);

        public AnalysisForm()
        {
            InitializeComponent();
        }

        private void AnalysisForm_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            //loadItemList1();
            loadItemList2();
            //loadvalues();
            dateFrom.Value = DateTime.Today;
            dateFrom.MaxDate = DateTime.Today;
            dateto.MaxDate = DateTime.Today;
            dateto.Value = DateTime.Today;
            comb_itemlist.SelectedIndex = comb_itemlist.Items.Count - 1;
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = comboBox2.Items.Count - 1;
            //loadtablelist1();
            //loadtablelist2();
        }
        private void loadtablelist1()
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

            comboBox1.DataSource = ds.Tables[0];
            //CombItemcodelistfrom.DataSource = ds.Tables[0];
            comboBox1.DisplayMember = ds.Tables[0].Columns[0].ToString();
            //CombItemcodelistfrom.DisplayMember = ds.Tables[0].Columns[0].ToString();
        }
        private void loadtablelist2()
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

            comboBox2.DataSource = ds.Tables[0];
            //CombItemcodelistfrom.DataSource = ds.Tables[0];
            comboBox2.DisplayMember = ds.Tables[0].Columns[0].ToString();
            //CombItemcodelistfrom.DisplayMember = ds.Tables[0].Columns[0].ToString();
        }

        private  void loadItemList1()
        {
            DataSet ds = new DataSet();
            string getEmpSQL = "SELECT DISTINCT menutype FROM menuinfo ;";
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

            comb_itemlist.DataSource = ds.Tables[0];
            //CombItemcodelistfrom.DataSource = ds.Tables[0];
            comb_itemlist.DisplayMember = ds.Tables[0].Columns[0].ToString();
            //CombItemcodelistfrom.DisplayMember = ds.Tables[0].Columns[0].ToString();
        }
        private void loadItemList2()
        {
            DataSet ds = new DataSet();
            string getEmpSQL = "SELECT DISTINCT menutype FROM menuinfo ;";
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

            //comb_itemlist.DataSource = ds.Tables[0];
            CombItemcodelistfrom.DataSource = ds.Tables[0];
            //comb_itemlist.DisplayMember = ds.Tables[0].Columns[0].ToString();
            CombItemcodelistfrom.DisplayMember = ds.Tables[0].Columns[0].ToString();
        }
        string q="";
        //DataTable dt;
        DataTable dt1;
        //Myclass mc;
        private void loadvalues()
        {
            txt_totalamount.Text = "";
            txt_qty.Text = "";
           string date1 = dateFrom.Value.ToString("MM-dd-yyyy");
           string date2 = dateto.Value.ToString("MM-dd-yyyy");
            int t1 = comboBox1.SelectedIndex ;
            int t2 = comboBox2.SelectedIndex ;
            //select dt.menu_qty,dt.menu_name,dt.menurate,dt.total,dt.masterbill_id,mb.table_no,mb.printdatetime from (detailbill dt  inner join mastebill mb on mb.billnumber = dt.masterbill_id and mb.billingdate=dt.billingdate) where mb.deletebill = 1 and dt.menu_code >= 1 And dt.menu_code <= 79 and mb.billingdate >=#03-11-2018#  and mb.billingdate <=#24-11-2018# and mb.table_no >= '2'  and mb.table_no <='25'
            //q = "select dt.menu_qty,dt.menu_name,dt.menurate,dt.total,dt.masterbill_id,mb.table_no,mb.printdatetime from detailbill dt  inner join mastebill mb on mb.billnumber=dt.masterbill_id where  mb.deletebill=1 and dt.menu_code >= " + txt_itemcodeFrom.Text + " And dt.menu_code <=" + txt_itemCode.Text + " and mb.billingdate >=#"+date1+"#  and mb.billingdate <=#"+date2+"# ";
            //q = "select dt.menu_qty,dt.menu_name,dt.menurate,dt.total,dt.masterbill_id,mb.table_no,mb.printdatetime from (detailbill dt  inner join mastebill mb on mb.billnumber = dt.masterbill_id and mb.billingdate=dt.billingdate)  inner join menuinfo mi on mi.MenuNumber=dt.menu_code  where mb.deletebill = 1 and dt.menu_code >= " + txt_itemcodeFrom.Text + " And dt.menu_code <= " + txt_itemCode.Text + " and mb.billingdate >=#" + date1 + "#  and mb.billingdate <=#" + date2 + "# and mb.table_no >= '" + t1 + "'  and mb.table_no <='" + t2+"'";
            q = "select dt.billingdate,dt.menu_name,sum(dt.menu_qty) as Qty,sum(dt.total) as Amount from (detailbill dt  inner join mastebill mb on mb.billnumber = dt.masterbill_id and mb.billingdate=dt.billingdate)  inner join menuinfo mi on mi.MenuNumber=dt.menu_code  where mb.deletebill = 1 and mi.menutype = '" + CombItemcodelistfrom.Text+ "' and mb.billingdate >=#" + date1 + "#  and mb.billingdate <=#" + date2 + "# and mb.table_no >= '" + t1 + "'  and mb.table_no <='" + t2+ "' group by dt.menu_name,dt.billingdate ";
            olecon.Open();
            dt1 = new DataTable();
            OleDbDataAdapter oleadapt = new OleDbDataAdapter(q, olecon);
            oleadapt.Fill(dt1);
            oleadapt.Dispose();
            olecon.Close();
            //return dt_catogory;



            //dt = mc.fillgidview(q);
            grid_analysis.DataSource = dt1;
            if (grid_analysis.Rows.Count > 0)
            {
                grid_analysis.Columns[0].HeaderText = "Date";
                grid_analysis.Columns[1].HeaderText = "Menu";
                grid_analysis.Columns[2].HeaderText = "Qty";
                grid_analysis.Columns[3].HeaderText = "Amount";
                //grid_analysis.Columns[4].HeaderText = "بل نمبر";
                //grid_analysis.Columns[5].HeaderText = "ٹیبل";
                //grid_analysis.Columns[6].HeaderText = "تاریخ";
                //grid_analysis.Columns[0].Width = 30;
                //grid_analysis.Columns[1].Width = 110;
                //grid_analysis.Columns[2].Width = 40;
                //grid_analysis.Columns[3].Width = 40;
                //grid_analysis.Columns[4].Width = 80;
                //grid_analysis.Columns[6].Width = 170;
                //comboBox_tblnumber.Text = grid_analysis.Rows[0].Cells["table_no"].Value.ToString();
                grid_analysis.ClearSelection();
                olecon.Close();
                summition();
            }
            else
            {
                dt1.Clear();
                grid_analysis.DataSource = null;
                Refresh();
            }
        }
        void summition()
        {
            int sum = 0;
            float qty = 0;
            foreach (DataGridViewRow row in grid_analysis.Rows)
            {
                if (!row.IsNewRow)
                    sum += Convert.ToInt32(row.Cells[3].Value.ToString());
                if (!row.IsNewRow)
                    qty += float.Parse(row.Cells[2].Value.ToString());
            }


            txt_totalamount.Text = sum.ToString();
            txt_qty.Text = qty.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void comb_itemlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            int no = comb_itemlist.SelectedIndex;
            txt_itemCode.Text = (no+1).ToString();
        }

        private void btn_execute_Click(object sender, EventArgs e)
        {
            //if(txt_itemcodeFrom.Text!="" && txt_itemCode.Text!="")
            //{
                loadvalues();
            //}
        }

        private void CombItemcodelistfrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            int no = CombItemcodelistfrom.SelectedIndex;
            txt_itemcodeFrom.Text =(no+1).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_print_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
