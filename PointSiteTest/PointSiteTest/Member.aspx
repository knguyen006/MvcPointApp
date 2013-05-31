<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Member.aspx.cs" Inherits="PointSiteTest.Member" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Member List</h3>
    <asp:EntityDataSource ID="MemberEntityDataSource" runat="server" ConnectionString="name=PointAppDBContainer" DefaultContainerName="PointAppDBContainer" EnableDelete="True" EnableFlattening="False" EnableInsert="True" EnableUpdate="True" EntitySetName="members">
    </asp:EntityDataSource>

    <asp:GridView ID="MemberGridView" runat="server" AllowPaging="True" AllowSorting="True" 
        AutoGenerateColumns="False" DataKeyNames="memberid" DataSourceID="MemberEntityDataSource">
        <Columns>
            <asp:CommandField ShowDeleteButton="True" />
            <asp:BoundField DataField="memberid" HeaderText="memberid" ReadOnly="True" SortExpression="memberid" />
            <asp:BoundField DataField="username" HeaderText="username" SortExpression="username" />
            <asp:BoundField DataField="userpass" HeaderText="userpass" SortExpression="userpass" />
            <asp:BoundField DataField="passphrase" HeaderText="passphrase" SortExpression="passphrase" />
            <asp:BoundField DataField="membertype" HeaderText="membertype" SortExpression="membertype" />
            <asp:BoundField DataField="approleid" HeaderText="approleid" SortExpression="approleid" />
        </Columns>
    </asp:GridView>

    <asp:EntityDataSource ID="AppRoleEntityDataSource" runat="server" ConnectionString="name=PointAppDBContainer" DefaultContainerName="PointAppDBContainer" EnableFlattening="False" EntitySetName="approles" Select="it.[approleid], it.[rolename]">
    </asp:EntityDataSource>

    <asp:DropDownList ID="AppRoleDropDownList" runat="server" DataSourceID="AppRoleEntityDataSource" DataTextField="approleid" DataValueField="approleid">
    </asp:DropDownList>

    <br />
</asp:Content>
