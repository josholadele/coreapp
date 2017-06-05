<%@ Page Title="" Language="C#" MasterPageFile="~/UI.Master" AutoEventWireup="true" CodeBehind="ViewTellers.aspx.cs" Inherits="UI.ViewTellers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
     <div class="panel panel-default">
                                <div class="panel-heading ui-draggable-handle">                                
                                    <h3 class="panel-title">Tellers' List</h3>   
                                                              
                                </div>
                                <div class="dataTables_wrapper no-footer">
                                   
                                    <div class="col-md-4">
                                        <asp:TextBox id="searchbyteller" class="form-control" placeholder="Search by Teller" runat="server"></asp:TextBox>
                                    </div>
                                       <div class="col-md-4">
                                       <asp:TextBox id="searchbytill" class="form-control"  placeholder="Search by Till" runat="server"></asp:TextBox>
                                    </div>
                                           <asp:Button class="btn btn-primary" text="Search" id="search" runat="server"/>
                                    

                                       <asp:GridView ID="tellertable" CssClass="table datatable_simple dataTable no-footer" runat="server" AutoGenerateColumns = "false" AllowPaging = "true" >
                                            
                                            <Columns>
                                            <asp:BoundField DataField = "ID" HeaderText = "S/N" />
                                            <asp:BoundField DataField = "Teller.Username" HeaderText = "Teller username" />
                                            <asp:BoundField DataField = "Till.Name" HeaderText = "Till Assigned" />
                                            <asp:BoundField DataField = "Till.Balance" HeaderText = "Till Balance" />
                                            <asp:BoundField DataField = "IsAssigned" HeaderText = "IsAssigned" />
                                        <%--<asp:BoundField DataField="ID" HeaderText = "Edit User" HtmlEncode="False" DataFormatString="<a class='fa fa-pencil' href='EditUser.aspx?UserID={0}' Title='Edit'></a>"/>--%>
                                            </Columns>
       
                                       </asp:GridView>
                                       
                                    </div>
            </div>

</asp:Content>
