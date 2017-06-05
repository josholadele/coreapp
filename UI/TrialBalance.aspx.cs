using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CBA.Core;
using CBA.Logic;

namespace UI
{
    public partial class TrialBalance : System.Web.UI.Page
    {
        DateTime from = Convert.ToDateTime("2014/03/01");
        DateTime to = Convert.ToDateTime("2020/03/01");
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                FinancialReportLogic financialReportLogic = new FinancialReportLogic();
           
                DataTable dataTable = new DataTable();
                dataTable.Columns.AddRange(new DataColumn[3] { new DataColumn("Name"), 
                                new DataColumn("Debit (Dr)"), 
                                new DataColumn("Credit (Cr)") });

                dataTable = financialReportLogic.GetTrialBalance(from,to);

                balancetable.DataSource = dataTable;
                balancetable.DataBind();
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

        protected void balancetable_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            
            if (e.Row.Cells[0].Text.Contains("Total"))
            {
                e.Row.Font.Bold = true;
                e.Row.Cells[1].Font.Underline = true;
                e.Row.Cells[2].Font.Underline = true;
            }
            
            
       }


        protected void onGo_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(dateFrom.Text))
                {
                    from = Convert.ToDateTime(dateFrom.Text);
                }

                if (!string.IsNullOrWhiteSpace(dateTo.Text))
                {
                    to = Convert.ToDateTime(dateTo.Text);
                }

                FinancialReportLogic financialReportLogic = new FinancialReportLogic();

                DataTable dataTable = new DataTable();
                dataTable.Columns.AddRange(new DataColumn[3]
                {
                    new DataColumn("Name"),
                    new DataColumn("Debit (Dr)"),
                    new DataColumn("Credit (Cr)")
                });

                dataTable = financialReportLogic.GetTrialBalance(from, to);
                balancetable.DataSource = dataTable;
                balancetable.DataBind();

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
    

        }
    }
