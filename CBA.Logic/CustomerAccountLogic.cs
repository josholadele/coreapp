using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CBA.Core;
using CBA.Data;

namespace CBA.Logic
{
    public class CustomerAccountLogic
    {
        public string GenerateAccountNumber(CustomerAccount customerAccount)
        {
           
            //int branchID = customerAccount.Branch.ID;
            //int idLength = branchID.ToString().Length;
            //int addZero = 3 - idLength;
            //int firstNumber = (int)AccountType.Savings;
            int firstNumber = (int)customerAccount.AccountType;

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(firstNumber);
            Random rng = new Random();
            StringBuilder CustomerIDbuilder = new StringBuilder();
            for (int i = 0; i < 4; i++)
            {
                stringBuilder.Append(rng.Next(10));
            }
            stringBuilder.Append(0);
            stringBuilder.Append(customerAccount.Customer.CustomerID);
            string accountNumber = stringBuilder.ToString();
            return accountNumber;
        }

        public void CreateAccount(CustomerAccount customerAccount)
        {
            CustomerAccountDAO customerAccountDao = new CustomerAccountDAO();
            customerAccountDao.AddAccount(customerAccount);
        }

        public List<CustomerAccount> GetCustomerAccounts()
        {
            CustomerAccountDAO customerAccountDao = new CustomerAccountDAO();
            List<CustomerAccount> customerAccounts = new List<CustomerAccount>();
            customerAccounts = customerAccountDao.GetAll();
            return customerAccounts;
        }

        public CustomerAccount GetByAccountNumber(string accountNumber)
        {
            CustomerAccountDAO customerAccountDao = new CustomerAccountDAO();
            var customerAccount = customerAccountDao.GetByName(accountNumber);
            return customerAccount;
        }

        public void UpdateBalance(CustomerAccount customerAccount)
        {

            CustomerAccountDAO customerAccountDao = new CustomerAccountDAO();
            customerAccountDao.UpdateBalance(customerAccount);
            
        }

        public void UpdateCOTCharge(CustomerAccount customerAccount)
        {
            CustomerAccountDAO customerAccountDao = new CustomerAccountDAO();
            customerAccountDao.UpdateCOTCharge(customerAccount);
        }
    }
}
