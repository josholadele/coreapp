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
    public partial class EditUser : System.Web.UI.Page
    {
        
       public int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BranchLogic myBranchLogic = new BranchLogic();
                List<Branch> myBranch = myBranchLogic.GetBranch();

                branch.DataSource = myBranch;
                branch.DataBind();
                if (Request.QueryString["UserID"] != null)
                {
                    id = int.Parse(Request.QueryString["UserID"]);
                    User user = new User();
                    UserLogic userLogic = new UserLogic();
                    int x = int.Parse(Request.QueryString["UserID"]);
                    user = userLogic.GetByID(int.Parse(Request.QueryString["UserID"]));
                    firstname.Text = user.FirstName;
                    lastname.Text = user.LastName;
                    email.Text = user.Email;
                    phonenumber.Text = user.PhoneNumber;
                    intt.Text = x.ToString();
                    //Username = user.Username;
                    branch.SelectedValue = user.Branch.Name;

                }
            }

            
            
        }

        protected void save_Click(object sender, EventArgs e)
        {
            try
            {

                UserLogic myUserLogic = new UserLogic();
                User user = myUserLogic.GetByID(int.Parse(intt.Text));
                Branch myBranch;
                BranchLogic myBranchLogic = new BranchLogic();
                myBranch = myBranchLogic.GetByName(branch.SelectedValue);
                user.Branch = myBranch;
                user.FirstName = firstname.Text;
                user.LastName = lastname.Text;
                user.Email = email.Text;
                user.PhoneNumber = phonenumber.Text;
                user.Branch = myBranch;
                //user.ID = user.ID;

                myUserLogic.UpdateUser(user);
                Response.Redirect("ViewUsers.aspx");
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

        }
    }
}