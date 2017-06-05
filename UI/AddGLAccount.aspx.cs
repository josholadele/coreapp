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
    public partial class AddGLAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User myUser = (User)Session["User"];
            if (myUser.UserRole == UserRole.Regular.ToString())
            {
                addGLAccount.Visible = false;
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "message",
                    "<script type='text/javascript'>alertify.alert('Message', '" + "You do not have permission to view this page!" +
                    "', function(){location = '/Dashboard.aspx';});</script>", false);
            }
            else 
            {
                if (!IsPostBack) 
                { 
                BranchLogic myBranchLogic = new BranchLogic();
                List<Branch> myBranch = myBranchLogic.GetBranch();

                branch.DataSource = myBranch;
                branch.DataBind();

                GLCategoryLogic glCategoryLogic = new GLCategoryLogic();
                List<GLCategory> glCategories = glCategoryLogic.GetGLCategories();
                glcategory.DataSource = glCategories;
                glcategory.DataBind();

                }
            }
        }

        protected void back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Dashboard.aspx");
        }

        protected void addaccount_Click(object sender, EventArgs e)
        {
            try
            {

                if (glcategory.SelectedIndex == 0 || branch.SelectedIndex == 0)
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "message",
                        "<script type='text/javascript'>alertify.alert('Message', '" + "Please fill all options" +
                        "');</script>", false);
                }
                else 
                {
                    GLAccount glAccount = new GLAccount();
                    GLAccountLogic glAccountLogic = new GLAccountLogic();
                    GLCategory glCategory = new GLCategory();
                    GLCategoryLogic glCategoryLogic = new GLCategoryLogic();
                    glCategory = glCategoryLogic.GetByName(glcategory.SelectedValue);
                    Branch myBranch = new Branch();
                    BranchLogic myBranchLogic = new BranchLogic();
                    myBranch = myBranchLogic.GetByName(branch.SelectedValue);


                    glAccount.Name = name.Text;
                    glAccount.GLCategory = glCategory;
                    glAccount.Branch = myBranch;
                    glAccount.AccountCode = glAccountLogic.GenerateAccountCode(glAccount);

                    glAccountLogic.AddGLAccount(glAccount);
                    if (!Page.ClientScript.IsClientScriptBlockRegistered(this.GetType(), "message"))
                    {
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "message",
                            "<script type='text/javascript'>alertify.alert('Message', '" + "General Ledger Account Added!" +
                            "', function(){location = '/AddGLAccount.aspx';});</script>", false);
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
    }
}