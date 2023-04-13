using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VesterShoes.Reports
{
    public partial class CustomerLederform : Form
    {
        SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["sqldbx"].ConnectionString);
        CustomerLedgerRpt cr = new CustomerLedgerRpt();
        DataSet ds;
        public string CustomerId { get; set; }
        public string BalanceAmount { get; set; }
        public int ptype { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }

        public CustomerLederform(DataSet dsa,string cid, string balance, string datef, string datet)
        {
            InitializeComponent();
            ds = dsa;
            CustomerId = cid;
            BalanceAmount = balance;
            DateFrom = datef;
            DateTo = datet;

        }

        private void CustomerLederform_Load(object sender, EventArgs e)
        {
            TextObject datef = (TextObject)cr.ReportDefinition.Sections["Section1"].ReportObjects["txtFromDate"];
            datef.Text = DateFrom;
            TextObject datet = (TextObject)cr.ReportDefinition.Sections["Section1"].ReportObjects["txtTodate"];
            datet.Text = DateTo;
            TextObject blnce = (TextObject)cr.ReportDefinition.Sections["Section1"].ReportObjects["txtBalanceAmount"];
            blnce.Text = BalanceAmount;

            SqlDataReader dra;
            if (sqlcon.State != ConnectionState.Open)
            {
                sqlcon.Open();
            }
            string guardianID = "";
            //string query = "select m.ProfileId,PName,PGaurdianName,PCompanyName,Paddress,m.invoicedate,PGaurdianNameID,m.BiltyVia,m.BiltyNumber from tblMasterInvoice m, tblProfile f where m.ProfileId=f.ProfileId and m.InvoiceID='" + InvoiceID + "'";
            string query = "select PName,PCompanyName,PType from tblProfile where ProfileId='" + CustomerId+"'";
            SqlCommand cmd = new SqlCommand(query, sqlcon);//Advised to use parameterized query
            dra = cmd.ExecuteReader();
            if (dra.Read())
            {
                string Name= (dra.GetValue(0).ToString()).Trim();
                string pcomp = (dra.GetValue(1).ToString());
                 ptype =int.Parse (dra.GetValue(2).ToString());
                TextObject Cname = (TextObject)cr.ReportDefinition.Sections["Section1"].ReportObjects["txtCustName"];
                Cname.Text ="Mr. "+ Name+" Sb";
                TextObject cid = (TextObject)cr.ReportDefinition.Sections["Section1"].ReportObjects["txtCustomerid"];
                cid.Text = CustomerId.ToString();

            }
            dra.Close();

            List<CustomerLedgerDB> _List = new List<CustomerLedgerDB>();
            foreach (DataRow dr1 in ds.Tables[0].Rows)
            {
                _List.Add(new CustomerLedgerDB
                {
                    Datetime =( dr1["ledgerdate"].ToString()).Substring(0,11),
                    Bill = dr1["eventid"].ToString(),
                    Detail = dr1["Detail"].ToString(),
                    Debit = dr1["debitamount"].ToString() ,
                    Credit = dr1["creditamount"].ToString(),
                    Balance = dr1["blc"].ToString()
                });
            }
            cr.SetDataSource(_List);
            CustLedgerCrystalReportViewer.ReportSource = cr;
            // cr.PrintToPrinter(1, false, 0, 0);

            if (sqlcon.State != ConnectionState.Closed)
            {
                sqlcon.Close();
            }
        }
    }
}
