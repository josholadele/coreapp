<%@ Page Title="" Language="C#" MasterPageFile="~/UI.Master" AutoEventWireup="true" CodeBehind="AddATMTerminal.aspx.cs" Inherits="UI.AddATMTerminal" %>
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
           
    

        
        <asp:Panel ID="addTerminal" runat="server">

        
        <div class="panel panel-success">
               <div class="panel-heading">
                   <h3 class="panel-title">Add ATM Terminal</h3>
               </div>
               <div class="panel-body">
                    <div class="form-group">
                        <div class="col-md-6"> 
                            <p>
                                <span class="xn-text">Name</span>
                                <input type="text" runat="server" id="name" clientidmode="Static" class="form-control" title="Invalid input" maxlength="20" required="required" />
                            </p>
    
                            <p>
                                <span class="xn-text">Terminal ID</span>
                                <input type="text" runat="server" id="terminalID" clientidmode="Static" class="form-control" title="Invalid input" maxlength="20" required="required" />
                            </p>
                            <p>
                                <asp:Label Text="Terminal Location" runat="server"></asp:Label>
                                <asp:TextBox ID="location" placeholder="Location" class="form-control" required="required" runat="server" ></asp:TextBox>
                            </p>
     
                           
                        </div> 
                                
                    </div>
                </div>
                    <div class="panel-footer">
                                <asp:Button class="btn btn-default " OnClick="back_Click" ID="Back"  Text="Back" runat="server"/>
                                <asp:Button class="btn btn-primary pull-right" OnClick="addterminal_Click" ID="AddButton"  Text="Add Terminal" runat="server"/>
                    </div>
           </div>
      
            </asp:Panel>
           
        </body>
    </html>

</asp:Content>
