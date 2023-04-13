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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace lasticecream
{
    public partial class ParamatereReportFm : Form
    {
        OleDbConnection olecon = new OleDbConnection(ConfigurationManager.ConnectionStrings["Accdbx"].ConnectionString);
        private static ParamatereReportFm alreadyOpened = null;
        public ParamatereReportFm()
        {
            if (alreadyOpened != null && !alreadyOpened.IsDisposed)
            {
                alreadyOpened.Focus();            // Bring the old one to top
                Shown += (s, e) => this.Close();  // and destroy the new one.
                return;
            }

            // Otherwise store this one as reference
            alreadyOpened = this;

            InitializeComponent();
        }

        private void ParamatereReportFm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            //loadcombobox_tablenumberFrom();
            //loadcombobox_tablenumberTo();
        }

        private void loadcombobox_tablenumberFrom()
        {

            DataSet ds = new DataSet();
            string getEmpSQL = "SELECT table_no FROM tableinfo order by table_no ;";
            OleDbDataAdapter sda = new OleDbDataAdapter(getEmpSQL, olecon);

            try
            {
                olecon.Open();
                sda.Fill(ds);
            }
            catch (Exception se)
            {
                MessageBox.Show("An error occured while connecting to database" + se.ToString());
            }
            finally
            {
                olecon.Close();
            }
            
            //comboBox_tblnumber_frm.DataSource = ds.Tables[0];
            //comboBox_tblnumber_frm.DisplayMember = "table_no";

        }

        private void loadcombobox_tablenumberTo()
        {

            DataSet ds = new DataSet();
            string getEmpSQL = "SELECT table_no FROM tableinfo order by table_no ;";
            OleDbDataAdapter sda = new OleDbDataAdapter(getEmpSQL, olecon);

            try
            {
                olecon.Open();
                sda.Fill(ds);
            }
            catch (Exception se)
            {
                MessageBox.Show("An error occured while connecting to database" + se.ToString());
            }
            finally
            {
                olecon.Close();
            }

            //comboBox_tblnumber_to.DataSource = ds.Tables[0];
            //comboBox_tblnumber_to.DisplayMember = "table_no";

        }

        private void btn_runonlytablequery_Click(object sender, EventArgs e)
        {
                string datefrom = datetime_from.Value.ToString("dd-MMM-yy");
                string dateto = datetime_to.Value.ToString("dd-MMM-yy");
            //int tblfrom = int.Parse(comboBox_tblnumber_frm.Text);
            //int tblto = int.Parse(comboBox_tblnumber_to.Text);
            customReportform crf = new customReportform(datefrom, dateto);
                crf.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                datetime_from.Value = DateTime.Now.Date;
                datetime_to.Value = DateTime.Now.Date;
                //comboBox_tblnumber_frm.SelectedIndex = 0;// = "0";
                //comboBox_tblnumber_to.SelectedIndex = comboBox_tblnumber_to.Items.Count - 1;
            }
            else
            {
                //comboBox_tblnumber_frm.SelectedIndex = 0;
                //comboBox_tblnumber_to.SelectedIndex = 0;
            }
        }

        private void datetime_to_Validating(object sender, CancelEventArgs e)
        {
           
        }

        private void datetime_to_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}

