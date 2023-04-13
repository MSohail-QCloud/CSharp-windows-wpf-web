using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.Sql;

namespace menutest
{
    class connectionService
    {
        private SqlConnection con = null;
        private static connectionService dbConn = null;
        public static SqlConnection getConnection()
        {
            SqlConnection conn = null;
            try
            {
                string server = System.Configuration.ConfigurationManager.AppSettings["Server"];
                string database = System.Configuration.ConfigurationManager.AppSettings["Database"];
                string user = "root";
                string password = "";

                string strConn = "SERVER=" + server + ";DATABASE=" + database + ";UID=" + user + ";PASSWORD=" + password;

                conn = new SqlConnection(strConn);
            }
            catch (Exception sqlex)
            {
                throw new Exception(sqlex.Message.ToString());
            }
            return conn;
        }
        public static connectionService GetInstance()
        {
            if (dbConn == null) { dbConn = new connectionService(); }

            return dbConn;
        }

        public SqlConnection GetConnection()
        {
            return this.con;
        }
    }
}
