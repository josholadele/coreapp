<%@ Page Title="" Language="C#" MasterPageFile="~/UI.Master" AutoEventWireup="true" CodeBehind="ViewGLPostings.aspx.cs" Inherits="UI.ViewGLPostings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
     <div class="panel panel-default">
                                <div class="panel-heading ui-draggable-handle">                                
                                    <h3 class="panel-title">GL Postings</h3>   
                                                              
                                </div>
                                <div class="dataTables_wrapper no-footer">
                                   
                                       
                                    <div class="col-md-4">
                                        <asp:TextBox id="searchbydebit" class="form-control" placeholder="Search by Account Debited" runat="server"></asp:TextBox>
                                    </div>
                                       
                    <div class="col-md-4">
                                       <asp:TextBox id="searchbycredit" class="form-control"  placeholder="Search by Account Credited" runat="server"></asp:TextBox>
                                    </div>        
                                           <asp:Button class="btn btn-primary" text="Search" id="search" runat="server"/>
                                    <br>
                                     
                                       <asp:GridView ID="glpostingtable" CssClass="table datatable_simple dataTable no-footer" OnPageIndexChanging="glpostingtable_OnPageIndexChanging" runat="server" AutoGenerateColumns = "false" AllowPaging = "true" >
                                            
                                            <Columns>
                                            <asp:BoundField DataField = "ID" HeaderText = "S/N" />
                                            <asp:BoundField DataField = "AccountToDebit.Name" HeaderText = "Account Debited" />
                                            <asp:BoundField DataField = "AccountToCredit.Name" HeaderText = "Account Credited" />
                                            <asp:BoundField DataField = "Amount" HeaderText = "Amount" />
                                            <asp:BoundField DataField = "Narration" HeaderText = "Posting Description" />
                                            <asp:BoundField DataField = "TransactionDate" HeaderText = "Posting Date and Time" />

                                            </Columns>
       
                                       </asp:GridView>
                                       
                                    </div>
            </div>
</asp:Content>
