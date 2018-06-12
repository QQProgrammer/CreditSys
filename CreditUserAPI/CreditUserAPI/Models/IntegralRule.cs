using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CreditUserAPI.Models
{
    public class IntegralRule
    {
        [Key]
        public int IntegralRuleId { get; set; }
        public string RuleName { get; set; }
        public string ProduceName { get; set; }
        public string ProduceNorms { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int RuleState { get; set; }
        public int Integral { get; set; }
        public float Price { get; set; }
        public string Unit { get; set; }
        public int IsActivity { get; set; }
        public string Remark { get; set; }
    }
}