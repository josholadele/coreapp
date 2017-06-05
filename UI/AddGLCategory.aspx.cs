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
    public partial class AddGLCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User myUser = (User)Session["User"];
            if (myUser.UserRole == UserRole.Regular.ToString())
            {
                addGLCategory.Visible = false;
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "message",
                    "<script type='text/javascript'>alertify.alert('Message', '" +
                    "You do not have permission to view this page!" +
                    "', function(){location = '/Dashboard.aspx';});</script>", false);
            }
            else
            {
                accountcategory.DataSource = Enum.GetNames(typeof (AccountCategory));
                accountcategory.DataBind();
            }
        }

        protected void addGL_Click(object sender, EventArgs e)
        {
            try
            {
                GLCategory glCategory = new GLCategory();
                GLCategoryLogic myGlCategoryLogic = new GLCategoryLogic();



                glCategory.Name = name.Value;
                glCategory.AccountCategory = (AccountCategory) Enum.Parse(typeof(AccountCategory), accountcategory.SelectedValue);//accountcategory.SelectedValue;
                glCategory.Description = description.Text;
            
                myGlCategoryLogic.AddGLCategory(glCategory);
                if (!Page.ClientScript.IsClientScriptBlockRegistered(this.GetType(), "message"))
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "message",
                        "<script type='text/javascript'>alertify.alert('Message', '" + "General Ledger Category Added!" +
                        "', function(){location = '/AddGLCategory.aspx';});</script>", false);
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
            Response.Redirect("Dashboard.aspx");
        }
    }
}