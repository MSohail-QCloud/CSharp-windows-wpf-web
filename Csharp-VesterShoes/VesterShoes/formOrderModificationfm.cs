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
using VesterShoes.Reports;

namespace VesterShoes
{
    public partial class formOrderModificationfm : Form
    {
        SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["sqldbx"].ConnectionString);
        enumClass ec = new enumClass();
        public int Orderid { get; set; }
        public int intSortID { get; set; }
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


        public formOrderModificationfm(int orderid, int sortid)
        {
            Orderid = orderid;
            intSortID = sortid;
            InitializeComponent();
            comboJobStatus.DataSource = Enum.GetNames(typeof(enumClass.jobStates));
        }

        //int save = 0,completed=0,cancel=0,deleted=0;
        private void loadgridorder()
        {
            comboJobStatus.Enabled = true;
            jobstatesValue = 0;
            try
            {
                if (sqlcon.State != ConnectionState.Open)
                {
                    sqlcon.Open();
                }

                SqlCommand cmd3 = sqlcon.CreateCommand();
                cmd3.CommandType = CommandType.Text;
                cmd3.CommandText = "Select * from tblOrders o inner join tblJobStates s on o.jobStates=s.jobStates  inner join tblItems ti on o.ItemsID=ti.ItemsID where OrderId ='" + txtOrderid.Text + "' and Sortid='"+txtSortid.Text+"'";
                cmd3.ExecuteNonQuery();
                SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
                DataSet ds = new DataSet();
                da3.Fill(ds);
                if (sqlcon.State != ConnectionState.Closed)
                {
                    sqlcon.Close();
                }
                float sum = 0;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {

                    txtItemDetail.Text= dr["itemsDescription"].ToString();
                    txtQty.Text= dr["itemsqty"].ToString();
                    txtRate.Text= dr["ItemsRate"].ToString();
                    string orderdt = (dr["orderdatetime"].ToString());
                    if (orderdt!="")
                    {
                    txtOrderDate.Text= DateTime.Parse(dr["orderdatetime"].ToString()).ToString("dd-MM-yyyy");
                    }
                    string jobdatetime = dr["jobStartDate"].ToString();
                    if (jobdatetime!="")
                    {
                    txtJobStartDate.Text= DateTime.Parse(dr["jobStartDate"].ToString()).ToString("dd-MM-yyyy");
                    }
                    txtProcessJobid.Text= dr["JobID"].ToString();
                    txtInvoiceID.Text= dr["Invoiceid"].ToString();
                    comboJobStatus.SelectedIndex= int.Parse(dr["jobstates"].ToString());  
                    jobstatesValue= int.Parse(dr["jobstates"].ToString());
                    lblitemid.Text= (dr["ItemsID"].ToString());
                    txtTotal.Text = (int.Parse(txtRate.Text) * (int.Parse(txtQty.Text))).ToString();
                }
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }

        }

        int jobstatesValue = 0;
        private void loadcustomerinfo()
        {
            try
            {
                SqlDataReader dr;
                sqlcon.Open();
                string query = "Select * from tblOrders tm inner join tblProfile tf on tm.ProfileId=tf.ProfileId where OrderId ='" + txtOrderid.Text + "'";
                SqlCommand cmd = new SqlCommand(query, sqlcon);//Advised to use parameterized query
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    lblCustomerID.Text = (dr["ProfileId"].ToString());
                    lblCompanyName.Text = (dr["PCompanyName"].ToString());
                    //txtOrderid.Text = (dr["OrderId"].ToString());
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

      
/*
        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dt = DateTime.Now;
                string StrQuery = "UPDATE tblMasterOrder SET TotalAmount = '" + txtGrandTotal.Text + "' , Enteredon='" + dt + "',Enteredby='" + "" + "',jobStates='" + combOrderStatus.SelectedIndex + "' WHERE OrderId = '" + txtOrderid.Text + "' ";
                if (sqlcon.State != ConnectionState.Open)
                {
                    sqlcon.Open();
                }
                SqlCommand command1 = new SqlCommand(StrQuery, sqlcon);
                command1.ExecuteNonQuery();
                DataSet ds = new DataSet();
                string getEmpSQL = "Select * from tblOrders  where OrderId ='" + txtOrderid.Text + "'";
                SqlDataAdapter sda = new SqlDataAdapter(getEmpSQL, sqlcon);
                sda.Fill(ds);
                if (combOrderStatus.SelectedIndex == 1)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        //arrorderid = int.Parse(dr["orderdetailID"].ToString());
                        arrOrderID = int.Parse(dr["OrderId"].ToString());
                        arrSortID = int.Parse(dr["SortID"].ToString());
                        arrProfileId = int.Parse(dr["ProfileId"].ToString());
                        //arrCopanyname = (dr["Copanyname"].ToString());
                        arrItemsID = int.Parse(dr["ItemsID"].ToString());
                        //arrItemsDescription = (dr["ItemsDescription"].ToString());                        
                        arrItemsQty = int.Parse(dr["ItemsQty"].ToString());
                        arrjobStates = int.Parse(dr["jobStates"].ToString());
                        string insertQuery = "INSERT INTO tblProcessingDetail (orderID,SortID,Vend_orderid,StartDate,ItemID,OrderQty,LocationId,jobStates,CustProfileID) VALUES ('" + arrOrderID + "','" + arrSortID + "','" + arrOrderID+"-"+arrSortID + "','" + dt + "','" + arrItemsID + "','" + arrItemsQty + "','0','0','"+ arrProfileId + "')";
                        using (SqlCommand comm = new SqlCommand(insertQuery, sqlcon))
                        {
                            comm.ExecuteNonQuery();
                        }
                        
                    }
                }
            }
            catch (Exception es)
            {
                System.Windows.MessageBox.Show(es.ToString());

            }
            finally
            {
                //if (sqlcon.State != ConnectionState.Closed)
                {
                    sqlcon.Close();
                }
            }
            this.Close();
        }
*/
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



        
        private void formOrderModificationfm_Load(object sender, EventArgs e)
        {
            //flagtoLoad = 1;
            if (Orderid==0)
            {
                return;
            }
            txtOrderid.Text = Orderid.ToString();
            txtSortid.Text = intSortID.ToString();
            loadcustomerinfo();
            loadgridorder();
            flagtoLoad = 0;

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

        int flagtoLoad = 1;

        private void txtOrderid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                loadgridorder();
                loadcustomerinfo();
            }
        }

        private void txtOrderid_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (e.KeyChar != (char)8 && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtOrderid_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtProcessid_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtProcessid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtOrderid.Text = "";
                txtSortid.Text = "";
                string s = "select orderid from tblOrders where JobID='" + txtProcessid.Text + "'";
                txtOrderid.Text = f.findnumber(s).ToString();
                string s1 = "select Sortid from tblOrders where JobID='" + txtProcessid.Text + "'";
                txtSortid.Text = f.findnumber(s1).ToString();
                loadgridorder();
                loadcustomerinfo();
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdateOrder_Click(object sender, EventArgs e)
        {

        }
        VestureClass vc= new VestureClass();
        
        private void comboJobStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (flagtoLoad==1)
            {
                return;
            }
           
            if (comboJobStatus.SelectedIndex<jobstatesValue)
            {
                comboJobStatus.SelectedIndex = jobstatesValue;
                lblerrormsg.Text = "You can't Move back to Job, Once Processed.";
                return;
            }
            int jobstatesid = f.findnumber("select jobstates from tblJobStates where JobStatesDesc='"+comboJobStatus.Text+"'");
            vc.Update("update tblOrders set jobStates="+jobstatesid+" where OrderID="+txtOrderid.Text+" and SortID="+txtSortid.Text+"");
            if (comboJobStatus.SelectedIndex==8)
            {
                comboJobStatus.Enabled = false;
            }
        }
        //update item button
        private void button1_Click(object sender, EventArgs e)
        {
            itemsForm inf=new itemsForm(lblCompanyName.Text,(lblCustomerID.Text),int.Parse(txtOrderid.Text),int.Parse(txtSortid.Text),int.Parse(lblitemid.Text));
            inf.ShowDialog();
            loadgridorder();
        }

        private void btnjobcardPrint_Click(object sender, EventArgs e)
        {
            lblerrormsg.Text = "";
            if (txtProcessid.Text=="")
            {
                lblerrormsg.Text = "Job Not Started.";
            }
            try
            {
jobCardForm jcd = new jobCardForm("Duplicate", txtOrderid.Text, txtSortid.Text);
            jcd.Show();
            }
            catch (Exception es)
            {
                lblerrormsg.Text = es.Message;
            }
            
        }
    }
}
