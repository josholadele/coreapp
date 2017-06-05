<%@ Page Title="" Language="C#" MasterPageFile="~/UI.Master" AutoEventWireup="true" CodeBehind="TellerPosting.aspx.cs" Inherits="UI.TellerPosting" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
        <div class="panel panel-success">
               <div class="panel-heading">
                   <h3 class="panel-title">Post Transaction</h3>
               </div>
               <div class="panel-body">
                    <div class="form-group">
                        <div class="col-md-6">
                            <%--   <asp:Label runat="server" ID="lblMsg" Text="" class="multi"/> --%>
                            <p>
                                <span class="xn-text">Verify Customer Account Number</span>
<%--                                <asp:TextBox ID="accountNumber1" class="form-control" runat="server" ></asp:TextBox>--%>
                                <asp:DropDownList ID="accountNumber" ClientIDMode="Static" required="required" AppendDataBoundItems="True" class="form-control" runat="server" DataTextField="AccountNumber" DataMember="AccountName" >
                                    <asp:ListItem />
                                </asp:DropDownList>
                                <asp:Button class="btn btn-default pull-right" OnClick="verify_Click" ID="verify"  Text="Verify Number" runat="server"/>
                            </p>
                           <asp:Panel ID="customer1" Enabled="True" runat="server">

                            <p>
                            <asp:Label Text="Customer Name" runat="server"></asp:Label>
                            <asp:TextBox ID="customer" ReadOnly="True" class="form-control" runat="server" ></asp:TextBox>
                            </p>
                            </asp:Panel>
                            <p>
                            <asp:Label Text="Type Of Transaction" runat="server"></asp:Label>
                            <asp:DropDownList ID="txnType" required="required" AppendDataBoundItems="True"  class="form-control" runat="server" >
                                <asp:ListItem Text="-Select Transaction Type-" Value="0"/>
                            </asp:DropDownList>
                            </p>
    
                            <p>
                            <asp:Label Text="Amount" runat="server"></asp:Label>
                            <asp:TextBox ID="amount"  class="form-control" runat="server" ></asp:TextBox>
                            </p>
                            <p>
                            <asp:Label Text="Narration" runat="server"></asp:Label>
                            <asp:TextBox ID="narration" MaxLength="60" class="form-control" runat="server" ></asp:TextBox>
                            </p>
    
                            </div>
                                
                    </div>
                </div>
                    <div class="panel-footer">
                                <asp:Button class="btn btn-default " OnClick="back_Click" ID="Back"  Text="Back" runat="server"/>
                                <asp:Button class="btn btn-primary pull-right" OnClick="post_Click" ID="PostButton"  Text="Post Transaction" runat="server"/>
                             
                    </div>
           </div>
       <script type="text/javascript">
            $(function () {
                debugger;
                $("#accountNumber").select2({ placeholder: "" });
            });
        </script>

</asp:Content>
