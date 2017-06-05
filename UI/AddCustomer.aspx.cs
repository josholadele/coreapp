using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using CBA.Core;
using CBA.Logic;

namespace UI
{
    public partial class AddCustomer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BranchLogic myBranchLogic = new BranchLogic();


            //accountType.DataSource = Enum.GetNames(typeof(AccountType));
            //accountType.DataBind();
           
            if (!IsPostBack)
            {
                gender.DataSource = Enum.GetNames(typeof(Gender));
                gender.DataBind();
            }
            
                
            
        }


        protected void addcustomer_Click(object sender, EventArgs e)
        {
            try
            {

            
                Customer customer = new Customer();
                CustomerLogic myCustomerLogic = new CustomerLogic();


           
                customer.Name = fullname.Value;
                customer.Address = address.Text;
                customer.Gender = gender.Text;
                customer.Email = email.Text;
                customer.PhoneNumber = phonenumber.Text;
                customer.CustomerID = myCustomerLogic.GenerateID();
                myCustomerLogic.CreateCustomer(customer);
                //Response.Redirect("AddCustomer.aspx");
                if (!Page.ClientScript.IsClientScriptBlockRegistered(this.GetType(), "message"))
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "message",
                        "<script type='text/javascript'>alertify.alert('Message', '" + "General Ledger Category Added!" +
                        "', function(){location = '/AddCustomer.aspx';});</script>", false);
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

        protected void testbutton_OnServerClick(object sender, EventArgs e)
        {
        }
    }
}