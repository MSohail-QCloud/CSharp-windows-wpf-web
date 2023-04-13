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

namespace lasticecream
{
    
    public partial class billsdetail : Form
    {
        OleDbConnection olecon = new OleDbConnection(ConfigurationManager.ConnectionStrings["Accdbx"].ConnectionString);
        DataSet ds = new DataSet();
        public billsdetail()
        {
            InitializeComponent();
        }

        private void billsdetail_Load(object sender, EventArgs e)
        {
            showlistofbiils();
        }

        private void showlistofbiils()
        {
            olecon.Open();
            DataTable dt = new DataTable();
            OleDbDataAdapter oleadapt = new OleDbDataAdapter("select * from mastebill order by billnumber desc", olecon);
            oleadapt.Fill(dt);
            dataGrid_listofbills.DataSource = dt;
            dataGrid_listofbills.Columns[0].HeaderText = "Bill id#";
            dataGrid_listofbills.Columns[1].HeaderText = "Customer Name";
            dataGrid_listofbills.Columns[2].HeaderText = "Table no#";
            dataGrid_listofbills.Columns[3].HeaderText = "Bill no#";
            dataGrid_listofbills.Columns[4].HeaderText = "Bill amount";
            dataGrid_listofbills.Columns[5].HeaderText = "Paid Amount";
            dataGrid_listofbills.Columns[6].HeaderText = "Date/time";
            olecon.Close();
        }

        private void showbildetail()
        {
            olecon.Open();
            DataTable dt = new DataTable();
            OleDbDataAdapter oleadapt = new OleDbDataAdapter("select numbershumar,menu_name,menurate,menu_qty,total from detailbill where masterbill_id= order by numbershumar ", olecon);
            
            oleadapt.Fill(dt);
            dataGrid_listofbills.DataSource = dt;
            dataGrid_listofbills.Columns[0].HeaderText = "Number#";
            dataGrid_listofbills.Columns[1].HeaderText = "Menu";
            dataGrid_listofbills.Columns[2].HeaderText = "Rate";
            dataGrid_listofbills.Columns[3].HeaderText = "Qty";
            dataGrid_listofbills.Columns[4].HeaderText = "Total";
            olecon.Close();
        }
        int billnumber;
        private void dataGrid_listofbills_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            billnumber = int.Parse( dataGrid_listofbills.Rows[e.RowIndex].Cells[3].Value.ToString());
            //showbildetail();
        }
    }
}
