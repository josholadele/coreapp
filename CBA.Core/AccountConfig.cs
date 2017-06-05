using CBA.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBA.Core
{
    public class AccountConfig
    {
        public int ID { get; set; }
        public double CrInterestRate { get; set; }
        public double DrInterestRate { get; set; }
        public double MinimumBalance { get; set; }
        public GLAccount InterestExpenseGL { get; set; }
        public GLAccount InterestIncomeGL { get; set; }
        public GLAccount COTIncomeGL { get; set; }
        public double COT { get; set; }
        public AccountType AccountType { get; set; }
        public GLAccount MainGL { get; set; }

        public AccountConfig()
        {
            CrInterestRate = 0.00;
            DrInterestRate = 0.00;
            MinimumBalance = 0.00;
            InterestExpenseGL = null;
            InterestIncomeGL = null;
            MainGL = null;
            COTIncomeGL = null;
            COT = 0.00;

        }

        //public AccountConfig(AccountType accountType)
        //{
        //    if (accountType == AccountType.Savings)
        //    {
        //        CrInterestRate = 2.00;
        //        MinimumBalance = 0.00;
        //        DrInterestRate = 0;
        //        COT = 0;
        //    }
        //    else if (accountType == AccountType.Current)
        //    {
        //        CrInterestRate = 12.0;
        //        MinimumBalance = 1000.00;
        //        DrInterestRate = 0;
        //        COT = 5;
        //    }
        //    else
        //        CrInterestRate = 10.0;
        //        MinimumBalance = 0.00;
        //        COT = 0;
        //        DrInterestRate = 5.00;

        //}
    }
}
