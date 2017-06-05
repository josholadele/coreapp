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
    public partial class ViewUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
               Bind(); 
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
            }
        }

        protected void Bind()
        {
            UserLogic myUserLogic = new UserLogic();
           List<User> myUsers = myUserLogic.GetUsers();
            BranchLogic branchLogic = new BranchLogic();
            if (!IsPostBack) { 
            searchbybranch.DataSource = branchLogic.GetBranch();
            searchbybranch.DataBind();
            }
            if (searchbyname.Text != string.Empty)
            {
                myUsers =
                    myUsers.Where(
                        x =>
                            x.LastName.ToLower().Contains(searchbyname.Text.ToLower().Trim()) ||
                            x.FirstName.ToLower().Contains(searchbyname.Text.ToLower().Trim())).ToList();
            }
            if (searchbybranch.Text != string.Empty)
            {
                myUsers =
                    myUsers.Where(
                        x =>
                            x.Branch.Name.ToLower().Contains(searchbybranch.Text.ToLower().Trim())).ToList();
            }


            usertable.DataSource = myUsers;
            usertable.DataBind();
        }
    }
}