using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IntegralCardAPI.Models
{
    public class IntegralGoods
    {
        [Key]
        public int GoodsId { get; set; }
        public string GoodsNo { get; set; }
        public string GoodsInterNo { get; set; }
        public string GoodsName { get; set; }
        public double GoodsPrice { get; set; }
        public int GoodsState { get; set; }
        public DateTime CreateDate { get; set; }
        public string Remark { get; set; }
        public string GoodsImageUrl { get; set; }
    }
}