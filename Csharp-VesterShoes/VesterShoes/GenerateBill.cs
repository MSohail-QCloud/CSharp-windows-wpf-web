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
using System.Windows;
using System.Windows.Forms;
using VesterShoes.classes;
using VesterShoes.Reports;

namespace VesterShoes
{
    public partial class GenerateBill : Form
    {
        SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["sqldbx"].ConnectionString);
        VestureClass vc = new VestureClass();
        public int PID { get; set; }
        public GenerateBill()
        {
            InitializeComponent();
        }

        public int CustomerID { get; set; }
        public string CompaanyName { get; set; }
        public int Balanceamount { get; set; }
        public string Systemuser { get; set; }
        public string Loginuser { get; set; }
        DataTable tbl_bill = new DataTable("tbl_main");

        public GenerateBill(string Custid, string companyname, string blnceamount, string LoginUser,String SystemUser)
        {
            InitializeComponent();
            CustomerID = int.Parse(Custid);
            CompaanyName = companyname;
            Systemuser = SystemUser;
            Loginuser = LoginUser;
            //Balanceamount = int.Parse(blnceamount);
        }

        readonly functions f = new functions();
        int gaurdian = 0;
        private void SelectCompleteItem_Load(object sender, EventArgs e)
        {
            textBox1.Text = CompaanyName;
            dtPickerGenerateBillDate.Value = DateTime.Today;
            //GridCompleteItems.DataSource = tbl_bill.DefaultView;
            //GridCompleteItems.ReadOnly=true;
            //txtPreviouseBalance.Text = Balanceamount.ToString();
            generateInvoice();
            int bal = 0;
             gaurdian = f.findnumber("select PGaurdianNameID from tblProfile where ProfileId='" + CustomerID+"' ");
            if (gaurdian > 0)
            {
                string str = "select (sum(CreditAmount)-sum(DebitAmount))as Balance from ((select  ledgerID, LedgerTypeID, EventID, l.ProfileId, DebitAmount, CreditAmount, datetime as ldatetime, SpecialNOte, l.updateby,Remarks, p.ProfileId as PGaurdianNameID , p.PCompanyName from tblLedger l , tblProfile p  where l.ProfileId=p.ProfileId and l.ProfileId = '" + gaurdian + "') union (select l.ledgerID, l.LedgerTypeID, l.EventID, l.ProfileId, l.DebitAmount, l.CreditAmount, l.datetime as ldatetime, l.SpecialNOte, l.updateby,l.Remarks, p.PGaurdianNameID,p.PCompanyName from tblLedger l , tblProfile p where l.ProfileId = p.ProfileId and p.PGaurdianNameID = '" + gaurdian + "')) a";
                bal = f.findnumber(str);
            }
            else
            {
                bal = f.findnumber("select SUM(CreditAmount)-SUM(DebitAmount) as BalanceAmount from tblLedger where ProfileId='" + CustomerID + "' ");

            }
            txtPreviouseBalance.Text = bal.ToString();
            txtJobid.Focus();
        }

        private void generateInvoice()
        {
            int numb = f.createNumber("Select top 1 InvoiceID  from tblMasterInvoice  order by InvoiceID desc");
            txtInvoiceId.Text = numb.ToString();
        }
        int loopclose = 0;int a = 0;
        private void GridCompleteItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (a == -1)
            {
                a = 0;
                return;
            }
            a = e.RowIndex;
            if (a == -1) return; //check if row index is not selected
            if (e.ColumnIndex==10)
            {                
                GridCompleteItems.Rows.RemoveAt(a);
                a = -1;
                int sumofTotal = 0;
                foreach (DataGridViewRow drv in GridCompleteItems.Rows)
                {
                    sumofTotal = sumofTotal + int.Parse(drv.Cells[7].Value.ToString());
                }
                txtSumAmount.Text = sumofTotal.ToString();
            }
        }

       

        private void txtSumAmount_TextChanged(object sender, EventArgs e)
        {
            if (txtSumAmount.Text != "")
            {
                txtBalaTotal.Text = (int.Parse(txtSumAmount.Text) + int.Parse(txtPreviouseBalance.Text)).ToString();
            }
        }
        //save button click
        int sumofTotal = 0;
        int orderid = 0;
        int Sortid = 0;
        int Jobid = 0;
        int Orderdetid = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtbiltyvia.Text == "")
            {
                System.Windows.MessageBox.Show("Enter Bilty Detail");
                return;
            }
            string itemsVerify = "OK";
            foreach (DataGridViewRow drv in GridCompleteItems.Rows)
            {
                orderid = 0;
                Sortid = 0;
                Jobid = 0;
                if (drv.Cells[1].Value.ToString() != "")
                {
                    orderid = int.Parse(drv.Cells[1].Value.ToString());
                    Sortid = int.Parse(drv.Cells[2].Value.ToString());
                }
                
                string itdescription = drv.Cells[4].Value.ToString();
                int rt = int.Parse(drv.Cells[6].Value.ToString());
                int qty = int.Parse(drv.Cells[5].Value.ToString());
                int tot = int.Parse(drv.Cells[7].Value.ToString());
                if (tot == 0)
                {
                    MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Order#" + orderid + "-" + Sortid + " having total amount is equal to Zero. Would you like to continue.", "Verification", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (messageBoxResult == MessageBoxResult.No)
                    {
                        itemsVerify = "NotOK";
                        break;
                    }
                }
            }
            if (itemsVerify == "NotOK")
            {
                return;
            }

            try
            {
                 sumofTotal = 0;
                orderid = 0;
                Sortid = 0;
                Jobid = 0;
                 Orderdetid = 0;
                if (GridCompleteItems.SelectedRows.Count > 0)
                {sumofTotal = 0;
                    //if (GridCompleteItems.SelectedRows != null)
                    //{
                    foreach (DataGridViewRow drv in GridCompleteItems.Rows)
                    {
                        
                        orderid = 0;
                        Sortid = 0;
                        Jobid = 0;
                        Orderdetid = 0;
                        string art = "";
                        string sol = "";
                        string siz = "";
                        if (drv.Cells[1].Value.ToString() != "")
                        {
                            orderid = int.Parse(drv.Cells[1].Value.ToString());
                            Sortid = int.Parse(drv.Cells[2].Value.ToString());
                        }
                        if (drv.Cells[3].Value.ToString() != "")
                        {
                            Jobid = int.Parse(drv.Cells[3].Value.ToString());
                        }
                        string itdescription = drv.Cells[4].Value.ToString();
                        int rt = int.Parse(drv.Cells[6].Value.ToString());
                        int qty = int.Parse(drv.Cells[5].Value.ToString());
                        int tot = int.Parse(drv.Cells[7].Value.ToString());
                        
                        if(drv.Cells[11].Value!=null && drv.Cells[11].Value.ToString()!="")
                        {
                            Orderdetid = int.Parse(drv.Cells[11].Value.ToString());
                        }
                        sumofTotal = sumofTotal + tot;
                        if (itdescription.Contains('_'))
                        {
                            string[] itdescriptions = itdescription.Split('_');
                            art= itdescriptions[0];
                            itdescription= itdescriptions[1];
                            sol = itdescriptions[2];
                            siz= itdescriptions[3];
                        }
                        if (orderid != 0)
                        {
                            vc.Insert("update tblOrders set invoiceid='" + txtInvoiceId.Text + "', Complete='1' , DeliverToCustomer='" + CustomerID + "',updateby='"+Loginuser+"',updatein='"+Systemuser+"',updateon='"+DateTime.Now+"', DeliveryDate='" + DateTime.Today + "' , jobStates='8' where OrderID='" + orderid + "'and SortID='" + Sortid + "' ");
                        }
                        string astr = "insert into tblDetailInvoice (InvoiceID,orderdetailID,iarticle,itemDescription,sol,size,itemQty,Rate,itemTotal,Enteredon,Enteredby,Enteredat)values('" + txtInvoiceId.Text + "','" + Orderdetid + "','" + art + "','" + itdescription + "','" + sol + "','" + siz + "','" + qty + "','" + rt + "','" + tot + "','" + DateTime.Now + "','" + Loginuser + "','" + Systemuser + "')";
                        vc.Insert(astr);

                    }
                    txtSumAmount.Text = sumofTotal.ToString();
                    string dt = dtPickerGenerateBillDate.Value.ToString("yyyy-MM-dd");
                    string dtime = (DateTime.Now).ToString("HH:mm:ss tt");
                    string dtime2 = (DateTime.Now).ToString("yyyy-MM-dd HH:mm:ss tt");
                    vc.Insert("insert into tblMasterInvoice (InvoiceID,ProfileId,TAmount,invoicedate,invoicetime,Enteredon,Enteredby,Enteredin,BiltyVia,BiltyNumber)values('" + txtInvoiceId.Text + "','" + CustomerID + "','" + txtSumAmount.Text + "','" + dt + "','" + dtime + "','" + dtime2 + "','" + Loginuser + "','" + Systemuser + "','" + txtbiltyvia.Text + "','" + txtbilitynumb.Text + "')");
                    vc.Insert("insert into tblLedger (LedgerTypeID,EventID,ProfileId,DebitAmount,CreditAmount,datetime,SpecialNOte,updateby,updatein,updateon)values('1','" + txtInvoiceId.Text + "','" + CustomerID + "',0,'" + txtSumAmount.Text + "','" + dtime2 + "','Customer Invoice','" + Loginuser + "','" + Systemuser+ "','" + DateTime.Now + "')");
                    GridCompleteItems.Rows.Clear();
                    InvoiceSlipForm vsl = new InvoiceSlipForm(int.Parse(txtInvoiceId.Text),  "");
                    vsl.Show();
                    
                }
                this.DialogResult = DialogResult.OK;
                this.Hide();
            }
            catch (Exception es)
            {
                System.Windows.MessageBox.Show("Error on Generating Invoice: " + es.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtJobid_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtJobid.Text=="")
            {
                return;
            }
            if (e.KeyCode == Keys.Enter)
            {
                //var result = tbl_bill.Select("JobID = '" + txtJobid.Text + "'");
                //    if (result.Any())
                //    {
                //        txtJobid.Text = "";
                //        //return;
                //    }
                //    //change querry
                DataSet ds = new DataSet();
                if (txtJobid.Text.Contains('-'))
                {
                    string[] ord = txtJobid.Text.Split('-');
                    int order = int.Parse(ord[0]);
                    int sort = int.Parse(ord[1]);
                    ds = vc.Select("select s.JobID,s.OrderID,s.SortID,s.ItemsID,p.PCompanyName, Concat(a.Article,'_',t.VesterType,SPACE(1),c.ColorName,SPACE(1),m.MaterialName,'_',sol.SolName,'_',siz.SizeName)as ItemsDescription,s.ItemsQty,s.ItemsRate,s.ItemsTotal, s.orderdetailID from tblorders s, tblItems i,tblMaterial m, tblArticle a,tblVesterType t,tblColor c,tblSol sol, tblSize siz,tblProfile p where s.ProfileId=p.ProfileId and s.ItemsID=i.ItemsID and i.ArticleID=a.ArticleID and i.VesterTypeID=t.VesterTypeID and i.ColorID=c.ColorID and i.SolID=sol.SolID and i.MaterialID=m.MaterialID and i.SizeID=siz.SizeID and s.OrderID='" + order + "' and s.SortID='" + sort + "' and jobStates<'8'");
                }
                else
                {
                    string str = "select s.JobID,s.OrderID,s.SortID,s.ItemsID,p.PCompanyName, Concat(a.Article,'_',t.VesterType,SPACE(1),c.ColorName,SPACE(1),m.MaterialName,'_',sol.SolName,'_',siz.SizeName)as ItemsDescription,s.ItemsQty,s.ItemsRate,s.ItemsTotal,s.orderdetailID from tblorders s, tblItems i,tblMaterial m, tblArticle a,tblVesterType t,tblColor c,tblSol sol, tblSize siz,tblProfile p where s.ProfileId=p.ProfileId and s.ItemsID=i.ItemsID and i.ArticleID=a.ArticleID and i.VesterTypeID=t.VesterTypeID and i.ColorID=c.ColorID and i.SolID=sol.SolID and i.MaterialID=m.MaterialID and i.SizeID=siz.SizeID and jobStates>'0' and jobStates<'8'  and JobID='" + txtJobid.Text + "'";
                     ds = vc.Select(str);
                    //ds = vc.Select("select JobID,orderID,SortID,tp.ItemsID,ItemsQty,ItemsRate,tf.PCompanyName,ti.ItemsDescription from tblOrders tp join tblProfile tf on tp.ProfileId=tf.ProfileId join tblItems ti on tp.ItemsID=ti.ItemsID where jobStates>'0' and jobStates<'8'  and JobID='" + txtJobid.Text + "'");
                }
                string itemfoundbefor="No";
                if (ds.Tables[0].Rows.Count==0)
                {
                    System.Windows.MessageBox.Show("Wrong Item detail or this item is delivered.");
                }
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    //DataRow drow1 = tbl_bill.NewRow();
                    string ord = dr["orderID"].ToString();
                    string sort = dr["SortID"].ToString();
                    string job = dr["JobID"].ToString();
                    string desc = dr["ItemsDescription"].ToString();
                    string qtyi = dr["ItemsQty"].ToString();
                    string ratei = dr["ItemsRate"].ToString();
                    int totali = (int.Parse(dr["ItemsRate"].ToString())*int.Parse(dr["ItemsQty"].ToString()));
                    string pccompany = dr["PCompanyName"].ToString();
                    string Orderdetailid = dr["orderdetailID"].ToString();

                    foreach (DataGridViewRow drv in GridCompleteItems.Rows)
                    {
                        if (drv.Cells[1].ToString() != "")
                        {
                            int ordd = int.Parse(drv.Cells[1].Value.ToString());
                            int sortt = int.Parse(drv.Cells[2].Value.ToString());
                            if (ordd == int.Parse(ord) && sortt == int.Parse(sort))
                            {
                                itemfoundbefor = "Yes";
                                break;
                            }
                        }
                        
                    }
                    if (itemfoundbefor == "No")
                    {
                        this.GridCompleteItems.Rows.Add("",ord, sort, job, desc, qtyi, ratei, totali, pccompany,"","X",Orderdetailid);
                        int sumofTotal = 0;
                        foreach (DataGridViewRow drv in GridCompleteItems.Rows)
                        {
                            sumofTotal=sumofTotal+ int.Parse(drv.Cells[7].Value.ToString()); ;
                        }
                        txtSumAmount.Text = sumofTotal.ToString();

                        txtJobid.Text = "";

                    }
                    else
                    {
                        System.Windows.MessageBox.Show("This item is already added.");
                        txtJobid.Text = "";
                    }
                }
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txtJobid_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtOldbill_KeyDown(object sender, KeyEventArgs e)
        {
            if (TxtOldbill.Text=="")
            {
                return;
            }
            if (e.KeyCode==Keys.Enter)
            {

                InvoiceSlipForm isp= new InvoiceSlipForm(int.Parse(TxtOldbill.Text),"Duplicate");
                isp.Show();
            }
        }
       
        private void TxtOldbill_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (e.KeyChar != (char)8 && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtJobid_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (e.KeyChar != (char)8 && !char.IsNumber(e.KeyChar) && e.KeyChar!='-' )
            {
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           CompleteItmes ci= new CompleteItmes();
            if (ci.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtJobid.Text = ci.GlobalVar.ToString();
            };
        }


        private void GridCompleteItems_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int i=0;
            try
            {
                for ( i = 0; i < GridCompleteItems.Rows.Count; ++i)
                {
                    int price = Convert.ToInt32(GridCompleteItems.Rows[i].Cells[6].Value);
                    int quantity = Convert.ToInt32(GridCompleteItems.Rows[i].Cells[5].Value);

                    GridCompleteItems.Rows[i].Cells[7].Value = price * quantity;
                }
                int sumofTotal = 0;
                foreach (DataGridViewRow drv in GridCompleteItems.Rows)
                {
                    sumofTotal = sumofTotal + int.Parse(drv.Cells[7].Value.ToString()); ;
                }
                txtSumAmount.Text = sumofTotal.ToString();
            }
            catch
            {
                GridCompleteItems.Rows[i].Cells[5].Value = 0;
                GridCompleteItems.Rows[i].Cells[6].Value = 0;
            }
            
        }

        private void btnAddOnAdding_Click(object sender, EventArgs e)
        {
            this.GridCompleteItems.Rows.Add("","", "", "", txtAdOnDescription.Text,txtAdOnQty.Text,txtAdonRate.Text,txtAdOnTotal.Text,"");
            int sumofTotal = 0;
            foreach (DataGridViewRow drv in GridCompleteItems.Rows)
            {
                sumofTotal = sumofTotal + int.Parse(drv.Cells[7].Value.ToString()); ;
            }
            txtSumAmount.Text = sumofTotal.ToString();
            txtAdOnDescription.Text = "";
            txtAdOnQty.Text = "";
            txtAdonRate.Text = "";
            txtAdOnTotal.Text = "";
        }

        private void txtAdOnQty_TextChanged(object sender, EventArgs e)
        {
            AddOnCalculate();
        }
        private void AddOnCalculate()
        {
            if (txtAdonRate.Text != "" && txtAdOnQty.Text != "")
            {
                txtAdOnTotal.Text = (int.Parse(txtAdonRate.Text) * int.Parse(txtAdOnQty.Text)).ToString();
            }
        }

        private void txtAdonRate_TextChanged(object sender, EventArgs e)
        {
            AddOnCalculate();

        }

        private void TxtOldbill_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
