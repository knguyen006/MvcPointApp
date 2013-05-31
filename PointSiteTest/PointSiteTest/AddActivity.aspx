<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddActivity.aspx.cs" Inherits="PointSiteTest.AddActivity" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Add new Activity</h3>
    <asp:EntityDataSource ID="ActivityEntityDataSource" runat="server" 
        ConnectionString="name=PointAppDBContainer" DefaultContainerName="PointAppDBContainer" 
        EnableFlattening="False" EntitySetName="activities"
        EnableInsert="true">
    </asp:EntityDataSource>
    <asp:DetailsView ID="ActivityDetailsView" runat="server" AutoGenerateRows="false"
        DataSourceID="ActivityEntityDataSource" DataKeyNames="activityid"
        DefaultMode="Insert">
        <Fields>
            <asp:BoundField DataField="actname" HeaderText="actname" />
            <asp:CommandField ShowInsertButton="true" />
        </Fields>
    </asp:DetailsView>
    <p><a id="A1" runat="server" href="~/Activity.aspx">Go back to activity list</a></p>
    <br />
</asp:Content>
