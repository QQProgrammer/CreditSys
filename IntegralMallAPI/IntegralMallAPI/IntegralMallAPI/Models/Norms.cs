using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IntegralMallAPI.Models
{
    public class Norms
    {
        [Key]
        public int NormsId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string TypeName { get; set; }
        public string TypeValue { get; set; }
        public int IsEnable { get; set; }
    }
}