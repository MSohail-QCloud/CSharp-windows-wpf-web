using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VesterShoes.Reports
{
    class InvoiceSlipDB
    {
        public String artical { get; set; }
        public String material { get; set; }
        public String sol { get; set; }
        public String ItemsDescription { get; set; }
        public String size { get; set; }
        public int ItemsQty { get; set; }
        public int ItemsRate { get; set; }
        public int ItemsTotal { get; set; }
    }
}
