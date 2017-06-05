<%@ Page Title="" Language="C#" MasterPageFile="~/UI.Master" AutoEventWireup="true" CodeBehind="EditUser.aspx.cs" Inherits="UI.EditUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
     <div class="panel panel-warning">
                        <div class="panel-heading">
                                <h3 class="panel-title">Edit User</h3>
                        </div>
                 <div class="panel-body">
                    <div class="form-group">
                        <div class="col-md-6"> 
                            <p>
                                    <span class="xn-text">First Name</span>
                                <%--<asp:Label  Text="First Name:" runat="server"></asp:Label>--%>
                                <asp:TextBox ID="firstname" class="form-control" runat="server" ></asp:TextBox>
                            </p>
    
                            <p>
                            <asp:Label Text="Last Name" runat="server"></asp:Label>
                            <asp:TextBox ID="lastname" class="form-control" runat="server" ></asp:TextBox>
                            </p>

                            <p>
                            <asp:Label Text="Email Address" runat="server"></asp:Label>
                            <asp:TextBox ID="email"  class="form-control" runat="server" ></asp:TextBox>
                            </p>
    
                            <p>
                            <asp:Label Text="Phone Number" runat="server"></asp:Label>
                            <asp:TextBox ID="phonenumber" class="form-control" runat="server"></asp:TextBox>
                            </p>
    
                            <p>
                                <asp:Label Text="Branch" runat="server"></asp:Label>
                                <asp:DropDownList ID="branch" AppendDataBoundItems="True" class="form-control" runat="server" DataTextField="Name">
                                    <asp:ListItem Text="-Choose a branch-" Value="0"/>
                                </asp:DropDownList>
                            </p>
  
                            <asp:TextBox ID="intt" Visible="False" class="form-control" runat="server"></asp:TextBox>
 
                            
                        </div>  
                   
                  </div>
               </div>
            <div class="panel-footer">
                                <asp:Button class="btn btn-default " OnClick="back_Click" ID="Back"  Text="Back" runat="server"/>
                                <asp:Button class="btn btn-primary pull-right" OnClick="save_Click" ID="SaveButton"  Text="Save Changes" runat="server"/>
                             
                    </div>
            </div>

</asp:Content>
