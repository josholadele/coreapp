using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CBA.Core;

namespace CBA.Logic
{
    public class BaseLogic
    {

        public bool CheckSufficientBalance(double balance, double amount)
        {
            if (balance >= amount)
            { return true;}
            return false;
        }
        public bool CheckSufficientBalance(double balance, double minimumbalance, double amount)
        {
            double txnamount = minimumbalance + amount;
            if (balance >= txnamount)
            { return true; }
            return false;
        }
        public void DebitAccount(CustomerAccount customerAccount, double amount)
        {
            customerAccount.Balance = customerAccount.Balance - amount;
            CustomerAccountLogic customerAccountLogic = new CustomerAccountLogic();
            customerAccountLogic.UpdateBalance(customerAccount);

        }
        public void CreditAccount(CustomerAccount customerAccount, double amount)
        {
            customerAccount.Balance = customerAccount.Balance + amount;
            CustomerAccountLogic customerAccountLogic = new CustomerAccountLogic();
            customerAccountLogic.UpdateBalance(customerAccount);

        }
        public void DebitAccount(GLAccount glAccount, double amount)
        {
            if (glAccount.AccountCode.StartsWith("1") || glAccount.AccountCode.StartsWith("5"))
            {
                glAccount.Balance = glAccount.Balance + amount;

            }
            else
            {
                glAccount.Balance = glAccount.Balance - amount;
            }
            GLAccountLogic glAccountLogic = new GLAccountLogic();
            glAccountLogic.UpdateBalance(glAccount);
        }
        public void DebitAccount(LoanAccount loanAccount, double amount)
        {
            
                loanAccount.Balance = loanAccount.Balance + amount;
            LoanAccountLogic loanAccountLogic = new LoanAccountLogic();
            loanAccountLogic.UpdateBalance(loanAccount);
        }
        public void CreditAccount(LoanAccount loanAccount, double amount)
        {

            loanAccount.Balance = loanAccount.Balance - amount;
            LoanAccountLogic glAccountLogic = new LoanAccountLogic();
            glAccountLogic.UpdateBalance(loanAccount);
        }
        public void CreditAccount(GLAccount glAccount, double amount)
        {
            if (glAccount.AccountCode.StartsWith("1") || glAccount.AccountCode.StartsWith("5"))
            {
                glAccount.Balance = glAccount.Balance - amount;

            }
            else
            {
                glAccount.Balance = glAccount.Balance + amount;
            }
            GLAccountLogic glAccountLogic = new GLAccountLogic();
            glAccountLogic.UpdateBalance(glAccount);

        }


    }
}
