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
    public partial class GLPosting : System.Web.UI.Page
    {
        static EODLogic eodLogic = new EODLogic();
        static CBA.Core.EOD eod = eodLogic.GetByID(1);

        DateTime ValidDate = eod.FinancialDate.Date;
        protected void Page_Load(object sender, EventArgs e)
        {
            EODLogic eodLogic = new EODLogic();
            CBA.Core.EOD eod = new CBA.Core.EOD();
            
            eod = eodLogic.GetByID(1);
            if(eod.BusinessIsOpen)
            { 
            GLAccountLogic myGLAccountLogic = new GLAccountLogic();
            List<GLAccount> myGlAccounts = myGLAccountLogic.GetGlAccounts();

            craccount.DataSource = myGlAccounts;
            craccount.DataBind();   
            draccount.DataSource = myGlAccounts;
            draccount.DataBind();
            }
        }

       protected void post_Click(object sender, EventArgs e)
        {
           try
           {
                CBA.Core.GLPosting glPosting = new CBA.Core.GLPosting();
                GLPostingLogic glPostingLogic = new GLPostingLogic();
                GLAccount crAccount;
                GLAccount drAccount;
                GLAccountLogic myBranchLogic = new GLAccountLogic();
                crAccount = myBranchLogic.GetByName(craccount.Text);
                drAccount = myBranchLogic.GetByName(draccount.Text);

                glPosting.AccountToCredit = crAccount;
                glPosting.AccountToDebit = drAccount;
                glPosting.Amount = double.Parse(amount.Text);
                glPosting.Narration = narration.Text;
                glPosting.TransactionDate=ValidDate;

                glPostingLogic.Post(glPosting);
                glPostingLogic.CreditAccount(crAccount, glPosting.Amount);
                glPostingLogic.DebitAccount(drAccount, glPosting.Amount);

                if (!Page.ClientScript.IsClientScriptBlockRegistered(this.GetType(), "message"))
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "message",
                        "<script type='text/javascript'>alertify.alert('Message', '" + "General Ledger Posting Successful!" +
                        "', function(){location = '/GLPosting.aspx';});</script>", false);
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

        }
    }
}