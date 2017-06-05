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
    public partial class CloseAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CustomerAccountLogic myCustomerAccountLogic = new CustomerAccountLogic();
            List<CustomerAccount> myCustomers = myCustomerAccountLogic.GetCustomerAccounts();
            accountNumber.DataSource = myCustomers;
            accountNumber.DataBind();
        }

        protected void verify_Click(object sender, EventArgs e)
        {
            if (accountNumber.Text == null)
            {
                
            }//CustomerAccount customerAccount = new CustomerAccount();
            CustomerAccountLogic customerAccountLogic = new CustomerAccountLogic();
            CustomerAccount customerAccount = customerAccountLogic.GetByAccountNumber(accountNumber.Text);

            //customername.Enabled = false;
            customername.Text = customerAccount.AccountName;
            balance.Text = String.Format("{0:f2}", customerAccount.Balance);
            if (customerAccount.IsClosed)
            accountStatus.Text = "Closed";
            else
            {
                accountStatus.Text = "Open";
            }
        }

        protected void back_Click(object sender, EventArgs e)
        {

        }

        protected void close_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(customername.Text))
            {
                return;
            }
            Close_Account.Text = "Open Account";
            accountStatus.Text = "Closed";
        }
    }
}