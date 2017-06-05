<%@ Page Title="" Language="C#" MasterPageFile="~/UI.Master" AutoEventWireup="true" CodeBehind="ViewBranch.aspx.cs" Inherits="UI.ViewBranch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<div class="panel panel-default">
                                <div class="panel-heading ui-draggable-handle">                                
                                    <h3 class="panel-title">Branches</h3>   
                                                              
                                </div>
                                <div class="dataTables_wrapper no-footer">
                                   
                                    <div class="col-md-4">
                                        <asp:TextBox id="searchbyname" class="form-control" placeholder="Search by Customer" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-2">
                                       <asp:TextBox id="searchbygender" class="form-control"  placeholder="Search by Account Type" runat="server"></asp:TextBox>
                                    </div>        
                                           <asp:Button class="btn btn-primary" text="Search" id="search" runat="server"/>
                                    <br>

                                        
                                       <asp:GridView ID="branchtable" CssClass="table datatable_simple dataTable no-footer" runat="server" AutoGenerateColumns = "false" AllowPaging = "true" >
                                            
                                            <Columns>
                                            <asp:BoundField DataField = "ID" HeaderText = "S/N" />
                                            <asp:BoundField DataField = "Name" HeaderText = "Branch Name" />
                                            <asp:BoundField DataField = "Address" HeaderText = "Branch Address" />
                                            <%--<asp:BoundField DataField = "Description" HeaderText = "Description" />--%>
                                            </Columns>
       
                                       </asp:GridView>
                                       
                                    </div>
            </div>
  
</asp:Content>
