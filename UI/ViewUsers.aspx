<%@ Page Title="All Users" Language="C#" MasterPageFile="~/UI.Master" AutoEventWireup="true" CodeBehind="ViewUsers.aspx.cs" Inherits="UI.ViewUsers" %>
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
           
     <div class="panel panel-default">
                                <div class="panel-heading ui-draggable-handle">                                
                                    <h3 class="panel-title">Users' List</h3>   
                                                              
                                </div>
                                <div class="dataTables_wrapper no-footer">
                                   <div class="col-md-4">
                                        <asp:TextBox id="searchbyname" class="form-control" placeholder="Search by name" runat="server"></asp:TextBox>
                                    </div>
                                       <div class="col-md-4">
                                       <asp:DropDownList id="searchbybranch" ClientIDMode="Static" class="form-control" AppendDataBoundItems="True"  placeholder="Search by branch" DataTextField="Name" runat="server">
                                           <asp:ListItem />
                                       </asp:DropDownList>
                                    </div>
                                           <asp:Button class="btn btn-primary" text="Search" id="search" runat="server"/>
                                    <br>
                                    <asp:GridView ID="usertable" CssClass="table datatable_simple dataTable no-footer" runat="server" AutoGenerateColumns = "false" AllowPaging = "true" >
                                            
                                            <Columns>
                                            <asp:BoundField DataField = "FirstName" HeaderText = "First Name" />
                                            <asp:BoundField DataField = "LastName" HeaderText = "Last Name" />
                                            <asp:BoundField DataField = "Email" HeaderText = "Email Address" />
                                            <asp:BoundField DataField = "Branch.Name" HeaderText = "Branch" />
                                            <asp:BoundField DataField = "PhoneNumber" HeaderText = "Phone Number" />
                                        <asp:BoundField DataField="ID" HeaderText = "Edit User" HtmlEncode="False" DataFormatString="<a class='fa fa-pencil' href='EditUser.aspx?UserID={0}' Title='Edit'></a>"/>
                                            </Columns>
       
                                       </asp:GridView>
                                       
                                    </div>
            </div>
        
        <script type="text/javascript">
               $(function () {
                   debugger;
                   $("#searchbybranch").select2({});
                   
               });
        </script>
    </body>
    
  
</asp:Content>
