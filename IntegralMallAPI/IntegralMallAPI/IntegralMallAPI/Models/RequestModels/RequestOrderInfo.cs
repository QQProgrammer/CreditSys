using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntegralMallAPI.Models
{
    public class RequestOrderInfo
    {
        public int MemberId { get; set; }
        public string OrderAddress { get; set; }
        public string OrderName { get; set; }
        public string OrderTelephone { get; set; }
        public string OrderState { get; set; }
        public int OrderPrice { get; set; }
        public int OrderType { get; set; }
        public int InventedType { get; set; }
        public string OrderFrom { get; set; }
        public string OrderRemark { get; set; }
        public List<OrderDetaile> OrderDetaile { get; set; }
    }
}