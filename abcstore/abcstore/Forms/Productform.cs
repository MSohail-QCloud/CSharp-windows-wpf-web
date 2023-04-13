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

namespace abcstore
{
    public partial class Productform : Form
    {
        public Productform()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbx"].ConnectionString);
        SqlCommand com;
        string str;
        DataTable dt;
        SqlDataAdapter ada;
        
        private void Productform_Load(object sender, EventArgs e)
        {
            str = "select p.p_code,p.p_name,p.p_type,p.p_size,p.p_price,p_detail,s.quantity from store_product p left join store_stock s on p.p_code=s.p_code";
            com = new SqlCommand(str, con);
            ada = new SqlDataAdapter();
            dt = new DataTable();
            ada.SelectCommand = com;
            ada.Fill(dt);
            searchdataGridView.DataSource = dt;
            searchdataGridView.Columns[0].HeaderCell.Value = "Item Code";
            searchdataGridView.Columns[1].HeaderCell.Value = "Name";
            searchdataGridView.Columns[2].HeaderCell.Value = "Type";
            searchdataGridView.Columns[3].HeaderCell.Value = "Size";
            searchdataGridView.Columns[4].HeaderCell.Value = "Price";
            searchdataGridView.Columns[4].HeaderCell.Value = "Detail";

            //searchdataGridView.ShowCellToolTips = false;
        }
        private ToolTip tp;

        private void searchdataGridView_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1) return;
            var cell = searchdataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];

            if (cell.Value != null)
            {
                tp = new ToolTip();
                tp.InitialDelay = 1000;
                searchdataGridView.ShowCellToolTips = false;
                tp.SetToolTip(searchdataGridView, cell.Value.ToString());
            }
        }

        private void searchdataGridView_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (tp != null)
                tp.Dispose();
        }

        private void Closebutton_Click(object sender, EventArgs e)
        {
            Close();
        }


    }
}
