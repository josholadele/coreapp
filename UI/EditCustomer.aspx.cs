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
    public partial class EditCustomer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                gender.DataSource = Enum.GetNames(typeof(Gender));
                gender.DataBind();
                

                if (Request.QueryString["CustomerID"] != null)
                {
                    Customer customer = new Customer();
                    CustomerLogic customerLogic = new CustomerLogic();
                    int x = int.Parse(Request.QueryString["CustomerID"]);
                    customer = customerLogic.GetByID(int.Parse(Request.QueryString["CustomerID"]));
                    fullname.Text = customer.Name;
                    address.Text = customer.Address;
                    email.Text = customer.Email;
                    phonenumber.Text = customer.PhoneNumber;
                    gender.SelectedValue = customer.Gender;
                    intt.Text = x.ToString();
                    //Username = user.Username;
                    //gender.SelectedValue = customer.Gender;

                }
            }

        }

        protected void save_Click(object sender, EventArgs e)
        {
            try
            {
                CustomerLogic myCustomerLogic = new CustomerLogic();
                Customer customer = myCustomerLogic.GetByID(int.Parse(intt.Text));
                customer.Name = fullname.Text;
                customer.Email = email.Text;
                customer.PhoneNumber = phonenumber.Text;
                customer.Address = address.Text;
                customer.Gender = gender.SelectedValue;
                customer.ID = customer.ID;

                myCustomerLogic.UpdateCustomer(customer);
                if (!Page.ClientScript.IsClientScriptBlockRegistered(this.GetType(), "message"))
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "message",
                        "<script type='text/javascript'>alertify.alert('Message', '" + "Customer successfully edited!" +
                        "', function(){location = '/ViewCustomers.aspx';});</script>", false);
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

        }
    }
}