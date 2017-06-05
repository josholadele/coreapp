<%@ Page Title="Add Branch" Language="C#" MasterPageFile="~/UI.Master" AutoEventWireup="true" CodeBehind="AddBranch.aspx.cs" Inherits="UI.AddBranch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    
    <h2><%: Title %>.</h2>
        
    <asp:Panel ID="alert" Visible="False" runat="server">
        <div class="alert alert-success" role="alert">
                                <button type="button" class="close" data-dismiss="alert"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                                 User created. Check Email for login details.
        </div>
        </asp:Panel>
    <div class="col-md-6">
    <p>
        
    <asp:Label Text="Branch Name:" runat="server"></asp:Label>
    <asp:TextBox ID="branchname" class="form-control" MaxLength="25" runat="server" ></asp:TextBox>
    <%--<input type="text" runat="server" id="firstname" clientidmode="Static" class="form-control" pattern="[A-Z a-z]+" title="Invalid input" maxlength="20" required="required" />--%>

   <%--<asp:TextBox runat="server"  Text="45" id="institutionCode"   Visible="True" TextMode="Number"/>--%>

    </p>
    
    <p>
      
    <asp:Label Text="Branch Address:" runat="server"></asp:Label>
    <asp:TextBox ID="address" class="form-control" placeholder="Input Address" MaxLength="60" runat="server" ></asp:TextBox>
        
    </p>
    
    <p>
        <asp:Button class="btn btn-default"  ID="AddButton"  Text="Add Branch" runat="server" OnClick="AddButton_Click"/>
    </p>
    </div>
    

</asp:Content>
