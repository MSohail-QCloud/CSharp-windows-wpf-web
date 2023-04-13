using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using MySql.Data.MySqlClient;
using System.Reflection;
using System.Data.SqlClient;
using System.Configuration;

namespace menutest
{
    public partial class FrmParent : Form
    {
        private ToolStripMenuItem MnuStripItem;
        //MySqlConnection conn = connectionService.getConnection();
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbx"].ConnectionString);
        public FrmParent(string uid)
        {
            InitializeComponent();
            this.toolUserID.Text = uid;
        }

        private void ChildClick(object sender, EventArgs e)
        {
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT FRM_CODE FROM MNU_SUBMENU WHERE FRM_NAME='" + sender.ToString() + "'", con);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            Assembly assembly = Assembly.LoadFile(Application.ExecutablePath);
            foreach (System.Type type in assembly.GetTypes())
            {
                if ((type.BaseType == typeof(Form)) && (type.Name == dataTable.Rows[0][0].ToString()))
                {
                    Form form = (Form)assembly.CreateInstance(type.ToString());
                    foreach (Form form2 in base.MdiChildren)
                    {
                        form2.Close();
                    }
                    form.MdiParent = this;
                    form.WindowState = FormWindowState.Maximized;
                    form.Show();
                }
            }
        }
        
        public void SubMenu(ToolStripMenuItem mnu, string submenu)
        {
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT FRM_NAME FROM vw_pagerole WHERE MENUPARVAL='" + submenu + "' and status = 1 and UID = '" + toolUserID.Text + "' ", con);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            foreach (DataRow row in dataTable.Rows)
            {
                ToolStripMenuItem item = new ToolStripMenuItem(row["FRM_NAME"].ToString(), null, new EventHandler(ChildClick));
                mnu.DropDownItems.Add(item);
            }
        }

        private void FrmParent_Load(object sender, EventArgs e)
        {
            this.MnuStrip = new MenuStrip();
            base.Controls.Add(this.MnuStrip);
            //conn.Open();
            string selectCommandText = "SELECT MAINMNU,MENUPARVAL,STATUS FROM mnu_parent where status = 'Y'";
            SqlDataAdapter adapter = new SqlDataAdapter(selectCommandText, con);
            DataTable dataTable = new DataTable();
            con.Open();
            adapter.Fill(dataTable);
            foreach (DataRow row in dataTable.Rows)
            {
                this.MnuStripItem = new ToolStripMenuItem(row["MAINMNU"].ToString());
                this.SubMenu(this.MnuStripItem, row["MENUPARVAL"].ToString());
                this.MnuStrip.Items.Add(this.MnuStripItem);
            }
            base.MainMenuStrip = this.MnuStrip;
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            base.Hide();
            //new Login().ShowDialog();
        }

    }
}
