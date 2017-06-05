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
    public partial class EditGLAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BranchLogic myBranchLogic = new BranchLogic();
                List<Branch> myBranch = myBranchLogic.GetBranch();

                branch.DataSource = myBranch;
                branch.DataBind();
                if (Request.QueryString["GLAccountID"] != null)
                {
                    GLAccount glAccount = new GLAccount();
                    GLAccountLogic glAccountLogic = new GLAccountLogic();
                    int x = int.Parse(Request.QueryString["GLAccountID"]);
                    glAccount = glAccountLogic.GetByID(int.Parse(Request.QueryString["GLAccountID"]));
                    name.Text = glAccount.Name;
                    branch.SelectedValue = glAccount.Branch.Name;
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