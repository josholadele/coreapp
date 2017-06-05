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
    public partial class AddATMTerminal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void back_Click(object sender, EventArgs e)
        {

        }

        protected void addterminal_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name.Value))
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "message",
                          "<script type='text/javascript'>alertify.alert('Message', '" + "Terminal name can not be empty" +
                          "', function(){});</script>", false);
                    return;
                }
                if (string.IsNullOrWhiteSpace(terminalID.Value))
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "message",
                          "<script type='text/javascript'>alertify.alert('Message', '" + "Terminal ID can not be empty" +
                          "', function(){});</script>", false);
                    return;
                }
                if (string.IsNullOrWhiteSpace(location.Text))
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "message",
                          "<script type='text/javascript'>alertify.alert('Message', '" + "Location can not be empty" +
                          "', function(){});</script>", false);
                    return;
                }
                ATMTerminal atmTerminal = new ATMTerminal();
                ATMTerminalLogic myAtmTerminalLogic = new ATMTerminalLogic();

                atmTerminal.Name = name.Value;
                atmTerminal.TerminalID = terminalID.Value;
                atmTerminal.Location = location.Text;

                myAtmTerminalLogic.Insert(atmTerminal);
                if (!Page.ClientScript.IsClientScriptBlockRegistered(this.GetType(), "message"))
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "message",
                        "<script type='text/javascript'>alertify.alert('Message', '" + "ATM Terminal added successfully!" +
                        "', function(){location = '/AddATMTerminal.aspx';});</script>", false);
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
}