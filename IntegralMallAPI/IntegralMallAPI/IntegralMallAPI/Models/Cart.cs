using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IntegralMallAPI.Models
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }
        public int MemberId { get; set; }
        public int SkuId { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        public string SkuName { get; set; }
        public int Price { get; set; }
    }
}