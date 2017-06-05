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
    public partial class ViewTellers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                TillAssignLogic tillAssignLogic = new TillAssignLogic();
                List<TillAssign> tillAssigns = tillAssignLogic.GetTillAccounts();

                if (searchbyteller.Text != string.Empty)
                {
                    tillAssigns =
                        tillAssigns.Where(
                            x =>
                                x.Teller.Username.ToLower().Contains(searchbyteller.Text.ToLower().Trim())).ToList();
                }
                if (searchbytill.Text != string.Empty)
                {
                    tillAssigns =
                        tillAssigns.Where(
                            x =>
                                x.Till.Name.ToLower().Contains(searchbytill.Text.ToLower().Trim())).ToList();
                }

                tellertable.DataSource = tillAssigns;
                tellertable.DataBind();
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