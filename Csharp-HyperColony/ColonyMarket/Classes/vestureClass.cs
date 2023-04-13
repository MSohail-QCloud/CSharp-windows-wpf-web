using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace ColonyMarket.classes
{
    
    class VestureClass
    {
        SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["sqldbx"].ToString());

        public void Insert(string s)
        {
            if (sqlcon.State == ConnectionState.Closed)
            {
                sqlcon.Open();
            }
            SqlCommand cmd = new SqlCommand(s, sqlcon);
            cmd.ExecuteNonQuery();
            sqlcon.Close();
        }

        public void Delete(string s)
        {
            if (sqlcon.State == ConnectionState.Closed)
            {
                sqlcon.Open();
            }
            SqlCommand cmd = new SqlCommand(s, sqlcon);
            cmd.ExecuteNonQuery();
            sqlcon.Close();
        }

        public bool Selectbool(string s)
        {
            SqlDataReader dr;
            if (sqlcon.State == ConnectionState.Closed)
            {
                sqlcon.Open();
            }
            SqlCommand cmd = new SqlCommand(s, sqlcon);//Advised to use parameterized query
            dr = cmd.ExecuteReader();
            
            if (dr.Read())
            {
               dr.Close();
                sqlcon.Close();
                return true;
            }
            sqlcon.Close();
            dr.Close();
            return false;
        }
        public DataSet Select(string s)
        {
            if (sqlcon.State == ConnectionState.Closed)
            {
                sqlcon.Open();
            }
            SqlDataAdapter da = new SqlDataAdapter(s, sqlcon);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (sqlcon.State == ConnectionState.Open)
            {
                sqlcon.Close();
            }
            return ds;
        }

        public void Update(string s)
        {
            if (sqlcon.State == ConnectionState.Closed)
            {
                sqlcon.Open();
            }
            SqlCommand cmd = new SqlCommand(s, sqlcon);
            cmd.ExecuteNonQuery();
            sqlcon.Close();

            //cmd = new SqlCommand("Update tbl_Record set Name=@name,State=@state where ID=@id", con);
            //con.Open();
            //cmd.Parameters.AddWithValue("@id", ID);
            //cmd.Parameters.AddWithValue("@name", txt_Name.Text);
            //cmd.Parameters.AddWithValue("@state", txt_State.Text);
            //cmd.ExecuteNonQuery();
            //MessageBox.Show("Record Updated Successfully");
            //con.Close();
            //DisplayData();
            //ClearData();
        }
    }
}
