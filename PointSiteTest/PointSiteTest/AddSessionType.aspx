<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddSessionType.aspx.cs" Inherits="PointSiteTest.AddSessionType" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Add New Session Type</h3>
   
    <asp:EntityDataSource ID="SessionTypeEntityDataSource" runat="server" 
        ConnectionString="name=PointAppDBContainer" DefaultContainerName="PointAppDBContainer" 
        EnableFlattening="False" EnableInsert="True" EntitySetName="sessiontypes">
    </asp:EntityDataSource>
   
    <asp:DetailsView ID="SessionTypeDetailsView" runat="server" AutoGenerateRows="False" 
        DataKeyNames="sessiontypeid" DataSourceID="SessionTypeEntityDataSource" DefaultMode="Insert">
        <Fields>
            <asp:BoundField DataField="typename" HeaderText="typename" SortExpression="typename" />
            <asp:BoundField DataField="note" HeaderText="note" SortExpression="note" />
            <asp:CommandField ShowInsertButton="true" />
        </Fields>
    </asp:DetailsView>
   <p><a id="A1" runat="server" href="~/SessionType.aspx">Go back to Session Type List</a></p>
    <br />
</asp:Content>
