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
    public partial class Ledger : Form
    {
        OleDbConnection olecon = new OleDbConnection(ConfigurationManager.ConnectionStrings["Accdbx"].ConnectionString);
        functions f = new functions();
        public Ledger()
        {
            InitializeComponent();
        }

        private void Ledger_Load(object sender, EventArgs e)
        {
            //loadGridAll();
        }
        private void loadGridAll(string str)
        {
            try
            {
                if (olecon.State != ConnectionState.Open)
                {
                    olecon.Open();
                }

                OleDbCommand cmd3 = olecon.CreateCommand();
                cmd3.CommandType = CommandType.Text;
               // string str ="Select ProfileID,PName,Pcnic,PMobile,PAddress from Profile order by ProfileID";
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
            string ispaidAgent = "";
            int profileid;
            if (e.RowIndex >= 0)
            {
                profileid = int.Parse(gridAgents.Rows[e.RowIndex].Cells[0].Value.ToString());
                lblName.Text = (gridAgents.Rows[e.RowIndex].Cells[2].Value.ToString());
                lblMobile.Text = (gridAgents.Rows[e.RowIndex].Cells[3].Value.ToString());
                loadGridLedgerAll(profileid);
            }
        }
        private void loadGridLedgerAll(int profileid)
        {
            try
            {
                int paid = 0;
                int total = 0;
                
                if (olecon.State != ConnectionState.Open)
                {
                    olecon.Open();
                }

                OleDbCommand cmd3 = olecon.CreateCommand();
                cmd3.CommandType = CommandType.Text;
                string str = "Select l.RecordDate,l.DealID,l.PlotNumber,l.SaleNumber,Debit,Credit,Remarks,p_s_name from Ledger l inner join PlotsList p on l.PlotNumber= p.PlotNumber where l.ProfileID=" + profileid + " order by l.RecordDate desc  ";
                cmd3.CommandText = str;
                cmd3.ExecuteNonQuery();
                OleDbDataAdapter da3 = new OleDbDataAdapter(cmd3);
                DataSet ds = new DataSet();
                da3.Fill(ds);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    paid += int.Parse(dr["Debit"].ToString());
                    total += int.Parse(dr["Credit"].ToString());
                }
                if (olecon.State != ConnectionState.Closed)
                {
                    olecon.Close();
                }
                gridLedgerAgent.AutoGenerateColumns = false;
                gridLedgerAgent.DataSource = ds.Tables[0].DefaultView;
                txtPaidAmount.Text = paid.ToString();
                txtTotalAmount.Text = total.ToString();
                txtBalanceAmount.Text = (total - paid).ToString();

            }
            catch (Exception es)
            {
                txtErrorMsg.Text = "Error: " + es.Message;
            }
        }

        private void btnLoadCustomers_Click(object sender, EventArgs e)
        {
            string s = "select Distinct l.ProfileID,PName,PMobile,Pcnic,PAddress from ledger l inner join profile p on p.ProfileID=l.ProfileID  where isPlotsold=1";
            loadGridAll(s);
        }

        private void btnLoadAgents_Click(object sender, EventArgs e)
        {
            string s = "select Distinct l.ProfileID,PName,PMobile,Pcnic,PAddress from Ledger l inner join profile p on p.ProfileID=l.ProfileID  where isagentPayment=1";
            loadGridAll(s);
        }

        private void gridLedgerAgent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
