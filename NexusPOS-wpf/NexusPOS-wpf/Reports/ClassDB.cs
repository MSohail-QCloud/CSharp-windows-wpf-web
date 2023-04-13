using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusPOS_wpf.Reports
{
    class ClassDB
    {
        OleDbConnection olecon = new OleDbConnection(ConfigurationManager.ConnectionStrings["Accdbx"].ConnectionString);

        public DataSet ds_invoice(int bNumber)
        {
            //string query = "select mb.printdatetime,mb.billnumber,mb.SubTotal,mb.Discount,mb.GrandTotal,mb.PaidBill,mb.RemainingBill,mb.RemainingBalance,mb.PersonName, db.Rate,db.SizeWidth,db.SizeLength,db.Qty,db.Total,db.LabourCharges,db.DesignCharges,db.PositiveCharges from detailbill db inner join mastebill mb on db.billnumber=mb.billnumber where mb.billnumber=@bNumber  group by db.menu_name,db.menurate,mb.printdatetime,mb.PartyName,mb.table_no,mb.billingdate,mb.billnumber,mb.billamount,mb.serviceCharges,mb.billDiscount,mb.grandTotal,mb.paidamount,mb.change,mb.WaiterName,mb.gTax";
            string query = "select mb.printdatetime,mb.billnumber,mb.SubTotal,mb.Discount,mb.GrandTotal,mb.PaidBill,mb.RemainingBill,mb.RemainingBalance,mb.PersonName, db.ItemDescription, db.Rate,db.SizeWidth,db.SizeLength,db.Qty,db.Total,db.LabourCharges,db.DesignCharges,db.PositiveCharges from detailbill db inner join mastebill mb on db.billnumber=mb.billnumber where mb.billnumber=@bNumber ";
            OleDbCommand olecmd = new OleDbCommand(query, olecon);
            olecmd.CommandType = CommandType.Text;
            olecmd.Parameters.AddWithValue("@bNumber", bNumber);
            OleDbDataAdapter oleda = new OleDbDataAdapter(olecmd);
            DataSet ds = new DataSet();
            oleda.Fill(ds);
            return ds;

        }
        //public DataSet reportdetail(int bNumber, string bdate)
        //{
        //    string query = "select table_no,billnumber,billamount,billDiscount,grandTotal, paidamount,change,billingdate,WaiterName  from mastebill where billnumber=@bNumber and billingdate=#" + bdate + "#";
        //    OleDbCommand olecmd = new OleDbCommand(query, olecon);
        //    olecmd.CommandType = CommandType.Text;
        //    olecmd.Parameters.AddWithValue("@bNumber", bNumber);
        //    OleDbDataAdapter oleda = new OleDbDataAdapter(olecmd);
        //    DataSet ds = new DataSet();
        //    oleda.Fill(ds);
        //    return ds;

        //}
        //public DataSet reportinfo(int bNumber, string bdate)
        //{
        //    string query = "select masterbill_id,menu_name, menu_qty,total from detailbill where masterbill_id=@bNumber and billingdate=#" + bdate + "#";
        //    OleDbCommand olecmd = new OleDbCommand(query, olecon);
        //    olecmd.CommandType = CommandType.Text;
        //    olecmd.Parameters.AddWithValue("@bNumber", bNumber);
        //    OleDbDataAdapter oleda = new OleDbDataAdapter(olecmd);
        //    DataSet ds = new DataSet();
        //    oleda.Fill(ds);
        //    return ds;

        //}

        //public DataSet miniReportDataset(int bNumber, string bdate)
        //{
        //    string query = "select mb.printdatetime,mb.billingdate,mb.table_no,mb.billnumber, mb.WaiterName ,sum(db.menu_qty)AS menu_qty,db.menu_name from detailbill db inner join mastebill mb on db.masterbill_id=mb.billnumber where mb.billnumber=@bNumber and mb.billingdate=#" + bdate + "# and db.partialBill=" + 0 + " group by db.menu_name,mb.printdatetime,mb.billingdate,mb.table_no,mb.billnumber, mb.WaiterName ";
        //    OleDbCommand olecmd = new OleDbCommand(query, olecon);
        //    olecmd.CommandType = CommandType.Text;
        //    olecmd.Parameters.AddWithValue("@bNumber", bNumber);
        //    OleDbDataAdapter oleda = new OleDbDataAdapter(olecmd);
        //    DataSet ds = new DataSet();
        //    oleda.Fill(ds);
        //    return ds;
        //}
    }
}
