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

namespace abcstore.Forms
{
    public partial class SearchProfileForm : Form
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbx"].ConnectionString);
        SqlCommand com;
        string str;
        DataTable dt;
        SqlDataAdapter ada;
        public string Ssname { get; set; }
        public string Sscode { get; set; }
        public string Scompany { get; set; }
        public int  cutom_vender { get; set; }
        
        public SearchProfileForm()
        {
            InitializeComponent();
        }

        private void SearchProfileForm_Load(object sender, EventArgs e)
        {
            con.Open();
            Search();
            con.Close(); 
        }

        private void Search()
        {
            
            str ="select pro.Pro_code,pro.Pro_name,pro.pro_fname,pro.pro_companyname,pro.pro_add,pro.pro_city,cv.name from Profile pro right join detail_CV cv on cv.pro_cv=pro.pro_cv where pro.pro_cv='"+cutom_vender+"'";
            com = new SqlCommand(str, con);
            ada = new SqlDataAdapter();
            dt = new DataTable();
            ada.SelectCommand = com;
            ada.Fill(dt);
            searchdataGridView.DataSource = dt;

            searchdataGridView.Columns[0].HeaderCell.Value = "Profile Code";
            searchdataGridView.Columns[1].HeaderCell.Value = "Name";
            searchdataGridView.Columns[2].HeaderCell.Value = "Father Name";
            searchdataGridView.Columns[3].HeaderCell.Value = "Company";
            searchdataGridView.Columns[4].HeaderCell.Value = "Address";
            searchdataGridView.Columns[5].HeaderCell.Value = "City";
            searchdataGridView.Columns[6].HeaderCell.Value = "Vender/Customer";
        }

        private void searchtextBox_TextChanged(object sender, EventArgs e)
        {
            //textchanged event of texbox when user enter a word in the textbox then through this dataview object string format it will filter and attached the filter result in to the datagridview
            DataView DV = new DataView(dt) { RowFilter = string.Format("pro_companyname LIKE '%{0}%'", searchtextBox.Text) };
            searchdataGridView.DataSource = DV;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void searchdataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                
                string scode = searchdataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
                string sname = searchdataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
                string scompany = searchdataGridView.Rows[e.RowIndex].Cells[4].Value.ToString();
                Ssname = sname;
                Sscode = scode;
               Scompany = scompany;
                Close();
            }
        }
    }
}
