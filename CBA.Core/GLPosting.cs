using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBA.Core
{
    public class GLPosting
    {
        public int ID { get; set; }
        public GLAccount AccountToDebit { get; set; }
        public GLAccount AccountToCredit { get; set; }
        public double Amount { get; set; }
        public string Narration { get; set; }
        public DateTime TransactionDate { get; set; }
        public bool IsReversible { get; set; }

        public GLPosting()
        {
            IsReversible = false;
        }
    
    }
}
