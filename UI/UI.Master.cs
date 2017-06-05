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
    public partial class UI : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            EODLogic eodLogic = new EODLogic();
            CBA.Core.EOD eod = eodLogic.GetByID(1);
            Session["EOD"] = eod;
            
            Session["CurrentDate"] = DateTime.Now.ToShortDateString();
            Session["FinancialDate"] = eod.FinancialDate.ToShortDateString();


            User myUser = (User)Session["User"];
            if (myUser == null)
            {
                Response.Redirect("Default.aspx");
            }
            if (myUser != null)
            {
                Session["Username"] = myUser.Username;
                //Session["Branch"] = myUser.Branch;
            }
            //UserLogic userLogic = new UserLogic();
            //User myUser = userLogic.GetByName("osimpson");
            //user.Text = myUser.Username;
        }

        protected void logOut_Click(object sender, EventArgs e)
        {
            //Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "message",
            //            "<script type='text/javascript'>alertify.alert('Message', '" + "Are you sure you want to log out?" +
            //            "', function(){location = '/Default.aspx';});</script>", false);

            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "message",
                        "<script type='text/javascript'>alertify.confirm('Message', '" +"This is a confirm dialog."+"',function(){alertify.success('Yes');},function(){alertify.error('Cancel');});</script>", false);
            
            
            Session["User"] = null;
        }

        protected void LinkButton_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "message",
                        "<script type='text/javascript'>alertify.confirm('Message', '" + "This is a confirm dialog." + "',function(){alertify.success('Yes');},function(){alertify.error('Cancel');});</script>", false);
            
            
        }
    }
}