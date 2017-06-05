using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEndProcessor
{
    public class Check
    {
        Transaction transaction = new Transaction();

        protected static bool TransactionTypeIsAllowed(string transactionTypeCode, IList<string> allowedTransactions)
        {
            if (allowedTransactions.Contains(transactionTypeCode))
            {
                return true;
            }
            
            return false;
        }

        protected static bool CardHasExpired(int expiryDate)
        {
            int today = int.Parse(DateTime.Now.Date.ToString("yyMM"));

            if (today <= expiryDate)
            {
                return false;
            }
            return true;
        }

        protected static bool CardNumberIsInvalid(string cardPan)
        {
            if (cardPan.Length != 16)
            {
                return true;
            }
            return false;
        }

        protected static bool AmountIsInvalid(string amount)
        {
            if (amount.Length > 8)
            {
                return true;
            }
            return false;
        }

        

    }
}
