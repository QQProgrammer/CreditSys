using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IntegralCardAPI.Models
{
    public class IntegralGoodsQrcPackage
    {
        [Key]
        public int PackageId { get; set; }
        public string Name { get; set; }
        public int GoodsId { get; set; }
        public string Url { get; set; }
        public int Range { get; set; }
        public string GoodsCode { get; set; }
        public int Source { get; set; }
        public int March { get; set; }
        public int Num { get; set; }
        public int State { get; set; }
        public string Remark { get; set; }
        public string DownLoadUrl { get; set; }
        public DateTime CreateDate { get; set; }
    }
}