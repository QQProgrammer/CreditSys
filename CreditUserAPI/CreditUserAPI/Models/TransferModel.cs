using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CreditUserAPI.Models
{
    public class TransferModel
    {
        public int MemberId { get; set; }
        public int OldSalemanId { get; set; }
        public int NewSalemanId { get; set; }
    }
}