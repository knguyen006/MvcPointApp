<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Student.aspx.cs" Inherits="PointSiteTest.Student" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Student List</h3>
    <p><a href="AddStudent.aspx">Add new Student</a></p>
    <asp:EntityDataSource ID="EntityDataSource" runat="server" ConnectionString="name=PointAppDBContainer" DefaultContainerName="PointAppDBContainer" EnableDelete="True" EnableFlattening="False" EnableInsert="True" EnableUpdate="True" EntitySetName="students">
    </asp:EntityDataSource>
    <table border="1">
        <tr>
            <th>ID</th>
            <th>First</th>
            <th>Last</th>
            <th>Middle</th>
            <th>Grade</th>
            <th>Active</th>
            <td></td>
       </tr>
        <asp:Repeater ID="Repeater1" runat="server" DataSourceID="EntityDataSource">
        <ItemTemplate> 
       <tr>
           <td><%# Eval("studentid") %> </td>
           <td><%# Eval("firstname") %> </td>
           <td><%# Eval("lastname") %> </td>
           <td><%# Eval("middlename") %> </td>
           <td><%# Eval("grade") %> </td>
           <td><%# Eval("active") %> </td> 
           <td>Update</td>         
       </tr>
       </ItemTemplate>
    </asp:Repeater>
    </table>
    <br />

</asp:Content>
