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
    public partial class AssignTill : System.Web.UI.Page
    {
      protected void Page_Load(object sender, EventArgs e)
        {
          User myUser = (User)Session["User"];
            
            if (!IsPostBack)
            {
                try
                {
                    if (myUser.UserRole == UserRole.Regular.ToString())
                    {
                            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "message",
                        "<script type='text/javascript'>alertify.alert('Message', '" +
                        "You do not have permission to view this page!" +
                        "', function(){location = '/Dashboard.aspx';});</script>", false);
                    }
                    else
                    { 
                        UserLogic myUserLogic = new UserLogic();
                        List<User> myUsers = myUserLogic.GetUsers();
                        TillAssignLogic tillAssignLogic = new TillAssignLogic();
                        //List<TillAssign> myTillAccounts = tillAssignLogic.GetTillAccounts();
                        GLAccountLogic glAccountLogic = new GLAccountLogic();
                        List<GLAccount> glAccounts = glAccountLogic.GetUnAssignedGls();

                        glAccounts = glAccounts.Where(x => x.GLCategory.Name == "Till Cash Assets").ToList();
                        myUsers = myUsers.Where(x => x.IsTeller == false).ToList();
                        user.DataSource = myUsers;
                        user.DataBind();
                        till.DataSource = glAccounts;
                        till.DataBind();
                        //user.DataSource = Enum.GetNames(typeof(AccountType));
                        //user.DataBind();

                        //if (!IsPostBack)
                        //{
                        //    till.DataSource = Enum.GetNames(typeof(Gender));
                        //    till.DataBind();
                        //}
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
                }
        }
    }

        protected void assign_Click(object sender, EventArgs e)
        {
            try
            {
                GLAccountLogic glAccountLogic = new GLAccountLogic();
                UserLogic userLogic = new UserLogic();
                TillAssignLogic tillAssignLogic = new TillAssignLogic();


            if (user.SelectedIndex == 0 ||till.SelectedIndex == 0)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "message",
                    "<script type='text/javascript'>alertify.alert('Message', '" + "Please fill all options" +
                    "');</script>", false);
            }
            else
            {
                GLAccount tillAccount = glAccountLogic.GetByName(till.SelectedValue);
                User myUser = userLogic.GetByName(user.SelectedValue);

                if (tillAssignLogic.CheckIfTellerExists(myUser.ID))
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "message",
                    "<script type='text/javascript'>alertify.alert('Message', '" + "User is already assigned to a till" +
                    "');</script>", false);

                }
                else if (tillAssignLogic.CheckIfTillExists(tillAccount.ID))
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "message",
                    "<script type='text/javascript'>alertify.alert('Message', '" + "Till is already assigned to a user" +
                    "');</script>", false);

                }
                else
                { 
                    List<GLAccount> glAccounts = glAccountLogic.GetGlAccounts();
                    TillAssign tillAssign = new TillAssign();
                    


                    tillAssign.Teller = myUser;

                    tillAssign.Till = tillAccount;

                    tillAssign.IsAssigned = true;
                    myUser.IsTeller = true;
                    userLogic.SetTeller(myUser);

            

                    tillAssignLogic.AddTill(tillAssign);
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

        protected void back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Dashboard.aspx");
        }
    }
}