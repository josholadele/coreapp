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
    public partial class EOD : System.Web.UI.Page
    {
        static EODLogic eodLogic = new EODLogic();
        CBA.Core.EOD eod = eodLogic.GetByID(1);
        
        
        protected void Page_Load(object sender, EventArgs e)
        {
            User myUser = (User)Session["User"];
            if (myUser !=null)
            {
                if (myUser.UserRole == UserRole.Regular.ToString())
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "message",
                        "<script type='text/javascript'>alertify.alert('Message', '" +
                        "You do not have permission to view this page!" +
                        "', function(){location = '/Dashboard.aspx';});</script>", false);
                    return;
                }
                else
                {
                    if (eod.BusinessIsOpen)
                    {
                        EOD_close.Visible = true;
                    }
                    else if (eod.BusinessIsOpen == false)
                    {
                        EOD_open.Visible = true;
                    }
                }

            }
        }

        protected void close_Click(object sender, EventArgs e)
        {
            //EODLogic eodLogic = new EODLogic();
            eod = eodLogic.GetByID(1);

            if (eod.BusinessIsOpen)
            {
                eodLogic.CloseBusiness();
                EOD_close.Visible = false;
                EOD_open.Visible = true;
                //eodLogic.RunEOD();
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "message",
                        "<script type='text/javascript'>alertify.alert('Message', '" +
                        "Business is currently closed!" +
                        "', function(){});</script>", false);
            }
        }

        protected void open_Click(object sender, EventArgs e)
        {
            if (eod.BusinessIsOpen == false)
            {
                eodLogic.OpenBusiness();
                EOD_open.Visible = false;
                EOD_close.Visible = true;
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "message",
                        "<script type='text/javascript'>alertify.alert('Message', '" +
                        "Business is currently closed!" +
                        "', function(){});</script>", false);
            }
        }
    }
}