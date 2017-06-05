<%@ Page Title="" Language="C#" MasterPageFile="~/UI.Master" AutoEventWireup="true" CodeBehind="ViewTellerPostings.aspx.cs" Inherits="UI.ViewTellerPostings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    

     <div class="panel panel-default">
                                <div class="panel-heading ui-draggable-handle">                                
                                    <h3 class="panel-title">Teller Postings</h3>   
                                                              
                                </div>
                                <div class="dataTables_wrapper no-footer">
                                   
                                    <div class="col-md-4">
                                        <asp:TextBox id="searchbycustomeraccount" class="form-control" placeholder="Search by Customer Account" runat="server"></asp:TextBox>
                                    </div>
                                    
                                       
                    <div class="col-md-3">
                                       <asp:TextBox id="searchbytill" class="form-control"  placeholder="Search by Till" runat="server"></asp:TextBox>
                                    </div> 
                                    <div class="col-md-3">
                                            <asp:DropDownList id="searchbytxntype" ClientIDMode="Static" class="form-control" AppendDataBoundItems="True"  placeholder="Search by Transaction Type" runat="server">
                                           <asp:ListItem />
                                       </asp:DropDownList>                                    </div>       
                                           <asp:Button class="btn btn-primary" text="Search" id="search" runat="server"/>
                                    <br>    

                                       <asp:GridView ID="tellerpostingtable" CssClass="table datatable_simple dataTable no-footer" runat="server" AutoGenerateColumns = "false" AllowPaging = "true" >
                                            
                                            <Columns>
                                            <asp:BoundField DataField = "ID" HeaderText = "S/N" />
                                            <asp:BoundField DataField = "CustomerAccount.AccountName" HeaderText = "Customer Account Name" />
                                            <asp:BoundField DataField = "CustomerAccount.AccountNumber" HeaderText = "Customer Account Number" />
                                            <asp:BoundField DataField = "Till.Name" HeaderText = "Service Till" />
                                            <asp:BoundField DataField = "Amount" HeaderText = "Transaction Amount" />
                                            <asp:BoundField DataField = "TransactionType" HeaderText = "Type of Transaction" />
                                            <asp:BoundField DataField = "Narration" HeaderText = "Description" />
                                            <asp:BoundField DataField = "TransactionDate" HeaderText = "Transaction Date" />
                                            </Columns>
       
                                       </asp:GridView>
                                       
                                    </div>
            </div>
    <script type="text/javascript">
               $(function () {
                   debugger;
                   $("#searchbytxntype").select2({});
                   
               });
        </script>
</asp:Content>
