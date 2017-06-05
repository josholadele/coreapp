<%@ Page Title="" Language="C#" MasterPageFile="~/UI.Master" AutoEventWireup="true" CodeBehind="EditGLAccount.aspx.cs" Inherits="UI.EditGLAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
        <asp:Panel ID="editGLAccount" runat="server">

        
        <div class="panel panel-success">
               <div class="panel-heading">
                   <h3 class="panel-title">Edit GL Account</h3>
               </div>
               <div class="panel-body">
                    <div class="form-group">
                        <div class="col-md-6"> 
                            <p>
                                 <span class="xn-text">Name</span>
                                 <%--<asp:Label  Text="First Name:" runat="server"></asp:Label>--%>
                                 <asp:TextBox ID="name" class="form-control" runat="server" ></asp:TextBox>
    
                            </p>
                           
                             <p>
                                <asp:Label Text="Branch" runat="server"></asp:Label>
                                <asp:DropDownList ID="branch" AppendDataBoundItems="True" class="form-control" runat="server" DataTextField="Name">
                                    <asp:ListItem Text="-Choose a branch-" Value="0"/>
                                </asp:DropDownList>
                            </p>

                             
    </div>
                        </div>
                   </div> </div>
            
            <div class="panel-footer">
                                <asp:Button class="btn btn-default " OnClick="back_Click" ID="Back"  Text="Back" runat="server"/>
                                <asp:Button class="btn btn-primary pull-right" OnClick="edit_Click" ID="EditButton"  Text="Save Changes" runat="server"/>
                             
            </div>
            </asp:Panel>

</asp:Content>
