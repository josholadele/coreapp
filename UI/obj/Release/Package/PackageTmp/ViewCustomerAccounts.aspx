<%@ Page Title="" Language="C#" MasterPageFile="~/UI.Master" AutoEventWireup="true" CodeBehind="ViewCustomerAccounts.aspx.cs" Inherits="UI.ViewCustomerAccounts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <body>
        
    <div class="panel panel-default">
                                <div class="panel-heading ui-draggable-handle">                                
                                    <h3 class="panel-title">Customers' Accounts List</h3>   
                                    <ul class="panel-controls">
                                        <li><a href="#" class="panel-collapse"><span class="fa fa-angle-down"></span></a></li>
                                        <li><a href="#" class="panel-refresh"><span class="fa fa-refresh"></span></a></li>
                                        <li><a href="#" class="panel-remove"><span class="fa fa-times"></span></a></li>
                                    </ul>                                
                                </div>
         <div class="panel-body">
                <div class="dataTables_wrapper no-footer">
                                   
                    <div class="col-md-3">
                                        <asp:TextBox id="searchbycustomer" class="form-control" placeholder="Search by Customer" runat="server"></asp:TextBox>
                                    </div>
                                       <div class="col-md-3">
                                       <asp:TextBox id="searchbyaccountname" class="form-control"  placeholder="Search by Account Name" runat="server"></asp:TextBox>
                                    </div>
                            <div class="col-md-2">
                                       <asp:TextBox id="searchbybranch" class="form-control"  placeholder="Search by branch" runat="server"></asp:TextBox>
                                    </div> 
                    <div class="col-md-2">
                                       <asp:TextBox id="searchbyaccounttype" class="form-control"  placeholder="Search by Account Type" runat="server"></asp:TextBox>
                                    </div>        
                                           <asp:Button class="btn btn-primary" text="Search" id="search" runat="server"/>
                                    <br>
                    

                    <asp:GridView ID="accountstable" CssClass="table datatable_default dataTable no-footer"  runat="server" AutoGenerateColumns = "false" AllowPaging = "true" >
                                            
                                           <Columns>
                                            <asp:BoundField DataField = "Customer.Name" HeaderText = "Customer" />
                                            <asp:BoundField DataField = "AccountName" HeaderText = "Account Name" />
                                            <asp:BoundField DataField = "AccountNumber" HeaderText = "Account Number" />
                                            <asp:BoundField DataField = "Balance" HeaderText = "Account Balance" />
                                            <asp:BoundField DataField = "Branch.Name" HeaderText = "Branch" />
                                            <asp:BoundField DataField = "AccountType" HeaderText = "Account Type" />
                                            <asp:BoundField DataField="ID" HeaderText = "Edit Account" HtmlEncode="False" DataFormatString="<a class='fa fa-pencil' href='EditCustomer.aspx?CustomerID={0}' Title='Edit'></a>"/>
<%--                                            <asp:BoundField DataField="ID" HeaderText = "Close Account" HtmlEncode="False" DataFormatString="<a class='fa fa-pencil' href='EditCustomer.aspx?CustomerID={0}' Title='Close Account'></a>"/>--%>
                                            </Columns>
       
                      </asp:GridView>

                                    </div>
             </div>
            </div>
    </body>

</asp:Content>
