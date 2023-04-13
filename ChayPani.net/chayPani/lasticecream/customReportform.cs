using CrystalDecisions.CrystalReports.Engine;
using lasticecream.mydatasetTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Configuration;

namespace lasticecream
{
    public partial class customReportform : Form
    {
        OleDbConnection olecon = new OleDbConnection(ConfigurationManager.ConnectionStrings["Accdbx"].ConnectionString);
        customereport cr = new customereport();
        string datefrom;
        string dateTo;
        string title;
        string phone;
        string msg;
        
        public customReportform(string dfrom,string dto)
        {
            datefrom = dfrom;
            dateTo = dto;
            //tblfrom = tnfrom;
            //tblto = tnto;
            InitializeComponent();
        }

        private void crystalReportVewer_custom_Load(object sender, EventArgs e)
        {

        }

        private void customReportform_Load(object sender, EventArgs e)
        {
            loadbioinfo();
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            mydataset ds = new mydataset();
            
            //DateTime dt = DateTime.Parse(datefrom);
            try
            {
                olecon.Open();

                //string str = "SELECT * from mastebill where billingdate between #14-May-18# and #16-May-18# ;";
                string str = "SELECT * from mastebill where billingdate between #"+datefrom+"# and #"+dateTo+ "#  order by billnumber ;";
                //string str = "SELECT * from mastebill  where table_no = '0'  order by billnumber; ";
                TextObject tiNo = (TextObject)cr.ReportDefinition.Sections["Section1"].ReportObjects["Text_title"];
                tiNo.Text = title;
                TextObject tiphone = (TextObject)cr.ReportDefinition.Sections["Section1"].ReportObjects["Txt_phone"];
                tiphone.Text = phone;

                adapter.SelectCommand = new OleDbCommand(str, olecon);
                adapter.Fill(ds.mastebill);
                olecon.Close();
                cr.SetDataSource(ds);
                crystalReportVewer_custom.ReportSource = cr;
                cr.Refresh();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            
        }
        private void loadbioinfo()
        {
            try
            {
                string sql = "Select * from bioinfo";
                olecon.Open();
                OleDbCommand oledbCmd = new OleDbCommand(sql, olecon);
                OleDbDataReader oledbReader = oledbCmd.ExecuteReader();
                while (oledbReader.Read())
                {
                    title = oledbReader["Title"].ToString();
                    phone = oledbReader["Phonenumber"].ToString();
                    msg = oledbReader["message"].ToString();
                }

                oledbReader.Close();
                oledbCmd.Dispose();
                olecon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                olecon.Close();
            }
        }

        private void btn_runonlytablequery_Click(object sender, EventArgs e)
        {
            
        }
    }
}
