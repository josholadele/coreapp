<%@ Page Title="" Language="C#" MasterPageFile="~/UI.Master" AutoEventWireup="true" CodeBehind="CreateLoanAccount.aspx.cs" Inherits="UI.CreateLoanAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
 <asp:Panel ID="alert" Visible="False" runat="server">
        <div class="alert alert-success" role="alert">
            <%--<asp:Button type="button" CssClass="close" ID="close_button" runat="server" OnClick="close_button_Click"></asp:Button>--%>
                                <button type="button" class="close" data-dismiss="alert"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                                 User created. Check Email for login details.
        </div>
       </asp:Panel>
        <div class="panel panel-success">
               <div class="panel-heading">
                   <h3 class="panel-title">Create a Loan Account</h3>
               </div>
               <div class="panel-body">
                    <div class="form-group">
                        <div class="col-md-6">
                            <asp:Label runat="server" ID="lblMsg" Text="" class="multi"/> 
                            
                            <p>
                                <span class="xn-text">Linked Customer Account Number</span>
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
                            </asp:Panel>
                            <p>
                                    <span class="xn-text">Loan Amount (₦)</span>
                                <%--<asp:Label  Text="First Name:" runat="server"></asp:Label>--%>
                                <asp:TextBox ID="loanamount" class="form-control" runat="server" ValidateRequestMode="Enabled"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="AmntEmialRegularExpressionValidator" EnableClientScript="true" runat="server" ErrorMessage="RegularExpressionValidator" ControlToValidate="loanamount" ForeColor="Red" Text="Invalid Amount Format" ValidationExpression="^\$?([0-9]{1,3},([0-9]{3},)*[0-9]{3}|[0-9]+)(.[0-9][0-9])?$" ValidationGroup="loanamount"></asp:RegularExpressionValidator>
                            </p>
 
                            <p>
                            <asp:Label Text="Loan Period (in days)" runat="server"></asp:Label>
                            <asp:TextBox ID="loanperiod" class="form-control" runat="server" ></asp:TextBox>
                            </p>

                            </div>
                                
                    </div>
                </div>
                    <div class="panel-footer">
                                <asp:Button class="btn btn-default " OnClick="back_Click" ID="Back"  Text="Back" runat="server"/>
                                <asp:Button class="btn btn-primary pull-right" OnClick="createloan_Click" ID="CreateLoan"  Text="Create Account" runat="server"/>
                             
                    </div>
           </div>
    <script type="text/javascript">
            $(function () {
                debugger;
                $("#accountNumber").select2({ placeholder: "Type Customer Account Number" });
            });
        </script>
</asp:Content>
