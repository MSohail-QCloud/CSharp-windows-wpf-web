using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;

namespace db_Backup_Application
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Server sqlsrv; //initialized when connection succeedes
        private string dbName;
        private string backupFile;
        private string serverName;
        private string sqlUser;
        private string sqlPass;

        private void Form1_Load(object sender, EventArgs e)
        {
            serverName = "10.0.4.52";
        }
        private bool connectToSQLServer()
        {
            try
            {
                ServerConnection serverConn = new ServerConnection(this.serverName);
                // Log in into sqlserver
                serverConn.LoginSecure = false;
                // Give the login username
                serverConn.Login = this.sqlUser;
                // Give the login password
                serverConn.Password = this.sqlPass;
                // create a new sql server object
                sqlsrv = new Server(serverConn.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
            return true;
        }
    }
}
