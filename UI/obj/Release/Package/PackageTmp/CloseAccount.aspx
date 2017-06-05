<%@ Page Title="" Language="C#" MasterPageFile="~/UI.Master" AutoEventWireup="true" CodeBehind="CloseAccount.aspx.cs" Inherits="UI.CloseAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
     <div class="panel panel-success">
               <div class="panel-heading">
                   <h3 class="panel-title">Close Customer Account</h3>
               </div>
               <div class="panel-body">
                    <div class="form-group">
                        <div class="col-md-6">
                            <asp:Label runat="server" ID="lblMsg" Text="" class="multi"/> 
                            
                            <p>
                                <span class="xn-text">Customer Account Number</span>
                                <%--<asp:TextBox ID="accountNumber" required="required" class="form-control" runat="server" ></asp:TextBox>--%>
                                <asp:DropDownList ID="accountNumber" ClientIDMode="Static" required="required" AppendDataBoundItems="True" class="form-control" runat="server" DataTextField="AccountNumber" DataMember="AccountName" >
                                    <asp:ListItem />
                                </asp:DropDownList>
                                <asp:Button class="btn btn-default pull-right" OnClick="verify_Click" ID="verify"  Text="Verify Number" runat="server"/>
                            </p>
                            <asp:Panel ID="customer1" Enabled="False" runat="server">
                            <p>
                                <asp:Label Text="Customer" runat="server"></asp:Label>
                            <asp:TextBox ID="customername" class="form-control" runat="server" ></asp:TextBox>
                            </p>
                            
                            

                            <p>
                               <span class="xn-text">Balance (₦)</span>
                                <%--<asp:Label  Text="First Name:" runat="server"></asp:Label>--%>
                                <asp:TextBox ID="balance" class="form-control" runat="server" ValidateRequestMode="Enabled"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="AmntEmialRegularExpressionValidator" EnableClientScript="true" runat="server" ErrorMessage="RegularExpressionValidator" ControlToValidate="balance" ForeColor="Red" Text="Invalid Amount Format" ValidationExpression="^\$?([0-9]{1,3},([0-9]{3},)*[0-9]{3}|[0-9]+)(.[0-9][0-9])?$" ValidationGroup="loanamount"></asp:RegularExpressionValidator>
                            </p>
                            <p>
                                <asp:Label Text="Account Status" runat="server"></asp:Label>
                            <asp:TextBox ID="accountStatus" class="form-control" runat="server" ></asp:TextBox>
                            </p>
                            
                            </asp:Panel>
                            </div>
                                
                    </div>
                </div>
                    <div class="panel-footer">
                                <asp:Button class="btn btn-default " OnClick="back_Click" ID="Back"  Text="Back" runat="server"/>
                                <asp:Button class="btn btn-primary pull-right" OnClick="close_Click" ID="Close_Account"  Text="Close Account" runat="server"/>
                             
                    </div>
           </div>
    <script type="text/javascript">
            $(function () {
                debugger;
                $("#accountNumber").select2({ placeholder: "Type Customer Account Number" });
            });
        </script>

</asp:Content>
