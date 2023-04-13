using ColonyMarket.classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ColonyMarket
{
    public partial class CloseDealfm : Form
    {
        functions f = new functions();
        int olddealnumb = 0;
        int newsellamount = 0;
        int newDealAgentComm = 0;
        public CloseDealfm(int olddeal,int sellamount,int commi)
        {
            InitializeComponent();
            olddealnumb = olddeal;
            newsellamount = sellamount;
            newDealAgentComm = commi;
        }

        private void  CloseDealfm_Load(object sender, EventArgs e)
        {
            lblprevdealid.Text = olddealnumb.ToString();
            DataSet ds = f.Select("select PlotNumber,salenumber,buyerID from Deals where DealID=" + lblprevdealid.Text + "");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                lblOldSale.Text = dr["salenumber"].ToString();
                lblOldPlotnumber.Text = dr["PlotNumber"].ToString();
                lblOldPlotOwnerid.Text = dr["buyerID"].ToString();
                //txtAgentAddress.Text = dr["PAddress"].ToString();
                //txtAgentName.Enabled = false;
                //txtAgentAddress.Enabled = false;
                //txtAgentMobile.Enabled = false;
                //btnSaveAgent.Enabled = false;

            }

            //lblownerName.Text = (f.findName("Select PName  from Deals d inner join Profile p on p.ProfileID=d.buyerID where d.DealID=" + lblprevdealid.Text + " and d.ProjectID=1 ")).ToString();
            lblownerName.Text = f.findName("Select PName  from Profile where ProfileID=" + lblOldPlotOwnerid.Text + " ");
            txtDealAmount.Text = (f.findnumber("Select top 1 Debit  from Ledger where DealID=" + lblprevdealid.Text + " and Credit=0 and isPlotsold=1 order by LedgerID ")).ToString();
            txtPaidAmount.Text = (f.findnumber("select sum(Credit)  from Ledger where DealID=" + lblprevdealid.Text + " and Debit=0 and isPlotsold=1  ")).ToString();
            txtSellAmount.Text = newsellamount.ToString();
            int rem = int.Parse(txtDealAmount.Text) - int.Parse(txtPaidAmount.Text);
            txtRemainigamount.Text = rem.ToString();
            txtAdjustedamount.Text=(int.Parse(txtSellAmount.Text)-int.Parse(txtRemainigamount.Text)).ToString();
            txtAgentCommision.Text = newDealAgentComm.ToString();
            calculateFinalAmount();

        }

        private void calculateFinalAmount()
        {
            //txtfinalamount.Text = (newsellamount - (int.Parse(txtRemainigamount.Text)+int.Parse(txtAgentCommision.Text))).ToString();
            txtfinalamount.Text = (newsellamount - (int.Parse(txtDealAmount.Text)+int.Parse(txtAgentCommision.Text))).ToString();
        }
        private void txtfinalamount_TextChanged(object sender, EventArgs e)
        {
            txtfinal2.Text = txtfinalamount.Text;
        }
        //VestureClass vc= new VestureClass();
        private void btnCloseDeal_Click(object sender, EventArgs e)
        {
            DateTime d=DateTime.Now.AddMinutes(1);
            string dt = d.ToString("dd-MM-yyyy");
            //inser into ledger Balance
            int countinstall = f.createNumber("select top 1 InstallmentNumber from Ledger where DealID=" + lblprevdealid.Text +" order by InstallmentNumber desc ");

            f.Insert("insert into Ledger(DealID,ProjectID,PlotNumber,SaleNumber,ProfileID,Debit,Credit,InstallmentNumber,RecordDate,isinstallment,Remarks,isPlotsold) " +
              "values(" + olddealnumb + ",1," + lblOldPlotnumber.Text + ",'" + lblOldSale.Text + "','" + lblOldPlotOwnerid.Text + "',0,'" + txtSellAmount.Text + "',"+countinstall+",'" + dt + "',1,'Plot Sold Amount',0)");
            //insert commission debit
            f.Insert("insert into Ledger(DealID,ProjectID,PlotNumber,SaleNumber,ProfileID,Debit,Credit,InstallmentNumber,RecordDate,isinstallment,Remarks,isPlotsold,isSellerComm) " +
               "values('" + olddealnumb + "',1," + lblOldPlotnumber.Text + ",'" + lblOldSale.Text + "','" + lblOldPlotOwnerid.Text + "','" + txtAgentCommision.Text + "',0,0,'" + dt + "',0,'Sale Plot Commission',0,1)");
            //is paid to seller is checked
            if (checkBox1.Checked)
            {
                //int countinstall = f.createNumber("select top 1 InstallmentNumber from Ledger where DealID=" + lblprevdealid.Text +" order by InstallmentNumber desc ");
                //countinstall++;
                f.Insert("insert into Ledger(DealID,ProjectID,PlotNumber,SaleNumber,InstallmentNumber,ProfileID,Debit,Credit,RecordDate,isinstallment,Remarks,isPlotsold) " +
                      "values('" + olddealnumb + "',1," + lblOldPlotnumber.Text + ",'" + lblOldSale.Text + "',0,'" + lblOldPlotOwnerid.Text + "'," + txtfinal2.Text + ",0,'" + dt + "',0,'Profit Paid',1)");
            }
            //var frm = (Soldfm)sender;
            Soldfm frm = new Soldfm();
            frm.NewAgentCommission= txtAgentCommision.Text;
            //System.Threading.Thread.Sleep(3000);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void txtAgentCommision_TextChanged(object sender, EventArgs e)
       {
            if (txtAgentCommision.Text!="")
            {
                calculateFinalAmount();
            }
            else
            {
                txtfinalamount.Text = "";
            }
        }
    }
}
