using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CreditUserAPI.Models
{
    public class MemberResume
    {
        [Key]
        public int ResumeId { get; set; }
        public int ProvinceId { get; set; }
        public string ProvinceName { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int AreaId { get; set; }
        public string AreaName { get; set; }
        public DateTime? BeginTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int MemberId { get; set; }
        public string HotelName { get; set; }
        public string HotelAddress { get; set; }
        public string Job { get; set; }
        public string HotelCode { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}