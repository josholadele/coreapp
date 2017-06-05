<%@ Page Title="" Language="C#" MasterPageFile="~/UI.Master" AutoEventWireup="true" CodeBehind="EOD.aspx.cs" Inherits="UI.EOD" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!DOCTYPE html>
        <html>
        <head>
        <style>
        .center1
        {
            float: left;
            width: 150px;
            height: 75px;
            margin: 10px;
            text-align:center;
            padding-top: 200px;
            padding-left: 300px;
            vertical-align: middle;
            /*border: 3px solid #73AD21;*/  
        }
        </style>
        </head>
    <body>
    
        <asp:Panel ID="EOD_close" Visible="False" runat="server">
            <div class="center1">
            <p>
                <asp:Button runat="server"  BackColor="#e34724" ForeColor="White" OnClick="close_Click" Font-Size="15" Text="Close Business" Height="70px" Width="300px"/>
                </p>
                </div>
                </asp:Panel>
                <asp:Panel ID="EOD_open" Visible="False" runat="server">
                    <div class="center1">
                <p>
            <asp:Button runat="server" BackColor="#33414e" ForeColor="White" OnClick="open_Click" Height="70px" Font-Size="15" Text="Open Business" Width="300px"/>
    
            </p>
            </div>
        </asp:Panel>
    </body>
            </html>
    
    

</asp:Content>
