<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Student.aspx.cs" Inherits="PointSiteTest.Student" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Student List</h3>
    <p><a href="AddStudent.aspx">Add new Student</a></p>
    
    <asp:EntityDataSource ID="StudentEntityDataSource" runat="server" ConnectionString="name=PointAppDBContainer" DefaultContainerName="PointAppDBContainer" EnableFlattening="False" EntitySetName="students" EnableDelete="True" EnableInsert="True" EnableUpdate="True">
    </asp:EntityDataSource>
    
    <asp:GridView ID="StudentGridView" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="studentid" DataSourceID="StudentEntityDataSource">
        <Columns>
            <asp:BoundField DataField="firstname" HeaderText="First" SortExpression="firstname" />
            <asp:BoundField DataField="lastname" HeaderText="Last" SortExpression="lastname" />
            <asp:BoundField DataField="middlename" HeaderText="Middle" SortExpression="middlename" />
            <asp:BoundField DataField="grade" HeaderText="Grade" SortExpression="grade" />
            <asp:BoundField DataField="active" HeaderText="Active" SortExpression="active" />
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
        </Columns>
    </asp:GridView>
    
    <br />

</asp:Content>
