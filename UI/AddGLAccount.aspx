<%@ Page Title="" Language="C#" MasterPageFile="~/UI.Master" AutoEventWireup="true" CodeBehind="AddGLAccount.aspx.cs" Inherits="UI.AddGLAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
 
        <asp:Panel ID="addGLAccount" Visible="True" runat="server">

        
        <div class="panel panel-success">
               <div class="panel-heading">
                   <h3 class="panel-title">Create a GL Account</h3>
               </div>
               <div class="panel-body">
                    <div class="form-group">
                        <div class="col-md-6"> 
                            <p>
                                 <span class="xn-text">Name</span>
                                 <%--<asp:Label  Text="First Name:" runat="server"></asp:Label>--%>
                                 <asp:TextBox ID="name" placeholder="GL Account name" required="required" class="form-control" runat="server" ></asp:TextBox>
    
                            </p>
                           
                             <p>
                                <asp:Label Text="GL Category" runat="server"></asp:Label>
                                <asp:DropDownList ID="glcategory" ClientIDMode="Static" AppendDataBoundItems="True" class="form-control" required="required" runat="server" DataTextField="Name">
                                    <asp:ListItem Text="-Select a Category-" Value="0"/>
                                </asp:DropDownList>
                            </p>

                             <p>
                                <asp:Label Text="Branch" runat="server"></asp:Label>
                                <asp:DropDownList ID="branch" ClientIDMode="Static" AppendDataBoundItems="True" class="form-control" required="required" runat="server" DataTextField="Name">
                                    <asp:ListItem Text="-Choose a branch-" Value="0"/>
                                </asp:DropDownList>
                            </p>
    
    </div>
                        </div>
                   </div>
            <div class="panel-footer">
                                <asp:Button class="btn btn-default " OnClick="back_Click" ID="Back"  Text="Back" runat="server"/>
                                <asp:Button class="btn btn-primary pull-right" OnClick="addaccount_Click" ID="AddButton"  Text="Add Account" runat="server"/>
                             
                    </div> 
        </div>
            </asp:Panel>
  

</asp:Content>
