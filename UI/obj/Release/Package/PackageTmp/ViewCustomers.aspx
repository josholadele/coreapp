<%@ Page Title="" Language="C#" MasterPageFile="~/UI.Master" AutoEventWireup="true" CodeBehind="ViewCustomers.aspx.cs" Inherits="UI.ViewCustomers" %>

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
                           
                    <div class="col-md-4">
                                        <asp:TextBox id="searchbyname" class="form-control" placeholder="Search by Name" runat="server"></asp:TextBox>
                                    </div>
                                       
                    <div class="col-md-2">
                                       <asp:TextBox id="searchbygender" class="form-control"  placeholder="Search by Gender" runat="server"></asp:TextBox>
                                    </div>        
                                           <asp:Button class="btn btn-primary" text="Search" id="search" runat="server"/>
                                    <br>
                    
                            
                    <asp:GridView ID="customertable" CssClass="table datatable_simple dataTable no-footer" runat="server" AutoGenerateColumns = "false" AllowPaging = "true" >
                                            
                                           <Columns>
                                            <asp:BoundField DataField = "Name" HeaderText = "Customer Name" />
                                            <asp:BoundField DataField = "Address" HeaderText = "Address" />
                                            <asp:BoundField DataField = "PhoneNumber" HeaderText = "Phone Number" />
                                            <asp:BoundField DataField = "Email" HeaderText = "Email Address" />
                                            <asp:BoundField DataField = "Gender" HeaderText = "Gender" />
                                            <asp:BoundField DataField="ID" HeaderText = "Edit Customer" HtmlEncode="False" DataFormatString="<a class='fa fa-pencil' href='EditCustomer.aspx?CustomerID={0}' Title='Edit'></a>"/>

                                            
                                            </Columns>
       
                                       </asp:GridView>

                                    </div>
             </div>
            </div>
    </body>

</asp:Content>
