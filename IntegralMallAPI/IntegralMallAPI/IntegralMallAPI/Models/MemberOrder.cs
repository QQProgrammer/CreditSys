using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IntegralMallAPI.Models
{
    public class MemberOrder
    {
        [Key]
        public int OrderId { get; set; }
        public int MemberId { get; set; }
        public string OrderAddress { get; set; }
        public string OrderName { get; set; }
        public string OrderTelephone { get; set; }
        public string OrderState { get; set; }
        public int OrderPrice { get; set; }
        public int OrderType { get; set; }
        public int InventedType { get; set; }
        public string LogisticsNo { get; set; }
        public string LogisticsType { get; set; }
        public string OrderFrom { get; set; }
        public string OrderRemark { get; set; }
        public DateTime AddDate { get; set; }

    }
}