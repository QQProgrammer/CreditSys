using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntegralMallAPI.Models
{
    public class SKU
    {
        public int SkuId { get; set; }
        public string SkuName { get; set; }
        public int ProductId { get; set; }
        public string SkuCode { get; set; }
        public int NormsId { get; set; }
        public int Stock { get; set; }
        public double MarketPrice { get; set; }
        public int Price { get; set; }
        public int Sort { get; set; }
        public int Limit { get; set; }
        public int IsShow { get; set; }
        public DateTime AddDate { get; set; }
        public int IsEnable { get; set; }

    }
}