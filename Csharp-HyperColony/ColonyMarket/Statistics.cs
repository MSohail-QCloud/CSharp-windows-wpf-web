using ColonyMarket.classes;
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
using ColonyMarket.Reports;

namespace ColonyMarket
{
    public partial class Statistics : Form
    {
        OleDbConnection olecon = new OleDbConnection(ConfigurationManager.ConnectionStrings["Accdbx"].ConnectionString);
        functions f = new functions();

        public Statistics(int projid)
        {
            InitializeComponent();
            ProjID = projid;
        }

        private void Statistics_Load(object sender, EventArgs e)
        {
            txtPropertyAmount.Text = f.findnumber("select Price from Projects where ProjectID=" + ProjID + "").ToString();
            loadGridSales();
            loadGridExpense();
            loadGridInvestment();
            loadGridPaidOwner();
            LoadGridAgentsPay();
            loadComboDevCompany();
            int result = (int.Parse(txtTotalInvestment.Text) + int.Parse(txtAmountRecieved.Text)) -
                         (int.Parse(txtpropertybalanc1.Text) + int.Parse(txtTotalExpense.Text) +
                          int.Parse(txtagentpaid.Text));
            textBox1.Text = result.ToString();
        }
        public int ProjID { get; set; }
        
        private void loadGridSales()
        {
            try
            {
                int recievedamount = 0;
                int recieveableamount = 0;
                if (olecon.State != ConnectionState.Open)
                {
                    olecon.Open();
                }

                OleDbCommand cmd3 = olecon.CreateCommand();
                cmd3.CommandType = CommandType.Text;
                string str =
                    "select p_s_name as Plot,sum(Debit) as Recieved,sum(Credit) as Pending from Ledger l inner join PlotsList p on l.PlotNumber=p.PlotNumber  where l.ProjectID = " + ProjID + " and l.SaleNumber = 1 GROUP BY p.p_s_name ";
                cmd3.CommandText = str;
                cmd3.ExecuteNonQuery();
                OleDbDataAdapter da3 = new OleDbDataAdapter(cmd3);
                DataSet ds = new DataSet();
                da3.Fill(ds);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    recievedamount += int.Parse(dr["Recieved"].ToString());
                    recieveableamount += int.Parse(dr["Pending"].ToString());
                }
                if (olecon.State != ConnectionState.Closed)
                {
                    olecon.Close();
                }
                //gridSales.AutoGenerateColumns = false;
                gridSales.DataSource = ds.Tables[0].DefaultView;
                txtgridSaleRecievedamount.Text = recievedamount.ToString();
                txtgridsaleRecievableamount.Text = recieveableamount.ToString();
            }
            catch (Exception es)
            {
               lblErrorMsg.Text = "Error: " + es.Message;
            }
        }

        private void loadGridExpense()
        {
            try
            {
                int totalExpenses = 0;
                if (olecon.State != ConnectionState.Open)
                {
                    olecon.Open();
                }

                OleDbCommand cmd3 = olecon.CreateCommand();
                cmd3.CommandType = CommandType.Text;
                string str =
                    "select l.RecordDate as Paid_Date,ed.CatagoryName as Expense,l.ExpenseDetail as Detail,l.Debit as Amount from  " +
                    "Ledger l inner  join  expenseCatagory ed on ed.CatagoryID = l.CatagoryID where l.ProjectID = " + ProjID + " and  l.isexpenses=1 and isPropertyOwner=0";
                cmd3.CommandText = str;
                cmd3.ExecuteNonQuery();
                OleDbDataAdapter da3 = new OleDbDataAdapter(cmd3);
                DataSet ds = new DataSet();
                da3.Fill(ds);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    totalExpenses += int.Parse(dr["Amount"].ToString());
                }
                if (olecon.State != ConnectionState.Closed)
                {
                    olecon.Close();
                }
                txtgridExpenseTotalExpense.Text = totalExpenses.ToString();
                //gridExpenses.AutoGenerateColumns = false;
                gridExpenses.DataSource = ds.Tables[0].DefaultView;
            }
            catch (Exception es)
            {
                lblErrorMsg.Text = "Error: " + es.Message;
            }
        }

        private void loadGridInvestment()
        {
            try
            {
                if (olecon.State != ConnectionState.Open)
                {
                    olecon.Open();
                }
                int totalInvestment = 0;
                OleDbCommand cmd3 = olecon.CreateCommand();
                cmd3.CommandType = CommandType.Text;
                //string str =
                //    "select PlotNumber,sum(Debit) as Recieved,sum(Credit) as Pending from Ledger where ProjectID = " + ProjID + " and SaleNumber = 1 GROUP BY PlotNumber ";
                string str= "select l.RecordDate as Paid_Date ,p.PName as Employee_Name,l.Credit as Investment,l.ExpenseDetail as Detail from Ledger l inner join Profile p on p.ProfileID = l.ProfileID where l.ProjectID = 1 and isinvestment = 1";
                //string str = "select l.RecordDate as Paid_Date,d.CompanyName as Company,l.ExpenseDetail as Detail,l.Credit as Investment,p.PName as Employee_Name " +
                //             "from  ((Ledger l inner  join  Developers d on d.ProfileID = l.ProfileID) " +
                //             "inner join EmployeeSallary s on L.LedgerID = s.LedgerID)" +
                //             "inner join Profile p  on p.ProfileID = s.ProfileID where l.ProjectID = " + ProjID + " and  isinvestment=1";
                //"select f.CompanyName, from Developers f inner join EmployeeSallary o on o.ProfileID = f.ProfileID where o.ProjectID = " +
                //ProjID + "";
                cmd3.CommandText = str;
                cmd3.ExecuteNonQuery();
                OleDbDataAdapter da3 = new OleDbDataAdapter(cmd3);
                DataSet ds = new DataSet();
                da3.Fill(ds);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    totalInvestment += int.Parse(dr["Investment"].ToString());
                }
                if (olecon.State != ConnectionState.Closed)
                {
                    olecon.Close();
                }
                txtgridInvestmentTotalInvestment.Text = totalInvestment.ToString();
                //gridExpenses.AutoGenerateColumns = false;
                gridInvestment.DataSource = ds.Tables[0].DefaultView;
            }
            catch (Exception es)
            {
                lblErrorMsg.Text = "Error: " + es.Message;
            }
        }

        private void loadGridPaidOwner()
        {
            try
            {
                if (olecon.State != ConnectionState.Open)
                {
                    olecon.Open();
                }
                int totalPaid = 0;
                OleDbCommand cmd3 = olecon.CreateCommand();
                cmd3.CommandType = CommandType.Text;
                string str =
                    "select l.RecordDate as Paid_Date,ed.CatagoryName as Expense,l.ExpenseDetail as Detail ,l.Debit as Paid from Ledger l " +
                    "inner  join  expenseCatagory ed on ed.CatagoryID = l.CatagoryID  where l.ProjectID = "+ProjID+ " and  isexpenses=1 and isPropertyOwner=1";
                cmd3.CommandText = str;
                cmd3.ExecuteNonQuery();
                OleDbDataAdapter da3 = new OleDbDataAdapter(cmd3);
                DataSet ds = new DataSet();
                da3.Fill(ds);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    totalPaid += int.Parse(dr["Paid"].ToString());
                }
                if (olecon.State != ConnectionState.Closed)
                {
                    olecon.Close();
                }
                txtgridPaidownerTotalPaid.Text = totalPaid.ToString();
                //gridExpenses.AutoGenerateColumns = false;
                gridOwnderPaid.DataSource = ds.Tables[0].DefaultView;
            }
            catch (Exception es)
            {
                lblErrorMsg.Text = "Error: " + es.Message;
            }
        }
        private void LoadGridAgentsPay()
        {
            try
            {
                if (olecon.State != ConnectionState.Open)
                {
                    olecon.Open();
                }
                int totalagentpadi = 0;
                OleDbCommand cmd3 = olecon.CreateCommand();
                cmd3.CommandType = CommandType.Text;
                string str =
                   "select l.RecordDate as Paid_Date,p.PName,p.Pcnic,l.Debit as Paid from Ledger l inner  join  Profile p on p.ProfileID=l.ProfileID  where l.ProjectID = " + ProjID + " and Debit > 0 and  l.isagentPayment=1";
                cmd3.CommandText = str;
                cmd3.ExecuteNonQuery();
                OleDbDataAdapter da3 = new OleDbDataAdapter(cmd3);
                DataSet ds = new DataSet();
                da3.Fill(ds);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    totalagentpadi += int.Parse(dr["Paid"].ToString());
                }
                if (olecon.State != ConnectionState.Closed)
                {
                    olecon.Close();
                }
                txtgridAgentPaid.Text = totalagentpadi.ToString();
                //gridExpenses.AutoGenerateColumns = false;
                griidAgentsPayment.DataSource = ds.Tables[0].DefaultView;
            }
            catch (Exception es)
            {
                lblErrorMsg.Text = "Error: " + es.Message;
            }
        }

        private void txtgridSaleRecievedamount_TextChanged(object sender, EventArgs e)
        {
            txtAmountRecieved.Text = txtgridSaleRecievedamount.Text;
        }

        private void txtgridExpenseTotalExpense_TextChanged(object sender, EventArgs e)
        {
            txtTotalExpense.Text = txtgridExpenseTotalExpense.Text;
        }

        private void txtgridSalleryTotalSallery_TextChanged(object sender, EventArgs e)
        {
            txtTotalInvestment.Text = txtgridInvestmentTotalInvestment.Text;

        }

        private void txtgridPaidownerTotalPaid_TextChanged(object sender, EventArgs e)
        {
            if (txtgridPaidownerTotalPaid.Text!="" && txtPropertyAmount.Text!="")
            {
                txtPropertyBalanceAmount.Text = ((int.Parse(txtgridPaidownerTotalPaid.Text) -(int.Parse(txtPropertyAmount.Text))).ToString());
            }
            
        }

        private void txtgridAgentPaid_TextChanged(object sender, EventArgs e)
        {
            txtagentpaid.Text = txtgridAgentPaid.Text;
        }

        private void btnPrintExpesnse_Click(object sender, EventArgs e)
        {
            StatPrintExpenses spe=new StatPrintExpenses();
            spe.Show();
                 
        }

        private void btnaddInvestment_Click(object sender, EventArgs e)
        {
            if (txtAddinvestmentAmount.Text != "")
            {
                DateTime dt1=DateTime.Now;
                string dt = dt1.ToString("dd-MM-yyyy");
                f.Insert("insert into Ledger(ProjectID,ProfileID,Credit,RecordDate,isexpenses,isinvestment,Remarks,ExpenseDetail) " +
                 "values('" + "1" + "'," + lblinversteridforInvestment.Text + ",'" + txtAddinvestmentAmount.Text + "','" + dt + "',0,1,'Investment','"+txtInvestmentExpenseDetail.Text+"')");
                txtAddinvestmentAmount.Text = "";
                txtInvestmentExpenseDetail.Text = "";
            }
            loadGridInvestment();

        }

        private void comboDevComapny_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string str =
                    "select f.ProfileID,Pcnic , f.PName from Profile f inner join Developers o on o.ProfileID = f.ProfileID where f.PName = '" + comboDevComapny.Text + "'";
                DataSet ds = f.Select(str);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lblinversteridforInvestment.Text = (dr["ProfileID"].ToString());
                    //lblgrpExpenseOwnerName.Text = (dr["PName"].ToString());
                    //lblgrpExpenseDevCnic.Text = (dr["Pcnic"].ToString());
                }
            }
            catch (Exception se)
            {
                MessageBox.Show(se.Message);
            }
        }

        private void loadComboDevCompany()
        {
            comboDevComapny.Items.Clear();
            DataSet ds = f.Select("select f.ProfileID , f.PName from Profile f inner join Developers o on o.ProfileID = f.ProfileID order by CompanyName ");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                comboDevComapny.Items.Add(dr["PName"].ToString());
            }
        }

        private void tbOwnerPaid_Click(object sender, EventArgs e)
        {

        }

        private void txtPropertyBalanceAmount_TextChanged(object sender, EventArgs e)
        {
            txtpropertybalanc1.Text = txtPropertyAmount.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int result = (int.Parse(txtTotalInvestment.Text) + int.Parse(txtAmountRecieved.Text)) -
                         (int.Parse(txtpropertybalanc1.Text) + int.Parse(txtTotalExpense.Text) +
                          int.Parse(txtagentpaid.Text));
            textBox1.Text = result.ToString();
        }
    }
}
