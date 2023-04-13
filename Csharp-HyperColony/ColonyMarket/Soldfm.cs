using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ColonyMarket.classes;
using ColonyMarket.Reports;
using CrystalDecisions.CrystalReports.Engine;
using MessageBox = System.Windows.MessageBox;

namespace ColonyMarket
{
    public partial class Soldfm : Form
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
        private static Soldfm alreadyOpened = null;


        //public Soldfm()
        //{
        //    InitializeComponent();
        //}

        public Soldfm(int poj, int plot, int salenumb, string projname)
        {
            if (alreadyOpened != null && !alreadyOpened.IsDisposed)
            {
                alreadyOpened.Focus();          // Bring the old one to top
                Shown += (s, e) => this.Close();  // and destroy the new one.
                return;
            }

            InitializeComponent();
            projectID = poj;
            PlotID = plot;
            ProjectName = projname;
            SaleID = salenumb;
        }
        public Soldfm()
        {

        }
        //txtSaleNumber.Text = "1";
        //NumbOfSale = 0;
        //txtSaleNumber.Text = NumbOfSale.ToString();
        //DataSet ds = f.Select("select Dimensions,Area,IsSpecial,IsCorner,IsParkFace,IsMainBulevard,SaleNumber from PlotsList pl inner join PlotsDimensionsList pd on pl.DimensionListID=pd.DimensionListID where pl.PlotNumber=" + txtPlotnumber.Text + " and pl.ProjectID=" + txtProjectNumber.Text + "");
        //foreach (DataRow dr in ds.Tables[0].Rows)
        //{
        //    lblAgentProfileID.Text = dr["ProfileID"].ToString();
        //    txtAgentName.Text = dr["PName"].ToString();
        //    txtAgentMobile.Text = dr["PMobile"].ToString();
        //    txtAgentAddress.Text = dr["PAddress"].ToString();
        //    txtBuyerName.Enabled = false;
        //    txtBuyerAddress.Enabled = false;
        //    txtBuyerMobile.Enabled = false;
        //}
        //txtProjectNumber.Text = dealid.ToString();
        //dealid = f.createNumber("Select top 1 DealID  from Deals order by DealID desc ");
        //cnic.Enabled = false;
        //btnSaveSeller.Enabled = false;

        //customer paid debit amount **** record insert credit
        //agent and expense credit amount ****** record insert debit

        private void txtSaleNumber_TextChanged(object sender, EventArgs e)
        {
            //lblErrorMsg.Text = "";
            //txtSellerCnic.Text = "";
            //txtBuyerCnic.Text = "";
            //if (txtSaleNumber.Text == "")
            //{
            //    return;
            //}

            //if (int.Parse(txtSaleNumber.Text) > SaleID)
            //{
            //    lblErrorMsg.Text = "Last Sale ID: " + SaleID.ToString() + "found.";
            //    txtSaleNumber.Text = SaleID.ToString();
            //    return;
            //}
            int dealid = f.findnumber("Select top 1 DealID  from Deals where PlotNumber=" + txtPlotnumber.Text + " and ProjectID=" + txtProjectNumber.Text + " and salenumber=" + txtSaleNumber.Text + " order by DealID desc");
            txtSellerCnic.Text = (f.findLongnumber("Select Pcnic  from PlotsList d inner join Profile p on p.ProfileID=d.plotOwner where d.PlotNumber=" + txtPlotnumber.Text + " and d.ProjectID=" + txtProjectNumber.Text + " ")).ToString();

            //int dealid = int.Parse(lblDealID.Text);
            if (dealid == 0) //if no previouse deal found
            {
                //create dealid
                lblDealID.Text = f.createNumber("Select top 1 DealID  from Deals order by DealID desc").ToString();
                txtNumberofInstallments.Text = (f.findnumber("select NoofInstallments from Rules where ProjectID=" + txtProjectNumber.Text + "")).ToString();
            }
            else //if deal found
            {
                lblDealID.Text = dealid.ToString();
                loadgridprofile();
                int isComplete = 0;
                DataSet ds = f.Select("Select Pcnic,isComplete,NumbofInstallments,Rate,Area,TotalAmount,Advance,NumbofInstallments  from Deals d inner join Profile p on p.ProfileID=d.buyerID where d.PlotNumber=" + txtPlotnumber.Text + " and d.ProjectID=" + txtProjectNumber.Text + " and d.DealID=" + lblDealID.Text + " and salenumber=" + txtSaleNumber.Text + " ");
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    txtBuyerCnic.Text = dr["Pcnic"].ToString();
                    isComplete = int.Parse(dr["isComplete"].ToString());
                    txtRateMrla.Text = (dr["Rate"].ToString());
                    lblMultiplierArea.Text = (dr["Area"].ToString());
                    txtTotalAmount.Text = (dr["TotalAmount"].ToString());
                    txtNumberofInstallments.Text = (dr["NumbofInstallments"].ToString());

                }
                txtSellerCnic.Text = (f.findLongnumber("Select Pcnic  from Deals d inner join Profile p on p.ProfileID=d.SalerID where d.PlotNumber=" + txtPlotnumber.Text + "  and d.DealID=" + lblDealID.Text + " and salenumber=" + txtSaleNumber.Text + " ")).ToString();
                txtAgentCnic.Text = (f.findLongnumber("Select Pcnic  from Deals d inner join Profile p on p.ProfileID=d.AgentID where d.PlotNumber=" + txtPlotnumber.Text + "  and d.DealID=" + lblDealID.Text + " and salenumber=" + txtSaleNumber.Text + " ")).ToString();
                loadPaidIntallments();
                findPendingInstall();
                //txtBuyerCnic.Text = (f.findLongnumber("Select Pcnic  from Deals d inner join Profile p on p.ProfileID=d.buyerID where d.PlotNumber=" + txtPlotnumber.Text + " and d.ProjectID=" + txtProjectNumber.Text + " and d.DealID=" + lblDealID.Text + "")).ToString();
                //if deal is final
                //int isComplete = f.findnumber("Select isComplete from Deals where PlotNumber=" + txtPlotnumber.Text + " and ProjectID=" + txtProjectNumber.Text + " and  DealID=" + lblDealID.Text + " and isfinal=1 ");
                //txtNumberofInstallments.Text = (f.findnumber("select NumbofInstallments from Deals where DealID=" + lblDealID.Text + "")).ToString();
                if (isComplete == 1)
                {
                    grpBoxMain.Enabled = false;
                    lblErrorMsg.Text = "This Deal is Completed.";
                    //loadPaidIntallments();
                    return;
                }
                bool isfinal = f.Selectbool("Select * from Deals where PlotNumber=" + txtPlotnumber.Text + " and ProjectID=" + txtProjectNumber.Text + " and  DealID=" + lblDealID.Text + " and isfinal=1 ");
                if (isfinal)
                {
                    btnSaveAgent.Enabled = false;
                    txtBuyerCnic.Enabled = false;
                    //txtSellerCnic.Enabled = false;
                    //txtAgentCnic.Enabled = false;
                    btnNewEntry.Enabled = false;
                    //btnModify.Enabled = false;
                    //btnDelete.Enabled = false;
                    btnDealfinal.Enabled = false;
                    //btnCanceldeal.Enabled = false;
                    //btnsavedeail.Enabled = false;
                    //btnModifyDeal.Enabled = false;
                    //btnNewDeal.Enabled = true;
                    txtRateMrla.Enabled = false;
                    txtTotalAmount.Enabled = false;
                    //txtBalance.Enabled = false;
                    txtNumberofInstallments.Enabled = false;
                    //txtAdvance.Enabled = false;
                    grpboxInstallment.Enabled = true;
                    lblErrorMsg.Text = lblErrorMsg.Text + " " + "This Deal is Finalized.";
                    //loadPaidIntallments();
                    //btnCanceldeal.Enabled = false;
                    //btnsavedeail.Enabled = false;
                }
                bool iscancel = f.Selectbool("Select * from Deals where PlotNumber=" + txtPlotnumber.Text + " and ProjectID=" + txtProjectNumber.Text + " and  DealID=" + lblDealID.Text + " and isCancel=1 ");
                if (iscancel)
                {
                    btnSaveAgent.Enabled = false;
                    btnNewEntry.Enabled = false;
                    //btnModify.Enabled = false;
                    //btnDelete.Enabled = false;
                    btnDealfinal.Enabled = false;
                    // btnCanceldeal.Enabled = false;
                    btnSaveAgent.Enabled = false;
                    //btnModifyDeal.Enabled = true;
                    //btnNewDeal.Enabled = true;
                    lblErrorMsg.Text = "This Deal is Cancelled.";
                }
                //bool issave = f.Selectbool("Select * from Deals where PlotNumber=" + txtPlotnumber.Text + " and ProjectID=" + txtProjectNumber.Text + " and  DealID=" + lblDealID.Text + " and issave=1 ");
                //if (issave)
                //{
                //    btnSaveAgent.Enabled = true;
                //    btnNewEntry.Enabled = true;
                //    //btnModify.Enabled = true;
                //   // btnDelete.Enabled = true;
                //    btnDealfinal.Enabled = true;
                //    //btnCanceldeal.Enabled = true;
                //    btnSaveAgent.Enabled = true;
                //    //btnModifyDeal.Enabled = true;
                //    //btnNewDeal.Enabled = true;
                //    lblErrorMsg.Text = "This Deal is Saved.";
                //   // btnCanceldeal.Enabled = true;
                //}
            }
            //}


            //gridProfile.DisplayMemberPath = tbl_main.Columns[0].ToString();
        }

        public string NewAgentCommission { get; set; }

        private void Soldfm_Load(object sender, EventArgs e)
        {
            try
            {
                txtProjName.Text = ProjectName;
                txtPlotnumber.Text = PlotID.ToString();
                txtProjectNumber.Text = projectID.ToString();
                findDimentionArea();
                projectDetail();
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

                txtSaleNumber.Text = SaleID.ToString();
                dtPaidInstallment.Value = DateTime.Now;
            }
            catch (Exception es)
            {
                lblErrorMsg.Text = es.Message;
            }



        }
        DataTable tbl_Installment = new DataTable("tbl_main");
        private void projectDetail()
        {


            try
            {
                string s = "select Rate_Marla,XtraRate_on_special,MinimumAdvance from Projects where ProjectID=" + txtProjectNumber.Text + "";
                OleDbDataReader dr;
                if (olecon.State == ConnectionState.Closed)
                {
                    olecon.Open();
                }
                OleDbCommand cmd = new OleDbCommand(s, olecon);//Advised to use parameterized query
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    txtDefaultRateMarla.Text = (int.Parse(dr.GetValue(0).ToString()) + int.Parse(dr.GetValue(1).ToString())).ToString();
                    keydownflag = 1;
                    //txtRateMrla.Text = txtDefaultRateMarla.Text;
                    txtMinAdv.Text = (dr.GetValue(2).ToString());
                    //txtAdvance.Text =Math.Round(int.Parse(txtMinAdv.Text) * float.Parse(lblMultiplierArea.Text),0).ToString();
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
        private void findDimentionArea()
        {
            try
            {
                string s = "select Dimensions,Area,IsSpecial,IsCorner,IsParkFace,IsMainBulevard,SaleNumber,p_s_name,plotOwner from PlotsList pl inner join PlotsDimensionsList pd on pl.DimensionListID=pd.DimensionListID where pl.PlotNumber=" + txtPlotnumber.Text + " and pl.ProjectID=" + txtProjectNumber.Text + "";
                OleDbDataReader dr;
                if (olecon.State == ConnectionState.Closed)
                {
                    olecon.Open();
                }
                OleDbCommand cmd = new OleDbCommand(s, olecon);//Advised to use parameterized query
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    txtDimension.Text = (dr.GetValue(0).ToString());
                    txtArea.Text = (dr.GetValue(1).ToString());
                    txt_p_s_name.Text = (dr.GetValue(7).ToString());
                    lblMultiplierArea.Text = txtArea.Text;
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
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (txtRateMrla.Text != "")
            {
                if (keydownflag == 0)
                {
                    return;
                }
                keydownflag = 0;
                if (txtArea.Text != "")
                {
                    lblMultiplierArea.Text = txtArea.Text;
                }
                if (txtRateMrla.Text != "" && lblMultiplierArea.Text != "")
                {
                    int rate = int.Parse(txtRateMrla.Text);
                    float area = float.Parse(lblMultiplierArea.Text);
                    txtTotalAmount.Text = Math.Round(rate * area, 0).ToString();
                }
                else
                {

                    txtTotalAmount.Text = "";
                }
            }
            else
            {
                txtTotalAmount.Text = "";
            }

            //txtRateMrla.Text = String.Format("{0:c2}", txtRateMrla.Cost);
        }

        private void Calculate()
        {

        }

        private bool KeyEnteredIsValid(string key)
        {
            Regex regex;
            regex = new Regex("[^0-9]+$"); //regex that matches disallowed text
            return regex.IsMatch(key);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void comboCommProfit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboCommProfit.Text != "" && txtTotalAmount.Text != "")
            {
                string commission = comboCommProfit.Text;
                commission = commission.Replace(@"%", "");
                int perc = int.Parse(commission);
                int totalamount = int.Parse(txtTotalAmount.Text);
                float commamount = (totalamount / 100) * perc;
                txtPaidAgentAmount.Text = (Math.Round(commamount)).ToString();
            }


        }

        private void cnic_TextChanged(object sender, EventArgs e)
        {
            if (txtSellerCnic.Text.Length == 13)
            {
                DataSet ds = f.Select("select ProfileID,PName,PMobile,PAddress from Profile where Pcnic='" + txtSellerCnic.Text + "'");
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
            if (txtSellerCnic.Text == "1111111111111")
            {
                txtSellerCnic.Visible = false;
            }
            else
            {
                txtSellerCnic.Visible = true;
            }
        }

        private void cnic_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (lblSellerprofileID.Text == "")
                {
                    txtNameSeller.Focus();
                }
                else
                {
                    txtBuyerCnic.Focus();
                }
            }
           // e.SuppressKeyPress = true;
        }

        private void cnic_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (e.KeyChar != (char)8 && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
           
        }

        private void NameBuyer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                mobile.Focus();
            }
           // e.SuppressKeyPress = true;
        }

        private void mobile_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                address.Focus();
            }
           // e.SuppressKeyPress = true;
        }

        private void address_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                //btnSaveSeller.Focus();
            }
           // e.SuppressKeyPress = true;
        }

        private void comboCommProfit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                btnSaveAgent.Focus();
            }
           // e.SuppressKeyPress = true;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtTotalAmount.Focus();

            }
            else
            {
                keydownflag = 1;

            }
           // e.SuppressKeyPress = true;

        }

        private void txtTotalAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                comboCommProfit.Focus();

            }
            else
            {
                keydownflag = 1;
            }
           // e.SuppressKeyPress = true;

        }

        //txtadvanc
        //txtbalance
        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtNumberofInstallments.Focus();
            }
        }

        private void txtRateMrla_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (e.KeyChar != (char)8 && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void txtTotalAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (e.KeyChar != (char)8 && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void txtAdvance_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (e.KeyChar != (char)8 && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtBalance_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (e.KeyChar != (char)8 && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtNumberofInstallments_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (e.KeyChar != (char)8 && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtNumberofInstallments_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                btnDealfinal.Focus();
            }
           // e.SuppressKeyPress = true;
        }

        private void btnDealfinal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtRateMrla.Focus();
            }
           // e.SuppressKeyPress = true;
        }

        private void btnNewEntry_Click(object sender, EventArgs e)
        {
            lblErrorMsg.Text = "";
            txtSellerCnic.Text = "";
            address.Text = "";
            mobile.Text = "";
            txtNameSeller.Text = "";
            lblSellerprofileID.Text = "";
            btnSaveAgent.Enabled = true;
            //btnModify.Enabled = false;
            //btnDelete.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {


                lblErrorMsg.Text = "";
                if (txtAgentCnic.Text == "")
                {
                    lblErrorMsg.Text = "Please Fill Agent CNIC.";
                    return;
                }
                if (txtAgentCnic.Text.Length != 13)
                {
                    lblErrorMsg.Text = "Please Enter Valid 13-Digit Agent CNIC Number without dashes.";
                    return;
                }
                if (txtAgentName.Text == "")
                {
                    lblErrorMsg.Text = "Please Agent Fill Name.";
                    return;
                }
                if (txtAgentAddress.Text == "")
                {
                    lblErrorMsg.Text = "Please Fill Agent Address.";
                    return;
                }
                if (txtAgentMobile.Text == "")
                {
                    lblErrorMsg.Text = "Please Enter Agent Mobile Number.";
                    return;
                }
                if (lblAgentProfileID.Text == "")
                {
                    int profileid = f.createNumber("SELECT ProfileID from Profile order by ProfileID desc");
                    f.Insert("insert into Profile(ProfileID,PName,Pcnic,PMobile,PAddress) values(" + profileid + ",'" + txtAgentName.Text + "','" + txtAgentCnic.Text + "','" + txtAgentMobile.Text + "','" + txtAgentAddress.Text + "')");
                    lblAgentProfileID.Text = (f.findnumber("SELECT ProfileID from Profile where Pcnic='" + txtAgentCnic.Text + "' order by ProfileID desc")).ToString();
                    txtAgentName.Enabled = false;
                    txtAgentMobile.Enabled = false;
                    txtAgentAddress.Enabled = false;
                }
                //bool dealstatus =
                //f.Selectbool("Select * from Deals where isfinal=1 and ProjectID=" + txtProjectNumber.Text + " and PlotNumber=" + txtPlotnumber.Text + " and DealID=" + lblDealID.Text + " ");
                //if (dealstatus == false)
                //{
                //    lblErrorMsg.Text = "This deal is not finalized. Plz finalize deal first.";
                //    return;
                //}
                //if (comboCommProfit.Text == "")
                //{
                //    lblErrorMsg.Text = "Enter or Select Commission for this agent.";
                //    return;
                //}
                //string commission = comboCommProfit.Text;
                //commission = commission.Replace(@"%", "");
                ////check for update
                //bool test =
                //f.Selectbool("Select * from Ledger where ProfileID=" + lblAgentProfileID.Text +
                //         " and ProjectID=" + txtProjectNumber.Text + " and PlotNumber=" + txtPlotnumber.Text + " and DealID=" + lblDealID.Text + " ");
                //if (test)
                //{
                //    f.Update("update Ledger set  Debit=" + txtPaidAgentAmount.Text + " where ProfileID=" + lblAgentProfileID.Text +
                //         " and ProjectID=" + txtProjectNumber.Text + " and PlotNumber=" + txtPlotnumber.Text + " and DealID=" + lblDealID.Text + "");
                //    f.Update("update Agents set  ProfitShare=" + commission + " where ProfileID=" + lblAgentProfileID.Text +
                //         " and ProjectID=" + txtProjectNumber.Text + " and PlotNumber=" + txtPlotnumber.Text + " and DealID=" + lblDealID.Text + "");

                //    //lblErrorMsg.Text = "This Agent is already registered for this Deal.";
                //    //return;
                //}

                //f.Insert("insert into Agents(DealID,ProfileID,ProjectID,PlotNumber,ProfitShare) values('" +
                //         lblDealID.Text + "','" + lblAgentProfileID.Text + "','" + txtProjectNumber.Text + "','" +
                //         txtPlotnumber.Text + "'," + commission + ")");
                //f.Insert("insert into Ledger(DealID,ProfileID,ProjectID,PlotNumber,SaleNumber,Debit,Credit,BalanceAmount,RecordDate,isagentPayment,Remarks) values('" +
                //         lblDealID.Text + "','" + lblAgentProfileID.Text + "','" + txtProjectNumber.Text + "','" +
                //         txtPlotnumber.Text + "'," + txtSaleNumber.Text + "," + txtPaidAgentAmount.Text + ",0,0,'" + DateTime.Now + "',1,'Commision Sale')");
                //txtAgentName.Text = "";
                //txtAgentCnic.Text = "";
                //txtAgentMobile.Text = "";
                //txtAgentAddress.Text = "";
                //loadgridprofile();
            }
            catch (Exception s)
            {
                lblErrorMsg.Text = s.Message;
            }
        }
        DataTable tbl_main = new DataTable("tbl_main");

        private void loadgridprofile()
        {
            tbl_main.Clear();
            try
            {

                string s1 = "select PName,Pcnic,PMobile,ProfitShare from Agents b inner join Profile p on b.ProfileID=p.ProfileID where b.PlotNumber=" + txtPlotnumber.Text + " and b.ProjectID=" + txtProjectNumber.Text + " and  b.DealID=" + lblDealID.Text + " ";
                OleDbDataReader dr1;
                if (olecon.State == ConnectionState.Closed)
                {
                    olecon.Open();
                }
                OleDbCommand cmd1 = new OleDbCommand(s1, olecon);//Advised to use parameterized query
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

        private void btnsavedeail_Click(object sender, EventArgs e)
        {
            try
            {
                lblErrorMsg.Text = "";
                DateTime dt = DateTime.Now;
                if (lblSellerprofileID.Text == "" && int.Parse(txtSaleNumber.Text) > 1)
                {
                    lblErrorMsg.Text = "Enter Seller Information.";
                    return;
                }
                if (lblBuyerProfileID.Text == "")
                {
                    lblErrorMsg.Text = "Enter Buyer Information.";
                    return;
                }
                //bool isfounddeail = f.Selectbool("Select * from Deals where DealID=" + lblDealID.Text + " ");
                //if (isfounddeail)
                //{
                //    f.Update("update Deals set buyerID=" + lblBuyerProfileID.Text + ", dealDate='" + dt + "' and Rate=" + txtRateMrla.Text + " , TotalAmount = " + txtTotalAmount.Text + " , Advance = " + txtTotalAmount.Text + " , NumbofInstallments = " + txtNumberofInstallments.Text + " ,issave=1 ,isfinal=0,isCancel=0 where DealID=" + lblDealID.Text + " ");
                //}
                //else
                {
                    int isprojectsale = 1;
                    if (txtSaleNumber.Text != "1")
                    {
                        isprojectsale = 0;
                    }

                    //if (lblSellerprofileID.Text == "")
                    //{
                    //    f.Insert("insert into Deals(DealID,ProjectID,PlotNumber,isProjectSale,salenumber,issave,isfinal,isCancel,buyerID,AgentID,AgentCommission,Rate,Area,TotalAmount,NumbofInstallments,SpNote,dealDate) " +
                    //          "values(" + lblDealID.Text + "," + txtProjectNumber.Text + "," + txtPlotnumber.Text + "," + isprojectsale + "," + txtSaleNumber.Text + ",1,0,0," + lblBuyerProfileID.Text + "," + lblAgentProfileID.Text + "," + comboCommProfit.Text + "," + txtRateMrla.Text + "," + lblMultiplierArea.Text + "," + txtTotalAmount.Text + "," + txtNumberofInstallments.Text + ",'Note','" + dt + "')");
                    //}
                    //else
                   // {
                        f.Insert("insert into Deals(DealID,ProjectID,PlotNumber,isProjectSale,salenumber,issave,isfinal,isCancel,SalerID,buyerID,AgentID,AgentCommission,Rate,Area,TotalAmount,Advance,NumbofInstallments,SpNote,dealDate) " +
                             "values(" + lblDealID.Text + "," + txtProjectNumber.Text + "," + txtPlotnumber.Text + "," + isprojectsale + "," + txtSaleNumber.Text + ",1,0,0," + lblSellerprofileID.Text + "," + lblBuyerProfileID.Text + ","+lblAgentProfileID.Text+","+comboCommProfit.Text+"," + txtRateMrla.Text + "," + lblMultiplierArea.Text + "," + txtTotalAmount.Text + "," + txtNumberofInstallments.Text + ",'Note','" + dt + "')");
                    //}


                }
                lblErrorMsg.Text = "Deal Saved.";
                //btnCanceldeal.Enabled = true;
                btnDealfinal.Enabled = true;
            }
            catch (Exception es)
            {
                lblErrorMsg.Text = es.Message;
            }


        }

        private void comboCommProfit_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (e.KeyChar != (char)8 && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtBuyerCnic_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (txtBuyerName.Enabled)
                {
                    txtBuyerName.Focus();
                }
                else
                {
                    txtAgentCnic.Focus();
                }
            }
            
        }

        private void txtBuyerCnic_TextChanged(object sender, EventArgs e)
        {
            if (txtBuyerCnic.Text.Length == 13)
            {
                DataSet ds = f.Select("select ProfileID,PName,PMobile,PAddress from Profile where Pcnic='" + txtBuyerCnic.Text + "'");
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lblBuyerProfileID.Text = dr["ProfileID"].ToString();
                    txtBuyerName.Text = dr["PName"].ToString();
                    txtBuyerMobile.Text = dr["PMobile"].ToString();
                    txtBuyerAddress.Text = dr["PAddress"].ToString();
                    txtBuyerName.Enabled = false;
                    txtBuyerAddress.Enabled = false;
                    txtBuyerMobile.Enabled = false;
                    btnSaveBuyer.Enabled = false;
                }
            }
            else
            {
                lblBuyerProfileID.Text = "";
                txtBuyerName.Enabled = true;
                txtBuyerAddress.Enabled = true;
                txtBuyerMobile.Enabled = true;
                btnSaveBuyer.Enabled = true;
            }
            
        }

        private void txtBuyerCnic_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (e.KeyChar != (char)8 && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
                

            }
            //e.SuppressKeyPress = true;
        }

        private void txtBuyerMobile_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtBuyerAddress.Focus();
            }
           //// e.SuppressKeyPress = true;
        }

        private void txtBuyerAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                btnSaveBuyer.Focus();
            }
           // e.SuppressKeyPress = true;
        }

        private void txtBuyerName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtBuyerMobile.Focus();
            }
           // e.SuppressKeyPress = true;
        }

        private void btnSaveSeller_Click(object sender, EventArgs e)
        {
            lblErrorMsg.Text = "";
            if (txtSellerCnic.Text == "")
            {
                lblErrorMsg.Text = "Please Fill Seller CNIC.";
                return;
            }
            if (txtSellerCnic.Text.Length != 13)
            {
                lblErrorMsg.Text = "Please Enter Valid 13-Digit Seller CNIC Number without dashes.";
                return;
            }
            if (txtNameSeller.Text == "")
            {
                lblErrorMsg.Text = "Please Fill Seller Name.";
                return;
            }
            if (address.Text == "")
            {
                lblErrorMsg.Text = "Please Fill Seller Address.";
                return;
            }
            if (mobile.Text == "")
            {
                lblErrorMsg.Text = "Please Enter Seller Mobile Number.";
                return;
            }
            if (lblSellerprofileID.Text == "")
            {
                try
                {
                    int profileid = f.createNumber("SELECT ProfileID from Profile order by ProfileID desc");
                    f.Insert("insert into Profile(ProfileID,PName,Pcnic,PMobile,PAddress) values(" + profileid + ",'" + txtNameSeller.Text + "','" + txtSellerCnic.Text + "','" + mobile.Text + "','" + address.Text + "')");
                    lblSellerprofileID.Text = (f.findnumber("SELECT ProfileID from Profile where Pcnic='" + txtSellerCnic.Text + "' order by ProfileID desc")).ToString();
                }
                catch (Exception es)
                {
                    lblErrorMsg.Text = es.Message;
                }

            }
        }

        private void btnSaveBuyer_Click(object sender, EventArgs e)
        {
            try
            {
                lblErrorMsg.Text = "";
                if (txtBuyerCnic.Text == "")
                {
                    lblErrorMsg.Text = "Please Fill Buyer CNIC.";
                    return;
                }
                if (txtBuyerCnic.Text.Length != 13)
                {
                    lblErrorMsg.Text = "Please Enter Valid 13-Digit Buyer CNIC Number without dashes.";
                    return;
                }
                if (txtBuyerName.Text == "")
                {
                    lblErrorMsg.Text = "Please Fill Buyer Name.";
                    return;
                }
                if (txtBuyerAddress.Text == "")
                {
                    lblErrorMsg.Text = "Please Fill Buyer Address.";
                    return;
                }
                if (txtBuyerMobile.Text == "")
                {
                    lblErrorMsg.Text = "Please Enter Buyer Mobile Number.";
                    return;
                }
                if (lblBuyerProfileID.Text == "")
                {
                    int profileid = f.createNumber("SELECT ProfileID from Profile order by ProfileID desc");
                    f.Insert("insert into Profile(ProfileID,PName,Pcnic,PMobile,PAddress) values(" + profileid + ",'" + txtBuyerName.Text + "','" + txtBuyerCnic.Text + "','" + txtBuyerMobile.Text + "','" + txtBuyerAddress.Text + "')");
                    lblBuyerProfileID.Text = (f.findnumber("SELECT ProfileID from Profile where Pcnic='" + txtBuyerCnic.Text + "' order by ProfileID desc")).ToString();
                }
                else
                {
                    f.Update("update Profile set PName ='" + txtBuyerName.Text + "', Pcnic = '" + txtBuyerCnic.Text + "', PMobile = '" + txtSaleNumber.Text + "', PAddress = '" + txtBuyerName.Text + "' where ProfileID = " + lblBuyerProfileID.Text + "");
                }
            }
            catch (Exception s)
            {

                lblErrorMsg.Text = s.Message.ToString();
            }

        }

        private void btnCanceldeal_Click(object sender, EventArgs e)
        {
            try
            {
                lblErrorMsg.Text = "";
                DateTime dt = DateTime.Now;
                if (lblSellerprofileID.Text == "" && int.Parse(txtSaleNumber.Text) > 1)
                {
                    lblErrorMsg.Text = "Enter Seller Information.";
                    return;
                }
                if (lblBuyerProfileID.Text == "")
                {
                    lblErrorMsg.Text = "Enter Buyer Information.";
                    return;
                }
                bool isfounddeail = f.Selectbool("Select * from Deals where DealID=" + lblDealID.Text + " ");
                if (isfounddeail)
                {
                    int oldSaleNumber = f.findnumber("Select salenumber from Deals where ProjectID=" + txtProjectNumber.Text + " and PlotNumber=" + txtPlotnumber.Text + " and isfinal=1 ");
                    if (oldSaleNumber == 0)
                    {
                        f.Update("update PlotsList set isSold=0,isForSold=1,SaleNumber=1 , plotOwner=0 , IsIninstallment=0 where ProjectID=" + txtProjectNumber.Text + " and PlotNumber=" + txtPlotnumber.Text + "");
                    }
                    else
                    {
                        int plotowner = f.findnumber("Select buyerID from Deals where ProjectID=" + txtProjectNumber.Text + " and PlotNumber=" + txtPlotnumber.Text + " and salenumber=" + oldSaleNumber + " ");
                        int iscomplete = f.findnumber("Select isComplete from Deals where ProjectID=" + txtProjectNumber.Text + " and PlotNumber=" + txtPlotnumber.Text + " and salenumber=" + oldSaleNumber + " ");
                        if (iscomplete == 0)
                        {
                            iscomplete = 1;
                        }
                        else if (iscomplete == 1)
                        {
                            iscomplete = 0;
                        }

                        f.Update("update PlotsList set isSold=1,isForSold=0,SaleNumber=" + oldSaleNumber + " , plotOwner=" + plotowner + " , IsIninstallment=" + iscomplete + " where ProjectID=" + txtProjectNumber.Text + " and PlotNumber=" + txtPlotnumber.Text + "");
                    }
                    f.Update("update Deals set  buyerID=" + lblBuyerProfileID.Text + " , Rate=" + txtRateMrla.Text + " , TotalAmount = " + txtTotalAmount.Text + " , Advance = " + txtTotalAmount.Text + " , NumbofInstallments = " + txtNumberofInstallments.Text + " ,  dealDate='" + dt + "' ,issave=0 ,isfinal=0,isCancel=1 where DealID=" + lblDealID.Text + " ");
                    lblErrorMsg.Text = "Deal Cancelled.";
                }
                //else
                //{
                //    int isprojectsale = 1;
                //    if (txtSaleNumber.Text != "1")
                //    {
                //        isprojectsale = 0;
                //    }
                //    f.Insert("insert into Deals(DealID,ProjectID,PlotNumber,isProjectSale,issave,isfinal,isCancel,SalerID,buyerID,Rate,Area,TotalAmount,Advance,NumbofInstallments,Balance,SpNote) " +
                //             "values('" + lblDealID.Text + "','" + txtProjectNumber.Text + "'," + txtPlotnumber.Text + ",'" + isprojectsale + "',1,0,0,'" + lblprofileID.Text + "','" + lblBuyerProfileID.Text + "','" + txtRateMrla.Text + "','" + lblMultiplierArea.Text + "','" + txtTotalAmount.Text + "','" + txtAdvance.Text + "','" + txtNumberofInstallments.Text + "','" + txtBalance.Text + "','Note','" + dt + "')");
                //    lblErrorMsg.Text = "Deal Saved.";
                //}
            }
            catch (Exception es)
            {
                lblErrorMsg.Text = es.Message;
            }

        }

        private void btnDealfinal_Click(object sender, EventArgs e)
        {
            try
            {
                lblErrorMsg.Text = "";
                DateTime dt = DateTime.Now;
                //if (lblSellerprofileID.Text == "" && int.Parse(txtSaleNumber.Text) > 1)
                //{
                //    lblErrorMsg.Text = "Enter Seller Information.";
                //    return;
                //}
                if (lblBuyerProfileID.Text == "")
                {
                    lblErrorMsg.Text = "Enter Buyer Information.";
                    return;
                }
               
                //bool isfounddeail = f.Selectbool("Select * from Deals where DealID=" + lblDealID.Text + " ");
                //int iscomplete = 0;
                int forplotinstallment = 1;
                //if (int.Parse(txtBalance.Text) == 0)
                //{
                //    iscomplete = 1;
                //    forplotinstallment = 0;
                //}
                //if (int.Parse(txtNumberofInstallments.Text) == 0)
                //{
                //    lblErrorMsg.Text = "This deal is not good, Amount is in balance and no installment is selected.";
                //    return;
                //}
                //if (isfounddeail)
                //{
                //    f.Update("update PlotsList set isSold=1,isForSold=0,SaleNumber=" + txtSaleNumber.Text + " , plotOwner=" +
                //             lblBuyerProfileID.Text + ", IsIninstallment=" + forplotinstallment + " where ProjectID=" +
                //             txtProjectNumber.Text + " and PlotNumber=" + txtPlotnumber.Text + " ");
                //    f.Update("update Ledger set Credit=" + txtTotalAmount.Text + " ,Debit=0 , BalanceAmount='" + txtTotalAmount.Text + "' where ProjectID=" +
                //             txtProjectNumber.Text + " and PlotNumber = " + txtPlotnumber.Text + " and DealID=" + lblDealID.Text + " and isinstallment=0");
                //    if (lblSellerprofileID.Text == "")
                //    {
                //        f.Update("update Deals set buyerID=" + lblBuyerProfileID.Text +
                //                 " ,  Rate=" + txtRateMrla.Text + " , TotalAmount = " +
                //                 txtTotalAmount.Text + " , Advance = " + txtTotalAmount.Text + " , NumbofInstallments = " +
                //                 txtNumberofInstallments.Text + " ,dealDate='" + dt +
                //                 "',issave=0 ,isfinal=1,isCancel=0,isComplete=" + iscomplete + " where DealID=" +
                //                 lblDealID.Text + " ");
                //    }
                //    else
                //    {
                //        f.Update("update Deals set SalerID=" + lblSellerprofileID.Text + " , buyerID=" + lblBuyerProfileID.Text +
                //                " , Rate=" + txtRateMrla.Text + " , TotalAmount = " +
                //                txtTotalAmount.Text + " , Advance = " + txtTotalAmount.Text + " , NumbofInstallments = " +
                //                txtNumberofInstallments.Text + " , dealDate='" + dt +
                //                "',issave=0 ,isfinal=1,isCancel=0,isComplete=" + iscomplete + " where DealID=" +
                //                lblDealID.Text + " ");
                //    }
                //}
                //else
                {
                    //close previouse deal
                    int oldsale = int.Parse(txtSaleNumber.Text) - 1;
                    int olddealid = f.findnumber("select DealID from Deals where PlotNumber=" + txtPlotnumber.Text+ " and isComplete=0 and salenumber="+oldsale+" ");
                    if (olddealid != 0)
                    {

                        CloseDealfm cd = new CloseDealfm(olddealid,int.Parse(txtTotalAmount.Text),int.Parse(txtPaidAgentAmount.Text));
                        cd.ShowDialog();
                        if (cd.DialogResult!=DialogResult.OK)
                        {
                            return;
                        }
                    }
                    //
                    int isprojectsale = 1;
                    if (txtSaleNumber.Text != "1")
                    {
                        isprojectsale = 0;
                    }
                    //update plot
                    f.Update("update PlotsList set isSold=1,isForSold=0,SaleNumber=" + txtSaleNumber.Text + " , plotOwner=" +
                             lblBuyerProfileID.Text + ", IsIninstallment=" + forplotinstallment + " where ProjectID=" +
                             txtProjectNumber.Text + " and PlotNumber=" + txtPlotnumber.Text + " ");
                    //inser into ledger
                    f.Insert("insert into Ledger(DealID,ProjectID,PlotNumber,SaleNumber,ProfileID,Debit,Credit,InstallmentNumber,RecordDate,isinstallment,Remarks,isPlotsold) " +
                      "values('" + lblDealID.Text + "','" + txtProjectNumber.Text + "'," + txtPlotnumber.Text + ",'" + txtSaleNumber.Text + "','" + lblBuyerProfileID.Text + "','" + txtTotalAmount.Text + "',0,0,'" + dt + "',0,'Purchase Plot',1)");
                    //insert into deal
                    f.Insert(
                           "insert into Deals(DealID,ProjectID,PlotNumber,isProjectSale,salenumber,issave,isfinal,isCancel,SalerID,buyerID,AgentID,AgentCommission,Rate,Area,TotalAmount,NumbofInstallments,SpNote,dealDate) " +
                           "values(" + lblDealID.Text + "," + txtProjectNumber.Text + "," + txtPlotnumber.Text + "," +
                           isprojectsale + "," + txtSaleNumber.Text + ",0,1,0," + lblSellerprofileID.Text + "," +
                           lblBuyerProfileID.Text + ",'"+lblAgentProfileID.Text+"','"+txtPaidAgentAmount.Text+"'," + txtRateMrla.Text + "," + lblMultiplierArea.Text + ", '" + txtTotalAmount.Text + "','" + txtNumberofInstallments.Text + "'," +
                            "'Note','" + dt + "')");
                    //insert commission Debit
                    f.Insert("insert into Ledger(DealID,ProjectID,PlotNumber,SaleNumber,ProfileID,Debit,Credit,InstallmentNumber,RecordDate,isinstallment,Remarks,isPlotsold,isSellerComm) " +
                       "values('" + lblDealID.Text + "','" + txtProjectNumber.Text + "'," + txtPlotnumber.Text + ",'" + txtSaleNumber.Text + "','" + lblSellerprofileID.Text + "','" + txtPaidAgentAmount.Text + "',0,0,'" + dt + "',0,'Sale Plot Commission',0,1)");
                    //insert Agent credit
                    f.Insert("insert into Ledger(DealID,ProjectID,PlotNumber,SaleNumber,ProfileID,Debit,Credit,InstallmentNumber,RecordDate,isinstallment,Remarks,isPlotsold,isagentPayment) " +
                       "values('" + lblDealID.Text + "','" + txtProjectNumber.Text + "'," + txtPlotnumber.Text + ",'" + txtSaleNumber.Text + "','" + lblAgentProfileID.Text + "',0,'" + txtPaidAgentAmount.Text + "',0,'" + dt + "',0,'Agent Commission',0,1)");
                }
                loadPaidIntallments();
                lblErrorMsg.Text = "Deal Finalized.";
                grpboxInstallment.Enabled = true;
                btnDealfinal.Enabled = false;
            }
            catch (Exception es)
            {
                lblErrorMsg.Text = es.Message;
            }

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void txtAgentCnic_TextChanged(object sender, EventArgs e)
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
                    btnSaveAgent.Enabled = false;
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

        private void txtAgentCnic_KeyDown(object sender, KeyEventArgs e)
        {
            lblErrorMsg.Text = "";

            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (lblAgentProfileID.Text == "")
                {
                    comboCommProfit.Focus();
                }
                else
                {
                    txtAgentName.Focus();
                }

            }
           // e.SuppressKeyPress = true;
        }

        private void txtAgentCnic_KeyPress(object sender, KeyPressEventArgs e)
        {
            lblErrorMsg.Text = "";

            base.OnKeyPress(e);
            if (e.KeyChar != (char)8 && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtAgentName_KeyDown(object sender, KeyEventArgs e)
        {
            lblErrorMsg.Text = "";

            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtAgentMobile.Focus();
            }
           // e.SuppressKeyPress = true;
        }

        private void txtAgentMobile_KeyDown(object sender, KeyEventArgs e)
        {
            lblErrorMsg.Text = "";

            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtAgentAddress.Focus();
            }
           // e.SuppressKeyPress = true;
        }

        private void txtAgentAddress_KeyDown(object sender, KeyEventArgs e)
        {
            lblErrorMsg.Text = "";

            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                comboCommProfit.Focus();
            }
           // e.SuppressKeyPress = true;
        }

        private void txtTotalAmount_TextChanged(object sender, EventArgs e)
        {
            lblErrorMsg.Text = "";
            try
            {
                if (txtTotalAmount.Text != "")
                {
                    if (keydownflag == 0)
                    {
                        return;
                    }
                    keydownflag = 0;
                    if (txtArea.Text != "")
                    {
                        lblMultiplierArea.Text = txtArea.Text;
                    }
                    if (txtTotalAmount.Text != "" && lblMultiplierArea.Text != "")
                    {
                        float area = float.Parse(lblMultiplierArea.Text);
                        int am = int.Parse(txtTotalAmount.Text);
                        txtRateMrla.Text = (Math.Round((area / am), 0)).ToString();
                    }
                    else
                    {
                        txtRateMrla.Text = "";
                    }
                }
                else
                {
                    txtRateMrla.Text = "";
                }
            }
            catch (Exception es)
            {
                lblErrorMsg.Text = es.Message;
            }
            finally
            {
                txtAdvance_TextChanged(sender, e);
            }


        }

        private void txtAdvance_TextChanged(object sender, EventArgs e)
        {
            //lblErrorMsg.Text = "";
            //if (txtAdvance.Text != "")
            //{
            //    double total = double.Parse(txtTotalAmount.Text);
            //    double Advanc = double.Parse(txtAdvance.Text);
            //    total = Math.Round(total, 0);
            //    Advanc = Math.Round(Advanc, 0);
            //    if (total > Advanc)
            //    {
            //        txtBalance.Text = (total - Advanc).ToString();
            //        countIntallments();
            //    }
            //    else
            //    {
            //        lblErrorMsg.Text = "Advance Amount is Greater then Total Amount.";
            //        txtBalance.Text = (total - Advanc).ToString();
            //        gridInstallmentsList.Rows.Clear();
            //    }
            //}
            //else
            //{
            //    txtBalance.Text = "";
            //}
        }

        private void countIntallments()
        {

            gridInstallmentsList.Rows.Clear();
            //if (txtNumberofInstallments.Text != "" && txtAdvance.Text != "" && txtBalance.Text != "")
            if (txtNumberofInstallments.Text != ""  && txtTotalAmount.Text != "")
            {

                int numbofinstal = int.Parse(txtNumberofInstallments.Text);
                int blance = int.Parse(txtTotalAmount.Text); //change txtadvance to txtTotalAmount
                int count = numbofinstal;
                for (int i = 1; i <= numbofinstal; i++)
                {
                    int first = blance / count;
                    gridInstallmentsList.Rows.Add(i + "-" + first);
                    blance -= first;
                    count -= 1;
                }
            }
        }

        private void txtNumberofInstallments_TextChanged(object sender, EventArgs e)
        {
            countIntallments();
        }

        private void txtBalance_TextChanged(object sender, EventArgs e)
        {
            countIntallments();
        }

        private void gridProfile_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gridProfile_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtAgentCnic.Text = (gridProfile.Rows[e.RowIndex].Cells[1].Value.ToString());
                comboCommProfit.Text = (gridProfile.Rows[e.RowIndex].Cells[3].Value.ToString());
            }
        }

        private void txtPaidAgentComm_TextChanged(object sender, EventArgs e)
        {

            //if (txtPaidAgentComm.Text!="")
            //{
            //    string commission = comboCommProfit.Text;
            //    commission = commission.Replace(@"%", "");
            //    int perc = int.Parse(commission);
            //    int totalamount = int.Parse(txtTotalAmount.Text);
            //    float commamount=(totalamount/100)*perc;
            //    txtPaidAgentAmount.Text = (Math.Round(commamount)).ToString();
            //}
        }

        private void btnAgentPaid_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboCommProfit.Text != "" && txtPaidAgentAmount.Text != "" && lblAgentProfileID.Text != "")
                {
                    DateTime dt = DateTime.Now;
                    f.Update("update Agents set paidDate='" + dt + "', paidAmount=" + txtPaidAgentAmount.Text + " where DealID=" + lblDealID.Text + " ");
                    f.Insert("insert into Ledger(DealID,ProjectID,PlotNumber,SaleNumber,ProfileID,Debit,Credit,BalanceAmount,RecordDate,isagentPayment,Remarks) " +
                            "values('" + lblDealID.Text + "','" + txtProjectNumber.Text + "'," + txtPlotnumber.Text + ",'" + txtSaleNumber.Text + "','" + lblAgentProfileID.Text + "',0," + txtPaidAgentAmount.Text + ",0,'" + dt + "',1,'Paid to Agent')");
                    lblErrorMsg.Text = "Paid.";
                    //btnAgentPaid.Visible = false;
                    loadgridprofile();
                }
            }
            catch (Exception es)
            {
                lblErrorMsg.Text = es.Message;
            }

        }

        private void btnPaidInstallment_Click(object sender, EventArgs e)
        {
            lblErrorMsg.Text = "";
            try
            {
                DateTime dt = dtPaidInstallment.Value;
                if (txtInstallCurrentPaid.Text != "")
                {
                    f.Insert("insert into Ledger(DealID,ProjectID,PlotNumber,SaleNumber,InstallmentNumber,ProfileID,Debit,Credit,RecordDate,isinstallment,Remarks,isPlotsold) " +
                      "values('" + lblDealID.Text + "','" + txtProjectNumber.Text + "'," + txtPlotnumber.Text + ",'" + txtSaleNumber.Text + "','" + lblCurrentInstallmntNumb.Text + "','" + lblBuyerProfileID.Text + "',0," + txtInstallCurrentPaid.Text + ",'" + dt + "',1,'Installment',1)");
                }
                //print slip
                if (chkPrintorNot.Checked)
                {
                    int Billnumber = f.findnumber("select LedgerID   from Ledger where DealID=" + lblDealID.Text + " and isinstallment=1 order by LedgerID desc");
                    int sumPaidInstallments = f.findnumber("select sum(Debit)   from Ledger where DealID=" + lblDealID.Text + " and isinstallment=1 and InstallmentNumber>0 ");
                    InstallmentSlip cr = new InstallmentSlip();
                    string dat = dt.ToString("dd-MM-yyyy");
                    TextObject txtprjName1 = (TextObject)cr.ReportDefinition.Sections["Section1"].ReportObjects["txtprjName"];
                    txtprjName1.Text = txtProjName.Text;
                    TextObject txtprjAddress = (TextObject)cr.ReportDefinition.Sections["Section1"].ReportObjects["txtprjAddress"];
                    string add = f.findName("select PAddress from Profile where ProfileID=0");
                    txtprjAddress.Text = add.ToUpper();
                    TextObject date = (TextObject)cr.ReportDefinition.Sections["Section2"].ReportObjects["txtDate"];
                    date.Text = dat;
                    TextObject billnumber = (TextObject)cr.ReportDefinition.Sections["Section2"].ReportObjects["txtReceiptNumbe"];
                    billnumber.Text = Billnumber.ToString(); //find
                    TextObject custname = (TextObject)cr.ReportDefinition.Sections["Section2"].ReportObjects["txtPayername"];
                    custname.Text = txtBuyerName.Text;
                    TextObject cnic = (TextObject)cr.ReportDefinition.Sections["Section2"].ReportObjects["txtcniC"];
                    cnic.Text = txtBuyerCnic.Text;
                    TextObject recievedamount = (TextObject)cr.ReportDefinition.Sections["Section2"].ReportObjects["txtReceivedAmount"];
                    recievedamount.Text = txtInstallCurrentPaid.Text;
                    TextObject plotnumb = (TextObject)cr.ReportDefinition.Sections["Section2"].ReportObjects["txtPlotNumb"];
                    plotnumb.Text = txt_p_s_name.Text;
                    TextObject totalAmount = (TextObject)cr.ReportDefinition.Sections["Section2"].ReportObjects["txttotalAmount"];
                    totalAmount.Text = txtTotalAmount.Text;
                    //TextObject txtAdvance1 = (TextObject)cr.ReportDefinition.Sections["Section2"].ReportObjects["txtAdvance"];
                    //txtAdvance1.Text = txtAdvance.Text;
                    TextObject txtPaidinInstallment = (TextObject)cr.ReportDefinition.Sections["Section2"].ReportObjects["txtPaidinInstallment"];
                    txtPaidinInstallment.Text = sumPaidInstallments.ToString();
                    TextObject txtBalanceAmount = (TextObject)cr.ReportDefinition.Sections["Section2"].ReportObjects["txtBalanceAmount"];
                    txtBalanceAmount.Text = txtinstallmentRemainig.Text;
                    cr.PrintToPrinter(1, false, 0, 0);
                }
                //slip end
                if (int.Parse(txtinstallmentRemainig.Text) == 0 || txtinstallmentRemainig.Text == "")
                {
                    f.Update("update PlotsList set isSold=1 , IsIninstallment=0 where ProjectID=" + txtProjectNumber.Text + " and PlotNumber=" + txtPlotnumber.Text + " ");
                    f.Update("update Deals set isComplete=1 where DealID=" + lblDealID.Text + "");
                    //txtInstallCurrentPaid.Text = "0";
                    lblCurrentInstallmntNumb.Text = "";
                    btnPaidInstallment.Enabled = false;
                    lblErrorMsg.Text = "All installments Paid, This deal is Completed.";
                }
                countPaidInstallments = -1;
                loadPaidIntallments();
                findPendingInstall();
            }
            catch (Exception es)
            {
                lblErrorMsg.Text = es.Message;
            }

        }

        int countPaidInstallments = -1;
        private void loadPaidIntallments()
        {
            tbl_Installment.Rows.Clear();
            gridPendingINstallments.Rows.Clear();
            int TotalAmount = f.findnumber("select top 1 Debit   from Ledger where DealID=" + lblDealID.Text + " and isPlotsold=1 and isinstallment=0 order by InstallmentNumber desc");
            string str = "select InstallmentNumber,Credit,RecordDate   from Ledger where DealID=" + lblDealID.Text + " and isPlotsold=1 and isagentPayment=0 order by InstallmentNumber desc";
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
                sumbalance = TotalAmount-(int.Parse( dr["Credit"].ToString()));
                drow1[3] = sumbalance.ToString();
                //string gridrow = dr["InstallmentNumber"]+"-"+ dr["Debit"] +"-->>"+ dr["BalanceAmount"];
                tbl_Installment.Rows.Add(drow1);
                countPaidInstallments += 1;
            }
            //int balanceamount = f.findnumber("select top 1 BalanceAmount   from Ledger where DealID=" + lblDealID.Text + " and isPlotsold=1 and isagentPayment=0  order by InstallmentNumber desc");
            int paidamount =
                f.findnumber("select sum(Credit) as Cr from ledger  where DealID=" + lblDealID.Text +
                             " and isPlotsold=1");
            txtInstalmntsBalance.Text =( int.Parse(txtTotalAmount.Text)-paidamount).ToString();
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
            int pendinginstall = int.Parse(txtNumberofInstallments.Text) - (countPaidInstallments + 1);
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

        private void txtInstallCurrentPaid_TextChanged(object sender, EventArgs e)
        {
            try
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
                        txtInstallCurrentPaid.Text = "";
                }
                findPendingInstall();
            }
            else
            {
                txtinstallmentRemainig.Text = "0";
            }
            }
            catch(Exception es)
            {
                MessageBox.Show(es.Message);
                txtInstallCurrentPaid.Text = "";
            }
            
        }

        private void txtinstallmentRemainig_TextChanged(object sender, EventArgs e)
        {
            if (txtinstallmentRemainig.Text == "")
            {
                txtinstallmentRemainig.Text = "0";
            }
        }

        private void grpboxInstallment_EnabledChanged(object sender, EventArgs e)
        {
            if (grpboxInstallment.Enabled)
            {

            }
        }

        private void txtSaleNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (e.KeyChar != (char)8 && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtInstalmntsBalance_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnModifyDeal_Click(object sender, EventArgs e)
        {

        }

        private void btnModify_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblAgentProfileID.Text != "")
                {
                    f.Delete("delete Agents where AgentID=" + lblAgentProfileID.Text + " and ProjectID=" + txtProjectNumber.Text + " and PlotNumber=" + txtPlotnumber.Text + " and DealID=" + lblDealID.Text + " ");
                    f.Delete("delete Ledger where isagentPayment=1 and ProfileID=" + lblAgentProfileID.Text + " and ProjectID=" + txtProjectNumber.Text + " and PlotNumber=" + txtPlotnumber.Text + " and DealID=" + lblDealID.Text + " ");
                }
            }
            catch (Exception es)
            {
                lblErrorMsg.Text = es.Message;
            }

        }

        private void txtPlotnumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }
    }
}
