using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;

namespace lasticecream
{
    public enum parsal
    {
        Parsal = 0
    }

    public enum menucatagory
    {
        Bar_BQ = 1, Chai_Kehwa = 2, Parathay = 3, Paratha_Rolls = 4, Shakes = 5, Ice_Cream_Shakes = 6, Ice_Cream = 7, others=8, Soft_Drinks=9
    }
    class Myclass
    {
        OleDbConnection olecon = new OleDbConnection(ConfigurationManager.ConnectionStrings["Accdbx"].ConnectionString);

        private void ConOpen(string con)
        {

        }

        public static DataSet selectfunc(string query)
        {
            
            OleDbConnection olecon = new OleDbConnection(ConfigurationManager.ConnectionStrings["Accdbx"].ConnectionString);

            OleDbDataAdapter da = new OleDbDataAdapter(query, olecon);
            DataSet ds = new DataSet("0");
            da.Fill(ds);
            return ds;
            
            
        }

        public DataTable fillgidview(string query)
        {
            olecon.Open();
            DataTable dt_catogory = new DataTable();
            OleDbDataAdapter oleadapt = new OleDbDataAdapter(query, olecon);
            oleadapt.Fill(dt_catogory);
            oleadapt.Dispose();
            olecon.Close();
            return dt_catogory;
            
        }

        public void abc(string sub,string matter)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("producations@gmail.com");
                mail.To.Add("producations@gmail.com");
                mail.Subject = sub;
                mail.Body = matter;

                SmtpServer.Port = 587;
                SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
                SmtpServer.UseDefaultCredentials = false;
                //client.Credentials = new System.Net.NetworkCredential("user@gmail.com", "password");

                SmtpServer.Credentials = new System.Net.NetworkCredential("producations@gmail.com", "productions@s");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.ToString());
            }


        }

        public void updateLog(string msg)
        {
            string str = "insert into DbLog (Description,LogTime) values ('" + msg + "',#" + DateTime.Now + "#)";
            olecon.Open();
            OleDbCommand cmd1 = new OleDbCommand(str, olecon);
            cmd1.ExecuteNonQuery();
            olecon.Close();
        }
    }
}
