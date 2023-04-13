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
    public partial class AllCustomerBalance : Form
    {
        SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["sqldbx"].ConnectionString);
        AllCustomerBalanceReport cr = new AllCustomerBalanceReport();
        public AllCustomerBalance()
        {
            InitializeComponent();
        }

        private void AllCustomerBalance_Load(object sender, EventArgs e)
        {
            List<allCustomerBalanceDB> _List = new List<allCustomerBalanceDB>();
            SqlDataReader dr1;
            if (sqlcon.State != ConnectionState.Open)
            {
                sqlcon.Open();
            }
            //string s = "select a.Article,t.VesterType,c.ColorName,m.MaterialName,sol.SolName,siz.SizeName,sum(s.ItemsQty) as ItemsQty,s.ItemsRate,sum(s.ItemsTotal ) as itemsTotal  from tblorders s, tblItems i,tblMaterial m, tblArticle a,tblVesterType t,tblColor c,tblSol sol, tblSize siz where s.ItemsID=i.ItemsID and i.ArticleID=a.ArticleID and i.VesterTypeID=t.VesterTypeID and i.ColorID=c.ColorID and i.SolID=sol.SolID and i.MaterialID=m.MaterialID and i.SizeID=siz.SizeID and s.invoiceid='" + InvoiceID+ "' group by Article,VesterType,ColorName,MaterialName,SolName,SizeName,ItemsRate,ItemsTotal";
            string s = "select customerid as ID,CONCAT('Mr.',TRIM( PName),' Sb' )as Name,PCompanyName as Company,cr as Credit,dr as Debit,balance as Balance from  AllCustomersBalance a, tblProfile p where a.customerid=p.ProfileId";
            SqlCommand cmda = new SqlCommand(s, sqlcon);//Advised to use parameterized query
            dr1 = cmda.ExecuteReader();
            while (dr1.Read())
            {
                _List.Add(new allCustomerBalanceDB
                {
                    ID = dr1["ID"].ToString(),
                    name = dr1["Name"].ToString(),
                    Cname = dr1["Company"].ToString(),
                    CR = dr1["Credit"].ToString(),
                    dR = dr1["Debit"].ToString(),
                    Balance = dr1["Balance"].ToString()
                });
                cr.SetDataSource(_List);
            }

            if (sqlcon.State != ConnectionState.Closed)
            {
                sqlcon.Close();
            }

            AllCustomerBal.ReportSource = cr;
            // cr.PrintToPrinter(1, false, 0, 0);
        }
    }
}
