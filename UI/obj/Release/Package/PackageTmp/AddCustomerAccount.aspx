<%@ Page Title="" Language="C#" MasterPageFile="~/UI.Master" AutoEventWireup="true" CodeBehind="AddCustomerAccount.aspx.cs" Inherits="UI.AddCustomerAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
  
        <asp:Panel ID="addCustomer" runat="server">

        
        <div class="panel panel-success">
               <div class="panel-heading">
                   <h3 class="panel-title">Create a customer account</h3>
               </div>
               <div class="panel-body">
                    <div class="form-group">
                        <div class="col-md-6"> 
                            
                            <p>
                                <asp:Label Text="Customer" runat="server"></asp:Label>
                                <asp:DropDownList ID="customer" ClientIDMode="Static" AppendDataBoundItems="True" required="required" class="form-control" runat="server" DataTextField="Name">
                                    <asp:ListItem/>
                                </asp:DropDownList>
                            </p>
                            
                            <p>
                                    <span class="xn-text">Account Name (Surname first)</span>
                                <%--<asp:Label  Text="First Name:" runat="server"></asp:Label>--%>
                                <asp:TextBox ID="fullname" class="form-control" required="required" runat="server" ></asp:TextBox>
                            </p>
    
                            <p>
                                <asp:Label Text="Branch" runat="server"></asp:Label>
                                <asp:DropDownList ID="branch" ClientIDMode="Static" required="required" AppendDataBoundItems="True" class="form-control" runat="server" DataTextField="Name">
                                    <asp:ListItem/>
                                </asp:DropDownList>
                            </p>
                            
                            <p>
                            <asp:Label Text="Type of Account"  runat="server"></asp:Label>
                            <asp:DropDownList ID="accountType" ClientIDMode="Static" required="required" AppendDataBoundItems="True"  class="form-control" runat="server" >
                                <asp:ListItem/>
                            </asp:DropDownList>
                            </p>
         
                        </div>
                                
                    </div>
                </div>
                    <div class="panel-footer">
                                <asp:Button class="btn btn-default " OnClick="back_Click" ID="Back"  Text="Back" runat="server"/>
                                <asp:Button class="btn btn-primary pull-right" OnClick="addcustomer_Click" ID="LoginButton"  Text="Create Account" runat="server"/>
                             
                    </div>
           </div>
      
            </asp:Panel>
           <script type="text/javascript">
               $(function () {
                   debugger;
                   $("#branch").select2({ placeholder: "-Select Branch-" });
                   $("#accountType").select2({ placeholder: "-Select the type of account-" });
                   $("#customer").select2({ placeholder: "" });

               });
        </script>

</asp:Content>
