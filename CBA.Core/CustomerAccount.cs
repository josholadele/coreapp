using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBA.Core
{
    public class CustomerAccount
    {
        public int ID { get; set; }
        public Customer Customer { get; set; }
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
        public double Balance { get; set; }
        public Branch Branch { get; set; }
        public AccountType AccountType { get; set; }
        public bool IsClosed { get; set; }

        public double COTCharge { get; set; }

        public CustomerAccount()
        {
            Balance = 0.00;
            IsClosed = false;
            COTCharge = 0.00;
        }
    }
}
