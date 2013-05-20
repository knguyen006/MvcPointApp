<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Activity.aspx.cs" Inherits="PointSiteTest.Activity" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Activity List</h3>
    <p><a href="AddActivity.aspx">Add new Activity</a></p>
    <asp:EntityDataSource ID="EntityDataSource1" runat="server" ConnectionString="name=PointAppDBContainer" DefaultContainerName="PointAppDBContainer" EnableDelete="True" EnableFlattening="False" EnableInsert="True" EnableUpdate="True" EntitySetName="activities">
    </asp:EntityDataSource>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="activityid" DataSourceID="EntityDataSource1">
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
            <asp:BoundField DataField="activityid" HeaderText="activityid" ReadOnly="True" SortExpression="activityid" />
            <asp:BoundField DataField="actname" HeaderText="actname" SortExpression="actname" />
        </Columns>
    </asp:GridView>
    <br />
</asp:Content>
