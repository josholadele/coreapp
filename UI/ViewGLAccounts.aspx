<%@ Page Title="" Language="C#" MasterPageFile="~/UI.Master" AutoEventWireup="true" CodeBehind="ViewGLAccounts.aspx.cs" Inherits="UI.ViewGLAccounts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
   
     <div class="panel panel-default">
                                <div class="panel-heading ui-draggable-handle">                                
                                    <h3 class="panel-title">GL Accounts</h3>   
                                                              
                                </div>
                                <div class="dataTables_wrapper no-footer">
                                   
                                    <div class="col-md-4">
                                        <asp:TextBox id="searchbyname" class="form-control" placeholder="Search by Name" runat="server"></asp:TextBox>
                                    </div>
                                       
                    <div class="col-md-2">
                                       <asp:TextBox id="searchbyglCat" class="form-control"  placeholder="Search by GL Category" runat="server"></asp:TextBox>
                                    </div>        
                                           <asp:Button class="btn btn-primary" text="Search" id="search" runat="server"/>
                                    <br>  
                                      
                                       <asp:GridView ID="gltable" CssClass="table datatable_simple dataTable no-footer" runat="server" AutoGenerateColumns = "false" OnPageIndexChanging="glaccounttable_OnPageIndexChanging" AllowPaging = "true">
                                            
                                            <Columns>
                                            <asp:BoundField DataField = "ID" HeaderText = "S/N" />
                                            <asp:BoundField DataField = "Name" HeaderText = "Name" />
                                            <asp:BoundField DataField = "GLCategory.Name" HeaderText = "Main Account Category" />
                                            <asp:BoundField DataField = "Balance" HeaderText = "Balance" />
                                            <%--<asp:BoundField DataField = "Description" HeaderText = "Description" />--%>
                                            <asp:BoundField DataField="ID" HeaderText = "Edit GL Account" HtmlEncode="False" DataFormatString="<a class='fa fa-pencil' href='EditGLAccount.aspx?GLAccountID={0}' Title='Edit'></a>"/>
                                            </Columns>
       
                                       </asp:GridView>
                                       
                                    </div>
            </div>

</asp:Content>
