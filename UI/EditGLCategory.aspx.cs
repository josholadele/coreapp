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
    public partial class EditGLCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BranchLogic myBranchLogic = new BranchLogic();
                List<Branch> myBranch = myBranchLogic.GetBranch();

                //branch.DataSource = myBranch;
                //branch.DataBind();
                if (Request.QueryString["GLCategoryID"] != null)
                {
                    GLCategory glCategory = new GLCategory();
                    GLCategoryLogic glCategoryLogic = new GLCategoryLogic();
                    int x = int.Parse(Request.QueryString["GLCategoryID"]);
                    glCategory = glCategoryLogic.GetByID(int.Parse(Request.QueryString["GLCategoryID"]));
                    name.Text = glCategory.Name;
                    description.Text = glCategory.Description;

                }
        }
    }

        protected void back_Click(object sender, EventArgs e)
        {

        }

        protected void edit_Click(object sender, EventArgs e)
        {

        }
    }
}