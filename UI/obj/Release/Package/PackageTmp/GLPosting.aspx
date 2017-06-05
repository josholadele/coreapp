<%@ Page Title="" Language="C#" MasterPageFile="~/UI.Master" AutoEventWireup="true" CodeBehind="GLPosting.aspx.cs" Inherits="UI.GLPosting" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    
       
        <div class="panel panel-success">
               <div class="panel-heading">
                   <h3 class="panel-title">Post Transaction into GL</h3>
               </div>
               <div class="panel-body">
                    <div class="form-group">
                        <div class="col-md-6">
                            <%--   <asp:Label runat="server" ID="lblMsg" Text="" class="multi"/> --%>
                            <p>
                                <span class="xn-text">Account to Debit</span>
                            <asp:DropDownList ID="draccount" AppendDataBoundItems="True"  class="form-control" runat="server" DataTextField="Name" >
                                <asp:ListItem Text="-Select Account to debit-" Value="0"/>
                            </asp:DropDownList>
                            </p>
                            <p>
                                <span class="xn-text">Account to Credit</span>
                            <asp:DropDownList ID="craccount" AppendDataBoundItems="True"  class="form-control" runat="server" DataTextField="Name" >
                                <asp:ListItem Text="-Select Account to credit-" Value="0"/>
                            </asp:DropDownList>
                            </p>
                           
                            <p>
                            
                            <p>
                            <asp:Label Text="Amount" runat="server"></asp:Label>
                            <asp:TextBox ID="amount" class="form-control" runat="server" ></asp:TextBox>
                            </p>
                            <p>
                            <asp:Label Text="Narration" runat="server"></asp:Label>
                            <asp:TextBox ID="narration" MaxLength="60" class="form-control" runat="server" ></asp:TextBox>
                            </p>
    
                            </div>
                                
                    </div>
                </div>
                    <div class="panel-footer">
                                <asp:Button class="btn btn-default " OnClick="back_Click" ID="Back"  Text="Back" runat="server"/>
                                <asp:Button class="btn btn-primary pull-right" OnClick="post_Click" ID="PostButton"  Text="Post Transaction" runat="server"/>
                             
                    </div>
           </div>
       
   

</asp:Content>
