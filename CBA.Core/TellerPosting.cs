using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBA.Core
{
    public class TellerPosting
    {
        public int ID { get; set; }
        public CustomerAccount CustomerAccount  { get; set; }
        public GLAccount Till { get; set; }
        public double Amount { get; set; }
        public TransactionType TransactionType { get; set; }
        public string Narration { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
