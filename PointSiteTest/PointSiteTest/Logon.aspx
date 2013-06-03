<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Logon.aspx.cs" Inherits="PointSiteTest.Logon" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Logon Page</h3>
    <table>
        <tr>
            <td>User name:</td>
            <td><input id ="txtUsername" type="text" runat="server" /></td>
            <td><asp:RequiredFieldValidator ControlToValidate="txtUsername"
                Display="Static" ErrorMessage="*" runat="server" ID="username" /></td>
        </tr>
        <tr>
            <td>Password:</td>
            <td><input id="txtUserpass" type="password" runat="server" /></td>
            <td><asp:RequiredFieldValidator ControlToValidate="txtUserpass"
                Display="Static" ErrorMessage="*" runat="server" ID="userpass" /></td>
        </tr>
        <tr>
          <td>Remember Password:</td>
          <td><ASP:CheckBox id="chkPersistCookie" runat="server" autopostback="false" /></td>
          <td></td>
       </tr>
    </table>
    <input type="submit" value="Logon" runat="server" id="cmdLogin" />
    <br />
    <asp:Label ID="lblMsg" ForeColor="Red" Font-Names="Verdana" Font-Size="10" runat="server" />
</asp:Content>
