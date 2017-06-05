using System;
using System.Web.UI;
using CBA.Core;
using CBA.Logic;

namespace UI
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["Logout"] != null)
            {
                Session["User"] = null;
            }
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            try
            {
                User myUser = new User();
                myUser.Username = username.Text;
                myUser.Password = password.Text;
                UserLogic myUserLogic = new UserLogic();
            
                myUser.Password = myUserLogic.EncryptPassword(password.Text);
                bool verify = myUserLogic.VerifyLogin(ref myUser);
                //Session["User"] = myUser;
                //Response.Redirect("~/Dashboard.aspx");
                if (verify)
                {
                    Session["User"] = myUser;
                    Response.Redirect("~/Dashboard.aspx");
                } //, true); }
                else
                {

                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "message",
                        "<script type='text/javascript'>alertify.alert('Message', '" + "Invalid Details. Try Again!" +
                        "', function(){location = '/Default.aspx';});</script>", false);
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