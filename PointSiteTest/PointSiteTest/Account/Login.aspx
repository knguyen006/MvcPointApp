<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PointSiteTest.Account.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Account Login</h3>
    <table>
        <tr>
            <td>
                <asp:Label ID="usernamelbl" runat="server">Enter username:</asp:Label>
            </td>
            <td>
                <asp:TextBox ID="username" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="passwordlbl" runat="server">Enter password:</asp:Label>
            </td>
            <td>
                <asp:TextBox ID="password" runat="server" TextMode="Password" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="warninglbl" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="logonBtn" runat="server" Text="Logon" OnClientClick="logonBtn_Click" />
                &nbsp;
                <asp:Button ID="cancelBtn" runat="server" Text="Cancel" OnClientClick="cancelBtn_Click" />
            </td>
        </tr>
    </table>
</asp:Content>