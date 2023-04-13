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
using System.Windows.Media.Media3D;
using CrystalDecisions.CrystalReports.Engine;
using VesterShoes.classes;

namespace VesterShoes.Reports
{
    public partial class InvoiceSlipForm : Form
    {
        SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["sqldbx"].ConnectionString);
        InvoiceSlipReport cr = new InvoiceSlipReport();
        DataTable dtable = new DataTable();
        public int print = 0;
        public string Duplication { get; set; }
        public int InvoiceID { get; set; }
        public int Custid { get; set; }
        public DateTime Nowdate { get; set; }
        public string name { get; set; }
        public string NCompanyName { get; set; }
        public string CustPH { get; set; }
        public int Sumamount { get; set; }
        public int PreviouseBalance { get; set; }
        public int NewBalance { get; set; }
        public string slipdate { get; set; }
        string billtoName = "";
        string billtoCompany = "";
        string billtoAddress = "";
        string biltyvia = "";
        string biltynumb = "";
        int prreviousebalnce = 0;
        string duplicate = "";
        string Customerid = "";
        int i = 0;
        
        public InvoiceSlipForm(int invoice,string duplicate1)
        {
            InitializeComponent();
            InvoiceID = invoice;
            duplicate = duplicate1;
        }

        string strBal = "";
        private void InvoiceSlipForm_Load(object sender, EventArgs e)
        {
            try
            {

                int ledgerid= f.findnumber("select ledgerID from tblLedger where EventID='"+InvoiceID+"'");

                SqlDataReader dra;
                if (sqlcon.State != ConnectionState.Open)
                {
                    sqlcon.Open();
                }
                bool dbill = false;
                string guardianID = "";
                string query = "select m.ProfileId,PName,PGaurdianName,PCompanyName,Paddress,m.invoicedate,PGaurdianNameID,m.BiltyVia,m.BiltyNumber,m.DeleteBill from tblMasterInvoice m, tblProfile f where m.ProfileId=f.ProfileId and m.InvoiceID='" + InvoiceID + "'";
                SqlCommand cmd = new SqlCommand(query, sqlcon);//Advised to use parameterized query
                dra = cmd.ExecuteReader();
                if (dra.Read())
                {
                    Custid =int.Parse(dra.GetValue(0).ToString());
                    name = (dra.GetValue(1).ToString());
                    NCompanyName = (dra.GetValue(3).ToString());
                    NCompanyName = NCompanyName.Trim();
                    biltyvia = dra.GetValue(7).ToString();
                    biltynumb = dra.GetValue(8).ToString();
                    DateTime dt = DateTime.Parse(dra.GetValue(5).ToString());
                    slipdate = dt.ToString("dd-MM-yyyy");
                    guardianID = dra.GetValue(6).ToString();
                    dbill =bool.Parse( dra.GetValue(9).ToString());
                    if (dbill == true)
                    {
                        duplicate = "This invoice is Deleted.";
                    }

                }
                dra.Close();
                if (guardianID=="" || guardianID=="0" || guardianID == "-1") //set guardian defualt 0
                {
                    strBal = "select SUM(CreditAmount)-SUM(DebitAmount) as BalanceAmount from tblLedger where ProfileId='" + Custid + "' and ledgerID<='" + ledgerid + "' ";
                    billtoName = name;
                    billtoCompany = NCompanyName;
                    Customerid = Custid.ToString();
                        
                }
                else
                {
                    strBal = "select (sum(CreditAmount)-sum(DebitAmount))as Balance from ((select  ledgerID, LedgerTypeID, EventID, l.ProfileId, DebitAmount, CreditAmount, datetime as ldatetime, SpecialNOte, l.updateby,Remarks, p.ProfileId as PGaurdianNameID , p.PCompanyName from tblLedger l , tblProfile p  where l.ProfileId=p.ProfileId and l.ProfileId = '" + guardianID + "') union (select l.ledgerID, l.LedgerTypeID, l.EventID, l.ProfileId, l.DebitAmount, l.CreditAmount, l.datetime as ldatetime, l.SpecialNOte, l.updateby,l.Remarks, p.PGaurdianNameID,p.PCompanyName from tblLedger l , tblProfile p where l.ProfileId = p.ProfileId and p.PGaurdianNameID = '" + guardianID + "')) a where ledgerID<='"+ledgerid+"'";
                    string query1 = "select PName,PCompanyName,Paddress from tblProfile where ProfileId='" + guardianID + "'";
                    SqlCommand cmd1 = new SqlCommand(query1, sqlcon);//Advised to use parameterized query
                    dra = cmd1.ExecuteReader();
                    if (dra.Read())
                    {
                        billtoName = dra.GetValue(0).ToString();
                        billtoCompany = (dra.GetValue(1).ToString());
                        billtoAddress = (dra.GetValue(2).ToString());
                    }
                    NCompanyName = NCompanyName + " " + "C/O"+" "+billtoCompany.Trim();
                    Customerid = guardianID;
                }


                if (sqlcon.State != ConnectionState.Closed)
                {
                    sqlcon.Close();
                }
                //find balanc
                Sumamount = f.findnumber("select top(1) CreditAmount  from tblLedger where EventID='" + InvoiceID + "' and LedgerTypeID='1' ");
                int Bal = f.findnumber(strBal);
                PreviouseBalance = Bal - Sumamount;
                NewBalance = Bal;
                
                    TextObject InvoiceStatus = (TextObject)cr.ReportDefinition.Sections["Section2"].ReportObjects["txtinvStatus"];
                InvoiceStatus.Text = duplicate;
                TextObject Cname = (TextObject)cr.ReportDefinition.Sections["Section2"].ReportObjects["txtCompanyName"];
                Cname.Text = NCompanyName;
                TextObject tInvoice = (TextObject)cr.ReportDefinition.Sections["Section2"].ReportObjects["txtInvoice"];
                tInvoice.Text = InvoiceID.ToString();
                TextObject txtcustomerid = (TextObject)cr.ReportDefinition.Sections["Section2"].ReportObjects["txtCustomerid"];
                txtcustomerid.Text = Customerid.ToString();
                TextObject biltydetail = (TextObject)cr.ReportDefinition.Sections["Section2"].ReportObjects["txtBilityvia"];

                if (biltynumb.Trim() != "")
                {
                    biltynumb = " Bilty#" + biltynumb;
                }

                biltydetail.Text = biltyvia.ToString() +  biltynumb;
                
                TextObject date1 = (TextObject)cr.ReportDefinition.Sections["Section1"].ReportObjects["Billdate"];
                date1.Text = slipdate;
                TextObject samount = (TextObject)cr.ReportDefinition.Sections["Section3"].ReportObjects["txtam"];
                samount.Text = Sumamount.ToString();
                TextObject pbal = (TextObject)cr.ReportDefinition.Sections["Section3"].ReportObjects["txtPBalance"];
                pbal.Text = PreviouseBalance.ToString();
                TextObject nbal = (TextObject)cr.ReportDefinition.Sections["Section3"].ReportObjects["txtNewBalance"];
                nbal.Text = NewBalance.ToString();

                List<InvoiceSlipDB> _List = new List<InvoiceSlipDB>();
                SqlDataReader dr1;
                if (sqlcon.State != ConnectionState.Open)
                {
                    sqlcon.Open();
                }
                //string s = "select a.Article,t.VesterType,c.ColorName,m.MaterialName,sol.SolName,siz.SizeName,sum(s.ItemsQty) as ItemsQty,s.ItemsRate,sum(s.ItemsTotal ) as itemsTotal  from tblorders s, tblItems i,tblMaterial m, tblArticle a,tblVesterType t,tblColor c,tblSol sol, tblSize siz where s.ItemsID=i.ItemsID and i.ArticleID=a.ArticleID and i.VesterTypeID=t.VesterTypeID and i.ColorID=c.ColorID and i.SolID=sol.SolID and i.MaterialID=m.MaterialID and i.SizeID=siz.SizeID and s.invoiceid='" + InvoiceID+ "' group by Article,VesterType,ColorName,MaterialName,SolName,SizeName,ItemsRate,ItemsTotal";
                string s = "select InvoiceID, iarticle, itemDescription, sol, size, itemQty, Rate, itemTotal from tblDetailInvoice where InvoiceID = '"+InvoiceID+"'";
                    SqlCommand cmda = new SqlCommand(s, sqlcon);//Advised to use parameterized query
                dr1 = cmda.ExecuteReader();
                while (dr1.Read())
                {
                    _List.Add(new InvoiceSlipDB
                    {
                        artical = dr1["iarticle"].ToString(),
                        ItemsDescription = dr1["itemDescription"].ToString(),
                        sol =  dr1["sol"].ToString(),
                        size =  dr1["size"].ToString(),
                        ItemsQty = int.Parse(dr1["itemQty"].ToString()),
                        ItemsRate = int.Parse(dr1["Rate"].ToString()),
                        ItemsTotal = int.Parse(dr1["itemTotal"].ToString())
                    });
                        cr.SetDataSource(_List);
                }

                if (sqlcon.State != ConnectionState.Closed)
                {
                    sqlcon.Close();
                }

                InvoicecrystalReportViewer.ReportSource = cr;
                // cr.PrintToPrinter(1, false, 0, 0);

            }
            catch (Exception es)
            {
                MessageBox.Show("Error While Printing : " + es);
            }
        }
        functions f= new functions();
        public int findvalues()
        {
            try
            {
                int b = 0;
                return b;
            }
            catch (Exception es)
            {
                System.Windows.MessageBox.Show(es.Message.ToString());
                return 0;
            }

        }
    }
}