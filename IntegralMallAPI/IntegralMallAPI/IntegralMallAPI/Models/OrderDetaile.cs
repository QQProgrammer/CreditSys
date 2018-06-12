using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IntegralMallAPI.Models
{
    public class OrderDetaile
    {
        [Key]
        public int OrderDetaileId { get; set; }
        public int OrderId { get; set; }
        public int SkuId { get; set; }
        public string SkuName { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
    }
}