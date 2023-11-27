using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GST_TaxPayerSearch_API.Models
{
    public class Data
    {
        public string StjCd { get; set; }
        public string Lgnm { get; set; }
        public string Dty { get; set; }
        public string Stj { get; set; }
        public List<object> Adadr { get; set; }
        public string Cxdt { get; set; }
        public List<string> Nba { get; set; }
        public string Gstin { get; set; }
        public string Lstupdt { get; set; }
        public string Ctb { get; set; }
        public string Rgdt { get; set; }
        public Pradr Pradr { get; set; }
        public string TradeNam { get; set; }
        public string CtjCd { get; set; }
        public string Sts { get; set; }
        public string Ctj { get; set; }
        public string EinvoiceStatus { get; set; }
    }
}