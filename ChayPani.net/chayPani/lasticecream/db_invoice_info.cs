using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lasticecream
{
    class db_invoice_info
    {
        
        public string table_no { get; set; }
        public int billnumber { get; set; }
        public int billamount { get; set; }
        public int paidamount { get; set; }
        public int change { get; set; }
        public DateTime billingdate { get; set; }

    }
}
