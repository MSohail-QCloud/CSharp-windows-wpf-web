using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VesterShoes.Reports
{
    public class JobCardDb
    {
        public string Duplicate { get; set; }
        public DateTime PrintDatetime { get; set; }
        public string cArticle { get; set; }
        public string cType { get; set; }
        public string cColor{ get; set; }
        public string cMaterial { get; set; }
        public string cSol { get; set; }
        public string csize{ get; set; }
        public string cstamp{ get; set; }
        public string cshoelast{ get; set; }
        public string OrderId { get; set; }
        public string Custname { get; set; }
        public string ProcessId { get; set; }
        public int CustmerID { get; set; }
        public int Qty { get; set; }
        public string rAM { get; set; }
        public string rBM { get; set; }
        public string rFM { get; set; }
        public string Ordernote { get; set; }

    }
}
