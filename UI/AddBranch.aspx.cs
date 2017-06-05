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
    public partial class AddBranch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                if(string.IsNullOrWhiteSpace(branchname.Text))
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "message",
                          "<script type='text/javascript'>alertify.alert('Message', '" + "Branch name can not be empty" +
                          "', function(){});</script>", false);
                    return;
                }
                if (string.IsNullOrWhiteSpace(address.Text))
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "message",
                          "<script type='text/javascript'>alertify.alert('Message', '" + "Branch address can not be empty" +
                          "', function(){});</script>", false);
                    return;
                }

                Branch branch = new Branch();
                BranchLogic myBranchLogic = new BranchLogic();

                branch.Address = address.Text;
                branch.Name = branchname.Text;

                myBranchLogic.AddBranch(branch);
                alert.Visible = true;
                if (!Page.ClientScript.IsClientScriptBlockRegistered(this.GetType(), "message"))
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "message",
                        "<script type='text/javascript'>alertify.alert('Message', '" + "Branch added successfully!" +
                        "', function(){location = '/AddBranch.aspx';});</script>", false);
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