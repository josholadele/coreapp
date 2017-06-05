using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void NewUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddUser.aspx");
            //Server.Transfer("AddUser.aspx", true);
        }

        protected void ViewUsers_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewUsers.aspx");
            //Server.Transfer("ViewUsers.aspx", true);
        }

        protected void AddBranch_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddBranch.aspx");
            //Server.Transfer("AddBranch.aspx", true);
        }
        protected void ViewBranch_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewBranch.aspx");
        }
    }
}