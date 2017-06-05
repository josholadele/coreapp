<%@ Page Title="" Language="C#" MasterPageFile="~/UI.Master" AutoEventWireup="true" CodeBehind="EditATMTerminal.aspx.cs" Inherits="UI.EditATMTerminal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="panel panel-success">
                        <div class="panel-heading">
                                <h3 class="panel-title">Edit Customer Details</h3>
                        </div>
                 <div class="panel-body">
                    <div class="form-group">
                        <div class="col-md-6"> 
                            <p>
                                    <span class="xn-text">Name</span>
                                <%--<asp:Label  Text="First Name:" runat="server"></asp:Label>--%>
                                <asp:TextBox ID="name" class="form-control" runat="server" ></asp:TextBox>
                            </p>
    
                            <p>
                                    <span class="xn-text">Terminal ID</span>
                                <%--<asp:Label  Text="First Name:" runat="server"></asp:Label>--%>
                                <asp:TextBox ID="terminalID" class="form-control" runat="server" ></asp:TextBox>
                            </p>

                            <p>
                            <asp:Label Text="Location" runat="server"></asp:Label>
                            <asp:TextBox ID="location" class="form-control" runat="server" ></asp:TextBox>
                            </p>

                           <asp:TextBox ID="intt" Visible="False" class="form-control" runat="server"></asp:TextBox>
                         
                        </div>  
                   
                  </div>
               </div>
            <div class="panel-footer">
                                <asp:Button class="btn btn-default " OnClick="back_Click" ID="Back"  Text="Back" runat="server"/>
                                <asp:Button class="btn btn-primary pull-right" OnClick="save_Click" ID="SaveButton"  Text="Save Changes" runat="server"/>
                             
            </div>
          </div>

</asp:Content>
