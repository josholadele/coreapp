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
    public partial class PandL_Report : System.Web.UI.Page
    {
        int rowcount = 0, rowcount1 = 0, rowcount2 = 0, rowcount3 = 0, rowcount4 = 0;
        // ReSharper disable once InconsistentNaming

        DateTime fromDate = Convert.ToDateTime("2014/03/01");
        DateTime toDate = Convert.ToDateTime("2020/03/01");

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                FinancialReportLogic financialReportLogic = new FinancialReportLogic();

                DataTable dataTable = new DataTable();
                dataTable.Columns.AddRange(new DataColumn[3]
                {
                    new DataColumn("Name"),
                    new DataColumn("Debit (Dr)"),
                    new DataColumn("Credit (Cr)")
                });

                dataTable = financialReportLogic.GetProfitAndLoss(fromDate, toDate);
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


        protected void Page_1Load(object sender, EventArgs e)
        {
            GLAccountLogic glAccountLogic = new GLAccountLogic();
            List<GLAccount> incomesList = glAccountLogic.GetIncomeGls();
            List<GLAccount> expensesList = glAccountLogic.GetExpenseGls();
            List<GLAccount> capitalList = glAccountLogic.GetCapitalGls();
            double totalExpense = 0, totalIncome = 0;

            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[3]
            {
                new DataColumn("Name"),
                new DataColumn("Debit (Dr)"),
                new DataColumn("Credit (Cr)")
            });

            rowcount = dt.Rows.Count;
            dt.Rows.Add("Income");

            foreach (var income in incomesList)
            {
                dt.Rows.Add(income.Name, "", income.Balance);
                totalIncome = totalIncome + income.Balance;

            }


            dt.Rows.Add("", "", "");
            rowcount2 = dt.Rows.Count;


            dt.Rows.Add("Expense");

            foreach (var expense in expensesList)
            {
                dt.Rows.Add(expense.Name, expense.Balance);
                totalExpense = totalExpense + expense.Balance;

            }

            dt.Rows.Add("", "", "");
            rowcount3 = dt.Rows.Count;

            double pandL = totalIncome - totalExpense;
            if (pandL >= 0)
            {
                dt.Rows.Add("Net Profit", "", pandL);

            }
            else if (pandL < 0)
            {
                dt.Rows.Add("Net Loss", pandL);
            }

            balancetable.DataSource = dt;
            balancetable.DataBind();
        }

        protected void balancetable_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex == rowcount || e.Row.RowIndex == rowcount1 || e.Row.RowIndex == rowcount2 ||
                e.Row.RowIndex == rowcount3 || e.Row.RowIndex == rowcount4)
            {
                e.Row.Cells[0].Font.Bold = true;
                e.Row.Cells[1].Font.Bold = true;
                e.Row.Cells[2].Font.Bold = true;
            }
            if (e.Row.RowIndex == rowcount || e.Row.RowIndex == rowcount2)
            {
                e.Row.BackColor = Color.LightGray;
            }
            if (e.Row.RowIndex == rowcount3)
            {
                e.Row.Cells[1].ForeColor = Color.Red;
                e.Row.Cells[2].ForeColor = Color.Green;
            }

        }

        protected void onGo_Click(object sender, EventArgs e)
        {
            
            if (!string.IsNullOrWhiteSpace(dateFrom.Text))
            {
                fromDate = Convert.ToDateTime(dateFrom.Text);
            }

            if (!string.IsNullOrWhiteSpace(dateTo.Text))
            {
                toDate = Convert.ToDateTime(dateTo.Text);
            }

            FinancialReportLogic financialReportLogic = new FinancialReportLogic();

            DataTable dataTable = new DataTable();
            dataTable.Columns.AddRange(new DataColumn[3]
            {
                new DataColumn("Name"),
                new DataColumn("Debit (Dr)"),
                new DataColumn("Credit (Cr)")
            });

            dataTable = financialReportLogic.GetProfitAndLoss(fromDate, toDate);
            balancetable.DataSource = dataTable;
            balancetable.DataBind();


        }
    
    }
}