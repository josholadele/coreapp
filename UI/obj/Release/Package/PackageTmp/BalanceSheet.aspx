<%@ Page Title="" Language="C#" MasterPageFile="~/UI.Master" AutoEventWireup="true" CodeBehind="BalanceSheet.aspx.cs" Inherits="UI.BalanceSheet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
   <div class="panel panel-default">
                                <div class="panel-heading ui-draggable-handle">
                                    
                                    <div class="form-group">
                                        <label class="col-md-1 control-label">From</label>
                                        <div class="col-md-4">
                                            <asp:TextBox ID="dateFrom" class="form-control datepicker" runat="server" ></asp:TextBox>
                                        </div>

                                        <label class="col-md-1 control-label">To</label>
                                        <div class="col-md-4">
                                            <asp:TextBox ID="dateTo" class="form-control datepicker" runat="server" ></asp:TextBox>
                                        </div>
                                        <asp:Button CssClass="btn btn-default" runat="server" OnClick="onGo_Click" Text="Go"/>
                                    </div>
                                                                    
                                    <h3 class="panel-title">Balance Sheet</h3>   
                                                              
                                </div>
                                <div class="dataTables_wrapper no-footer">
                                   
                                        
                                       <asp:GridView ID="balancetable" CssClass="table datatable_simple dataTable no-footer" OnRowDataBound="balancetable_OnRowDataBound" runat="server" AutoGenerateColumns = "false" Height="409px" Width="797px">
                                            
                                            <Columns>
                                            <asp:BoundField DataField="Name" HeaderStyle-BackColor="#33414e" HeaderStyle-ForeColor="#ffffff" HeaderText = "Description" />
                                            <asp:BoundField DataField="Debit (Dr)" HeaderStyle-BackColor="#33414e"  HeaderStyle-ForeColor="#ffffff" HeaderText = "Debit (₦)" ItemStyle-Width="200px"/>
                                            <asp:BoundField DataField="Credit (Cr)" HeaderStyle-BackColor="#33414e" HeaderStyle-ForeColor="#ffffff" HeaderText = "Credit (₦)" ItemStyle-Width="200px"/>
                                           
                                            </Columns>
       
                                       </asp:GridView>
                                       
                                    </div>
            </div>
  
</asp:Content>
