using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PPOkNoJavascript.Models
{
    public class Item
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
