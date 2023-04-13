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
        

    public partial class UserRole : Form
    {
        //SqlConnection conn = connectionService.getConnection();
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbx"].ConnectionString);
        
        public UserRole(string uid)
        {
            InitializeComponent();
            this.lbluid.Text = uid;
        }
        private SqlDataAdapter da;
        private DataSet ds;
        private DataTable dtSource;

        private void Form1_Load(object sender, EventArgs e)
        {
            Databind();
        }
        public static DataSet GetDataSet(string sql)
        {
            SqlConnection conn = connectionService.getConnection();
            SqlCommand selectCommand = new SqlCommand(sql, conn);
            SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            conn.Close();
            return dataSet;
        }
        public static DataTable GetDataTable(string sql)
        {
            Console.WriteLine(sql);
            DataSet dataSet = GetDataSet(sql);
            if (dataSet.Tables.Count > 0)
            {
                return dataSet.Tables[0];
            }
            return null;
        }
       
        public void Databind()
        {
            con.Open();
            string sql = "SELECT  * FROM  MNU_USERROLE where UID = '" + this.lbluid.Text + "'";
            SqlCommand command = new SqlCommand(sql, con);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            command.ExecuteNonQuery();
            if (GetDataTable(sql).Rows.Count > 0)
            {
                string str2 = "SELECT  * FROM  vw_pagerole where UID = '" + this.lbluid.Text + "' ";
                SqlCommand command2 = new SqlCommand(str2, con);
                command2.ExecuteNonQuery();
                DataTable dataTable = GetDataTable(str2);
                this.dataGridView1.DataSource = dataTable;
                this.dataGridView1.Refresh();
                this.dataGridView1.Parent.Refresh();
            }
            else
            {
                string str3 = "SELECT   MENUPARVAL  , FRM_NAME,     FRM_CODE , '' AS  UID, 0 AS STATUS FROM   mnu_submenu ";
                SqlCommand command3 = new SqlCommand(str3, con);
                command3.ExecuteNonQuery();
                DataTable table3 = GetDataTable(str3);
                this.dataGridView1.DataSource = table3;
            }
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            int count = this.dataGridView1.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                if (dataGridView1.Rows[i].Cells[5].Value.ToString() == "1")
                {
                    dataGridView1.Rows[i].Cells[0].Value = true;
                }
            }
        }

        private void ChkAll_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i <= (this.dataGridView1.RowCount - 1); i++)
            {
                this.dataGridView1[0, i].Value = this.ChkAll.Checked;
            }
            this.dataGridView1.EndEdit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.dataGridView1.EndEdit();
            int count = this.dataGridView1.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                string str = this.dataGridView1.Rows[i].Cells[3].Value.ToString();
                if ((this.dataGridView1.Rows[i].Cells[5].Value.ToString() == "0") && (this.dataGridView1.Rows[i].Cells[4].Value.ToString() == ""))
                {
                    SqlCommand com = new SqlCommand("insert into MNU_USERROLE (UID,FRM_CODE,status)  values ('" + lbluid.Text + "', '" + str + "', '1' )", con);
                    try
                    {
                        SqlDataAdapter adap = new SqlDataAdapter(com);
                        DataTable table = new DataTable();
                        adap.Fill(table);
                        
                        con.Close();
                        lblmsg.Text = "Item Successfully saved";
                        
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.ToString());
                    }
                    
                }
                else if (Convert.ToBoolean(this.dataGridView1.Rows[i].Cells[0].Value))
                {
                    SqlCommand com1 = new SqlCommand("update MNU_USERROLE set status= '1'     where FRM_CODE = '" + str + "' and uid   = '" + this.lbluid.Text + "'", con);
                    try
                    {
                        SqlDataAdapter adap1 = new SqlDataAdapter(com1);
                        DataTable table1 = new DataTable();
                        adap1.Fill(table1);
                       
                        con.Close();
                        lblmsg.Text = "Updated";
                        this.dataGridView1.EndEdit();
                        this.dataGridView1.Refresh();
                        this.dataGridView1.ResetBindings();
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.ToString());
                    }
                   
                }
                else
                {
                    SqlCommand com2 = new SqlCommand("update MNU_USERROLE set status= '0'     where FRM_CODE = '" + str + "' and uid   = '" + this.lbluid.Text + "'", con);
                    try
                    {
                        SqlDataAdapter adap2 = new SqlDataAdapter(com2);
                        DataTable table2 = new DataTable();
                        adap2.Fill(table2);
                        lblmsg.Text = "Updated";
                        con.Close();
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.ToString());
                    }
                }
            }
            //base.Hide();
            //new UserRole(this.lbluid.Text).ShowDialog();
        }
    }
}
