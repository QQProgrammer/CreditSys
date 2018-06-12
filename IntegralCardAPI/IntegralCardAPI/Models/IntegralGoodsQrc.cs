using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IntegralCardAPI.Models
{
    public class IntegralGoodsQrc
    {
        [Key]
        public int QrcId { get; set; }
        public string QrcUrl { get; set; }
        public string Code { get; set; }
        public int State { get; set; }
        public int PackageId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UseDate { get; set; }
        public string Remark { get; set; }
    }
}