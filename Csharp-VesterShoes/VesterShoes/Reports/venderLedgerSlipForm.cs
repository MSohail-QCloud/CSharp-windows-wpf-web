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
using CrystalDecisions.CrystalReports.Engine;

namespace VesterShoes.Reports
{
    public partial class venderLedgerSlipForm : Form
    {
        SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["sqldbx"].ConnectionString);
        VenderLedgerSlipReport3inch cr = new VenderLedgerSlipReport3inch();
        DataSet Work = new DataSet();
        DataSet moneypaid = new DataSet();
        public int Vendid { get; set; }
        public string vendname { get; set; }
        public string fromdate { get; set; }
        public string todate { get; set; }
        public string blanceamount { get; set; }
        public venderLedgerSlipForm(int Venderid,string vname,DataSet work,DataSet gotmoney,int balance,string dtfrom,string dtt)
        {
            InitializeComponent();
            Vendid = Venderid;
            vendname = vname;
            Work = work;
            moneypaid = gotmoney;
            blanceamount = balance.ToString();
            fromdate = dtfrom;
            todate = dtt;
        }
        private void VendLedgerCrystalReportViewer_Load(object sender, EventArgs e)
        {
        }

        private void venderLedgerSlipForm_Load(object sender, EventArgs e)
        {
            try
            {
                
                TextObject vname = (TextObject)cr.ReportDefinition.Sections["Section2"].ReportObjects["txtVName"];
                vname.Text = vendname.ToString();
                TextObject vid = (TextObject)cr.ReportDefinition.Sections["Section2"].ReportObjects["txtvid"];
                vid.Text = Vendid.ToString();
                TextObject dtf = (TextObject)cr.ReportDefinition.Sections["Section2"].ReportObjects["txtdtFrom"];
                dtf.Text = fromdate.ToString();
                TextObject dtt = (TextObject)cr.ReportDefinition.Sections["Section2"].ReportObjects["txtdtto"];
                dtt.Text = todate.ToString();



                List<VenderLedgerDBWork> _List = new List<VenderLedgerDBWork>();
                List<VenderLedgerDBgetmoney> _List2 = new List<VenderLedgerDBgetmoney>();
                foreach (DataRow dr1 in Work.Tables[0].Rows)
                {
                    _List.Add(new VenderLedgerDBWork
                    {
                        //WorkDate = DateTime.Parse(dr1["VDateTime"].ToString()).ToString("dd-MM-yy"),
                        WorkDate = (dr1["VDateTime"].ToString()=="")?"":  DateTime.Parse(dr1["VDateTime"].ToString()).ToString("dd-MM-yy"),
                        jid = dr1["JobID"].ToString(),
                        ItemsDescription = dr1["AM"].ToString()+"_"+dr1["FM"].ToString()+"_"+dr1["ItemsDescription"].ToString(),
                        qty = dr1["ReturnQty"].ToString(),
                        rat=dr1["IssueRate"].ToString(),
                        Amount = dr1["VAmount"].ToString()
                    });
                }
                foreach (DataRow dr1 in moneypaid.Tables[0].Rows)
                {
                    _List2.Add(new VenderLedgerDBgetmoney
                    {
                        billdate = dr1["VDateTime"].ToString(),
                        Remarks = dr1["VRemarks"].ToString(),
                        Amount = dr1["VAmount"].ToString()
                    });
                }
                cr.SetDataSource(_List);
                cr.Subreports[0].SetDataSource(_List2);
                
                VendLedgerCrystalReportViewer.ReportSource = cr;
                // cr.PrintToPrinter(1, false, 0, 0);

            }
            catch (Exception es)
            {
                MessageBox.Show("Error While Printing : " + es);
            }
        
    }
    }
}
