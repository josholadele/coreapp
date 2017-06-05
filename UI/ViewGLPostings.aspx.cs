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
    public partial class ViewGLPostings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                GLPostingLogic glCategoryLogic = new GLPostingLogic();
                List<CBA.Core.GLPosting> glCategories = glCategoryLogic.GetGLPostings();
                if (searchbydebit.Text != string.Empty)
                {
                    glCategories =
                        glCategories.Where(
                            x =>
                                x.AccountToDebit.Name.ToLower().Contains(searchbydebit.Text.ToLower().Trim())).ToList();
                }
                if (searchbycredit.Text != string.Empty)
                {
                    glCategories =
                        glCategories.Where(
                            x =>
                                x.AccountToCredit.Name.ToLower().Contains(searchbycredit.Text.ToLower().Trim())).ToList();
                }
                glpostingtable.DataSource = glCategories;
                glpostingtable.DataBind();
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

        protected void grdView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //FillGrid();
            glpostingtable.PageIndex = e.NewPageIndex;
            glpostingtable.DataBind();
        }

        protected void glpostingtable_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            glpostingtable.PageIndex = e.NewPageIndex;
            glpostingtable.DataBind();
        }
    }
}