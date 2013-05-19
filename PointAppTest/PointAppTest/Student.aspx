<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Student.aspx.cs" Inherits="PointAppTest.Student" %>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2>Student List</h2>
    <p>
        Testing
    </p>
    <p>
        <asp:EntityDataSource ID="PointAppDBConnectionString" runat="server">
        </asp:EntityDataSource>
    </p>
    <asp:ValidationSummary ID="StudentsValidationSummary" runat="server" ShowSummary="true"
    DisplayMode="BulletList" Style="color: Red" />
    <br />
    <br />
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/StudentsAdd.aspx" >Add Student</asp:HyperLink>
</asp:Content>
