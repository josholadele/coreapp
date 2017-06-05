using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CBA.Core;
using CBA.Data;

namespace CBA.Logic
{
    public class GLAccountLogic
    {
        public string GenerateAccountCode(GLAccount glAccount)
        {
            int firstNumber = (int)glAccount.GLCategory.AccountCategory;
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(firstNumber);
            Random rng = new Random();
            stringBuilder.Append(0);
            stringBuilder.Append(0);
            for (int i = 0; i < 4; i++)
            {
                stringBuilder.Append(rng.Next(10));
            }
            string accountCode = stringBuilder.ToString();
            return accountCode;
        }

        public void AddGLAccount(GLAccount glAccount)
        {
            GLAccountDAO glAccountDao = new GLAccountDAO();
            glAccountDao.Insert(glAccount);
        }

        public void GetBalance(string name)
        {
            GLAccountDAO glAccountDao = new GLAccountDAO();
            glAccountDao.GetByName(name);
        }

        public List<GLAccount> GetGlAccounts()
        {
            GLAccountDAO glAccountDao = new GLAccountDAO();
            List<GLAccount> glAccounts = glAccountDao.GetAll();
            return glAccounts;
        }
        public List<GLAccount> GetUnAssignedGls()
        {
            GLAccountDAO glAccountDao = new GLAccountDAO();
            List<GLAccount> glAccounts = glAccountDao.GetUnAssignedGls();
            return glAccounts;
        }

        public List<GLAccount> GetAssetGls()
        {
            GLAccountDAO glAccountDao = new GLAccountDAO();
            List<GLAccount> glAccounts = glAccountDao.GetAssets();
            return glAccounts;
        }
        public List<GLAccount> GetIncomeGls()
        {
            GLAccountDAO glAccountDao = new GLAccountDAO();
            List<GLAccount> glAccounts = glAccountDao.GetIncomes();
            return glAccounts;
        }
        public List<GLAccount> GetExpenseGls()
        {
            GLAccountDAO glAccountDao = new GLAccountDAO();
            List<GLAccount> glAccounts = glAccountDao.GetExpenses();
            return glAccounts;
        }
        public List<GLAccount> GetLiabilityGls()
        {
            GLAccountDAO glAccountDao = new GLAccountDAO();
            List<GLAccount> glAccounts = glAccountDao.GetLiabilities();
            return glAccounts;
        }
        public List<GLAccount> GetCapitalGls()
        {
            GLAccountDAO glAccountDao = new GLAccountDAO();
            List<GLAccount> glAccounts = glAccountDao.GetCapital();
            return glAccounts;
        }

        public GLAccount GetByName(string name)
        {
            GLAccountDAO myGlAccountDao = new GLAccountDAO();

            GLAccount myGlAccount = myGlAccountDao.GetByName(name);
            return myGlAccount;
        }
        public GLAccount GetByID(int number)
        {
            GLAccountDAO myGlAccountDao = new GLAccountDAO();
            GLAccount myGlAccount = myGlAccountDao.GetByID(number);
            return myGlAccount;
        }

        public void UpdateBalance(GLAccount glAccount)
        {
            GLAccountDAO glAccountDao = new GLAccountDAO();
            glAccountDao.UpdateBalance(glAccount);
        }
    }
}
