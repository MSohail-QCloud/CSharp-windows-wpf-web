using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using VesterShoes.classes;

namespace VesterShoes.Reports
{
    public partial class jobCardForm : Form
    {
        SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["sqldbx"].ConnectionString);
        JobCardReport cr = new JobCardReport();

        public int print = 0;
        public string Duplication { get; set; }
         public jobCardForm(string Duplicate,string oid,string sortid)
        {
            InitializeComponent();
            //Nowdate = dt;
            //Itemmid = itemid;
            Orderid = oid;
             SortId = sortid;
            //Processid = pid;
            //Custid = custID;
            //OrderQty = oqty;
            dup = Duplicate;
             
        }

        public string SortId { get; set; }
        public int Custid { get; set; }
        public string CustName { get; set; }
        public string dup { get; set; }
        public DateTime Nowdate { get; set; }
        public int Itemmid { get; set; }
        public string Article { get; set; }
        public string Type { get; set; }
        public string color { get; set; }
        public string Material { get; set; }
        public string Sol { get; set; }
        public string size { get; set; }
        public string Shoelast { get; set; }
        public string stamp { get; set; }
        public string Orderid { get; set; }
        public string Processid { get; set; }
        public string Vname { get; set; }
        public int Venderid { get; set; }
        public int OrderQty { get; set; }
        public string RecDetailAM { get; set; }
        public string RecDetailBM { get; set; }
        public string RecDetailFM { get; set; }
        public string oNote { get; set; }
        //db dblayer = new db();
        int i = 0;
        private void jobCardForm_Load(object sender, EventArgs e)
        {
            
            try
            {
                getidetail();
            getitemdetail();
                List<JobCardDb> list = new List<JobCardDb>();
                list.Add(new JobCardDb
                {
                    Duplicate = dup,
                    PrintDatetime = Nowdate,
                    cArticle = Article,
                    CustmerID = Custid,
                    cType = Type,
                    cColor = color,
                    cMaterial = Material,
                    cSol = Sol,
                    csize = size,
                    cstamp = stamp,
                    cshoelast = Shoelast,
                    OrderId = Orderid,
                    ProcessId = Processid,
                    Qty = OrderQty,
                    Custname = CustName,
                    rAM=RecDetailAM,
                    rBM=RecDetailBM,
                    rFM=RecDetailFM,
                    Ordernote=oNote
                });
               // MessageBox.Show()
                cr.SetDataSource(list);
                JobCardcrystalReportViewer.ReportSource = cr;
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
        private void getitemdetail()
        {
            try
            {
                SqlDataReader dr;
                if (sqlcon.State != ConnectionState.Open)
                {
                    sqlcon.Open();
                }
                string query = "select ar.Article,vt.VesterType,cl.ColorName,tm.MaterialName,so.SolName,siz.SizeName,stp.StampName,slast.ShooLeastNumber from tblitems it join tblarticle ar on it.ArticleID=ar.ArticleID  join tblVesterType vt on it.VesterTypeID=vt.VesterTypeID join tblColor cl on it.ColorID=cl.ColorID join tblMaterial tm on it.MaterialID=tm.MaterialID join tblSol so on it.SolID=so.SolID join tblSize siz on it.SizeID=siz.SizeID join tblStamp stp on it.StampID=stp.StampID join tblshooleast slast on it.ShooleastID=slast.ShooleastID where it.ItemsID ='" + Itemmid + "'";
                SqlCommand cmd = new SqlCommand(query, sqlcon);//Advised to use parameterized query
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    Article = (dr["Article"].ToString());
                    Type = (dr["VesterType"].ToString());
                    color = (dr["ColorName"].ToString());
                    Material = (dr["MaterialName"].ToString());
                    Sol = (dr["SolName"].ToString());
                    size = (dr["SizeName"].ToString());
                    stamp = (dr["StampName"].ToString());
                    Shoelast = (dr["ShooLeastNumber"].ToString());
                }
                else
                {
                    System.Windows.MessageBox.Show("No Record Found");
                }
                dr.Close();
            }
            catch (Exception es)
            {
                System.Windows.Forms.MessageBox.Show(es.Message.ToString());
                return;
            }
            finally
            {
                if (sqlcon.State != ConnectionState.Closed)
                {
                    sqlcon.Close();
                }
            }
        }

        private void getidetail()
        {
            try
            {
                SqlDataReader dr;
                if (sqlcon.State != ConnectionState.Open)
                {
                    sqlcon.Open();
                }
                //string query =
                //    "select o.OrderDatetime,o.ProfileId,ItemsID,JobID,ItemsQty,p.PCompanyName from tblOrders o inner join tblProfile p on o.ProfileId=p.ProfileId where OrderID=" + Orderid+" and SortID="+SortId+"";
                string query =
                    "select a.OrderDatetime,a.ProfileId,a.ItemsID,a.JobID,a.ItemsQty,a.PCompanyName,b.AM,b.BM,b.FM,a.CustomerPO from (select o.orderdetailID, o.OrderDatetime,o.ProfileId,ItemsID,JobID,ItemsQty,p.PCompanyName,o.CustomerPO from tblOrders o inner join tblProfile p on o.ProfileId = p.ProfileId where OrderID = " + Orderid+" and SortID = "+SortId+"	)a inner join tblRecipeStepsDetail b on a.orderdetailID = b.orderdetailID";
                SqlCommand cmd = new SqlCommand(query, sqlcon); //Advised to use parameterized query
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    Nowdate = DateTime.Parse(dr["OrderDatetime"].ToString());
                    Itemmid = int.Parse (dr["ItemsID"].ToString());
                    Custid = int.Parse (dr["ProfileId"].ToString());
                    Processid = dr["JobID"].ToString()+"("+Orderid+"-"+SortId+")";
                    OrderQty = int.Parse(dr["ItemsQty"].ToString());
                    CustName = dr["PCompanyName"].ToString();
                    int am =int.Parse( dr["AM"].ToString());
                    int bm =int.Parse( dr["BM"].ToString());
                    int fm =int.Parse( dr["FM"].ToString());
                    oNote=dr["CustomerPO"].ToString();
                    var aam = (enumClass.RecipeDetailAM)am;
                    var bbm = (enumClass.RecipeDetailBM)bm;
                    var ffm = (enumClass.RecipeDetailFM)fm;
                    RecDetailAM = aam.ToString();
                    RecDetailBM = bbm.ToString();
                    RecDetailFM = ffm.ToString();
                }
                else
                {
                    System.Windows.MessageBox.Show("No Record Found");
                }
                dr.Close();
            }
            catch (Exception es)
            {
                //System.Windows.Forms.MessageBox.Show(es.Message.ToString());
                System.Windows.Forms.MessageBox.Show(es.ToString());
                return;
            }
            finally
            {
                if (sqlcon.State != ConnectionState.Closed)
                {
                    sqlcon.Close();
                }
            }
        }

    }
}
