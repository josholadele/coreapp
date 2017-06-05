<%@ Page Title="" Language="C#" MasterPageFile="~/UI.Master" AutoEventWireup="true" CodeBehind="AddUser.aspx.cs" Inherits="UI.Pages.AddUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <h5>Add a new user</h5>
    <form runat="server">
    <p>
    <asp:Label  Text="First Name:" runat="server"></asp:Label>
    <asp:TextBox ID="firstname" placeholder="John" runat="server" ></asp:TextBox>
    </p>
    
    <p>
    <asp:Label Text="Last Name:" runat="server"></asp:Label>
    <asp:TextBox ID="lastname" placeholder="Doe" runat="server" ></asp:TextBox>
    </p>
    
    <p>
    <asp:Label Text="Email Address:" runat="server"></asp:Label>
    <asp:TextBox ID="email" placeholder="omodele@example.com" runat="server" ></asp:TextBox>
    </p>
    
    <p>
    <asp:Label Text="Phone Number" runat="server"></asp:Label>
    <asp:TextBox ID="phonenumber" placeholder="+2348021234567" runat="server"></asp:TextBox>
    </p>
    
    <p>
    <asp:Label Text="Branch:" runat="server"></asp:Label>
    <asp:TextBox ID="branch" placeholder="Ikeja" runat="server" ></asp:TextBox>
    </p>

    <p>
    <asp:Label Text="Username:" runat="server"></asp:Label>
    <asp:TextBox ID="username" placeholder="Username" runat="server" ></asp:TextBox>
    </p>
    
    <p>
        <asp:Button class="btn btn-default" OnClick="adduser_Click" ID="LoginButton"  Text="Add User" runat="server"/>
    </p>
    
    <asp:TextBox ID="myConfirm" runat="server" />
    <br /><br />
    </form>

</asp:Content>
