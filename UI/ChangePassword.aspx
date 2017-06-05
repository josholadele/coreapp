<%@ Page Title="" Language="C#" MasterPageFile="~/UI.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="UI.ChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    

       <div class="panel panel-warning">
               <div class="panel-heading">
                   <h3 class="panel-title">Change Password</h3>
               </div>
               <div class="panel-body">
                    <div class="form-group">
                        <div class="col-md-6"> 
                            <p>
                                 
                                    <span class="xn-text">Current Password</span>
                                <%--<asp:Label  Text="First Name:" runat="server"></asp:Label>--%>
                                <asp:TextBox ID="oldpassword" TextMode="Password" required="required"  placeholder="old password" class="form-control" runat="server" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="oldpassword" ErrorMessage="Required field cannot be left blank." Display="Dynamic">
                                </asp:RequiredFieldValidator>
                            </p>
    
                            <p>
                            <asp:Label Text="New Password" runat="server"></asp:Label>
                            <asp:TextBox ID="newpassword" TextMode="Password" required="required" placeholder="new password" class="form-control" runat="server" ></asp:TextBox>
                            </p>
                            
                            <p>
                            <asp:Label Text="Confirm New Password" runat="server"></asp:Label>
                            <asp:TextBox ID="confirmnewpassword" TextMode="Password" required="required" placeholder="new password" class="form-control" runat="server" ></asp:TextBox>
                            </p>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Passwords do not match."    ControlToCompare="confirmnewpassword" ControlToValidate="newpassword">
                            </asp:CompareValidator>
                          </div>
                   </div>
             </div>
               <div class="panel-footer">
                                <asp:Button class="btn btn-default " OnClick="back_Click" ID="Back"  Text="Back" runat="server"/>
                                <asp:Button class="btn btn-primary pull-right" OnClick="changepassword_Click" ID="LoginButton"  Text="Change Password" runat="server"/>
                             
                    </div>
        </div>

</asp:Content>
