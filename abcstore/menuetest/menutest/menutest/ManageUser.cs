using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Configuration;

namespace menutest
{
    public partial class ManageUser : Form
    {
        //MySqlConnection conn = connectionService.getConnection();
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbx"].ConnectionString);
        
        public ManageUser()
        {
            InitializeComponent();
        }

        private SqlDataAdapter da;
        private DataSet ds;
        private DataTable dtSource;

        private void ManageUser_Load(object sender, EventArgs e)
        {
            loaddata();
        }
        public void loaddata()
        {
            string sql = "SELECT * FROM  tbl_User ";

            LoadDS(sql);
        }

        private void LoadDS(string sSQL)
        {
            try
            {
                //Set the DataAdapter's query.
                da = new SqlDataAdapter(sSQL, con);
                ds = new DataSet();

                // Fill the DataSet.
                da.Fill(ds, "Items");

                // Set the source table.
                dtSource = ds.Tables["Items"];

                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns[0].Width = 50;
                dataGridView1.Columns[0].HeaderText = "UID";
                dataGridView1.Columns[1].Width = 70;
                dataGridView1.Columns[1].HeaderText = "UserName";
                dataGridView1.Columns[2].Width = 40;
                dataGridView1.Columns[2].HeaderText = "Position";
                dataGridView1.Columns[3].Width = 100;
                dataGridView1.Columns[3].HeaderText = "Password";
                DataGridViewButtonColumn dataGridViewColumn = new DataGridViewButtonColumn();
                dataGridView1.Columns.Add(dataGridViewColumn);
                dataGridViewColumn.HeaderText = "Privilege";
                dataGridViewColumn.Text = "Access";
                dataGridViewColumn.Name = "Access";
                dataGridViewColumn.UseColumnTextForButtonValue = true;
                dataGridViewColumn.Width = 50;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                new UserRole(row.Cells[1].Value.ToString()).ShowDialog();
            }
            catch
            {
            }
        }
    }
}
