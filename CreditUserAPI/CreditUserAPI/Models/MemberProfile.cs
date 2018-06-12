using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CreditUserAPI.Models
{
    public class MemberProfile
    {
        [Key]
        public int MemberId { get; set; }
        public string JobReason { get; set; }
        public string FoodDemand { get; set; }
        public string ExpertInCuisine { get; set; }
        public int? IsShare { get; set; }
        public DateTime? Birthday { get; set; }
        public int? Sex { get; set; }
        public string Nation { get; set; }
        public int? HomeProvinceId { get; set; }
        public string HomeProvinceName { get; set; }
        public int? HomeCityId { get; set; }
        public string HomeCityName { get; set; }
        public int? HomeAreaId { get; set; }
        public string HomeAreaName { get; set; }
        public string HomeAddress { get; set; }
        public DateTime? JoinDate { get; set; }
        public string School { get; set; }
        public string Major { get; set; }
        public string Nature { get; set; }
        public int? IsJob { get; set; }
        public string Hobbys { get; set; }
        public string Speciality { get; set; }
        public string Educations { get; set; }
        public string ChoicePower { get; set; }
        public string IsCtrlTime { get; set; }
        public string Teacher { get; set; }
        public string Development { get; set; }
        public int? IsManyExp { get; set; }
        public string WishCity { get; set; }
        public string Represent { get; set; }
        public string SuccessReasons { get; set; }
        public string Purchaser { get; set; }
        public int? IsMarry { get; set; }
        public string ChineseLv { get; set; }
        public string MatchName { get; set; }
        public string MatchLv { get; set; }
        public string MatchNum { get; set; }
        public string Honor { get; set; }
        public string Qualifications { get; set; }
        public string DietitianLv { get; set; }
        public string ExposureCount { get; set; }
        public string Introduction { get; set; }
        public DateTime? ProfileTime { get; set; }

    }
}