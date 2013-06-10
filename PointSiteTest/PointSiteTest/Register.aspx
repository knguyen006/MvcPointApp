<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="PointSiteTest.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register</title>
    <link href="Styles/Site.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="content-wrapper">
        <p>&nbsp;</p>
    </div>
    <div id="body">
        <h3>Register</h3>
        <table>
            <tr>
                <td>Please choose your status: (Parent or Student)</td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server">
                        <asp:ListItem>Parent</asp:ListItem>
                        <asp:ListItem>Student</asp:ListItem>

                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Enter Username:</td>
                <td>
                    <asp:TextBox ID="username" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Enter Password:</td>
                <td>
                    <asp:TextBox ID="userpass" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Enter Password Phrase:</td>
                <td>
                    <asp:TextBox ID="passphrase" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblWarning" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="registerBtn" runat="server" Text="Register" OnClick="registerBtn_Click" />
                    &nbsp;
                    <asp:Button ID="cancelBtn" runat="server" Text="Cancel" OnClick="cancelBtn_Click" />
                </td>
            </tr>
        </table>
        
        <p>If you already have an account, please go to <a href="Login.aspx">Login</a>.</p>
    </div>
    </form>
</body>
</html>
