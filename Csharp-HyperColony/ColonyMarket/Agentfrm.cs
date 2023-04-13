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

namespace ColonyMarket
{
    public partial class Agentfrm : Form
    {
        OleDbConnection olecon = new OleDbConnection(ConfigurationManager.ConnectionStrings["Accdbx"].ConnectionString);
        functions f = new functions();
        public Agentfrm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Agentfrm_Load(object sender, EventArgs e)
        {
            loadGridagent();
        }
        private void loadGridagent()
        {
            try
            {
                if (olecon.State != ConnectionState.Open)
                {
                    olecon.Open();
                }

                OleDbCommand cmd3 = olecon.CreateCommand();
                cmd3.CommandType = CommandType.Text;
                string str =
                    "Select DISTINCT  d.ProfileID,PName,Pcnic,PMobile,PAddress from Agents d inner join Profile p on p.ProfileID=d.ProfileID  ";
                cmd3.CommandText = str;
                cmd3.ExecuteNonQuery();
                OleDbDataAdapter da3 = new OleDbDataAdapter(cmd3);
                DataSet ds = new DataSet();
                da3.Fill(ds);
                if (olecon.State != ConnectionState.Closed)
                {
                    olecon.Close();
                }
                gridAgents.AutoGenerateColumns = false;
                gridAgents.DataSource = ds.Tables[0].DefaultView;
            }
            catch (Exception es)
            {
                txtErrorMsg.Text = "Error: " + es.Message;
            }
        }

        private void gridAgents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblpaidstatus.Text = "";
            string ispaidAgent = "";
            int profileid;
            if (e.RowIndex >= 0)
            {
                profileid= int.Parse (gridAgents.Rows[e.RowIndex].Cells[0].Value.ToString());
                lblprofileid.Text = profileid.ToString();
                txtAgentName.Text = gridAgents.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtAgentMobile.Text = gridAgents.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtAgentAddress.Text = gridAgents.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtAgentCnic.Text = gridAgents.Rows[e.RowIndex].Cells[1].Value.ToString();
                loadGridagentLedger(profileid);
            }
            
        }

        private void loadGridagentLedger(int profileid)
        {
            try
            {
                if (olecon.State != ConnectionState.Open)
                {
                    olecon.Open();
                }

                OleDbCommand cmd3 = olecon.CreateCommand();
                cmd3.CommandType = CommandType.Text;
                string str = "Select RecordDate,DealID,p_s_name as Plot,l.SaleNumber,Credit as Payable,Debit as Paid,BalanceAmount,Remarks from Ledger l left join PlotsList p on l.PlotNumber=p.PlotNumber where L.ProfileID=" + profileid+ " and isagentPayment=1 order by L.RecordDate desc  ";
                cmd3.CommandText = str;
                cmd3.ExecuteNonQuery();
                OleDbDataAdapter da3 = new OleDbDataAdapter(cmd3);
                DataSet ds = new DataSet();
                da3.Fill(ds);
                if (olecon.State != ConnectionState.Closed)
                {
                    olecon.Close();
                }
                gridLedgerAgent.AutoGenerateColumns = false;
                gridLedgerAgent.DataSource = ds.Tables[0].DefaultView;

                int debit = 0;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    debit += int.Parse(dr["Payable"].ToString());
                }
                int credit = 0;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    credit += int.Parse(dr["Paid"].ToString());
                }

                txtdebit.Text = debit.ToString();
                txtcredit.Text = credit.ToString();
                txtBalance.Text = (debit- credit).ToString();
            }
            catch (Exception es)
            {
                txtErrorMsg.Text = "Error: " + es.Message;
            }
        }

        private void btnPaid_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtBalance.Text != "" && txtcredit.Text != "" && txtdebit.Text != "")
                {
                    DateTime dt = DateTime.Now;
                    //f.Update("update Agents set paidDate='" + dt + "', paidAmount=" + txtPaidAgentAmount.Text + " where DealID=" + lblDealID.Text + " ");
                    f.Insert("insert into Ledger(ProjectID,ProfileID,Debit,Credit,RecordDate,isagentPayment,Remarks) " +
                            "values(1,'" + lblprofileid.Text + "','" + txtPaid.Text + "',0,'" + dt + "',1,'Paid to Agent')");
                    lblpaidstatus.Text = "Paid.";
                    txtPaid.Text = "";
                    loadGridagentLedger(int.Parse(lblprofileid.Text));
                }
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }

        }

        private void txtBalance_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
