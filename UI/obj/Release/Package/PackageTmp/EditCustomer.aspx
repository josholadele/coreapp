<%@ Page Title="" Language="C#" MasterPageFile="~/UI.Master" AutoEventWireup="true" CodeBehind="EditCustomer.aspx.cs" Inherits="UI.EditCustomer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
     <div class="panel panel-success">
                        <div class="panel-heading">
                                <h3 class="panel-title">Edit Customer Details</h3>
                        </div>
                 <div class="panel-body">
                    <div class="form-group">
                        <div class="col-md-6"> 
                            <p>
                                    <span class="xn-text">Full Name</span>
                                <%--<asp:Label  Text="First Name:" runat="server"></asp:Label>--%>
                                <asp:TextBox ID="fullname" class="form-control" runat="server" ></asp:TextBox>
                            </p>
    
                            <p>
                            <asp:Label Text="Address" runat="server"></asp:Label>
                            <asp:TextBox ID="address" class="form-control" runat="server" ></asp:TextBox>
                            </p>

                            <p>
                            <asp:Label Text="Email Address" runat="server"></asp:Label>
                            <asp:TextBox ID="email"  class="form-control" runat="server" ></asp:TextBox>
                            </p>
    
                            <p>
                            <asp:Label Text="Phone Number" runat="server"></asp:Label>
                            <asp:TextBox ID="phonenumber" class="form-control" runat="server"></asp:TextBox>
                            </p>
    
                            <p>
                                <asp:Label Text="Gender" runat="server"></asp:Label>
                                <asp:DropDownList ID="gender" AppendDataBoundItems="True" class="form-control" runat="server" >
                                    <asp:ListItem Text="-Select Gender-" Value="0"/>
                                </asp:DropDownList>
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
