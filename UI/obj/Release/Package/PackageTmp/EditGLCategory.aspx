<%@ Page Title="" Language="C#" MasterPageFile="~/UI.Master" AutoEventWireup="true" CodeBehind="EditGLCategory.aspx.cs" Inherits="UI.EditGLCategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
       
        <asp:Panel ID="addGLAccount" runat="server">

        
        <div class="panel panel-success">
               <div class="panel-heading">
                   <h3 class="panel-title">Edit GL category</h3>
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
                                <asp:Label Text="Short Description" runat="server"></asp:Label>
                                <asp:TextBox ID="description" placeholder="A short description" MaxLength="50" class="form-control" runat="server" ></asp:TextBox>
                            </p>

                             
    </div>
                        </div>
                   </div> </div>
            <div class="panel-footer">
                                <asp:Button class="btn btn-default " OnClick="back_Click" ID="Back"  Text="Back" runat="server"/>
                                <asp:Button class="btn btn-primary pull-right" OnClick="edit_Click" ID="EditButton"  Text="Save Changes" runat="server"/>
                             
            </div>
            </asp:Panel>
   
</asp:Content>
