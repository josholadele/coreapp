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
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void changepassword_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(oldpassword.Text))
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "message",
                            "<script type='text/javascript'>alertify.alert('Message', '" + "Input current password!" +
                            "', function(){});</script>", false);
                    return;
                }
                if (string.IsNullOrWhiteSpace(newpassword.Text))
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "message",
                            "<script type='text/javascript'>alertify.alert('Message', '" + "Input new password!" +
                            "', function(){});</script>", false);
                    return;
                }
                if (string.IsNullOrWhiteSpace(confirmnewpassword.Text))
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "message",
                              "<script type='text/javascript'>alertify.alert('Message', '" + "Confirm new password!" +
                              "', function(){});</script>", false);
                    return;
                }
                if (newpassword.Text != confirmnewpassword.Text)
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "message",
                              "<script type='text/javascript'>alertify.alert('Message', '" + "Passwords do not match. Please check and try again!" +
                              "', function(){});</script>", false);
                    return;
                }
                User myUser = (User) Session["User"];
                UserLogic userLogic = new UserLogic();
                myUser.Password = userLogic.EncryptPassword(confirmnewpassword.Text);
                if (userLogic.UpdatePassword(myUser))
                {
                    if (!Page.ClientScript.IsClientScriptBlockRegistered(this.GetType(), "message"))
                    {
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "message",
                            "<script type='text/javascript'>alertify.alert('Message', '" + "Password Changed Successfully. Kndly log in with your new password" +
                            "', function(){location = '/Default.aspx';});</script>", false);
                    }
                
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