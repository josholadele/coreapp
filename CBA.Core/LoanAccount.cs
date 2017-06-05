using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBA.Core
{
    public class LoanAccount
    {
        public int ID { get; set; }
        public CustomerAccount LinkedAccount { get; set; }
        public double LoanAmount { get; set; }
        public DateTime LoanStartDate { get; set; }
        public DateTime LoanDueDate { get; set; }
        public double LoanInterest { get; set; }
        public double LoanPeriod { get; set; }
        public double Balance { get; set; }
        public string AccountNumber { get; set; }
    }
}
