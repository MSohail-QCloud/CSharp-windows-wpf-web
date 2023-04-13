using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VesterShoes.Reports
{
    class VenderLedgerDBWork
    {
        public string WorkDate { get; set; }
        public string jid { get; set; }
        public string ItemsDescription { get; set; }
        public string finish { get; set; }
        public string Apper { get; set; }
        public string rat { get; set; }
        public string qty { get; set; }
        public string Amount { get; set; }
    }
    class VenderLedgerDBgetmoney
    {
        public string billdate { get; set; }
        public string Amount { get; set; }
        public string Remarks { get; set; }
    }
}
