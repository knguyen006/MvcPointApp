<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SessionType.aspx.cs" Inherits="PointSiteTest.SessionType" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Session Type List</h3>

    <asp:EntityDataSource ID="EntityDataSource" runat="server" ConnectionString="name=PointAppDBContainer" DefaultContainerName="PointAppDBContainer" EnableDelete="True" EnableFlattening="False" EnableInsert="True" EnableUpdate="True" EntitySetName="sessiontypes">
    </asp:EntityDataSource>
    <asp:GridView ID="GridView" runat="server" AutoGenerateColumns="False" DataKeyNames="sessiontypeid" DataSourceID="EntityDataSource" AllowPaging="True" AllowSorting="True">
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
            <asp:BoundField DataField="sessiontypeid" HeaderText="id" ReadOnly="True" SortExpression="sessiontypeid" />
            <asp:BoundField DataField="typename" HeaderText="type" SortExpression="typename" />
            <asp:BoundField DataField="note" HeaderText="note" SortExpression="note" />
        </Columns>
    </asp:GridView>

    <br />
</asp:Content>
