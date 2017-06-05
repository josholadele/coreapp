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
    public partial class TellerPosting : System.Web.UI.Page
    {
         
        User myUser = new User();
        static EODLogic eodLogic = new EODLogic();
        static CBA.Core.EOD eod = eodLogic.GetByID(1);

        DateTime ValidDate = eod.FinancialDate.Date;
        protected void Page_Load(object sender, EventArgs e)
        {

            EODLogic eodLogic = new EODLogic();
            CBA.Core.EOD eod= new CBA.Core.EOD();
            eod = eodLogic.GetByID(1);
            
            if (eod.BusinessIsOpen)
            {
                UserLogic userLogic = new UserLogic();
                //User myUser = new User();
                myUser = (User)Session["User"];



                if (!IsPostBack)
                {
                    CustomerAccountLogic customerAccountLogic = new CustomerAccountLogic();
                    List<CustomerAccount> myCustomerAccounts = customerAccountLogic.GetCustomerAccounts();
                    accountNumber.DataSource = myCustomerAccounts;
                    accountNumber.DataBind();
                    txnType.DataSource = Enum.GetNames(typeof (TransactionType));
                    txnType.DataBind();
                }
            }
            else if (eod.BusinessIsOpen == false)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "message",
                            "<script type='text/javascript'>alertify.alert('Message', '" + "Business is currently closed" +
                            "', function(){location = '/Dashboard.aspx';});</script>", false);
                return;
            }

        }

        protected void back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Dashboard.aspx");
        }
        protected void verify_Click(object sender, EventArgs e)
        {
            CustomerAccount customerAccount = new CustomerAccount();
            CustomerAccountLogic customerAccountLogic = new CustomerAccountLogic();
            customerAccount = customerAccountLogic.GetByAccountNumber(accountNumber.Text);

            //customer.Enabled = false;
            customer.Text = customerAccount.AccountName;
        }
        protected void post_Click(object sender, EventArgs e)
        {
            try
            {
                ServerValidate();


                CBA.Core.TellerPosting tellerPosting = new CBA.Core.TellerPosting();
                CustomerAccount customerAccount = new CustomerAccount();
                CustomerAccountLogic myCustomerLogic = new CustomerAccountLogic();
                TillAssign tillAssign = new TillAssign();
                TillAssignLogic tillAssignLogic = new TillAssignLogic();

                customerAccount = myCustomerLogic.GetByAccountNumber(accountNumber.Text);

                tellerPosting.CustomerAccount = customerAccount;
                tellerPosting.Amount = double.Parse(amount.Text);
                tellerPosting.TransactionType = (TransactionType) Enum.Parse(typeof (TransactionType), txnType.SelectedValue);
                tellerPosting.Narration = narration.Text;
                tellerPosting.TransactionDate = ValidDate;

                try
                    {
                         if (myUser.IsTeller)
                            {
                                GLAccount Till = new GLAccount();
                                GLAccountLogic glAccountLogic = new GLAccountLogic();
                                tillAssign = tillAssignLogic.GetTillByTellerID(myUser.ID);
                                Till = glAccountLogic.GetByID(tillAssign.Till.ID);
                                tellerPosting.Till = Till;
                            }
                    }
                catch (Exception ex)
                    {
                       //throw ex.Message;
                    }

                if (customerAccount.IsClosed == false)
                {
                    TellerPostingLogic tellerPostingLogic = new TellerPostingLogic();
                    GLPostingLogic glPostingLogic = new GLPostingLogic();
                    AccountConfigLogic accountConfigLogic = new AccountConfigLogic();
                    //Select Transaction Type
                    if (txnType.SelectedValue == "Withdrawal")
                    {
                        CBA.Core.AccountConfig accountConfig_ = accountConfigLogic.GetByAccountType(customerAccount.AccountType);
                        bool accountbalance=tellerPostingLogic.CheckSufficientBalance(customerAccount.Balance, accountConfig_.MinimumBalance, tellerPosting.Amount);
                        //bool tillbalance = tellerPostingLogic.CheckSufficientBalance(tillAssign.Balance, tellerPosting.Amount);
                        if (accountbalance==false)
                        {
                                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "message",
                            "<script type='text/javascript'>alertify.alert('Message', '" + "Insufficient Balance in Customer Account" +
                            "', function(){});</script>", false);
                            return;
                        }
                        //if (accountbalance == false)
                        //{
                        //    Response.Write("Insufficient balance in customer's account");
                        //    return;
                        //}
                        //if (tillbalance == false)
                        //{
                        //    Response.Output.Write("Insufficient balance in till account");
                        
                        //}
                        if (customerAccount.AccountType == AccountType.Current)
                            {
                            
                                CBA.Core.AccountConfig accountConfig = accountConfigLogic.GetByID(2);

                                double cotCharge = (accountConfig.COT*tellerPosting.Amount)/100;

                                customerAccount.COTCharge += cotCharge;
                                myCustomerLogic.UpdateCOTCharge(customerAccount);
                            }

                        tellerPostingLogic.Post(tellerPosting);
                        tellerPostingLogic.DebitAccount(customerAccount,tellerPosting.Amount);
                        tellerPostingLogic.CreditAccount(tillAssign.Till,tellerPosting.Amount);

                        CBA.Core.GLPosting glPosting = new CBA.Core.GLPosting();
                        glPosting.Amount = tellerPosting.Amount;
                        glPosting.AccountToCredit = tillAssign.Till;
                        CBA.Core.AccountConfig accountConfig1 = accountConfigLogic.GetByID((int)customerAccount.AccountType);
                        glPosting.AccountToDebit = accountConfig1.MainGL;
                        glPosting.Narration = string.Format("Withdrawal from {0}",customerAccount.AccountNumber);
                        glPosting.TransactionDate = tellerPosting.TransactionDate;
                        glPostingLogic.Post(glPosting);
                        glPostingLogic.DebitAccount(accountConfig1.MainGL, tellerPosting.Amount);
                    }
                
                    if (txnType.SelectedValue == "Deposit")
                    {
                        tellerPostingLogic.Post(tellerPosting);

                        tellerPostingLogic.CreditAccount(customerAccount, tellerPosting.Amount);
                        tellerPostingLogic.DebitAccount(tillAssign.Till, tellerPosting.Amount);

                        CBA.Core.GLPosting glPosting = new CBA.Core.GLPosting();
                        glPosting.Amount = tellerPosting.Amount;
                        glPosting.AccountToDebit = tillAssign.Till;
                        CBA.Core.AccountConfig accountConfig1 = accountConfigLogic.GetByID((int)customerAccount.AccountType);
                        glPosting.AccountToCredit = accountConfig1.MainGL;
                        glPosting.Narration = string.Format("Deposit into {0}", customerAccount.AccountNumber);
                        glPosting.TransactionDate = tellerPosting.TransactionDate;
                        glPostingLogic.Post(glPosting);
                        glPostingLogic.CreditAccount(accountConfig1.MainGL, tellerPosting.Amount);
                    }

                    if (!Page.ClientScript.IsClientScriptBlockRegistered(this.GetType(), "message"))
                    {
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "message",
                            "<script type='text/javascript'>alertify.alert('Message', '" + "Transaction Posted Successfully!" +
                            "', function(){location = '/TellerPosting.aspx';});</script>", false);
                    }


                }
                else if (customerAccount.IsClosed)
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "message",
                            "<script type='text/javascript'>alertify.alert('Message', '" + "Customer Account is closed" +
                            "', function(){});</script>", false);
                    return;
                }
            }

            catch (Exception ex)
            {
                string errorMessage = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
                if (!Page.ClientScript.IsClientScriptBlockRegistered(this.GetType(), "message"))
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "message",
                        @"<script type='text/javascript'>alertify.alert('Message', """ +
                        errorMessage.Replace("\n", "").Replace("\r", "") + @""", function(){});</script>", false);
                }
                //return error message here
                //Response.Write("<script type='text/javascript'>alertify.alert('Message', '" + ex.Message + "', function(){location = '/';});</script>");
            }
        }

        protected void ServerValidate()
        {
            if (string.IsNullOrWhiteSpace(accountNumber.Text))
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "message",
                          "<script type='text/javascript'>alertify.alert('Message', '" + "Select Account Nummber!" +
                          "', function(){});</script>", false);
                return;
            }
            if (string.IsNullOrWhiteSpace(customer.Text))
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "message",
                          "<script type='text/javascript'>alertify.alert('Message', '" + "Customer Name cannot be empty!" +
                          "', function(){});</script>", false);
                return;
            }
            if (string.IsNullOrWhiteSpace(txnType.Text) || txnType.SelectedIndex == 0)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "message",
                          "<script type='text/javascript'>alertify.alert('Message', '" + "Select Transaction Type!" +
                          "', function(){});</script>", false);
                return;
            }
            if (string.IsNullOrWhiteSpace(amount.Text))
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "message",
                          "<script type='text/javascript'>alertify.alert('Message', '" + "Select Transaction Amount!" +
                          "', function(){});</script>", false);
                return;
            }
            if (string.IsNullOrWhiteSpace(narration.Text))
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "message",
                          "<script type='text/javascript'>alertify.alert('Message', '" + "Kindly add a narration!" +
                          "', function(){});</script>", false);
                return;
            }
        }
    }
}