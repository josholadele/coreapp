<%@ Page Title="" Language="C#" MasterPageFile="~/UI.Master" AutoEventWireup="true" CodeBehind="AccountConfig.aspx.cs" Inherits="UI.AccountConfig" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    
        <asp:Panel ID="acctConfig" runat="server">

        
        <div class="panel panel-success">
               <div class="panel-heading">
                   <h3 class="panel-title">Account Configuration</h3>
               </div>
               <div class="panel-body">
                    <div class="form-group">
                        <div class="col-md-6"> 
                            
                            <asp:Panel ID="savingsAcc" Enabled="False" Visible="False" runat="server">
                                    <p>
                                            <span class="xn-text">Credit Interest Rate (%)</span>
                                        <%--<asp:Label  Text="First Name:" runat="server"></asp:Label>--%>
                                        <asp:TextBox ID="crInterest" MaxLength="2" class="form-control" runat="server" ></asp:TextBox>
                                    </p>
    
                                    <p>
                                        <asp:Label Text="Minimum Balance (₦)" runat="server"></asp:Label>
                                        <asp:TextBox ID="minbalance" MaxLength="5" class="form-control" runat="server" ></asp:TextBox>
                                    </p>
                                   <p>
                                    <span class="xn-text">Interest Expense GL</span>
                                    <asp:DropDownList ID="expenseGl" AppendDataBoundItems="True" required="required" class="form-control" runat="server" DataTextField="Name" >
                                        <asp:ListItem Text="-Select GL-" Value="0"/>
                                    </asp:DropDownList>

                                    </p>

                            </asp:Panel>
                            <asp:Panel ID="currentAcc" Enabled="False" Visible="False" runat="server">
                            <p>
                            <asp:Label Text="COTperMil (₦)" runat="server"></asp:Label>
                            <asp:TextBox ID="cot" class="form-control" runat="server" ></asp:TextBox>
                            </p>
                                <p>
                                    <span class="xn-text">COT Income GL</span>
                                    <asp:DropDownList ID="cotGl" AppendDataBoundItems="True" required="required" class="form-control" runat="server" DataTextField="Name" >
                                        <asp:ListItem Text="-Select COT Income GL-" Value="0"/>
                                    </asp:DropDownList>

                                    </p>
    
                            </asp:Panel>

                            <asp:Panel ID="loanAcc" Enabled="False" Visible="False" runat="server">
                            <p>
                            <asp:Label Text="Debit Interest Rate (%)" runat="server"></asp:Label>
                            <asp:TextBox ID="drInterest" MaxLength="2" class="form-control" runat="server" ></asp:TextBox>
                            </p>
                                <p>
                                    <span class="xn-text">Interest Income GL</span>
                                    <asp:DropDownList ID="incomeGl" AppendDataBoundItems="True" required="required" class="form-control" runat="server" DataTextField="Name" >
                                        <asp:ListItem Text="-Select GL-" Value="0"/>
                                    </asp:DropDownList>

                                    </p>
    
                            </asp:Panel>
                            
         
                        </div>
                                
                    </div>
                </div>
                    <div class="panel-footer">
                                <asp:Button class="btn btn-default " OnClick="back_Click" ID="Back"  Text="Back" runat="server"/>
                                <asp:Button class="btn btn-primary pull-right" OnClick="edit_Click" ID="EditButton"  Text="Edit" runat="server"/>
                                <asp:Button class="btn btn-primary pull-right" Visible = "False" OnClick="save_Click" ID="SaveButton"  Text="Save Changes" runat="server"/>
                             
                    </div>
           </div>
      
            </asp:Panel>
           

                        <p><asp:TextBox ID="intt" class="form-control" Visible="False" runat="server" ></asp:TextBox></p>


</asp:Content>
