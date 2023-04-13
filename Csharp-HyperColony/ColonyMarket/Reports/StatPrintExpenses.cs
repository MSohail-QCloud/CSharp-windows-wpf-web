using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace ColonyMarket.Reports
{
    public partial class StatPrintExpenses : Form
    {

        public StatPrintExpenses()
        {
            InitializeComponent();
        }
        DataTable ds1 = new DataTable();
        StatPrintExpenses cr = new StatPrintExpenses();
        private void StatPrintExpenses_Load(object sender, EventArgs e)
        {
            try
            {
                //TextObject code = (TextObject)cr.ReportDefinition.Sections["Section1"].ReportObjects["VendID"];
                //code.Text = Vendid.ToString();
                //TextObject Name = (TextObject)cr.ReportDefinition.Sections["Section1"].ReportObjects["VName"];
                //Name.Text = vname;
                //TextObject f = (TextObject)cr.ReportDefinition.Sections["Section1"].ReportObjects["From"];
                //f.Text = fromdate.ToString("dd-MM-yyyy");
                //TextObject t = (TextObject)cr.ReportDefinition.Sections["Section1"].ReportObjects["to"];
                //t.Text = todate.ToString("dd-MM-yyyy");
                //TextObject bala = (TextObject)cr.ReportDefinition.Sections["Section4"].ReportObjects["txtBalance"];
                //bala.Text = Balance;
                //string[] name = lblName.Text.Split('-');
                //string name2 = name[0];
                //string desig = name[1];
                //string depart = name[2];
                //TextObject name1 = (TextObject)cr.ReportDefinition.Sections["Section1"].ReportObjects["txtName"];
                //name1.Text = name2;

                //TextObject desi = (TextObject)cr.ReportDefinition.Sections["Section1"].ReportObjects["txtDesignation"];
                //desi.Text = desig;
                //TextObject dept = (TextObject)cr.ReportDefinition.Sections["Section1"].ReportObjects["txt_department"];
                //dept.Text = depart;

                //VendID =int.Parse(dr["OUT_DATE"].ToString()),
                //VenderName = dr["OUT_TIME"].ToString(),
                //FromDate = DateTime.Parse(dr["IN_DATE"].ToString()),
                //ToDate = DateTime.Parse(dr["OUT_DATE"].ToString()),
                //VenderType =(dr["IN_DATE"].ToString()),

                //List<VenderLedgerSlipDB> _List = new List<VenderLedgerSlipDB>();
                ////DataTable ds = ds1;

                //foreach (DataRow dr in ds1.Rows)
                //{
                //    _List.Add(new VenderLedgerSlipDB
                //    {
                //        CurrDate = DateTime.Parse(dr["datetime"].ToString()),
                //        ProcessId = int.Parse(dr["EventID"].ToString()),
                //        Opeining = (dr["Opening_Balance"].ToString()),
                //        Payment = dr["CreditAmount"].ToString(),
                //        Paid = dr["DebitAmount"].ToString(),
                //        Closing = dr["Closing_Balance"].ToString()
                //    });
                //}



                //DataSet ds2 = ds1;
                foreach (DataRow dr in ds1.Rows)
                {

                   // cr.SetDataSource(_List);
                }
                statPrintExpensesReportViewer.ReportSource = cr;
                // cr.PrintToPrinter(1, false, 0, 0);

            }
            catch (Exception es)
            {
                MessageBox.Show("Error While Printing : " + es);
            }
        }
    }
}
