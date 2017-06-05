using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using CBA.Core;
using CBA.Logic;

namespace UI.Pages
{
    public partial class AddUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void adduser_Click(object sender, EventArgs e)
        {
            User user = new User();
            UserLogic myUserLogic = new UserLogic();

            string password = Membership.GeneratePassword(12, 1);
            user.FirstName = firstname.Text;
            user.LastName = lastname.Text;
            //user.Branch = branch.Text;
            user.Email = email.Text;
            user.PhoneNumber = phonenumber.Text;
            user.Username = username.Text;
            user.Password = password;
            myUserLogic.AddUser(user);
        }
    }
}