using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CBA.Core;
using CBA.Logic;

namespace FrontEndProcessor
{
    public class CBACheck
    {
        protected static bool EnoughCash(string linkedAccount, IList<string> allowedTransactions)
        {
            CustomerAccountLogic customerAccountLogic = new CustomerAccountLogic();
            CustomerAccount customerAccount = customerAccountLogic.GetByAccountNumber(linkedAccount);

            double txnAmount = Double.Epsilon;

            if (customerAccount.Balance >= txnAmount)
            {
                return true;
            }

            return false;
        }

        protected static bool PostTransaction(string linkedAccount, IList<string> allowedTransactions)
        {
            CustomerAccountLogic customerAccountLogic = new CustomerAccountLogic();
            CustomerAccount customerAccount = customerAccountLogic.GetByAccountNumber(linkedAccount);

            double txnAmount = Double.Epsilon;

            if (customerAccount.Balance >= txnAmount)
            {
                return true;
            }

            return false;
        }

    }
}
