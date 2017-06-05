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
    public partial class ViewCustomerAccounts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                CustomerAccountLogic myCustomerAccountLogic = new CustomerAccountLogic();
                List<CustomerAccount> myCustomers = myCustomerAccountLogic.GetCustomerAccounts();

                if (searchbycustomer.Text != string.Empty)
                {
                    myCustomers =
                        myCustomers.Where(
                            x =>
                                x.Customer.Name.ToLower().Contains(searchbycustomer.Text.ToLower().Trim())).ToList();
                }
                if (searchbyaccountname.Text != string.Empty)
                {
                    myCustomers =
                        myCustomers.Where(
                            x =>
                                x.AccountName.ToLower().Contains(searchbyaccountname.Text.ToLower().Trim())).ToList();
                }

                foreach (var customer in myCustomers)
                {
                   customer.Balance = double.Parse(string.Format("{0:f2}", customer.Balance));
                }

                
                accountstable.DataSource = myCustomers;
                accountstable.DataBind();
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