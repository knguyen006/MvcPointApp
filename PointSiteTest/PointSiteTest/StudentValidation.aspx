<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentValidation.aspx.cs" Inherits="PointSiteTest.StudentValidation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h3>Check student name</h3>
        <table>
            <tr>
                <td>Enter student first name:</td>
                <td>
                    <asp:TextBox ID="firstname" runat="server" />
                </td>
            </tr>
            <tr>
                <td>Enter student last name:</td>
                <td>
                    <asp:TextBox ID="lastname" runat="server" />
                </td>
            </tr>
            <tr>
                <td>Enter student grade:</td>
                <td>
                    <asp:TextBox ID="grade" runat="server" />
                </td>
            </tr>
        </table>
            <asp:Button ID="Button1" runat="server" Text="Verify" OnClick="Button1_Click" />
    </div>
    </form>
</body>
</html>
