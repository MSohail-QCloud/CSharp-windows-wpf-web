using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VesterShoes.Reports
{
    internal class CustomerLedgerDB
    {
        public String Datetime { get; set; }

        public String Bill { get; set; }
        public String Debit { get; set; }
        public String Credit { get; set; }
        public String Balance { get; set; }
        public String Detail { get; set; }
        public String pcompanyname { get; set; }
    }
}
