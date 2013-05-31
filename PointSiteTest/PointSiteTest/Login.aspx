<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PointSiteTest.Login" %>
@{
    var message="";
    Validation.RequireField("username", "User name is require");
    Validation.Add("username", Validator.StringLength(32));

    if(IsPost){
        if(Validation.IsValid()){
            var username = Request["username"];

            message += @"For username, you entered " + username;
        }    
    }
}
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
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="username"
                            ErrorMessage="This field is required.">*
                        </asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Enter Password:</td>
                    <td>
                        <asp:TextBox ID="userpass" runat="server" TextMode="Password" />
                    </td>
                </tr>
                <tr>
                    <td>Re-enter Password:</td>
                    <td>
                        <asp:TextBox ID="reuserpass" runat="server" TextMode="Password" />
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
            <asp:Button ID="Button1" runat="server" Text="Save" onclick="Button1_Click" ValidationGroup="MyValidationGroup" CausesValidation="true" />
        </div>
    </form>
</body>
</html>
