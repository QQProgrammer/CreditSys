using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CommonAPI.Models
{
    public class Address
    {
        [Key]
        public int AddressId { get; set; }
        public int MemberId { get; set; }
        public string FullName { get; set; }
        public string Mobile { get; set; }
        public int ProvinceId { get; set; }
        public string ProvinceName { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int AreaId { get; set; }
        public string AreaName { get; set; }
        public string MemberAddress { get; set; }
        public int IsDefault { get; set; }
        public string ZipCode { get; set; }

    }
}