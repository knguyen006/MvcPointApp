<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddStudent.aspx.cs" Inherits="PointSiteTest.AddStudent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Add Student</h3>
    <asp:EntityDataSource ID="StudentEntityDataSource" runat="server" 
        ConnectionString="name=PointAppDBContainer" DefaultContainerName="PointAppDBContainer" 
        EnableFlattening="False" EntitySetName="students"
        EnableInsert="true">
    </asp:EntityDataSource>
    <asp:DetailsView ID="StudentDetailsView" runat="server" AutoGenerateRows="False"
        DataSourceID="StudentEntityDataSource" DataKeyNames="studentid"
        DefaultMode="Insert">
        <Fields>
            <asp:BoundField DataField="firstname" HeaderText="firstname" />
            <asp:BoundField DataField="lastname" HeaderText="lastname" />
            <asp:BoundField DataField="middlename" HeaderText="middlename" />
            <asp:BoundField DataField="grade" HeaderText="grade" />
            <asp:BoundField DataField="active" HeaderText="active" />
            <asp:CommandField ShowInsertButton="true" />
        </Fields>
    </asp:DetailsView>
    <p><a id="A1" runat="server" href="~/Student.aspx">Go back to student list</a></p>
</asp:Content>


