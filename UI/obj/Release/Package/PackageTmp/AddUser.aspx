<%@ Page Title="New User Portal" Language="C#" MasterPageFile="~/UI.Master" AutoEventWireup="true" CodeBehind="AddUser.aspx.cs" Inherits="UI.AddUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  
<!DOCTYPE html>
<html lang="en">
    <head>        
        <!-- META SECTION -->
        <title><%: Title %>.</title>            
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        <meta http-equiv="X-UA-Compatible" content="IE=edge" />
        <meta name="viewport" content="width=device-width, initial-scale=1" />
        
        <link rel="icon" href="favicon.ico" type="image/x-icon" />
        <!-- END META SECTION -->
        
        <!-- CSS INCLUDE -->        
        <link rel="stylesheet" type="text/css" id="theme" href="css/theme-default.css"/>
        <!-- EOF CSS INCLUDE -->                                    
    </head>
    <body>
    <%--<h2><%: Title %>.</h2>--%>
           
   
       <asp:Panel ID="alert" Visible="False" runat="server">
        <div class="alert alert-success" role="alert">
            <%--<asp:Button type="button" CssClass="close" ID="close_button" runat="server" OnClick="close_button_Click"></asp:Button>--%>
                                <button type="button" class="close" data-dismiss="alert"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                                 User created. Check Email for login details.
        </div>
       </asp:Panel>
        <asp:Panel ID="User_" Visible="False" runat="server">
        <div class="panel panel-success">
               <div class="panel-heading">
                   <h3 class="panel-title">Add a new user</h3>
               </div>
               <div class="panel-body">
                    <div class="form-group">
                        <div class="col-md-6">
                            <asp:Label runat="server" ID="lblMsg" Text="" class="multi"/> 
                            <p>
                                    <span class="xn-text">First Name</span>
                                <%--<asp:Label  Text="First Name:" runat="server"></asp:Label>--%>
                                <%--<asp:TextBox ID="fame" placeholder="John" class="form-control" runat="server" ></asp:TextBox>--%>
                                <input type="text" runat="server" id="firstname" clientidmode="Static" class="form-control" pattern="[A-Za-z]+" title="Invalid input" maxlength="20" required="required" />
                            </p>
    <%--<asp:RangeValidator ID="Value1RangeValidator" ControlToValidate="firstname"
             Type="String" MinimumValue="1" MaximumValue="100" Display="Dynamic"
             ErrorMessage="Please enter an integer <br /> between than 1 and 100.<br />"
             runat="server"/>--%>
                            <p>
                            <asp:Label Text="Last Name" runat="server"></asp:Label>
                            <%--<asp:TextBox ID="lastsname" placeholder="Doe" class="form-control" runat="server" ></asp:TextBox>--%>
                            <input type="text" runat="server" id="lastname" clientidmode="Static" class="form-control" pattern="[A-Za-z]+" title="Invalid input" maxlength="20" required="required" />

                            </p>

                            <p>
                            <asp:Label Text="Gender" runat="server"></asp:Label>
                            <asp:DropDownList ID="gender" ClientIDMode="Static" required="required" placeholder="Select Gender" AppendDataBoundItems="True" class="form-control" runat="server" >
                                <asp:ListItem Text="-Select Gender-" Value="0"/>
                            </asp:DropDownList>
                            </p>
    
                            <p>
                            <asp:Label Text="Email Address" runat="server"></asp:Label>
                            <asp:TextBox ID="email" required="required" class="form-control" runat="server" ></asp:TextBox>
                            <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="email" ErrorMessage="Invalid Email Format"></asp:RegularExpressionValidator>
                            </p>
    
                            <p>
                            <asp:Label Text="Phone Number" runat="server"></asp:Label>
                            <asp:TextBox ID="phonenumber" required="required" class="form-control" runat="server"></asp:TextBox>
                            </p>
    
                            <p>
                                <asp:Label Text="Branch" runat="server"></asp:Label>
                                <asp:DropDownList ID="branch" placeholder="Select a branch" AppendDataBoundItems="True" class="form-control" runat="server" DataTextField="Name">
                                    <asp:ListItem Text="-Choose a branch-" Value="0"/>
                                </asp:DropDownList>
                            </p>
         
                            <p>
                                <asp:Label Text="Username" runat="server"></asp:Label>
                                <asp:TextBox ID="username" required="required" class="form-control" runat="server" ></asp:TextBox>
                            </p>
  
                            <p>
                            <asp:Label Text="User Role" runat="server"></asp:Label>
                            <asp:DropDownList ID="userrole" ClientIDMode="Static" required="required" AppendDataBoundItems="True" class="form-control" runat="server" >
                                <asp:ListItem Text="-Select Role-" Value="0"/>
                            </asp:DropDownList>
                            </p>
                            
                            
                            </div>
                                
                    </div>
                </div>
                    <div class="panel-footer">
                                <asp:Button class="btn btn-default " OnClick="back_Click" ID="Back"  Text="Back" runat="server"/>
                                <asp:Button class="btn btn-primary pull-right" OnClick="adduser_Click" ID="LoginButton"  Text="Add User" runat="server"/>
                             
                    </div>
           </div>
 
            </asp:Panel>
    </body>
    </html>


</asp:Content>
        