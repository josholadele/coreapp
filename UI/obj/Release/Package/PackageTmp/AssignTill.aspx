<%@ Page Title="" Language="C#" MasterPageFile="~/UI.Master" AutoEventWireup="true" CodeBehind="AssignTill.aspx.cs" Inherits="UI.AssignTill" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
   <div class="panel panel-warning">
                        <div class="panel-heading">
                                <h3 class="panel-title">Assign Teller a Till Account</h3>
                        </div>
                 <div class="panel-body">
                    <div class="form-group">
                        <div class="col-md-6"> 
                            <p>
                                <p>
                                    <asp:Label Text="Select User" runat="server"></asp:Label>
                                    <asp:DropDownList ID="user" required="required" AppendDataBoundItems="True" class="form-control" runat="server" DataTextField="Username" >
                                    <asp:ListItem Text="-Select a user-" Value="0"/>
                                    </asp:DropDownList>
                                </p>
    
                            <p>
                                <span class="xn-text">Select Till Account</span>
                                <asp:DropDownList ID="till" required="required" AppendDataBoundItems="True" class="form-control" runat="server" DataTextField="Name" >
                                    <asp:ListItem Text="-Assign till-" Value="0"/>
                                </asp:DropDownList>

                            </p>
                            
                            <p>
                                    <asp:TextBox Visible="False" ID="balance" DataTextField="Balance" runat="server"></asp:TextBox>
                            </p>
                            
                        </div>  
                   
                  </div>
               </div>
            <div class="panel-footer">
                                <asp:Button class="btn btn-default " OnClick="back_Click" ID="Back"  Text="Back" runat="server"/>
                                <asp:Button class="btn btn-primary pull-right" OnClick="assign_Click" ID="AssignButton"  Text="Assign" runat="server"/>
                             
                    </div>
            </div>
   
</asp:Content>
