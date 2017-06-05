using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBA.Core
{
    public class Enums
    {
       
  }

    public enum UserRole
    {
        Regular, Admin
    }

    public enum Gender
    {
        Male, Female
    }
    public enum AccountType
    {
        Savings=1, Current, Loan
    }

    public enum AccountCategory
    {
        Asset=1, Liability, Capital, Income, Expense
    }

    public enum TransactionType
    {
        Deposit,Withdrawal
    }
}
