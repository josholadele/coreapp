using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CBA.Core;
using CBA.Logic;

namespace UI
{
    public partial class CreateLoanAccount : System.Web.UI.Page
    {
        static EODLogic eodLogic = new EODLogic();
        static CBA.Core.EOD eod = eodLogic.GetByID(1);

        DateTime ValidDate = eod.FinancialDate.Date;
        protected void Page_Load(object sender, EventArgs e)
        {

            

            Session["CurrentDate"] = DateTime.Now.ToShortDateString();
            Session["FinancialDate"] = eod.FinancialDate.ToShortDateString();
            CustomerAccountLogic myCustomerAccountLogic = new CustomerAccountLogic();
            List<CustomerAccount> myCustomerAccounts = myCustomerAccountLogic.GetCustomerAccounts();

            myCustomerAccounts = myCustomerAccounts.Where(x => x.IsClosed == false).ToList();
            

            accountNumber.DataSource = myCustomerAccounts;
            accountNumber.DataBind();
            eod = eodLogic.GetByID(1);

            if (eod.BusinessIsOpen == false)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "message",
                    "<script type='text/javascript'>alertify.alert('Message', '" + "Business is currently closed!" +
                    "', function(){location = '/Dashboard.aspx';});</script>", false);
            }

        }

        protected void verify_Click(object sender, EventArgs e)
        {
            //CustomerAccount customerAccount = new CustomerAccount();
            CustomerAccountLogic customerAccountLogic = new CustomerAccountLogic();
            CustomerAccount customerAccount = customerAccountLogic.GetByAccountNumber(accountNumber.Text);

            //customername.Enabled = false;
            customername.Text = customerAccount.AccountName;

        }

        protected void back_Click(object sender, EventArgs e)
        {

        }

        protected void createloan_Click(object sender, EventArgs e)
        {
            LoanAccount loanAccount = new LoanAccount();
            AccountConfigLogic accountConfigLogic = new AccountConfigLogic();
            CBA.Core.AccountConfig accountConfig = accountConfigLogic.GetByID(3);
            LoanAccountLogic loanAccountLogic = new LoanAccountLogic();

            CustomerAccountLogic myCustomerLogic = new CustomerAccountLogic();
            CustomerAccount customerAccount = myCustomerLogic.GetByAccountNumber(accountNumber.Text);
            loanAccount.LinkedAccount = customerAccount;
            loanAccount.LoanAmount = double.Parse(loanamount.Text);
            loanAccount.LoanPeriod = int.Parse(loanperiod.Text);
            DateTime today = DateTime.Now;
            loanAccount.LoanStartDate =ValidDate;
            loanAccount.LoanDueDate =ValidDate.AddDays(loanAccount.LoanPeriod);
            
            loanAccount.LoanInterest = accountConfig.DrInterestRate;
            loanAccount.AccountNumber = loanAccountLogic.GenerateLoanAccountNumber(loanAccount);
            loanAccount.Balance = loanAccount.LoanAmount;
            loanAccountLogic.CreateLoan(loanAccount);

            TellerPostingLogic myTellerPostingLogic = new TellerPostingLogic();
            myTellerPostingLogic.CreditAccount(customerAccount,loanAccount.LoanAmount);


            GLPostingLogic glPostingLogic = new GLPostingLogic();
            CBA.Core.GLPosting glPosting = new CBA.Core.GLPosting();
            glPosting.Amount = loanAccount.LoanAmount;
            glPosting.AccountToDebit = accountConfig.MainGL;
            CBA.Core.AccountConfig accountConfig1 = accountConfigLogic.GetByID((int)customerAccount.AccountType);
            glPosting.AccountToCredit = accountConfig1.MainGL;
            glPosting.Narration = string.Format("Loan Transaction to Account Number: {0}", customerAccount.AccountNumber);
            glPosting.TransactionDate = ValidDate;
            glPostingLogic.Post(glPosting);
            




            if (!Page.ClientScript.IsClientScriptBlockRegistered(this.GetType(), "message"))
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "message",
                    "<script type='text/javascript'>alertify.alert('Message', '" + "Loan Account Created Successfully!" +
                    "', function(){location = '/CreateLoanAccount.aspx';});</script>", false);
            }

        }
    }
}