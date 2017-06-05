using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Providers.Entities;
using CBA.Core;
using CBA.Data;

namespace CBA.Logic
{
    public class EODLogic:BaseLogic
    {
        public void RunEOD()
        {
            PayInterests();
            ReceiveInterests();
            ReceiveCOTInterest();
        }

        public void CloseBusiness()
        {
            EOD eod = new EOD();
            
            eod = GetByID(1);
            eod.BusinessIsOpen = false;
            RunEOD();
            eod.FinancialDate = eod.FinancialDate.AddDays(1);
            
            UpdateEOD(eod);
        }

        public void OpenBusiness()
        {
            EOD eod = new EOD();
            eod = GetByID(1);
            eod.BusinessIsOpen = true;
            UpdateEOD(eod);
        }

        void PayInterests()
        {
            EOD eod = GetByID(1);
            CustomerAccountLogic customerAccountLogic = new CustomerAccountLogic();
            List<CustomerAccount> customerAccounts = customerAccountLogic.GetCustomerAccounts();
            customerAccounts = customerAccounts.Where(x => x.IsClosed == false).ToList();
            AccountConfigLogic accountConfigLogic = new AccountConfigLogic();
            AccountConfig accountConfig = new AccountConfig();

            //debit interest expense to credit custommer accounts
            foreach (var customerAccount in customerAccounts)
            {
                GLAccountLogic glAccountLogic = new GLAccountLogic();
                GLPostingLogic glPostingLogic = new GLPostingLogic();
                GLPosting glPosting = new GLPosting();

           
                accountConfig = accountConfigLogic.GetByID((int)customerAccount.AccountType);
                glPosting.AccountToCredit = accountConfig.MainGL;
                double interest = CalculateInterest(customerAccount.Balance, accountConfig.CrInterestRate);
                CreditAccount(customerAccount, interest);
                DebitAccount(accountConfig.InterestExpenseGL, interest);
                glPosting.AccountToDebit = accountConfig.InterestExpenseGL;
                glPosting.Amount = interest;
                glPosting.Narration=string.Format("EOD Interest Payment for {0}",eod.FinancialDate);
                glPosting.TransactionDate = eod.FinancialDate;

                glPostingLogic.Post(glPosting);
                glPostingLogic.CreditAccount(accountConfig.MainGL, interest);
            }
            
        }

        void ReceiveInterests()
        {
            EOD eod = GetByID(1);

            //interest income from current accounts
            //interest income from loan accounts
            LoanAccountLogic loanAccountLogic = new LoanAccountLogic();
            List<LoanAccount> loanAccounts = loanAccountLogic.GetLoanAccounts();
            AccountConfigLogic accountConfigLogic = new AccountConfigLogic();
            AccountConfig loanAccountConfig = new AccountConfig();

            foreach (var loanAccount in loanAccounts)
            {
                loanAccountConfig = accountConfigLogic.GetByID(3);
                double interest = CalculateInterest(loanAccount.Balance, loanAccountConfig.DrInterestRate);
                double instalment = CalculatePrincipalInstalment(loanAccount);
                
                DebitAccount(loanAccount.LinkedAccount, interest);
                DebitAccount(loanAccount.LinkedAccount, instalment);

                CreditAccount(loanAccount,instalment);
                CreditAccount(loanAccountConfig.InterestIncomeGL, interest);

                GLAccountLogic glAccountLogic = new GLAccountLogic();
                GLPostingLogic glPostingLogic = new GLPostingLogic();
                GLPosting glPosting = new GLPosting(), glPosting1 = new GLPosting();


                glPosting.AccountToCredit = loanAccountConfig.MainGL;
                AccountConfig linkedAccountConfig = accountConfigLogic.GetByID((int)loanAccount.LinkedAccount.AccountType);
                glPosting.AccountToDebit = linkedAccountConfig.MainGL;
                glPosting.Amount = instalment;
                glPosting.Narration = string.Format("Loan Amount Instalment Payment for {0}", eod.FinancialDate.ToShortDateString());
                glPosting.TransactionDate = eod.FinancialDate;
                glPostingLogic.Post(glPosting);
                glPostingLogic.CreditAccount(loanAccountConfig.MainGL, instalment);
                glPostingLogic.DebitAccount(linkedAccountConfig.MainGL, instalment);


                glPosting.AccountToCredit = loanAccountConfig.InterestIncomeGL;
                glPosting.AccountToDebit = linkedAccountConfig.MainGL;
                glPosting.Amount = interest;
                glPosting.Narration = string.Format("Loan Interest Payment for {0}", eod.FinancialDate.ToShortDateString());
                glPosting.TransactionDate = eod.FinancialDate;

                glPostingLogic.Post(glPosting);
                

                
            }
            
        }

        void ReceiveCOTInterest()
        {
            EOD eod = GetByID(1);
            //cot income from current accounts
            CustomerAccountLogic customerAccountLogic = new CustomerAccountLogic();
            List<CustomerAccount> customerAccounts = customerAccountLogic.GetCustomerAccounts();
            customerAccounts = customerAccounts.Where(x => x.IsClosed == false).ToList();

            foreach (var customerAccount in customerAccounts)
            {
                AccountConfigLogic accountConfigLogic = new AccountConfigLogic();
                AccountConfig accountConfig = accountConfigLogic.GetByID((int)customerAccount.AccountType);
                GLPostingLogic glPostingLogic = new GLPostingLogic();
                GLPosting glPosting = new GLPosting();

                if (customerAccount.COTCharge > 0.00)
                {
                    DebitAccount(customerAccount, customerAccount.COTCharge);

                    CreditAccount(accountConfig.COTIncomeGL, customerAccount.COTCharge);


                    glPosting.AccountToCredit = accountConfig.COTIncomeGL;
                    glPosting.AccountToDebit = accountConfig.MainGL;
                    glPosting.Amount = customerAccount.COTCharge;
                    glPosting.Narration = string.Format("Daily COT Charge for {0} on account: {1}", eod.FinancialDate.ToShortDateString(),customerAccount.AccountNumber);
                    glPosting.TransactionDate = eod.FinancialDate;

                    glPostingLogic.Post(glPosting);
                    glPostingLogic.DebitAccount(accountConfig.MainGL, customerAccount.COTCharge);
                    customerAccount.COTCharge = 0;
                    customerAccountLogic.UpdateCOTCharge(customerAccount);
                }
            }
        }

        double CalculatePrincipalInstalment(LoanAccount loanAccount)
        {
            double instalment = loanAccount.LoanAmount/loanAccount.LoanPeriod;
            return instalment;
        }

        double CalculateInterest(double amount, double rate)
        {
            double interest  = amount * rate/(100*365);
            return interest;
        }

        public EOD GetByID(int id)
        {
            EODDAO eoddao = new EODDAO();
            //EOD eod = eoddao.GetByID(id);
            return new EOD { FinancialDate=DateTime.Now};
        }

        public void Insert(EOD eod)
        {
            EODDAO eoddao = new EODDAO();
            eoddao.Insert(eod);
        }

        public void UpdateEOD(EOD eod)
        {
            EODDAO eoddao = new EODDAO();
            eoddao.UpdateEOD(eod);
        }
    }
}