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
using VesterShoes.classes;

namespace VesterShoes
{
    public partial class OrderProduction : Form
    {
        SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["sqldbx"].ConnectionString);
        enumClass ec = new enumClass();
        public int Orderid { get; set; }
        public OrderProduction(int orderid)
        {
            Orderid = orderid;
            InitializeComponent();
            //combOrderStatus.DataSource = Enum.GetNames(typeof(enumClass.jobStates));
            loadgridorder(Orderid);
            loadcustomerinfo(Orderid);
        }

        private void OrderProduction_Load(object sender, EventArgs e)
        {

        }

        //int save = 0,completed=0,cancel=0,deleted=0;
        private void loadgridorder(int id)
        {
            try
            {
                if (sqlcon.State != ConnectionState.Open)
                {
                    sqlcon.Open();
                }

                SqlCommand cmd3 = sqlcon.CreateCommand();
                cmd3.CommandType = CommandType.Text;
                cmd3.CommandText = "Select * from tblProcessingDetail o inner join tblJobStates s on o.jobStates=s.jobStates  inner join tblItems ti on o.ItemID=ti.ItemsID where OrderId ='" + id + "'";
                cmd3.ExecuteNonQuery();
                SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
                DataSet ds = new DataSet();
                da3.Fill(ds);
                if (sqlcon.State != ConnectionState.Closed)
                {
                    sqlcon.Close();
                }
                //float sum = 0;
                //foreach (DataRow dr in ds.Tables[0].Rows)
                //{
                //    sum += float.Parse(dr["ItemsTotal"].ToString());
                //}
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = ds.Tables[0].DefaultView;
                //txtGrandTotal.Text = sum.ToString();
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }

        }
        //int arrorderid ;
        int arrOrderID;
        int arrSortID;
        int arrProfileId;
        string arrCopanyname;
        int arrItemsID;
        string arrItemsDescription;
        int arrIsStampAdded;
        int arrisBoxAdded;
        int arrItemsQty;
        int arrjobStates;
        private void btnCancel_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    DateTime dt = DateTime.Now;
            //    string StrQuery = "UPDATE tblMasterOrder SET TotalAmount = '" + txtGrandTotal.Text + "' , Enteredon='" + dt + "',Enteredby='" + "" + "',jobStates='" + combOrderStatus.SelectedIndex + "' WHERE OrderId = '" + lblOrderid.Text + "' ";
            //    if (sqlcon.State != ConnectionState.Open)
            //    {
            //        sqlcon.Open();
            //    }
            //    SqlCommand command1 = new SqlCommand(StrQuery, sqlcon);
            //    command1.ExecuteNonQuery();
            //    DataSet ds = new DataSet();
            //    string getEmpSQL = "Select * from tblOrders  where OrderId ='" + lblOrderid.Text + "'";
            //    SqlDataAdapter sda = new SqlDataAdapter(getEmpSQL, sqlcon);
            //    sda.Fill(ds);
            //    if (combOrderStatus.SelectedIndex == 1)
            //    {
            //        foreach (DataRow dr in ds.Tables[0].Rows)
            //        {
            //            //arrorderid = int.Parse(dr["orderdetailID"].ToString());
            //            arrOrderID = int.Parse(dr["OrderId"].ToString());
            //            arrSortID = int.Parse(dr["SortID"].ToString());
            //            arrProfileId = int.Parse(dr["ProfileId"].ToString());
            //            //arrCopanyname = (dr["Copanyname"].ToString());
            //            arrItemsID = int.Parse(dr["ItemsID"].ToString());
            //            //arrItemsDescription = (dr["ItemsDescription"].ToString());                        
            //            arrItemsQty = int.Parse(dr["ItemsQty"].ToString());
            //            arrjobStates = int.Parse(dr["jobStates"].ToString());
            //            string insertQuery = "INSERT INTO tblProcessingDetail (orderID,SortID,Vend_orderid,StartDate,ItemID,OrderQty,LocationId,jobStates,CustProfileID) VALUES ('" + arrOrderID + "','" + arrSortID + "','" + arrOrderID + "-" + arrSortID + "','" + dt + "','" + arrItemsID + "','" + arrItemsQty + "','0','0','" + arrProfileId + "')";
            //            using (SqlCommand comm = new SqlCommand(insertQuery, sqlcon))
            //            {
            //                comm.ExecuteNonQuery();
            //            }

            //        }
            //    }
            //}
            //catch (Exception es)
            //{
            //    System.Windows.MessageBox.Show(es.ToString());

            //}
            //finally
            //{
            //    //if (sqlcon.State != ConnectionState.Closed)
            //    {
            //        sqlcon.Close();
            //    }
            //}
            this.Close();
        }
        functions f = new functions();
        string orderdetailid;
        string Status;
        string SortID;
        string Stamp;
        string Box;
        string Qty;
        string Rate;
        string total;

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }



        private void loadcustomerinfo(int id)
        {
            try
            {
                SqlDataReader dr;
                sqlcon.Open();
                string query = "Select * from tblMasterOrder tm inner join tblProfile tf on tm.ProfileId=tf.ProfileId where OrderId ='" + id + "'";
                SqlCommand cmd = new SqlCommand(query, sqlcon);//Advised to use parameterized query
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    lblCustomerID.Text = (dr["ProfileId"].ToString());
                    lblCompanyName.Text = (dr["PCompanyName"].ToString());
                    lblOrderid.Text = (dr["OrderId"].ToString());
                    //txtStatusNote.Text = (dr["ReasonaboutStatus"].ToString());
                    //combOrderStatus.SelectedIndex = int.Parse(dr["jobStates"].ToString());
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
                sqlcon.Close();
            }

        }
        private void formOrderModificationfm_Load(object sender, EventArgs e)
        {


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellEndEdit_1(object sender, DataGridViewCellEventArgs e)
        {

            //if ((e.ColumnIndex == 6) || (e.ColumnIndex == 7))
            //{
            //    DataGridViewTextBoxCell cellQty = (DataGridViewTextBoxCell)dataGridView1.Rows[e.RowIndex].Cells[6];
            //    DataGridViewTextBoxCell cellAmount = (DataGridViewTextBoxCell)dataGridView1.Rows[e.RowIndex].Cells[8];
            //    DataGridViewTextBoxCell cellRate = (DataGridViewTextBoxCell)dataGridView1.Rows[e.RowIndex].Cells[7];
            //    cellAmount.Value = (int)cellQty.Value * (int)cellRate.Value;
            //    int sum = 0;
            //    foreach (DataGridViewRow row in dataGridView1.Rows)
            //    {
            //        DataGridViewTextBoxCell Amount = (DataGridViewTextBoxCell)dataGridView1.Rows[int.Parse((row).ToString())].Cells[8];
            //        sum += int.Parse(Amount.ToString());
            //    }
            //    txtGrandTotal.Text = sum.ToString();
            //}

            //orderdetailid = (dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            //Status = (dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
            //SortID = (dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
            ////Stamp = (dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
            ////Box = (dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString());
            //Qty = (dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
            //Rate = (dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString());
            //total = (int.Parse(Qty) * (int.Parse(Rate))).ToString();
            //try
            //{
            //    DateTime dt = DateTime.Now;
            //    int stat = f.findnumber("Select jobstates from tbljobstates where JobStatesDesc='" + Status + "'");
            //    string StrQuery = "UPDATE tblOrders SET Enteredby='" + "" + "',jobStates='" + stat + "' ,ItemsQty='" + Qty + "',ItemsRate='" + Rate + "', ItemsTotal='" + total + "'  WHERE orderdetailID = '" + orderdetailid + "' ";
            //    sqlcon.Open();
            //    SqlCommand command1 = new SqlCommand(StrQuery, sqlcon);
            //    command1.ExecuteNonQuery();
            //    sqlcon.Close();
            //    //loadgridorder(Orderid);


            //}
            //catch (Exception es)
            //{
            //    System.Windows.MessageBox.Show(es.ToString());

            //}
            //finally
            //{
            //    sqlcon.Close();
            //}

        }

        private void combOrderStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (combOrderStatus.SelectedIndex != 0 && combOrderStatus.SelectedIndex != 1)
            //{
            //    System.Windows.MessageBox.Show("Orders Can only Start from here. Notice that Started order does not show here. It moved in Production, further changes are applied in Production.");
            //    combOrderStatus.SelectedIndex = 1;
            //}
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
