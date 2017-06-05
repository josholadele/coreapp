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
    public partial class BalanceSheet : System.Web.UI.Page
    {
        int rowcount = 0, rowcount1 = 0, rowcount2 = 0, rowcount3 = 0, rowcount4 = 0;
        DateTime from = Convert.ToDateTime("2014/03/01");
        DateTime to = Convert.ToDateTime("2020/03/01");

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

                    dataTable = financialReportLogic.GetBalanceSheet(from, to);
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

        protected void Page_1Load(object sender, EventArgs e)
        {
            GLAccountLogic glAccountLogic = new GLAccountLogic();
            List<GLAccount> assetsList = glAccountLogic.GetAssetGls();
            List<GLAccount> liabilitiesList = glAccountLogic.GetLiabilityGls();
            List<GLAccount> capitalList = glAccountLogic.GetCapitalGls();
            double totalAssets = 0, totalLiabilities = 0, totalCapital = 0,cashBalance=0;

            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[3] { new DataColumn("Name"), 
                            new DataColumn("Debit (Dr)"), 
                            new DataColumn("Credit (Cr)") });

            rowcount = dt.Rows.Count;
            dt.Rows.Add("Assets");

            foreach (var asset in assetsList)
            {
                if (asset.GLCategory.Name == "Cash Assets")
                {
                    cashBalance = cashBalance + asset.Balance;
                    totalAssets = totalAssets + asset.Balance;
                }
               
            }
            dt.Rows.Add("Cash", cashBalance);
            foreach (var asset in assetsList)
            {
                if (asset.GLCategory.Name != "Cash Assets")
                {
                    dt.Rows.Add(asset.Name, asset.Balance);
                    totalAssets = totalAssets + asset.Balance;
                }
                
            }
            rowcount1 = dt.Rows.Count;
            dt.Rows.Add("Total", totalAssets);
            dt.Rows.Add("", "", "");
            rowcount2 = dt.Rows.Count;
            dt.Rows.Add("Liabilities");


            foreach (var liability in liabilitiesList)
            {
                dt.Rows.Add(liability.Name, "", liability.Balance);
                totalLiabilities = totalLiabilities + liability.Balance;

            }


            dt.Rows.Add("", "", "");
            rowcount3 = dt.Rows.Count;
            dt.Rows.Add("Capital");

            totalCapital = totalLiabilities;
            if (capitalList != null)
            {
                foreach (var capital in capitalList)
                {
                    dt.Rows.Add(capital.Name, "", capital.Balance);
                    totalCapital = totalCapital + capital.Balance;

                }
            }
            dt.Rows.Add("", "", "");
            rowcount4 = dt.Rows.Count;
            dt.Rows.Add("Total", "", totalCapital);



            GLAccountLogic myGlAccountLogic = new GLAccountLogic();
            List<GLAccount> myAssets = myGlAccountLogic.GetAssetGls();
            balancetable.DataSource = dt;
            balancetable.DataBind();
        }

        protected void balancetable_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells[0].Text == "Total")
            {
                e.Row.Cells[1].Font.Bold = true;
                e.Row.Cells[2].Font.Bold = true;
                e.Row.Cells[1].Font.Size = 13;
                e.Row.Cells[2].Font.Size = 13;
            }
            if (e.Row.Cells[0].Text == "Assets" || e.Row.Cells[0].Text == "Liabilities" || e.Row.Cells[0].Text == "Capital")
            {
                e.Row.BackColor = Color.LightGray;
                e.Row.Cells[0].Font.Bold = true;
            }

            if (e.Row.RowIndex == rowcount || e.Row.RowIndex == rowcount1 || e.Row.RowIndex == rowcount2 || e.Row.RowIndex == rowcount3 || e.Row.RowIndex == rowcount4)
            {
                e.Row.Cells[0].Font.Bold = true;
                e.Row.Cells[1].Font.Bold = true;
                e.Row.Cells[2].Font.Bold = true;
            }
            if (e.Row.RowIndex == rowcount || e.Row.RowIndex == rowcount2 || e.Row.RowIndex == rowcount3)
            {
                e.Row.BackColor = Color.LightGray;
            }
            if (e.Row.RowIndex == rowcount1)
            {
                e.Row.Cells[1].Font.Size = 13;
                e.Row.Cells[1].Font.Underline = true;

            }
            if (e.Row.RowIndex == rowcount4)
            {
                e.Row.Cells[2].Font.Size = 13;
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

                dataTable = financialReportLogic.GetBalanceSheet(from, to);
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