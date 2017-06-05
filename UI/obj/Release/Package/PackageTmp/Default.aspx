<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="UI.Default" %>

<!DOCTYPE html>
<html lang="en" class="body-full-height">
    <head>        
        <!-- META SECTION -->
        <title>CBA | Bank of Oladele</title>            
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        <meta http-equiv="X-UA-Compatible" content="IE=edge" />
        <meta name="viewport" content="width=device-width, initial-scale=1" />
        
        <link rel="icon" href="favicon.ico" type="image/x-icon" />
        <!-- END META SECTION -->
        
        <!-- Alertify --> 
        <script src="js/alertify.min.js" ></script>
         <link rel="stylesheet" type="text/css"  href="css/alertify.min.css"/>
         <link rel="stylesheet" type="text/css"  href="css/themes/default.min.css"/>
        
        <!-- CSS INCLUDE -->        
        <link rel="stylesheet" type="text/css" id="theme" href="css/theme-default.css"/>
        <!-- EOF CSS INCLUDE -->                                    
    </head>
    <body>
        
        <div class="login-container">
        
            <div class="login-box animated fadeInDown">
                
                <div class="login-body">
                    <div class="login-title"><strong>Welcome to Bank of Oladele CBA</strong>, Please login</div>
                    <form  runat="server" class="form-horizontal" method="post">
                    <div class="form-group">
                        <div class="col-md-12">
                           
                  <p>
                
                        <asp:TextBox ID="username" placeholder="Username" class="form-control" runat="server" ></asp:TextBox>
                   </p>  
                  <p>
                        <asp:TextBox ID="password" TextMode="password" placeholder="Password" class="form-control" runat="server" ></asp:TextBox>
                  </p>
                 
              </div>
                    </div>
                    
                    <div class="form-group">
                        <div class="col-md-6">
                            <a href="#" class="btn btn-link btn-block">Forgot your password?</a>
                        </div>
                        <div class="col-md-6">
                           <asp:Button class="btn btn-info btn-block" ID="Button1"  Text="Log In" runat="server" OnClick="LoginButton_Click" />
                           <%--<button class="btn btn-info btn-block">Log  In</button>--%>
                        </div>
                    </div>
                    </form>
                </div>
                <div class="login-footer">
                    <div class="pull-left">
                        &copy; 2016 Bank Of Oladele
                    </div>
                    <div class="pull-right">
                        <a href="#">About</a> |
                        <a href="#">Privacy</a> |
                        <a href="#">Contact Us</a>
                    </div>
                </div>
            </div>
            
        </div>
        
    </body>
</html>
