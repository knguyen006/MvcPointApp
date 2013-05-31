<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PointSiteTest.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <p>The following is the link of different pages:</p>
    <ol>
        <li><a id="A1" runat="server" href="~/Student.aspx">Student List</a></li>
        <li><a id="A2" runat="server" href="~/Activity.aspx">Activity List</a></li>
        <li><a id="A3" runat="server" href="~/SessionType.aspx">Session Type List</a></li>
        <li><a id="A4" runat="server" href="~/AppRole.aspx">Application Role List</a></li>
        <li><a id="A5" runat="server" href="~/Member.aspx">Member List</a></li>
    </ol>
</asp:Content>
