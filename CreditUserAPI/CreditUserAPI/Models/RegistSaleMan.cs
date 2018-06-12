using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CreditUserAPI.Models
{
    public class RegistSaleMan
    {
        [Key]
        public int SalemanId { get; set; }
        public int ProvinceId { get; set; }
        public string ProvinceName { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int AreaId { get; set; }
        public string AreaName { get; set; }
        public int? RegionId { get; set; }
        public string RegionName { get; set; }
        public string WorkNum { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }
        public string CardId { get; set; }
        public DateTime RegistDate { get; set; }
        public int RegistState { get; set; }
        public string Remark { get; set; }
        public DateTime? ImportDate { get; set; }
        public int IsEnable { get; set; }
    }
}