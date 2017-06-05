<%@ Page Title="" Language="C#" MasterPageFile="~/UI.Master" AutoEventWireup="true" CodeBehind="AddGLCategory.aspx.cs" Inherits="UI.AddGLCategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
     
        <asp:Panel ID="addGLCategory" Visible="True" runat="server">

        
        <div class="panel panel-success">
               <div class="panel-heading">
                   <h3 class="panel-title">Create a GL category</h3>
               </div>
               <div class="panel-body">
                    <div class="form-group">
                        <div class="col-md-6"> 
                            <p>
                                    <span class="xn-text">Name</span>
                                <%--<asp:Label  Text="First Name:" runat="server"></asp:Label>--%>
                                <%--<asp:TextBox ID="name" placeholder="Cash Payable" class="form-control" runat="server" ></asp:TextBox>--%>
                                <input type="text" runat="server" id="name" clientidmode="Static" class="form-control" pattern="[A-Z a-z]+" title="Invalid input" maxlength="20" required="required" />
                            </p>
    
                            <p>
                            <asp:Label Text="Account Category" runat="server"></asp:Label>
                            <asp:DropDownList ID="accountcategory" required="required" AppendDataBoundItems="True" class="form-control" runat="server" >
                                <asp:ListItem Text="-Select Account Category-" Value="0"/>
                            </asp:DropDownList>
                            </p>
                            <p>
                                <asp:Label Text="Short Description" runat="server"></asp:Label>
                                <asp:TextBox ID="description" placeholder="A short description" MaxLength="60" class="form-control" runat="server" ></asp:TextBox>
                            </p>
     
                      </div>
                                
                    </div>
                </div>
                    <div class="panel-footer">
                                <asp:Button class="btn btn-default " OnClick="back_Click" ID="Back"  Text="Back" runat="server"/>
                                <asp:Button class="btn btn-primary pull-right" OnClick="addGL_Click" ID="AddButton"  Text="Add GL" runat="server"/>
                             
                    </div>
           </div>
      
            </asp:Panel>
  
</asp:Content>
