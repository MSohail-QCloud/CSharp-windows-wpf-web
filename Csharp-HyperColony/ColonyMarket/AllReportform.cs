using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ColonyMarket.classes;
using ColonyMarket.Reports;
using CrystalDecisions.CrystalReports.Engine;

namespace ColonyMarket
{
    public partial class AllReportform : Form
    {
        OleDbConnection olecon = new OleDbConnection(ConfigurationManager.ConnectionStrings["Accdbx"].ConnectionString);
        functions f = new functions();
        public int projectID { get; set; }
        public int PlotID { get; set; }
        public int SaleID { get; set; }
        public string ProjectName { get; set; }
        public int NumbOfSale { get; set; }
        public int isSpeciall { get; set; }

        public int ispecial { get; set; }
        public int iscorner { get; set; }
        public int isParkface { get; set; }
        public int isMainBulevard { get; set; }
        DataTable tbl_Installment = new DataTable("tbl_main");
        // functions f =new functions();
        public AllReportform(int projeid)
        {
           
            InitializeComponent();
            lblprojID.Text = projeid.ToString();
        }

        public int ProjectID { get; set; }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            var g = e.Graphics;
            var text = this.tabCompnyDetail.TabPages[e.Index].Text;
            var sizeText = g.MeasureString(text, this.tabCompnyDetail.Font);

            var x = e.Bounds.Left + 3;
            var y = e.Bounds.Top + (e.Bounds.Height - sizeText.Height)/2;

            g.DrawString(text, this.tabCompnyDetail.Font, Brushes.Black, x, y);
        }

        //functions f=new functions();
        private void AllReportform_Load(object sender, EventArgs e)
        {
           // lblprojID.Text = ProjectID.ToString();
            lblProjectName.Text = f.findName("select ProjectName from Projects where ProjectID="+lblprojID.Text+"");
            LoadComboPlots();
            //search by sale and deal
            //txtProjName.Text = ProjectName;

           // txtPlotnumber.Text = PlotID.ToString();
            
            tbl_main.Columns.Add("Name");
            tbl_main.Columns.Add("CNIC");
            tbl_main.Columns.Add("Mobile");
            tbl_main.Columns.Add("Commision");
            //tbl_main.Columns.Add("Paid");
            //tbl_main.Columns.Add("Paid Date");
            gridProfile.DataSource = tbl_main.DefaultView;
            gridProfile.ClearSelection();

            tbl_Installment.Columns.Add("NO#");
            tbl_Installment.Columns.Add("RecordDate");
            tbl_Installment.Columns.Add("Paid");
            tbl_Installment.Columns.Add("Balance");

            gridCustPaidInstallments.DataSource = tbl_Installment.DefaultView;
            gridCustPaidInstallments.Columns[0].Width = 30;
            gridProfile.ClearSelection();

            //txtSaleNumber.Text = SaleID.ToString();

            //dscomb = f.Select("select ExpID,HeadName from expenseHead ");
            //if (dscomb.Tables[0].Rows.Count > 0)
            //{
            //    comboLedgerRptExpenseHeader.DisplayMember = "HeadName";
            //    comboLedgerRptExpenseHeader.ValueMember = "ExpID";
            //    comboLedgerRptExpenseHeader.DataSource = dscomb.Tables[0].DefaultView;
            //    comboLedgerRptExpenseHeader.SelectedIndex = 0;

            //}
            //else
            //{
            //    dscomb.Tables[0].Clear();
            //    comboLedgerRptExpenseHeader.DisplayMember = "HeadName";
            //    comboLedgerRptExpenseHeader.ValueMember = "ExpID";
            //    comboLedgerRptExpenseHeader.DataSource = dscomb.Tables[0].DefaultView;
            //}
            //*****
        }
        DataSet dscomb= new DataSet();

        private void txtSaleNumber_TextChanged(object sender, EventArgs e)
        {
            loadDealDetail();
        }

        private void loadDealDetail()
        {
            lblErrorMsg.Text = "";
            if (txtSaleNumber.Text == "")
            {
                return;
            }
            if (comboPlotname.SelectedIndex <= 0)
            {
                return;
            }
            //if (lblDealID.Text == "")
            //{
            //    return;
            //}
            int dealid =
                f.findnumber("Select top 1 DealID  from Deals where PlotNumber=" + comboPlotname.SelectedValue +
                             " and salenumber=" + txtSaleNumber.Text +
                             " order by DealID desc");

            if (dealid == 0) //if no previouse deal found
            {
                lblErrorMsg.Text = "No Record found.";
            }
            else //if deal found
            {
                //lblDealID.Text = dealid.ToString();
                //loadgridprofile();
                //txtSaleNumber.Text = (f.findnumber("Select salenumber  from Deals where  DealID=" + lblDealID.Text + " ")).ToString();
                //string cnic =(f.findLongnumber("Select Pcnic  from Deals d inner join Profile p on p.ProfileID=d.SalerID where d.PlotNumber=" + comboPlotname.SelectedValue + " and d.DealID=" +lblDealID.Text + "")).ToString();
                txtSellerCnic.Text = (f.findLongnumber("Select Pcnic  from Deals d inner join Profile p on p.ProfileID=d.SalerID where d.PlotNumber=" + comboPlotname.SelectedValue + " and d.DealID=" + lblDealID.Text + "")).ToString();
                txtAgentCnic.Text = (f.findLongnumber("Select Pcnic  from Deals d inner join Profile p on p.ProfileID=d.AgentID where d.PlotNumber=" + comboPlotname.SelectedValue + " and d.DealID=" + lblDealID.Text + "")).ToString();
                //if (cnic == "0")
                //{
                //    txtNameSeller.Text = "Project Sale";
                //}
                //else
                //{
                //txtSellerCnic.Text = cnic;
                //}
                int isComplete = 0;
                DataSet ds = f.Select("Select Pcnic,isComplete,NumbofInstallments,Rate,TotalAmount  from Deals d inner join Profile p on p.ProfileID=d.buyerID where d.PlotNumber=" + comboPlotname.SelectedValue + "  and d.DealID=" + lblDealID.Text + "");
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    txtBuyerCnic.Text = dr["Pcnic"].ToString();
                    isComplete = int.Parse(dr["isComplete"].ToString());
                    txtRateMrla.Text = (dr["Rate"].ToString());
                    txtTotalAmount.Text = (dr["TotalAmount"].ToString());
                    lbltotalinstallments.Text = (dr["NumbofInstallments"].ToString());
                    //txtBalance.Text = (dr["Balance"].ToString());
                    //.Text = (dr["NumbofInstallments"].ToString());
                }
                txtTotalPaid.Text =
                    f.findnumber("select sum(Credit) from ledger where isinstallment=1 and DealID=" + lblDealID.Text +
                                 "").ToString();
                txtBalance.Text = (int.Parse(txtTotalAmount.Text) - int.Parse(txtTotalPaid.Text)).ToString();
                //txtTotalPaid.Text = (int.Parse(txtTotalAmount.Text) - int.Parse(txtBalance.Text)).ToString();
                //txtBuyerCnic.Text = (f.findLongnumber("Select Pcnic  from Deals d inner join Profile p on p.ProfileID=d.buyerID where d.PlotNumber=" + txtPlotnumber.Text + " and d.ProjectID=" + lblprojID.Text + " and d.DealID=" + lblDealID.Text + "")).ToString();
                //if deal is final
                //int isComplete = f.findnumber("Select isComplete from Deals where PlotNumber=" + txtPlotnumber.Text + " and ProjectID=" + lblprojID.Text + " and  DealID=" + lblDealID.Text + " and isfinal=1 ");
                //txtNumberofInstallments.Text = (f.findnumber("select NumbofInstallments from Deals where DealID=" + lblDealID.Text + "")).ToString();
                if (isComplete == 1)
                {
                    grpBoxMain.Enabled = false;
                    //btnNewDeal.Enabled = true;
                    lblErrorMsg.Text = "This Deal is Completed.";
                    loadPaidIntallments();
                    findPendingInstall();
                    return;
                }
                bool isfinal =
                    f.Selectbool("Select * from Deals where PlotNumber=" + comboPlotname.SelectedValue + " and ProjectID=" +
                                 lblprojID.Text + " and  DealID=" + lblDealID.Text + " and isfinal=1 ");
                if (isfinal)
                {
                    txtBuyerCnic.Enabled = false;
                    txtAgentCnic.Enabled = false;
                    txtRateMrla.Enabled = false;
                    txtTotalAmount.Enabled = false;
                    txtBalance.Enabled = false;
                    //txtAdvance.Enabled = false;
                    grpboxInstallment.Enabled = true;
                    lblErrorMsg.Text = lblErrorMsg.Text + " " + "This Deal is Finalized.";
                    loadPaidIntallments();
                    findPendingInstall();
                }
                //bool iscancel =
                //    f.Selectbool("Select * from Deals where PlotNumber=" + comboPlotname.SelectedValue + " and ProjectID=" +
                //                 lblprojID.Text + " and  DealID=" + lblDealID.Text + " and isCancel=1 ");
                //if (iscancel)
                //{
                //    lblErrorMsg.Text = "This Deal is Cancelled.";
                //}
                //bool issave =
                //    f.Selectbool("Select * from Deals where PlotNumber=" + comboPlotname.SelectedValue + " and ProjectID=" +
                //                 lblprojID.Text + " and  DealID=" + lblDealID.Text + " and issave=1 ");
                //if (issave)
                //{
                //    lblErrorMsg.Text = "This Deal is Saved.";
                //}
            }
        }
        private void findDimentionArea()
        {
            try
            {
                string s =
                    "select Dimensions,Area,IsSpecial,IsCorner,IsParkFace,IsMainBulevard,SaleNumber,p_s_name from PlotsList pl inner join PlotsDimensionsList pd on pl.DimensionListID=pd.DimensionListID where pl.PlotNumber=" +
                    comboPlotname.SelectedValue + " and pl.ProjectID=" + lblprojID.Text + "";
                OleDbDataReader dr;
                if (olecon.State == ConnectionState.Closed)
                {
                    olecon.Open();
                }
                OleDbCommand cmd = new OleDbCommand(s, olecon); //Advised to use parameterized query
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                   
                    txtDimension.Text = (dr.GetValue(0).ToString());
                    txtArea.Text = (dr.GetValue(1).ToString());
                    //comboPlotname.Text = (dr.GetValue(7).ToString());
                    ispecial = int.Parse(dr.GetValue(2).ToString());
                    iscorner = int.Parse(dr.GetValue(3).ToString());
                    if (iscorner == 1)
                    {
                        txtspecialCharacter.Text = "C ";
                    }
                    isParkface = int.Parse(dr.GetValue(4).ToString());
                    if (isParkface == 1)
                    {
                        txtspecialCharacter.Text = txtspecialCharacter.Text + " P ";
                    }
                    isMainBulevard = int.Parse(dr.GetValue(5).ToString());
                    if (isMainBulevard == 1)
                    {
                        txtspecialCharacter.Text = txtspecialCharacter.Text + " M";
                    }
                    //txtSaleNumber.Text = dr.GetValue(6).ToString();
                }
                if (olecon.State != ConnectionState.Closed)
                {
                    olecon.Close();

                }
                dr.Close();
            }
            catch (Exception es)
            {
                lblErrorMsg.Text = es.Message;
            }
        }

        //txtRate Marla
        int keydownflag = 0;

        private void txtRateMrla_TextChanged(object sender, EventArgs e)
        {
            //if (txtRateMrla.Text != "")
            //{
            //    if (keydownflag == 0)
            //    {
            //        return;
            //    }
            //    keydownflag = 0;
            //    if (txtArea.Text != "")
            //    {
            //        lblMultiplierArea.Text = txtArea.Text;
            //    }
            //    if (txtRateMrla.Text != "" && lblMultiplierArea.Text != "")
            //    {
            //        int rate = int.Parse(txtRateMrla.Text);
            //        float area = float.Parse(lblMultiplierArea.Text);
            //        txtTotalAmount.Text = (rate*area).ToString();
            //    }
            //    else
            //    {

            //        txtTotalAmount.Text = "";
            //    }
            //}
            //else
            //{
            //    txtTotalAmount.Text = "";
            //}
        }

        private void comboCommProfit_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (comboCommProfit.Text != "")
            //{
            //    string commission = comboCommProfit.Text;
            //    commission = commission.Replace(@"%", "");
            //    int perc = int.Parse(commission);
            //    int totalamount = int.Parse(txtTotalAmount.Text);
            //    float commamount = (totalamount/100)*perc;
            //    txtPaidAgentAmount.Text = (Math.Round(commamount)).ToString();
            //}
        }

        private void txtSellerCnic_TextChanged(object sender, EventArgs e)
        {
            if (txtSellerCnic.Text.Length == 13)
            {
                DataSet ds =
                    f.Select("select ProfileID,PName,PMobile,PAddress from Profile where Pcnic='" + txtSellerCnic.Text +
                             "'");
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lblSellerprofileID.Text = dr["ProfileID"].ToString();
                    txtNameSeller.Text = dr["PName"].ToString();
                    mobile.Text = dr["PMobile"].ToString();
                    address.Text = dr["PAddress"].ToString();
                    txtNameSeller.Enabled = false;
                    address.Enabled = false;
                    mobile.Enabled = false;
                    //btnSaveSeller.Enabled = false;
                }
            }
            else
            {
                lblSellerprofileID.Text = "";
                txtNameSeller.Enabled = true;
                address.Enabled = true;
                mobile.Enabled = true;
                //btnSaveSeller.Enabled = true;
            }
        }

        private void btnNewEntry_Click(object sender, EventArgs e)
        {
            lblErrorMsg.Text = "";
            txtSellerCnic.Text = "";
            address.Text = "";
            mobile.Text = "";
            txtNameSeller.Text = "";
            lblSellerprofileID.Text = "";
            //btnSaveAgent.Enabled = true;
            //btnModify.Enabled = false;
            //btnDelete.Enabled = false;
        }

        DataTable tbl_main = new DataTable("tbl_main");

        private void loadgridprofile()
        {
            tbl_main.Clear();
            try
            {

                string s1 =
                    "select PName,Pcnic,PMobile,ProfitShare,paidAmount,paidDate from Agents b inner join Profile p on b.ProfileID=p.ProfileID where b.PlotNumber=" +
                    comboPlotname.SelectedValue + " and b.ProjectID=" + lblprojID.Text + " and  b.DealID=" +
                    lblDealID.Text + " ";
                OleDbDataReader dr1;
                if (olecon.State == ConnectionState.Closed)
                {
                    olecon.Open();
                }
                OleDbCommand cmd1 = new OleDbCommand(s1, olecon); //Advised to use parameterized query
                dr1 = cmd1.ExecuteReader();

                if (dr1.Read())
                {
                    DataRow drow = tbl_main.NewRow();
                    drow[0] = (dr1.GetValue(0).ToString());
                    drow[1] = (dr1.GetValue(1).ToString());
                    drow[2] = (dr1.GetValue(2).ToString());
                    drow[3] = (dr1.GetValue(3) + "%");
                    //drow[4] = dr1.GetValue(4);
                    //if (dr1.GetValue(4).ToString() != "")
                    //{
                    //    DateTime dt = DateTime.Parse(dr1.GetValue(5).ToString());
                    //    string setdt = dt.ToString("dd-MM-yyyy");
                    //    drow[5] = setdt;
                    //}
                    tbl_main.Rows.Add(drow);
                }
                if (olecon.State != ConnectionState.Closed)
                {
                    olecon.Close();

                }
                dr1.Close();
            }
            catch (Exception es)
            {
                lblErrorMsg.Text = es.Message;
            }
        }

        private void txtBuyerCnic_TextChanged(object sender, EventArgs e)
        {
            if (txtBuyerCnic.Text.Length == 13)
            {
                DataSet ds = f.Select("select ProfileID,PName,PMobile,PAddress from Profile  where Pcnic='" + txtBuyerCnic.Text + "'");
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lblBuyerProfileID.Text = dr["ProfileID"].ToString();
                    txtBuyerName.Text = dr["PName"].ToString();
                    txtBuyerMobile.Text = dr["PMobile"].ToString();
                    txtBuyerAddress.Text = dr["PAddress"].ToString();
                    txtBuyerName.Enabled = false;
                    txtBuyerAddress.Enabled = false;
                    txtBuyerMobile.Enabled = false;
                    //btnSaveBuyer.Enabled = false;
                }
            }
            else
            {
                lblBuyerProfileID.Text = "";
                txtBuyerName.Enabled = true;
                txtBuyerAddress.Enabled = true;
                txtBuyerMobile.Enabled = true;
                //btnSaveBuyer.Enabled = true;
            }
        }

        private void txtTotalAmount_TextChanged(object sender, EventArgs e)
        {
            //lblErrorMsg.Text = "";
            //try
            //{
            //    if (txtTotalAmount.Text != "")
            //    {
            //        if (keydownflag == 0)
            //        {
            //            return;
            //        }
            //        keydownflag = 0;
            //        if (txtArea.Text != "")
            //        {
            //            lblMultiplierArea.Text = txtArea.Text;
            //        }
            //        if (txtTotalAmount.Text != "" && lblMultiplierArea.Text != "")
            //        {
            //            float area = float.Parse(lblMultiplierArea.Text);
            //            int am = int.Parse(txtTotalAmount.Text);
            //            txtRateMrla.Text = (area / am).ToString();
            //        }
            //        else
            //        {
            //            txtRateMrla.Text = "";
            //        }
            //    }
            //    else
            //    {
            //        txtRateMrla.Text = "";
            //    }
            //}
            //catch (Exception es)
            //{
            //    lblErrorMsg.Text = es.Message;
            //}
            //finally
            //{
            //    txtAdvance_TextChanged(sender, e);
            //}
        }

        //private void countIntallments()
        //{

        //    gridInstallmentsList.Rows.Clear();
        //    if (txtNumberofInstallments.Text != "" && txtAdvance.Text != "")
        //    {

        //        int numbofinstal = int.Parse(txtNumberofInstallments.Text);
        //        int blance = int.Parse(txtBalance.Text);
        //        int count = numbofinstal;
        //        for (int i = 1; i <= numbofinstal; i++)
        //        {
        //            int first = blance / count;
        //            gridInstallmentsList.Rows.Add(i + "-" + first);
        //            blance -= first;
        //            count -= 1;
        //        }
        //    }
        //}

        private void txtBalance_TextChanged(object sender, EventArgs e)
        {
            //countIntallments();
        }

        int countPaidInstallments = -1;

        private void loadPaidIntallments()
        {
            tbl_Installment.Rows.Clear();
            gridPendingINstallments.Rows.Clear();
            int TotalAmount = f.findnumber("select top 1 Debit   from Ledger where DealID=" + lblDealID.Text + " and isPlotsold=1 and isinstallment=0 order by InstallmentNumber desc");
            string str = "select InstallmentNumber,Credit,RecordDate   from Ledger where DealID=" + lblDealID.Text + " and isPlotsold=1 and isinstallment=1 order by InstallmentNumber desc";
            DataSet ds = f.Select(str);
            //int totalamount = int.Parse(txtTotalAmount.Text);
            int sumbalance = 0;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                DataRow drow1 = tbl_Installment.NewRow();
                drow1[0] = (int.Parse(dr["InstallmentNumber"].ToString()));
                DateTime d = DateTime.Parse(dr["RecordDate"].ToString());
                drow1[1] = d.ToString("dd-MMM-yy");
                drow1[2] = (dr["Credit"].ToString());
                sumbalance = TotalAmount - (int.Parse(dr["Credit"].ToString()));
                drow1[3] = sumbalance.ToString();
                //string gridrow = dr["InstallmentNumber"]+"-"+ dr["Debit"] +"-->>"+ dr["BalanceAmount"];
                tbl_Installment.Rows.Add(drow1);
                countPaidInstallments += 1;
            }
            //int balanceamount = f.findnumber("select top 1 BalanceAmount   from Ledger where DealID=" + lblDealID.Text + " and isPlotsold=1 and isagentPayment=0  order by InstallmentNumber desc");
            int paidamount =
                f.findnumber("select sum(Credit) as Cr from ledger  where DealID=" + lblDealID.Text +
                             " and isPlotsold=1");
            txtInstalmntsBalance.Text = (int.Parse(txtTotalAmount.Text) - paidamount).ToString();
            txtInstallCurrentPaid.Text = "0";
            //try
            // {
            lblCurrentInstallmntNumb.Text = (countPaidInstallments + 1).ToString();
            //     int blance = 0;
            //     blance = int.Parse(txtInstalmntsBalance.Text);
            //     if (blance > 0)
            //     {
            //         //txtInstallCurrentPaid.Text = (blance / pendinginstall).ToString(); //change to commment
            //          
            //         txtinstallmentRemainig.Text =
            //             (int.Parse(txtInstalmntsBalance.Text) - int.Parse(txtInstallCurrentPaid.Text)).ToString();
            //     }
            //     else
            //     {
            //         txtInstallCurrentPaid.Text = "0";
            //         txtinstallmentRemainig.Text =
            //             (int.Parse(txtInstalmntsBalance.Text) - int.Parse(txtInstallCurrentPaid.Text)).ToString();
            //     }
            // }
            // catch (Exception es)
            // {
            //     lblErrorMsg.Text = es.Message;
            // }
        }

        private void findPendingInstall()
        {
            gridPendingINstallments.Rows.Clear();
            int blance = 0;
            int pendinginstall = int.Parse(lbltotalinstallments.Text) - (countPaidInstallments + 1);
            //if (int.Parse(lblCurrentInstallmntNumb.Text) == 1)
            //{
            //    blance = int.Parse(txtBalance.Text);
            //}
            //else
            {
                blance = int.Parse(txtinstallmentRemainig.Text);
            }

            int count = pendinginstall;
            for (int i = 1; i <= pendinginstall; i++)
            {
                int first = blance / count;
                gridPendingINstallments.Rows.Add(i + 1 + "-" + first);
                blance -= first;
                count -= 1;
            }

        }


        //private void loadPaidIntallments()
        //{
        //    countPaidInstallments = -1;
        //    tbl_Installment.Rows.Clear();
        //    gridPendingINstallments.Rows.Clear();
        //    DataSet ds = f.Select("select InstallmentNumber,Credit   from Ledger where DealID=" + lblDealID.Text + " and isinstallment=1  order by InstallmentNumber desc");
        //    foreach (DataRow dr in ds.Tables[0].Rows)
        //    {
        //        DataRow drow1 = tbl_Installment.NewRow();
        //        drow1[0] = dr["InstallmentNumber"].ToString();
        //        drow1[1] = dr["Credit"].ToString();
        //        int balance=
        //        drow1[2] = (dr["BalanceAmount"].ToString());

        //        //string gridrow = dr["InstallmentNumber"]+"-"+ dr["Debit"] +"-->>"+ dr["BalanceAmount"];
        //        tbl_Installment.Rows.Add(drow1);
        //        countPaidInstallments += 1;
        //    }
        //    findPendingInstall();
        //    //int isFirstInstallment = f.findnumber("select count(*)   from Ledger where DealID=" + lblDealID.Text + " and isinstallment=1 ");
        //    //if (isFirstInstallment == 0)
        //    //{
        //    // txtInstalmntsBalance.Text = txtBalance.Text;
        //    //}
        //    // else
        //    // {
        //    int balanceamount = f.findnumber("select BalanceAmount   from Ledger where DealID=" + lblDealID.Text + " and isinstallment=1 order by InstallmentNumber desc");
        //    txtInstalmntsBalance.Text = balanceamount.ToString();
        //    //}


        //    try
        //    {
        //        //string s = "select Debit from Ledger where DealID=" + lblDealID.Text + " and isinstallment=1 order by LedgerID";
        //        //OleDbDataReader dr;
        //        //if (olecon.State == ConnectionState.Closed)
        //        //{
        //        //    olecon.Open();
        //        //}
        //        //OleDbCommand cmd = new OleDbCommand(s, olecon);//Advised to use parameterized query
        //        //dr = cmd.ExecuteReader();
        //        ////int i = 1;
        //        //while (dr.Read())
        //        //{
        //        //    countPaidInstallments += 1;
        //        //    gridCustPaidInstallments.Rows.Add(countPaidInstallments + " - " + (dr.GetValue(0).ToString()));
        //        //}
        //       // lblCurrentInstallmntNumb.Text = (countPaidInstallments + 1).ToString();

        //        //if (olecon.State != ConnectionState.Closed)
        //        //{
        //        //    olecon.Close();

        //        //}
        //        //dr.Close();

        //        int blance = 0;
        //        // int numbofinstal = int.Parse(txtNumberofInstallments.Text);
        //        int pendinginstall = int.Parse(lbltotalinstallments.Text) - (countPaidInstallments);

        //        blance = int.Parse(txtInstalmntsBalance.Text);
        //        if (blance > 0)
        //        {
        //            txtInstallCurrentPaid.Text = (blance / pendinginstall).ToString();
        //            txtinstallmentRemainig.Text =
        //                (int.Parse(txtInstalmntsBalance.Text) - int.Parse(txtInstallCurrentPaid.Text)).ToString();
        //        }
        //        else
        //        {
        //            txtInstallCurrentPaid.Text = "0";
        //            txtinstallmentRemainig.Text =
        //                (int.Parse(txtInstalmntsBalance.Text) - int.Parse(txtInstallCurrentPaid.Text)).ToString();
        //        }


        //    }
        //    catch (Exception es)
        //    {
        //        lblErrorMsg.Text = es.Message;
        //    }
        //}

        //private void findPendingInstall()
        //{
        //    gridPendingINstallments.Rows.Clear();
        //    int blance = 0;
        //    //int numbofinstal = int.Parse(txtNumberofInstallments.Text);

        //    int pendinginstall = int.Parse(lbltotalinstallments.Text) - (countPaidInstallments + 1);
        //    //if (int.Parse(lblCurrentInstallmntNumb.Text) == 1)
        //    //{
        //    //    blance = int.Parse(txtBalance.Text);
        //    //}
        //    //else
        //    {
        //        blance = int.Parse(txtinstallmentRemainig.Text);
        //    }

        //    int count = pendinginstall;
        //    for (int i = 1; i <= pendinginstall; i++)
        //    {
        //        int first = blance / count;

        //        gridPendingINstallments.Rows.Add(i + "-" + first);
        //        blance -= first;
        //        //count -= 1;
        //    }

        //}

        private void txtInstallCurrentPaid_TextChanged(object sender, EventArgs e)
        {
            if (txtInstallCurrentPaid.Text != "" && txtInstalmntsBalance.Text != "")
            {
                int curpaid = int.Parse(txtInstallCurrentPaid.Text);
                int blanceamount = int.Parse(txtInstalmntsBalance.Text);
                if (curpaid <= blanceamount)
                {
                    txtinstallmentRemainig.Text = (blanceamount - curpaid).ToString();
                }
                else
                {
                    lblErrorMsg.Text = "Current Installemnt is increased by balance amount";
                }
                //findPendingInstall();
            }
            else
            {
                txtinstallmentRemainig.Text = "0";
            }
        }

        private void txtinstallmentRemainig_TextChanged(object sender, EventArgs e)
        {
            if (txtinstallmentRemainig.Text == "")
            {
                txtinstallmentRemainig.Text = "0";
            }
        }

        private void txtPlotnumber_TextChanged(object sender, EventArgs e)
        {
           
        }
        //combo list of deals
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text=="")
            {
                lblErrorMsg.Text = "Select Deal Number form drop down menu.";
                return;
            }
            else
            {
                lblDealID.Text = comboBox1.Text;
                lblDealID_KeyDown(null, new KeyEventArgs(Keys.Enter));
                //loadDealDetail();
            }
            
        }
        DataSet  ds= new DataSet();
        int ispaymentrecieved = 0;
        int isagents = 0;
        int isexpenses = 0;
        private void chkboxPaymentRecieved_CheckedChanged(object sender, EventArgs e)
        {
            int recieved = 0;
            int paid = 0;
            gridLedger.DataSource = null;
            gridLedger.Rows.Clear();
            //ds= new DataSet();
            //"select * from ((Profile f inner join EmployeesProject e on e.ProfileID = f.ProfileID ) inner join DesignationsList l  on  e.DesignationID=l.DesignationID) where e.ProjectID = " +

    string s = "select * from (( Ledger b inner join Profile p on b.ProfileID=p.ProfileID) inner join  PlotsList pl on pl.PlotNumber=b.PlotNumber) where  isinstallment=1  and isexpenses=0 ";
            ds = f.Select(s);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                recieved += int.Parse(dr["Debit"].ToString());
                paid += int.Parse(dr["Credit"].ToString());
            }

            gridLedger.AutoGenerateColumns = false;
            gridLedger.DataSource = ds.Tables[0].DefaultView;
            gridLedger.ClearSelection();
            txtLedgerRptsumPaid.Text = paid.ToString();
            txtLedgerRptsumRecieved.Text = recieved.ToString();

            //ispaymentrecieved = 0;
            //if (chkboxPaymentRecieved.Checked==true)
            //{
            //    ispaymentrecieved = 1;
            //}
            //else
            //{
            //    ispaymentrecieved = 0;
            //}
            //loadgridexpensesall();

        }

        
        private void chkboxagents_CheckedChanged(object sender, EventArgs e)
        {
            //isagents = 0;
            //if (chkboxagents.Checked == true)
            //{
            //    isagents = 1;
            //}
            //else
            //{
            //    isagents = 0;
            //}
            //loadgridexpensesall();
        }

        private void chkboxExpenses_CheckedChanged(object sender, EventArgs e)
        {
            
            //if (chkboxExpenses.Checked == true)
            //{
            //    string s = "select * from Ledger where isagentPayment=0 and isinstallment=0 and isexpenses=1 and ProjectID="+lblprojID.Text+" ";
            //    ds = f.Select(s);
            //    gridLedgerExpense.AutoGenerateColumns = false;
            //    gridLedgerExpense.DataSource = ds.Tables[0].DefaultView;
            //    gridLedgerExpense.ClearSelection();
            //}
            //else
            //{
            //    gridLedgerExpense.Rows.Clear();
            //}
            //loadgridexpensesall();
        }

        private void loadgridexpensesall()
        {

            int recieved = 0;
            int paid = 0;
            gridLedger.DataSource = null;
            gridLedger.Rows.Clear();
            //ds= new DataSet();
                string s = "select * from Ledger b inner join Profile p on b.ProfileID=p.ProfileID where ( isagentPayment=" + isagents+ " or isinstallment="+ispaymentrecieved+ " ) and isexpenses=0 " ;
                ds = f.Select(s);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                recieved += int.Parse(dr["Debit"].ToString());
                paid += int.Parse(dr["Credit"].ToString());
            }
            
            gridLedger.AutoGenerateColumns = false;
            gridLedger.DataSource = ds.Tables[0].DefaultView;
               gridLedger.ClearSelection();
            txtLedgerRptsumPaid.Text = paid.ToString();
            txtLedgerRptsumRecieved.Text = recieved.ToString();
        }
        int Headid = 0;
        
        //txtleder recieved
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (txtLedgerRptsumRecieved.Text!="" && txtLedgerRptsumPaid.Text!="")
            {
                txtlederBalance.Text = (int.Parse(txtLedgerRptsumRecieved.Text) - int.Parse(txtLedgerRptsumPaid.Text)).ToString();
            }
        }

        private void txtLedgerRptsumRecieved_TextChanged(object sender, EventArgs e)
        {
            if (txtLedgerRptsumRecieved.Text != "" && txtLedgerRptsumPaid.Text != "")
            {
                txtlederBalance.Text = (int.Parse(txtLedgerRptsumRecieved.Text) - int.Parse(txtLedgerRptsumPaid.Text)).ToString();
            }
        }

        private void chkboxAllExpenses_CheckedChanged(object sender, EventArgs e)
        {
            //if (chkboxAllExpenses.Checked)
            //{
            //    int sum = 0;
            //    string s = "select * from Ledger b inner join expenseHead p on b.ExpID=p.ExpID where isagentPayment=0 and isinstallment=0 and isexpenses=1 and ProjectID=" + lblprojID.Text + " ";
            //    ds = f.Select(s);

            //    foreach (DataRow dr in ds.Tables[0].Rows)
            //    {
            //        sum += int.Parse(dr["Credit"].ToString());
            //    }

            //    gridLedgerExpense.AutoGenerateColumns = false;
            //    gridLedgerExpense.DataSource = ds.Tables[0].DefaultView;
            //    gridLedgerExpense.ClearSelection();
            //    txtledgerRptsumExpenses.Text = sum.ToString();
            //}
           
        }

        private void lblDealID_KeyDown(object sender, KeyEventArgs e)
        {


            lblErrorMsg.Text = "";
            if (lblDealID.Text == "")
            {
                return;
            }
            if (e.KeyCode==Keys.Enter)
            {
                int plotid = f.findnumber("select PlotNumber from Deals where DealID="+lblDealID.Text+" ");
                int saleid = f.findnumber("select salenumber from Deals where DealID=" + lblDealID.Text + " ");
                comboPlotname.SelectedValue = plotid.ToString();
                txtSaleNumber.Text = "";
                txtSaleNumber.Text = saleid.ToString();
                findDimentionArea();
            }
        }

        
        private void LoadComboPlots()
        {
            try
            {
                OleDbCommand sqlCmd = new OleDbCommand("select p_s_name,PlotNumber   from PlotsList order by PlotNumber ", olecon);
                if (olecon.State != ConnectionState.Open)
                {
                    olecon.Open();
                }
                OleDbDataReader sqlReader = sqlCmd.ExecuteReader();
                Dictionary<string, string> DictionaryCustomer = new Dictionary<string, string>();
                DictionaryCustomer.Add("-1", "--Select-- Plot or Shop");
                while (sqlReader.Read())
                {
                    string name = sqlReader["p_s_name"].ToString();
                    string Value = (sqlReader["PlotNumber"].ToString());
                    DictionaryCustomer.Add(Value, name);
                }
                comboPlotname.DisplayMember = "Value";
                comboPlotname.ValueMember = "Key";
                comboPlotname.DataSource = new BindingSource(DictionaryCustomer, null);
                sqlReader.Close();
                if (olecon.State != ConnectionState.Closed)
                {
                    olecon.Close();
                }
            }
            catch (Exception es)
            {
                lblErrorMsg.Text = "Error: " + es.Message;
            }

        }

        private void comboPlotname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                comboBox1.Items.Clear();
                DataSet ds = f.Select("Select DealID from Deals where PlotNumber=" + comboPlotname.SelectedValue + "");
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    comboBox1.Items.Add(dr["DealID"].ToString());
                }
                comboBox1.SelectedIndex = (comboBox1.Items.Count) - 1;
            }
        }

        private void comboPlotname_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnPrintDeal_Click(object sender, EventArgs e)
        {
            DateTime dt=DateTime.Now;
            DealReportCrystal cr = new DealReportCrystal();
            string dat = dt.ToString("dd-MM-yyyy");
            TextObject txtprjName1 = (TextObject)cr.ReportDefinition.Sections["Section1"].ReportObjects["txtprjname"];
            txtprjName1.Text = lblProjectName.Text;
            TextObject txtprjAddress = (TextObject)cr.ReportDefinition.Sections["Section1"].ReportObjects["txtprjaddress"];
            string add = f.findName("select PAddress from Profile where ProfileID=0");
            txtprjAddress.Text = add.ToUpper();
            TextObject date = (TextObject)cr.ReportDefinition.Sections["Section2"].ReportObjects["txtprintDate"];
            date.Text = dat;
            TextObject dealid = (TextObject)cr.ReportDefinition.Sections["Section2"].ReportObjects["txtdealID"];
            dealid.Text = lblDealID.Text; //find
            TextObject dealdate = (TextObject)cr.ReportDefinition.Sections["Section2"].ReportObjects["txtDealDate"];
            dealdate.Text = txtdealdate.Text;
            TextObject plotnumber = (TextObject)cr.ReportDefinition.Sections["Section2"].ReportObjects["txtPlotnumber"];
            plotnumber.Text = comboPlotname.Text;
            TextObject area = (TextObject)cr.ReportDefinition.Sections["Section2"].ReportObjects["txtArea"];
            area.Text = txtArea.Text;
            TextObject sellername = (TextObject)cr.ReportDefinition.Sections["Section2"].ReportObjects["txtSellerName"];
            sellername.Text = txtNameSeller.Text;
            TextObject buyername = (TextObject)cr.ReportDefinition.Sections["Section2"].ReportObjects["txtBuyerName"];
            buyername.Text = comboPlotname.Text;
            TextObject buyercnic = (TextObject)cr.ReportDefinition.Sections["Section2"].ReportObjects["txtBuyercnic"];
            buyercnic.Text = txtBuyerCnic.Text;
            TextObject buyerphone = (TextObject)cr.ReportDefinition.Sections["Section2"].ReportObjects["txtBuyerPhone"];
            buyerphone.Text = txtBuyerMobile.Text;
            TextObject txtbuyeradd = (TextObject)cr.ReportDefinition.Sections["Section2"].ReportObjects["txtBuyerAddress"];
            txtbuyeradd.Text = txtBuyerAddress.Text;
            TextObject rateMarla = (TextObject)cr.ReportDefinition.Sections["Section2"].ReportObjects["txtRateMarla"];
            rateMarla.Text = txtinstallmentRemainig.Text;
            TextObject rateTotal = (TextObject)cr.ReportDefinition.Sections["Section2"].ReportObjects["txtTotalRate"];
            rateTotal.Text = txtTotalAmount.Text;
            //TextObject advance = (TextObject)cr.ReportDefinition.Sections["Section2"].ReportObjects["txtadvance"];
            //advance.Text = txtAdvance.Text;
            TextObject paidtotal = (TextObject)cr.ReportDefinition.Sections["Section2"].ReportObjects["txttotalPaid"];
            paidtotal.Text = txtTotalPaid.Text;
            TextObject balanceamount = (TextObject)cr.ReportDefinition.Sections["Section2"].ReportObjects["txtBalanceAmount"];
            balanceamount.Text = txtBalance.Text;
            cr.PrintToPrinter(1, false, 0, 0);
            //cr.PrintToPrinter();
        }

        private void grpboxInstallment_Enter(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnLedgerExpenseExecute_Click(object sender, EventArgs e)
        {
            int sum = 0;
            string s = "";
            if (rdbtnExpenseAll.Checked)
            {
                s = "select * from Ledger b inner join expenseCatagory p on b.CatagoryID=p.CatagoryID where isagentPayment=0 and isinstallment=0 and isexpenses=1 ";

            }
            if (rdbtnExpenseCatagoryWise.Checked)
            {
                s = "select * from Ledger b inner join expenseCatagory p on b.CatagoryID=p.CatagoryID where isagentPayment=0 and isinstallment=0 and isexpenses=1 and p.CatagoryID=" + CatagoryID + " ";

            }
            if (rdbtnExpenseHeadWise.Checked)
            {
                s = "select * from Ledger b inner join expenseCatagory p on b.CatagoryID=p.CatagoryID where isagentPayment=0 and isinstallment=0 and isexpenses=1 and p.ExpID=" + Headid + " ";
            }
            ds = f.Select(s);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                sum += int.Parse(dr["Credit"].ToString());
            }

            gridLedgerExpense.AutoGenerateColumns = false;
            gridLedgerExpense.DataSource = ds.Tables[0].DefaultView;
            gridLedgerExpense.ClearSelection();
            txtledgerRptsumExpenses.Text = sum.ToString();
        }

        private void rdbtnExpenseHeadWise_CheckedChanged(object sender, EventArgs e)
        {
            if(rdbtnExpenseHeadWise.Checked)
            {
                comboLedgerRptExpenseHeader.Enabled = true;
            }
            else
            {
                comboLedgerRptExpenseHeader.Enabled = false;

            }
            comboledgerreportCatagory.Items.Clear();
            DataSet ds = f.Select("select ExpID,HeadName from expenseHead order by ExpID");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                comboLedgerRptExpenseHeader.Items.Add(dr["HeadName"].ToString());
            }
        }

        private void rdbtnExpenseCatagoryWise_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbtnExpenseCatagoryWise.Checked)
            {
                comboledgerreportCatagory.Enabled = true;
            }
            else
            {
                comboledgerreportCatagory.Enabled = false;

            }
            comboledgerreportCatagory.Items.Clear();
            DataSet ds = f.Select("select CatagoryID,CatagoryName   from expenseCatagory order by CatagoryID");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                comboledgerreportCatagory.Items.Add(dr["CatagoryName"].ToString());
            }
        }

        private void rdbtnExpenseAll_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbtnExpenseAll.Checked)
            {
                comboLedgerRptExpenseHeader.Enabled = false;
                comboledgerreportCatagory.Enabled = false;
            }
        }
        int CatagoryID = 0;
        private void comboledgerreportCatagory_SelectedIndexChanged(object sender, EventArgs e)
        {
            CatagoryID =
                f.findnumber("select CatagoryID from expenseCatagory where CatagoryName='" + comboledgerreportCatagory.Text + "'");
        }
        private void comboLedgerRptExpenseHeader_SelectedIndexChanged(object sender, EventArgs e)
        {
            Headid =
                f.findnumber("select CatagoryID from expenseCatagory where CatagoryName='" + comboLedgerRptExpenseHeader.Text + "'");
        }

        private void txtAgentCnic_TextChanged_1(object sender, EventArgs e)
        {
            lblErrorMsg.Text = "";

            if (txtAgentCnic.Text.Length == 13)
            {
                DataSet ds = f.Select("select ProfileID,PName,PMobile,PAddress from Profile where Pcnic='" + txtAgentCnic.Text + "'");
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lblAgentProfileID.Text = dr["ProfileID"].ToString();
                    txtAgentName.Text = dr["PName"].ToString();
                    txtAgentMobile.Text = dr["PMobile"].ToString();
                    txtAgentAddress.Text = dr["PAddress"].ToString();
                    txtAgentName.Enabled = false;
                    txtAgentAddress.Enabled = false;
                    txtAgentMobile.Enabled = false;
                }
            }
            else
            {
                lblAgentProfileID.Text = "";
                txtAgentName.Enabled = true;
                txtAgentMobile.Enabled = true;
                txtAgentAddress.Enabled = true;
            }
        }

        private void txtTotalPaid_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
