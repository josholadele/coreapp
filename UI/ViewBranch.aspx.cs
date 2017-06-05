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
    public partial class ViewBranch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        
            try
            {
                BranchLogic branchLogic = new BranchLogic();
                List<Branch> branches = branchLogic.GetBranch();

                if (searchbyname.Text != string.Empty)
                {
                    branches =
                        branches.Where(
                            x =>
                                x.Name.ToLower().Contains(searchbyname.Text.ToLower().Trim())).ToList();
                }

                branchtable.DataSource = branches;
                branchtable.DataBind();
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