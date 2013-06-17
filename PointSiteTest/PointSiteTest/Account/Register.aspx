<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="PointSiteTest.Account.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Create new account</h3>
    <table>
        <tr>
            <td>
                <asp:Label ID="memberstatuslbl" runat="server">Choose your status:</asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="memberstatus" runat="server">
                    <asp:ListItem Value="Student" Text="Student" />
                    <asp:ListItem Value="Parent" Text="Parent" />
                </asp:DropDownList>
            </td>
        </tr>
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
            <td>
                <asp:Label ID="passphraselbl" runat="server">Enter password phrase:</asp:Label>
            </td>
            <td>
                <asp:TextBox ID="passphrase" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="createUserBtn" runat="server" Text="Create User" OnClientClick="createuserBtn_Click" />
                &nbsp;
                <asp:Button ID="cancelBtn" runat="server" Text="Cancel" OnClientClick="cancelBtn_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
