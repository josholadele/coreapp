using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CBA.Core;
using CBA.Data;

namespace CBA.Logic
{
    public class AccountConfigLogic
    {
        public AccountConfig GetByAccountType(AccountType accountType)
        {
            AccountConfigDAO accountConfigDao = new AccountConfigDAO();
            AccountConfig accountConfig = accountConfigDao.GetByAccountType(accountType.ToString());
            return accountConfig;
        }
        public AccountConfig GetByID(int number)
        {
            AccountConfigDAO accountConfigDao = new AccountConfigDAO();
            AccountConfig accountConfig = accountConfigDao.GetByID(number);
            return accountConfig;
        }

        public void SaveConfigUpdate(AccountConfig accountConfig)
        {
            AccountConfigDAO accountConfigDao = new AccountConfigDAO();
             accountConfigDao.UpdateConfig(accountConfig);
        }
    }
}
