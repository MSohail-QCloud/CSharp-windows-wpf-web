using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lasticecream
{
    class db_invoice_detail
    {
        public DateTime billingdate { get; set; }
        public string Pprintdatetime { get; set; }
        public string table_no { get; set; }
        public int billnumber { get; set; }
        public int billamount { get; set; }
        public int serviceCharges { get; set; }
        public int billDiscount { get; set; }
        public int grandTotal { get; set; }
        public int paidamount { get; set; }
        public int change { get; set; }
        public float menu_qty { get; set; }
        public string menu_name { get; set; }
        public int menurate { get; set; }
        public int total { get; set; }
        public string Waiter { get; set; }
        public string CustomerName { get; set; }

    }
}
