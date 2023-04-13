using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColonyMarket
{
    public partial class Form1 : Form
    {
        OleDbConnection oleconP = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=appdb.accdb; Jet OLEDB:Database Password=myhyperdb");

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s = "insert into AllowedPC(MaccAddress,BoardID,AllowtoUser,AllowDate)values ('"+txtmac.Text+ "','" + txtboardid.Text + "','" + txtuser.Text + "','" + DateTime.Today + "') ";
            Insert(s);
        }
        public void Insert(string s)
        {
            if (oleconP.State == ConnectionState.Closed)
            {
                oleconP.Open();
            }
            OleDbCommand cmd = new OleDbCommand(s, oleconP);
            cmd.ExecuteNonQuery();
            oleconP.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
