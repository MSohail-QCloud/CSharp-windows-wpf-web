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
    public partial class ProductionCountByVTypeFrm : Form
    {
        SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["sqldbx"].ConnectionString);
        ProductionCountByVTypeRpt cr = new ProductionCountByVTypeRpt();
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public int BillFrom { get; set; }
        public int BillTo { get; set; }
        public int FlagbyDateOrBill { get; set; }
        public ProductionCountByVTypeFrm(string dtf, string dto,int bfrom,int bto, int flage)
        {
            InitializeComponent();
            DateFrom = dtf;
            DateTo = dto;
            BillFrom = bfrom;
            BillTo = bto;
            FlagbyDateOrBill = flage;
        }

        private void ProductionCountByVTypeFrm_Load(object sender, EventArgs e)
        {
            //string str = "select M.invoicedate,d.InvoiceID,d.itemDescription, d.itemQty, v.VesterType from tblDetailInvoice d, tblMasterInvoice m, tblItems i, tblOrders o ,tblVesterType v where d.InvoiceID = m.InvoiceID and d.orderdetailID = o.orderdetailID  and o.ItemsID = i.ItemsID and i.VesterTypeID = v.VesterTypeID and invoicedate> '" + DateFrom+"' and invoicedate <= '"+DateTo+"'  order by d.InvoiceID";
            string str = "";
            if (FlagbyDateOrBill == 0) //search by date
            {
                str = "select orderdetailID,JobID,o.Invoiceid,t.VesterTypeID,t.VesterType,ItemsQty from tblOrders o,tblItems i,tblVesterType t , tblMasterInvoice m where o.Invoiceid is not null and o.ItemsID=i.ItemsID and i.VesterTypeID=t.VesterTypeID and m.InvoiceID=o.Invoiceid and m.invoicedate>'"+DateFrom+"' and m.invoicedate<='"+DateTo+"'   order by Invoiceid";
            }
            else //search by bill number
            {
                str = "select orderdetailID,JobID,Invoiceid,t.VesterTypeID,t.VesterType,ItemsQty from tblOrders o,tblItems i,tblVesterType t where Invoiceid is not null and o.ItemsID=i.ItemsID and i.VesterTypeID=t.VesterTypeID and o.Invoiceid>'" + BillFrom + "' and o.Invoiceid<='" + BillTo+"'   order by Invoiceid";
            }
            //DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(str, sqlcon);

            DataSet Ds = new DataSet();

            // here my_dt is the name of the DataTable which we 
            // created in the designer view.
            adapter.Fill(Ds, "Dt_ProdCountVesterType");

            if (Ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("No data Found", "CrystalReport");
                this.Close();
                //return;
            }

            // Setting data source of our report object
            cr.SetDataSource(Ds);

            CrystalDecisions.CrystalReports.Engine.TextObject root;
            root = (CrystalDecisions.CrystalReports.Engine.TextObject)
                 cr.ReportDefinition.ReportObjects["txt_header"];
            root.Text = "Sample Report By Using Data Table!!";

            // Binding the crystalReportViewer with our report object. 
            CrystlReportViewer.ReportSource = cr;
        }
    }
}
