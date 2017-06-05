using System;
using System.Collections.Generic;
using CBA.Core;
using CBA.Logic;
using System.Web.Security;


namespace UI
{
    public partial class AddUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User myUser = (User)Session["User"];
            if (myUser != null)
            {
                if ( myUser.UserRole == UserRole.Regular.ToString())
                { 
                User_.Visible = false;
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "message",
                    "<script type='text/javascript'>alertify.alert('Message', '" + "You do not have permission to view this page!" +
                    "', function(){location = '/Dashboard.aspx';});</script>", false);
                }
                else
                {
                    User_.Visible = true;
                    BranchLogic myBranchLogic = new BranchLogic();
                    List<Branch> myBranch = myBranchLogic.GetBranch();

                    branch.DataSource = myBranch;
                    branch.DataBind();

                    if (!IsPostBack)
                    {
                        gender.DataSource = Enum.GetNames(typeof(Gender));
                        gender.DataBind();
                        userrole.DataSource = Enum.GetNames(typeof(UserRole));
                        userrole.DataBind();
                    }
                }
            }
            

        }

        protected void adduser_Click(object sender, EventArgs e)
        {
            try
            {

                User user = new User();
                UserLogic myUserLogic = new UserLogic();
                Branch myBranch;
                BranchLogic myBranchLogic = new BranchLogic();
                myBranch = myBranchLogic.GetByName(branch.Text);
                user.Branch = myBranch;

                string password = Membership.GeneratePassword(12, 1);
                user.Password = password;
                user.FirstName = firstname.Value;
                user.LastName = lastname.Value;

                user.Gender = gender.Text;
                user.UserRole = userrole.Text;
                user.Email = email.Text;
                user.PhoneNumber = phonenumber.Text;
                user.Username = username.Text;
                //myUserLogic.SendMail(user);
                user.Password = myUserLogic.EncryptPassword(password);
                user.Password = "05af28558ea02dee13b97d145eeaeb";
                myUserLogic.AddUser(user);
                //alert.Visible = true;

                if (!Page.ClientScript.IsClientScriptBlockRegistered(this.GetType(), "message"))
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "message",
                        "<script type='text/javascript'>alertify.alert('Message', '" +
                        "User Saved Successfully. Check mail for log in details" +
                        "', function(){location = '/AddUser.aspx';});</script>", false);
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

        protected void close_button_Click(object sender, EventArgs e)
        {

            Response.Redirect("~/AddUser.aspx");
        }
    }
}