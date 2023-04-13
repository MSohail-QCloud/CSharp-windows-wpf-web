using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NexusPOS_wpf.Reports;
using CrystalDecisions.CrystalReports.Engine;

namespace NexusPOS_wpf.Reports
{
    
    public partial class BillSlip : Form
    {
        OleDbConnection olecon = new OleDbConnection(ConfigurationManager.ConnectionStrings["Accdbx"].ConnectionString);
        RptInvoiceBillSlip cr = new RptInvoiceBillSlip();
        DataTable dt;
        string title;
        string phone;
        string msg;
        public int print = 1;
        string billdate;
        public string Duplication { get; set; }
        private static BillSlip alreadyOpened = null;

        public BillSlip(int b)
        {
            if (alreadyOpened != null && !alreadyOpened.IsDisposed)
            {
                alreadyOpened.Close();
            }

            // Otherwise store this one as reference
            alreadyOpened = this;
            InitializeComponent();
            i = b;
        }

        ClassDB dblayer = new ClassDB();
        int i = 0;
        int test = 0;
        private void BillSlip_Load(object sender, EventArgs e)
        {
            if (test == 0)
            {
                try
                {
                    //TextObject BillDuplicate = (TextObject)cr.ReportDefinition.Sections["Section1"].ReportObjects["txt_duplicate"];
                    //BillDuplicate.Text = Duplication;
                    List<ClassBillSlip> _List = new List<ClassBillSlip>();
                    DataSet ds = dblayer.ds_invoice(i);
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {

                        _List.Add(new ClassBillSlip
                        {
                            billingdate = DateTime.Parse(dr["printdatetime"].ToString()),
                            billnumber = int.Parse(dr["billnumber"].ToString()),
                            billamount = int.Parse(dr["SubTotal"].ToString()),
                            billDiscount = int.Parse(dr["Discount"].ToString()),
                            grandTotal = int.Parse(dr["GrandTotal"].ToString()),
                            paidamount = int.Parse(dr["PaidBill"].ToString()),
                            RemainingBill = int.Parse(dr["RemainingBill"].ToString()),
                            RemainingBalance = int.Parse(dr["RemainingBalance"].ToString()),
                            CustomerName = (dr["PersonName"].ToString()),
                            Discription = (dr["ItemDescription"].ToString()),
                            ItemPrice = float.Parse(dr["Rate"].ToString()),
                            Size = (dr["SizeWidth"].ToString() + "x" + dr["SizeLength"].ToString()),
                            Qty = int.Parse(dr["Qty"].ToString()),
                            Total = int.Parse(dr["Total"].ToString()),
                            Labour = int.Parse(dr["LabourCharges"].ToString()),
                            Design = int.Parse(dr["DesignCharges"].ToString()),
                            Positive = int.Parse(dr["PositiveCharges"].ToString())
                        });
                    }

                    DataSet ds2 = dblayer.ds_invoice(i);
                    foreach (DataRow dr in ds2.Tables[0].Rows)
                    {
                        cr.SetDataSource(_List);
                        //cr.SetParameterValue("pBillnumber", 1);
                    }
                    //crystalReportViewer1.ReportSource = invoice11;
                    crystalReportViewer1.ReportSource = cr;
                    if (print != 0 && Duplication != "Duplicate")
                    {
                        cr.PrintToPrinter(1, false, 0, 0);
                    }
                   // test = 1;
                }
                catch (Exception es)
                {
                    MessageBox.Show("Error While Printing : " + es.Message);
                }
            }
            
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        //private void loadbioinfo()
        //{
        //    try
        //    {
        //        string sql = "Select * from bioinfo";
        //        olecon.Open();
        //        OleDbCommand oledbCmd = new OleDbCommand(sql, olecon);
        //        OleDbDataReader oledbReader = oledbCmd.ExecuteReader();
        //        while (oledbReader.Read())
        //        {
        //            title = oledbReader["Title"].ToString();
        //            phone = oledbReader["Phonenumber"].ToString();
        //            msg = oledbReader["message"].ToString();
        //        }

        //        oledbReader.Close();
        //        oledbCmd.Dispose();
        //        olecon.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //        olecon.Close();
        //    }
        //}
    }
}
