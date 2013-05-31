<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SessionType.aspx.cs" Inherits="PointSiteTest.SessionType" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Session Type List</h3>
    <p><a href="AddSessionType.aspx">Add new Session Type</a></p>
    

    <asp:EntityDataSource ID="SessionTypeEntityDataSource" runat="server" ConnectionString="name=PointAppDBContainer" DefaultContainerName="PointAppDBContainer" EnableDelete="True" EnableFlattening="False" EnableInsert="True" EnableUpdate="True" EntitySetName="sessiontypes">
    </asp:EntityDataSource>
    

    <asp:GridView ID="SessionTypeGridView" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="sessiontypeid" DataSourceID="SessionTypeEntityDataSource">
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
            <asp:BoundField DataField="typename" HeaderText="Type" SortExpression="typename" />
            <asp:BoundField DataField="note" HeaderText="note" SortExpression="note" />
        </Columns>
    </asp:GridView>
    

    <br />
</asp:Content>
