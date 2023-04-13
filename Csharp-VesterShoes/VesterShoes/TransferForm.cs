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
    public partial class TransferForm : Form
    {
        SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["sqldbx"].ConnectionString);
        public string sYSUSER { get; set; }
        public string lOGUSER { get; set; }
        public TransferForm(string Suser,string luser)
        {
            InitializeComponent();
            sYSUSER = Suser;
            lOGUSER = luser;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void dislableINPut()
        {
            txtOrderNumber.Enabled = false;
            txtJobID.Enabled = false;
            txtBillNumber.Enabled = false;
            btnInvoiceDelete.Enabled = true;
            btnBilllRetrive.Enabled = true;
        }
        private void enableInput()
        {
            txtOrderNumber.Enabled = true;
            txtJobID.Enabled = true;
            txtBillNumber.Enabled = true;
            btnInvoiceDelete.Enabled = false;
            btnTransfer.Enabled = false;
            btnBilllRetrive.Enabled = false;
        }
        functions f = new functions();
        //Order number
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtOrderNumber.Text.Contains('-'))
                {
                    try
                    {
                        dislableINPut();
                        string[] ord = txtOrderNumber.Text.Split('-');
                        txtJobID.Text = f.findnumber("select JobID from tblOrders where OrderID ='"+ord[0]+"' and SortID='"+ord[1]+"'").ToString();
                        txtBillNumber.Text = f.findnumber("select Invoiceid from tblOrders where OrderID='"+ord[0]+"' and SortID='"+ord[1]+"'").ToString();
                        if (txtJobID.Text != "")
                        {
                            loadJobdetail();
                        }
                        if (txtBillNumber.Text != "")
                        {
                            loadInvoiceDetail();
                            billstatus = f.findnumber("select DeleteBill from tblMasterInvoice where Invoiceid='" + txtBillNumber.Text + "'");
                            if (billstatus == 0)
                            {
                                btnBilllRetrive.Enabled = false;
                                btnInvoiceDelete.Enabled = true;
                            }
                            else if (billstatus == 1)
                            {
                                btnBilllRetrive.Enabled = false;
                                btnInvoiceDelete.Enabled = true;
                            }
                            else
                            {
                                btnBilllRetrive.Enabled = false;
                                btnInvoiceDelete.Enabled = false;
                            }
                        }
                    }
                    catch (Exception es)
                    {
                        MessageBox.Show(es.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Order Number Not in correct Format.");
                }
            }
        }

        private void TransferForm_Load(object sender, EventArgs e)
        {
            lblPreviouseCustomer.Text = "";
            lblPreviousCustID.Text = "";
            btnInvoiceDelete.Enabled = false;
            btnBilllRetrive.Enabled = false;
        }

        private void txtJobID_TextChanged(object sender, EventArgs e)
        {
            if (txtJobID.Text == "0")
            {
                txtJobID.Text = "";
            }
        }

        private void txtBillNumber_TextChanged(object sender, EventArgs e)
        {
            if (txtBillNumber.Text == "0")
            {
                txtBillNumber.Text = "";
            }
        }

        private void btnRefrsh_Click(object sender, EventArgs e)
        {
            enableInput();
            //if (dgv_invoicDetail.Rows.Count > 0)
            //{
            //    dgv_invoicDetail.Rows.Clear();
            //}
            //if (dgv_JobDetail.Rows.Count > 0)
            //{
            //    dgv_JobDetail.Rows.Clear();
            //}
            //if (dgv_Orderdetail.Rows.Count > 0)
            //{
            //    dgv_Orderdetail.Rows.Clear();
            //}
        }
        int billstatus=2;
        private void txtJobID_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtJobID.Text == "")
            {
                return;
            }
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    dislableINPut();
                    txtOrderNumber.Text = f.findname("select CONCAT(OrderID,'-',SortID) as ordernumber from tblOrders where JobID='"+txtJobID.Text+"'");
                    if (txtOrderNumber.Text.Contains('-'))
                    {
                        string[] ord = txtOrderNumber.Text.Split('-');
                        txtBillNumber.Text = f.findnumber("select Invoiceid from tblOrders where OrderID='" + ord[0] + "' and SortID='" + ord[1] + "'").ToString();
                        loadJobdetail();
                        loadInvoiceDetail();
                        
                        Orderdetail(ord[0],ord[1]);
                    }
                }
                catch (Exception es)
                {
                    MessageBox.Show(es.Message);
                }

            }
        }
        private void Orderdetail(string ord, string sor)
        {
            if (sqlcon.State != ConnectionState.Open)
            {
                sqlcon.Open();
            }
            SqlCommand cmd3 = sqlcon.CreateCommand();
            cmd3.CommandType = CommandType.Text;
            cmd3.CommandText = "select orderdetailID,concat(OrderID,'-',SortID)as OrderID,i.ItemsDescription,ItemsQty,ItemsRate,ItemsTotal,j.JobStatesDesc from tblOrders o, tblItems i,tblJobStates j where o.ItemsID=i.ItemsID and o.jobStates=j.jobStates and OrderID='" + ord + "' and SortID='" + sor + "'";
            cmd3.ExecuteNonQuery();
            DataTable dtOrder = new DataTable();
            SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
            da3.Fill(dtOrder);
            dgv_Orderdetail.DataSource = dtOrder;
            //dgv_Orderdetail.Columns["VesterTypeID"].Visible = false;
            if (sqlcon.State != ConnectionState.Closed)
            {
                sqlcon.Close();
            }
        }
        private void loadJobdetail()
        {
            if (sqlcon.State != ConnectionState.Open)
            {
                sqlcon.Open();
            }
            SqlCommand cmd3 = sqlcon.CreateCommand();
            cmd3.CommandType = CommandType.Text;
            cmd3.CommandText = "select p.PName as VenderName,pr.vender_type_name as Job_Type,IssueQty as Issue_Qty,vo.IssueRate as Rate,cast(vo.IssueDate as date)as IssueOn,ReturnDate as ReturnON,vo.ReturnQty,vo.EnteredBy,vo.updateon from tblVenderOrders vo , tblProfile p, tblProcessStates pr where vo.ProfileId = p.ProfileId and pr.vender_type_id = vo.vender_type_id and vo.ProcessiingID = '"+txtJobID.Text+"' order by vo.vender_type_id";
            cmd3.ExecuteNonQuery();
            DataTable dtOrder = new DataTable();
            SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
            da3.Fill(dtOrder);
            dgv_JobDetail.DataSource = dtOrder;
            if (sqlcon.State != ConnectionState.Closed)
            {
                sqlcon.Close();
            }
        }
        DataTable dtInvoice;
        private void loadInvoiceDetail()
        {
            if (sqlcon.State != ConnectionState.Open)
            {
                sqlcon.Open();
            }
            SqlCommand cmd3 = sqlcon.CreateCommand();
            cmd3.CommandType = CommandType.Text;
            cmd3.CommandText = "select InvoiceID,iarticle as Article,itemDescription as Detail, sol as Sol,Size as Size,itemQty as Qty,Rate,itemTotal as Total from tblDetailInvoice d where InvoiceID='"+txtBillNumber.Text+"'";
            cmd3.ExecuteNonQuery();
             dtInvoice = new DataTable();
            SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
            da3.Fill(dtInvoice);
            dgv_invoicDetail.DataSource = dtInvoice;
            if (sqlcon.State != ConnectionState.Closed)
            {
                sqlcon.Close();
            }
            billstatus = f.findnumber("select DeleteBill from tblMasterInvoice where Invoiceid='" + txtBillNumber.Text + "'");
            if (billstatus == 0)
            {
                btnBilllRetrive.Enabled = false;
                btnInvoiceDelete.Enabled = true;
            }
            else if (billstatus == 1)
            {
                btnBilllRetrive.Enabled = false;
                btnInvoiceDelete.Enabled = true;
            }
            else
            {
                btnBilllRetrive.Enabled = false;
                btnInvoiceDelete.Enabled = false;
            }
        }

        private void CustomerComboLoad()
        {
            try
            {

                if (sqlcon.State != ConnectionState.Open)
                {
                    sqlcon.Open();
                }

                SqlCommand cmd3 = sqlcon.CreateCommand();
                cmd3.CommandType = CommandType.Text;
                cmd3.CommandText = "Select ProfileId,PCompanyName from tblProfile where PType='0' order by PCompanyName ";
                cmd3.ExecuteNonQuery();
                SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
                DataSet ds = new DataSet();
                da3.Fill(ds);
                if (sqlcon.State != ConnectionState.Closed)
                {
                    sqlcon.Close();
                }
                //CombVender.au = false;
                if (ds.Tables[0].Rows.Count > 0)
                {

                    ComboCustomer.DisplayMember = "PCompanyName";
                    ComboCustomer.ValueMember = "ProfileId";
                    ComboCustomer.DataSource = ds.Tables[0];
                }
                else
                {
                    ds.Tables[0].Clear();
                    ComboCustomer.DisplayMember = "PCompanyName";
                    ComboCustomer.ValueMember = "ProfileId";
                    ComboCustomer.DataSource = ds.Tables[0];

                }
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void rdbtnOrderTransfer_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbtnOrderTransfer.Checked == true)
            {
                string[] ord = txtOrderNumber.Text.Split('-');
                ComboCustomer.Enabled = true;
                CustomerComboLoad();
                lblPreviouseCustomer.Text = f.findname("select PCompanyName from tblOrders o, tblProfile p where o.ProfileId=p.ProfileId and o.OrderID='"+ord[0]+"'");
                lblPreviousCustID.Text = f.findname("select o.ProfileId from tblOrders o, tblProfile p where o.ProfileId=p.ProfileId and o.OrderID='" + ord[0]+"'");
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void rdbtnInvoiceTransfer_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbtnInvoiceTransfer.Checked == true)
            {
                ComboCustomer.Enabled = true;
                CustomerComboLoad();
                lblPreviouseCustomer.Text = f.findname("select PCompanyName from tblMasterInvoice m , tblProfile p where m.ProfileId=p.ProfileId and m.InvoiceID='" + txtBillNumber.Text + "'");
                lblPreviousCustID.Text = f.findname("select m.ProfileId from tblMasterInvoice m , tblProfile p where m.ProfileId=p.ProfileId and m.InvoiceID='" + txtBillNumber.Text + "'");

            }
        }

        private void ComboCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblSelectedCustomerid.Text = ComboCustomer.SelectedValue.ToString();
        }

        private void txtBillNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtBillNumber.Text != "")
                {
                    dislableINPut();
                //    int billstatus = f.findnumber("select DeleteBill from tblMasterInvoice where Invoiceid='" + txtBillNumber.Text + "'");
                //    if (billstatus == 0)
                //    {
                //        btnBilllRetrive.Enabled = false;
                //        btnInvoiceDelete.Enabled = true;
                //    }
                //    else if(billstatus==1)
                //    {
                //        btnBilllRetrive.Enabled = false;
                //        btnInvoiceDelete.Enabled = true;
                //    }
                //    else
                //    {
                //        btnBilllRetrive.Enabled = false;
                //        btnInvoiceDelete.Enabled = false;
                //    }
                    txtOrderNumber.Text = f.findname("select CONCAT(OrderID,'-',SortID) as ordernumber from tblOrders where Invoiceid='" + txtBillNumber.Text + "'");
                    if (txtOrderNumber.Text != "")
                    {
                        string[] ord = txtOrderNumber.Text.Split('-');
                        txtJobID.Text = f.findnumber("select JobID from tblOrders where OrderID ='" + ord[0] + "' and SortID='" + ord[1] + "'").ToString();
                        Orderdetail(ord[0], ord[1]);
                        loadJobdetail();
                    }
                    loadInvoiceDetail();
                }
            }
        }
        VestureClass vc = new VestureClass();
        private void btnTransfer_Click(object sender, EventArgs e)
        {
            if (lblSelectedCustomerid.Text != "")
            {
                if (rdbtnOrderTransfer.Checked == true)
                {
                    string[] ord = txtOrderNumber.Text.Split('-');
                    string str = "update tblOrders set ProfileId ='"+lblSelectedCustomerid.Text+"' where OrderID ='"+ord[0]+"' and SortID='"+ord[1]+"'";
                    vc.Update(str);
                    str = "insert into tblChangeLog(LogDatetime,OrderNumber,JobID,BillNumber,ChangeWhat,ChangeFrom,ChangeTo,ChangeBy,ChangeIn,ChangeOn)values('"+DateTime.Now.ToString("yyyy-MM-dd")+"','"+txtOrderNumber.Text+"','"+txtJobID.Text+"','"+txtBillNumber.Text+"','Order Transfer','"+lblPreviousCustID.Text+"','"+lblSelectedCustomerid.Text+"','"+sYSUSER+"','"+lOGUSER+"','"+DateTime.Now+"')";
                    vc.Insert(str);
                    rdbtnOrderTransfer.Checked = false;
                    lblPreviousCustID.Text = "";
                    lblPreviouseCustomer.Text = "";
                    MessageBox.Show("Changed.");
                }
                else if (rdbtnInvoiceTransfer.Checked == true)
                {
                    string str = "update tblMasterInvoice set ProfileId='"+lblSelectedCustomerid.Text+"' where InvoiceID='"+txtBillNumber.Text+"'";
                    vc.Update(str);
                     str = "update tblLedger set ProfileId='" + lblSelectedCustomerid.Text + "' where EventID='" + txtBillNumber.Text + "'";
                    vc.Update(str);
                    str = "insert into tblChangeLog(LogDatetime,OrderNumber,JobID,BillNumber,ChangeWhat,ChangeFrom,ChangeTo,ChangeBy,ChangeIn,ChangeOn)values('"+DateTime.Now.ToString("yyyy-MM-dd") + "','" + txtOrderNumber.Text + "','" + txtJobID.Text + "','" + txtBillNumber.Text + "','Invoicee Transfer','" + lblPreviouseCustomer.Text + "','" + lblSelectedCustomerid.Text + "','" + sYSUSER + "','" + lOGUSER + "','" + DateTime.Now + "')";
                    vc.Insert(str);
                    rdbtnInvoiceTransfer.Checked = false;
                    MessageBox.Show("Changed.");
                }
            }
        }

        private void btnInvoiceDelete_Click(object sender, EventArgs e)
        {
            if (billstatus == 0)
            {
                int custid = f.findnumber("select ProfileId from tblMasterInvoice where InvoiceID='" + txtBillNumber.Text + "'");
                int tamount = f.findnumber("select TAmount from tblMasterInvoice where InvoiceID='" + txtBillNumber.Text + "'");
                string str = "update tblMasterInvoice set DeleteBill=1, DelDate='" + DateTime.Today + "',Delby='" + lOGUSER + "' where InvoiceID='"+txtBillNumber.Text+"'";
                vc.Update(str);
                str = "update tblOrders set jobStates=7 , Invoiceid='' where Invoiceid='" + txtBillNumber.Text + "'";
                vc.Update(str);
                str = "insert into tblChangeLog(LogDatetime,OrderNumber,JobID,BillNumber,ChangeWhat,ChangeFrom,ChangeTo,ChangeBy,ChangeIn,ChangeOn)values('" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + txtOrderNumber.Text + "','" + txtJobID.Text + "','" + txtBillNumber.Text + "','Delete Bill','No','Yes','" + sYSUSER + "','" + lOGUSER + "','" + DateTime.Now + "')";
                vc.Insert(str);
                str = "insert into tblLedger (LedgerTypeID,EventID,ProfileId,DebitAmount,CreditAmount,datetime,SpecialNOte,updateby,updatein,updateon)values('1','" + txtBillNumber.Text + "','" + custid + "','" + tamount + "','0','" + DateTime.Today + "','Invoice Delete','" + lOGUSER + "','" + sYSUSER + "','" + DateTime.Now + "')";
                vc.Insert(str);
                MessageBox.Show("Invoice Delete and ledger updated.");
                txtBillNumber.Text = "";
                txtJobID.Text = "";
                txtOrderNumber.Text = "";
                billstatus = 1;
            }
            else
            {
                MessageBox.Show("This Bill is already deleted, not retrieved.");
            }




        }

        private void btnBilllRetrive_Click(object sender, EventArgs e)
        {
            if (billstatus == 1)
            {
                int custid = f.findnumber("select ProfileId from tblMasterInvoice where InvoiceID='" + txtBillNumber.Text + "'");
                int tamount = f.findnumber("select TAmount from tblMasterInvoice where InvoiceID='" + txtBillNumber.Text + "'");
                string str = "update tblMasterInvoice set DeleteBill=0, DelDate='" + DateTime.Today + "',Delby='" + lOGUSER + "'";
                vc.Update(str);
                str = "insert into tblChangeLog(LogDatetime,OrderNumber,JobID,BillNumber,ChangeWhat,ChangeFrom,ChangeTo,ChangeBy,ChangeIn,ChangeOn)values('" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + txtOrderNumber.Text + "','" + txtJobID.Text + "','" + txtBillNumber.Text + "','Delete Bill',1,0,'" + sYSUSER + "','" + lOGUSER + "','" + DateTime.Now + "')";
                vc.Insert(str);
                str = "insert into tblLedger (LedgerTypeID,EventID,ProfileId,DebitAmount,CreditAmount,datetime,SpecialNOte,updateby,updatein,updateon)values('1','" + txtBillNumber.Text + "','" + custid + "','0','" + tamount + "','" + DateTime.Today + "','Invoice Retrive','" + lOGUSER + "','" + sYSUSER + "','" + DateTime.Now + "')";
                vc.Insert(str);
                MessageBox.Show("Invoice Retrive and ledger updated.");
                txtBillNumber.Text = "";
                txtJobID.Text = "";
                txtOrderNumber.Text = "";
                billstatus = 0;
                
            }
            else
            {
                MessageBox.Show("This Bill is already retrived, not deleted.");
            }
            
        }
    }
}
