using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CBA.Core;
using CBA.Data;

namespace CBA.Logic
{
    public class FinancialReportLogic
    {
        public DataTable GetTrialBalance(DateTime from,DateTime to)
        {
            DataTable table = new DataTable();
            table.Columns.AddRange(new DataColumn[3]
            {
                new DataColumn("Name"),
                new DataColumn("Debit (Dr)"),
                new DataColumn("Credit (Cr)")
            });
            GLPostingLogic glPostingLogic = new GLPostingLogic();
            GLAccountLogic glAccountLogic = new GLAccountLogic();
            List<GLPosting> glPostings = glPostingLogic.GetGLPostings();
            List<GLAccount> glAccounts = glAccountLogic.GetGlAccounts();
            double totalDebit = 0, totalCredit = 0;


            foreach (var glAccount in glAccounts)
            {
                var drPosts = GetDrGLPostingsByDate(glAccount.ID, from, to);
                var crPosts = GetCrGLPostingsByDate(glAccount.ID, from, to);

                double total = 0;
                if (drPosts != null)
                {
                    foreach (var post in drPosts)
                    {
                        if (glAccount.GLCategory.AccountCategory == AccountCategory.Asset ||
                            glAccount.GLCategory.AccountCategory == AccountCategory.Expense)
                        {
                            total += post.Amount;
                        }
                        else
                        {
                            total -= post.Amount;
                        }
                    }
                }
                if (crPosts != null)
                {
                    foreach (var post in crPosts)
                    {
                        if (glAccount.GLCategory.AccountCategory == AccountCategory.Asset ||
                            glAccount.GLCategory.AccountCategory == AccountCategory.Expense)
                        {
                            total -= post.Amount;
                        }
                        else
                        {
                            total += post.Amount;
                        }
                    }
                }
                if (glAccount.GLCategory.AccountCategory == AccountCategory.Asset ||
                    glAccount.GLCategory.AccountCategory == AccountCategory.Expense)
                {
                    double total_ = double.Parse(string.Format("{0:f2}", total));
                    table.Rows.Add(glAccount.Name, total_);
                    totalDebit += total;

                }
                else
                {
                    double total_ = double.Parse(string.Format("{0:f2}", total));
                    table.Rows.Add(glAccount.Name, "", total_);
                    totalCredit += total;
                }
            }

            table.Rows.Add();
            double totalDebit_ = double.Parse(string.Format("{0:f2}", totalDebit));
            double totalCredit_ = double.Parse(string.Format("{0:f2}", totalCredit));
            table.Rows.Add("Total", totalDebit_, totalCredit_);
            return table;
        }

        public DataTable GetProfitAndLoss(DateTime from, DateTime to)
        {
            GLAccountLogic glAccountLogic = new GLAccountLogic();
            List<GLAccount> incomesList = glAccountLogic.GetIncomeGls();
            List<GLAccount> expensesList = glAccountLogic.GetExpenseGls();


            double totalExpense = 0, totalIncome = 0;

            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[3]
            {
                new DataColumn("Name"),
                new DataColumn("Debit (Dr)"),
                new DataColumn("Credit (Cr)")
            });

            dt.Rows.Add("Income");
            //double  = 0;
            foreach (var income in incomesList)
            {
                var drPosts = GetDrGLPostingsByDate(income.ID, from, to);
                var crPosts = GetCrGLPostingsByDate(income.ID, from, to);

                double incomeBalance = 0;
                if (drPosts != null)

                {
                    foreach (var post in drPosts)
                    {
                        incomeBalance -= post.Amount;
                    }
                }
                if (crPosts != null)

                {
                    foreach (var post in crPosts)
                    {
                        incomeBalance += post.Amount;
                    }
                }
                double incomeBalance_ = double.Parse(string.Format("{0:f2}", incomeBalance));
                dt.Rows.Add(income.Name,"", incomeBalance_);
                totalIncome = totalIncome + incomeBalance;
            }


            dt.Rows.Add("", "", "");


            dt.Rows.Add("Expense");
            //double expenseBalance = 0;
            foreach (var expense in expensesList)
            {

                var drPosts = GetDrGLPostingsByDate(expense.ID, from, to);
                var crPosts = GetCrGLPostingsByDate(expense.ID, from, to);

                double expenseBalance = 0;
                if(drPosts != null)
                { 
                    foreach (var post in drPosts)
                    {
                        expenseBalance += post.Amount;
                    }
                }
                if (crPosts != null)
                {
                    foreach (var post in crPosts)
                    {
                        expenseBalance -= post.Amount;
                    }
                }
                double expenseBalance_ = double.Parse(string.Format("{0:f2}", expenseBalance));
                dt.Rows.Add(expense.Name, expenseBalance_);
                totalExpense = totalExpense + expenseBalance;

            }

            dt.Rows.Add("", "", "");

            double pandL = totalIncome - totalExpense;
            if (pandL >= 0)
            {
                double pandL_ = double.Parse(string.Format("{0:f2}", pandL));
                dt.Rows.Add("Net Profit", "", pandL_);

            }
            else if (pandL < 0)
            {
                double pandL_ = double.Parse(string.Format("{0:f2}", pandL));
                dt.Rows.Add("Net Loss", pandL_);
            }
            return dt;

        }

        public DataTable GetBalanceSheet(DateTime from, DateTime to)
        {
            GLPostingLogic glPostingLogic = new GLPostingLogic();
            List<GLPosting> glPostings = glPostingLogic.GetGLPostings();
            GLAccountLogic glAccountLogic = new GLAccountLogic();
            List<GLAccount> assetsList = glAccountLogic.GetAssetGls();
            List<GLAccount> glAccounts = glAccountLogic.GetGlAccounts();
            List<GLAccount> liabilitiesList = glAccountLogic.GetLiabilityGls();
            List<GLAccount> capitalList = glAccountLogic.GetCapitalGls();
            double totalAssets = 0, totalLiabilities = 0, totalCapital = 0;

            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[3]
            {
                new DataColumn("Name"),
                new DataColumn("Debit (Dr)"),
                new DataColumn("Credit (Cr)")
            });

            dt.Rows.Add("Assets");
            double cashBalance = 0;


            foreach (var asset in assetsList)
            {
                var drPosts = GetDrGLPostingsByDate(asset.ID, from, to);
                var crPosts = GetCrGLPostingsByDate(asset.ID, from, to);

                double total = 0;
                if (asset.GLCategory.Name == "Cash Assets")
                {
                    if (drPosts != null)
                    {
                        foreach (var post in drPosts)
                        {
                            cashBalance += post.Amount;
                        }
                    }
                    if (crPosts != null)
                    {
                        foreach (var post in crPosts)
                        {
                            cashBalance -= post.Amount;
                        }
                    }
                }
            }
            totalAssets += cashBalance;
            cashBalance = double.Parse(string.Format("{0:f2}", cashBalance));
            
            dt.Rows.Add("Cash", cashBalance);

            foreach (var asset in assetsList)
            {
                var drPosts = GetDrGLPostingsByDate(asset.ID, from, to);
                var crPosts = GetCrGLPostingsByDate(asset.ID, from, to);

                double total = 0;

                if (asset.GLCategory.Name != "Cash Assets")
                {
                    if (drPosts != null)
                    {
                        foreach (var post in drPosts)
                        {
                            total += post.Amount;
                        }
                    }
                    if (crPosts != null)
                    {
                        foreach (var post in crPosts)
                        {
                            total -= post.Amount;

                        }
                    }
                    totalAssets += total;
                    total = double.Parse(string.Format("{0:f2}", total));

                dt.Rows.Add(asset.Name, total);
            }
        }
            totalAssets = double.Parse(string.Format("{0:f2}", totalAssets));
            dt.Rows.Add("Total", totalAssets);
            dt.Rows.Add("", "", "");
            dt.Rows.Add("Liabilities");


            foreach (var liability in liabilitiesList)
            {
                var drPosts = GetDrGLPostingsByDate(liability.ID, from, to);
                var crPosts = GetCrGLPostingsByDate(liability.ID, from, to);

                double total = 0;
                if (drPosts != null)
                {
                    foreach (var post in drPosts)
                    {
                        total -= post.Amount;

                    }
                }
                if (crPosts != null)
                {
                    foreach (var post in crPosts)
                    {
                        total += post.Amount;
                    }
                }
                double total_ = double.Parse(string.Format("{0:f2}", total));
                dt.Rows.Add(liability.Name, "", total_);
                totalLiabilities = totalLiabilities + total;

            }


            dt.Rows.Add("", "", "");
            dt.Rows.Add("Capital");

            totalCapital = totalLiabilities;
            if (capitalList != null)
            {
                foreach (var capital in capitalList)
                {
                    var drPosts = GetDrGLPostingsByDate(capital.ID, from, to);
                    var crPosts = GetCrGLPostingsByDate(capital.ID, from, to);

                    double total = 0;
                    if (drPosts != null)
                    {
                        foreach (var post in drPosts)
                        {
                            total -= post.Amount;

                        }

                    }
                    if (crPosts != null)
                    {
                        foreach (var post in crPosts)
                        {
                            total += post.Amount;
                        }
                    }
                    double total_ = double.Parse(string.Format("{0:f2}", total));
                    dt.Rows.Add(capital.Name, "", total_);
                    totalCapital = totalCapital + total;

                }
            }
            
            List<GLAccount> incomesList = glAccountLogic.GetIncomeGls();
            List<GLAccount> expensesList = glAccountLogic.GetExpenseGls();


            double totalExpense = 0, totalIncome = 0;
            foreach (var income in incomesList)
            {
                var drPosts = GetDrGLPostingsByDate(income.ID, from, to);
                var crPosts = GetCrGLPostingsByDate(income.ID, from, to);

                double incomeBalance = 0;
                if (drPosts != null)
                {
                    foreach (var post in drPosts)
                    {
                        incomeBalance -= post.Amount;
                    }
                }
                if (crPosts != null)
                {
                    foreach (var post in crPosts)
                    {
                        incomeBalance += post.Amount;
                    }
                }
                totalIncome = totalIncome + incomeBalance;
            }


            //double expenseBalance = 0;
            foreach (var expense in expensesList)
            {

                var drPosts = GetDrGLPostingsByDate(expense.ID, from, to);
                var crPosts = GetCrGLPostingsByDate(expense.ID, from, to);

                double expenseBalance = 0;
                if (drPosts != null)
                {
                    foreach (var post in drPosts)
                    {
                        expenseBalance += post.Amount;
                    }
                }
                if (crPosts != null)
                {
                    foreach (var post in crPosts)
                    {
                        expenseBalance -= post.Amount;
                    }
                }
                totalExpense = totalExpense + expenseBalance;

            }

            double pandL = totalIncome - totalExpense;
            if (pandL >= 0)
            {
                double pandL_ = double.Parse(string.Format("{0:f2}", pandL));
                dt.Rows.Add("Net Profit", "", pandL_);
                totalCapital += pandL;

            }
            else if (pandL < 0)
            {
                double pandL_ = double.Parse(string.Format("{0:f2}", pandL));
                dt.Rows.Add("Net Loss", pandL_);
                totalCapital -= pandL;
            }

            dt.Rows.Add("", "", "");
            double totalCapital_ = double.Parse(string.Format("{0:f2}", totalCapital));
            dt.Rows.Add("Total", "", totalCapital_);

            return dt;

            /*foreach (var glAccount in glAccounts)
            {
                double total = 0;
                foreach (var glPosting in glPostings)
                {
                    if (glPosting.AccountToDebit.ID == glAccount.ID)
                    {
                        if (glAccount.GLCategory.Name == "Cash Assets")
                        {
                            dt.Rows.Add(glAccount.Name, glPosting.Amount);
                            cashBalance += glPosting.Amount;
                        }
                    }
                    else if (glPosting.AccountToCredit.ID == glAccount.ID)
                    {
                        if (glAccount.GLCategory.Name == "Cash Assets")
                        {
                            dt.Rows.Add(glAccount.Name, glPosting.Amount);
                            cashBalance -= glPosting.Amount;
                        }
                    }
                }
                foreach (var asset in assetsList)
                {
                    if (asset.GLCategory.Name == "Cash Assets")
                    {
                        cashBalance = cashBalance + asset.Balance;
                        totalAssets = totalAssets + asset.Balance;
                    }

                }
                dt.Rows.Add("Cash", cashBalance);
                foreach (var asset in assetsList)
                {
                    if (asset.GLCategory.Name != "Cash Assets")
                    {
                        dt.Rows.Add(asset.Name, asset.Balance);
                        totalAssets = totalAssets + asset.Balance;
                    }

                }
                dt.Rows.Add("Total", totalAssets);
                dt.Rows.Add("", "", "");
                dt.Rows.Add("Liabilities");


                foreach (var liability in liabilitiesList)
                {
                    dt.Rows.Add(liability.Name, "", liability.Balance);
                    totalLiabilities = totalLiabilities + liability.Balance;

                }


                dt.Rows.Add("", "", "");
                dt.Rows.Add("Capital");

                totalCapital = totalLiabilities;
                if (capitalList != null)
                {
                    foreach (var capital in capitalList)
                    {
                        dt.Rows.Add(capital.Name, "", capital.Balance);
                        totalCapital = totalCapital + capital.Balance;

                    }
                }
                dt.Rows.Add("", "", "");
                dt.Rows.Add("Total", "", totalCapital);
            }*/
        }

        public List<GLPosting> GetDrGLPostingsByDate(int accountID, DateTime from, DateTime to)
        {
            FinancialReportDAO financialReportDao = new FinancialReportDAO();
            List<GLPosting> glPostings = financialReportDao.GetDrGLPostingsByDate(accountID, from, to);
            return glPostings;
        }
        public List<GLPosting> GetCrGLPostingsByDate(int accountID, DateTime from, DateTime to)
        {
            FinancialReportDAO financialReportDao = new FinancialReportDAO();
            List<GLPosting> glPostings = financialReportDao.GetCrGLPostingsByDate(accountID, from, to);
            return glPostings;
        }

        public List<GLPosting> GetDrGLPostings(int accountID)
        {

            FinancialReportDAO financialReportDao = new FinancialReportDAO();
            List<GLPosting> glPostings = financialReportDao.GetDrGLPostings(accountID);
            return glPostings;
        }
        public List<GLPosting> GetCrGLPostings(int accountID)
        {
            FinancialReportDAO financialReportDao = new FinancialReportDAO();
            List<GLPosting> glPostings = financialReportDao.GetCrGLPostings(accountID);
            return glPostings;
        }
    }
}