using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IntegralMallAPI.Models
{
    public class SaleActivity
    {
        [Key]
        public int SkuId { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int SalePrice { get; set; }
        public int Limit { get; set; }
    }
}