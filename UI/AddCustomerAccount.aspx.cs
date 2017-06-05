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
    public partial class AddCustomerAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BranchLogic myBranchLogic = new BranchLogic();
            List<Branch> myBranch = myBranchLogic.GetBranch();
            CustomerLogic myCustomerLogic = new CustomerLogic();
            List<Customer> myCustomers = myCustomerLogic.GetCustomers();

            customer.DataSource = myCustomers;
            customer.DataBind();
            branch.DataSource = myBranch;
            branch.DataBind();
            accountType.DataSource = Enum.GetNames(typeof(AccountType));
            accountType.DataBind();
        }

        protected void addcustomer_Click(object sender, EventArgs e)
        {
            try
            {

                CustomerAccount customerAccount = new CustomerAccount();
                Customer myCustomer = new Customer();
                CustomerLogic myCustomerLogic = new CustomerLogic();
                CustomerAccountLogic myCustomerAccountLogic = new CustomerAccountLogic();
                Branch myBranch;
                BranchLogic myBranchLogic = new BranchLogic();
                myBranch = myBranchLogic.GetByName(branch.Text);

                myCustomer = myCustomerLogic.GetByName(customer.Text);
                customerAccount.Customer = myCustomer;
                customerAccount.AccountName = fullname.Text;
                customerAccount.Branch = myBranch;
                customerAccount.AccountType = (AccountType)Enum.Parse(typeof(AccountType), accountType.SelectedValue); ;
                customerAccount.Customer.CustomerID = myCustomer.CustomerID;
                customerAccount.AccountNumber = myCustomerAccountLogic.GenerateAccountNumber(customerAccount);
                myCustomerAccountLogic.CreateAccount(customerAccount);

                if (!Page.ClientScript.IsClientScriptBlockRegistered(this.GetType(), "message"))
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "message",
                        "<script type='text/javascript'>alertify.alert('Message', '" + "General Ledger Category Added!" +
                        "', function(){location = '/AddCustomerAccount.aspx';});</script>", false);
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

        protected void back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Dashboard.aspx");
        }
    }
}