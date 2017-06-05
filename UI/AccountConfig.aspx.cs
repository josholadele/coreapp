using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CBA.Core;
using CBA.Logic;

namespace UI
{
    public partial class AccountConfig : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            CBA.Core.AccountConfig accountConfig;
            AccountConfigLogic accountConfigLogic = new AccountConfigLogic();

            GLAccountLogic glAccountLogic = new GLAccountLogic();
            List<GLAccount> glAccounts = glAccountLogic.GetGlAccounts();

            expenseGl.DataSource = glAccounts;
            expenseGl.DataBind();
            cotGl.DataSource = glAccounts;
            cotGl.DataBind();
            incomeGl.DataSource = glAccounts;
            incomeGl.DataBind();

            if (!IsPostBack)
            {
                int x = int.Parse(Request.QueryString["ConfigID"]);

                if (Request.QueryString["ConfigID"] != null && int.Parse(Request.QueryString["ConfigID"]) == 1)
                {

                    accountConfig = accountConfigLogic.GetByID(1);

                    savingsAcc.Visible = true;
                    crInterest.Text = accountConfig.CrInterestRate.ToString();
                    minbalance.Text = accountConfig.MinimumBalance.ToString();
                    expenseGl.SelectedValue = accountConfig.InterestExpenseGL.Name;



                }
                if (Request.QueryString["ConfigID"] != null && int.Parse(Request.QueryString["ConfigID"]) == 2)
                {
                    accountConfig = accountConfigLogic.GetByID(2);

                    savingsAcc.Visible = true;
                    currentAcc.Visible = true;
                    crInterest.Text = accountConfig.CrInterestRate.ToString();
                    minbalance.Text = accountConfig.MinimumBalance.ToString();
                    expenseGl.SelectedValue = accountConfig.InterestExpenseGL.Name;
                    cot.Text = accountConfig.COT.ToString();
                    cotGl.SelectedValue = accountConfig.COTIncomeGL.Name;
                    ;

                }

                if (Request.QueryString["ConfigID"] != null && int.Parse(Request.QueryString["ConfigID"]) == 3)
                {
                    accountConfig = accountConfigLogic.GetByID(3);
                    drInterest.Text = accountConfig.DrInterestRate.ToString();
                    incomeGl.SelectedValue = accountConfig.InterestIncomeGL.Name;
                    loanAcc.Visible = true;
                }

                intt.Text = x.ToString();
            }
        }

        protected void back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Dashboard.aspx");
        }

        protected void edit_Click(object sender, EventArgs e)
        {
            EditButton.Visible = false;
            SaveButton.Visible = true;
            crInterest.ReadOnly = false;
            savingsAcc.Enabled = true;
            currentAcc.Enabled = true;
            loanAcc.Enabled = true;
        }
        protected void save_Click(object sender, EventArgs e)
        {
            try
            {

               int x = int.Parse(intt.Text);

                CBA.Core.AccountConfig accountConfig = new CBA.Core.AccountConfig();
                AccountConfigLogic accountConfigLogic = new AccountConfigLogic();
                GLAccountLogic glAccountLogic = new GLAccountLogic();

                switch (x)
                {
                    case 1:
                        accountConfig.CrInterestRate = double.Parse(crInterest.Text);
                        accountConfig.MinimumBalance = double.Parse(minbalance.Text);
                        accountConfig.AccountType = AccountType.Savings;
                        accountConfig.InterestExpenseGL = glAccountLogic.GetByName(expenseGl.SelectedValue);
                        accountConfigLogic.SaveConfigUpdate(accountConfig);
                        break;
                    case 2:
                        accountConfig.CrInterestRate = double.Parse(crInterest.Text);
                        accountConfig.MinimumBalance = double.Parse(minbalance.Text);
                        accountConfig.COT = double.Parse(cot.Text);
                        accountConfig.AccountType = AccountType.Current;
                        accountConfig.InterestExpenseGL = glAccountLogic.GetByName(expenseGl.SelectedValue);
                        accountConfig.COTIncomeGL = glAccountLogic.GetByName(cotGl.SelectedValue);
                        accountConfigLogic.SaveConfigUpdate(accountConfig);
                        break;
                    case 3:
                        accountConfig.DrInterestRate = double.Parse(drInterest.Text);
                        accountConfig.AccountType = AccountType.Loan;
                        accountConfig.InterestIncomeGL = glAccountLogic.GetByName(incomeGl.SelectedValue);
                        accountConfigLogic.SaveConfigUpdate(accountConfig);

                        break;
                }
                if (!Page.ClientScript.IsClientScriptBlockRegistered(this.GetType(), "message"))
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "message",
                        "<script type='text/javascript'>alertify.alert('Message', '" + "Account Configuration successfully updated!" +
                        "', function(){location = '/Dashboard.aspx';});</script>", false);
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
    }
}