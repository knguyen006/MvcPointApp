<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Activity.aspx.cs" Inherits="PointSiteTest.Activity" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <div class="content-wrapper">
        <a href="/Role.aspx">Roles</a> | 
        <a href="/Activity.aspx">Activity</a> | 
        <a href="/Student.aspx">Student</a> | 
        <a href="/Contact.aspx">Contact</a> | 
        <a href="/Member.aspx">Member</a> | 
        <a href="/SessionType.aspx">Session Type</a> | 
        <a href="/SessionCal.aspx">Session Calendar</a> | 
        <a href="/SignUp.aspx">Sign Up</a> |
        <a href="/FeeRequest.aspx">Fee Request</a>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Activity List</h3>
    <asp:ObjectDataSource ID="ActivityObj" runat="server" SelectMethod="GetActivity" TypeName="DataLayerBusiness.ActivityMgr"></asp:ObjectDataSource>
    <asp:Repeater ID="ActivityRepeater" runat="server" DataSourceID="ActivityObj"></asp:Repeater>
</asp:Content>
