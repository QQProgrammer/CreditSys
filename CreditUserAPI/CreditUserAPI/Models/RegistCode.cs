using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CreditUserAPI.Models
{
    public class RegistCode
    {
        [Key]
        public int RegistCodeId { get; set; }
        public int SalemanId { get; set; }
        
        [DefaultValue(0)]
        public int MemberId { get; set; }
        public int RegistCodeState { get; set; }
        public DateTime GenerDate { get; set; }
        public DateTime? UseDate { get; set; }
    }
}