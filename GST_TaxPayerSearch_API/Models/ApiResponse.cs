using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GST_TaxPayerSearch_API.Models
{
    public class ApiResponse
    {
        public Data Data { get; set; }
        public string StatusCd { get; set; }
        public string StatusDesc { get; set; }
    }
}