<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginTest.aspx.cs" Inherits="PointSiteTest.LoginTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
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
                        <asp:TextBox ID="userpassword" runat="server" TextMode="Password" />
                    </td>
                </tr>
                <tr>
                    <td>Re-enter Password:</td>
                    <td>
                        <asp:TextBox ID="reuserpass" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>Enter Password Phrase:</td>
                    <td>
                        <asp:TextBox ID="passphrase" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>Member Type:</td>
                    <td>
                        <asp:DropDownList ID="DropDownList1" runat="server"
                            AppendDataBoundItems="true">
                            <asp:ListItem Value="-1">Select</asp:ListItem>
                            <asp:ListItem>Parent</asp:ListItem>
                            <asp:ListItem>Student</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
            <asp:Button ID="Button1" runat="server" Text="Save" onclick="Button1_Click" />
        </div>
    </form>
</body>
</html>
