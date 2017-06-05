<%@ Page Title="" Language="C#" MasterPageFile="~/UI.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="UI.Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
 <div class="row">
        
        <div class="col-md-3">
            <h2>Add New User</h2>
            <p>
                <asp:Button class="btn btn-default" Text ="Add Here »" ID="newuser"  runat="server" OnClick="NewUser_Click" />
            </p>
        </div>
        <div class="col-md-3">
            <h2>View All Users</h2>
            <p>
                <asp:Button class="btn btn-default" Text ="View Here »" ID="viewusers"  runat="server" OnClick="ViewUsers_Click" />
            </p>
        </div>
        <div class="col-md-3">
            <h2>Add Branch</h2>
           <p>
                <asp:Button class="btn btn-default" Text ="Add Here »" ID="addbranch"  runat="server" OnClick="AddBranch_Click" />
            </p>
        </div>
        <div class="col-md-3">
            <h2>View Branches</h2>
            
            <p>
                <asp:Button class="btn btn-default" Text ="View Here »" ID="viewbranch"  runat="server" OnClick="ViewBranch_Click" />
            </p>
        </div>

  </div>
</asp:Content>
