using System;
using System.Collections.Generic;
using System.Text;
using CBA.Core;
using CBA.Data;

namespace CBA.Logic
{
    public class LoanAccountLogic:BaseLogic
    {
        public void CreateLoan(LoanAccount loanAccount)
        {
            LoanAccountDAO loanAccountDao = new LoanAccountDAO();
            loanAccountDao.Insert(loanAccount);
            AccountConfigLogic accountConfigLogic = new AccountConfigLogic();
            AccountConfig accountConfig = new AccountConfig(), accountConfig1 = new AccountConfig(); ;
            accountConfig = accountConfigLogic.GetByID(3);
            accountConfig1 = accountConfigLogic.GetByAccountType(loanAccount.LinkedAccount.AccountType);
            DebitAccount(accountConfig.MainGL, loanAccount.LoanAmount);
            CreditAccount(accountConfig1.MainGL,loanAccount.LoanAmount);
            UpdateBalance(loanAccount);
        }

        public void UpdateBalance(LoanAccount loanAccount)
        {
            LoanAccountDAO loanAccountDao = new LoanAccountDAO();
            loanAccountDao.UpdateBalance(loanAccount);
        }
        public string GenerateLoanAccountNumber(LoanAccount loanAccount)
        {

            int firstNumber = 3;

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(firstNumber);
            Random rng = new Random();
            StringBuilder CustomerIDbuilder = new StringBuilder();
            for (int i = 0; i < 4; i++)
            {
                stringBuilder.Append(rng.Next(10));
            }
            stringBuilder.Append(0);
            stringBuilder.Append(loanAccount.LinkedAccount.Customer.CustomerID);

            string accountNumber = stringBuilder.ToString();
            return accountNumber;
        }

        public List<LoanAccount> GetLoanAccounts()
        {
            LoanAccountDAO loanAccountDao = new LoanAccountDAO();
            List<LoanAccount> loanAccounts = loanAccountDao.GetAll();
            return loanAccounts;
        }

        public void DisburseLoan(LoanAccount loanAccount)
        {
            DebitAccount(loanAccount,loanAccount.LoanAmount);

        }
    }
}