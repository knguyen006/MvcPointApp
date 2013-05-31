<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddAppRole.aspx.cs" Inherits="PointSiteTest.AddAppRole" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Add new Role</h3>
    <asp:EntityDataSource ID="AppRoleEntityDataSource" runat="server" 
        ConnectionString="name=PointAppDBContainer" DefaultContainerName="PointAppDBContainer" 
        EnableFlattening="False" EnableInsert="True" EntitySetName="approles">
    </asp:EntityDataSource>
    <asp:DetailsView ID="AppRoleDetailsView" runat="server"
        AutoGenerateRows="false" DataKeyNames="approleid"
        DefaultMode="Insert" DataSourceID="AppRoleEntityDataSource">
        <Fields>
            <asp:BoundField DataField="rolename" HeaderText="rolename" />
            <asp:BoundField DataField="note" HeaderText="note" />
            <asp:CommandField ShowInsertButton="true" />
        </Fields>
    </asp:DetailsView>
    <p><a id="A1" runat="server" href="~/AppRole.aspx">Go back to application role list</a></p>
    <br />
</asp:Content>
