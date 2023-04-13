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
using System.Net.Mail;
using lasticecream.ChayPaniForms;

namespace lasticecream
{
    public partial class parentform : Form
    {
        OleDbConnection olecon = new OleDbConnection(ConfigurationManager.ConnectionStrings["Accdbx"].ToString());
        public parentform()
        {
            InitializeComponent();
        }
        string date1 = "";
        private void parentform_Load(object sender, EventArgs e)
        {
            date1 = DateTime.Now.AddDays(-3).ToString("dd-MM-yyyy");

            deleteDetailBill();
            deleteMasterBill();
            //abc();
            //billFormToolStripMenuItem_Click(sender, e);
        }
        
        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void deleteMasterBill()
        {
            try
            {
                olecon.Open();
                string query = "delete from mastebill  where  billingdate<=#" + date1 + "#";
                OleDbCommand cmd = new OleDbCommand(query, olecon);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                olecon.Close();
            }
            catch (Exception es)
            {
                MessageBox.Show(es.ToString());
            }

            //DataTable table = new DataTable();

            ////in some of your methods:

            //string sqlQuery = @"SELECT * FROM mastebill";
            //using (OleDbCommand cmd = new OleDbCommand(sqlQuery, olecon))
            //{
            //    OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            //    da.Fill(table);
            //}

            //foreach (DataRow dr in table.Rows)
            //{
            //    //string test = dr[9].ToString();
            //    //DateTime dtest =(DateTime)dr[8];
            //    // DateTime testdate = (DateTime)dr[7];
            //    DateTime openingdate = DateTime.Now.AddDays(-6);
            //    if ((DateTime)dr[8] < openingdate)
            //    {
            //        int deletindex = (int)dr[0];
            //        deleterec(deletindex);
            //    }
            //}
        }
        private void deleteDetailBill()
        {
            try
            {
                olecon.Open();
                string query= "delete FROM detailbill WHERE masterbill_id in  (select  dt.masterbill_id from   detailbill dt  inner join mastebill mb on mb.billnumber = dt.masterbill_id where mb.billingdate <=#" + date1 + "# )";
                OleDbCommand cmd = new OleDbCommand(query, olecon);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                olecon.Close();
            }
            catch(Exception es)
            {
                MessageBox.Show(es.ToString());
            }
        }

        private void deleterec(int indexx)
        {
            olecon.Open();
            string ind = indexx.ToString();
            OleDbCommand cmd = new OleDbCommand("DELETE from  mastebill WHERE billid = " + indexx + ";", olecon);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            olecon.Close();
        }

        private void tableFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        

        private void billFormToolStripMenuItem_Click(object sender, EventArgs e)
        {


            BillScreen bsfm = new BillScreen();
            bsfm.Show();
            this.Hide();
            
        }

        private void menuFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            additems aifm1 = new additems();
                aifm1.MdiParent = this;
                aifm1.Show();
        }

        private void parentform_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private bool CheckOpened(string name)
        {
            FormCollection fc = Application.OpenForms;

            foreach (Form frm in fc)
            {
                if (frm.Name == name)
                {
                    return true;
                }
            }
            return false;
        }
        private void tableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Addtables at = new Addtables();
            at.MdiParent = this;
            at.Show();
        }

        private void بندکریںToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        

        private void بلزڈٹیلToolStripMenuItem_Click(object sender, EventArgs e)
        {
            billsdetail bd = new billsdetail();
            bd.Show();
        }

        private void رپورٹسToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            //ParamatereReportFm rt = new ParamatereReportFm();
            //rt.MdiParent = this;
            //rt.Show();
        }

        private void خریداریوالافارمToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Purchaseinfor pfm = new Purchaseinfor();
            pfm.MdiParent = this;
            pfm.Show();
        }

        private void parentform_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void انوائسToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ViewAbill vab = new ViewAbill(0);
            //vab.MdiParent = this;
            //vab.Show();
        }

        private void analysisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AnalysisForm asf = new AnalysisForm();
            asf.MdiParent = this;
            asf.Show();
        }

        private void summaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ledger ld = new Ledger();
            ld.MdiParent = this;
            ld.Show();
        }

        private void analysisByProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductAnalysis pa = new ProductAnalysis();
            pa.MdiParent = this;
            pa.Show();
        }
    }
}
