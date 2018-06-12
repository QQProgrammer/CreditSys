using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IntegralCardAPI.Models
{
    public class IntegralRuleChance
    {
        [Key]
        public int RuleChanceId { get; set; }
        public int RuleId { get; set; }
        public int Integral { get; set; }
        public int PutNum { get; set; }
        public int Chance { get; set; }
    }
}