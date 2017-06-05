using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CBA.Core;
using CBA.Data;

namespace CBA.Logic
{
    public class TillAccountLogic
    {
        public void AddTill(TillAccount till)
        {
            TillAccountDAO myTillAccountDao = new TillAccountDAO();
            myTillAccountDao.InsertTill(till);
        }

        public List<TillAccount> GetTillAccounts()
        {
            TillAccountDAO myTillAccountDao = new TillAccountDAO();
            List<TillAccount> tillAccounts = myTillAccountDao.GetAll();
            return tillAccounts;
        }
    }
}
