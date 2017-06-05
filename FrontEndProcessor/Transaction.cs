using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEndProcessor
{
    public class Transaction
    {

        private List<string> rr = AllowedTransactions_1();
        private double withdrawalFee = GetWithdrawalFee();
        public List<string> AllowedTransactions
        {
            //List<string> rr = AllowedTransactions_1();
            get { return rr; }
        }
        public double WithdrwalFee
        {
            //List<string> rr = AllowedTransactions_1();
            get { return withdrawalFee; }
        }

        private static double GetWithdrawalFee()
        {
            double fee = double.Parse(System.Configuration.ConfigurationManager.AppSettings["WithdrawalFee"]);
            return fee;
        }
        private static List<string> AllowedTransactions_1()
        {
            List<string> allowedTransactions = new List<string>();
            allowedTransactions.Add(System.Configuration.ConfigurationManager.AppSettings["Withdrawal"]);
            allowedTransactions.Add(System.Configuration.ConfigurationManager.AppSettings["BalanceEnquiry"]);
            allowedTransactions.Add(System.Configuration.ConfigurationManager.AppSettings["Payment"]);
            allowedTransactions.Add(System.Configuration.ConfigurationManager.AppSettings["Reversal"]);
            return allowedTransactions;
        }
    }
}
