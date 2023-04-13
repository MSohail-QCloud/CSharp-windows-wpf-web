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

namespace lasticecream.ChayPaniForms
{
    public partial class miniReportForm : Form
    {
        OleDbConnection olecon = new OleDbConnection(ConfigurationManager.ConnectionStrings["Accdbx"].ConnectionString);
        MiniCrReport cr = new MiniCrReport();
        DataTable dt;
        string title;
        string phone;
        string msg;
        public int print = 1;
        string billdate;
        public string Duplication { get; set; }
        public miniReportForm(int b, string s)
        {
            InitializeComponent();
            i = b;
            billdate = s;
        }

        db dblayer=new db();
        int i = 0;
        private void miniReportForm_Load(object sender, EventArgs e)
        {
            try
            {
                List<miniReportDetail> _List = new List<miniReportDetail>();
                DataSet ds = dblayer.miniReportDataset(i, billdate);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {

                    _List.Add(new miniReportDetail
                    {
                        billingdate = DateTime.Parse(dr["billingdate"].ToString()),
                        Pprintdatetime = dr["printdatetime"].ToString(),
                        table_no = dr["table_no"].ToString(),
                        billnumber = int.Parse(dr["billnumber"].ToString()),
                        menu_qty = float.Parse(dr["menu_qty"].ToString()),
                        menu_name = dr["menu_name"].ToString(),
                        Waiter = (dr["WaiterName"].ToString())
                    });
                }

                DataSet ds2 = dblayer.miniReportDataset(i, billdate);
                foreach (DataRow dr in ds2.Tables[0].Rows)
                {
                    cr.SetDataSource(_List);
                    //cr.SetParameterValue("pBillnumber", 1);
                }
                MiniReportViewer.ReportSource = cr;
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

        private void MiniReportViewer_Load(object sender, EventArgs e)
        {

        }
    }
}
