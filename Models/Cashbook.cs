using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace bookkeepingAPI.Models
{
    public class Cashbook
    {
        [Key]
        public int receipt_no { get; set; }
        public string details{ get; set; }
        public int salesCount { get; set; }
        public int cashInHand { get; set; }
        public DateTime Date { get; set; }

    }
}
