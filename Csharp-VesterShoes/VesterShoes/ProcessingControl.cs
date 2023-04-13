using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VesterShoes.classes;
using VesterShoes.Reports;

namespace VesterShoes
{
    public partial class ProcessingControl : Form
    {
        SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["sqldbx"].ConnectionString);
        enumClass ec = new enumClass();
        public int ProcID { get; set; }
        public ProcessingControl(int id)
        {
            InitializeComponent();
            ProcID = id;

        }

        private void ProcessingControl_Load(object sender, EventArgs e)
        {
            loadItemDetail();
            
            //CombNextStemp.DataSource = Enum.GetNames(typeof(enumClass.ProcessStates));


            //try
            //{
            //    if (sqlcon.State != ConnectionState.Open)
            //    {
            //        sqlcon.Open();
            //    }

            //    SqlCommand cmd3 = sqlcon.CreateCommand();
            //    cmd3.CommandType = CommandType.Text;
            //    cmd3.CommandText = "Select top 1 vender_type_id  from tblVenderOrders where ProcessiingID='" + lblProcessingdetailID.Text + "' Order by ProcessiingID desc";
            //    cmd3.ExecuteNonQuery();
            //    SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
            //    DataSet ds = new DataSet();
            //    da3.Fill(ds);
            //    if (sqlcon.State != ConnectionState.Closed)
            //    {
            //        sqlcon.Close();
            //    }
            //    foreach (DataRow dr in ds.Tables[0].Rows)
            //    {
            //        int i = int.Parse(dr["vender_type_id"].ToString());
            //        int j = CombVender.Items.Count - 1;
            //        if (j >= i)
            //        {
            //            CombVender.SelectedIndex = i;
            //        }
            //    }
            //}
            //catch (Exception es)
            //{
            //    MessageBox.Show(es.Message);
            //}

        }
        private void loadcurrentItem(int venderorderid)
        {
            try
            {
                if (sqlcon.State != ConnectionState.Open)
                {
                    sqlcon.Open();
                }

                SqlCommand cmd3 = sqlcon.CreateCommand();
                cmd3.CommandType = CommandType.Text;
                //cmd3.CommandText = "Select * from tblVenderOrders p join tblProcessStates s on p.vender_type_id=s.vender_type_id where ProcessiingID='" + lblProcessingdetailID.Text + "' and p.vender_type_id='" + CombVender.SelectedIndex + "'  Order by ProcessiingID desc";
                cmd3.CommandText = "select * from tblVenderOrders where VenderAccountid='" + venderorderid + "'";
                cmd3.ExecuteNonQuery();
                SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
                DataSet ds = new DataSet();
                da3.Fill(ds);
                if (sqlcon.State != ConnectionState.Closed)
                {
                    sqlcon.Close();
                }
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    string rQty = (dr["ReturnQty"].ToString());
                    int step = int.Parse(dr["vender_type_id"].ToString());
                    lblProcessingdetailID.Text = (dr["ProcessiingID"].ToString());
                    //CombVender.SelectedIndex = int.Parse(dr["ProfileId"].ToString());
                    if (rQty == "")
                    {
                        CombNextStemp.SelectedIndex = int.Parse(dr["vender_type_id"].ToString());
                        venderComboLoad();

                        CombVender.SelectedValue = int.Parse(dr["ProfileId"].ToString());
                        txtNextStepQty.Text = (dr["IssueQty"].ToString());
                        txtRate.Text = (dr["IssueRate"].ToString());
                        txtBill.Text = (dr["TotalBill"].ToString());
                        dtPickerIssueDate.Value = DateTime.Parse(dr["IssueDate"].ToString());
                        txtNote.Text = (dr["Note"].ToString());
                        btnStep.Enabled = false;
                        btnStep.FlatStyle = FlatStyle.System;
                        btnReturn.Enabled = true;
                        btnReturn.FlatStyle = FlatStyle.Popup;
                        txtRate.Enabled = false;

                        txtNextStepQty.Enabled = false;
                        txtNote.Enabled = false;
                        CombNextStemp.Enabled = true;
                        CombVender.Enabled = false;
                        txtReturnQty.Text = txtNextStepQty.Text;
                        txtReturnQty.Focus();
                    }
                    //else
                    //{
                    //    CombNextStemp.SelectedIndex = step + 1;
                    //}
                }
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }
        private void loaditemHistory()
        {
            try
            {
                if (sqlcon.State != ConnectionState.Open)
                {
                    sqlcon.Open();
                }

                SqlCommand cmd3 = sqlcon.CreateCommand();
                cmd3.CommandType = CommandType.Text;
                cmd3.CommandText = "Select tb.VenderAccountid as ID, tbp.vender_type_name as Job_Level,tp.PName as Person,tb.IssueDate as 'Start Job',tb.IssueQty as Qty,tb.ReturnDate as 'Complete Job',tb.ReturnQty as 'Return Qty' from tblVenderOrders tb join tblProcessStates tbp on tb.vender_type_id=tbp.vender_type_id join tblProfile tp on tp.ProfileId=tb.ProfileId where ProcessiingID='" + lblProcessingdetailID.Text + "' order by tb.vender_type_id desc";
                cmd3.ExecuteNonQuery();
                SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
                DataSet ds = new DataSet();
                da3.Fill(ds);
                if (sqlcon.State != ConnectionState.Closed)
                {
                    sqlcon.Close();
                }
                gridHistory.DataSource = ds.Tables[0].DefaultView;

                //foreach (DataRow dr in ds.Tables[0].Rows)
                //{
                //    arrorderid = int.Parse(dr["orderID"].ToString());
                //    arrMaterOrderID = int.Parse(dr["MaterOrderID"].ToString());
                //    arrSortID = int.Parse(dr["SortID"].ToString());
                //    arrProfileId = int.Parse(dr["ProfileId"].ToString());
                //    arrCopanyname = (dr["Copanyname"].ToString());
                //    arrItemsID = int.Parse(dr["ItemsID"].ToString());
                //    arrItemsDescription = (dr["ItemsDescription"].ToString());
                //    arrIsStampAdded = int.Parse(dr["IsStampAdded"].ToString());
                //    arrisBoxAdded = int.Parse(dr["isBoxAdded"].ToString());
                //    arrItemsQty = int.Parse(dr["ItemsQty"].ToString());
                //    arrjobStates = int.Parse(dr["jobStates"].ToString());
                //    string insertQuery = "INSERT INTO tblProcessing (orderID,MaterOrderID,SortID,ProfileId,Copanyname,ItemsID,ItemsDescription,IsStampAdded,isBoxAdded,ItemsQty,Enteredon,Enteredby,jobStates) VALUES ('" + arrorderid + "','" + arrMaterOrderID + "','" + arrSortID + "','" + arrProfileId + "','" + arrCopanyname + "','" + arrItemsID + "','" + arrItemsDescription + "','" + arrIsStampAdded + "','" + arrisBoxAdded + "','" + arrItemsQty + "','" + dt + "','" + "Enteredby" + "','" + arrjobStates + "')";
                //    using (SqlCommand comm = new SqlCommand(insertQuery, sqlcon))
                //    {
                //        comm.ExecuteNonQuery();
                //    }

                //}
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }
        string abc = "";
        private void loadItemDetail()
        {
            try
            {
                SqlDataReader dr;
                if (sqlcon.State != ConnectionState.Open)
                {
                    sqlcon.Open();
                }
                string query = "Select * from tblOrders tc join tblProfile tp on tc.ProfileId=tp.ProfileId join tblItems ti on ti.ItemsID=tc.ItemsID where JobID ='" + ProcID + "'";
                SqlCommand cmd = new SqlCommand(query, sqlcon);//Advised to use parameterized query
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    lblCustomerID.Text = (dr["ProfileId"].ToString());
                    lblVesterTypeid.Text = (dr["VesterTypeID"].ToString());
                    lblTrackID.Text = (dr["orderID"].ToString());
                    lblCompanyName.Text = (dr["PCompanyName"].ToString());
                    lblOrderID.Text = (dr["orderID"] +"-"+ dr["SortID"]);
                    lblSortID.Text = (dr["SortID"].ToString());
                    lblProcessingdetailID.Text = (dr["JobID"].ToString());
                    lblItemID.Text = (dr["ItemsID"].ToString());
                    groupBox1.Text = @"Item Detail of # " + (dr["ItemsID"]);
                    lblQty.Text = (dr["ItemsQty"].ToString());
                    lblItemDescription.Text = (dr["ItemsDescription"].ToString());
                    int state = int.Parse(dr["jobStates"].ToString());
                    abc = (dr["vender_type_id"].ToString());

                    if (state != 0)
                    {
                        btnStart.Enabled = false;
                        btnStart.FlatStyle = FlatStyle.System;
                        txtNextStepQty.Text = lblQty.Text;
                        txtNextStepQty.Enabled = false;
                        btnStep.Enabled = true;
                        btnStep.FlatStyle = FlatStyle.Popup;
                    }
                }
                else
                {
                    System.Windows.MessageBox.Show("No Record Found");
                    return;
                }
                dr.Close();
                //if (abc == "")
                //{
                //    CombNextStemp.SelectedIndex = 0;
                //    venderComboLoad();
                //}
                loaditemHistory();
            }
            catch (Exception es)
            {
                System.Windows.Forms.MessageBox.Show(es.Message.ToString());
                return;
            }
            finally
            {
                if (sqlcon.State != ConnectionState.Closed)
                {
                    sqlcon.Close();
                }
            }
        }

        private void lblItemDescription_Click(object sender, EventArgs e)
        {


        }
        DateTime dt = DateTime.Now;
        VestureClass vc = new VestureClass();
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (txtNextStepQty.Text != "")
            {
                try
                {
                    if (int.Parse((txtNextStepRemainingQty.Text).ToString()) > 0)
                    {

                        vc.Update("UPDATE tblProcessingDetail SET jobStates = '" + 1 + "' , OrderQty = '" + txtNextStepQty.Text + "'  WHERE ProcessiingID = '" + lblProcessingdetailID.Text + "' ");
                        vc.Insert("INSERT INTO tblProcessingDetail (orderID,SortID,Vend_orderid,StartDate,ItemID,OrderQty,LocationId,jobStates,CustProfileID) VALUES ('" + lblTrackID.Text + "','" + lblSortID.Text + "','" + lblOrderID.Text + "','" + dt + "','" + lblItemID.Text + "','" + txtNextStepRemainingQty.Text + "','" + '0' + "','" + "0" + "','" + lblCustomerID.Text + "')");
                        lblQty.Text = txtNextStepQty.Text;
                    }
                    else
                    {
                        vc.Update("UPDATE tblProcessingDetail SET jobStates = '" + 1 + "'  WHERE ProcessiingID = '" + ProcID + "' ");
                    }
                    CombNextStemp.SelectedIndex = 0;
                    //venderComboLoad();
                    btnStart.Enabled = false;
                    txtNextStepQty.Text = lblQty.Text;
                    txtNextStepQty.Enabled = false;
                    btnStart.FlatStyle = FlatStyle.System;
                    btnStep.FlatStyle = FlatStyle.Popup;
                    btnStep.Enabled = true;
                }
                catch (Exception es)
                {
                    System.Windows.MessageBox.Show(es.ToString());

                }
                finally
                {
                    if (sqlcon.State != ConnectionState.Closed)
                    {
                        sqlcon.Close();
                    }
                }

                //jobCardForm jcd = new jobCardForm("", dt, int.Parse(lblCustomerID.Text), int.Parse(lblItemID.Text), (lblOrderID.Text), int.Parse(lblProcessingdetailID.Text), int.Parse(txtNextStepQty.Text));
                //jcd.Show();
            }
            else
            {
                MessageBox.Show("Please Fill Qty textbox to start.");
            }
        }

        private void CombNextStemp_SelectedIndexChanged(object sender, EventArgs e)
        {
            venderComboLoad();
            if (CombNextStemp.SelectedIndex >= 0)
            {
                previousRate = (f.findnumber("Select VRate from tblVesterRate where vender_type_id='" + CombNextStemp.SelectedIndex + "' and VesterTypeID='" + lblVesterTypeid.Text + "'"));
                txtRate.Text = previousRate.ToString();
            }
        }
        private void venderComboLoad()
        {
            try
            {
                //CombVender.Refresh();

                //CombVender.Items.Clear();
                if (sqlcon.State != ConnectionState.Open)
                {
                    sqlcon.Open();
                }

                SqlCommand cmd3 = sqlcon.CreateCommand();
                cmd3.CommandType = CommandType.Text;
                cmd3.CommandText = "Select ProfileId,PName from tblProfile where PType='1' and vender_type_id='" + CombNextStemp.SelectedIndex + "' order by ProfileId ";
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

                    CombVender.DisplayMember = "PName";
                    CombVender.ValueMember = "ProfileId";
                    CombVender.DataSource = ds.Tables[0].DefaultView;
                }
                else
                {
                    ds.Tables[0].Clear();
                    CombVender.DisplayMember = "PName";
                    CombVender.ValueMember = "ProfileId";
                    CombVender.DataSource = ds.Tables[0].DefaultView;
                    CombVender.Text = "";
                    lblVenderId.Text = "";
                }
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }

        int previousRate = 0;
        private void CombVender_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblVenderId.Text = "";
            if (CombVender.Items.Count > 0)
            {
                //CombVender.SelectedIndex = 0;
                lblVenderId.Text = (CombVender.SelectedValue.ToString());

            }
        }

        private void label33_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (txtNextStepQty.Text != "")
            {
                if (int.Parse(txtNextStepQty.Text.ToString()) <= int.Parse(lblQty.Text.ToString()))
                {

                    txtNextStepRemainingQty.Text = (int.Parse(lblQty.Text.ToString()) - (int.Parse(txtNextStepQty.Text.ToString()))).ToString();
                    txtReturnQty.Text = txtNextStepQty.Text;

                }
                else
                {
                    MessageBox.Show("Issue Qty Must be smaller than Order Qty");
                    txtNextStepQty.Text = lblQty.Text;
                }
            }
            else { txtNextStepRemainingQty.Text = ""; }
            txtRate_TextChanged(sender, e);

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (e.KeyChar != (char)8 && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        functions f = new functions();
        private void btnStep_Click(object sender, EventArgs e)
        {
            if (lblVenderId.Text != "" && txtNextStepQty.Text != "" && txtRate.Text != "")
            {
                try
                {
                    if (CombNextStemp.SelectedIndex == 6)
                    {
                        SqlDataReader dr;
                        if (sqlcon.State != ConnectionState.Open)
                        {
                            sqlcon.Open();
                        }
                        string query = "select * from tblVenderOrders where ReturnQty is null and ProcessiingID ='" + ProcID + "'";
                        SqlCommand cmd = new SqlCommand(query, sqlcon);//Advised to use parameterized query
                        dr = cmd.ExecuteReader();
                        //if (dr.Read())
                        if (dr.HasRows)
                        {
                            MessageBox.Show("This item is not returned from Venders. First Return it from venders then it goes to next step.");
                        }
                        else
                        {
                            dr.Close();
                            nextstepProcedure();
                        }

                    }
                    else
                    {
                        nextstepProcedure();
                    }

                }
                catch (Exception es)
                {
                    MessageBox.Show(es.Message);
                }

                finally
                {
                    if (sqlcon.State != ConnectionState.Closed)
                    {
                        sqlcon.Close();
                    }
                }

            }
            else
            {
                MessageBox.Show("Please Fill all columns.");
            }

        }

        private void nextstepProcedure()
        {
            if (int.Parse(CombVender.SelectedValue.ToString()) != 0)
            {
                if (previousRate != int.Parse(txtRate.Text))
                {
                    if (vc.Selectbool("select * from tblVesterRate where vender_type_id='" + CombNextStemp.SelectedIndex + "' and VesterTypeID='" + lblVesterTypeid.Text + "'  ") == true)
                    {
                        vc.Update("update tblVesterRate set VRate='" + txtRate.Text.Trim() + "' where vender_type_id='" + CombNextStemp.SelectedIndex + "' and VesterTypeID='" + lblVesterTypeid.Text + "' ");
                    }
                    else
                    {
                        vc.Insert("insert into  tblVesterRate ( vender_type_id,VesterTypeID,VRate) values('" + CombNextStemp.SelectedIndex + "','" + lblVesterTypeid.Text + "','" + txtRate.Text + "')");
                    }
                }
                string a = ("select vender_type_id from tblVenderOrders where ProcessiingID='" + lblProcessingdetailID.Text + "' and vender_type_id='" + CombNextStemp.SelectedIndex + "'");
                SqlDataReader dr;

                if (sqlcon.State != ConnectionState.Open)
                {
                    sqlcon.Open();
                }
                int operationsuccess = 0;
                SqlCommand cmd = new SqlCommand(a, sqlcon);//Advised to use parameterized query
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("This step is Already Performed.");
                }
                else
                {
                    operationsuccess = 1;
                }
                dr.Close();
                if (operationsuccess == 1)
                {
                    operationsuccess = 0;
                    DateTime dt = DateTime.Now;
                    string StrQuery = "INSERT INTO tblVenderOrders (ProcessiingID,ProfileId,vender_type_id,IssueQty,IssueRate,TotalBill,IssueDate,Note,entereddate) VALUES ('" + lblProcessingdetailID.Text + "','" + CombVender.SelectedValue + "','" + CombNextStemp.SelectedIndex + "','" + txtNextStepQty.Text + "','" + txtRate.Text + "','" + txtBill.Text + "','" + dtPickerIssueDate.Value + "','" + txtNote.Text + "','" + dt + "')";
                    if (sqlcon.State != ConnectionState.Open)
                    {
                        sqlcon.Open();
                    }
                    using (SqlCommand comm = new SqlCommand(StrQuery, sqlcon))
                    {
                        comm.ExecuteNonQuery();
                    }
                    loadItemDetail();
                    loaditemHistory();
                    btnStep.Enabled = false;
                    btnStep.FlatStyle = FlatStyle.System;
                    txtRate.Enabled = false;
                    txtNextStepQty.Enabled = false;
                    txtNote.Enabled = false;
                    CombNextStemp.Enabled = false;
                    CombVender.Enabled = false;
                    txtReturnQty.Text = txtNextStepQty.Text;
                    btnAddNextStep.Visible = true;
                    txtReturnQty.Focus();
                    btnReturn.Enabled = true;
                    btnReturn.FlatStyle = FlatStyle.Popup;
                }
                if (sqlcon.State != ConnectionState.Closed)
                {
                    sqlcon.Close();
                }
            }
        }

        private void clear()
        {
            txtRate.Text = "";
            txtNote.Text = "";

        }

        private void txtRate_TextChanged(object sender, EventArgs e)
        {
            if (txtRate.Text != "" && txtNextStepQty.Text != "")
            {
                txtBill.Text = (int.Parse(txtRate.Text.ToString()) * (int.Parse(txtNextStepQty.Text.ToString()))).ToString();
                txtReturnBill.Text = txtBill.Text;
            }

        }

        private void txtRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (e.KeyChar != (char)8 && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dt = DateTime.Now;
                string StrQuery = "UPDATE tblVenderOrders SET ReturnDate = '" + dtReturnDate.Value + "' , ReturnQty = '" + txtReturnQty.Text + "',BalanceQty = '" + txtBalanceQty.Text + "' WHERE ProcessiingID = '" + lblProcessingdetailID.Text + "' and vender_type_id='" + CombNextStemp.SelectedIndex + "' ";
                if (sqlcon.State != ConnectionState.Open)
                {
                    sqlcon.Open();
                }
                SqlCommand command1 = new SqlCommand(StrQuery, sqlcon);
                command1.ExecuteNonQuery();
                vc.Insert("INSERT INTO tblLedger (LedgerTypeID,EventID,ProfileId,CreditAmount,datetime,SpecialNOte) VALUES ('2','" + lblProcessingdetailID.Text + "','" + CombVender.SelectedValue + "','" + txtReturnBill.Text + "','" + dt + "','" + "" + "')");

                string Query = "INSERT INTO tblVendersAccount (ProfileId,ProcessDetailID,ReturnedQty,Rate,Total,ReturnedDate) VALUES ('" + CombVender.SelectedValue + "','" + lblProcessingdetailID.Text + "','" + txtReturnQty.Text + "','" + txtRate.Text + "','" + txtReturnBill.Text + "','" + dt + "')";

                using (SqlCommand comm = new SqlCommand(Query, sqlcon))
                {
                    comm.ExecuteNonQuery();
                }
                loadItemDetail();
                loaditemHistory();
                txtRate.Enabled = true;
                txtNextStepQty.Enabled = true;
                txtNote.Enabled = true;
                CombNextStemp.Enabled = true;
                CombVender.Enabled = true;
                txtNextStepQty.Text = lblQty.Text;
                txtRate.Focus();
                //if(lblQty.Text)
                btnReturn.FlatStyle = FlatStyle.System;
                btnReturn.Enabled = false;
                btnStep.FlatStyle = FlatStyle.Popup;
                btnStep.Enabled = true;
                if (CombNextStemp.SelectedIndex == 6)
                {
                    vc.Update("UPDATE tblProcessingDetail SET jobStates = '" + 5 + "' WHERE ProcessiingID = '" + lblProcessingdetailID.Text + "' ");
                }
            }
            catch (Exception es)
            {
                System.Windows.MessageBox.Show(es.ToString());

            }
            finally
            {
                if (sqlcon.State != ConnectionState.Closed)
                {
                    sqlcon.Close();
                }
            }
            //this.Close();
            btnStep.FlatStyle = FlatStyle.Popup;
            btnStep.Enabled = true;
        }

        private void txtReturnQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (e.KeyChar != (char)8 && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtReturnQty_TextChanged(object sender, EventArgs e)
        {
            if (txtReturnQty.Text != "" && txtRate.Text != "")
            {
                txtBalanceQty.Text = ((int.Parse(txtNextStepQty.Text) - (int.Parse(txtReturnQty.Text))).ToString());
                txtReturnBill.Text = ((int.Parse(txtReturnQty.Text) * (int.Parse(txtRate.Text))).ToString());
            }
            else
            {
                txtBalanceQty.Text = "";
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        public string gvar { get; set; }
        private void btnAddVender_Click(object sender, EventArgs e)
        {
            gvar = "AddInfo";
            FormProfileFm fcf = new FormProfileFm(gvar,LoginUser,SysteUser);
            fcf.ShowDialog();
            venderComboLoad();

        }
        public string LoginUser { get; set; }
        public string SysteUser { get; set; }
        private void btnAddNextStep_Click(object sender, EventArgs e)
        {
            txtRate.Enabled = true;
            txtNextStepQty.Enabled = false;
            txtNote.Enabled = true;
            CombNextStemp.Enabled = true;
            CombVender.Enabled = true;
            txtNextStepQty.Text = lblQty.Text;
            txtRate.Focus();
            btnReturn.FlatStyle = FlatStyle.System;
            btnReturn.Enabled = false;
            btnStep.FlatStyle = FlatStyle.Popup;
            btnStep.Enabled = true;
            btnAddNextStep.Visible = false;
        }
        //btn open order
        private void button1_Click_1(object sender, EventArgs e)
        {

            formOrderModificationfm fdf = new formOrderModificationfm(int.Parse(lblTrackID.Text),0); //replace 0 by sortid
            fdf.ShowDialog();
        }

        private void gridHistory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (gridHistory.Rows.Count > 0)
            //{
            //    int abc = int.Parse(gridHistory.Rows[e.RowIndex].Cells[0].Value.ToString());
            //    loadcurrentItem(abc);
            //}
        }

        private void btnDuplicate_Click(object sender, EventArgs e)
        {
            //jobCardForm jcd = new jobCardForm("Duplicate", dt, int.Parse(lblCustomerID.Text), int.Parse(lblItemID.Text), (lblOrderID.Text), int.Parse(lblProcessingdetailID.Text), int.Parse(txtNextStepQty.Text));
            //jcd.Show();
        }

        private void txtReturnQty_Leave(object sender, EventArgs e)
        {
            if (int.Parse(txtReturnQty.Text.ToString()) != int.Parse(txtNextStepQty.Text))
            {
                MessageBox.Show("Return Qty must be equal to Issued Qty.");
            }
        }

        private void gridHistory_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {


            //if (e.RowIndex >= 0)
            //{

            //    int abc = int.Parse(gridHistory.Rows[e.RowIndex].Cells[0].Value.ToString());
            //    lblModifyId.Text = abc.ToString();
            //    loadcurrentItem(abc);

            //    btnReturn.Enabled = false;
            //    btnAddNextStep.Enabled = false;
            //    CombVender.Enabled = true;
            //    btnModify.Visible = true;
            //    lblModifyId.Visible = true;
            //    txtRate.Enabled = true;
            //}
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            try
            {
                if (previousRate != int.Parse(txtRate.Text))
                {
                    vc.Update("update tblVesterRate set     VRate='" + txtRate.Text + "'  where vender_type_id='" + CombNextStemp.SelectedIndex + "' and VesterTypeID='" + lblVesterTypeid.Text + "'");
                }
                vc.Update("update tblVenderOrders set ProfileId='" + CombVender.SelectedValue + "' where VenderAccountid='" + lblModifyId.Text + "' ");

                vc.Update("update tblVendersAccount set ReturnedQty='" +txtReturnQty.Text + "', Rate='"+txtRate.Text+ "', Total='"+ txtReturnBill .Text+ "' where ProcessDetailID='" + lblProcessingdetailID.Text + "' and ProfileId='" + lblVenderId.Text + "' ");
                vc.Update("update tblLedger set CreditAmount='" + txtReturnBill.Text + "' where EventID='" + lblProcessingdetailID.Text + "' and ProfileId='"+ lblVenderId.Text + "' ");



                loaditemHistory();

                btnModify.Visible = false;
                lblModifyId.Visible = false;
                CombVender.Enabled = false;
                txtRate.Enabled = false;
                btnReturn.Enabled = true;
                btnAddNextStep.Enabled = true;
            }
            catch (Exception es)
            {

                MessageBox.Show(es.Message);
            }
        }
    }

}
