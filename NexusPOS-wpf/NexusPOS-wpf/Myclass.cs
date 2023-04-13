using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusPOS_wpf
{
    public enum RemindPlane
        {
            specificDateRemind=1,WeekofDayRemind=2,MonthlyRemind=3
        }
    class Myclass
    {
        OleDbConnection olecon = new OleDbConnection(ConfigurationManager.ConnectionStrings["Accdbx"].ConnectionString);
       

        public int findCustomerBalance(int CustomerID)
        {
            DataSet ds = new DataSet();
            string getEmpSQL = "SELECT * FROM SaleRegister where Personid=" + CustomerID + " order by SaleRegisterID ";
            OleDbDataAdapter sda = new OleDbDataAdapter(getEmpSQL, olecon);
                olecon.Open();
                sda.Fill(ds);
                olecon.Close();
            int BillAmount = 0;
            int Paidamount = 0;
            int balance = 0;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                BillAmount += int.Parse(dr["TotalBill"].ToString());
                Paidamount += int.Parse(dr["PaidBill"].ToString());
            }
            balance = BillAmount - Paidamount;
            return balance;
        }

        public int findVenderBalance(int VenderID)
        {
            DataSet ds = new DataSet();
            string getEmpSQL = "SELECT * FROM PurchaseRegister where Personid=" + VenderID + " order by PurchaseRegisterID ";
            OleDbDataAdapter sda = new OleDbDataAdapter(getEmpSQL, olecon);
            olecon.Open();
            sda.Fill(ds);
            olecon.Close();
            int BillAmount = 0;
            int Paidamount = 0;
            int balance = 0;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                BillAmount += int.Parse(dr["TotalPO"].ToString());
                Paidamount += int.Parse(dr["PaidPO"].ToString());
            }
            balance = BillAmount - Paidamount;
            return balance;
        }



    }
}
