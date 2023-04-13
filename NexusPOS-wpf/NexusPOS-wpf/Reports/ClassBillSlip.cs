using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusPOS_wpf.Reports
{
    class ClassBillSlip
    {
        public DateTime billingdate { get; set; }
        public int billnumber { get; set; }
        public int billamount { get; set; }
        public int billDiscount { get; set; }
        public int grandTotal { get; set; }
        public int paidamount { get; set; }
        public int RemainingBill { get; set; }
        public int RemainingBalance { get; set; }
        public string CustomerName { get; set; }
        public string Discription { get; set; }
        public float ItemPrice { get; set; }
        public String Size { get; set; }
        public int Qty { get; set; }
        public int Total { get; set; }
        public int Labour { get; set; }
        public int Design { get; set; }
        public int Positive { get; set; }
    }
}
