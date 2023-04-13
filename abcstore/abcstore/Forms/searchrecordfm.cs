using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace abcstore
{
    public partial class searchrecordfm : Form
    {
        
        public searchrecordfm()
        {
            InitializeComponent();
        }

       SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbx"].ConnectionString);
        SqlCommand com;
        string str;
        DataTable dt;
        SqlDataAdapter ada;
        public string Ssname { get; set; }
        //public string Ssid { get; set; }
        public string Sscode { get; set; }
        public string Sstype { get; set; }
        public string Sssize { get; set; }
        public string Ssprice { get; set; }
        public string Ssdetail { get; set; }
        public string Stukmess { get; set; }
        
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
            
        }

        private void searchrecord_Load(object sender, EventArgs e)
        {
            //con.Open();
            Search();

            //con.Close(); 
        }

       

        private void Search()
        {
            str =
                "select  p.p_code,p.p_name,p.p_type,p.p_size,p.p_price,tm.nameTM,p.p_detail from store_product p right join detail_TM tm on tm.p_TuckMess=p.p_TuckMess p.Disable='N'";
            //str = "select * from store_product";
            con.Open();
            com = new SqlCommand(str, con);
            ada = new SqlDataAdapter();
            dt = new DataTable();
            ada.SelectCommand = com;
            ada.Fill(dt);
            searchdataGridView.DataSource = dt;
            con.Close();
            searchdataGridView.Columns[0].HeaderCell.Value = "Product Code";
            searchdataGridView.Columns[1].HeaderCell.Value = "Name";
            searchdataGridView.Columns[2].HeaderCell.Value = "Type";
            searchdataGridView.Columns[3].HeaderCell.Value = "Size";
            searchdataGridView.Columns[4].HeaderCell.Value = "Price";
            searchdataGridView.Columns[5].HeaderCell.Value = "TuckShop/Mess";
            searchdataGridView.Columns[6].HeaderCell.Value = "Detail";
        }

        private void searchdataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void searchtextBox_TextChanged(object sender, EventArgs e)
        {
            //textchanged event of texbox when user enter a word in the textbox then through this dataview object string format it will filter and attached the filter result in to the datagridview
            DataView DV = new DataView(dt) {RowFilter = string.Format("p_name LIKE '%{0}%'", searchtextBox.Text)};
            searchdataGridView.DataSource = DV;
        }

        public void searchdataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                string scode = searchdataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
                string sname = searchdataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
                string stype = searchdataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                string ssize = searchdataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
                string sprice = searchdataGridView.Rows[e.RowIndex].Cells[4].Value.ToString();
                string stukmes = searchdataGridView.Rows[e.RowIndex].Cells[5].Value.ToString();
                string sdetail = searchdataGridView.Rows[e.RowIndex].Cells[6].Value.ToString();
                Ssname = sname;
                Sscode = scode;
                Sstype = stype;
                Sssize = ssize;
                Ssprice = sprice;
                Ssdetail = sdetail;
                Stukmess = stukmes;
                Close();
            }

        }

        private void codesearchtextBox_TextChanged(object sender, EventArgs e)
        {
            //textchanged event of texbox when user enter a word in the textbox then through this dataview object string format it will filter and attached the filter result in to the datagridview
            //DataView DV = new DataView(dt) { RowFilter = string.Format("p_code LIKE '%{0}%'", codesearchtextBox.Text) };
            //searchdataGridView.DataSource = DV;
        }
        

    }
}
