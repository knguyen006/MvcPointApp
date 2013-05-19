<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PointAppTest.Default" %>
<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h2>LPAC Point Tracking System!</h2>
            </hgroup>
            <p>The purpose of create new web application is to form all data into one set of format and consistency. 
                This new web application will allow users track their fundraising point for individual account. 
                The requirement to create an account is a family must have one or more child that enrolls in the instrumental music program 
                through the school. 
                The parent or children can create their own account to track their volunteer hour through fundraising session to earn point. 
                The point will compute by family account not individual account. When the family earns point, they can apply to pay their 
                music program fee with their fundraising point. The request for this web application is having ability to create an account 
                with multiple email address, a statement of points, statement fee that student own, and ability to fill out an online form 
                where family can see the deduction fee amount through point. </p>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <ol class="round">
                <li class="one">
                    <h5>Student</h5>
                    This add student is monitor by administrator.  The administrator will have right to 
                    add/update/delete student record.
                </li>

                <li class="two">
                    <h5>Register</h5>
                    The only parent and student who are existing in student list would be able to
                    register.  Because application is only open for one high school.
                </li>

                <li class="three">
                    <h5>Add contact information</h5>
                    If the parent or student are be able to register.  They will have right to 
                    add their contact information and multiple email.
                </li>
                <li class="four">
                    <h5>Even calendar</h5>
                    The members are able to view event calendar and signup for volunteer.
                </li>
                <li class="five">
                    <h5>Sign up volunteer</h5>
                    Members can sign up for volunteer.
                </li>
                <li class="eight">
                    <h5>Member summary</h5>
                    Members can view their summary volunteer hour or point.
                </li>
                <li class="seven">
                    <h5>Request Deduction Point</h5>
                    Members can ask to deduction their fee out from point.  
                    This function is based on family.
                </li>
                </ol>
</asp:Content>

