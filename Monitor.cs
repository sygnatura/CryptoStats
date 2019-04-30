using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoStats
{
    class Monitor
    {
        public long id { get; set; }
        public string name { get; set; }
        public byte monitor_index { get; set; }
        public byte rule_index { get; set; }
        public decimal value { get; set; }
    }
}
