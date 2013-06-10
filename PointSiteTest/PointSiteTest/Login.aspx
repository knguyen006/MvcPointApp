<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PointSiteTest.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Login Form</title>
    <link href="Styles/Site.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="content-wrapper">
            <p>&nbsp;</p>
        </div>
        <div id ="body">
            <h3>Login</h3>
            <table>
                <tr>
                    <td>Enter username:</td>
                    <td>
                        <asp:TextBox ID="username" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>Enter Password:</td>
                    <td>
                        <asp:TextBox ID="userpass" runat="server" TextMode="Password" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="lblWarning" runat="server" Text="Label"></asp:Label>
                   </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="loginBtn" runat="server" Text="Logon" OnClick="loginBtn_Click" />
                        &nbsp;
                        <asp:Button ID="cancelBtn" runat="server" Text="Button" OnClick="cancelBtn_Click" />
                    </td>
                </tr>
            </table>

            <p>If you don't have an account, please go to <a href="Register.aspx">Register</a> new account.</p>
        </div>
    </form>
</body>
</html>
