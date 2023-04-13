using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace lasticecream
{
    public partial class Report : Form
    {
        OleDbConnection olecon = new OleDbConnection(ConfigurationManager.ConnectionStrings["Accdbx"].ConnectionString);
        invoice1 cr = new invoice1();
        DataTable dt;
        string title;
        string phone;
        string msg;
        public int print = 1;
        string billdate;
        public string Duplication { get; set; }
        private static Report alreadyOpened = null;

        public Report( int b,string s)
        {
            if (alreadyOpened != null && !alreadyOpened.IsDisposed)
            {
                alreadyOpened.Close();
                //Shown += (s, e) => this.Focus();  // and destroy the new one.
                            // Bring the old one to top

                //return;
            }

            // Otherwise store this one as reference
            alreadyOpened = this;
            InitializeComponent();
            i = b;
            billdate = s;
        }

        
        db dblayer = new db();
        int i = 0;
        private void Report_Load(object sender, EventArgs e)
        {
            try
            {
                TextObject BillDuplicate = (TextObject)cr.ReportDefinition.Sections["Section1"].ReportObjects["txt_duplicate"];
                BillDuplicate.Text = Duplication;
                List<db_invoice_detail> _List = new List<db_invoice_detail>();
                DataSet ds = dblayer.ds_invoice(i, billdate);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {

                    _List.Add(new db_invoice_detail
                    {
                        billingdate = DateTime.Parse(dr["billingdate"].ToString()),
                        Pprintdatetime = dr["printdatetime"].ToString(),
                        table_no = dr["table_no"].ToString(),
                        billnumber = int.Parse(dr["billnumber"].ToString()),
                        billamount = int.Parse(dr["billamount"].ToString()),
                        serviceCharges = int.Parse(dr["serviceCharges"].ToString()),
                        billDiscount = int.Parse(dr["billDiscount"].ToString()),
                        grandTotal = int.Parse(dr["grandTotal"].ToString()),
                        paidamount = int.Parse(dr["paidamount"].ToString()),
                        change = int.Parse(dr["change"].ToString()),
                        menu_qty = float.Parse(dr["menu_qty"].ToString()),
                        menu_name = dr["menu_name"].ToString(),
                        menurate = int.Parse(dr["menurate"].ToString()),
                        total = int.Parse(dr["total"].ToString()),
                        CustomerName = (dr["PartyName"].ToString()),
                        Waiter = (dr["WaiterName"].ToString())
                    });
                }

                DataSet ds2 = dblayer.ds_invoice(i, billdate);
                foreach (DataRow dr in ds2.Tables[0].Rows)
                {
                    cr.SetDataSource(_List);
                    cr.SetParameterValue("pBillnumber", 1);
                }
                //crystalReportViewer1.ReportSource = invoice11;
                crystalReportViewer1.ReportSource = cr;
                if (print != 0)
                {
                    cr.PrintToPrinter(1, false, 0, 0);
                }
            }
            catch (Exception es)
            {
                MessageBox.Show("Error While Printing : " + es.Message);
            }
        }
        private void loadbioinfo()
        {
            try
            {
                string sql = "Select * from bioinfo";
                olecon.Open();
                OleDbCommand oledbCmd = new OleDbCommand(sql, olecon);
                OleDbDataReader oledbReader = oledbCmd.ExecuteReader();
                while (oledbReader.Read())
                {
                    title = oledbReader["Title"].ToString();
                    phone = oledbReader["Phonenumber"].ToString();
                    msg = oledbReader["message"].ToString();
                }

                oledbReader.Close();
                oledbCmd.Dispose();
                olecon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                olecon.Close();
            }
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
