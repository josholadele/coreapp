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
    public partial class ViewTellerPostings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                TellerPostingLogic tellerPostingLogic = new TellerPostingLogic();
                List<CBA.Core.TellerPosting> tellerPostings = tellerPostingLogic.GetTellerPostings();
                if (!IsPostBack)
                {
                    searchbytxntype.DataSource = Enum.GetNames(typeof(TransactionType));
                    searchbytxntype.DataBind();
                }
                if (searchbycustomeraccount.Text != string.Empty)
                {
                    tellerPostings =
                        tellerPostings.Where(
                            x =>
                                x.CustomerAccount.AccountName.ToLower().Contains(searchbycustomeraccount.Text.ToLower().Trim()) ||
                                x.CustomerAccount.AccountNumber.ToLower().Contains(searchbycustomeraccount.Text.ToLower().Trim())).ToList();
                }
                if (searchbytill.Text != string.Empty)
                {
                    tellerPostings =
                        tellerPostings.Where(
                            x =>
                                x.Till.Name.ToLower().Contains(searchbytill.Text.ToLower().Trim())).ToList();
                }
                if (searchbytxntype.Text != string.Empty)
                {
                    tellerPostings =
                        tellerPostings.Where(
                            x =>
                                x.TransactionType.ToString().ToLower().Contains(searchbytxntype.Text.ToLower().Trim())).ToList();
                }
                tellerpostingtable.DataSource = tellerPostings;
                tellerpostingtable.DataBind();
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