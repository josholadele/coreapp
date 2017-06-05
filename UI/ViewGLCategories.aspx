<%@ Page Title="" Language="C#" MasterPageFile="~/UI.Master" AutoEventWireup="true" CodeBehind="ViewGLCategories.aspx.cs" Inherits="UI.ViewGLCategories" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
     <div class="panel panel-default">
                                <div class="panel-heading ui-draggable-handle">                                
                                    <h3 class="panel-title">GL Categories</h3>   
                                                              
                                </div>
                                <div class="dataTables_wrapper no-footer">
                                   
                                    <div class="col-md-4">
                                        <asp:TextBox id="searchbyname" class="form-control" placeholder="Search by Name" runat="server"></asp:TextBox>
                                    </div>
                                       
                    <div class="col-md-2">
                       <asp:DropDownList id="searchbyaccCat" ClientIDMode="Static" class="form-control" AppendDataBoundItems="True"  placeholder="Search by Account Type" runat="server">
                                           <asp:ListItem />
                                       </asp:DropDownList>
                    </div>       
                                                              
                                           <asp:Button class="btn btn-primary" text="Search" id="search" runat="server"/>
                                    <br>
                                        
                                       <asp:GridView ID="gltable" CssClass="table datatable_simple dataTable no-footer" runat="server" AutoGenerateColumns = "false" AllowPaging = "true" >
                                            
                                            <Columns>
                                            <asp:BoundField DataField = "ID" HeaderText = "S/N" />
                                            <asp:BoundField DataField = "Name" HeaderText = "Name" />
                                            <asp:BoundField DataField = "AccountCategory" HeaderText = "Main Account Category" />
                                            <asp:BoundField DataField = "Description" HeaderText = "Description" />
                                            <asp:BoundField DataField="ID" HeaderText = "Edit GL Category" HtmlEncode="False" DataFormatString="<a class='fa fa-pencil' href='EditGLCategory.aspx?GLCategoryID={0}' Title='Edit'></a>"/>
                                            </Columns>
       
                                       </asp:GridView>
                                       
                                    </div>
            </div>
    <script type="text/javascript">
               $(function () {
                   debugger;
                   $("#searchbyaccCat").select2({});
                   
               });
        </script>
</asp:Content>
