using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Configuration;

namespace lasticecream
{
    public partial class ProductAnalysis : Form
    {
        OleDbConnection olecon = new OleDbConnection(ConfigurationManager.ConnectionStrings["Accdbx"].ConnectionString);
        private static ProductAnalysis alreadyOpened = null;
        public ProductAnalysis()
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

        private void ProductAnalysis_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            loadItemList1();
            loadItemList2();
            //loadvalues();
            dateFrom.Value = DateTime.Now;
            dateFrom.MaxDate = DateTime.Now;
            dateto.MaxDate = DateTime.Now;
            dateto.Value = DateTime.Now;
            comb_itemlist.SelectedIndex = comb_itemlist.Items.Count - 1;
            loadtablelist1();
            loadtablelist2();
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

        private void loadItemList1()
        {
            DataSet ds = new DataSet();
            string getEmpSQL = "SELECT menuname FROM menuinfo order by MenuNumber ;";
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
            string getEmpSQL = "SELECT menuname FROM menuinfo order by MenuNumber ;";
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
        string q = "";
        DataTable dt;
        DataTable dt1;
        Myclass mc;
        private void loadvalues()
        {
            txt_totalamount.Text = "";
            txt_qty.Text = "";
            string date1 = dateFrom.Value.ToString("MM-dd-yyyy");
            string date2 = dateto.Value.ToString("MM-dd-yyyy");
            int t1 = comboBox1.SelectedIndex + 1;
            int t2 = comboBox2.SelectedIndex + 1;
            //q = "select dt.menu_qty,dt.menu_name,dt.menurate,dt.total,dt.masterbill_id,mb.table_no,mb.printdatetime from detailbill dt  inner join mastebill mb on mb.billnumber=dt.masterbill_id where  mb.deletebill=1 and dt.menu_code >= " + txt_itemcodeFrom.Text + " And dt.menu_code <=" + txt_itemCode.Text + " and mb.billingdate >=#"+date1+"#  and mb.billingdate <=#"+date2+"# ";
            //q = "select sum(dt.menu_qty),dt.menu_name,dt.menurate,dt.total,dt.masterbill_id,mb.table_no,mb.printdatetime from (detailbill dt  inner join mastebill mb on mb.billnumber = dt.masterbill_id)  inner join tableinfo ti on ti.table_no = mb.table_no  where mb.deletebill = 1 and dt.menu_code >= " + txt_itemcodeFrom.Text + " And dt.menu_code <= " + txt_itemCode.Text + " and mb.billingdate >=#" + date1 + "#  and mb.billingdate <=#" + date2 + "# and ti.tableid >= " + t1 + "  and ti.tableid<=" + t2 + " group by dt.menu_name ";
            //q = "select sum(dt.menu_qty),dt.menu_name,dt.menurate, sum(dt.total) (detailbill dt  inner join mastebill mb on mb.billnumber = dt.masterbill_id)  inner join tableinfo ti on ti.table_no = mb.table_no  where mb.deletebill = 1 and dt.menu_code >= " + txt_itemcodeFrom.Text + " And dt.menu_code <= " + txt_itemCode.Text + " and mb.billingdate >=#" + date1 + "#  and mb.billingdate <=#" + date2 + "# and ti.tableid >= " + t1 + "  and ti.tableid<=" + t2 + " group by dt.menu_name,dt.menurate ";
            q = "select sum(dt.menu_qty),dt.menu_name,dt.menurate,SUM( dt.total ) from (detailbill dt  inner join mastebill mb on mb.billnumber = dt.masterbill_id)  inner join tableinfo ti on ti.table_no = mb.table_no  where mb.deletebill = 1 and dt.menu_code >= " + txt_itemcodeFrom.Text + " And dt.menu_code <= " + txt_itemCode.Text + " and mb.billingdate >=#" + date1 + "#  and mb.billingdate <=#" + date2 + "# and ti.tableid >= " + t1 + "  and ti.tableid<=" + t2 + "  group by dt.menu_name,dt.menurate ";
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
                grid_analysis.Columns[0].HeaderText = "تعداد";
                grid_analysis.Columns[1].HeaderText = "مینیو نام";
                grid_analysis.Columns[2].HeaderText = "ریٹ";
                grid_analysis.Columns[3].HeaderText = "ٹوٹل";
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
                    qty += float.Parse(row.Cells[0].Value.ToString());
            }


            txt_totalamount.Text = sum.ToString();
            txt_qty.Text = qty.ToString();
        }

        private void btn_execute_Click(object sender, EventArgs e)
        {
            if (txt_itemcodeFrom.Text != "" && txt_itemCode.Text != "")
            {
                loadvalues();
            }
        }

        private void CombItemcodelistfrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            int no = CombItemcodelistfrom.SelectedIndex;
            txt_itemcodeFrom.Text = (no + 1).ToString();
        }

        private void comb_itemlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            int no = comb_itemlist.SelectedIndex;
            txt_itemCode.Text = (no + 1).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
