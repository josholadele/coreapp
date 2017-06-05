<%@ Page Title="" Language="C#" MasterPageFile="~/UI.Master" AutoEventWireup="true" CodeBehind="AddCustomer.aspx.cs" Inherits="UI.AddCustomer" %>
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
           
    

        
        <asp:Panel ID="addCustomer" runat="server">

        
        <div class="panel panel-success">
               <div class="panel-heading">
                   <h3 class="panel-title">Create a new customer</h3>
               </div>
               <div class="panel-body">
                    <div class="form-group">
                        <div class="col-md-6"> 
                            <p>
                                    <span class="xn-text">Name (Surname first)</span>
                                <%--<asp:Label  Text="First Name:" runat="server"></asp:Label>--%>
                                <%--<asp:TextBox ID="fullname" placeholder="Doe John" class="form-control" runat="server" ></asp:TextBox>--%>
                                <input type="text" runat="server" id="fullname" clientidmode="Static" class="form-control" title="Invalid input" maxlength="20" required="required" />
                            </p>
    
                            <p>
                                <asp:Label Text="Address" runat="server"></asp:Label>
                                <asp:TextBox ID="address" placeholder="Address" class="form-control" required="required" runat="server" ></asp:TextBox>
                            </p>
     
                            <p>
                            <asp:Label Text="Email Address" runat="server"></asp:Label>
                            <asp:TextBox ID="email" required="required" class="form-control" runat="server" ></asp:TextBox>
                            <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="email" ErrorMessage="Invalid Email Format"></asp:RegularExpressionValidator>
                           </p>
    
                            <p>
                            <asp:Label Text="Phone Number" runat="server"></asp:Label>
                            <asp:TextBox ID="phonenumber" aria-required="true" required="required" class="form-control" runat="server"></asp:TextBox>
                            </p>
    
                            
                            <p>
                            <asp:Label Text="Gender" runat="server"></asp:Label>
                            <asp:DropDownList ID="gender" ClientIDMode="Static" required="required" placeholder="-Select Gender-" AppendDataBoundItems="True" class="form-control" runat="server" >
                                <asp:ListItem/>
                            </asp:DropDownList>
                            </p>
         
                        </div> 
                                
                    </div>
                </div>
                    <div class="panel-footer">
                                <asp:Button class="btn btn-default " OnClick="back_Click" ID="Back"  Text="Back" runat="server"/>
                                <asp:Button class="btn btn-primary pull-right" OnClick="addcustomer_Click" ID="LoginButton"  Text="Create Customer" runat="server"/>
                    </div>
           </div>
      
            </asp:Panel>
           
        <script type="text/javascript">
            $(function () {
                debugger;
                $("#gender").select2({placeholder: "See"});
            });
        </script>


    </body>
    </html>
       
    
    
    
    

</asp:Content>
