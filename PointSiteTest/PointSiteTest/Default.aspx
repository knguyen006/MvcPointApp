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
        <li><a id="A3" runat="server" href="~/Activity.aspx">Session Type List</a></li>
    </ol>
</asp:Content>
